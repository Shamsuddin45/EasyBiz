using Microsoft.Data.Sqlite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyBiz
{
    /// <summary>
    /// Cheque Book Manager — tracks issued cheques (payable) and
    /// received cheques (receivable) with status: Issued / Cleared / Returned / Cancelled.
    /// </summary>
    public partial class ChequeBook : Form
    {
        public ChequeBook()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadBankAccounts();
            LoadPartyAccounts();
            LoadCheques();
            comboDirection.Items.AddRange(new[] { "Payable (We Issued)", "Receivable (We Received)" });
            comboDirection.SelectedIndex = 0;
            comboStatus.Items.AddRange(new[] { "All", "Issued", "Cleared", "Returned", "Cancelled" });
            comboStatus.SelectedIndex = 0;
            ThemeManager.ApplyTheme(this);
        }

        // ── Populate combos ───────────────────────────────────────────────────
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

        private void LoadPartyAccounts()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT account_id, account_name FROM accounts ORDER BY account_name";
            using var r = cmd.ExecuteReader();
            comboPartyName.Items.Clear();
            comboPartyId.Items.Clear();
            while (r.Read())
            {
                comboPartyName.Items.Add(r.GetString(1));
                comboPartyId.Items.Add(r.GetInt32(0).ToString());
            }
        }

        // ── Load cheque register ──────────────────────────────────────────────
        public void LoadCheques()
        {
            gridCheques.Rows.Clear();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();

            string statusFilter = comboStatus.SelectedItem?.ToString() ?? "All";
            string wherePart = statusFilter == "All" ? "" : "WHERE c.status = @status";

            cmd.CommandText = $@"
                SELECT c.cheque_id, c.cheque_no, c.cheque_date, c.bank_account_name,
                       c.party_account_name, c.amount, c.direction, c.status,
                       c.description, c.cleared_date, c.created_at
                FROM cheques c
                {wherePart}
                ORDER BY c.cheque_date DESC, c.cheque_id DESC";

            if (statusFilter != "All")
                cmd.Parameters.AddWithValue("@status", statusFilter);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                int ri = gridCheques.Rows.Add();
                var row = gridCheques.Rows[ri];
                row.Cells["colChequeId"].Value = r.GetInt32(0);
                row.Cells["colChequeNo"].Value = r.GetString(1);
                row.Cells["colChequeDate"].Value = r.GetString(2);
                row.Cells["colBankName"].Value = r.GetString(3);
                row.Cells["colPartyName"].Value = r.GetString(4);
                row.Cells["colAmount"].Value = r.GetDecimal(5).ToString("N0");
                row.Cells["colDirection"].Value = r.GetString(6);
                row.Cells["colStatus"].Value = r.GetString(7);
                row.Cells["colDesc"].Value = r.IsDBNull(8) ? "" : r.GetString(8);
                row.Cells["colClearedDate"].Value = r.IsDBNull(9) ? "" : r.GetString(9);

                // Color by status
                string status = r.GetString(7);
                row.DefaultCellStyle.BackColor = status switch
                {
                    "Cleared" => Color.FromArgb(230, 255, 230),
                    "Returned" => Color.FromArgb(255, 230, 230),
                    "Cancelled" => Color.FromArgb(245, 245, 245),
                    _ => Color.FromArgb(255, 255, 230) // Issued = pale yellow
                };
                row.DefaultCellStyle.ForeColor = status switch
                {
                    "Cleared" => Color.DarkGreen,
                    "Returned" => Color.DarkRed,
                    "Cancelled" => Color.Gray,
                    _ => Color.FromArgb(100, 80, 0)
                };
            }

            UpdateSummaryLabels();
        }

        private void UpdateSummaryLabels()
        {
            using var conn = DatabaseHelper.GetConnection();

            decimal SumOf(string status, string dir)
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT IFNULL(SUM(amount),0) FROM cheques WHERE status=@s AND direction=@d";
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@d", dir);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }

            decimal issuedPay = SumOf("Issued", "Payable");
            decimal issuedRec = SumOf("Issued", "Receivable");
            decimal clearedPay = SumOf("Cleared", "Payable");
            decimal clearedRec = SumOf("Cleared", "Receivable");

            lblSummary.Text =
                $"Payable Pending: {issuedPay:N0}  |  " +
                $"Receivable Pending: {issuedRec:N0}  |  " +
                $"Cleared (Out): {clearedPay:N0}  |  " +
                $"Cleared (In): {clearedRec:N0}";
        }

        // ── Add new cheque ────────────────────────────────────────────────────
        private void BtnAddCheque_Click(object sender, EventArgs e)
        {
            if (comboBankId.SelectedIndex < 0) { MessageBox.Show("Select a bank account."); return; }
            if (comboPartyId.SelectedIndex < 0) { MessageBox.Show("Select a party account."); return; }
            if (string.IsNullOrWhiteSpace(txtChequeNo.Text)) { MessageBox.Show("Enter a cheque number."); return; }
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            { MessageBox.Show("Enter a valid amount."); return; }

            string direction = comboDirection.SelectedIndex == 0 ? "Payable" : "Receivable";

            using var conn = DatabaseHelper.GetConnection();

            // Check for duplicate cheque number within same bank + direction
            using (var dup = conn.CreateCommand())
            {
                dup.CommandText = "SELECT COUNT(*) FROM cheques WHERE cheque_no=@cn AND bank_account_id=@bid AND direction=@dir";
                dup.Parameters.AddWithValue("@cn", txtChequeNo.Text.Trim());
                dup.Parameters.AddWithValue("@bid", int.Parse(comboBankId.SelectedItem!.ToString()!));
                dup.Parameters.AddWithValue("@dir", direction);
                if (Convert.ToInt32(dup.ExecuteScalar()) > 0)
                {
                    MessageBox.Show($"Cheque #{txtChequeNo.Text.Trim()} already exists for this bank ({direction}).",
                        "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO cheques
                (cheque_no, cheque_date, bank_account_id, bank_account_name,
                 party_account_id, party_account_name, amount, direction, status, description)
                VALUES
                (@cn, @cd, @bid, @bn, @pid, @pn, @amt, @dir, 'Issued', @desc)";

            cmd.Parameters.AddWithValue("@cn", txtChequeNo.Text.Trim());
            cmd.Parameters.AddWithValue("@cd", dateCheque.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@bid", int.Parse(comboBankId.SelectedItem!.ToString()!));
            cmd.Parameters.AddWithValue("@bn", comboBankName.SelectedItem!.ToString()!);
            cmd.Parameters.AddWithValue("@pid", int.Parse(comboPartyId.SelectedItem!.ToString()!));
            cmd.Parameters.AddWithValue("@pn", comboPartyName.SelectedItem!.ToString()!);
            cmd.Parameters.AddWithValue("@amt", amount);
            cmd.Parameters.AddWithValue("@dir", direction);
            cmd.Parameters.AddWithValue("@desc", txtDesc.Text.Trim());
            cmd.ExecuteNonQuery();

            MessageBox.Show("Cheque added to register successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearInputs();
            LoadCheques();
        }

        // ── Change status of selected cheque ──────────────────────────────────
        private void ChangeStatus(string newStatus)
        {
            if (gridCheques.SelectedRows.Count == 0) { MessageBox.Show("Select a cheque first."); return; }
            var row = gridCheques.SelectedRows[0];
            int chequeId = Convert.ToInt32(row.Cells["colChequeId"].Value);
            string current = row.Cells["colStatus"].Value?.ToString() ?? "";

            if (current == newStatus)
            { MessageBox.Show($"Cheque is already {newStatus}."); return; }

            string confirm = newStatus == "Cleared"
                ? $"Mark cheque #{row.Cells["colChequeNo"].Value} as CLEARED?"
                : newStatus == "Returned"
                    ? $"Mark cheque #{row.Cells["colChequeNo"].Value} as RETURNED (bounced)?"
                    : $"Mark cheque #{row.Cells["colChequeNo"].Value} as {newStatus}?";

            if (MessageBox.Show(confirm, "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE cheques SET status=@s,
                    cleared_date = CASE WHEN @s='Cleared' THEN date('now') ELSE cleared_date END
                WHERE cheque_id=@id";
            cmd.Parameters.AddWithValue("@s", newStatus);
            cmd.Parameters.AddWithValue("@id", chequeId);
            cmd.ExecuteNonQuery();

            LoadCheques();
        }

        private void ClearInputs()
        {
            txtChequeNo.Clear();
            txtAmount.Clear();
            txtDesc.Clear();
            comboPartyName.SelectedIndex = -1;
            comboPartyId.SelectedIndex = -1;
            comboBankName.SelectedIndex = -1;
            comboBankId.SelectedIndex = -1;
            comboDirection.SelectedIndex = 0;
        }

        // ── UI events ─────────────────────────────────────────────────────────
        private void comboBankId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBankId.SelectedIndex >= 0) comboBankName.SelectedIndex = comboBankId.SelectedIndex;
        }
        private void comboBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBankName.SelectedIndex >= 0) comboBankId.SelectedIndex = comboBankName.SelectedIndex;
        }
        private void comboPartyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyId.SelectedIndex >= 0) comboPartyName.SelectedIndex = comboPartyId.SelectedIndex;
        }
        private void comboPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyName.SelectedIndex >= 0) comboPartyId.SelectedIndex = comboPartyName.SelectedIndex;
        }
        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e) => LoadCheques();
        private void BtnRefresh_Click(object sender, EventArgs e) => LoadCheques();
        private void BtnClear_Click(object sender, EventArgs e) => ChangeStatus("Cleared");
        private void BtnReturn_Click(object sender, EventArgs e) => ChangeStatus("Returned");
        private void BtnCancel_Click(object sender, EventArgs e) => ChangeStatus("Cancelled");
        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void gridCheques_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRow = gridCheques.SelectedRows.Count > 0;
            BtnClear.Enabled = hasRow;
            BtnReturn.Enabled = hasRow;
            BtnCancel.Enabled = hasRow;
        }

        private void txtSearchCheque_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearchCheque.Text.Trim().ToLower();
            foreach (DataGridViewRow row in gridCheques.Rows)
            {
                if (row.IsNewRow) continue;
                string no = row.Cells["colChequeNo"].Value?.ToString()?.ToLower() ?? "";
                string party = row.Cells["colPartyName"].Value?.ToString()?.ToLower() ?? "";
                row.Visible = string.IsNullOrEmpty(q) || no.Contains(q) || party.Contains(q);
            }
        }

        private void ChequeBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBankName.Text != "" || comboPartyName.Text != "" || txtChequeNo.Text != "" || txtDesc.Text != "" || txtAmount.Text != "")
            {
                var result = MessageBox.Show("Are you sure you want to close the Cheque Book Manager?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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