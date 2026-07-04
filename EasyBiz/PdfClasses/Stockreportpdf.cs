using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EasyBiz
{
    // ── Data models ──────────────────────────────────────────────────────────

    /// <summary>One row for the Current Stock Summary tab.</summary>
    public class StockSummaryRow
    {
        public int SrNo { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string Unit { get; set; } = "";
        public string WeightUnit { get; set; } = "";
        public decimal CurrentQty { get; set; }
        public decimal CurrentWeight { get; set; }
        public decimal MinStockQty { get; set; }
        public decimal SaleRate { get; set; }
        public decimal PurchaseRate { get; set; }
        public decimal StockValue { get; set; }           // CurrentQty × SaleRate
        public bool IsLowStock => CurrentQty <= MinStockQty && MinStockQty > 0;
    }

    /// <summary>One row for the Stock Movement Ledger tab.</summary>
    public class StockMovementRow
    {
        public int SrNo { get; set; }
        public string Date { get; set; } = "";
        public string MovementType { get; set; } = "";    // "Sale" | "Purchase" | …
        public string VoucherRef { get; set; } = "";      // e.g. "Sale #12"
        public string ProductName { get; set; } = "";
        public decimal QtyIn { get; set; }
        public decimal QtyOut { get; set; }
        public decimal WeightIn { get; set; }
        public decimal WeightOut { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceQty { get; set; }
        public decimal BalanceWeight { get; set; }
    }

    // ── PDF generator ────────────────────────────────────────────────────────

    internal static class StockReportPDF
    {
        static StockReportPDF()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // ── Palette ──────────────────────────────────────────────────────────
        private static readonly string HeaderBg = "#1B3A5C";   // deep navy
        private static readonly string SubHeaderBg = "#2E6DA4";   // mid-blue band
        private static readonly string RowAlt = "#EAF2FB";   // soft blue stripe
        private static readonly string LowStockBg = "#FDEDEC";   // soft red — low stock
        private static readonly string LowStockFg = "#922B21";
        private static readonly string SaleRowBg = "#FEF9E7";   // pale amber — sale
        private static readonly string PurchaseBg = "#EAFAF1";   // pale green — purchase
        private static readonly string White = "#FFFFFF";
        private static readonly string TextDark = "#1A1A2E";
        private static readonly string GreenText = "#1E8449";
        private static readonly string RedText = "#C0392B";
        private static readonly string BorderGrey = "#BDC3C7";
        private static readonly string TotalsRowBg = "#1B3A5C";

        // ════════════════════════════════════════════════════════════════════
        //  PUBLIC: Generate Stock Summary PDF
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Generates a Current Stock Summary PDF (one row per product).
        /// </summary>
        public static void GenerateSummary(
            string outputPath,
            string companyName,
            DateTime asOfDate,
            List<StockSummaryRow> rows)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(25);
                    page.DefaultTextStyle(x =>
                        x.FontFamily("Arial").FontSize(9).FontColor(TextDark));

                    page.Header().Element(ctx =>
                        ComposeSummaryHeader(ctx, companyName, asOfDate, rows.Count));

                    page.Content().PaddingTop(8).Element(ctx =>
                        ComposeSummaryTable(ctx, rows));

                    page.Footer().Element(ComposeFooter);
                });
            })
            .GeneratePdf(outputPath);
        }

        // ════════════════════════════════════════════════════════════════════
        //  PUBLIC: Generate Stock Movement PDF
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Generates a Stock Movement Ledger PDF for a date range,
        /// optionally filtered to a single product, party, and/or movement type.
        /// </summary>
        public static void GenerateMovements(
            string outputPath,
            string companyName,
            string productFilter,       // "" = all products, else product name
            string partyFilter,         // "" = all parties, else party/account name
            string movementTypeFilter,  // FEATURE: "" = Both, else "Sale" or "Purchase"
            DateTime fromDate,
            DateTime toDate,
            List<StockMovementRow> rows)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(25);
                    page.DefaultTextStyle(x =>
                        x.FontFamily("Arial").FontSize(9).FontColor(TextDark));

                    page.Header().Element(ctx =>
                        ComposeMovementHeader(ctx, companyName, productFilter, partyFilter,
                                              movementTypeFilter, fromDate, toDate));

                    page.Content().PaddingTop(8).Element(ctx =>
                        ComposeMovementTable(ctx, rows));

                    page.Footer().Element(ComposeFooter);
                });
            })
            .GeneratePdf(outputPath);
        }

        // ════════════════════════════════════════════════════════════════════
        //  SUMMARY HEADER
        // ════════════════════════════════════════════════════════════════════

        private static void ComposeSummaryHeader(IContainer container,
            string companyName, DateTime asOfDate, int productCount)
        {
            container.Column(col =>
            {
                // Title bar
                col.Item()
                    .Background(HeaderBg)
                    .Padding(12)
                    .Row(row =>
                    {
                        row.RelativeItem().Column(c =>
                        {
                            c.Item().Text(companyName)
                                .FontSize(20).Bold().FontColor(White);
                            c.Item().Text("Stock Summary Report")
                                .FontSize(11).FontColor("#AED6F1");
                        });

                        row.ConstantItem(230).AlignRight().Column(c =>
                        {
                            c.Item().Text($"Printed: {DateTime.Now:dd-MMM-yyyy  hh:mm tt}")
                                .FontSize(8).FontColor("#AED6F1");
                            c.Item().PaddingTop(4)
                                .Text($"As of: {asOfDate:dd-MMM-yyyy}")
                                .FontSize(9).Bold().FontColor(White);
                        });
                    });

                // Sub-header band
                col.Item()
                    .Background(SubHeaderBg)
                    .PaddingHorizontal(12).PaddingVertical(6)
                    .Row(row =>
                    {
                        row.RelativeItem().Text(txt =>
                        {
                            txt.Span("Total Products: ")
                                .FontColor("#D6EAF8").FontSize(9);
                            txt.Span(productCount.ToString())
                                .Bold().FontColor(White).FontSize(10);
                        });

                        row.RelativeItem().AlignRight().Text(txt =>
                        {
                            txt.Span("⚠ Low-stock rows highlighted in red")
                                .FontColor("#FADBD8").FontSize(8).Italic();
                        });
                    });
            });
        }

        // ════════════════════════════════════════════════════════════════════
        //  SUMMARY TABLE
        // ════════════════════════════════════════════════════════════════════

        private static void ComposeSummaryTable(IContainer container,
            List<StockSummaryRow> rows)
        {
            container.Table(table =>
            {
                // Column widths (landscape A4 ≈ 792 pt usable after margins)
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(28);    // #
                    cols.ConstantColumn(48);    // ID
                    cols.RelativeColumn(3f);    // Product Name
                    cols.ConstantColumn(50);    // Unit
                    cols.ConstantColumn(72);    // Qty
                    cols.ConstantColumn(72);    // Weight
                    cols.ConstantColumn(48);    // Wt Unit
                    cols.ConstantColumn(62);    // Min Qty
                    cols.ConstantColumn(72);    // Sale Rate
                    cols.ConstantColumn(72);    // Pur Rate
                    cols.ConstantColumn(90);    // Stock Value
                });

                // Header row
                string[] titles =
                {
                    "#", "ID", "Product Name", "Unit",
                    "Qty", "Weight", "Wt Unit", "Min Qty",
                    "Sale Rate", "Pur Rate", "Stock Value"
                };
                bool[] rightAlign =
                {
                    false, false, false, false,
                    true, true, false, true,
                    true, true, true
                };

                table.Header(header =>
                {
                    for (int i = 0; i < titles.Length; i++)
                    {
                        int idx = i;
                        header.Cell()
                            .Background(HeaderBg)
                            .BorderBottom(1).BorderColor(White)
                            .Padding(6)
                            .Element(c =>
                            {
                                var aligned = rightAlign[idx]
                                    ? c.AlignRight() : c.AlignLeft();
                                aligned.Text(titles[idx])
                                    .FontColor(White).Bold().FontSize(9);
                            });
                    }
                });

                // Data rows
                decimal grandValue = 0m;
                foreach (var r in rows)
                {
                    grandValue += r.StockValue;

                    string bg = r.IsLowStock
                        ? LowStockBg
                        : (r.SrNo % 2 == 0 ? RowAlt : White);
                    string fg = r.IsLowStock ? LowStockFg : TextDark;

                    void Cell(Action<IContainer> content)
                    {
                        table.Cell()
                            .Background(bg)
                            .BorderBottom(1).BorderColor(BorderGrey)
                            .PaddingVertical(5).PaddingHorizontal(5)
                            .Element(c => content(c));
                    }

                    Cell(c => c.AlignCenter().Text(r.SrNo.ToString()).FontSize(8).FontColor(fg));
                    Cell(c => c.Text(r.ProductId.ToString()).FontSize(8).FontColor(fg));
                    Cell(c => c.Text(r.ProductName).FontSize(8).FontColor(fg));
                    Cell(c => c.Text(r.Unit).FontSize(8).FontColor(fg));
                    Cell(c => c.AlignRight().Text(r.CurrentQty.ToString("N3")).FontSize(8)
                               .FontColor(r.IsLowStock ? LowStockFg : GreenText));
                    Cell(c => c.AlignRight().Text(r.CurrentWeight.ToString("N3")).FontSize(8).FontColor(fg));
                    Cell(c => c.Text(r.WeightUnit).FontSize(8).FontColor(fg));
                    Cell(c => c.AlignRight().Text(r.MinStockQty.ToString("N3")).FontSize(8).FontColor(fg));
                    Cell(c => c.AlignRight().Text(r.SaleRate.ToString("N2")).FontSize(8).FontColor(fg));
                    Cell(c => c.AlignRight().Text(r.PurchaseRate.ToString("N2")).FontSize(8).FontColor(fg));
                    Cell(c => c.AlignRight().Text(r.StockValue.ToString("N2")).FontSize(8)
                               .FontColor(r.IsLowStock ? LowStockFg : TextDark).Bold());
                }

                // Totals row
                SummaryTotalsRow(table, rows.Count, grandValue);
            });
        }

        private static void SummaryTotalsRow(TableDescriptor table,
            int count, decimal grandValue)
        {
            void Cell(Action<IContainer> content, int span = 1)
            {
                table.Cell().ColumnSpan((uint)span)
                    .Background(TotalsRowBg)
                    .PaddingVertical(6).PaddingHorizontal(5)
                    .Element(c => content(c));
            }

            Cell(c => c.AlignRight()
                       .Text($"TOTAL  ({count} products)")
                       .FontColor(White).Bold().FontSize(9), 10);

            Cell(c => c.AlignRight()
                       .Text(grandValue.ToString("N2"))
                       .FontColor("#82E0AA").Bold().FontSize(9));
        }

        // ════════════════════════════════════════════════════════════════════
        //  MOVEMENT HEADER
        // ════════════════════════════════════════════════════════════════════

        private static void ComposeMovementHeader(IContainer container,
            string companyName, string productFilter, string partyFilter,
            string movementTypeFilter, // FEATURE: "" = Both, else "Sale"/"Purchase"
            DateTime fromDate, DateTime toDate)
        {
            container.Column(col =>
            {
                // Title bar
                col.Item()
                    .Background(HeaderBg)
                    .Padding(12)
                    .Row(row =>
                    {
                        row.RelativeItem().Column(c =>
                        {
                            c.Item().Text(companyName)
                                .FontSize(20).Bold().FontColor(White);
                            c.Item().Text("Stock Movement Ledger")
                                .FontSize(11).FontColor("#AED6F1");
                        });

                        row.ConstantItem(240).AlignRight().Column(c =>
                        {
                            c.Item().Text($"Printed: {DateTime.Now:dd-MMM-yyyy  hh:mm tt}")
                                .FontSize(8).FontColor("#AED6F1");
                            c.Item().PaddingTop(4)
                                .Text($"Period:  {fromDate:dd-MMM-yyyy}  →  {toDate:dd-MMM-yyyy}")
                                .FontSize(8).FontColor(White);
                        });
                    });

                // Sub-header band
                // FEATURE: added a fourth RelativeItem for the Sale/Purchase/Both movement-type
                // filter, next to Product and Party, ahead of the colour-key legend.
                col.Item()
                    .Background(SubHeaderBg)
                    .PaddingHorizontal(12).PaddingVertical(6)
                    .Row(row =>
                    {
                        row.RelativeItem().Text(txt =>
                        {
                            txt.Span("Product: ").FontColor("#D6EAF8").FontSize(9);
                            txt.Span(string.IsNullOrWhiteSpace(productFilter)
                                    ? "All Products"
                                    : productFilter)
                               .Bold().FontColor(White).FontSize(10);
                        });

                        row.RelativeItem().Text(txt =>
                        {
                            txt.Span("Party: ").FontColor("#D6EAF8").FontSize(9);
                            txt.Span(string.IsNullOrWhiteSpace(partyFilter)
                                    ? "All Parties"
                                    : partyFilter)
                               .Bold().FontColor(White).FontSize(10);
                        });

                        row.RelativeItem().Text(txt =>
                        {
                            txt.Span("Type: ").FontColor("#D6EAF8").FontSize(9);
                            txt.Span(string.IsNullOrWhiteSpace(movementTypeFilter)
                                    ? "Both"
                                    : movementTypeFilter)
                               .Bold().FontColor(White).FontSize(10);
                        });

                        row.RelativeItem().AlignRight().Text(txt =>
                        {
                            txt.Span("Green = Purchase  |  Amber = Sale")
                                .FontColor("#D6EAF8").FontSize(8).Italic();
                        });
                    });
            });
        }

        // ════════════════════════════════════════════════════════════════════
        //  MOVEMENT TABLE
        // ════════════════════════════════════════════════════════════════════

        private static void ComposeMovementTable(IContainer container,
            List<StockMovementRow> rows)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(28);    // #
                    cols.ConstantColumn(65);    // Date
                    cols.ConstantColumn(62);    // Type
                    cols.ConstantColumn(72);    // Voucher
                    cols.RelativeColumn(2.4f);  // Product
                    cols.ConstantColumn(58);    // Qty In
                    cols.ConstantColumn(58);    // Qty Out
                    cols.ConstantColumn(58);    // Wt In
                    cols.ConstantColumn(58);    // Wt Out
                    cols.ConstantColumn(60);    // Rate
                    cols.ConstantColumn(72);    // Amount
                    cols.ConstantColumn(62);    // Bal Qty
                    cols.ConstantColumn(62);    // Bal Wt
                });

                string[] titles =
                {
                    "#", "Date", "Type", "Voucher", "Product",
                    "Qty In", "Qty Out", "Wt In", "Wt Out",
                    "Rate", "Amount", "Bal Qty", "Bal Wt"
                };
                bool[] rightAlign =
                {
                    false, false, false, false, false,
                    true, true, true, true,
                    true, true, true, true
                };

                table.Header(header =>
                {
                    for (int i = 0; i < titles.Length; i++)
                    {
                        int idx = i;
                        header.Cell()
                            .Background(HeaderBg)
                            .BorderBottom(1).BorderColor(White)
                            .Padding(6)
                            .Element(c =>
                            {
                                var aligned = rightAlign[idx]
                                    ? c.AlignRight() : c.AlignLeft();
                                aligned.Text(titles[idx])
                                    .FontColor(White).Bold().FontSize(8);
                            });
                    }
                });

                // Data rows
                decimal totalQtyIn = 0, totalQtyOut = 0;
                decimal totalWtIn = 0, totalWtOut = 0;
                decimal totalAmount = 0;

                foreach (var r in rows)
                {
                    totalQtyIn += r.QtyIn;
                    totalQtyOut += r.QtyOut;
                    totalWtIn += r.WeightIn;
                    totalWtOut += r.WeightOut;
                    totalAmount += r.Amount;

                    // Row colour by movement type
                    string bg = r.MovementType == "Purchase"
                        ? PurchaseBg
                        : r.MovementType == "Sale"
                            ? SaleRowBg
                            : (r.SrNo % 2 == 0 ? RowAlt : White);

                    string typeColor = r.MovementType == "Purchase"
                        ? GreenText
                        : r.MovementType == "Sale"
                            ? RedText
                            : TextDark;

                    void Cell(Action<IContainer> content)
                    {
                        table.Cell()
                            .Background(bg)
                            .BorderBottom(1).BorderColor(BorderGrey)
                            .PaddingVertical(5).PaddingHorizontal(5)
                            .Element(c => content(c));
                    }

                    Cell(c => c.AlignCenter().Text(r.SrNo.ToString()).FontSize(8));
                    Cell(c => c.Text(r.Date).FontSize(8));
                    Cell(c => c.Text(r.MovementType).FontSize(8).FontColor(typeColor).Bold());
                    Cell(c => c.Text(r.VoucherRef).FontSize(8));
                    Cell(c => c.Text(r.ProductName).FontSize(8));
                    Cell(c => c.AlignRight()
                               .Text(r.QtyIn > 0 ? r.QtyIn.ToString("N3") : "-")
                               .FontSize(8).FontColor(r.QtyIn > 0 ? GreenText : TextDark));
                    Cell(c => c.AlignRight()
                               .Text(r.QtyOut > 0 ? r.QtyOut.ToString("N3") : "-")
                               .FontSize(8).FontColor(r.QtyOut > 0 ? RedText : TextDark));
                    Cell(c => c.AlignRight()
                               .Text(r.WeightIn > 0 ? r.WeightIn.ToString("N3") : "-")
                               .FontSize(8).FontColor(r.WeightIn > 0 ? GreenText : TextDark));
                    Cell(c => c.AlignRight()
                               .Text(r.WeightOut > 0 ? r.WeightOut.ToString("N3") : "-")
                               .FontSize(8).FontColor(r.WeightOut > 0 ? RedText : TextDark));
                    Cell(c => c.AlignRight().Text(r.Rate.ToString("N2")).FontSize(8));
                    Cell(c => c.AlignRight().Text(r.Amount.ToString("N2")).FontSize(8).Bold());
                    Cell(c => c.AlignRight().Text(r.BalanceQty.ToString("N3")).FontSize(8)
                               .FontColor(r.BalanceQty < 0 ? RedText : TextDark));
                    Cell(c => c.AlignRight().Text(r.BalanceWeight.ToString("N3")).FontSize(8)
                               .FontColor(r.BalanceWeight < 0 ? RedText : TextDark));
                }

                // Totals row
                MovementTotalsRow(table,
                    totalQtyIn, totalQtyOut,
                    totalWtIn, totalWtOut,
                    totalAmount);
            });
        }

        private static void MovementTotalsRow(TableDescriptor table,
            decimal qtyIn, decimal qtyOut,
            decimal wtIn, decimal wtOut,
            decimal amount)
        {
            void Cell(Action<IContainer> content, int span = 1)
            {
                table.Cell().ColumnSpan((uint)span)
                    .Background(TotalsRowBg)
                    .PaddingVertical(6).PaddingHorizontal(5)
                    .Element(c => content(c));
            }

            // Label spanning first 5 columns
            Cell(c => c.AlignRight()
                       .Text("TOTALS")
                       .FontColor(White).Bold().FontSize(9), 5);

            Cell(c => c.AlignRight()
                       .Text(qtyIn.ToString("N3"))
                       .FontColor("#82E0AA").Bold().FontSize(9));

            Cell(c => c.AlignRight()
                       .Text(qtyOut.ToString("N3"))
                       .FontColor("#F1948A").Bold().FontSize(9));

            Cell(c => c.AlignRight()
                       .Text(wtIn.ToString("N3"))
                       .FontColor("#82E0AA").Bold().FontSize(9));

            Cell(c => c.AlignRight()
                       .Text(wtOut.ToString("N3"))
                       .FontColor("#F1948A").Bold().FontSize(9));

            // empty Rate cell
            Cell(c => { });

            Cell(c => c.AlignRight()
                       .Text(amount.ToString("N2"))
                       .FontColor(White).Bold().FontSize(9));

            // balance columns — no meaningful total
            Cell(c => { });
            Cell(c => { });
        }

        // ════════════════════════════════════════════════════════════════════
        //  SHARED FOOTER
        // ════════════════════════════════════════════════════════════════════

        private static void ComposeFooter(IContainer container)
        {
            container
                .BorderTop(1).BorderColor(BorderGrey)
                .PaddingTop(5)
                .Row(row =>
                {
                    row.RelativeItem()
                       .Text("EasyBiz — Inventory & Accounting Software")
                       .FontSize(8).FontColor("#7F8C8D");

                    row.RelativeItem().AlignCenter()
                       .Text("** This is a computer-generated report **")
                       .FontSize(8).FontColor("#7F8C8D").Italic();

                    row.RelativeItem().AlignRight().Text(txt =>
                    {
                        txt.Span("Page ").FontSize(8).FontColor("#7F8C8D");
                        txt.CurrentPageNumber().FontSize(8).FontColor("#7F8C8D");
                        txt.Span(" of ").FontSize(8).FontColor("#7F8C8D");
                        txt.TotalPages().FontSize(8).FontColor("#7F8C8D");
                    });
                });
        }
    }
}