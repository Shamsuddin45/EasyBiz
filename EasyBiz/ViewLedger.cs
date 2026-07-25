using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Data;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class ViewLedger : Form
    {
        public ViewLedger()
        {
            InitializeComponent();
            LoadAccounts();
            setupDates();
            ThemeManager.ApplyTheme(this);
        }

        private void setupDates()
        {
            if (checkAllDates.Checked != true)
            {
                dateTimePicker1.Value = DateTime.Now.AddDays(-30);
                dateTimePicker2.Value = DateTime.Now;
            }
            else
            {
                dateTimePicker1.Value = new DateTime(2000, 01, 01);
                dateTimePicker2.Value = new DateTime(2100, 01, 01);
            }
        }

        // ── PDF Export ───────────────────────────────────────────────────────
        private void PrintLedger(string accountName, DateTime fromDate, DateTime toDate)
        {
            if (string.IsNullOrWhiteSpace(accountName))
            {
                MessageBox.Show("Please select an account first.",
                    "No Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Fetch account details (id, type)
            int accountId = 0;
            string accountType = "";

            using (var connection = DatabaseHelper.GetConnection())
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText =
                    "SELECT account_id, account_type FROM accounts WHERE account_name = @Name LIMIT 1";
                cmd.Parameters.AddWithValue("@Name", accountName);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        accountId = reader.GetInt32(0);
                        accountType = reader.GetString(1);
                    }
                    else
                    {
                        MessageBox.Show("Account not found in database.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // 2. Opening balance = net of all transactions BEFORE fromDate
            decimal openingBalance = 0;
            using (var connection = DatabaseHelper.GetConnection())
                openingBalance = GetOpeningBalance(connection, accountId, fromDate);

            // 3. Load transactions for the period
            var rows = new List<LedgerRow>();
            decimal runningBalance = openingBalance;

            using (var connection = DatabaseHelper.GetConnection())
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT
                        transaction_date,
                        voucher_no,
                        transaction_type,
                        description,
                        debit,
                        credit
                    FROM transactions
                    WHERE account_id  = @AccountId
                      AND transaction_date >= @FromDate
                      AND transaction_date <= @ToDate
                    ORDER BY transaction_date, transaction_id";

                cmd.Parameters.AddWithValue("@AccountId", accountId);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ToDate", toDate.ToString("yyyy-MM-dd"));

                using (var reader = cmd.ExecuteReader())
                {
                    int srNo = 1;
                    while (reader.Read())
                    {
                        decimal debit = reader["debit"] != DBNull.Value
                            ? Convert.ToDecimal(reader["debit"]) : 0;
                        decimal credit = reader["credit"] != DBNull.Value
                            ? Convert.ToDecimal(reader["credit"]) : 0;

                        runningBalance += debit - credit;

                        rows.Add(new LedgerRow
                        {
                            SrNo = srNo++,
                            Date = Convert.ToDateTime(reader["transaction_date"])
                                              .ToString("dd-MMM-yyyy"),
                            VoucherNo = reader["voucher_no"].ToString() ?? "",
                            Type = reader["transaction_type"].ToString() ?? "",
                            Description = reader["description"].ToString() ?? "",
                            Debit = debit,
                            Credit = credit,
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
            string filePath = Path.Combine(folderPath, "AccountLedger.pdf");
            
            
            // 5. Generate PDF
            try
            {
                LedgerReportPDF.Generate(
                    outputPath: filePath,
                    accountName: accountName,
                    accountId: accountId,
                    accountType: accountType,
                    fromDate: fromDate,
                    toDate: toDate,
                    openingBalance: openingBalance,
                    rows: rows);
                
                }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Pass the file path to the ViewReports form and show it
            ViewReports viewReports = new ViewReports(filePath);
            viewReports.ShowDialog();
        }

        // ── Load accounts into combos ─────────────────────────────────────────
        public void LoadAccounts()
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT account_id, account_name FROM accounts ORDER BY account_name";

                using (var reader = command.ExecuteReader())
                {
                    comboSearchName.Items.Clear();
                    comboSearchId.Items.Clear();

                    while (reader.Read())
                    {
                        comboSearchName.Items.Add(reader.GetString(1));
                        comboSearchId.Items.Add(reader.GetInt32(0).ToString());
                    }
                }
            }
        }

        // ── Load transactions into DataGridView ──────────────────────────────
        public void LoadTransactions(int accountId, DateTime fromDate, DateTime toDate)
        {
            dataGridView1.Rows.Clear();

            using (var connection = DatabaseHelper.GetConnection())
            {
                decimal openingBalance = GetOpeningBalance(connection, accountId, fromDate);
                decimal runningBalance = openingBalance;

                // Opening balance row
                int openingRow = dataGridView1.Rows.Add();
                dataGridView1.Rows[openingRow].Cells[0].Value = "";
                dataGridView1.Rows[openingRow].Cells[1].Value = "";
                dataGridView1.Rows[openingRow].Cells[4].Value = "Opening Balance";
                // Show Dr/Cr suffix like the rest of the balance column
                dataGridView1.Rows[openingRow].Cells[7].Value = openingBalance < 0
                    ? $"{Math.Abs(openingBalance):N0} Cr"
                    : $"{openingBalance:N0} Dr";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT
                            transaction_date,
                            voucher_no,
                            transaction_type,
                            description,
                            debit,
                            credit
                        FROM transactions
                        WHERE account_id = @AccountId
                          AND transaction_date >= @FromDate
                          AND transaction_date <= @ToDate
                        ORDER BY transaction_date, transaction_id";

                    command.Parameters.AddWithValue("@AccountId", accountId);
                    command.Parameters.AddWithValue("@FromDate", fromDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@ToDate", toDate.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        int srNo = 1;
                        while (reader.Read())
                        {
                            decimal debit = reader["debit"] != DBNull.Value
                                ? Convert.ToDecimal(reader["debit"]) : 0;
                            decimal credit = reader["credit"] != DBNull.Value
                                ? Convert.ToDecimal(reader["credit"]) : 0;

                            runningBalance += debit - credit;

                            int rowIndex = dataGridView1.Rows.Add();
                            dataGridView1.Rows[rowIndex].Cells[0].Value = srNo++;
                            dataGridView1.Rows[rowIndex].Cells[1].Value =
                                Convert.ToDateTime(reader["transaction_date"]).ToString("dd-MM-yyyy");
                            dataGridView1.Rows[rowIndex].Cells[2].Value = reader["voucher_no"].ToString();
                            dataGridView1.Rows[rowIndex].Cells[3].Value = reader["transaction_type"].ToString();
                            dataGridView1.Rows[rowIndex].Cells[4].Value = reader["description"].ToString();
                            dataGridView1.Rows[rowIndex].Cells[5].Value = debit.ToString("N0");
                            dataGridView1.Rows[rowIndex].Cells[6].Value = credit.ToString("N0");
                            dataGridView1.Rows[rowIndex].Cells[7].Value = runningBalance < 0
                                ? $"{Math.Abs(runningBalance):N0} Cr"
                                : $"{runningBalance:N0} Dr";
                        }
                    }
                }
            }
        }

        // ── Opening balance helper ───────────────────────────────────────────
        // ── Opening balance helper ───────────────────────────────────────────
        private decimal GetOpeningBalance(SqliteConnection connection,
                                          int accountId, DateTime fromDate)
        {
            // 1. Get the stored opening_balance from accounts table
            decimal storedOpeningBalance = 0;
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT IFNULL(opening_balance, 0)
            FROM   accounts
            WHERE  account_id = @AccountId";
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                storedOpeningBalance = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            // 2. Get net movement from transactions BEFORE fromDate
            decimal transactionMovement = 0;
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT IFNULL(SUM(debit), 0) - IFNULL(SUM(credit), 0)
            FROM   transactions
            WHERE  account_id = @AccountId
              AND  transaction_date < @FromDate";
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.ToString("yyyy-MM-dd"));
                transactionMovement = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            return storedOpeningBalance + transactionMovement;
        }

        // ── UI event handlers ────────────────────────────────────────────────
        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnExportPdf_Click(object sender, EventArgs e)
        {
            PrintLedger(
                comboSearchName.Text,
                dateTimePicker1.Value.Date,
                dateTimePicker2.Value.Date);
        }

        private void comboSearchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSearchName.SelectedIndex >= 0)
            {
                comboSearchId.SelectedIndex = comboSearchName.SelectedIndex;
                int accountId = int.Parse(comboSearchId.SelectedItem!.ToString()!);
                LoadTransactions(accountId, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            }
        }

        private void comboSearchId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSearchId.SelectedIndex >= 0)
            {
                comboSearchName.SelectedIndex = comboSearchId.SelectedIndex;
                int accountId = int.Parse(comboSearchId.SelectedItem!.ToString()!);
                LoadTransactions(accountId, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format balance column with Dr/Cr suffix
            if (e.ColumnIndex == 7 && e.Value != null)
            {
                var value = e.Value.ToString();
                if (value.EndsWith(" Cr"))
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
        }

        private void checkAllDates_CheckedChanged(object sender, EventArgs e)
        {
            setupDates();
        }
    }
}