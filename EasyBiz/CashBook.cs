using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class CashBook : Form
    {
        // Tracks the currently running operation so F5/F1 cannot leave
        // overlapping database/PDF operations running against the same form.
        private CancellationTokenSource? _cts;
        private Task _pendingOperation = Task.CompletedTask;

        public CashBook()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            ThemeManager.ApplyTheme(this);            

            // Constructors cannot be async.
            _pendingOperation = LoadCashBookEntriesAsync();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    _pendingOperation = BtnLoad_ClickAsync();
                    return true;

                case Keys.F1:
                    _pendingOperation = BtnExport_ClickAsync();
                    return true;

                case Keys.Escape:
                    Close();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();

            try
            {
                await _pendingOperation;
            }
            catch
            {
                // The operation handles/suppresses its own errors.
            }

            base.OnFormClosing(e);
        }

        /// <summary>
        /// Gets the cash-book balance immediately before the selected From Date.
        /// Positive balance means cash available; negative means an overdrawn
        /// cash balance according to the existing EasyBiz cash-book convention.
        /// </summary>
        private async Task<decimal> GetOpeningBalanceAsync(
            DbConnection connection,
            DateTime beforeDate,
            CancellationToken ct)
        {
            decimal storedOpeningBalance = 0m;

            // Stored opening balance from the accounts table.
            await using (var obCmd = connection.CreateCommand())
            {
                obCmd.CommandText = @"
SELECT IFNULL(SUM(opening_balance), 0)
FROM accounts
WHERE account_id BETWEEN 10001 AND 20000;";

                object? obResult = await obCmd.ExecuteScalarAsync(ct);

                storedOpeningBalance =
                    obResult == null || obResult == DBNull.Value
                        ? 0m
                        : Convert.ToDecimal(obResult);
            }

            // Add all cash-book movements before the selected date.
            //
            // IMPORTANT:
            // Sale Invoice is reversed for the cash-book because the existing
            // transactions table stores its debit/credit direction opposite
            // to the cash-book presentation.
            //
            // TRIM + LOWER makes transaction-type matching tolerant of:
            //   "Sale Invoice"
            //   "Sale Invoice "
            //   "sale invoice"
            // etc.
            await using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
SELECT IFNULL(
    SUM(
        CASE
            WHEN LOWER(TRIM(COALESCE(transaction_type, ''))) = 'sale invoice'
                THEN COALESCE(debit, 0) - COALESCE(credit, 0)

            ELSE
                COALESCE(credit, 0) - COALESCE(debit, 0)
        END
    ),
    0
)
FROM transactions
WHERE date(transaction_date) < date(@BeforeDate)
AND
(
    account_id < 10001
    OR account_id >= 20001
    OR LOWER(TRIM(COALESCE(transaction_type, ''))) IN
    (
        'journal voucher',
        'sale invoice',
        'purchase invoice',
        'cash payment',
        'cash receipt',
        'bank payment',
        'bank receipt'
    )
);";

            var p = cmd.CreateParameter();
            p.ParameterName = "@BeforeDate";
            p.DbType = DbType.String;
            p.Value = beforeDate.Date.ToString("yyyy-MM-dd");
            cmd.Parameters.Add(p);

            object? result = await cmd.ExecuteScalarAsync(ct);

            decimal transactionMovement =
                result == null || result == DBNull.Value
                    ? 0m
                    : Convert.ToDecimal(result);

            return storedOpeningBalance + transactionMovement;
        }

        /// <summary>
        /// SQL used by both the DataGridView and PDF export.
        /// Keeping the query in one place prevents the grid and report from
        /// showing different transactions.
        /// </summary>
        private const string CashBookTransactionSql = @"
SELECT
    transaction_date,
    transaction_type,
    voucher_no,
    account_name,
    description,

    CASE
        WHEN LOWER(TRIM(COALESCE(transaction_type, ''))) = 'sale invoice'
            THEN COALESCE(credit, 0)
        ELSE
            COALESCE(debit, 0)
    END AS debit,

    CASE
        WHEN LOWER(TRIM(COALESCE(transaction_type, ''))) = 'sale invoice'
            THEN COALESCE(debit, 0)
        ELSE
            COALESCE(credit, 0)
    END AS credit

FROM transactions

WHERE date(transaction_date) BETWEEN date(@fromDate) AND date(@toDate)

AND
(
    account_id < 10001
    OR account_id >= 20001

    OR LOWER(TRIM(COALESCE(transaction_type, ''))) IN
    (
        'journal voucher',
        'sale invoice',
        'purchase invoice',
        'cash payment',
        'cash receipt',
        'bank payment',
        'bank receipt'
    )
)

-- Do NOT display the ""Cash In Hand"" counterpart
-- for Cash Payment / Cash Receipt transactions.
AND NOT
(
    LOWER(TRIM(COALESCE(account_name, ''))) = 'cash in hand'
    AND LOWER(TRIM(COALESCE(transaction_type, ''))) IN
    (
        'cash payment',
        'cash receipt'
    )
)";

        private static string SafeString(DbDataReader reader, string columnName)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(ordinal))
                return string.Empty;

            return reader.GetValue(ordinal)?.ToString()?.Trim() ?? string.Empty;
        }

        private static decimal SafeDecimal(DbDataReader reader, string columnName)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(ordinal))
                return 0m;

            return Convert.ToDecimal(reader.GetValue(ordinal));
        }

        private static DateTime SafeDate(DbDataReader reader, string columnName)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(ordinal))
                return DateTime.MinValue;

            object value = reader.GetValue(ordinal);

            if (value is DateTime dateTime)
                return dateTime;

            if (DateTime.TryParse(value?.ToString(), out DateTime parsed))
                return parsed;

            return DateTime.MinValue;
        }

        private async Task PrintCashbookAsync()
        {
            using var cts = new CancellationTokenSource();
            _cts = cts;
            CancellationToken ct = cts.Token;

            BtnExport.Enabled = false;

            try
            {
                DateTime fromDate = dateFrom.Value.Date;
                DateTime toDate = dateTo.Value.Date;

                // 1. Opening balance
                decimal openingBalance;

                await using (var connection = DatabaseHelper.GetConnection())
                {
                    openingBalance =
                        await GetOpeningBalanceAsync(connection, fromDate, ct);
                }

                // 2. Load transactions for the selected period
                var rows = new List<CashbookRow>();
                decimal runningBalance = openingBalance;

                await using (var connection = DatabaseHelper.GetConnection())
                await using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = CashBookTransactionSql;

                    cmd.Parameters.AddWithValue(
                        "@fromDate",
                        fromDate.ToString("yyyy-MM-dd"));

                    cmd.Parameters.AddWithValue(
                        "@toDate",
                        toDate.ToString("yyyy-MM-dd"));

                    await using var reader =
                        await cmd.ExecuteReaderAsync(ct);

                    int srNo = 1;

                    while (await reader.ReadAsync(ct))
                    {
                        DateTime transactionDate =
                            SafeDate(reader, "transaction_date");

                        string transactionType =
                            SafeString(reader, "transaction_type");

                        string voucherNo =
                            SafeString(reader, "voucher_no");

                        string description =
                            SafeString(reader, "description");

                        string accountName =
                            SafeString(reader, "account_name");

                        decimal debit =
                            SafeDecimal(reader, "debit");

                        decimal credit =
                            SafeDecimal(reader, "credit");

                        runningBalance += credit - debit;

                        rows.Add(new CashbookRow
                        {
                            SrNo = srNo++,
                            Date = transactionDate == DateTime.MinValue
                                ? string.Empty
                                : transactionDate.ToString("dd-MMM-yyyy"),

                            VoucherNo = voucherNo,
                            Type = transactionType,
                            Description = description,
                            AccountName = accountName,

                            // CashIn = money received.
                            CashIn = credit,

                            // CashOut = money paid.
                            CashOut = debit,

                            Balance = runningBalance
                        });
                    }
                }

                // 3. Report directory
                string folderPath = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.ApplicationData),
                    "CashbookAIReports");

                Directory.CreateDirectory(folderPath);

                string filePath =
                    Path.Combine(folderPath, "Cashbook.pdf");

                // 4. Generate PDF away from the UI thread.
                try
                {
                    await Task.Run(
                        () => CashbookReportPDF.Generate(
                            outputPath: filePath,
                            cashAccountName: "Cash Accounts",
                            branchOrLocation: "",
                            fromDate: fromDate,
                            toDate: toDate,
                            openingBalance: openingBalance,
                            rows: rows),
                        ct);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to generate PDF:\n\n{ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (IsDisposed || Disposing)
                    return;

                // 5. Show generated report
                using var viewReports = new ViewReports(filePath);
                viewReports.ShowDialog(this);
            }
            catch (OperationCanceledException)
            {
                // Operation was cancelled because the form was closed or
                // another operation replaced the current operation.
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing)
                {
                    MessageBox.Show(
                        "Error exporting cash book.\n\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (_cts == cts)
                    _cts = null;

                if (!IsDisposed && !Disposing)
                    BtnExport.Enabled = true;
            }
        }

        public async Task LoadCashBookEntriesAsync()
        {
            using var cts = new CancellationTokenSource();
            _cts = cts;
            CancellationToken ct = cts.Token;

            BtnLoad.Enabled = false;

            try
            {
                dataGridView1.SuspendLayout();

                dataGridView1.Rows.Clear();

                decimal totalDebit = 0m;
                decimal totalCredit = 0m;
                decimal runningBalance;

                DateTime fromDate = dateFrom.Value.Date;
                DateTime toDate = dateTo.Value.Date;

                await using (var connection = DatabaseHelper.GetConnection())
                {
                    // =========================================
                    // OPENING BALANCE
                    // =========================================
                    decimal openingBalance =
                        await GetOpeningBalanceAsync(
                            connection,
                            fromDate,
                            ct);

                    runningBalance = openingBalance;

                    int srNo = 1;

                    // =========================================
                    // ADD OPENING BALANCE ROW
                    // =========================================
                    int rowIndex = dataGridView1.Rows.Add();

                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    row.Cells["sno"].Value = srNo++;
                    row.Cells["date"].Value = fromDate.ToString("dd-MM-yyyy");

                    row.Cells["type"].Value = "Opening Balance";
                    row.Cells["accountname"].Value = "Cash Accounts";
                    row.Cells["desc"].Value = "Brought Forward Opening Balance";

                    if (runningBalance < 0)
                    {
                        row.Cells["debit"].Value = "0";
                        decimal openingCredit = Math.Abs(runningBalance);
                        row.Cells["credit"].Value = openingCredit.ToString("N0");

                        // FIX: Add the opening balance to the total credit
                        totalCredit += openingCredit;
                    }
                    else
                    {
                        row.Cells["debit"].Value = runningBalance.ToString("N0");
                        row.Cells["credit"].Value = "0";

                        // FIX: Add the opening balance to the total debit
                        totalDebit += runningBalance;
                    }
                    

                    // =========================================
                    // LOAD CASH BOOK TRANSACTIONS
                    // =========================================
                    await using (var command = connection.CreateCommand())
                    {
                        command.CommandText = CashBookTransactionSql;

                        command.Parameters.AddWithValue(
                            "@fromDate",
                            fromDate.ToString("yyyy-MM-dd"));

                        command.Parameters.AddWithValue(
                            "@toDate",
                            toDate.ToString("yyyy-MM-dd"));

                        await using var reader =
                            await command.ExecuteReaderAsync(ct);

                        while (await reader.ReadAsync(ct))
                        {
                            DateTime transactionDate =
                                SafeDate(reader, "transaction_date");

                            string transactionType =
                                SafeString(reader, "transaction_type");

                            string voucherNo =
                                SafeString(reader, "voucher_no");

                            string accountName =
                                SafeString(reader, "account_name");

                            string description =
                                SafeString(reader, "description");

                            decimal debit =
                                SafeDecimal(reader, "debit");

                            decimal credit =
                                SafeDecimal(reader, "credit");

                            // =========================================
                            // TOTALS & RUNNING BALANCE
                            // =========================================
                            totalDebit += debit;
                            totalCredit += credit;

                            runningBalance += credit - debit;

                            // =========================================
                            // DISPLAY TRANSACTION
                            // =========================================
                            dataGridView1.Rows.Add(
                                srNo++,

                                transactionDate == DateTime.MinValue
                                    ? ""
                                    : transactionDate.ToString("dd-MM-yyyy"),

                                string.IsNullOrWhiteSpace(voucherNo)
                                    ? transactionType
                                    : transactionType + " #" + voucherNo,

                                accountName,
                                description,
                                debit.ToString("N0"),
                                credit.ToString("N0"),
                                runningBalance.ToString("N0")
                            );
                        }
                    }
                }

                // =========================================
                // SHOW TOTALS
                // =========================================
                lblTotalDr.Text =
                    $"Debit: {totalDebit:N2}";

                lblTotalCr.Text =
                    $"Credit: {totalCredit:N2}";

                if (runningBalance > 0)
                {
                    lblRunningBalance.ForeColor = Color.Green;
                }
                else if (runningBalance < 0)
                {
                    lblRunningBalance.ForeColor = Color.Red;
                }
                else
                {
                    lblRunningBalance.ForeColor =
                        dataGridView1.DefaultCellStyle.ForeColor;
                }

                lblRunningBalance.Text =
                    $"Balance: {totalCredit - totalDebit:N2}";
            }
            catch (OperationCanceledException)
            {
                // Form closed or operation cancelled.
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing)
                {
                    MessageBox.Show(
                        "Error loading cash book entries.\n\n" +
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (!IsDisposed && !Disposing)
                {
                    dataGridView1.ResumeLayout();
                    BtnLoad.Enabled = true;
                }

                if (_cts == cts)
                    _cts = null;
            }
        }

        private async Task BtnLoad_ClickAsync()
        {
            await LoadCashBookEntriesAsync();
        }

        private async void BtnLoad_Click(
            object sender,
            EventArgs e)
        {
            _pendingOperation = BtnLoad_ClickAsync();
            await _pendingOperation;
        }

        private async Task BtnExport_ClickAsync()
        {
            await PrintCashbookAsync();
        }

        private async void BtnExport_Click(
            object sender,
            EventArgs e)
        {
            _pendingOperation = BtnExport_ClickAsync();
            await _pendingOperation;
        }

        private void dataGridView1_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0 ||
                e.ColumnIndex >= dataGridView1.Columns.Count)
            {
                return;
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name != "type")
                return;

            if (e.Value == null)
                return;

            string transactionType =
                e.Value.ToString()?.Trim() ?? string.Empty;

            DataGridViewRow row =
                dataGridView1.Rows[e.RowIndex];

            // Reset first so recycled rows do not retain an old color.
            row.DefaultCellStyle.BackColor =
                dataGridView1.DefaultCellStyle.BackColor;

            row.DefaultCellStyle.ForeColor =
                dataGridView1.DefaultCellStyle.ForeColor;

            if (transactionType.Equals(
                    "Opening Balance",
                    StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(230, 242, 255);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(0, 102, 204);
            }
            else if (transactionType.StartsWith(
                         "Cash Payment",
                         StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(255, 235, 235);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(153, 0, 0);
            }
            else if (transactionType.StartsWith(
                         "Cash Receipt",
                         StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(235, 255, 235);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(0, 102, 0);
            }
            else if (transactionType.StartsWith(
                         "Journal Voucher",
                         StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(255, 255, 235);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(153, 153, 0);
            }
            else if (transactionType.StartsWith(
                         "Purchase Invoice",
                         StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(245, 235, 255);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(102, 0, 102);
            }
            else if (transactionType.StartsWith(
                         "Sale Invoice",
                         StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(235, 245, 255);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(0, 102, 102);
            }
            else if (transactionType.StartsWith(
                         "Bank Payment",
                         StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(235, 235, 255);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(0, 0, 153);
            }
            else if (transactionType.StartsWith(
                         "Bank Receipt",
                         StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor =
                    Color.FromArgb(235, 255, 255);

                row.DefaultCellStyle.ForeColor =
                    Color.FromArgb(0, 153, 153);
            }
        }
    }
}