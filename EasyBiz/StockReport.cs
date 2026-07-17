using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing; // BUG FIX: Color/Font/Padding/FontStyle live here — was missing, file would not compile
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class StockReport : Form
    {
        public StockReport()
        {
            InitializeComponent();
            EnsurePartyColumn(); // FEATURE: adds "Party" column to gridMovements at runtime
            LoadStockSummary();
            LoadProducts();
            LoadParties(); // FEATURE: populate party/customer filter dropdown
            LoadMovementTypes(); // FEATURE: populate Sale/Purchase/Both filter dropdown
            LoadPaymentTypes(); // FEATURE: populate Cash/Credit/Both filter dropdown
            BeautifyGrid(gridStock, Color.FromArgb(52, 152, 219));
            BeautifyGrid(gridMovements, Color.FromArgb(39, 174, 96));
            setupDates();
            ThemeManager.ApplyTheme(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData) 
            {
                case Keys.Enter:
                    SelectNextControl(ActiveControl, true, true, true, true);
                    return true;

                case Keys.F1:
                    BtnExportMovements_Click(null, null);
                    return true;

                case Keys.F2:
                    BtnExportSummary_Click(null, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void setupDates()
        {
            if (checkAllDates.Checked != true)
            {
                dateFrom.Value = DateTime.Now;
                dateTo.Value = DateTime.Now;
            }
            else
            {
                dateFrom.Value = new DateTime(2000, 01, 01);
                dateTo.Value = new DateTime(2100, 01, 01);
            }
        }

        private void EnsurePartyColumn()
        {
            if (gridMovements.Columns.Contains("smParty")) return;

            var col = new DataGridViewTextBoxColumn
            {
                Name = "smParty",
                HeaderText = "Party",
                DataPropertyName = "",
                FillWeight = 100
            };
            gridMovements.Columns.Add(col);
        }

        private static decimal SafeDecimal(SqliteDataReader r, int i)
        {
            if (r.IsDBNull(i)) return 0m;
            return Convert.ToDecimal(r.GetValue(i));
        }

        private static double SafeDouble(SqliteDataReader r, int i)
        {
            if (r.IsDBNull(i)) return 0.0;
            return Convert.ToDouble(r.GetValue(i));
        }

        private static string SafeString(SqliteDataReader r, int i)
        {
            return r.IsDBNull(i) ? string.Empty : r.GetString(i);
        }

        private void BeautifyGrid(DataGridView grid, Color headerColor)
        {
            grid.BorderStyle = BorderStyle.Fixed3D;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToOrderColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.StandardTab = true;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            grid.GridColor = Color.FromArgb(230, 232, 235);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 44;
            grid.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Regular);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 48);
            grid.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);

            grid.RowTemplate.Height = 38;

            grid.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    e.CellStyle.SelectionBackColor = grid.DefaultCellStyle.SelectionBackColor;
            };
        }


        // ── Tab 1: Current Stock Summary ─────────────────────────────────────
        private void LoadStockSummary()
        {
            gridStock.Rows.Clear();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT product_id, product_name, unit, weight_unit,
                       current_qty, current_weight, min_stock_qty,
                       sale_rate, purchase_rate, isUnit
                FROM products
                ORDER BY product_name";

            using var r = cmd.ExecuteReader();
            int sno = 1;
            while (r.Read())
            {
                decimal qty = SafeDecimal(r, 4);
                decimal minQty = SafeDecimal(r, 6);
                decimal weight = SafeDecimal(r, 5);
                decimal saleRate = SafeDecimal(r, 7);
                decimal purRate = SafeDecimal(r, 8);
                bool lowStock = qty <= minQty && minQty > 0;
                int isUnit = r.GetInt16(9);

                int rowIdx = gridStock.Rows.Add();
                var row = gridStock.Rows[rowIdx];
                row.Cells["csNo"].Value = sno++;
                row.Cells["csId"].Value = r.GetInt32(0);
                row.Cells["csProduct"].Value = SafeString(r, 1);
                if (isUnit == 1)
                {
                    row.Cells["csUnit"].Value = SafeString(r, 2);
                } else { row.Cells["csUnit"].Value = "-"; }
                if (isUnit == 1)
                {
                    row.Cells["csQty"].Value = qty.ToString("N3");
                } else { row.Cells["csQty"].Value = "-"; }
                if (isUnit == 1)
                {
                    row.Cells["csWeight"].Value = "-";
                } else { row.Cells["csWeight"].Value = weight.ToString("N3"); }
                
                if (isUnit == 1)
                {
                    row.Cells["csWeightUnit"].Value = "-";
                }
                else { row.Cells["csWeightUnit"].Value = SafeString(r, 3); }
                
                row.Cells["csMinQty"].Value = minQty.ToString("N3");
                row.Cells["csSaleRate"].Value = saleRate.ToString("N2");
                row.Cells["csPurRate"].Value = purRate.ToString("N2");
                row.Cells["csValue"].Value = (qty * saleRate).ToString("N2");

                if (lowStock)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        // ── Tab 2: Stock Movement Ledger ─────────────────────────────────────
        private void LoadProducts()
        {
            comboProductFilter.Items.Clear();
            comboProductFilter.Items.Add("-- All Products --");
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT product_id, product_name FROM products ORDER BY product_name";
            using var r = cmd.ExecuteReader();
            while (r.Read())
                comboProductFilter.Items.Add($"{r.GetInt32(0)} - {SafeString(r, 1)}");
            comboProductFilter.SelectedIndex = 0;
        }

        private void LoadParties()
        {
            comboPartyFilter.Items.Clear();
            comboPartyFilter.Items.Add("-- All Parties --");
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT account_id, account_name FROM accounts ORDER BY account_name";
            using var r = cmd.ExecuteReader();
            while (r.Read())
                comboPartyFilter.Items.Add($"{r.GetInt32(0)} - {SafeString(r, 1)}");
            comboPartyFilter.SelectedIndex = 0;
        }

        private void LoadMovementTypes()
        {
            comboMovementType.Items.Clear();
            comboMovementType.Items.Add("-- Both --");
            comboMovementType.Items.Add("Sale");
            comboMovementType.Items.Add("Purchase");
            comboMovementType.SelectedIndex = 0;
        }

        // FEATURE: populate the Cash / Credit / Both payment-type filter dropdown.
        // NOTE: requires a ComboBox named "comboPaymentFilter" added to the form in the
        // designer (drop it next to comboMovementType). "Cash" means the linked account's
        // accounts.account_type = 'Cash'; "Credit" means every other account_type (or no
        // linked account at all). See LoadMovements()/BuildMovementRows() for the join.
        private void LoadPaymentTypes()
        {
            comboPaymentFilter.Items.Clear();
            comboPaymentFilter.Items.Add("-- Cash/Credit --");
            comboPaymentFilter.Items.Add("Cash");
            comboPaymentFilter.Items.Add("Credit");
            comboPaymentFilter.SelectedIndex = 0;
        }

        private string GetSelectedMovementType()
        {
            if (comboMovementType.SelectedIndex <= 0) return "";
            return comboMovementType.SelectedItem!.ToString()!;
        }

        // FEATURE: parses the payment-type combo selection into "Cash" / "Credit",
        // or "" for "-- Cash/Credit --" (no filter).
        private string GetSelectedPaymentType()
        {
            if (comboPaymentFilter.SelectedIndex <= 0) return "";
            return comboPaymentFilter.SelectedItem!.ToString()!;
        }

        private int GetSelectedPartyId()
        {
            if (comboPartyFilter.SelectedIndex <= 0) return 0;
            string sel = comboPartyFilter.SelectedItem!.ToString()!;
            return int.Parse(sel.Split('-')[0].Trim());
        }

        // FEATURE: builds the SQL fragment for the Cash/Credit filter based on
        // accounts.account_type of the linked account ("acc" alias — see JOIN in the
        // callers). Cash = account_type = 'Cash'. Credit = anything else, INCLUDING
        // movements with no linked account at all (acc.account_type IS NULL).
        private static string BuildPaymentTypeFilter(string paymentType)
        {
            if (paymentType == "Cash") return " AND acc.account_type = 'Cash'";
            if (paymentType == "Credit") return " AND COALESCE(acc.account_type, '') <> 'Cash'";
            return "";
        }

        private void LoadMovements()
        {
            gridMovements.Rows.Clear();

            string productFilter = "";
            int productId = 0;
            if (comboProductFilter.SelectedIndex > 0)
            {
                string sel = comboProductFilter.SelectedItem!.ToString()!;
                productId = int.Parse(sel.Split('-')[0].Trim());
                productFilter = " AND sm.product_id = @pid";
            }

            int partyId = GetSelectedPartyId();
            string partyFilter = partyId > 0 ? " AND COALESCE(si.account_id, pi.account_id) = @partyId" : "";

            string moveType = GetSelectedMovementType();
            string moveTypeFilter = moveType != "" ? " AND sm.movement_type = @moveType" : "";

            // FEATURE: Cash/Credit filter, resolved via accounts.account_type (see acc JOIN below)
            string paymentType = GetSelectedPaymentType();
            string paymentTypeFilter = BuildPaymentTypeFilter(paymentType);

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT sm.movement_date, sm.movement_type, sm.voucher_type,
                       sm.voucher_no, sm.product_name, sm.qty_in, sm.qty_out,
                       sm.weight_in, sm.weight_out, sm.rate, sm.amount,
                       sm.balance_qty, sm.balance_weight,
                       COALESCE(si.account_name, pi.account_name) AS party_name
                FROM stock_movements sm
                LEFT JOIN sale_invoices si
                    ON sm.voucher_type = 'Sale Invoice' AND sm.voucher_no = si.voucher_no
                LEFT JOIN purchase_invoices pi
                    ON sm.voucher_type = 'Purchase Invoice' AND sm.voucher_no = pi.voucher_no
                LEFT JOIN accounts acc
                    ON acc.account_id = COALESCE(si.account_id, pi.account_id)
                WHERE date(sm.movement_date) BETWEEN date(@from) AND date(@to)
                {productFilter}
                {partyFilter}
                {moveTypeFilter}
                {paymentTypeFilter}
                ORDER BY sm.movement_date, sm.movement_id";

            cmd.Parameters.AddWithValue("@from", dateFrom.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@to", dateTo.Value.ToString("yyyy-MM-dd"));
            if (productId > 0) cmd.Parameters.AddWithValue("@pid", productId);
            if (partyId > 0) cmd.Parameters.AddWithValue("@partyId", partyId);
            if (moveType != "") cmd.Parameters.AddWithValue("@moveType", moveType);

            using var r = cmd.ExecuteReader();
            int sno = 1;
            while (r.Read())
            {
                double qtyIn = SafeDouble(r, 5);
                double qtyOut = SafeDouble(r, 6);
                double wtIn = SafeDouble(r, 7);
                double wtOut = SafeDouble(r, 8);
                double rate = SafeDouble(r, 9);
                double amount = SafeDouble(r, 10);
                double balQty = SafeDouble(r, 11);
                double balWt = SafeDouble(r, 12);

                int rowIdx = gridMovements.Rows.Add();
                var row = gridMovements.Rows[rowIdx];
                row.Cells["smNo"].Value = sno++;
                row.Cells["smDate"].Value = SafeString(r, 0);
                row.Cells["smVoucher"].Value = $"{SafeString(r, 2)} #{r.GetInt32(3)}";
                row.Cells["smProduct"].Value = SafeString(r, 4);
                row.Cells["smQtyIn"].Value = qtyIn > 0 ? qtyIn.ToString("N3") : "-";
                row.Cells["smQtyOut"].Value = qtyOut > 0 ? qtyOut.ToString("N3") : "-";
                row.Cells["smWtIn"].Value = wtIn > 0 ? wtIn.ToString("N3") : "-";
                row.Cells["smWtOut"].Value = wtOut > 0 ? wtOut.ToString("N3") : "-";
                row.Cells["smRate"].Value = rate.ToString("N2");
                row.Cells["smAmount"].Value = amount.ToString("N2");
                row.Cells["smBalQty"].Value = balQty.ToString("N3");
                row.Cells["smBalWt"].Value = balWt.ToString("N3");
                string party = SafeString(r, 13);
                row.Cells["smParty"].Value = string.IsNullOrEmpty(party) ? "-" : party;
            }
        }

        // ── PDF export helpers ────────────────────────────────────────────────

        private List<StockSummaryRow> BuildSummaryRows()
        {
            var rows = new List<StockSummaryRow>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT product_id, product_name, unit, weight_unit,
                       current_qty, current_weight, min_stock_qty,
                       sale_rate, purchase_rate
                FROM products
                ORDER BY product_name";

            using var r = cmd.ExecuteReader();
            int sno = 1;
            while (r.Read())
            {
                decimal qty = SafeDecimal(r, 4);
                decimal sale = SafeDecimal(r, 7);
                rows.Add(new StockSummaryRow
                {
                    SrNo = sno++,
                    ProductId = r.GetInt32(0),
                    ProductName = SafeString(r, 1),
                    Unit = SafeString(r, 2),
                    WeightUnit = SafeString(r, 3),
                    CurrentQty = qty,
                    CurrentWeight = SafeDecimal(r, 5),
                    MinStockQty = SafeDecimal(r, 6),
                    SaleRate = sale,
                    PurchaseRate = SafeDecimal(r, 8),
                    StockValue = qty * sale
                });
            }
            return rows;
        }

        /// <summary>Reads stock_movements for the selected period/product/party/type/payment.</summary>
        private List<StockMovementRow> BuildMovementRows()
        {
            var rows = new List<StockMovementRow>();

            string productFilter = "";
            int productId = 0;
            if (comboProductFilter.SelectedIndex > 0)
            {
                string sel = comboProductFilter.SelectedItem!.ToString()!;
                productId = int.Parse(sel.Split('-')[0].Trim());
                productFilter = " AND sm.product_id = @pid";
            }

            int partyId = GetSelectedPartyId();
            string partyFilter = partyId > 0 ? " AND COALESCE(si.account_id, pi.account_id) = @partyId" : "";

            string moveType = GetSelectedMovementType();
            string moveTypeFilter = moveType != "" ? " AND sm.movement_type = @moveType" : "";

            // FEATURE: Cash/Credit filter, resolved via accounts.account_type (see acc JOIN below) — mirrors LoadMovements()
            string paymentType = GetSelectedPaymentType();
            string paymentTypeFilter = BuildPaymentTypeFilter(paymentType);

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT sm.movement_date, sm.movement_type, sm.voucher_type,
                       sm.voucher_no, sm.product_name, sm.qty_in, sm.qty_out,
                       sm.weight_in, sm.weight_out, sm.rate, sm.amount,
                       sm.balance_qty, sm.balance_weight,
                       COALESCE(si.account_name, pi.account_name) AS party_name
                FROM stock_movements sm
                LEFT JOIN sale_invoices si
                    ON sm.voucher_type = 'Sale Invoice' AND sm.voucher_no = si.voucher_no
                LEFT JOIN purchase_invoices pi
                    ON sm.voucher_type = 'Purchase Invoice' AND sm.voucher_no = pi.voucher_no
                LEFT JOIN accounts acc
                    ON acc.account_id = COALESCE(si.account_id, pi.account_id)
                WHERE date(sm.movement_date) BETWEEN date(@from) AND date(@to)
                {productFilter}
                {partyFilter}
                {moveTypeFilter}
                {paymentTypeFilter}
                ORDER BY sm.movement_date, sm.movement_id";

            cmd.Parameters.AddWithValue("@from", dateFrom.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@to", dateTo.Value.ToString("yyyy-MM-dd"));
            if (productId > 0) cmd.Parameters.AddWithValue("@pid", productId);
            if (partyId > 0) cmd.Parameters.AddWithValue("@partyId", partyId);
            if (moveType != "") cmd.Parameters.AddWithValue("@moveType", moveType);

            using var r = cmd.ExecuteReader();
            int sno = 1;
            while (r.Read())
            {
                rows.Add(new StockMovementRow
                {
                    SrNo = sno++,
                    Date = SafeString(r, 0),
                    MovementType = SafeString(r, 1),
                    VoucherRef = $"{SafeString(r, 2)} #{r.GetInt32(3)}",
                    ProductName = SafeString(r, 4),
                    QtyIn = SafeDecimal(r, 5),
                    QtyOut = SafeDecimal(r, 6),
                    WeightIn = SafeDecimal(r, 7),
                    WeightOut = SafeDecimal(r, 8),
                    Rate = SafeDecimal(r, 9),
                    Amount = SafeDecimal(r, 10),
                    BalanceQty = SafeDecimal(r, 11),
                    BalanceWeight = SafeDecimal(r, 12),
                    PartyName = SafeString(r, 13)
                });
            }
            return rows;
        }

        // ── Button handlers ───────────────────────────────────────────────────

        private void BtnLoadMovements_Click(object sender, EventArgs e)
        {
            LoadStockSummary();
            LoadMovements();
        }

        private void BtnExportSummary_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Stock Summary Report",
                FileName = $"StockSummary_{DateTime.Today:ddMMMyyyy}.pdf"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var rows = BuildSummaryRows();
                StockReportPDF.GenerateSummary(
                    outputPath: dlg.FileName,
                    companyName: "EasyBiz",
                    asOfDate: DateTime.Today,
                    rows: rows);

                var open = MessageBox.Show(
                    $"Stock summary exported successfully!\n\n{dlg.FileName}\n\nOpen the file now?",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (open == DialogResult.Yes)
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(dlg.FileName)
                        { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportMovements_Click(object sender, EventArgs e)
        {
            string productLabel = comboProductFilter.SelectedIndex > 0
                ? comboProductFilter.SelectedItem!.ToString()!.Split('-', 2)[1].Trim()
                : "";

            string moveTypeLabel = GetSelectedMovementType();

            // FEATURE: resolve payment type first, since it can override the Party label below
            string paymentTypeLabel = GetSelectedPaymentType();

            // FEATURE: when filtering to Cash movements, show "Party: Cash" in the PDF header
            // instead of the actual party dropdown selection — "Cash" here describes who the
            // movement is against, so it belongs in the Party slot, not a separate Payment field.
            string partyLabel;
            if (paymentTypeLabel == "Cash")
            {
                partyLabel = "Cash";
            }
            else
            {
                partyLabel = comboPartyFilter.SelectedIndex > 0
                    ? comboPartyFilter.SelectedItem!.ToString()!.Split('-', 2)[1].Trim()
                    : "";
            }

            using var dlg = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Stock Movement Report",
                FileName = $"StockMovements_{dateFrom.Value:ddMMMyyyy}_to_{dateTo.Value:ddMMMyyyy}.pdf"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var rows = BuildMovementRows();
                StockReportPDF.GenerateMovements(
                    outputPath: dlg.FileName,
                    companyName: "EasyBiz",
                    productFilter: productLabel,
                    partyFilter: partyLabel,
                    movementTypeFilter: moveTypeLabel,                    
                    fromDate: dateFrom.Value.Date,
                    toDate: dateTo.Value.Date,
                    rows: rows);

                var open = MessageBox.Show(
                    $"Stock movements exported successfully!\n\n{dlg.FileName}\n\nOpen the file now?",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (open == DialogResult.Yes)
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(dlg.FileName)
                        { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkAllDates_CheckedChanged(object sender, EventArgs e) => setupDates();        
        private void comboPaymentFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadMovements();        
        private void comboMovementType_SelectedIndexChanged(object sender, EventArgs e) => LoadMovements();        
        private void comboProductFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadMovements();
        private void comboPartyFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadMovements();
        
    }
}