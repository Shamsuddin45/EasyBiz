using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EasyBiz
{
    // One row of cashbook data passed into the PDF generator
    public class CashbookRow
    {
        public int SrNo { get; set; }
        public string Date { get; set; } = "";
        public string VoucherNo { get; set; } = "";
        public string Type { get; set; } = "";        // e.g. Receipt / Payment / Contra
        public string AccountName { get; set; } = ""; // opposite account
        public string Description { get; set; } = "";        
        public decimal CashIn { get; set; }           // receipts / inflows
        public decimal CashOut { get; set; }          // payments / outflows
        public decimal Balance { get; set; }          // running balance; negative = overdraft
    }

    internal static class CashbookReportPDF
    {
        static CashbookReportPDF()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // ── Colours ──────────────────────────────────────────────────────────
        private static readonly string HeaderBg = "#1B4F72";   // deep teal-navy
        private static readonly string SubHeaderBg = "#148F77";   // teal band
        private static readonly string RowAlt = "#E8F8F5";   // light mint stripe
        private static readonly string White = "#FFFFFF";
        private static readonly string TextDark = "#1A1A2E";
        private static readonly string InGreen = "#1E8449";   // cash-in
        private static readonly string OutRed = "#C0392B";   // cash-out
        private static readonly string BorderGrey = "#BDC3C7";

        // ── Public entry point ───────────────────────────────────────────────
        /// <summary>
        /// Generates a cashbook PDF and saves it to <paramref name="outputPath"/>.
        /// </summary>
        public static void Generate(
            string outputPath,
            string cashAccountName,      // e.g. "Main Cash Account"
            string branchOrLocation,     // e.g. "Head Office" — pass "" to hide
            DateTime fromDate,
            DateTime toDate,
            decimal openingBalance,
            List<CashbookRow> rows)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());   // wider — more columns
                    page.Margin(25);
                    page.DefaultTextStyle(x =>
                        x.FontFamily("Arial").FontSize(9).FontColor(TextDark));

                    page.Header().Element(ctx =>
                        ComposeHeader(ctx, cashAccountName, branchOrLocation,
                                      fromDate, toDate, openingBalance));

                    page.Content().PaddingTop(8).Element(ctx =>
                        ComposeTable(ctx, rows, openingBalance));

                    page.Footer().Element(ComposeFooter);
                });
            })
            .GeneratePdf(outputPath);
        }

        // ── Header ───────────────────────────────────────────────────────────
        private static void ComposeHeader(IContainer container,
            string cashAccountName, string branchOrLocation,
            DateTime fromDate, DateTime toDate, decimal openingBalance)
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
                            c.Item().Text("EasyBiz")
                                .FontSize(22).Bold().FontColor(White);
                            c.Item().Text("Cashbook Report")
                                .FontSize(11).FontColor("#A9DFBF");
                        });

                        row.ConstantItem(220).AlignRight().Column(c =>
                        {
                            c.Item().Text($"Printed: {DateTime.Now:dd-MMM-yyyy  hh:mm tt}")
                                .FontSize(8).FontColor("#A9DFBF");
                            c.Item().PaddingTop(4)
                                .Text($"Period:  {fromDate:dd-MMM-yyyy}  →  {toDate:dd-MMM-yyyy}")
                                .FontSize(8).FontColor(White);
                        });
                    });

                // Account info band
                col.Item()
                    .Background(SubHeaderBg)
                    .PaddingHorizontal(12).PaddingVertical(6)
                    .Row(row =>
                    {
                        row.RelativeItem().Text(txt =>
                        {
                            txt.Span("Cash Account: ").FontColor(White).FontSize(10);
                            txt.Span(cashAccountName).Bold().FontColor(White).FontSize(11);
                        });

                        if (!string.IsNullOrWhiteSpace(branchOrLocation))
                        {
                            row.RelativeItem().AlignCenter().Text(txt =>
                            {
                                txt.Span("Branch / Location: ").FontColor("#A9DFBF").FontSize(9);
                                txt.Span(branchOrLocation).Bold().FontColor(White).FontSize(10);
                            });
                        }

                        row.RelativeItem().AlignRight().Text(txt =>
                        {
                            txt.Span("Opening Balance: ").FontColor("#A9DFBF").FontSize(9);
                            txt.Span(openingBalance < 0
                                    ? $"{Math.Abs(openingBalance):N0} OD"
                                    : $"{openingBalance:N0}")
                               .Bold().FontColor(White).FontSize(10);
                        });
                    });
            });
        }

        // ── Table ────────────────────────────────────────────────────────────
        private static void ComposeTable(IContainer container,
            List<CashbookRow> rows, decimal openingBalance)
        {
            container.Table(table =>
            {
                // Column widths (landscape A4 ≈ 792 pt usable)
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(30);    // Sr
                    cols.ConstantColumn(72);    // Date
                    cols.ConstantColumn(60);    // Voucher
                    cols.RelativeColumn(1.2f);  // Type
                    cols.RelativeColumn(2f);    // Account
                    cols.RelativeColumn(2.8f);  // Description                    
                    cols.ConstantColumn(90);    // Cash In
                    cols.ConstantColumn(90);    // Cash Out
                    cols.ConstantColumn(100);   // Balance
                });

                // Header row
                table.Header(header =>
                {
                    string[] titles =
                    {
                        "#", "Date", "Voucher", "Type", "Account",
                        "Description", "Cash In", "Cash Out", "Balance"
                    };
                    bool[] rightAlign =
                    {
                        false, false, false, false, false,
                        false, true, true, true
                    };

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
                                    ? c.AlignRight()
                                    : c.AlignLeft();

                                aligned.Text(titles[idx])
                                    .FontColor(White)
                                    .Bold()
                                    .FontSize(9);
                            });
                    }
                });

                // Opening balance row
                TableRow(table, 0, "", "", "", "Opening Balance", "",
                         0, 0, openingBalance, isOpeningBalance: true);

                // Data rows
                foreach (var r in rows)
                {
                    TableRow(table, r.SrNo, r.Date, r.VoucherNo, r.Type,
                             r.AccountName, r.Description,
                             r.CashIn, r.CashOut, r.Balance,
                             isAlt: r.SrNo % 2 == 0);
                }

                // Totals row
                decimal totalIn = rows.Sum(r => r.CashIn);
                decimal totalOut = rows.Sum(r => r.CashOut);
                decimal closingBal = openingBalance + totalIn - totalOut;
                TotalsRow(table, totalIn, totalOut, closingBal);
            });
        }

        private static void TableRow(TableDescriptor table,
            int srNo, string date, string voucherNo, string type,
            string accountName, string description,
            decimal cashIn, decimal cashOut, decimal balance,
            bool isAlt = false, bool isOpeningBalance = false)
        {
            string bg = isOpeningBalance ? "#D1F2EB"
                      : isAlt ? RowAlt
                                        : White;

            void Cell(Action<IContainer> content)
            {
                table.Cell()
                    .Background(bg)
                    .BorderBottom(1).BorderColor(BorderGrey)
                    .PaddingVertical(5).PaddingHorizontal(5)
                    .Element(c => { content(c); });
            }

            // Sr#
            Cell(c => c.AlignCenter()
                       .Text(isOpeningBalance ? "" : srNo.ToString())
                       .FontSize(8));

            // Date
            Cell(c => c.Text(date).FontSize(8));

            // Voucher
            Cell(c => c.Text(voucherNo).FontSize(8));

            // Type
            Cell(c => c.Text(type).FontSize(8));

            // Account
            Cell(c => c.Text(accountName).FontSize(8));

            // Description
            Cell(c => c.Text(isOpeningBalance
                    ? "Opening Balance b/f"
                    : description)
                .FontSize(8).Italic(isOpeningBalance));            

            // Cash In
            Cell(c => c.AlignRight()
                       .Text(cashIn != 0 ? cashIn.ToString("N0") : "-")
                       .FontColor(cashIn != 0 ? InGreen : TextDark)
                       .FontSize(8));

            // Cash Out
            Cell(c => c.AlignRight()
                       .Text(cashOut != 0 ? cashOut.ToString("N0") : "-")
                       .FontColor(cashOut != 0 ? OutRed : TextDark)
                       .FontSize(8));

            // Balance
            string balText;
            string balColor;

            if (isOpeningBalance && balance == 0)
            {
                balText = "0";
                balColor = TextDark;
            }
            else
            {
                balText = balance < 0
                    ? $"{Math.Abs(balance):N0}"
                    : $"{balance:N0}";
                balColor = balance < 0 ? OutRed : InGreen;
            }

            Cell(c =>
            {
                var txt = c.AlignRight()
                           .Text(balText)
                           .FontColor(balColor)
                           .FontSize(8);

                if (isOpeningBalance)
                    txt.Bold();
            });
        }

        private static void TotalsRow(TableDescriptor table,
            decimal totalIn, decimal totalOut, decimal closingBalance)
        {
            void Cell(Action<IContainer> content, int span = 1)
            {
                table.Cell().ColumnSpan((uint)span)
                    .Background(HeaderBg)
                    .PaddingVertical(6).PaddingHorizontal(5)
                    .Element(c => { content(c); });
            }

            // Span first 6 columns for label
            Cell(c => c.AlignRight()
                       .Text("TOTALS / CLOSING BALANCE")
                       .FontColor(White)
                       .Bold()
                       .FontSize(9), 6);

            // Cash In total
            Cell(c => c.AlignRight()
                       .Text(totalIn.ToString("N0"))
                       .FontColor("#82E0AA").Bold().FontSize(9));

            // Cash Out total
            Cell(c => c.AlignRight()
                       .Text(totalOut.ToString("N0"))
                       .FontColor("#F1948A").Bold().FontSize(9));

            // Closing balance
            string closingText = closingBalance < 0
                ? $"{Math.Abs(closingBalance):N0} OD"
                : closingBalance.ToString("N0");

            Cell(c => c.AlignRight()
                       .Text(closingText)
                       .FontColor(closingBalance < 0 ? "#F1948A" : "#82E0AA")
                       .Bold().FontSize(9));
        }

        // ── Footer ───────────────────────────────────────────────────────────
        private static void ComposeFooter(IContainer container)
        {
            container
                .BorderTop(1).BorderColor(BorderGrey)
                .PaddingTop(5)
                .Row(row =>
                {
                    row.RelativeItem()
                       .Text("EasyBiz — Accounting Software")
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