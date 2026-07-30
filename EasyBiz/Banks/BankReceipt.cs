using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class BankReceipt : Form
    {
        private int? _editingVoucherNo = null;

        public BankReceipt()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadBankAccounts();
            LoadPartyAccounts();
            ShowVoucherNo();
            ThemeManager.ApplyTheme(this);
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
            txtVoucherNo.Text = GetNextVoucherNo("Bank Receipt").ToString();
        }

        private void LoadBankAccounts()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT account_id, account_name FROM accounts WHERE account_type='Banks' ORDER BY account_name";
            using var r = cmd.ExecuteReader();
            comboBankName.Items.Clear();
            comboBankId.Items.Clear();
            while (r.Read())
            {
                comboBankName.Items.Add(r.GetString(1));
                comboBankId.Items.Add(r.GetInt32(0).ToString());
            }
        }

        public void LoadPartyAccounts()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT account_id, account_name FROM accounts ORDER BY account_name";
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
            txtBankBalance.Text = bal < 0 ? $"{Math.Abs(bal):N0} Cr" : $"{bal:N0} Dr";
        }

        private void UpdatePartyBalance(int accountId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT current_balance FROM accounts WHERE account_id = @AccountId";

            var param = cmd.CreateParameter();
            param.ParameterName = "@AccountId";
            param.Value = accountId;
            cmd.Parameters.Add(param);

            var result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                decimal b = Convert.ToDecimal(result);
                txtPreBalance.ForeColor = b < 0 ? Color.Green : Color.Red;
                txtPreBalance.Text = b < 0 ? $"{Math.Abs(b):N0} Cr" : $"{b:N0} Dr";
            }
            else
            {
                // BUG FIX: this said "0 N0" (a leftover format-specifier typo)
                // instead of "0 Dr", so the no-balance/account-not-found state
                // displayed garbled text instead of a sensible default.
                txtPreBalance.Text = "0 Dr";
                txtPreBalance.ForeColor = Color.Black;
            }
        }

        // BUG FIX: parses with explicit NumberStyles/culture to match the
        // "N2" formatted strings now stored by AddRow, and the displayed
        // total is now rounded to 2 decimal places ("N2") instead of "N0" so
        // it doesn't visually disagree with the cents-precise row amounts.
        private void RecalcTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in gridLines.Rows)
            {
                if (r.IsNewRow) continue;
                if (decimal.TryParse(
                        r.Cells["colAmount"].Value?.ToString(),
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out var a))
                {
                    total += a;
                }
            }
            txtTotal.Text = total.ToString("N2");
        }

        // BUG FIX: amount is now stored as "N2" for consistency with the
        // corrected BankPayment.AddRow and with RecalcTotal's parsing above,
        // so the grid, the running total, and the posted ledger amount all
        // agree on precision.
        public void AddRow(string partyName, string description, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(partyName)) { MessageBox.Show("Party name is required."); return; }
            if (amount <= 0) { MessageBox.Show("Amount must be greater than zero."); return; }
            if (comboBankId.SelectedIndex < 0) { MessageBox.Show("Please select a bank account."); return; }
            if (comboPartyId.SelectedIndex < 0) { MessageBox.Show("Please select a party account."); return; }

            int ri = gridLines.Rows.Add();
            var row = gridLines.Rows[ri];
            row.Cells["colSno"].Value = gridLines.Rows.Count;
            row.Cells["colPartyId"].Value = comboPartyId.Text;
            row.Cells["colPartyName"].Value = partyName;
            row.Cells["colDesc"].Value = description;
            row.Cells["colAmount"].Value = amount.ToString("N2", CultureInfo.InvariantCulture);
            row.Cells["colChequeNo"].Value = txtChequeNo.Text.Trim();
            RecalcTotal();
        }

        // BUG FIX: this used to return void and only show a MessageBox when
        // the voucher didn't exist, but never actually stopped the caller
        // from proceeding. LoadTransactionForEditing called this and then
        // barreled ahead regardless - marking the form as "editing" a
        // voucher that doesn't exist, locking the voucher number box, and
        // running a SELECT that simply returns zero rows. Now it returns
        // bool so the caller can bail out cleanly, matching the pattern
        // already used in BankPayment.
        private bool CheckIfVoucherExists(int voucherNo)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COUNT(*) FROM transactions WHERE voucher_no=@v AND transaction_type='Bank Receipt'", conn);
            cmd.Parameters.AddWithValue("@v", voucherNo);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                MessageBox.Show($"Bank Receipt #{voucherNo} does not exist.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // BUG FIX (critical/crash): this method used to return void, but
        // EditTransactions.OpenTransaction<T> calls it through `dynamic` as:
        //     if (form.LoadTransactionForEditing(voucherNo))
        // Using a void-returning method as the condition of an `if` through
        // `dynamic` throws a RuntimeBinderException at runtime - so opening
        // any Bank Receipt for editing from the Edit Transactions screen
        // would crash. Changed to return bool, matching BankPayment's
        // signature, and now returns false immediately (without touching any
        // UI state) when the voucher doesn't exist - instead of leaving the
        // form in a half-initialized "editing" state.
        //
        // BUG FIX (ordering): the bank account is now restored BEFORE the
        // rows are added. AddRow() requires comboBankId.SelectedIndex >= 0
        // and silently rejects the row (with a "Please select a bank
        // account" message box) otherwise. Restoring the bank after the loop
        // - as the original code did - meant every row got rejected and the
        // grid ended up empty on edit, exactly like the BankPayment bug.
        public bool LoadTransactionForEditing(int voucherNo)
        {
            if (!CheckIfVoucherExists(voucherNo))
                return false;

            _editingVoucherNo = voucherNo;
            txtVoucherNo.Text = voucherNo.ToString();
            txtVoucherNo.ReadOnly = true;

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            // Load credit (party) rows — exclude the bank debit leg
            cmd.CommandText = @"
                SELECT t.account_id, t.account_name, t.description, t.credit,
                       t.transaction_date, t.cheque_no
                FROM   transactions t
                JOIN   accounts a ON a.account_id = t.account_id
                WHERE  t.voucher_no = @v AND t.transaction_type = 'Bank Receipt'
                  AND  t.credit > 0 AND a.account_type != 'Banks'";
            cmd.Parameters.AddWithValue("@v", voucherNo);

            gridLines.Rows.Clear();
            bool dateSet = false;

            // Buffer rows first, then close the reader before doing any
            // further work on the connection (avoids running a second
            // command against the connection while this reader is open).
            var rows = new List<(int AccId, string AccName, string Desc, decimal Credit, string ChequeNo)>();
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    if (!dateSet)
                    {
                        if (DateTime.TryParse(r.GetString(4), out var dt)) dateInvoice.Value = dt;
                        dateSet = true;
                    }
                    rows.Add((
                        r.GetInt32(0),
                        r.GetString(1),
                        r.GetString(2),
                        r.GetDecimal(3),
                        r.IsDBNull(5) ? "" : r.GetString(5)));
                }
            }

            // Restore bank selection BEFORE adding rows (see method-level
            // bug fix note above for why ordering matters here).
            using var cmd2 = conn.CreateCommand();
            cmd2.CommandText = @"
                SELECT t.account_id FROM transactions t
                JOIN accounts a ON a.account_id = t.account_id
                WHERE t.voucher_no=@v AND t.transaction_type='Bank Receipt'
                  AND a.account_type='Banks' LIMIT 1";
            cmd2.Parameters.AddWithValue("@v", voucherNo);
            var bankId = cmd2.ExecuteScalar();
            if (bankId != null) SelectBankById(Convert.ToInt32(bankId));

            foreach (var row in rows)
            {
                SelectPartyById(row.AccId);

                // Set the cheque box only for the duration of this AddRow
                // call, then clear it so it can't leak into the next row.
                txtChequeNo.Text = row.ChequeNo;
                AddRow(row.AccName, row.Desc, row.Credit);
                txtChequeNo.Clear();
            }

            comboPartyName.SelectedIndex = -1;
            comboPartyId.SelectedIndex = -1;
            txtPreBalance.Text = "0 Dr";
            return true;
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

                const string txType = "Bank Receipt";
                int bankAccountId = int.Parse(comboBankId.SelectedItem!.ToString()!);
                string bankName = comboBankName.SelectedItem!.ToString()!;
                int voucherNo;

                if (_editingVoucherNo.HasValue)
                {
                    voucherNo = _editingVoucherNo.Value;

                    // BUG FIX: previously this opened a SqliteDataReader and
                    // then, while it was still open, executed UPDATE commands
                    // against the same connection inside the read loop.
                    // Microsoft.Data.Sqlite does not support a write running
                    // against a connection that still has an open reader from
                    // an earlier SELECT - fixed by buffering the reversal
                    // rows into a list first, closing the reader, then
                    // issuing the UPDATEs.

                    // Reverse credit balances (party accounts)
                    var creditReversals = new List<(int AccountId, decimal Amount)>();
                    using (var cmd = new SqliteCommand(@"
                        SELECT account_id, credit FROM transactions
                        WHERE voucher_no=@v AND transaction_type=@t AND credit>0",
                        conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@t", txType);
                        using var r = cmd.ExecuteReader();
                        while (r.Read())
                            creditReversals.Add((r.GetInt32(0), r.GetDecimal(1)));
                    }
                    foreach (var (accId, amt) in creditReversals)
                    {
                        using var u = new SqliteCommand(
                            "UPDATE accounts SET current_balance=current_balance+@a WHERE account_id=@id",
                            conn, txn);
                        u.Parameters.AddWithValue("@a", amt);
                        u.Parameters.AddWithValue("@id", accId);
                        u.ExecuteNonQuery();
                    }

                    // Reverse bank debit (this one already read the total via
                    // ExecuteScalar before writing, so it didn't have the open-
                    // reader problem, but is left structurally consistent here)
                    using (var cmd = new SqliteCommand(@"
                        SELECT SUM(debit) FROM transactions
                        WHERE voucher_no=@v AND transaction_type=@t AND account_id=@b",
                        conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@t", txType);
                        cmd.Parameters.AddWithValue("@b", bankAccountId);
                        object sc = cmd.ExecuteScalar();
                        decimal tot = (sc == null || sc is DBNull) ? 0 : Convert.ToDecimal(sc);
                        using var u = new SqliteCommand(
                            "UPDATE accounts SET current_balance=current_balance-@a WHERE account_id=@id",
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
                    string partyDesc = $"To {bankName}: {desc}";
                    string bankDesc = $"From {partyName}: {desc}";
                    string chequeNo = row.Cells["colChequeNo"].Value?.ToString() ?? "";

                    if (!int.TryParse(partyIdStr, out int partyId))
                    { MessageBox.Show($"Invalid party ID in row {row.Index + 1}."); txn.Rollback(); return; }

                    // BUG FIX: parse with the same NumberStyles/culture used
                    // to store the value (see AddRow/RecalcTotal above).
                    if (!decimal.TryParse(
                            row.Cells["colAmount"].Value?.ToString(),
                            NumberStyles.Number,
                            CultureInfo.InvariantCulture,
                            out decimal amount))
                    { MessageBox.Show($"Invalid amount in row {row.Index + 1}."); txn.Rollback(); return; }

                    // Credit leg (party — they paid us)
                    InsertTx(conn, txn, txType, voucherNo, partyId, partyName, partyDesc, 0, amount, date, chequeNo);
                    using (var u = new SqliteCommand(
                        "UPDATE accounts SET current_balance=current_balance-@a WHERE account_id=@id",
                        conn, txn))
                    { u.Parameters.AddWithValue("@a", amount); u.Parameters.AddWithValue("@id", partyId); u.ExecuteNonQuery(); }

                    // Debit leg (bank — we received money)
                    InsertTx(conn, txn, txType, voucherNo, bankAccountId, bankName, bankDesc, amount, 0, date, chequeNo);
                    using (var u = new SqliteCommand(
                        "UPDATE accounts SET current_balance=current_balance+@a WHERE account_id=@id",
                        conn, txn))
                    { u.Parameters.AddWithValue("@a", amount); u.Parameters.AddWithValue("@id", bankAccountId); u.ExecuteNonQuery(); }
                }

                txn.Commit();
                MessageBox.Show("Bank Receipt posted successfully.", "Success",
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

        // BUG FIX: these handlers were calling UpdatePartyBalance(comboPartyId.SelectedIndex)
        // / UpdatePartyBalance(comboPartyName.SelectedIndex) - passing the
        // combo box's *list position* instead of the actual account_id.
        // UpdatePartyBalance(int accountId) runs
        // "SELECT current_balance FROM accounts WHERE account_id = @AccountId",
        // so unless an account's ID happens to equal its sorted position in
        // the list (which won't generally be true once accounts are added or
        // removed over time), this looked up and displayed the wrong
        // account's balance. Fixed to parse the actual ID out of
        // comboPartyId.Text, matching the pattern BankPayment already uses.
        private void comboPartyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyId.SelectedIndex >= 0)
            {
                comboPartyName.SelectedIndex = comboPartyId.SelectedIndex;

                if (!int.TryParse(comboPartyId.Text, out int accountId))
                    return;
                UpdatePartyBalance(accountId);
            }
        }
        private void comboPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyName.SelectedIndex >= 0)
            {
                comboPartyId.SelectedIndex = comboPartyName.SelectedIndex;

                if (!int.TryParse(comboPartyId.Text, out int accountId))
                    return;
                UpdatePartyBalance(accountId);
            }
            txtDescription.Focus();
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtAmount.Focus();
        }

        // BUG FIX: previously, if decimal.TryParse failed, `amount` defaulted
        // to 0 and AddRow was still called (which rejects amount <= 0, but
        // the input fields were cleared regardless of whether a row was
        // actually added) - silently discarding whatever the user had typed.
        // Now it bails out immediately on invalid input, and only clears the
        // inputs once a row has actually been added.
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            if (txtChequeNo.Text.Trim() != "")
            {
                if (!txtDescription.Text.Contains($"Chq# {txtChequeNo.Text.Trim()}"))
                {
                    txtDescription.Text += $" Chq# {txtChequeNo.Text.Trim()}";
                }
            }

            int rowCountBefore = gridLines.Rows.Count;
            AddRow(comboPartyName.Text, txtDescription.Text, amount);

            if (gridLines.Rows.Count > rowCountBefore)
            {
                txtDescription.Clear();
                txtAmount.Clear();
                txtChequeNo.Clear();
                comboPartyName.Focus();
            }
        }

        // BUG FIX: this never called RenumberRows() after deleting a row, so
        // the colSno (serial number) column went out of sequence after a
        // delete (e.g. 1, 2, 4 after deleting row 3, instead of 1, 2, 3).
        // BankPayment already renumbers; this brings BankReceipt in line.
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (gridLines.SelectedRows.Count > 0 && !gridLines.SelectedRows[0].IsNewRow)
            {
                if (MessageBox.Show("Delete selected row?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    gridLines.Rows.RemoveAt(gridLines.SelectedRows[0].Index);
                    RenumberRows();
                    RecalcTotal();
                }
            }
        }

        private void RenumberRows()
        {
            for (int i = 0; i < gridLines.Rows.Count; i++)
            {
                if (!gridLines.Rows[i].IsNewRow)
                    gridLines.Rows[i].Cells["colSno"].Value = i + 1;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Post this Bank Receipt?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PostEntry();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BankReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBankName.Text != "" || comboPartyName.Text != "" || txtChequeNo.Text != "" || txtDescription.Text != "" || txtAmount.Text != "")
            {
                var result = MessageBox.Show("Are you sure you want to close the Bank Receipt Voucher?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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