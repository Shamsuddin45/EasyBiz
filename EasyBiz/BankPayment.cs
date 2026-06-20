using Microsoft.Data.Sqlite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class BankPayment : Form
    {
        private int? _editingVoucherNo = null;

        public BankPayment()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadBankAccounts();
            LoadPartyAccounts();
            ShowVoucherNo();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
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

        // ── Voucher number ────────────────────────────────────────────────────
        private int GetNextVoucherNo(string type)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COALESCE(MAX(voucher_no),0)+1 FROM transactions WHERE transaction_type=@t", conn);
            cmd.Parameters.AddWithValue("@t", type);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void ShowVoucherNo()
        {
            txtVoucherNo.Text = GetNextVoucherNo("Bank Payment").ToString();
        }

        // ── Load bank accounts (category = 'Banks') ───────────────────────────
        private void LoadBankAccounts()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT account_id, account_name, current_balance FROM accounts WHERE account_type='Banks' ORDER BY account_name";
            using var r = cmd.ExecuteReader();
            comboBankName.Items.Clear();
            comboBankId.Items.Clear();
            while (r.Read())
            {
                comboBankName.Items.Add(r.GetString(1));
                comboBankId.Items.Add(r.GetInt32(0).ToString());
            }
        }

        // ── Load all accounts for the party (payee) combo ─────────────────────
        public void LoadPartyAccounts()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT account_id, account_name, current_balance FROM accounts ORDER BY account_name";
            using var r = cmd.ExecuteReader();
            comboPartyName.Items.Clear();
            comboPartyId.Items.Clear();
            txtPreBalance.Text = "0 Dr";
            while (r.Read())
            {
                comboPartyName.Items.Add(r.GetString(1));
                comboPartyId.Items.Add(r.GetInt32(0).ToString());
            }
        }

        private void UpdateBankBalance()
        {
            if (comboBankId.SelectedIndex < 0) return;
            int id = int.Parse(comboBankId.SelectedItem!.ToString()!);
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT current_balance FROM accounts WHERE account_id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            decimal bal = Convert.ToDecimal(cmd.ExecuteScalar());
            txtBankBalance.ForeColor = bal < 0 ? Color.Green : Color.Red;
            txtBankBalance.Text = bal < 0
                ? $"{Math.Abs(bal):N0} Cr"
                : $"{bal:N0} Dr";
        }

        private void UpdatePartyBalance(int accountId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();

            // 1. Query only the specific record using a parameterized query
            cmd.CommandText = "SELECT current_balance FROM accounts WHERE account_id = @AccountId";

            var param = cmd.CreateParameter();
            param.ParameterName = "@AccountId";
            param.Value = accountId;
            cmd.Parameters.Add(param);

            // 2. Use ExecuteScalar since we are only fetching a single value
            var result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                decimal b = Convert.ToDecimal(result);

                // 3. UI Update logic remains clean and safe
                txtPreBalance.ForeColor = b < 0 ? Color.Green : Color.Red;
                txtPreBalance.Text = b < 0 ? $"{Math.Abs(b):N0} Cr" : $"{b:N0} Dr";
            }
            else
            {
                // Optional: Handle case where account isn't found
                txtPreBalance.Text = "0 N0";
                txtPreBalance.ForeColor = Color.Black;
            }
        }

        private void RecalcTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in gridLines.Rows)
            {
                if (r.IsNewRow) continue;
                if (decimal.TryParse(r.Cells["colAmount"].Value?.ToString(), out var a)) total += a;
            }
            txtTotal.Text = total.ToString("N0");
        }

        // ── Add row ───────────────────────────────────────────────────────────
        public void AddRow(string partyName, string description, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(partyName)) { MessageBox.Show("Party name is required."); return; }
            if (amount <= 0) { MessageBox.Show("The amount you've entered is invalid."); return; }
            if (comboBankId.SelectedIndex < 0) { MessageBox.Show("Please select a bank account."); return; }
            if (comboPartyId.SelectedIndex < 0) { MessageBox.Show("Please select a party account."); return; }

            int ri = gridLines.Rows.Add();
            var row = gridLines.Rows[ri];
            row.Cells["colSno"].Value = gridLines.Rows.Count;
            row.Cells["colPartyId"].Value = comboPartyId.Text;
            row.Cells["colPartyName"].Value = partyName;
            row.Cells["colDesc"].Value = description;
            row.Cells["colAmount"].Value = amount.ToString();
            row.Cells["colChequeNo"].Value = txtChequeNo.Text.Trim();
            RecalcTotal();
        }

        // ── Check / Load for editing ──────────────────────────────────────────
        public void CheckIfVoucherExists(int voucherNo)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COUNT(*) FROM transactions WHERE voucher_no=@v AND transaction_type='Bank Payment'", conn);
            cmd.Parameters.AddWithValue("@v", voucherNo);
            if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                MessageBox.Show($"Bank Payment #{voucherNo} does not exist.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadTransactionForEditing(int voucherNo)
        {
            CheckIfVoucherExists(voucherNo);
            _editingVoucherNo = voucherNo;
            txtVoucherNo.Text = voucherNo.ToString();
            txtVoucherNo.ReadOnly = true;

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            // Load debit (payee) rows only; the bank credit row has account_type = 'Banks'
            cmd.CommandText = @"
                SELECT t.account_id, t.account_name, t.description, t.debit,
                       t.transaction_date, t.cheque_no
                FROM   transactions t
                JOIN   accounts a ON a.account_id = t.account_id
                WHERE  t.voucher_no = @v AND t.transaction_type = 'Bank Payment'
                  AND  t.debit > 0";
            cmd.Parameters.AddWithValue("@v", voucherNo);

            gridLines.Rows.Clear();
            bool dateSet = false;
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (!dateSet)
                {
                    if (DateTime.TryParse(r.GetString(4), out var dt)) dateInvoice.Value = dt;
                    dateSet = true;
                }
                int accId = r.GetInt32(0);
                SelectPartyById(accId);
                txtChequeNo.Text = r.IsDBNull(5) ? "" : r.GetString(5);
                AddRow(r.GetString(1), r.GetString(2), r.GetDecimal(3));
            }

            // Restore bank selection
            using var cmd2 = conn.CreateCommand();
            cmd2.CommandText = @"
                SELECT t.account_id FROM transactions t
                JOIN accounts a ON a.account_id = t.account_id
                WHERE t.voucher_no=@v AND t.transaction_type='Bank Payment'
                  AND a.account_type='Banks' LIMIT 1";
            cmd2.Parameters.AddWithValue("@v", voucherNo);
            var bankId = cmd2.ExecuteScalar();
            if (bankId != null) SelectBankById(Convert.ToInt32(bankId));

            comboPartyName.SelectedIndex = -1;
            comboPartyId.SelectedIndex = -1;
            txtPreBalance.Text = "0 Dr";
        }

        private void SelectPartyById(int id)
        {
            for (int i = 0; i < comboPartyId.Items.Count; i++)
                if (comboPartyId.Items[i].ToString() == id.ToString())
                { comboPartyId.SelectedIndex = i; comboPartyName.SelectedIndex = i; return; }
        }

        private void SelectBankById(int id)
        {
            for (int i = 0; i < comboBankId.Items.Count; i++)
                if (comboBankId.Items[i].ToString() == id.ToString())
                { comboBankId.SelectedIndex = i; comboBankName.SelectedIndex = i; return; }
        }

        // ── Post ──────────────────────────────────────────────────────────────
        public void PostEntry()
        {
            if (gridLines.Rows.Count == 0)
            { MessageBox.Show("No transactions to post.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (comboBankId.SelectedIndex < 0)
            { MessageBox.Show("Please select a bank account."); return; }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var txn = conn.BeginTransaction();

                const string txType = "Bank Payment";
                int bankAccountId = int.Parse(comboBankId.SelectedItem!.ToString()!);
                string bankName = comboBankName.SelectedItem!.ToString()!;
                int voucherNo;

                if (_editingVoucherNo.HasValue)
                {
                    voucherNo = _editingVoucherNo.Value;

                    // Reverse debit balances
                    using (var cmd = new SqliteCommand(@"
                        SELECT account_id, debit FROM transactions
                        WHERE voucher_no=@v AND transaction_type=@t AND debit>0",
                        conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@t", txType);
                        using var r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            using var u = new SqliteCommand(
                                "UPDATE accounts SET current_balance=current_balance-@a WHERE account_id=@id",
                                conn, txn);
                            u.Parameters.AddWithValue("@a", r.GetDecimal(1));
                            u.Parameters.AddWithValue("@id", r.GetInt32(0));
                            u.ExecuteNonQuery();
                        }
                    }
                    // Reverse bank credit
                    using (var cmd = new SqliteCommand(@"
                        SELECT SUM(credit) FROM transactions
                        WHERE voucher_no=@v AND transaction_type=@t AND account_id=@b",
                        conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@t", txType);
                        cmd.Parameters.AddWithValue("@b", bankAccountId);
                        decimal tot = Convert.ToDecimal(cmd.ExecuteScalar());
                        using var u = new SqliteCommand(
                            "UPDATE accounts SET current_balance=current_balance+@a WHERE account_id=@id",
                            conn, txn);
                        u.Parameters.AddWithValue("@a", tot);
                        u.Parameters.AddWithValue("@id", bankAccountId);
                        u.ExecuteNonQuery();
                    }
                    using (var cmd = new SqliteCommand(
                        "DELETE FROM transactions WHERE voucher_no=@v AND transaction_type=@t",
                        conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@t", txType);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using var cmd = new SqliteCommand(
                        "SELECT COALESCE(MAX(voucher_no),0)+1 FROM transactions WHERE transaction_type=@t",
                        conn, txn);
                    cmd.Parameters.AddWithValue("@t", txType);
                    voucherNo = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string date = dateInvoice.Value.ToString("yyyy-MM-dd");

                foreach (DataGridViewRow row in gridLines.Rows)
                {
                    if (row.IsNewRow) continue;

                    string partyIdStr = row.Cells["colPartyId"].Value?.ToString() ?? "";
                    string partyName = row.Cells["colPartyName"].Value?.ToString() ?? "";
                    string desc = row.Cells["colDesc"].Value?.ToString() ?? "";
                    string partyDesc = $"From {bankName}: {desc}";
                    string bankDesc = $"To {partyName}: {desc}";
                    string chequeNo = row.Cells["colChequeNo"].Value?.ToString() ?? "";

                    if (!int.TryParse(partyIdStr, out int partyId))
                    { MessageBox.Show($"Invalid party ID in row {row.Index + 1}."); txn.Rollback(); return; }
                    if (!decimal.TryParse(row.Cells["colAmount"].Value?.ToString(), out decimal amount))
                    { MessageBox.Show($"Invalid amount in row {row.Index + 1}."); txn.Rollback(); return; }

                    // Debit leg (payee)
                    InsertTx(conn, txn, txType, voucherNo, partyId, partyName, partyDesc, amount, 0, date, chequeNo);
                    using (var u = new SqliteCommand(
                        "UPDATE accounts SET current_balance=current_balance+@a WHERE account_id=@id",
                        conn, txn))
                    { u.Parameters.AddWithValue("@a", amount); u.Parameters.AddWithValue("@id", partyId); u.ExecuteNonQuery(); }

                    // Credit leg (bank)
                    InsertTx(conn, txn, txType, voucherNo, bankAccountId, bankName, bankDesc, 0, amount, date, chequeNo);
                    using (var u = new SqliteCommand(
                        "UPDATE accounts SET current_balance=current_balance-@a WHERE account_id=@id",
                        conn, txn))
                    { u.Parameters.AddWithValue("@a", amount); u.Parameters.AddWithValue("@id", bankAccountId); u.ExecuteNonQuery(); }
                }

                txn.Commit();
                MessageBox.Show("Bank Payment posted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _editingVoucherNo = null;
                txtVoucherNo.ReadOnly = false;
                ShowVoucherNo();
                gridLines.Rows.Clear();
                txtDescription.Clear();
                txtAmount.Clear();
                txtChequeNo.Clear();
                comboPartyName.SelectedIndex = -1;
                comboPartyId.SelectedIndex = -1;
                txtTotal.Text = "0";
                UpdateBankBalance();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private static void InsertTx(SqliteConnection conn, SqliteTransaction txn,
            string type, int voucher, int accId, string accName, string desc,
            decimal debit, decimal credit, string date, string chequeNo)
        {
            using var cmd = new SqliteCommand(@"
                INSERT INTO transactions
                (transaction_type,voucher_no,account_id,account_name,description,debit,credit,transaction_date,cheque_no)
                VALUES(@t,@v,@aid,@an,@d,@dr,@cr,@dt,@ch)",
                conn, txn);
            cmd.Parameters.AddWithValue("@t", type);
            cmd.Parameters.AddWithValue("@v", voucher);
            cmd.Parameters.AddWithValue("@aid", accId);
            cmd.Parameters.AddWithValue("@an", accName);
            cmd.Parameters.AddWithValue("@d", desc);
            cmd.Parameters.AddWithValue("@dr", debit);
            cmd.Parameters.AddWithValue("@cr", credit);
            cmd.Parameters.AddWithValue("@dt", date);
            cmd.Parameters.AddWithValue("@ch", chequeNo);
            cmd.ExecuteNonQuery();
        }

        // ── UI events ─────────────────────────────────────────────────────────
        private void comboBankId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBankId.SelectedIndex >= 0)
            { comboBankName.SelectedIndex = comboBankId.SelectedIndex; UpdateBankBalance(); }
        }

        private void comboBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBankName.SelectedIndex >= 0)
            { comboBankId.SelectedIndex = comboBankName.SelectedIndex; UpdateBankBalance(); }
        }

        private void comboPartyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyId.SelectedIndex >= 0)
            { comboPartyName.SelectedIndex = comboPartyId.SelectedIndex; UpdatePartyBalance(comboPartyId.SelectedIndex); }
        }

        private void comboPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyName.SelectedIndex >= 0)
            { comboPartyId.SelectedIndex = comboPartyName.SelectedIndex; UpdatePartyBalance(comboPartyName.SelectedIndex); }
            txtDescription.Focus();
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtAmount.Focus();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (decimal.TryParse(txtAmount.Text, out decimal amount))
                {
                    if (txtChequeNo.Text.Trim() != "")
                    {
                        txtDescription.Text += $" Chq# {txtChequeNo.Text.Trim()}";
                    }
                }
                AddRow(comboPartyName.Text, txtDescription.Text, amount);
                txtDescription.Clear();
                txtAmount.Clear();
                txtChequeNo.Clear();
                comboPartyName.Focus();
            }            
        }       

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (gridLines.SelectedRows.Count > 0 && !gridLines.SelectedRows[0].IsNewRow)
            {
                if (MessageBox.Show("Delete selected row?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    gridLines.Rows.RemoveAt(gridLines.SelectedRows[0].Index);
                    RecalcTotal();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Post this Bank Payment?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PostEntry();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close? Unsaved data will be lost.", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }
    }
}