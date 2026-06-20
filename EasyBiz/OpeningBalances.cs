using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyBiz
{
    public partial class OpeningBalances : Form
    {
        public OpeningBalances()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadAccounts();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    BtnSave_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F5:
                    BtnRefresh_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Escape:
                    BtnClose_Click(this, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ── Load all accounts into the grid ──────────────────────────────────
        private void LoadAccounts()
        {
            dataGridView1.Rows.Clear();

            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT account_id, account_name, account_type, opening_balance
                FROM   accounts
                ORDER  BY account_id";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                decimal ob = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3);

                // Convention: negative opening_balance stored = Credit side
                string drCr = ob < 0 ? "Cr" : "Dr";
                decimal display = Math.Abs(ob);

                int row = dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells["colId"].Value = id;
                dataGridView1.Rows[row].Cells["colName"].Value = name;
                dataGridView1.Rows[row].Cells["colType"].Value = type;
                dataGridView1.Rows[row].Cells["colAmount"].Value = display == 0 ? "" : display.ToString("N0");
                dataGridView1.Rows[row].Cells["colDrCr"].Value = drCr;
            }
        }

        // ── Save button ───────────────────────────────────────────────────────
        private void BtnSave_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "This will overwrite existing opening balances and update current balances accordingly.\n\nContinue?",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using var connection = DatabaseHelper.GetConnection();
                using var transaction = connection.BeginTransaction();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (!int.TryParse(row.Cells["colId"].Value?.ToString(), out int accountId))
                        continue;

                    string amountStr = row.Cells["colAmount"].Value?.ToString()?.Replace(",", "") ?? "0";

                    if (!decimal.TryParse(amountStr, out decimal amount))
                        amount = 0;

                    string drCr = row.Cells["colDrCr"].Value?.ToString() ?? "Dr";

                    // Store credits as negative values
                    decimal newOpeningBalance = drCr == "Cr" ? -amount : amount;

                    // Get existing balances
                    using var getCmd = new SqliteCommand(@"
                SELECT opening_balance, current_balance
                FROM accounts
                WHERE account_id = @id",
                        connection, transaction);

                    getCmd.Parameters.AddWithValue("@id", accountId);

                    using var reader = getCmd.ExecuteReader();

                    if (!reader.Read())
                        continue;

                    decimal oldOpeningBalance = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                    decimal currentBalance = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);                    

                    reader.Close();

                    // Adjust current balance by the opening balance difference
                    decimal difference = newOpeningBalance - oldOpeningBalance;
                    decimal newCurrentBalance = currentBalance + difference;

                    using var updateCmd = new SqliteCommand(@"
                UPDATE accounts
                SET opening_balance = @ob,                    
                    current_balance = @cb
                WHERE account_id = @id",
                        connection, transaction);

                    updateCmd.Parameters.AddWithValue("@ob", newOpeningBalance);                    
                    updateCmd.Parameters.AddWithValue("@cb", newCurrentBalance);
                    updateCmd.Parameters.AddWithValue("@id", accountId);

                    updateCmd.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show(
                    "Opening balances saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error saving opening balances:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ── Refresh button ────────────────────────────────────────────────────
        private void BtnRefresh_Click(object sender, EventArgs e) => LoadAccounts();

        // ── Close button ──────────────────────────────────────────────────────
        private void BtnClose_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Close Opening Balances?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) Close();
        }

        // ── Colour-code Dr/Cr cells while editing ─────────────────────────────
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name != "colDrCr") return;
            if (e.Value == null) return;

            if (e.Value.ToString() == "Cr")
            {
                e.CellStyle.ForeColor = Color.ForestGreen;
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                e.CellStyle.ForeColor = Color.Crimson;
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private void txtSearchAccount_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchAccount.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string accountName = row.Cells["colName"].Value?.ToString()?.ToLower() ?? "";

                row.Visible = string.IsNullOrEmpty(searchText) ||
                              accountName.Contains(searchText);
            }
        }
    }
}