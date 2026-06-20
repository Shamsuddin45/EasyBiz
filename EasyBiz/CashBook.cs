using System.Data;

namespace EasyBiz
{
    public partial class CashBook : Form
    {
        public CashBook()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadCashBookEntries();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    BtnLoad_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F1:
                    BtnExport_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Escape:
                    this.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private decimal GetOpeningBalance(System.Data.Common.DbConnection connection, DateTime beforeDate)
        {
            // Stored opening balance of Cash In Hand (account_id = 10001)
            decimal storedOB = 0;
            using (var obCmd = connection.CreateCommand())
            {
                obCmd.CommandText = "SELECT IFNULL(opening_balance, 0) FROM accounts WHERE account_id = 10001";
                storedOB = Convert.ToDecimal(obCmd.ExecuteScalar());
            }

            // Transaction movement before beforeDate (excluding Cash In Hand account rows)
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
        SELECT IFNULL(SUM(credit), 0) - IFNULL(SUM(debit), 0)
        FROM   transactions
        WHERE  date(transaction_date) < date(@BeforeDate)
        AND    lower(account_name) != 'cash in hand'";

            var p = cmd.CreateParameter();
            p.ParameterName = "@BeforeDate";
            p.DbType = System.Data.DbType.Date;
            p.Value = beforeDate.Date;
            cmd.Parameters.Add(p);

            var result = cmd.ExecuteScalar();
            decimal txMovement = result == null || result == DBNull.Value ? 0m : Convert.ToDecimal(result);

            return storedOB + txMovement;
        }

        private void PrintCashbook()
        {
            // 1. Opening balance
            decimal openingBalance = 0;
            using (var connection = DatabaseHelper.GetConnection())
                openingBalance = GetOpeningBalance(connection, dateFrom.Value.Date);

            // 2. Load transactions for the period
            var rows = new List<CashbookRow>();
            decimal runningBalance = openingBalance;

            using (var connection = DatabaseHelper.GetConnection())
            using (var cmd = connection.CreateCommand())
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
            AND   lower(account_name) != 'cash in hand'
            ORDER BY transaction_type ASC, transaction_date ASC";

                cmd.Parameters.AddWithValue("@FromDate", dateFrom.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ToDate", dateTo.Value.ToString("yyyy-MM-dd"));

                using (var reader = cmd.ExecuteReader())
                {
                    int srNo = 1;
                    while (reader.Read())
                    {
                        decimal debit = reader.IsDBNull(5) ? 0 : Convert.ToDecimal(reader["debit"]);
                        decimal credit = reader.IsDBNull(6) ? 0 : Convert.ToDecimal(reader["credit"]);

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
                            CashOut = debit,    // debit = money going OUT
                            Balance = runningBalance
                        });
                    }
                }
            }

            // 3. Save-file dialog
            using var saveDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Cashbook Report",
                FileName = $"Cashbook_{dateFrom.Value:ddMMMyyyy}_to_{dateTo.Value:ddMMMyyyy}.pdf"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            // 4. Generate PDF
            try
            {
                CashbookReportPDF.Generate(
                    outputPath: saveDialog.FileName,
                    cashAccountName: "Cash In Hand",
                    branchOrLocation: "",
                    fromDate: dateFrom.Value.Date,
                    toDate: dateTo.Value.Date,
                    openingBalance: openingBalance,
                    rows: rows);

                var open = MessageBox.Show(
                    $"Cashbook exported successfully!\n\n{saveDialog.FileName}\n\nOpen the file now?",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (open == DialogResult.Yes)
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(saveDialog.FileName)
                        { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadCashBookEntries()
        {
            try
            {
                dataGridView1.SuspendLayout();

                // Clear old rows
                dataGridView1.Rows.Clear();

                decimal totalDebit = 0;
                decimal totalCredit = 0;
                decimal runningBalance = 0;
                decimal openingBalance = 0;

                using (var connection = DatabaseHelper.GetConnection())
                {
                    // =========================================
                    // GET OPENING BALANCE (Fixed to match PrintCashbook)
                    // =========================================
                    openingBalance = GetOpeningBalance(connection, dateFrom.Value.Date);
                    runningBalance = openingBalance;

                    int srNo = 1;

                    // =========================================
                    // ADD OPENING BALANCE ROW (Fixed columns count)
                    // =========================================
                    dataGridView1.Rows.Add(
                        srNo++,
                        dateFrom.Value.ToString("dd-MM-yyyy"),
                        "Opening Balance",
                        "Cash In Hand",
                        "Brought Forward Opening Balance",
                        "0",                            // Debit Column
                        "0",                            // Credit Column
                        runningBalance.ToString("N0")   // Balance Column
                    );

                    // =========================================
                    // LOAD CASH BOOK ENTRIES
                    // =========================================
                    using (var command = connection.CreateCommand())
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
                    AND lower(account_name) != 'cash in hand'
                    ORDER BY transaction_type ASC, transaction_date ASC";

                        command.Parameters.AddWithValue("@fromDate", dateFrom.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@toDate", dateTo.Value.ToString("yyyy-MM-dd"));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // =========================================
                                // SAFE VALUE READING (Fixed Indexes)
                                // =========================================
                                DateTime transactionDate = reader.IsDBNull(0)
                                    ? DateTime.Now
                                    : Convert.ToDateTime(reader["transaction_date"]);

                                string transactionType = reader["transaction_type"]?.ToString() ?? "";
                                string voucherNo = reader["voucher_no"]?.ToString() ?? "";
                                string accountName = reader["account_name"]?.ToString() ?? "";
                                string description = reader["description"]?.ToString() ?? "";

                                // Fixed: Debit is index 5, Credit is index 6
                                decimal debit = reader.IsDBNull(5) ? 0 : Convert.ToDecimal(reader["debit"]);
                                decimal credit = reader.IsDBNull(6) ? 0 : Convert.ToDecimal(reader["credit"]);

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
                dataGridView1.ResumeLayout();
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadCashBookEntries();
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
                    else
                    {
                        // 4. Default reset fallback to prevent scrolling display bugs
                        row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            PrintCashbook();
        }
    }
}
