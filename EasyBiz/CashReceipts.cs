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
    public partial class CashReceipts : Form
    {
        private int? _editingVoucherNo = null; // null = new entry, set = editing
        public CashReceipts()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadAccounts();
            ShowVoucherNo();
            try { ShowVoucherNo(); }
            catch (Exception ex) { MessageBox.Show("Could not load voucher number: " + ex.Message); }
            comboAccountName.Select();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:

                    if (ActiveControl == txtAmount)
                    {
                        if (decimal.TryParse(txtAmount.Text, out decimal amount))
                        {
                            AddRowToDataGridView(
                                comboAccountName.Text,
                                txtDescription.Text,
                                amount);

                            txtDescription.Clear();
                            txtAmount.Clear();
                            comboAccountName.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Invalid amount.");
                        }

                        return true;
                    }

                    SelectNextControl(ActiveControl, true, true, true, true);
                    return true;

                case Keys.Control | Keys.S:
                    BtnSave_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Delete:
                    BtnDeleteRow_Click(this, EventArgs.Empty);
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
            string transactionType = "Cash Receipt"; // or bind from dropdown
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
        private void RecalcTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.IsNewRow) continue;
                if (decimal.TryParse(r.Cells["amount"].Value?.ToString(), out var a))
                    total += a;
            }
            txtTotal.Text = total.ToString("N0");
        }
        public void AddRowToDataGridView(string partyName, string description, decimal amount)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(partyName))
            {
                MessageBox.Show("Party name is required.");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.");
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

            row.Cells["sno"].Value = rowIndex + 1;
            // store account id in hidden column to preserve the FK reference
            row.Cells["accountId"].Value = comboAccountId.Text;
            row.Cells["accountname"].Value = partyName;
            row.Cells["desc"].Value = description;
            // store raw numeric value (unformatted) so parsing later is reliable
            row.Cells["amount"].Value = amount.ToString();
            RecalcTotal();
        }

        private bool CheckIfVoucherExists(int voucherNo)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM transactions WHERE voucher_no = @voucherNo AND transaction_type = @type";
                command.Parameters.AddWithValue("@voucherNo", voucherNo);
                command.Parameters.AddWithValue("@type", "Cash Receipt");
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
        public bool LoadTransactionForEditing(int voucherNo)
        {
            if (!CheckIfVoucherExists(voucherNo))
            {
                MessageBox.Show(
                    $"Voucher number {voucherNo} does not exist for Cash Receipt.",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return false;
            }
            _editingVoucherNo = voucherNo;
            txtInvoiceNumber.Text = voucherNo.ToString();
            txtInvoiceNumber.ReadOnly = true; // lock it while editing

            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                // Only load the CREDIT side rows (exclude the Cash debit leg)
                command.CommandText = @"
                SELECT account_id, account_name, description, credit, transaction_date
                FROM transactions 
                WHERE voucher_no = @voucherNo 
                  AND transaction_type = @type
                  AND credit > 0 AND account_id != 10001";

                command.Parameters.AddWithValue("@voucherNo", voucherNo);
                command.Parameters.AddWithValue("@type", "Cash Receipt");

                using (var reader = command.ExecuteReader())
                {
                    dataGridView1.Rows.Clear();
                    bool dateSet = false;
                    while (reader.Read())
                    {
                        string accountName = reader.GetString(1);
                        string description = reader.GetString(2);
                        decimal amount = reader.GetDecimal(3);

                        // Restore the date from the first row
                        if (!dateSet)
                        {
                            if (DateTime.TryParse(reader.GetString(4), out var txDate))
                                dateTimePicker1.Value = txDate;
                            dateSet = true;
                        }

                        // We need account_id for the hidden column — select the combo
                        int accountId = reader.GetInt32(0);
                        SelectAccountById(accountId);

                        AddRowToDataGridView(accountName, description, amount);
                    }
                }
            }

            // Reset combo after loading
            comboAccountName.SelectedIndex = -1;
            comboAccountId.SelectedIndex = -1;
            txtPreBalance.Text = "0 Dr";
            return true;
        }

        /// <summary>
        /// Selects the combo by account_id so AddRowToDataGridView can read it.
        /// </summary>
        /// 
        private void SelectAccountById(int accountId)
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
        public void PostEntry()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No transactions to post.", "No Transactions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                using (var transaction = connection.BeginTransaction())
                {
                    string transactionType = "Cash Receipt";
                    int voucherNo;

                    if (_editingVoucherNo.HasValue)
                    {
                        // ── EDIT MODE: reverse old balances, delete old rows ──────────
                        voucherNo = _editingVoucherNo.Value;

                        // 1. Reverse every debit balance (accounts that were debited)
                        using (var cmd = new SqliteCommand(@"
                        SELECT account_id, credit FROM transactions
                        WHERE voucher_no = @v AND transaction_type = @t AND credit > 0",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@v", voucherNo);
                            cmd.Parameters.AddWithValue("@t", transactionType);
                            using (var r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    int accId = r.GetInt32(0);
                                    decimal credit = r.GetDecimal(1);

                                    using (var upd = new SqliteCommand(
                                        "UPDATE accounts SET current_balance = current_balance - @a WHERE account_id = @id",
                                        connection, transaction))
                                    {
                                        upd.Parameters.AddWithValue("@a", credit);
                                        upd.Parameters.AddWithValue("@id", accId);
                                        upd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 2. Reverse the Cash credit (restore Cash balance)
                        using (var cmd = new SqliteCommand(@"
                        SELECT SUM(debit) FROM transactions
                        WHERE voucher_no = @v AND transaction_type = @t AND account_id = 10001",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@v", voucherNo);
                            cmd.Parameters.AddWithValue("@t", transactionType);
                            object scalar = cmd.ExecuteScalar();
                            decimal totalDebit = (scalar == null || scalar is DBNull) ? 0m : Convert.ToDecimal(scalar);

                            using (var upd = new SqliteCommand(
                                "UPDATE accounts SET current_balance = current_balance - @a WHERE account_id = 10001",
                                connection, transaction))
                            {
                                upd.Parameters.AddWithValue("@a", totalDebit);
                                upd.ExecuteNonQuery();
                            }
                        }

                        // 3. Delete old transaction rows
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
                        // ── NEW ENTRY: generate next voucher number ───────────────────
                        using (var cmd = new SqliteCommand(
                            "SELECT COALESCE(MAX(voucher_no), 0) + 1 FROM transactions WHERE transaction_type = @type",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@type", transactionType);
                            voucherNo = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }

                    // ── INSERT rows (shared by both new and edit) ─────────────────────
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
                            transaction.Rollback();
                            return;
                        }
                        if (!decimal.TryParse(row.Cells["amount"].Value?.ToString(), out var amount))
                        {
                            MessageBox.Show($"Invalid amount in row {row.Index + 1}.");
                            transaction.Rollback();
                            return;
                        }

                        // Credit leg
                        using (var cmd = new SqliteCommand(@"
                        INSERT INTO transactions 
                        (transaction_type, voucher_no, account_id, account_name, description, debit, credit, transaction_date)
                        VALUES (@t, @v, @aid, @an, @d, 0, @credit, @date)",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@t", transactionType);
                            cmd.Parameters.AddWithValue("@v", voucherNo);
                            cmd.Parameters.AddWithValue("@aid", accountId);
                            cmd.Parameters.AddWithValue("@an", accountName);
                            cmd.Parameters.AddWithValue("@d", description);
                            cmd.Parameters.AddWithValue("@credit", amount);
                            cmd.Parameters.AddWithValue("@date", dated);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new SqliteCommand(
                            "UPDATE accounts SET current_balance = current_balance - @a WHERE account_id = @id",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@a", amount);
                            cmd.Parameters.AddWithValue("@id", accountId);
                            cmd.ExecuteNonQuery();
                        }

                        // Debit leg (Cash)
                        using (var cmd = new SqliteCommand(@"
                        INSERT INTO transactions 
                        (transaction_type, voucher_no, account_id, account_name, description, debit, credit, transaction_date)
                        VALUES (@t, @v, 10001, 'Cash In Hand', @d, @debit, 0, @date)",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@t", transactionType);
                            cmd.Parameters.AddWithValue("@v", voucherNo);
                            cmd.Parameters.AddWithValue("@d", description);
                            cmd.Parameters.AddWithValue("@debit", amount);
                            cmd.Parameters.AddWithValue("@date", dated);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new SqliteCommand(
                            "UPDATE accounts SET current_balance = current_balance + @a WHERE account_id = 10001",
                            connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@a", amount);
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
                    txtAmount.Clear();
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

                // Update balance
                UpdateBalance(comboAccountId.SelectedIndex);
            }
        }

        private void comboAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAccountName.SelectedIndex != -1)
            {
                // Sync account ID with selected name
                comboAccountId.SelectedIndex = comboAccountName.SelectedIndex;

                // Update balance
                UpdateBalance(comboAccountName.SelectedIndex);
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

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && !dataGridView1.SelectedRows[0].IsNewRow)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    RecalcTotal();
                }
            }
        }

        private void CashReceipts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboAccountName.Text != "" || txtDescription.Text != "" || txtAmount.Text != "")
            {
                var result = MessageBox.Show("Are you sure you want to close the Cash Receipt Voucher?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
