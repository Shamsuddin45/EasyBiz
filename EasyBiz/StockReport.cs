using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
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
            BeautifyGrid(gridStock, Color.FromArgb(52, 152, 219));
            BeautifyGrid(gridMovements, Color.FromArgb(39, 174, 96));            
        }

        private void BeautifyGrid(DataGridView grid, Color headerColor)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;
            grid.RowHeadersVisible = false;

            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            grid.GridColor = Color.FromArgb(220, 220, 220);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Header Style
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Rows
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            grid.RowTemplate.Height = 35;
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
                decimal qty = (decimal)r.GetDouble(4);
                decimal minQty = (decimal)r.GetDouble(6);
                bool lowStock = qty <= minQty && minQty > 0;

                int rowIdx = gridStock.Rows.Add();
                var row = gridStock.Rows[rowIdx];
                row.Cells["csNo"].Value = sno++;
                row.Cells["csId"].Value = r.GetInt32(0);
                row.Cells["csProduct"].Value = r.GetString(1);
                row.Cells["csUnit"].Value = r.GetString(2);
                row.Cells["csQty"].Value = qty.ToString("N3");
                row.Cells["csWeight"].Value = ((decimal)r.GetDouble(5)).ToString("N3");
                row.Cells["csWeightUnit"].Value = r.GetString(3);
                row.Cells["csMinQty"].Value = minQty.ToString("N3");
                row.Cells["csSaleRate"].Value = ((decimal)r.GetDouble(7)).ToString("N2");
                row.Cells["csPurRate"].Value = ((decimal)r.GetDouble(8)).ToString("N2");
                row.Cells["csValue"].Value = (qty * (decimal)r.GetDouble(7)).ToString("N2");

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
                comboProductFilter.Items.Add($"{r.GetInt32(0)} - {r.GetString(1)}");
            comboProductFilter.SelectedIndex = 0;
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

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT sm.movement_date, sm.movement_type, sm.voucher_type,
                       sm.voucher_no, sm.product_name, sm.qty_in, sm.qty_out,
                       sm.weight_in, sm.weight_out, sm.rate, sm.amount,
                       sm.balance_qty, sm.balance_weight
                FROM stock_movements sm
                WHERE date(sm.movement_date) BETWEEN date(@from) AND date(@to)
                {productFilter}
                ORDER BY sm.movement_date, sm.movement_id";

            cmd.Parameters.AddWithValue("@from", dateFrom.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@to", dateTo.Value.ToString("yyyy-MM-dd"));
            if (productId > 0) cmd.Parameters.AddWithValue("@pid", productId);

            using var r = cmd.ExecuteReader();
            int sno = 1;
            while (r.Read())
            {
                int rowIdx = gridMovements.Rows.Add();
                var row = gridMovements.Rows[rowIdx];
                row.Cells["smNo"].Value = sno++;
                row.Cells["smDate"].Value = r.GetString(0);
                row.Cells["smType"].Value = r.GetString(1);
                row.Cells["smVoucher"].Value = $"{r.GetString(2)} #{r.GetInt32(3)}";
                row.Cells["smProduct"].Value = r.GetString(4);
                row.Cells["smQtyIn"].Value = r.GetDouble(5) > 0 ? r.GetDouble(5).ToString("N3") : "-";
                row.Cells["smQtyOut"].Value = r.GetDouble(6) > 0 ? r.GetDouble(6).ToString("N3") : "-";
                row.Cells["smWtIn"].Value = r.GetDouble(7) > 0 ? r.GetDouble(7).ToString("N3") : "-";
                row.Cells["smWtOut"].Value = r.GetDouble(8) > 0 ? r.GetDouble(8).ToString("N3") : "-";
                row.Cells["smRate"].Value = r.GetDouble(9).ToString("N2");
                row.Cells["smAmount"].Value = r.GetDouble(10).ToString("N2");
                row.Cells["smBalQty"].Value = r.GetDouble(11).ToString("N3");
                row.Cells["smBalWt"].Value = r.GetDouble(12).ToString("N3");

                string mType = r.GetString(1);
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
                decimal qty = (decimal)r.GetDouble(4);
                decimal sale = (decimal)r.GetDouble(7);
                rows.Add(new StockSummaryRow
                {
                    SrNo = sno++,
                    ProductId = r.GetInt32(0),
                    ProductName = r.GetString(1),
                    Unit = r.GetString(2),
                    WeightUnit = r.GetString(3),
                    CurrentQty = qty,
                    CurrentWeight = (decimal)r.GetDouble(5),
                    MinStockQty = (decimal)r.GetDouble(6),
                    SaleRate = sale,
                    PurchaseRate = (decimal)r.GetDouble(8),
                    StockValue = qty * sale
                });
            }
            return rows;
        }

        /// <summary>Reads stock_movements for the selected period/product.</summary>
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

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT sm.movement_date, sm.movement_type, sm.voucher_type,
                       sm.voucher_no, sm.product_name, sm.qty_in, sm.qty_out,
                       sm.weight_in, sm.weight_out, sm.rate, sm.amount,
                       sm.balance_qty, sm.balance_weight
                FROM stock_movements sm
                WHERE date(sm.movement_date) BETWEEN date(@from) AND date(@to)
                {productFilter}
                ORDER BY sm.movement_date, sm.movement_id";

            cmd.Parameters.AddWithValue("@from", dateFrom.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@to", dateTo.Value.ToString("yyyy-MM-dd"));
            if (productId > 0) cmd.Parameters.AddWithValue("@pid", productId);

            using var r = cmd.ExecuteReader();
            int sno = 1;
            while (r.Read())
            {
                rows.Add(new StockMovementRow
                {
                    SrNo = sno++,
                    Date = r.GetString(0),
                    MovementType = r.GetString(1),
                    VoucherRef = $"{r.GetString(2)} #{r.GetInt32(3)}",
                    ProductName = r.GetString(4),
                    QtyIn = (decimal)r.GetDouble(5),
                    QtyOut = (decimal)r.GetDouble(6),
                    WeightIn = (decimal)r.GetDouble(7),
                    WeightOut = (decimal)r.GetDouble(8),
                    Rate = (decimal)r.GetDouble(9),
                    Amount = (decimal)r.GetDouble(10),
                    BalanceQty = (decimal)r.GetDouble(11),
                    BalanceWeight = (decimal)r.GetDouble(12)
                });
            }
            return rows;
        }

        // ── Button handlers ───────────────────────────────────────────────────

        private void BtnRefreshStock_Click(object sender, EventArgs e) =>
            LoadStockSummary();

        private void BtnLoadMovements_Click(object sender, EventArgs e) =>
            LoadMovements();

        private void BtnClose_Click(object sender, EventArgs e) =>
            Close();

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

        /// <summary>Export Stock Movements for the selected period/product to PDF.</summary>
        private void BtnExportMovements_Click(object sender, EventArgs e)
        {
            // Determine product label for the header
            string productLabel = comboProductFilter.SelectedIndex > 0
                ? comboProductFilter.SelectedItem!.ToString()!.Split('-', 2)[1].Trim()
                : "";

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
    }
}