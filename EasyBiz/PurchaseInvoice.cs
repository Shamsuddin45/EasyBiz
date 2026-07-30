using Microsoft.Data.Sqlite;
using QuestPDF.Infrastructure;
using System;
using System.Drawing.Text;
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
            comboPartyName.SelectedItem = "Cash In Hand"; // default selection
            comboPartyName.Select();
            AiPredictionHelper.AttachToButton(btnAiPredict, txtDescription, () => new PredictionContext
            {
                TransactionType = "Purchase Invoice",
                AccountId = int.TryParse(comboPartyId.Text, out var accId) ? accId : (int?)null,
                Amount = decimal.TryParse(txtAmount.Text, out var amt) ? amt : (decimal?)null,
                Date = dateInvoice.Value
            });
            ThemeManager.ApplyTheme(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (ActiveControl == txtAmount)
                    { BtnAddItem_Click(this, EventArgs.Empty); return true; }
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
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
        private void BeautifyGrid()
        {
            // General
            gridItems.BorderStyle = BorderStyle.None;
            gridItems.BackgroundColor = System.Drawing.Color.White;
            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = true;
            gridItems.AllowUserToResizeRows = false;
            gridItems.MultiSelect = false;
            gridItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridItems.RowHeadersVisible = false;
            gridItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Header Style
            gridItems.EnableHeadersVisualStyles = false;
            gridItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridItems.ColumnHeadersHeight = 40;

            gridItems.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            gridItems.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            gridItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gridItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Rows
            gridItems.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            gridItems.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            gridItems.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            gridItems.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            gridItems.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            // Alternate Row Color
            gridItems.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // Grid Lines
            gridItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridItems.GridColor = System.Drawing.Color.Gainsboro;

            // Row Height
            gridItems.RowTemplate.Height = 32;

            // Adjust Column Widths
            gridItems.Columns["colProductId"].Width = 80;
            gridItems.Columns["colQty"].Width = 80;
            gridItems.Columns["colWeight"].Width = 80;
            gridItems.Columns["colRate"].Width = 80;
            gridItems.Columns["colAmount"].Width = 120;

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
        public bool CheckIfPurchaseVoucherExists(int voucherNo)
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
            return count > 0;
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
            cmd.CommandText = "SELECT product_id, product_name, purchase_rate, current_qty, current_weight, unit, weight_unit, isUnit FROM products ORDER BY product_name";
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
                    r.GetDouble(4), r.GetString(5), r.GetString(6), r.GetInt16(7)
                });
            }
        }


        // ── 2. Load invoice into the form for editing ────────────────────────────────
        public bool LoadTransactionForEditing(int voucherNo)
        {
            if (!CheckIfPurchaseVoucherExists(voucherNo))
            {
                return false;
            }

            _editingVoucherNo = voucherNo;
            txtVoucherNo.Text = voucherNo.ToString();
            txtVoucherNo.ReadOnly = true;                      // lock while editing
            lblHeader.Text = $"Purchase Invoice # {voucherNo} (Edit Mode)";
            lblHeader.Left = (this.ClientSize.Width - lblHeader.Width) / 2;

            // ── Load header ──────────────────────────────────────────────────────────
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT account_id, account_name, invoice_date,
                   description, discount
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
                    txtDiscount.Text = r.IsDBNull(4) ? "0" : r.GetDecimal(4).ToString("N2");

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
            txtQty.Text = "0";
            txtWeight.Text = "0";
            txtRate.Text = "0";
            lblStockQty.Text = "Qty: -";
            lblStockWt.Text = "Weight: -";
            return true;
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
            if (comboProduct.Tag is not List<object[]> list) return;
            if (comboProduct.SelectedIndex >= list.Count) return;
            var prod = list[comboProduct.SelectedIndex];
            txtRate.Text = Convert.ToDecimal(prod[2]).ToString("N2");
            lblStockQty.Text = $"Qty: {(double)prod[3]:N2} {prod[5]}";
            lblStockWt.Text = $"Weight: {(double)prod[4]:N3} {prod[6]}";
            bool isUnit = Convert.ToInt32(prod[7]) == 1;

            txtQty.Enabled = isUnit;
            txtWeight.Enabled = !isUnit;

        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (comboProduct.SelectedIndex < 0) { MessageBox.Show("Select a product."); return; }
            if (txtQty.Text == "0" && txtWeight.Text == "0")
            { MessageBox.Show("Enter quantity or weight."); return; }
            if (txtRate.Text == "0") { MessageBox.Show("Enter a valid rate."); return; }
            if (txtAmount.Text == "0") { MessageBox.Show("Enter amount properly!"); return; }
            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
            { txtDiscount.Text = "0"; }

            var list = (System.Collections.Generic.List<object[]>)comboProduct.Tag;
            var prod = list[comboProduct.SelectedIndex];

            decimal qty = decimal.TryParse(txtQty.Text, out var q) ? q : 0;
            decimal weight = decimal.TryParse(txtWeight.Text, out var w) ? w : 0;
            decimal rate = decimal.TryParse(txtRate.Text, out var r) ? r : 0;
            decimal amount = decimal.TryParse(txtAmount.Text, out var a) ? a : 0; ;
            bool isUnit = Convert.ToInt32(prod[7]) == 1;

            int rowIndex = gridItems.Rows.Add();
            var row = gridItems.Rows[rowIndex];
            row.Cells["colProductId"].Value = prod[0].ToString();
            row.Cells["colProductName"].Value = prod[1].ToString();

            if (isUnit)
            {
                // Enable Unit/Qty
                row.Cells["colUnit"].ReadOnly = false;
                row.Cells["colQty"].ReadOnly = false;

                // Set Unit/Qty Values
                row.Cells["colUnit"].Value = prod[5].ToString();
                row.Cells["colQty"].Value = qty;

                // Disable Weight
                row.Cells["colWeight"].ReadOnly = true;

                // Clear Weight Values
                row.Cells["colWeightUnit"].Value = "-";
                row.Cells["colWeight"].Value = "-";
            }
            else
            {
                // Disable Unit/Qty
                row.Cells["colUnit"].ReadOnly = true;
                row.Cells["colQty"].ReadOnly = true;

                // Clear Unit/Qty Values
                row.Cells["colUnit"].Value = "-";
                row.Cells["colQty"].Value = "-";

                // Enable Weight
                row.Cells["colWeight"].ReadOnly = false;

                // Set Weight Values
                row.Cells["colWeightUnit"].Value = prod[6].ToString();
                row.Cells["colWeight"].Value = weight;
            }

            row.Cells["colRate"].Value = rate;
            row.Cells["colAmount"].Value = amount;

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
            txtTotal.Text = total.ToString("N2");
            txtNetAmount.Text = (total - decimal.Parse(txtDiscount.Text)).ToString("N2");
        }

        private void ResetItemInputs()
        {
            comboProduct.SelectedIndex = -1;
            txtQty.Text = "0";
            txtWeight.Text = "0";
            txtRate.Text = "0";
            txtAmount.Text = "0";
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
                //string payMode = comboPaymentMode.SelectedItem!.ToString()!;
                decimal total = decimal.Parse(txtTotal.Text);
                decimal discount = decimal.Parse(txtDiscount.Text);
                decimal net = decimal.Parse(txtNetAmount.Text);
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
                 total_amount, discount, net_amount)
            VALUES (@v,@dt,@aid,@an,@d,@tot,@disc,@net);
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
                        if (discount > 0)
                        { itemSummary.Append($"{productName} ({qty:N3} x {rate:N2}) discount: {discount}"); }
                        else { itemSummary.Append($"{productName} ({qty:N3} x {rate:N2})"); }
                    }
                    else if (weight > 0)
                    {
                        if (itemSummary.Length > 0) itemSummary.Append(", ");
                        if (discount > 0)
                        { itemSummary.Append($"{productName} ({weight:N3} {weightUnit} x {rate:N2}) discount: {discount}"); }
                        else { itemSummary.Append($"{productName} ({weight:N3} {weightUnit} x {rate:N2})"); }
                    }

                    // 4. Accounting entry 
                    int creditAccountId = accountId;
                    string creditAccName = accountName;

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
            txtDiscount.Text = "0";
            txtTotal.Text = "0";
            txtNetAmount.Text = "0";
            comboPartyName.SelectedIndex = -1;
            comboPartyId.SelectedIndex = -1;
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
            Close();
        }

        private void PurchaseInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboProduct.Text != "" || txtDescription.Text != "" || gridItems.Rows.Count != 0)
            {
                var result = MessageBox.Show("Are you sure you want to close the Purchase Invoice?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        public bool numberstowords = true;
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (!txtAmount.Focused)
                return;

            decimal qty = decimal.TryParse(txtQty.Text, out var q) ? q : 0;
            decimal weight = decimal.TryParse(txtWeight.Text, out var w) ? w : 0;
            decimal amount = decimal.TryParse(txtAmount.Text, out var a) ? a : 0;

            if (qty > 0)
                txtRate.Text = (amount / qty).ToString("N2");
            else if (weight > 0)
                txtRate.Text = (amount / weight).ToString("N2");

            if (long.TryParse(txtAmount.Text, out long amount1))
            {
                string amountInWords = numberstowords ? NumberConverter.ToWords(amount1) : NumberConverter.ToWordsSindhi(amount1);
                lblInWords.Text = amountInWords;
            }
            else
            {
                lblInWords.Text = "-";
            }

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtQty.Text, out decimal qty) &&
                decimal.TryParse(txtRate.Text, out decimal rate))
            {
                decimal total = qty * rate;
                txtAmount.Text = total.ToString("N2");
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtWeight.Text, out decimal weight) &&
                decimal.TryParse(txtRate.Text, out decimal rate))
            {
                decimal total = weight * rate;
                txtAmount.Text = total.ToString("N2");
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            decimal qty = decimal.TryParse(txtQty.Text, out var q) ? q : 0;
            decimal weight = decimal.TryParse(txtWeight.Text, out var w) ? w : 0;
            decimal rate = decimal.TryParse(txtRate.Text, out var r) ? r : 0;

            decimal amount = (qty > 0 ? qty : weight) * rate;
            txtAmount.Text = amount.ToString("N2");
        }

        private void BtnAddItem_Enter(object sender, EventArgs e)
        {
            BtnAddItem_Click(sender, e);
        }

        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            if (GlobalConfig.AppSettings.InWords == "Off")
            {
                lblInWords.Visible = false;
            }
            if (GlobalConfig.AppSettings.InWords == "English")
            {
                lblInWords.Visible = true;
                numberstowords = true;
            }
            if (GlobalConfig.AppSettings.InWords == "Sindhi")
            {
                lblInWords.Visible = true;
                numberstowords = false;
            }
        }
    }


}