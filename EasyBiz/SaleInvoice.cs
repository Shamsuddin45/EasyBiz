using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyBiz
{
    public partial class SaleInvoice : Form
    {
        private int? _editingVoucherNo = null;

        public SaleInvoice()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadAccounts();
            LoadProducts();
            ShowVoucherNo();
            BeautifyGrid();
            comboPartyName.SelectedItem = "Cash In Hand";            
            txtDescription.Select();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    // focus to the next control                
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
            gridItems.BackgroundColor = Color.White;
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

            gridItems.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            gridItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gridItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Rows
            gridItems.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            gridItems.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            gridItems.DefaultCellStyle.SelectionForeColor = Color.Black;
            gridItems.DefaultCellStyle.BackColor = Color.White;
            gridItems.DefaultCellStyle.ForeColor = Color.Black;            

            // Alternate Row Color
            gridItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Grid Lines
            gridItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridItems.GridColor = Color.Gainsboro;

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
                DataGridViewContentAlignment.MiddleLeft;

            gridItems.Columns["colWeight"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            gridItems.Columns["colRate"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            gridItems.Columns["colAmount"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Currency Format
            gridItems.Columns["colRate"].DefaultCellStyle.Format = "N2";
            gridItems.Columns["colAmount"].DefaultCellStyle.Format = "N2";
        }


        // ── 1. Verify voucher exists ─────────────────────────────────────────────────
        private bool CheckIfSaleVoucherExists(int voucherNo)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COUNT(*) FROM sale_invoices WHERE voucher_no = @v", conn);
            cmd.Parameters.AddWithValue("@v", voucherNo);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
                MessageBox.Show(
                    $"Sale Invoice #{voucherNo} does not exist.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return count > 0;

        }


        // ── Voucher Number ───────────────────────────────────────────────────
        private void ShowVoucherNo()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COALESCE(MAX(voucher_no), 0) + 1 FROM sale_invoices", conn);
            txtVoucherNo.Text = cmd.ExecuteScalar()!.ToString();
            lblHeader.Text = $"Sale Invoice # {txtVoucherNo.Text}" + (_editingVoucherNo.HasValue ? " (Edit Mode)" : "");
        }

        // ── Load Combos ──────────────────────────────────────────────────────
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
            cmd.CommandText = "SELECT product_id, product_name, sale_rate, current_qty, current_weight, unit, weight_unit, isUnit FROM products ORDER BY product_name";
            using var r = cmd.ExecuteReader();
            comboProduct.Items.Clear();
            comboProduct.Tag = new System.Collections.Generic.List<object[]>(); // store product data
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
        public void LoadTransactionForEditing(int voucherNo)
        {
            if (!CheckIfSaleVoucherExists(voucherNo))
                return;

            _editingVoucherNo = voucherNo;
            txtVoucherNo.Text = voucherNo.ToString();
            txtVoucherNo.ReadOnly = true;                      // lock while editing
            lblHeader.Text = $"Sale Invoice # {voucherNo} (Edit Mode)";

            // ── Load header ──────────────────────────────────────────────────────────
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT account_id, account_name, invoice_date,
                   description, discount
            FROM   sale_invoices
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
            FROM   sale_invoice_items
            WHERE  voucher_no = @v";
                cmd.Parameters.AddWithValue("@v", voucherNo);

                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int rowIndex = gridItems.Rows.Add();
                    var row = gridItems.Rows[rowIndex];

                    row.Cells["colProductId"].Value = r.GetInt32(0).ToString();
                    row.Cells["colProductName"].Value = r.GetString(1);
                    row.Cells["colQty"].Value = r.GetDouble(2).ToString("N3");
                    row.Cells["colWeight"].Value = r.GetDouble(3).ToString("N3");
                    row.Cells["colWeightUnit"].Value = r.IsDBNull(4) ? "" : r.GetString(4);

                    // Populate colUnit from the products table so it is consistent
                    string unit = "";
                    using (var conn2 = DatabaseHelper.GetConnection())
                    using (var cmd2 = new SqliteCommand(
                        "SELECT unit FROM products WHERE product_id = @pid", conn2))
                    {
                        cmd2.Parameters.AddWithValue("@pid", r.GetInt32(0));
                        var res = cmd2.ExecuteScalar();
                        if (res != null) unit = res.ToString()!;
                    }
                    row.Cells["colUnit"].Value = unit;
                    row.Cells["colRate"].Value = r.GetDouble(5).ToString("N2");
                    row.Cells["colAmount"].Value = r.GetDouble(6).ToString("N2");
                }
            }

            RecalcTotal();

            // Reset item-input section (leave combos blank, ready for extra lines)
            comboProduct.SelectedIndex = -1;
            txtQty.Text = "0";
            txtWeight.Text = "0";
            txtRate.Text = "0";
            lblStockQty.Text = "Qty: -";
            lblStockWt.Text = "Weight: -";
        }

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

        // ── Product Selection — auto-fill rate & show stock ──────────────────
        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProduct.SelectedIndex < 0)
                return;

            if (comboProduct.Tag is not List<object[]> list)
                return;

            if (comboProduct.SelectedIndex >= list.Count)
                return;

            var prod = list[comboProduct.SelectedIndex];

            txtRate.Text = Convert.ToDecimal(prod[2]).ToString("N2");

            lblStockQty.Text =
                $"Qty: {Convert.ToDouble(prod[3]):N2} {prod[5]}";

            lblStockWt.Text =
                $"Weight: {Convert.ToDouble(prod[4]):N3} {prod[6]}";

            bool isUnit = Convert.ToInt32(prod[7]) == 1;

            txtQty.Enabled = isUnit;
            txtWeight.Enabled = !isUnit;

            if (isUnit)
            {
                txtWeight.Text = "0";
                txtQty.Focus();
            }
            else
            {
                txtQty.Text = "0";
                txtWeight.Focus();
            }
        }

        // ── Add Item Row ─────────────────────────────────────────────────────
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (comboProduct.SelectedIndex < 0)
            { MessageBox.Show("Select a product."); return; }
            if (txtQty.Text == "0" && txtWeight.Text == "0")
            { MessageBox.Show("Enter quantity or weight."); return; }
            if (txtRate.Text == "0")
            { MessageBox.Show("Rate cannot be zero."); return; }
            if (txtAmount.Text == "0")
            { MessageBox.Show("Amount cannot be zero."); return; }

            var list = (System.Collections.Generic.List<object[]>)comboProduct.Tag;
            var prod = list[comboProduct.SelectedIndex];

            decimal qty = decimal.TryParse(txtQty.Text, out var q) ? q : 0;
            decimal weight = decimal.TryParse(txtWeight.Text, out var w) ? w : 0;
            decimal rate = decimal.TryParse(txtRate.Text, out var r) ? r : 0;
            decimal amount = decimal.TryParse(txtAmount.Text, out var a) ? a : 0;

            int rowIndex = gridItems.Rows.Add();
            var row = gridItems.Rows[rowIndex];
            row.Cells["colProductId"].Value = prod[0].ToString();
            row.Cells["colProductName"].Value = prod[1].ToString();
            row.Cells["colUnit"].Value = prod[5].ToString();
            row.Cells["colQty"].Value = qty;
            row.Cells["colWeight"].Value = weight;
            row.Cells["colWeightUnit"].Value = prod[6].ToString();
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

        // ── Delete selected row ───────────────────────────────────────────────
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (gridItems.SelectedRows.Count > 0 && !gridItems.SelectedRows[0].IsNewRow)
            {
                gridItems.Rows.RemoveAt(gridItems.SelectedRows[0].Index);
                RecalcTotal();
            }
        }

        // ── POST SALE ────────────────────────────────────────────────────────
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (comboPartyId.SelectedIndex < 0)
            { MessageBox.Show("Select a party account."); return; }
            if (gridItems.Rows.Count == 0)
            { MessageBox.Show("Add at least one item."); return; }

            var confirm = MessageBox.Show("Post this Sale Invoice?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            PostSaleInvoice();
        }

        private void PostSaleInvoice()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var txn = conn.BeginTransaction();

                string date = dateInvoice.Value.ToString("yyyy-MM-dd");
                int accountId = int.TryParse(comboPartyId.SelectedItem!.ToString()!, out var accId) ? accId : 0;
                string accountName = comboPartyName.SelectedItem!.ToString()!;
                // ── REMOVED payMode VARIABLE HERE ──
                decimal total = decimal.TryParse(txtTotal.Text, out var t) ? t : 0;
                decimal discount = decimal.TryParse(txtDiscount.Text, out var d) ? d : 0;
                decimal net = decimal.TryParse(txtNetAmount.Text, out var n) ? n : 0;
                string desc = txtDescription.Text.Trim();

                int voucherNo;

                // ════════════════════════════════════════════════════════════════════
                //  EDIT MODE — reverse everything that was posted, then re-insert
                // ════════════════════════════════════════════════════════════════════
                if (_editingVoucherNo.HasValue)
                {
                    voucherNo = _editingVoucherNo.Value;

                    // 1a. Restore stock quantities from the old line items
                    using (var cmd = new SqliteCommand(@"
        SELECT product_id, quantity, weight
        FROM   sale_invoice_items
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
                SET current_qty    = current_qty    + @qty,
                    current_weight = current_weight + @wt
                WHERE product_id = @pid", conn, txn);
                            upd.Parameters.AddWithValue("@qty", qty);
                            upd.Parameters.AddWithValue("@wt", wt);
                            upd.Parameters.AddWithValue("@pid", pid);
                            upd.ExecuteNonQuery();
                        }
                    }

                    // 1b. Reverse the old financial transaction (find old net & debit account)
                    using (var cmd = new SqliteCommand(@"
        SELECT account_id, debit
        FROM   transactions
        WHERE  voucher_no        = @v
          AND  transaction_type  = 'Sale Invoice'", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        using var r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            int oldAccId = r.GetInt32(0);
                            decimal oldDebit = r.GetDecimal(1);

                            using var upd = new SqliteCommand(
                                "UPDATE accounts SET current_balance = current_balance - @a WHERE account_id = @id",
                                conn, txn);
                            upd.Parameters.AddWithValue("@a", (double)oldDebit);
                            upd.Parameters.AddWithValue("@id", oldAccId);
                            upd.ExecuteNonQuery();
                        }
                    }

                    // 1c. Delete old records
                    foreach (string tbl in new[] {
        "stock_movements",
        "sale_invoice_items",
        "transactions" })
                    {

                        using var cmd = new SqliteCommand(
                            tbl == "transactions"
                                ? "DELETE FROM transactions WHERE voucher_no = @v AND transaction_type = 'Sale Invoice'"
                                : $"DELETE FROM {tbl} WHERE voucher_no = @v",
                            conn, txn);
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.ExecuteNonQuery();
                    }

                    // 1d. Delete and re-insert the header
                    using (var cmd = new SqliteCommand(
                        "DELETE FROM sale_invoices WHERE voucher_no = @v", conn, txn))
                    {
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
                        "SELECT COALESCE(MAX(voucher_no),0)+1 FROM sale_invoices", conn, txn);
                    voucherNo = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // ════════════════════════════════════════════════════════════════════
                //  INSERT — shared by both new and edit
                // ════════════════════════════════════════════════════════════════════

                // 2. Insert sale header
                long saleId;
                using (var cmd = new SqliteCommand(@"
    INSERT INTO sale_invoices
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
                    saleId = (long)cmd.ExecuteScalar()!;
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
                    if (amount <= 0)
                    {
                        MessageBox.Show($"Line item '{productName}' has zero amount. Skipping this item.");
                        continue; // skip zero-amount items
                    }
                    // a. Insert line item
                    using (var cmd = new SqliteCommand(@"
        INSERT INTO sale_invoice_items
            (sale_id, voucher_no, product_id, product_name,
             quantity, weight, weight_unit, rate, amount)
        VALUES (@sid,@v,@pid,@pn,@qty,@wt,@wu,@rate,@amt)", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@sid", saleId);
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

                    // b. Reduce stock
                    using (var cmd = new SqliteCommand(@"
        UPDATE products
        SET current_qty    = current_qty    - @qty,
            current_weight = current_weight - @wt
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
             product_id, product_name, qty_out, weight_out, rate, amount,
             balance_qty, balance_weight)
        VALUES (@dt,'Sale','Sale Invoice',@v,@pid,@pn,@qo,@wo,@rate,@amt,@bq,@bw)", conn, txn))
                    {
                        cmd.Parameters.AddWithValue("@dt", date);
                        cmd.Parameters.AddWithValue("@v", voucherNo);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.Parameters.AddWithValue("@pn", productName);
                        cmd.Parameters.AddWithValue("@qo", (double)qty);
                        cmd.Parameters.AddWithValue("@wo", (double)weight);
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
                        { itemSummary.Append($"{productName} ({qty:N3} x {rate:N2}) discount: {discount:N2}"); }
                        else { itemSummary.Append($"{productName} ({qty:N3} x {rate:N2})"); }
                    }
                    else if (weight > 0)
                    {
                        if (itemSummary.Length > 0) itemSummary.Append(", ");
                        if (discount > 0)
                        { itemSummary.Append($"{productName} ({weight:N3} {weightUnit} x {rate:N2}) discount: {discount:N2}"); }
                        else { itemSummary.Append($"{productName} ({weight:N3} {weightUnit} x {rate:N2})"); }
                    }
                }

                // 4. Accounting entry
                // ── MODIFIED: Always use the selected accountId and accountName ──
                int debitAccountId = accountId;
                string debitAccName = accountName;

                string finalDescription = $"Sale Inv #{voucherNo}";
                if (!string.IsNullOrWhiteSpace(desc))
                    finalDescription += $" - {desc}";
                if (itemSummary.Length > 0)
                    finalDescription += $" [{itemSummary}]";

                using (var cmd = new SqliteCommand(@"
    INSERT INTO transactions
        (transaction_type, voucher_no, account_id, account_name,
         description, debit, credit, transaction_date)
    VALUES ('Sale Invoice',@v,@aid,@an,@d,@net,0,@dt)", conn, txn))
                {
                    cmd.Parameters.AddWithValue("@v", voucherNo);
                    cmd.Parameters.AddWithValue("@aid", debitAccountId);
                    cmd.Parameters.AddWithValue("@an", debitAccName);
                    cmd.Parameters.AddWithValue("@d", finalDescription);
                    cmd.Parameters.AddWithValue("@net", (double)net);
                    cmd.Parameters.AddWithValue("@dt", date);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqliteCommand(
                    "UPDATE accounts SET current_balance = current_balance + @a WHERE account_id = @id",
                    conn, txn))
                {
                    cmd.Parameters.AddWithValue("@a", (double)net);
                    cmd.Parameters.AddWithValue("@id", debitAccountId);
                    cmd.ExecuteNonQuery();
                }

                txn.Commit();

                string mode = _editingVoucherNo.HasValue ? "updated" : "posted";
                MessageBox.Show($"Sale Invoice #{voucherNo} {mode} successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ── NEW: offer to print a thermal receipt ───────────────────────
                if (MessageBox.Show("Print receipt now?", "Print Receipt",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // ── MODIFIED: Removed payMode parameter from BuildReceiptData ──
                    ThermalReceiptPrinter.Print(BuildReceiptData(voucherNo, accountName, net, total, discount), preview: true);
                }

                // Reset to new-entry mode
                _editingVoucherNo = null;
                txtVoucherNo.ReadOnly = false;
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error posting sale: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ReceiptData BuildReceiptData(int voucherNo, string customerName,
         decimal net, decimal total, decimal discount)
        {
            var data = new ReceiptData
            {
                ShopName = "EasyBiz",   // hardcode your shop name here, or pull from a settings row
                VoucherNo = voucherNo,
                InvoiceDate = dateInvoice.Value,
                CustomerName = customerName,                
                Total = total,
                Discount = discount,
                NetAmount = net
            };

            foreach (DataGridViewRow row in gridItems.Rows)
            {
                if (row.IsNewRow) continue;
                data.Items.Add(new ReceiptItem
                {
                    ProductName = row.Cells["colProductName"].Value?.ToString() ?? "",
                    Qty = decimal.TryParse(row.Cells["colQty"].Value?.ToString(), out var q) ? q : 0,
                    Weight = decimal.TryParse(row.Cells["colWeight"].Value?.ToString(), out var w) ? w : 0,
                    Unit = row.Cells["colUnit"].Value?.ToString() ?? "",
                    Rate = decimal.TryParse(row.Cells["colRate"].Value?.ToString(), out var rt) ? rt : 0,
                    Amount = decimal.TryParse(row.Cells["colAmount"].Value?.ToString(), out var a) ? a : 0
                });
            }
            return data;
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
            LoadProducts(); // refresh stock
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

        private void numQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAddItem_Click(sender, e);
                comboProduct.Focus();
            }
        }

        private void numWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAddItem_Click(sender, e);
                comboProduct.Focus();
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

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSave_Click(sender, e);
            }
        }

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
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            decimal amount = decimal.TryParse(txtTotal.Text, out var a) ? a : 0;
            decimal discount = decimal.TryParse(txtDiscount.Text, out var d) ? d : 0;

            txtNetAmount.Text = (amount - discount).ToString("N2");
        }

        private void SaleInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboProduct.Text != "" || comboPartyName.Text != "" || gridItems.Rows.Count != 0)
            {
                var result = MessageBox.Show("Are you sure you want to close the Sale Invoice?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void BtnAddItem_Enter(object sender, EventArgs e)
        {
            BtnAddItem_Click(sender, e);
        }
    }
}