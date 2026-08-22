using System.Composition;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace EasyBiz
{
    public partial class CashBook : Form
    {
        // Guards against overlapping loads (e.g. rapid F5 presses) and lets
        // Escape / form-close wait for an in-flight operation instead of
        // tearing the form down mid-query.
        private CancellationTokenSource? _cts;
        private Task _pendingOperation = Task.CompletedTask;

        public CashBook()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            ThemeManager.ApplyTheme(this);

            // Constructors can't be async, so kick off the initial load as a
            // fire-and-forget task. Errors are still handled inside
            // LoadCashBookEntriesAsync's own try/catch.
            _ = LoadCashBookEntriesAsync();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    _ = BtnLoad_ClickAsync();
                    return true;

                case Keys.F1:
                    _ = BtnExport_ClickAsync();
                    return true;

                case Keys.Escape:
                    this.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            // Give any in-flight DB/PDF work a chance to finish/cancel
            // cleanly instead of disposing the form underneath it.
            _cts?.Cancel();
            try
            {
                await _pendingOperation;
            }
            catch
            {
                // Already surfaced to the user where it happened.
            }
            base.OnFormClosing(e);
        }

        private async Task<decimal> GetOpeningBalanceAsync(DbConnection connection, DateTime beforeDate, CancellationToken ct)
        {
            decimal storedOB = 0;
            await using (var obCmd = connection.CreateCommand())
            {
                obCmd.CommandText = "SELECT IFNULL(opening_balance, 0) FROM accounts WHERE account_id BETWEEN 10001 AND 20000";
                var obResult = await obCmd.ExecuteScalarAsync(ct);

                // Safely check for null/DBNull just in case the account row doesn't exist yet
                storedOB = obResult == null || obResult == DBNull.Value ? 0m : Convert.ToDecimal(obResult);
            }

            await using var cmd = connection.CreateCommand();

            // FIX: Changed the WHERE clause to match the logic used in your main transaction queries
            cmd.CommandText = @"
        SELECT IFNULL(SUM(credit), 0) - IFNULL(SUM(debit), 0)
        FROM   transactions
        WHERE  date(transaction_date) < date(@BeforeDate)
        AND (
    account_id < 10001
    OR account_id >= 20001
    OR transaction_type IN ('Journal Voucher')
    )
    AND transaction_type NOT IN ('Sale Invoice', 'Purchase Invoice')
";

            var p = cmd.CreateParameter();
            p.ParameterName = "@BeforeDate";
            p.DbType = System.Data.DbType.String;
            p.Value = beforeDate.Date.ToString("yyyy-MM-dd");
            cmd.Parameters.Add(p);

            var result = await cmd.ExecuteScalarAsync(ct);
            decimal txMovement = result == null || result == DBNull.Value ? 0m : Convert.ToDecimal(result);

            return storedOB + txMovement;
        }

        private async Task PrintCashbookAsync()
        {
            var cts = new CancellationTokenSource();
            _cts = cts;
            var ct = cts.Token;

            BtnExport.Enabled = false;
            try
            {
                // 1. Opening balance
                decimal openingBalance;
                await using (var connection = DatabaseHelper.GetConnection())
                    openingBalance = await GetOpeningBalanceAsync(connection, dateFrom.Value.Date, ct);

                // 2. Load transactions for the period
                var rows = new List<CashbookRow>();
                decimal runningBalance = openingBalance;

                await using (var connection = DatabaseHelper.GetConnection())
                await using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
            SELECT
                transaction_date,
                transaction_type,
                voucher_no,
                account_name,
                description,
                debit,
                credit
            FROM transactions
            WHERE date(transaction_date) BETWEEN date(@FromDate) AND date(@ToDate)
            AND (
    account_id < 10001
    OR account_id >= 20001
    OR transaction_type IN ('Journal Voucher')
    )
    AND transaction_type NOT IN ('Sale Invoice', 'Purchase Invoice')
            ORDER BY transaction_type ASC, transaction_date ASC";

                    cmd.Parameters.AddWithValue("@FromDate", dateFrom.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ToDate", dateTo.Value.ToString("yyyy-MM-dd"));
                    
                    await using (var reader = await cmd.ExecuteReaderAsync(ct))
                    {
                        int srNo = 1;
                        while (await reader.ReadAsync(ct))
                        {
                            decimal debit = await reader.IsDBNullAsync(5, ct) ? 0 : Convert.ToDecimal(reader["debit"]);
                            decimal credit = await reader.IsDBNullAsync(6, ct) ? 0 : Convert.ToDecimal(reader["credit"]);

                            runningBalance += credit - debit;

                            rows.Add(new CashbookRow
                            {
                                SrNo = srNo++,
                                Date = Convert.ToDateTime(reader["transaction_date"]).ToString("dd-MMM-yyyy"),
                                VoucherNo = reader["voucher_no"]?.ToString() ?? "",
                                Type = reader["transaction_type"]?.ToString() ?? "",
                                Description = reader["description"]?.ToString() ?? "",
                                AccountName = reader["account_name"]?.ToString() ?? "",
                                CashIn = credit,   // in your schema credit = money coming IN
                                CashOut = debit,   // debit = money going OUT
                                Balance = runningBalance
                            });
                        }
                    }
                }

                // Define your target directory (e.g., the system's Application Data folder)
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                folderPath = Path.Combine(folderPath, "CashbookAIReports");

                // Ensure the directory exists; create it if it doesn't
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Combine folder path and file name to get the full file path
                string filePath = Path.Combine(folderPath, "Cashbook.pdf");

                // 4. Generate PDF off the UI thread — QuestPDF generation is
                // CPU/IO bound and synchronous, so Task.Run keeps the UI responsive.
                try
                {
                    await Task.Run(() => CashbookReportPDF.Generate(
                        outputPath: filePath,
                        cashAccountName: "Cash Accounts",
                        branchOrLocation: "",
                        fromDate: dateFrom.Value.Date,
                        toDate: dateTo.Value.Date,
                        openingBalance: openingBalance,
                        rows: rows), ct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to generate PDF:\n\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Pass the file path to the ViewReports form and show it
                using ViewReports viewReports = new ViewReports(filePath);
                viewReports.ShowDialog();
            }
            catch (OperationCanceledException)
            {
                // Form closed / superseded while exporting — nothing to report.
            }
            finally
            {
                if (_cts == cts) _cts = null;
                if (!IsDisposed) BtnExport.Enabled = true;
            }
        }

        public async Task LoadCashBookEntriesAsync()
        {
            var cts = new CancellationTokenSource();
            _cts = cts;
            var ct = cts.Token;

            BtnLoad.Enabled = false;
            try
            {
                dataGridView1.SuspendLayout();

                // Clear old rows
                dataGridView1.Rows.Clear();

                decimal totalDebit = 0;
                decimal totalCredit = 0;
                decimal runningBalance = 0;
                decimal openingBalance;

                await using (var connection = DatabaseHelper.GetConnection())
                {
                    // =========================================
                    // GET OPENING BALANCE (Fixed to match PrintCashbook)
                    // =========================================
                    openingBalance = await GetOpeningBalanceAsync(connection, dateFrom.Value.Date, ct);
                    runningBalance = openingBalance;

                    int srNo = 1;

                    // =========================================
                    // ADD OPENING BALANCE ROW (Fixed columns count)
                    // =========================================

                    int rowIndex = dataGridView1.Rows.Add();

                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    row.Cells["sno"].Value = srNo++;
                    row.Cells["date"].Value = dateFrom.Value.ToString("dd-MM-yyyy");
                    row.Cells["type"].Value = "Opening Balance";
                    row.Cells["accountname"].Value = "Cash Accounts";
                    row.Cells["desc"].Value = "Brought Forward Opening Balance";
                    if (runningBalance < 0)
                    {
                        row.Cells["debit"].Value = "0";
                        // Math.Abs removes the negative sign
                        row.Cells["credit"].Value = Math.Abs(runningBalance).ToString("N0");
                    }
                    else
                    {
                        row.Cells["debit"].Value = runningBalance.ToString("N0");
                        row.Cells["credit"].Value = "0";
                    }

                    // =========================================
                    // LOAD CASH BOOK ENTRIES
                    // =========================================
                    await using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
        SELECT 
            transaction_date,
            transaction_type,
            voucher_no,
            account_name,
            description,
            debit,
            credit
        FROM transactions
        WHERE date(transaction_date) BETWEEN date(@fromDate) AND date(@toDate)
        AND (
    account_id < 10001
    OR account_id >= 20001
    OR transaction_type IN ('Journal Voucher')
    )
    AND transaction_type NOT IN ('Sale Invoice', 'Purchase Invoice')
        ORDER BY transaction_type ASC, transaction_date ASC";

                        // Bind as formatted strings, same as PrintCashbookAsync(), not DbType.Date
                        command.Parameters.AddWithValue("@fromDate", dateFrom.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@toDate", dateTo.Value.ToString("yyyy-MM-dd"));

                        await using (var reader = await command.ExecuteReaderAsync(ct))
                        {
                            while (await reader.ReadAsync(ct))
                            {
                                // =========================================
                                // SAFE VALUE READING (Fixed Indexes)
                                // =========================================
                                DateTime transactionDate = await reader.IsDBNullAsync(0, ct)
                                    ? DateTime.Now
                                    : Convert.ToDateTime(reader["transaction_date"]);

                                string transactionType = reader["transaction_type"]?.ToString() ?? "";
                                string voucherNo = reader["voucher_no"]?.ToString() ?? "";
                                string accountName = reader["account_name"]?.ToString() ?? "";
                                string description = reader["description"]?.ToString() ?? "";

                                // Fixed: Debit is index 5, Credit is index 6
                                decimal debit = await reader.IsDBNullAsync(5, ct) ? 0 : Convert.ToDecimal(reader["debit"]);
                                decimal credit = await reader.IsDBNullAsync(6, ct) ? 0 : Convert.ToDecimal(reader["credit"]);

                                // =========================================
                                // TOTALS & BALANCE
                                // =========================================
                                totalDebit += debit;
                                totalCredit += credit;
                                runningBalance += credit - debit;

                                // =========================================
                                // ADD ROW
                                // =========================================
                                dataGridView1.Rows.Add(
                                    srNo++,
                                    transactionDate.ToString("dd-MM-yyyy"),
                                    transactionType + " #" + voucherNo,
                                    accountName,
                                    description,
                                    debit.ToString("N0"),
                                    credit.ToString("N0"),
                                    runningBalance.ToString("N0")
                                );
                            }
                        }
                    }
                }

                // =========================================
                // SHOW TOTALS
                // =========================================
                lblTotalDr.Text = $"Debit: {totalDebit:N2}";
                lblTotalCr.Text = $"Credit: {totalCredit:N2}";

                if (runningBalance > 0)
                    lblRunningBalance.ForeColor = Color.Green;
                else
                    lblRunningBalance.ForeColor = Color.Red;

                lblRunningBalance.Text = $"Balance: {runningBalance:N2}";
            }
            catch (OperationCanceledException)
            {
                // Form closed / superseded while loading — nothing to report.
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading cash book entries.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (!IsDisposed)
                {
                    dataGridView1.ResumeLayout();
                    BtnLoad.Enabled = true;
                }
                if (_cts == cts) _cts = null;
            }
        }

        private async Task BtnLoad_ClickAsync()
        {
            await LoadCashBookEntriesAsync();
        }

        private async void BtnLoad_Click(object sender, EventArgs e)
        {
            await BtnLoad_ClickAsync();
        }

        private async Task BtnExport_ClickAsync()
        {
            await PrintCashbookAsync();
        }

        private async void BtnExport_Click(object sender, EventArgs e)
        {
            await BtnExport_ClickAsync();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Ensure we are not processing header rows or invalid row indices
            if (e.RowIndex < 0) return;

            // 2. Check if the current column being formatted is the "Type" column
            // (Ensure "Type" matches the exact .Name property of your column)
            if (dataGridView1.Columns[e.ColumnIndex].Name == "type")
            {
                if (e.Value != null)
                {
                    string transactionType = e.Value.ToString().Trim();
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // 3. Apply custom colors to the ENTIRE row based on the Type value
                    if (transactionType == "Opening Balance")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 242, 255); // Very soft blue
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 102, 204);   // Deep blue text
                    }
                    else if (transactionType.StartsWith("Cash Payment"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235); // Soft red/pink
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(153, 0, 0);     // Dark red text
                    }
                    else if (transactionType.StartsWith("Cash Receipt"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235); // Soft green
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 102, 0);     // Dark green text
                    }
                    else if (transactionType.StartsWith("Journal Voucher"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 235); // Soft yellow
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(153, 153, 0);   // Dark yellow text
                    }
                    else if (transactionType.StartsWith("Purchase Invoice"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 235, 255); // Soft purple
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(102, 0, 102);   // Dark purple text
                    }
                    else if (transactionType.StartsWith("Sale Invoice"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255); // Soft cyan
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 102, 102);   // Dark cyan text
                    }
                    else if (transactionType.StartsWith("Bank Payment"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 255); // Soft blue
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 153);     // Dark blue text
                    }
                    else if (transactionType.StartsWith("Bank Receipt"))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 255); // Soft cyan
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 153, 153);   // Dark cyan text
                    }
                    else
                    {
                        // 4. Default reset fallback to prevent scrolling display bugs
                        row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }
    }
}