using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class PurchaseInvoice : Form
    {
        private int? _editingVoucherNo = null;
        public PurchaseInvoice()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadAccounts();
            LoadProducts();
            ShowVoucherNo();
            BeautifyGrid();
            comboPaymentMode.Items.AddRange(new[] { "Credit", "Cash" });
            comboPaymentMode.SelectedItem = "Credit";
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
        private void BeautifyGrid()
        {
            // General
            gridItems.BorderStyle = BorderStyle.None;
            gridItems.BackgroundColor = Color.White;
            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = false;
            gridItems.AllowUserToResizeRows = false;
            gridItems.MultiSelect = false;
            gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItems.RowHeadersVisible = false;
            gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Header Style
            gridItems.EnableHeadersVisualStyles = false;
            gridItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridItems.ColumnHeadersHeight = 40;

            gridItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            gridItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gridItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Rows
            gridItems.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            gridItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            gridItems.DefaultCellStyle.SelectionForeColor = Color.White;
            gridItems.DefaultCellStyle.BackColor = Color.White;
            gridItems.DefaultCellStyle.ForeColor = Color.Black;

            // Alternate Row Color
            gridItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Grid Lines
            gridItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridItems.GridColor = Color.Gainsboro;

            // Row Height
            gridItems.RowTemplate.Height = 32;

            // Column Alignment
            gridItems.Columns["colQty"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            gridItems.Columns["colWeight"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            gridItems.Columns["colRate"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            gridItems.Columns["colAmount"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            // Currency Format
            gridItems.Columns["colRate"].DefaultCellStyle.Format = "N2";
            gridItems.Columns["colAmount"].DefaultCellStyle.Format = "N2";
        }

        // ── 1. Verify voucher exists ─────────────────────────────────────────────────
        public void CheckIfPurchaseVoucherExists(int voucherNo)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COUNT(*) FROM purchase_invoices WHERE voucher_no = @v", conn);
            cmd.Parameters.AddWithValue("@v", voucherNo);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
                MessageBox.Show(
                    $"Purchase Invoice #{voucherNo} does not exist.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowVoucherNo()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COALESCE(MAX(voucher_no),0)+1 FROM purchase_invoices", conn);
            txtVoucherNo.Text = cmd.ExecuteScalar()!.ToString();
            lblHeader.Text = $"Purchase Invoice # {txtVoucherNo.Text}" + (_editingVoucherNo.HasValue ? " (Edit Mode)" : "");
        }

        private void LoadAccounts()
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

        private void LoadProducts()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT product_id, product_name, purchase_rate, current_qty, current_weight, unit, weight_unit FROM products ORDER BY product_name";
            using var r = cmd.ExecuteReader();
            comboProduct.Items.Clear();
            comboProduct.Tag = new System.Collections.Generic.List<object[]>();
            var list = (System.Collections.Generic.List<object[]>)comboProduct.Tag;
            while (r.Read())
            {
                comboProduct.Items.Add(r.GetString(1));
                list.Add(new object[] {
                    r.GetInt32(0), r.GetString(1),
                    r.GetDouble(2), r.GetDouble(3),
                    r.GetDouble(4), r.GetString(5), r.GetString(6)
                });
            }
        }


        // ── 2. Load invoice into the form for editing ────────────────────────────────
        public void LoadTransactionForEditing(int voucherNo)
        {
            CheckIfPurchaseVoucherExists(voucherNo);

            _editingVoucherNo = voucherNo;
            txtVoucherNo.Text = voucherNo.ToString();
            txtVoucherNo.ReadOnly = true;                      // lock while editing
            lblHeader.Text = $"Purchase Invoice # {voucherNo} (Edit Mode)";

            // ── Load header ──────────────────────────────────────────────────────────
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT account_id, account_name, invoice_date,
                   description, discount, payment_mode
            FROM   purchase_invoices
            WHERE  voucher_no = @v";
                cmd.Parameters.AddWithValue("@v", voucherNo);

                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    // Party
                    SelectPartyById(r.GetInt32(0));

                    // Date
                    if (DateTime.TryParse(r.GetString(2), out var dt))
                        dateInvoice.Value = dt;

                    // Description
                    txtDescription.Text = r.IsDBNull(3) ? "" : r.GetString(3);

                    // Discount
                    numDiscount.Value = r.IsDBNull(4) ? 0 : r.GetDecimal(4);

                    // Payment mode
                    string pm = r.IsDBNull(5) ? "Credit" : r.GetString(5);
                    comboPaymentMode.SelectedItem = pm;
                }
            }

            // ── Load line items ──────────────────────────────────────────────────────
            gridItems.Rows.Clear();

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT product_id, product_name, quantity, weight,
                   weight_unit, rate, amount
            FROM   purchase_invoice_items
            WHERE  voucher_no = @v";
                cmd.Parameters.AddWithValue("@v", voucherNo);

                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int productId = r.GetInt32(0);

                    // Fetch unit from products table
                    string unit = "";
                    using (var conn2 = DatabaseHelper.GetConnection())
                    using (var cmd2 = new SqliteCommand(
                        "SELECT unit FROM products WHERE product_id = @pid", conn2))
                    {
                        cmd2.Parameters.AddWithValue("@pid", productId);
                        var res = cmd2.ExecuteScalar();
                        if (res != null) unit = res.ToString()!;
                    }

                    int rowIndex = gridItems.Rows.Add();
                    var row = gridItems.Rows[rowIndex];

                    row.Cells["colProductId"].Value = productId.ToString();
                    row.Cells["colProductName"].Value = r.GetString(1);
                    row.Cells["colUnit"].Value = unit;
                    row.Cells["colQty"].Value = r.GetDouble(2).ToString("N3");
                    row.Cells["colWeight"].Value = r.GetDouble(3).ToString("N3");
                    row.Cells["colWeightUnit"].Value = r.IsDBNull(4) ? "" : r.GetString(4);
                    row.Cells["colRate"].Value = r.GetDouble(5).ToString("N2");
                    row.Cells["colAmount"].Value = r.GetDouble(6).ToString("N2");
                }
            }

            RecalcTotal();

            // Reset item-input section ready for optional extra lines
            comboProduct.SelectedIndex = -1;
            numQty.Value = 0;
            numWeight.Value = 0;
            numRate.Value = 0;
            lblStockQty.Text = "Qty: -";
            lblStockWt.Text = "Weight: -";
        }

        // ── 3. Helper — select party combo by account_id ─────────────────────────────
        private void SelectPartyById(int accountId)
        {
            for (int i = 0; i < comboPartyId.Items.Count; i++)
            {
                if (comboPartyId.Items[i].ToString() == accountId.ToString())
                {
                    comboPartyId.SelectedIndex = i;
                    comboPartyName.SelectedIndex = i;
                    return;
                }
            }
        }
        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProduct.SelectedIndex < 0) return;
            var list = (System.Collections.Generic.List<object[]>)comboProduct.Tag;
            var prod = list[comboProduct.SelectedIndex];
            numRate.Value = (decimal)(double)prod[2];
            lblStockQty.Text = $"Qty: {(double)prod[3]:N2} {prod[5]}";
            lblStockWt.Text = $"Weight: {(double)prod[4]:N3} {prod[6]}";
            numQty.Focus();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (comboProduct.SelectedIndex < 0) { MessageBox.Show("Select a product."); return; }
            if (numQty.Value <= 0 && numWeight.Value <= 0)
            { MessageBox.Show("Enter quantity or weight."); return; }
            if (numRate.Value <= 0) { MessageBox.Show("Enter a valid rate."); return; }

            var list = (System.Collections.Generic.List<object[]>)comboProduct.Tag;
            var prod = list[comboProduct.SelectedIndex];

            decimal qty = numQty.Value;
            decimal weight = numWeight.Value;
            decimal rate = numRate.Value;
            decimal amount = (qty > 0 ? qty : weight) * rate;

            int rowIndex = gridItems.Rows.Add();
            var row = gridItems.Rows[rowIndex];
            row.Cells["colProductId"].Value = prod[0].ToString();
            row.Cells["colProductName"].Value = prod[1].ToString();
            row.Cells["colUnit"].Value = prod[5].ToString();
            row.Cells["colQty"].Value = qty.ToString("N3");
            row.Cells["colWeight"].Value = weight.ToString("N3");
            row.Cells["colWeightUnit"].Value = prod[6].ToString();
            row.Cells["colRate"].Value = rate.ToString("N2");
            row.Cells["colAmount"].Value = amount.ToString("N2");

            RecalcTotal();
            ResetItemInputs();
        }

        private void RecalcTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in gridItems.Rows)
            {
                if (r.IsNewRow) continue;
                if (decimal.TryParse(r.Cells["colAmount"].Value?.ToString(), out var a))
                    total += a;
            }
            numTotal.Value = total;
            numNetAmount.Value = total - numDiscount.Value;
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e) => RecalcTotal();

        private void ResetItemInputs()
        {
            comboProduct.SelectedIndex = -1;
            numQty.Value = 0;
            numWeight.Value = 0;
            numRate.Value = 0;
            lblStockQty.Text = "Qty: -";
            lblStockWt.Text = "Weight: -";
            comboProduct.Focus();
        }

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (gridItems.SelectedRows.Count > 0 && !gridItems.SelectedRows[0].IsNewRow)
            {
                gridItems.Rows.RemoveAt(gridItems.SelectedRows[0].Index);
                RecalcTotal();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (comboPartyId.SelectedIndex < 0) { MessageBox.Show("Select a supplier."); return; }
            if (gridItems.Rows.Count == 0) { MessageBox.Show("Add at least one item."); return; }

            if (MessageBox.Show("Post this Purchase Invoice?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            PostPurchaseInvoice();
        }

        private void PostPurchaseInvoice()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var txn = conn.BeginTransaction();

                string date = dateInvoice.Value.ToString("yyyy-MM-dd");
                int accountId = int.Parse(comboPartyId.SelectedItem!.ToString()!);
                string accountName = comboPartyName.SelectedItem!.ToString()!;
                string payMode = comboPaymentMode.SelectedItem!.ToString()!;
                decimal total = numTotal.Value;
                decimal discount = numDiscount.Value;
                decimal net = numNetAmount.Value;
                string desc = txtDescription.Text.Trim();

                int voucherNo;

                // ════════════════════════════════════════════════════════════════════
                //  EDIT MODE — reverse everything posted, then re-insert fresh
                // ════════════════════════════════════════════════════════════════════
                if (_editingVoucherNo.HasValue)
                {
                    voucherNo = _editingVoucherNo.Value;

                    // 1a. Reverse stock — purchases ADD stock, so we SUBTRACT it back
                    using (var cmd = new SqliteCommand(@"
                SELECT product_id, quantity, weight
                FROM   purchase_invoice_items
                WHERE  voucher_no = @v", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        using var r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            int pid = r.GetInt32(0);
                            double qty = r.GetDouble(1);
                            double wt = r.GetDouble(2);

                            using var upd = new SqliteCommand(@"
                        UPDATE products
                        SET current_qty    = current_qty    - @qty,
                            current_weight = current_weight - @wt
                        WHERE product_id = @pid", conn, txn);
                            upd.Parameters.AddWithValue("@qty", qty);
                            upd.Parameters.AddWithValue("@wt", wt);
                            upd.Parameters.AddWithValue("@pid", pid);
                            upd.ExecuteNonQuery();
                        }
                    }

                    // 1b. Reverse the old financial transaction balance
                    //     Purchase posts a CREDIT to supplier/cash, so we ADD back
                    using (var cmd = new SqliteCommand(@"
                SELECT account_id, credit
                FROM   transactions
                WHERE  voucher_no       = @v
                  AND  transaction_type = 'Purchase Invoice'", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        using var r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            int oldAccId = r.GetInt32(0);
                            decimal oldCredit = r.GetDecimal(1);

                            using var upd = new SqliteCommand(
                                "UPDATE accounts SET current_balance = current_balance + @a WHERE account_id = @id",
                                conn, txn);
                            upd.Parameters.AddWithValue("@a", (double)oldCredit);
                            upd.Parameters.AddWithValue("@id", oldAccId);
                            upd.ExecuteNonQuery();
                        }
                    }

                    // 1c. Delete old records from all related tables
                    foreach (string sql in new[]
                    {
                "DELETE FROM stock_movements       WHERE voucher_no = @v AND movement_type = 'Purchase'",
                "DELETE FROM purchase_invoice_items WHERE voucher_no = @v",
                "DELETE FROM transactions           WHERE voucher_no = @v AND transaction_type = 'Purchase Invoice'",
                "DELETE FROM purchase_invoices      WHERE voucher_no = @v"
            })
                    {
                        using var cmd = new SqliteCommand(sql, conn, txn);
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // ════════════════════════════════════════════════════════════════
                    //  NEW MODE — generate next voucher number
                    // ════════════════════════════════════════════════════════════════
                    using var cmd = new SqliteCommand(
                        "SELECT COALESCE(MAX(voucher_no),0)+1 FROM purchase_invoices", conn, txn);
                    voucherNo = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // ════════════════════════════════════════════════════════════════════
                //  INSERT — shared by both new and edit
                // ════════════════════════════════════════════════════════════════════

                // 2. Insert purchase header
                long purchaseId;
                using (var cmd = new SqliteCommand(@"
            INSERT INTO purchase_invoices
                (voucher_no, invoice_date, account_id, account_name, description,
                 total_amount, discount, net_amount, payment_mode)
            VALUES (@v,@dt,@aid,@an,@d,@tot,@disc,@net,@pm);
            SELECT last_insert_rowid();", conn, txn))
                {
                    cmd.Parameters.AddWithValue("@v", voucherNo);
                    cmd.Parameters.AddWithValue("@dt", date);
                    cmd.Parameters.AddWithValue("@aid", accountId);
                    cmd.Parameters.AddWithValue("@an", accountName);
                    cmd.Parameters.AddWithValue("@d", desc);
                    cmd.Parameters.AddWithValue("@tot", (double)total);
                    cmd.Parameters.AddWithValue("@disc", (double)discount);
                    cmd.Parameters.AddWithValue("@net", (double)net);
                    cmd.Parameters.AddWithValue("@pm", payMode);
                    purchaseId = (long)cmd.ExecuteScalar()!;
                }

                // 3. Process each line item
                var itemSummary = new System.Text.StringBuilder();

                foreach (DataGridViewRow row in gridItems.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = int.Parse(row.Cells["colProductId"].Value!.ToString()!);
                    string productName = row.Cells["colProductName"].Value!.ToString()!;
                    decimal qty = decimal.Parse(row.Cells["colQty"].Value!.ToString()!);
                    decimal weight = decimal.Parse(row.Cells["colWeight"].Value!.ToString()!);
                    string weightUnit = row.Cells["colWeightUnit"].Value!.ToString()!;
                    decimal rate = decimal.Parse(row.Cells["colRate"].Value!.ToString()!);
                    decimal amount = decimal.Parse(row.Cells["colAmount"].Value!.ToString()!);

                    // a. Insert line item
                    using (var cmd = new SqliteCommand(@"
                INSERT INTO purchase_invoice_items
                    (purchase_id, voucher_no, product_id, product_name,
                     quantity, weight, weight_unit, rate, amount)
                VALUES (@pid2,@v,@pid,@pn,@qty,@wt,@wu,@rate,@amt)", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@pid2", purchaseId);
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.Parameters.AddWithValue("@pn", productName);
                        cmd.Parameters.AddWithValue("@qty", (double)qty);
                        cmd.Parameters.AddWithValue("@wt", (double)weight);
                        cmd.Parameters.AddWithValue("@wu", weightUnit);
                        cmd.Parameters.AddWithValue("@rate", (double)rate);
                        cmd.Parameters.AddWithValue("@amt", (double)amount);
                        cmd.ExecuteNonQuery();
                    }

                    // b. Increase stock (purchases add stock)
                    using (var cmd = new SqliteCommand(@"
                UPDATE products
                SET current_qty    = current_qty    + @qty,
                    current_weight = current_weight + @wt
                WHERE product_id = @pid", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@qty", (double)qty);
                        cmd.Parameters.AddWithValue("@wt", (double)weight);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.ExecuteNonQuery();
                    }

                    // c. Get updated stock for movement record
                    double balQty = 0, balWt = 0;
                    using (var cmd = new SqliteCommand(
                        "SELECT current_qty, current_weight FROM products WHERE product_id=@pid", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@pid", productId);
                        using var r = cmd.ExecuteReader();
                        if (r.Read()) { balQty = r.GetDouble(0); balWt = r.GetDouble(1); }
                    }

                    // d. Record stock movement
                    using (var cmd = new SqliteCommand(@"
                INSERT INTO stock_movements
                    (movement_date, movement_type, voucher_type, voucher_no,
                     product_id, product_name, qty_in, weight_in, rate, amount,
                     balance_qty, balance_weight)
                VALUES (@dt,'Purchase','Purchase Invoice',@v,@pid,@pn,@qi,@wi,@rate,@amt,@bq,@bw)", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@dt", date);
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.Parameters.AddWithValue("@pn", productName);
                        cmd.Parameters.AddWithValue("@qi", (double)qty);
                        cmd.Parameters.AddWithValue("@wi", (double)weight);
                        cmd.Parameters.AddWithValue("@rate", (double)rate);
                        cmd.Parameters.AddWithValue("@amt", (double)amount);
                        cmd.Parameters.AddWithValue("@bq", balQty);
                        cmd.Parameters.AddWithValue("@bw", balWt);
                        cmd.ExecuteNonQuery();
                    }

                    // e. Build description summary
                    if (qty > 0)
                    {
                        if (itemSummary.Length > 0) itemSummary.Append(", ");
                        itemSummary.Append($"{productName} ({qty:N3} x {rate:N2})");
                    }
                    else if (weight > 0)
                    {
                        if (itemSummary.Length > 0) itemSummary.Append(", ");
                        itemSummary.Append($"{productName} ({weight:N3} {weightUnit} x {rate:N2})");
                    }
                }

                // 4. Accounting entry — Credit supplier/cash, Debit purchases
                int creditAccountId = payMode == "Cash" ? 10001 : accountId;
                string creditAccName = payMode == "Cash" ? "Cash In Hand" : accountName;

                string finalDescription = $"Purchase Inv #{voucherNo}";
                if (!string.IsNullOrWhiteSpace(desc))
                    finalDescription += $" - {desc}";
                if (itemSummary.Length > 0)
                    finalDescription += $" [{itemSummary}]";

                using (var cmd = new SqliteCommand(@"
            INSERT INTO transactions
                (transaction_type, voucher_no, account_id, account_name,
                 description, debit, credit, transaction_date)
            VALUES ('Purchase Invoice',@v,@aid,@an,@d,0,@net,@dt)", conn, txn))
                {
                    cmd.Parameters.AddWithValue("@v", voucherNo);
                    cmd.Parameters.AddWithValue("@aid", creditAccountId);
                    cmd.Parameters.AddWithValue("@an", creditAccName);
                    cmd.Parameters.AddWithValue("@d", finalDescription);
                    cmd.Parameters.AddWithValue("@net", (double)net);
                    cmd.Parameters.AddWithValue("@dt", date);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqliteCommand(
                    "UPDATE accounts SET current_balance = current_balance - @a WHERE account_id = @id",
                    conn, txn))
                {
                    cmd.Parameters.AddWithValue("@a", (double)net);
                    cmd.Parameters.AddWithValue("@id", creditAccountId);
                    cmd.ExecuteNonQuery();
                }

                txn.Commit();

                string mode = _editingVoucherNo.HasValue ? "updated" : "posted";
                MessageBox.Show($"Purchase Invoice #{voucherNo} {mode} successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset to new-entry mode
                _editingVoucherNo = null;
                txtVoucherNo.ReadOnly = false;
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            gridItems.Rows.Clear();
            txtDescription.Clear();
            numDiscount.Value = 0;
            numTotal.Value = 0;
            numNetAmount.Value = 0;
            comboPartyName.SelectedIndex = -1;
            comboPartyId.SelectedIndex = -1;
            comboPaymentMode.SelectedItem = "Credit";
            ShowVoucherNo();
            LoadProducts();
            comboPartyName.Focus();
        }

        private void comboPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyName.SelectedIndex >= 0)
                comboPartyId.SelectedIndex = comboPartyName.SelectedIndex;
        }

        private void comboPartyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPartyId.SelectedIndex >= 0)
                comboPartyName.SelectedIndex = comboPartyId.SelectedIndex;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close? Unsaved data will be lost.", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }
    }
}