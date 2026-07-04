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
            LoadStockSummary();
            LoadProducts();
            LoadParties(); // FEATURE: populate party/customer filter dropdown
            LoadMovementTypes(); // FEATURE: populate Sale/Purchase/Both filter dropdown
            BeautifyGrid(gridStock, Color.FromArgb(52, 152, 219));
            BeautifyGrid(gridMovements, Color.FromArgb(39, 174, 96));
            setupDates();
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

        // BUG FIX: Microsoft.Data.Sqlite's GetDouble() throws InvalidCastException when a
        // REAL-affinity column happens to be stored with INTEGER storage class (e.g. a value
        // of exactly 0, which is extremely common for qty/weight/rate columns). GetValue() +
        // Convert.ToDouble() reads the value regardless of underlying storage class.
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

        // BUG FIX: guard against NULL text columns (e.g. weight_unit) throwing on GetString()
        private static string SafeString(SqliteDataReader r, int i)
        {
            return r.IsDBNull(i) ? string.Empty : r.GetString(i);
        }

        private void BeautifyGrid(DataGridView grid, Color headerColor)
        {
            // Base grid setup
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

            // Modern flat grid lines — thin, single-direction, low-contrast
            grid.GridColor = Color.FromArgb(230, 232, 235);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Header style — flat, bold, generous height
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 44;
            grid.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Regular);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Row / cell style
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 48);
            grid.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 20, 20);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Zebra striping — subtle
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);

            grid.RowTemplate.Height = 38;

            // Remove focus rectangle on selected cell for a cleaner look
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
                       sale_rate, purchase_rate
                FROM products
                ORDER BY product_name";

            using var r = cmd.ExecuteReader();
            int sno = 1;
            while (r.Read())
            {
                // BUG FIX: use SafeDecimal instead of (decimal)r.GetDouble(...) to avoid
                // InvalidCastException when a value is stored with INTEGER storage class (e.g. 0)
                decimal qty = SafeDecimal(r, 4);
                decimal minQty = SafeDecimal(r, 6);
                decimal weight = SafeDecimal(r, 5);
                decimal saleRate = SafeDecimal(r, 7);
                decimal purRate = SafeDecimal(r, 8);
                bool lowStock = qty <= minQty && minQty > 0;

                int rowIdx = gridStock.Rows.Add();
                var row = gridStock.Rows[rowIdx];
                row.Cells["csNo"].Value = sno++;
                row.Cells["csId"].Value = r.GetInt32(0);
                row.Cells["csProduct"].Value = SafeString(r, 1);
                row.Cells["csUnit"].Value = SafeString(r, 2);
                row.Cells["csQty"].Value = qty.ToString("N3");
                row.Cells["csWeight"].Value = weight.ToString("N3");
                row.Cells["csWeightUnit"].Value = SafeString(r, 3);
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

        // FEATURE: populate the party/customer filter dropdown from the accounts table.
        // NOTE: stock_movements has no account_id column of its own — a movement's party is
        // only reachable by joining back to sale_invoices / purchase_invoices on voucher_no
        // (see LoadMovements/BuildMovementRows below). This just lists every account; narrow
        // the WHERE clause here if you want to restrict to specific account_type values
        // (e.g. 'Personal Ledgers', 'Receivables', 'Payables').
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

        // FEATURE: populate the Sale / Purchase / Both movement-type filter dropdown.
        // NOTE: requires a ComboBox named "comboMovementType" added to the form in the
        // designer (drop it next to comboPartyFilter). Items are set here in code so the
        // designer control can start empty.
        private void LoadMovementTypes()
        {
            comboMovementType.Items.Clear();
            comboMovementType.Items.Add("-- Both --");
            comboMovementType.Items.Add("Sale");
            comboMovementType.Items.Add("Purchase");
            comboMovementType.SelectedIndex = 0;
        }

        // FEATURE: parses the movement-type combo selection into the exact string stored in
        // stock_movements.movement_type ("Sale" / "Purchase"), or "" for "Both" (no filter).
        private string GetSelectedMovementType()
        {
            if (comboMovementType.SelectedIndex <= 0) return "";
            return comboMovementType.SelectedItem!.ToString()!;
        }

        // FEATURE: parses "{id} - {name}" combo selection into the account_id, or 0 for "All".
        private int GetSelectedPartyId()
        {
            if (comboPartyFilter.SelectedIndex <= 0) return 0;
            string sel = comboPartyFilter.SelectedItem!.ToString()!;
            return int.Parse(sel.Split('-')[0].Trim());
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

            // FEATURE: resolve party filter (0 = all parties)
            int partyId = GetSelectedPartyId();
            string partyFilter = partyId > 0 ? " AND COALESCE(si.account_id, pi.account_id) = @partyId" : "";

            // FEATURE: resolve Sale/Purchase/Both movement-type filter ("" = both)
            string moveType = GetSelectedMovementType();
            string moveTypeFilter = moveType != "" ? " AND sm.movement_type = @moveType" : "";

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
                WHERE date(sm.movement_date) BETWEEN date(@from) AND date(@to)
                {productFilter}
                {partyFilter}
                {moveTypeFilter}
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
                // BUG FIX: replaced r.GetDouble(...) calls with SafeDouble to prevent
                // InvalidCastException on zero-valued qty/weight columns
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
                // NOTE: party_name is column index 13 (last). Only wire this into the grid
                // if you add an "smParty" column to gridMovements in the designer.
                // row.Cells["smParty"].Value = SafeString(r, 13);

                string mType = SafeString(r, 1);
                if (mType == "Sale")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (mType == "Purchase")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235);
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        // ── PDF export helpers ────────────────────────────────────────────────

        /// <summary>Reads the products table and returns StockSummaryRow list.</summary>
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
                // BUG FIX: SafeDecimal instead of (decimal)r.GetDouble(...)
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

        /// <summary>Reads stock_movements for the selected period/product/party/type.</summary>
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

            // FEATURE: resolve party filter (0 = all parties) — mirrors LoadMovements()
            int partyId = GetSelectedPartyId();
            string partyFilter = partyId > 0 ? " AND COALESCE(si.account_id, pi.account_id) = @partyId" : "";

            // FEATURE: resolve Sale/Purchase/Both movement-type filter ("" = both) — mirrors LoadMovements()
            string moveType = GetSelectedMovementType();
            string moveTypeFilter = moveType != "" ? " AND sm.movement_type = @moveType" : "";

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
                WHERE date(sm.movement_date) BETWEEN date(@from) AND date(@to)
                {productFilter}
                {partyFilter}
                {moveTypeFilter}
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
                // BUG FIX: SafeDecimal instead of (decimal)r.GetDouble(...)
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
                    BalanceWeight = SafeDecimal(r, 12)
                    // NOTE: party_name is column index 13 — add a PartyName property to
                    // StockMovementRow (and to StockReportPDF's rendering) if you want it
                    // printed in the exported PDF.
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



        /// <summary>Export Current Stock Summary to PDF.</summary>
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

        /// <summary>Export Stock Movements for the selected period/product/party/type to PDF.</summary>
        private void BtnExportMovements_Click(object sender, EventArgs e)
        {
            // Determine product label for the header
            string productLabel = comboProductFilter.SelectedIndex > 0
                ? comboProductFilter.SelectedItem!.ToString()!.Split('-', 2)[1].Trim()
                : "";

            // FEATURE: party label for the header
            string partyLabel = comboPartyFilter.SelectedIndex > 0
                ? comboPartyFilter.SelectedItem!.ToString()!.Split('-', 2)[1].Trim()
                : "";

            // FEATURE: movement-type label for the header ("" = Both)
            string moveTypeLabel = GetSelectedMovementType();

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
                    movementTypeFilter: moveTypeLabel, // FEATURE: Sale / Purchase / "" (Both)
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

        private void checkAllDates_CheckedChanged(object sender, EventArgs e)
        {
            setupDates();
        }
    }
}