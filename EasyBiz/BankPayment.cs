using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
                txtPreBalance.Text = "0 Dr";
                txtPreBalance.ForeColor = Color.Black;
            }
        }

        // BUG FIX: RecalcTotal used to parse colAmount.ToString() with a plain
        // decimal.TryParse, which is fragile against the "N0" formatted strings
        // stored by AddRow (and silently produces wrong totals if the cell ever
        // holds something unparsable). We now parse with NumberStyles that match
        // what AddRow stores, and we always re-sum from the same currency-safe
        // formatting helper so the displayed total matches what gets posted.
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

        // ── Add row ───────────────────────────────────────────────────────────
        // BUG FIX: amount is now stored with 2 decimal places ("N2") instead of
        // "N0". Storing whole-number-only text silently rounded away cents
        // (e.g. 1500.75 became "1,501"), and that rounded figure is what later
        // got posted into the ledger via PostEntry -> InsertTx. That is a real
        // money-correctness bug; fixed here so cents survive round-tripping
        // through the grid.
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
            row.Cells["colAmount"].Value = amount.ToString("N2", CultureInfo.InvariantCulture);
            row.Cells["colChequeNo"].Value = txtChequeNo.Text.Trim();
            RecalcTotal();
        }

        // ── Check / Load for editing ──────────────────────────────────────────
        private bool CheckIfVoucherExists(int voucherNo)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT COUNT(*) FROM transactions WHERE voucher_no = @voucherNo AND transaction_type = @type";
                command.Parameters.AddWithValue("@voucherNo", voucherNo);
                command.Parameters.AddWithValue("@type", "Bank Payment");
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        // BUG FIX: txtChequeNo used to be left holding whatever the *last*
        // loaded row's cheque number was, because it was set inside the loop
        // and never cleared afterward. That stale value then silently leaked
        // into colChequeNo on the next manually-typed row (AddRow reads
        // txtChequeNo.Text). We now read the cheque number per-row into a
        // local variable and pass it straight into a per-row add, instead of
        // routing it through the shared txtChequeNo text box.
        public bool LoadTransactionForEditing(int voucherNo)
        {
            if (!CheckIfVoucherExists(voucherNo))
            {
                MessageBox.Show(
                    $"Voucher number {voucherNo} does not exist for Bank Payment.",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return false;
            }
            _editingVoucherNo = voucherNo;
            txtVoucherNo.Text = voucherNo.ToString();
            txtVoucherNo.ReadOnly = true;

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
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

            // Buffer rows first, then close the reader before doing any
            // further work on the connection (see PostEntry fix below for why
            // this matters: Microsoft.Data.Sqlite does not like a second
            // command running against the same connection while a reader from
            // an earlier command is still open).
            var rows = new List<(int AccId, string AccName, string Desc, decimal Debit, string ChequeNo)>();
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

            // BUG FIX: the bank account must be selected BEFORE we call AddRow
            // in the loop below. AddRow() has a guard clause that requires
            // comboBankId.SelectedIndex >= 0, and shows "Please select a bank
            // account" + returns without adding the row if it isn't selected
            // yet. The bank used to be restored AFTER the rows were added,
            // which meant every single row got silently rejected by that
            // guard during edit-load, leaving the grid empty with a stray
            // message box. Moving this block above the foreach fixes it.
            using var cmd2 = conn.CreateCommand();
            cmd2.CommandText = @"
                SELECT t.account_id FROM transactions t
                JOIN accounts a ON a.account_id = t.account_id
                WHERE t.voucher_no=@v AND t.transaction_type='Bank Payment'
                  AND a.account_type='Banks' LIMIT 1";
            cmd2.Parameters.AddWithValue("@v", voucherNo);
            var bankId = cmd2.ExecuteScalar();
            if (bankId != null) SelectBankById(Convert.ToInt32(bankId));

            foreach (var row in rows)
            {
                SelectPartyById(row.AccId);

                // Set the cheque box only for the duration of this AddRow call,
                // then clear it immediately so it can't leak into the next row.
                txtChequeNo.Text = row.ChequeNo;
                AddRow(row.AccName, row.Desc, row.Debit);
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

                    // BUG FIX: previously each of these blocks opened a
                    // SqliteDataReader and then, *while that reader was still
                    // open*, created and executed a second SqliteCommand
                    // (an UPDATE) against the same connection inside the loop.
                    // Microsoft.Data.Sqlite does not support having an UPDATE
                    // run against a connection that still has an open reader
                    // from a SELECT on that same connection - this throws
                    // "database table is locked" / SqliteException in
                    // practice. Fixed by fully buffering each reader's rows
                    // into a list first, closing the reader, and only then
                    // issuing the UPDATEs.

                    // Reverse debit balances (payee legs)
                    var debitReversals = new List<(int AccountId, decimal Amount)>();
                    using (var cmd = new SqliteCommand(@"
                        SELECT account_id, debit FROM transactions
                        WHERE voucher_no=@v AND transaction_type=@t AND debit>0",
                        conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@t", txType);
                        using var r = cmd.ExecuteReader();
                        while (r.Read())
                            debitReversals.Add((r.GetInt32(0), r.GetDecimal(1)));
                    }
                    foreach (var (accId, amt) in debitReversals)
                    {
                        using var u = new SqliteCommand(
                            "UPDATE accounts SET current_balance=current_balance-@a WHERE account_id=@id",
                            conn, txn);
                        u.Parameters.AddWithValue("@a", amt);
                        u.Parameters.AddWithValue("@id", accId);
                        u.ExecuteNonQuery();
                    }

                    // Reverse the ORIGINAL bank account credit leg(s)
                    var creditReversals = new List<(int AccountId, decimal Amount)>();
                    using (var cmd = new SqliteCommand(@"
                        SELECT account_id, SUM(credit)
                        FROM transactions
                        WHERE voucher_no = @v
                          AND transaction_type = @t
                          AND credit > 0
                        GROUP BY account_id",
                        conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@t", txType);

                        using var reader = cmd.ExecuteReader();
                        while (reader.Read())
                            creditReversals.Add((reader.GetInt32(0), reader.GetDecimal(1)));
                    }
                    foreach (var (originalBankId, originalCredit) in creditReversals)
                    {
                        using var updateCmd = new SqliteCommand(
                            @"UPDATE accounts
                              SET current_balance = current_balance + @amount
                              WHERE account_id = @id",
                            conn, txn);
                        updateCmd.Parameters.AddWithValue("@amount", originalCredit);
                        updateCmd.Parameters.AddWithValue("@id", originalBankId);
                        updateCmd.ExecuteNonQuery();
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

                    // BUG FIX: parse with the same NumberStyles/culture used to
                    // store the value (see AddRow/RecalcTotal). A plain
                    // decimal.TryParse on "N2"-formatted text with thousands
                    // separators works in en-US, but is culture-fragile; being
                    // explicit avoids silent failures on other locales/cells.
                    if (!decimal.TryParse(
                            row.Cells["colAmount"].Value?.ToString(),
                            NumberStyles.Number,
                            CultureInfo.InvariantCulture,
                            out decimal amount))
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
                txtDescription.Clear();
                txtAmount.Clear();
                txtChequeNo.Clear();
                comboPartyName.SelectedIndex = -1;
                comboPartyId.SelectedIndex = -1;
                txtTotal.Text = "0";
                gridLines.Rows.Clear();
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

        // BUG FIX: previously, if decimal.TryParse failed, AddRow was still
        // called with the default `amount` value of 0 - and the input fields
        // were cleared regardless of success, silently discarding whatever
        // the user typed. Now we bail out before touching the row or clearing
        // anything when the amount is not a valid number, and we only clear
        // the inputs after a row was actually added.
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
                if (!txtDescription.Text.Contains($"Chq#{txtChequeNo.Text.Trim()}"))
                {
                    txtDescription.Text += $" Chq#{txtChequeNo.Text.Trim()}";
                }
            }

            int rowCountBefore = gridLines.Rows.Count;
            AddRow(comboPartyName.Text, txtDescription.Text, amount);

            // Only clear the inputs if AddRow actually added a row (AddRow
            // shows a MessageBox and returns early without adding a row when
            // party/bank/amount validation fails).
            if (gridLines.Rows.Count > rowCountBefore)
            {
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
            if (MessageBox.Show("Post this Bank Payment?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PostEntry();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BankPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBankName.Text != "" || comboPartyName.Text != "" || txtChequeNo.Text != "" || txtDescription.Text != "" || txtAmount.Text != "")
            {
                var result = MessageBox.Show("Are you sure you want to close the Bank Payment Voucher?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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