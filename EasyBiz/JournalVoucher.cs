using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class JournalVoucher : Form
    {
        private int? _editingVoucherNo = null;
        public JournalVoucher()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadAccounts();
            ShowVoucherNo();
            comboAccountName.Select();
            ThemeManager.ApplyTheme(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (ActiveControl == txtCredit)
                    {
                        AddDataToGrid();
                        return true;
                    }
                    SelectNextControl(this.ActiveControl, true, true, true, true);
                    return true;            

                case Keys.Control | Keys.S:
                    BtnSave_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Escape:
                    BtnClose_Click(this, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private int GetNextVoucherNo(string transactionType)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var cmd = new SqliteCommand(
                "SELECT COALESCE(MAX(voucher_no), 0) + 1 FROM transactions WHERE transaction_type = @type",
                connection))
            {
                cmd.Parameters.AddWithValue("@type", transactionType);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private void ShowVoucherNo()
        {
            string transactionType = "Journal Voucher"; // or bind from dropdown
            int nextVoucherNo = GetNextVoucherNo(transactionType);
            txtInvoiceNumber.Text = nextVoucherNo.ToString();
        }
        public void LoadAccounts()
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT account_id, account_name, current_balance FROM accounts ORDER BY account_name";

                using (var reader = command.ExecuteReader())
                {
                    comboAccountName.Items.Clear();
                    comboAccountId.Items.Clear();
                    txtPreBalance.Text = "0 Dr";

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        double balance = reader.GetDouble(2);

                        comboAccountName.Items.Add(name);
                        comboAccountId.Items.Add(id.ToString());
                    }
                }
            }
        }

        private void UpdateBalance(int index)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT current_balance FROM accounts ORDER BY account_name";
                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        if (i == index)
                        {
                            double balance = reader.GetDouble(0);
                            if (balance < 0)
                            {
                                txtPreBalance.ForeColor = Color.Green;
                                txtPreBalance.Text = Math.Abs(balance).ToString("N0") + " Cr";
                            }
                            else
                            {
                                txtPreBalance.ForeColor = Color.Red;
                                txtPreBalance.Text = balance.ToString("N0") + " Dr";
                            }
                            break;
                        }
                        i++;
                    }
                }
            }
        }

        public void AddRowToDataGridView(string partyName, string description, decimal debit, decimal credit)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(partyName))
            {
                MessageBox.Show("Party name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Description is required.");
                return;
            }

            if (description.Length > 255)
            {
                MessageBox.Show("Description cannot exceed 255 characters.");
                return;
            }
            if (description.Length < 3)
            {
                MessageBox.Show("Description must be at least 3 characters long.");
                return;
            }

            if (debit <= 0 && credit <= 0)
            {
                MessageBox.Show("Debit or credit amount must be greater than zero.");
                return;
            }

            // Ensure an account is selected (we need the account id for the foreign key)
            if (comboAccountId.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an account before adding a row.");
                return;
            }

            // Add row to DataGridView
            int rowIndex = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            row.Cells["sno"].Value = dataGridView1.Rows.Count; // Auto-incrementing serial number
            // store account id in hidden column to preserve the FK reference
            row.Cells["accountId"].Value = comboAccountId.Text;
            row.Cells["accountname"].Value = partyName;
            row.Cells["desc"].Value = description;
            // store raw numeric value (unformatted) so parsing later is reliable
            row.Cells["debit"].Value = debit.ToString();
            row.Cells["credit"].Value = credit.ToString();
        }

        private void SelectAccountById(int accountId) // ✅ Added (same as other forms)
        {
            for (int i = 0; i < comboAccountId.Items.Count; i++)
            {
                if (comboAccountId.Items[i].ToString() == accountId.ToString())
                {
                    comboAccountId.SelectedIndex = i;
                    comboAccountName.SelectedIndex = i;
                    return;
                }
            }
        }

        public bool CheckIfVoucherExists(int voucherNo)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM transactions WHERE voucher_no = @voucherNo AND transaction_type = @type";
                command.Parameters.AddWithValue("@voucherNo", voucherNo);
                command.Parameters.AddWithValue("@type", "Journal Voucher");
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
        public bool LoadTransactionForEditing(int voucherNo)
        {
            if (!CheckIfVoucherExists(voucherNo))
            {
                MessageBox.Show(
                    $"Voucher number {voucherNo} does not exist for Journal Voucher.",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return false;
            }
            _editingVoucherNo = voucherNo;           // Store for PostEntry
            txtInvoiceNumber.Text = voucherNo.ToString(); // Show voucher
            txtInvoiceNumber.ReadOnly = true;                 // Lock while editing

            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                SELECT account_id, account_name, description, debit, credit, transaction_date
                FROM transactions 
                WHERE voucher_no = @voucherNo AND transaction_type = @type"; // Fixed query

                command.Parameters.AddWithValue("@voucherNo", voucherNo);
                command.Parameters.AddWithValue("@type", "Journal Voucher"); // Fixed type

                using (var reader = command.ExecuteReader())
                {
                    dataGridView1.Rows.Clear();
                    bool dateSet = false;
                    while (reader.Read())
                    {
                        int accountId = reader.GetInt32(0);
                        string accountName = reader.GetString(1);
                        string description = reader.GetString(2);
                        decimal debit = reader.GetDecimal(3);
                        decimal credit = reader.GetDecimal(4);

                        // Restore date from first row
                        if (!dateSet)
                        {
                            if (DateTime.TryParse(reader.GetString(5), out var txDate))
                                dateTimePicker1.Value = txDate;
                            dateSet = true;
                        }

                        SelectAccountById(accountId); // So AddRow can read comboAccountId
                        AddRowToDataGridView(accountName, description, debit, credit);
                    }
                }
            }

            // Reset combo after loading
            comboAccountName.SelectedIndex = -1;
            comboAccountId.SelectedIndex = -1;
            txtPreBalance.Text = "0 Dr";
            return true;
        }

        public void PostEntry()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No transactions to post. Please add at least one transaction.",
                    "No Transactions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validate debit == credit totals first
                decimal totalDebit = 0, totalCredit = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    decimal.TryParse(row.Cells["debit"].Value?.ToString(), out var d);
                    decimal.TryParse(row.Cells["credit"].Value?.ToString(), out var c);
                    totalDebit += d;
                    totalCredit += c;
                }

                if (totalDebit != totalCredit)
                {
                    MessageBox.Show("Debit and Credit amounts are not equal. Entry cannot be posted.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = DatabaseHelper.GetConnection())
                using (var transaction = connection.BeginTransaction())
                {
                    string transactionType = "Journal Voucher";
                    int voucherNo;

                    if (_editingVoucherNo.HasValue)
                    {
                        // ── EDIT MODE ────────────────────────────────────────────────
                        voucherNo = _editingVoucherNo.Value;

                        // 1. Reverse all account balances (debit rows added, credit rows subtracted)
                        using (var cmd = new SqliteCommand(@"
                        SELECT account_id, debit, credit FROM transactions
                        WHERE voucher_no = @v AND transaction_type = @t",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@v", voucherNo);
                            cmd.Parameters.AddWithValue("@t", transactionType);
                            using (var r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    int accId = r.GetInt32(0);
                                    decimal debit = r.GetDecimal(1);
                                    decimal credit = r.GetDecimal(2);

                                    // Reverse: subtract what was added, add back what was subtracted
                                    using (var upd = new SqliteCommand(@"
                                    UPDATE accounts 
                                    SET current_balance = current_balance - @debit + @credit
                                    WHERE account_id = @id",
                                        connection, transaction))
                                    {
                                        upd.Parameters.AddWithValue("@debit", debit);
                                        upd.Parameters.AddWithValue("@credit", credit);
                                        upd.Parameters.AddWithValue("@id", accId);
                                        upd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 2. Delete old rows
                        using (var cmd = new SqliteCommand(
                            "DELETE FROM transactions WHERE voucher_no = @v AND transaction_type = @t",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@v", voucherNo);
                            cmd.Parameters.AddWithValue("@t", transactionType);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // ── NEW ENTRY ─────────────────────────────────────────────────
                        using (var cmd = new SqliteCommand(
                            "SELECT COALESCE(MAX(voucher_no), 0) + 1 FROM transactions WHERE transaction_type = @type",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@type", transactionType);
                            voucherNo = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }

                    // ── INSERT rows (shared by both new and edit) ─────────────────
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string accountIdStr = row.Cells["accountId"].Value?.ToString() ?? "";
                        string accountName = row.Cells["accountname"].Value?.ToString() ?? "";
                        string description = row.Cells["desc"].Value?.ToString() ?? "";
                        string dated = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                        if (!int.TryParse(accountIdStr, out var accountId))
                        {
                            MessageBox.Show($"Invalid account id in row {row.Index + 1}.");
                            transaction.Rollback(); // ✅ Rollback before return
                            return;
                        }
                        if (!decimal.TryParse(row.Cells["debit"].Value?.ToString(), out var debit))
                        {
                            MessageBox.Show($"Invalid debit in row {row.Index + 1}.");
                            transaction.Rollback();
                            return;
                        }
                        if (!decimal.TryParse(row.Cells["credit"].Value?.ToString(), out var credit))
                        {
                            MessageBox.Show($"Invalid credit in row {row.Index + 1}.");
                            transaction.Rollback();
                            return;
                        }

                        using (var cmd = new SqliteCommand(@"
                        INSERT INTO transactions 
                        (transaction_type, voucher_no, account_id, account_name, description, debit, credit, transaction_date)
                        VALUES (@t, @v, @aid, @an, @d, @debit, @credit, @date)",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@t", transactionType);
                            cmd.Parameters.AddWithValue("@v", voucherNo);
                            cmd.Parameters.AddWithValue("@aid", accountId);
                            cmd.Parameters.AddWithValue("@an", accountName);
                            cmd.Parameters.AddWithValue("@d", description);
                            cmd.Parameters.AddWithValue("@debit", debit);
                            cmd.Parameters.AddWithValue("@credit", credit);
                            cmd.Parameters.AddWithValue("@date", dated);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new SqliteCommand(@"
                        UPDATE accounts 
                        SET current_balance = current_balance + @debit - @credit
                        WHERE account_id = @id",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@debit", debit);
                            cmd.Parameters.AddWithValue("@credit", credit);
                            cmd.Parameters.AddWithValue("@id", accountId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    MessageBox.Show("Transaction posted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset to new-entry mode
                    _editingVoucherNo = null;
                    txtInvoiceNumber.ReadOnly = false;
                    ShowVoucherNo();
                    dataGridView1.Rows.Clear();
                    txtDescription.Clear();
                    txtDebit.Clear();
                    txtCredit.Clear();
                    comboAccountName.SelectedIndex = -1;
                    comboAccountId.SelectedIndex = -1;
                    comboAccountName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {            
              Close();            
        }

        private void comboAccountId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAccountId.SelectedIndex != -1)
            {
                // Sync account name with selected ID
                comboAccountName.SelectedIndex = comboAccountId.SelectedIndex;
                UpdateBalance(comboAccountId.SelectedIndex);
            }
        }

        private void comboAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAccountName.SelectedIndex != -1)
            {
                // Sync account ID with selected name
                comboAccountId.SelectedIndex = comboAccountName.SelectedIndex;             
                UpdateBalance(comboAccountName.SelectedIndex);
            }            
        }

        public void AddDataToGrid()
        {
            string partyName = comboAccountName.Text;
            string description = txtDescription.Text;

            decimal debit = 0;
            decimal credit = 0;

            bool isValid =
                (!string.IsNullOrWhiteSpace(txtDebit.Text) ||
                 !string.IsNullOrWhiteSpace(txtCredit.Text)) &&

                (string.IsNullOrWhiteSpace(txtDebit.Text) ||
                 decimal.TryParse(txtDebit.Text, out debit)) &&

                (string.IsNullOrWhiteSpace(txtCredit.Text) ||
                 decimal.TryParse(txtCredit.Text, out credit));

            if (isValid)
            {
                AddRowToDataGridView(partyName, description, debit, credit);

                txtDescription.Clear();
                txtDebit.Clear();
                txtCredit.Clear();

                comboAccountName.Focus();
            }
            else
            {
                MessageBox.Show("Enter a valid Debit or Credit amount.");
            }
        }        

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to post this transaction?", "Confirm Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PostEntry();
            }
        }

        private void comboAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // FOCUS TO NEXT CONTROL ON ENTER
            if (e.KeyChar == (char)Keys.Enter)
            {

            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            // FOCUS TO NEXT CONTROL ON ENTER
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDebit.Focus();
            }
        }        

        private void JournalVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboAccountName.Text != "" || txtDescription.Text != "" || txtDebit.Text != "" || txtCredit.Text != "")
            {
                var result = MessageBox.Show("Are you sure you want to close the Journal Voucher?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else { e.Cancel = false; }
        }
    }
}
