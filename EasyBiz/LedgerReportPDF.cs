using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EasyBiz
{
    // One row of ledger data passed into the PDF generator
    public class LedgerRow
    {
        public int SrNo { get; set; }
        public string Date { get; set; } = "";
        public string VoucherNo { get; set; } = "";
        public string Type { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }   // raw numeric — negative = Cr
    }

    internal static class LedgerReportPDF
    {
        static LedgerReportPDF()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // ── Colours ──────────────────────────────────────────────────────────
        private static readonly string HeaderBg = "#1E3A5F";   // dark navy
        private static readonly string SubHeaderBg = "#2E86C1";   // blue band
        private static readonly string RowAlt = "#F0F4F8";   // light blue-grey stripe
        private static readonly string White = "#FFFFFF";
        private static readonly string TextDark = "#1A1A2E";
        private static readonly string DebitRed = "#C0392B";
        private static readonly string CreditGreen = "#1E8449";
        private static readonly string BorderGrey = "#BDC3C7";

        // ── Public entry point ───────────────────────────────────────────────
        /// <summary>
        /// Generates a customer ledger PDF and saves it to <paramref name="outputPath"/>.
        /// </summary>
        public static void Generate(
            string outputPath,
            string accountName,
            int accountId,
            string accountType,
            DateTime fromDate,
            DateTime toDate,
            decimal openingBalance,
            List<LedgerRow> rows)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Portrait());
                    page.Margin(25);
                    page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(9).FontColor(TextDark));

                    page.Header().Element(ctx => ComposeHeader(ctx, accountName, accountId,
                                                               accountType, fromDate, toDate));

                    page.Content().PaddingTop(8).Element(ctx =>
                        ComposeTable(ctx, rows, openingBalance));

                    page.Footer().Element(ComposeFooter);
                });
            })
            .GeneratePdf(outputPath);
        }

        // ── Header ───────────────────────────────────────────────────────────
        private static void ComposeHeader(IContainer container,
            string accountName, int accountId, string accountType,
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
                            c.Item().Text("EasyBiz")
                                .FontSize(22).Bold().FontColor(White);
                            c.Item().Text("Customer Ledger Report")
                                .FontSize(11).FontColor("#AED6F1");
                        });

                        row.ConstantItem(200).AlignRight().Column(c =>
                        {
                            c.Item().Text($"Printed: {DateTime.Now:dd-MMM-yyyy  hh:mm tt}")
                                .FontSize(8).FontColor("#AED6F1");
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
                            txt.Span("Account: ").FontColor(White).FontSize(10);
                            txt.Span(accountName).Bold().FontColor(White).FontSize(11);
                        });
                        row.RelativeItem().AlignCenter().Text(txt =>
                        {
                            txt.Span("A/C ID: ").FontColor("#AED6F1").FontSize(9);
                            txt.Span(accountId.ToString()).Bold().FontColor(White).FontSize(10);
                        });
                        row.RelativeItem().AlignRight().Text(txt =>
                        {
                            txt.Span("Type: ").FontColor("#AED6F1").FontSize(9);
                            txt.Span(accountType).Bold().FontColor(White).FontSize(10);
                        });
                    });
            });
        }

        // ── Table ────────────────────────────────────────────────────────────
        private static void ComposeTable(IContainer container,
            List<LedgerRow> rows, decimal openingBalance)
        {
            container.Table(table =>
            {
                // Column widths (total = ~100%)
                table.ColumnsDefinition(cols =>
                {
                    cols.ConstantColumn(30);   // Sr
                    cols.ConstantColumn(72);   // Date
                    cols.ConstantColumn(55);   // Voucher
                    cols.RelativeColumn(1.4f); // Type
                    cols.RelativeColumn(3f);   // Description
                    cols.ConstantColumn(80);   // Debit
                    cols.ConstantColumn(80);   // Credit
                    cols.ConstantColumn(95);   // Balance
                });

                // Header row
                table.Header(header =>
                {
                    string[] titles = { "#", "Date", "Voucher", "Type", "Description",
                                        "Debit", "Credit", "Balance" };
                    bool[] rightAlign = { false, false, false, false, false, true, true, true };

                    for (int i = 0; i < titles.Length; i++)
                    {
                        int idx = i; // capture
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
                TableRow(table, 0, "", "", "", "Opening Balance",
                         0, 0, openingBalance, isOpeningBalance: true);

                // Data rows
                foreach (var r in rows)
                {
                    TableRow(table, r.SrNo, r.Date, r.VoucherNo, r.Type,
                             r.Description, r.Debit, r.Credit, r.Balance,
                             isAlt: r.SrNo % 2 == 0);
                }

                // Totals row
                decimal totalDebit = rows.Sum(r => r.Debit);
                decimal totalCredit = rows.Sum(r => r.Credit);
                decimal closingBal = openingBalance + totalDebit - totalCredit;
                TotalsRow(table, totalDebit, totalCredit, closingBal);
            });
        }

        private static void TableRow(TableDescriptor table,
            int srNo, string date, string voucherNo, string type,
            string description, decimal debit, decimal credit, decimal balance,
            bool isAlt = false, bool isOpeningBalance = false)
        {
            string bg = isOpeningBalance ? "#D6EAF8"
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
            Cell(c => c.AlignCenter().Text(isOpeningBalance ? "" : srNo.ToString()).FontSize(8));
            // Date
            Cell(c => c.Text(date).FontSize(8));
            // Voucher
            Cell(c => c.Text(voucherNo).FontSize(8));
            // Type
            Cell(c => c.Text(type).FontSize(8));
            // Description
            Cell(c => c.Text(isOpeningBalance
                ? "Opening Balance b/f"
                : description).FontSize(8).Italic(isOpeningBalance));

            // Debit
            Cell(c => c.AlignRight().Text(
                debit != 0 ? debit.ToString("N0") : "-")
                .FontColor(debit != 0 ? DebitRed : TextDark).FontSize(8));

            // Credit
            Cell(c => c.AlignRight().Text(
                credit != 0 ? credit.ToString("N0") : "-")
                .FontColor(credit != 0 ? CreditGreen : TextDark).FontSize(8));

            // Balance
            string balText = balance < 0
                ? $"{Math.Abs(balance):N0} Cr"
                : $"{balance:N0} Dr";
            string balColor = balance < 0 ? CreditGreen : DebitRed;
            if (isOpeningBalance && balance == 0) { balText = "0"; balColor = TextDark; }

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
            decimal totalDebit, decimal totalCredit, decimal closingBalance)
        {
            void Cell(Action<IContainer> content, int span = 1)
            {
                table.Cell().ColumnSpan((uint)span)
                    .Background(HeaderBg)
                    .PaddingVertical(6).PaddingHorizontal(5)
                    .Element(c => { content(c); });
            }

            Cell(c => c.AlignRight()
           .Text("TOTALS / CLOSING BALANCE")
           .FontColor(White)
           .Bold()
           .FontSize(9), 5);

            Cell(c => c.AlignRight()
                       .Text(totalDebit.ToString("N0"))
                       .FontColor("#F1948A").Bold().FontSize(9));

            Cell(c => c.AlignRight()
                       .Text(totalCredit.ToString("N0"))
                       .FontColor("#82E0AA").Bold().FontSize(9));

            string closingText = closingBalance < 0
                ? $"{Math.Abs(closingBalance):N0} Cr"
                : $"{closingBalance:N0} Dr";

            Cell(c => c.AlignRight()
                       .Text(closingText)
                       .FontColor(closingBalance < 0 ? "#82E0AA" : "#F1948A")
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
                    row.RelativeItem().Text("EasyBiz — Accounting Software")
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