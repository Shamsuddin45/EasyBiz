using System;
using System.Collections.Generic;
using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EasyBiz
{
    // ============================================================
    // CASHBOOK ROW
    // ============================================================
    public class CashbookRow
    {
        public int SrNo { get; set; }

        public string Date { get; set; } = "";

        public string VoucherNo { get; set; } = "";

        public string Type { get; set; } = "";

        public string AccountName { get; set; } = "";

        public string Description { get; set; } = "";

        // Money received
        public decimal CashIn { get; set; }

        // Money paid
        public decimal CashOut { get; set; }

        // Running cash balance
        public decimal Balance { get; set; }
    }


    // ============================================================
    // CASHBOOK PDF REPORT
    // ============================================================
    internal static class CashbookReportPDF
    {
        static CashbookReportPDF()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }


        // ============================================================
        // COLORS
        // ============================================================
        private const string HeaderBg = "#1B4F72";
        private const string SubHeaderBg = "#148F77";

        private const string White = "#FFFFFF";
        private const string TextDark = "#1A1A2E";

        private const string RowAlt = "#F4F9F8";
        private const string OpeningBg = "#E8F6F3";

        private const string BorderGrey = "#D5D8DC";

        private const string InGreen = "#1E8449";
        private const string OutRed = "#C0392B";

        private const string OpeningBlue = "#21618C";


        // ============================================================
        // PUBLIC GENERATE METHOD
        // ============================================================
        public static void Generate(
            string outputPath,
            string cashAccountName,
            string branchOrLocation,
            DateTime fromDate,
            DateTime toDate,
            decimal openingBalance,
            List<CashbookRow> rows)
        {
            if (rows == null)
                rows = new List<CashbookRow>();

            // --------------------------------------------------------
            // Calculate period totals.
            //
            // IMPORTANT:
            // These totals are ONLY transactions during the selected
            // period. Opening balance is displayed separately.
            // --------------------------------------------------------
            decimal totalCashIn =
                rows.Sum(x => x.CashIn);

            decimal totalCashOut =
                rows.Sum(x => x.CashOut);

            // --------------------------------------------------------
            // Closing balance.
            //
            // CashBook convention:
            //
            // Balance = Opening + Cash In - Cash Out
            // --------------------------------------------------------
            decimal closingBalance =
                openingBalance +
                totalCashIn -
                totalCashOut;


            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());

                    page.MarginHorizontal(22);
                    page.MarginVertical(20);

                    page.DefaultTextStyle(style =>
                        style
                            .FontFamily("Arial")
                            .FontSize(8)
                            .FontColor(TextDark));

                    // HEADER
                    page.Header()
                        .Element(container =>
                            ComposeHeader(
                                container,
                                cashAccountName,
                                branchOrLocation,
                                fromDate,
                                toDate,
                                openingBalance));

                    // CONTENT
                    page.Content()
                        .PaddingTop(8)
                        .Element(container =>
                            ComposeTable(
                                container,
                                rows,
                                openingBalance,
                                totalCashIn,
                                totalCashOut,
                                closingBalance));

                    // FOOTER
                    page.Footer()
                        .Element(ComposeFooter);
                });
            })
            .GeneratePdf(outputPath);
        }


        // ============================================================
        // HEADER
        // ============================================================
        private static void ComposeHeader(
            IContainer container,
            string cashAccountName,
            string branchOrLocation,
            DateTime fromDate,
            DateTime toDate,
            decimal openingBalance)
        {
            container.Column(column =>
            {
                // ----------------------------------------------------
                // TITLE
                // ----------------------------------------------------
                column.Item()
                    .Background(HeaderBg)
                    .Padding(11)
                    .Row(row =>
                    {
                        row.RelativeItem()
                            .Column(left =>
                            {
                                left.Item()
                                    .Text("EasyBiz")
                                    .FontSize(21)
                                    .Bold()
                                    .FontColor(White);

                                left.Item()
                                    .PaddingTop(2)
                                    .Text("Cash Book Report")
                                    .FontSize(10)
                                    .FontColor("#A9DFBF");
                            });


                        row.ConstantItem(245)
                            .AlignRight()
                            .Column(right =>
                            {
                                right.Item()
                                    .Text(
                                        $"Printed: {DateTime.Now:dd-MMM-yyyy hh:mm tt}")
                                    .FontSize(8)
                                    .FontColor("#D5F5E3");

                                right.Item()
                                    .PaddingTop(3)
                                    .Text(
                                        $"Period: {fromDate:dd-MMM-yyyy}  →  {toDate:dd-MMM-yyyy}")
                                    .FontSize(8)
                                    .FontColor(White);
                            });
                    });


                // ----------------------------------------------------
                // ACCOUNT INFORMATION
                // ----------------------------------------------------
                column.Item()
                    .Background(SubHeaderBg)
                    .PaddingHorizontal(11)
                    .PaddingVertical(6)
                    .Row(row =>
                    {
                        // Cash account
                        row.RelativeItem()
                            .Text(text =>
                            {
                                text.Span("Cash Account: ")
                                    .FontColor("#D5F5E3")
                                    .FontSize(8);

                                text.Span(
                                        string.IsNullOrWhiteSpace(cashAccountName)
                                            ? "Cash Accounts"
                                            : cashAccountName)
                                    .Bold()
                                    .FontColor(White)
                                    .FontSize(9);
                            });


                        // Branch
                        if (!string.IsNullOrWhiteSpace(branchOrLocation))
                        {
                            row.RelativeItem()
                                .AlignCenter()
                                .Text(text =>
                                {
                                    text.Span("Branch: ")
                                        .FontColor("#D5F5E3")
                                        .FontSize(8);

                                    text.Span(branchOrLocation)
                                        .Bold()
                                        .FontColor(White)
                                        .FontSize(9);
                                });
                        }


                        // Opening balance
                        row.RelativeItem()
                            .AlignRight()
                            .Text(text =>
                            {
                                text.Span("Opening Balance: ")
                                    .FontColor("#D5F5E3")
                                    .FontSize(8);

                                text.Span(
                                        FormatBalance(openingBalance))
                                    .Bold()
                                    .FontColor(White)
                                    .FontSize(9);
                            });
                    });
            });
        }


        // ============================================================
        // TABLE
        // ============================================================
        private static void ComposeTable(
            IContainer container,
            List<CashbookRow> rows,
            decimal openingBalance,
            decimal totalCashIn,
            decimal totalCashOut,
            decimal closingBalance)
        {
            container.Table(table =>
            {
                // ----------------------------------------------------
                // COLUMN DEFINITIONS
                // ----------------------------------------------------
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(28);     // #
                    columns.ConstantColumn(68);     // Date
                    columns.ConstantColumn(58);     // Voucher

                    columns.RelativeColumn(1.35f);  // Type
                    columns.RelativeColumn(1.9f);   // Account
                    columns.RelativeColumn(3.0f);   // Description

                    columns.ConstantColumn(78);     // Cash In
                    columns.ConstantColumn(78);     // Cash Out
                    columns.ConstantColumn(92);     // Balance
                });


                // ----------------------------------------------------
                // TABLE HEADER
                // ----------------------------------------------------
                table.Header(header =>
                {
                    string[] titles =
                    {
                        "#",
                        "Date",
                        "Voucher",
                        "Type",
                        "Account",
                        "Description",
                        "Cash In",
                        "Cash Out",
                        "Balance"
                    };


                    for (int i = 0; i < titles.Length; i++)
                    {
                        int index = i;

                        header.Cell()
                            .Background(HeaderBg)
                            .BorderBottom(1)
                            .BorderColor(White)
                            .PaddingVertical(6)
                            .PaddingHorizontal(4)
                            .Element(cell =>
                            {
                                if (index >= 6)
                                {
                                    cell.AlignRight()
                                        .Text(titles[index])
                                        .FontColor(White)
                                        .Bold()
                                        .FontSize(8);
                                }
                                else if (index == 0)
                                {
                                    cell.AlignCenter()
                                        .Text(titles[index])
                                        .FontColor(White)
                                        .Bold()
                                        .FontSize(8);
                                }
                                else
                                {
                                    cell.AlignLeft()
                                        .Text(titles[index])
                                        .FontColor(White)
                                        .Bold()
                                        .FontSize(8);
                                }
                            });
                    }
                });


                // ----------------------------------------------------
                // OPENING BALANCE ROW
                // ----------------------------------------------------
                AddOpeningBalanceRow(
                    table,
                    openingBalance);


                // ----------------------------------------------------
                // TRANSACTION ROWS
                // ----------------------------------------------------
                foreach (CashbookRow row in rows)
                {
                    AddTransactionRow(
                        table,
                        row);
                }


                // ----------------------------------------------------
                // TOTALS
                // ----------------------------------------------------
                AddTotalsRow(
                    table,
                    totalCashIn,
                    totalCashOut,
                    closingBalance);
            });
        }


        // ============================================================
        // OPENING BALANCE ROW
        // ============================================================
        private static void AddOpeningBalanceRow(
            TableDescriptor table,
            decimal openingBalance)
        {
            string bg = OpeningBg;


            void Cell(Action<IContainer> content)
            {
                table.Cell()
                    .Background(bg)
                    .BorderBottom(1)
                    .BorderColor(BorderGrey)
                    .PaddingVertical(5)
                    .PaddingHorizontal(4)
                    .Element(content);
            }


            // #
            Cell(c =>
                c.AlignCenter()
                    .Text("")
                    .FontSize(8));


            // DATE
            Cell(c =>
                c.Text("")
                    .FontSize(8));


            // VOUCHER
            Cell(c =>
                c.Text("")
                    .FontSize(8));


            // TYPE
            Cell(c =>
                c.Text("Opening Balance")
                    .Bold()
                    .FontColor(OpeningBlue)
                    .FontSize(8));


            // ACCOUNT
            Cell(c =>
                c.Text("Cash Accounts")
                    .Bold()
                    .FontColor(OpeningBlue)
                    .FontSize(8));


            // DESCRIPTION
            Cell(c =>
                c.Text("Brought Forward / Opening Balance")
                    .Italic()
                    .FontColor(OpeningBlue)
                    .FontSize(8));


            // CASH IN
            Cell(c =>
                c.AlignRight()
                    .Text("-")
                    .FontSize(8));


            // CASH OUT
            Cell(c =>
                c.AlignRight()
                    .Text("-")
                    .FontSize(8));


            // BALANCE
            Cell(c =>
                c.AlignRight()
                    .Text(FormatBalance(openingBalance))
                    .Bold()
                    .FontColor(
                        openingBalance < 0
                            ? OutRed
                            : OpeningBlue)
                    .FontSize(8));
        }


        // ============================================================
        // TRANSACTION ROW
        // ============================================================
        private static void AddTransactionRow(
            TableDescriptor table,
            CashbookRow row)
        {
            string background =
                row.SrNo % 2 == 0
                    ? RowAlt
                    : White;


            void Cell(Action<IContainer> content)
            {
                table.Cell()
                    .Background(background)
                    .BorderBottom(1)
                    .BorderColor(BorderGrey)
                    .PaddingVertical(4.5f)
                    .PaddingHorizontal(4)
                    .Element(content);
            }


            // --------------------------------------------------------
            // SERIAL
            // --------------------------------------------------------
            Cell(c =>
                c.AlignCenter()
                    .Text(row.SrNo.ToString())
                    .FontSize(7.5f));


            // --------------------------------------------------------
            // DATE
            // --------------------------------------------------------
            Cell(c =>
                c.Text(row.Date ?? "")
                    .FontSize(7.5f));


            // --------------------------------------------------------
            // VOUCHER
            // --------------------------------------------------------
            string voucher =
                string.IsNullOrWhiteSpace(row.VoucherNo)
                    ? ""
                    : "#" + row.VoucherNo.Trim();


            Cell(c =>
                c.Text(voucher)
                    .FontSize(7.5f));


            // --------------------------------------------------------
            // TYPE
            // --------------------------------------------------------
            Cell(c =>
                c.Text(row.Type ?? "")
                    .FontSize(7.5f));


            // --------------------------------------------------------
            // ACCOUNT
            // --------------------------------------------------------
            Cell(c =>
                c.Text(row.AccountName ?? "")
                    .FontSize(7.5f));


            // --------------------------------------------------------
            // DESCRIPTION
            // --------------------------------------------------------
            Cell(c =>
                c.Text(row.Description ?? "")
                    .FontSize(7.5f));


            // --------------------------------------------------------
            // CASH IN
            // --------------------------------------------------------
            Cell(c =>
            {
                string value =
                    row.CashIn == 0
                        ? "-"
                        : row.CashIn.ToString("N0");

                c.AlignRight()
                    .Text(value)
                    .FontColor(
                        row.CashIn != 0
                            ? InGreen
                            : TextDark)
                    .FontSize(7.5f);
            });


            // --------------------------------------------------------
            // CASH OUT
            // --------------------------------------------------------
            Cell(c =>
            {
                string value =
                    row.CashOut == 0
                        ? "-"
                        : row.CashOut.ToString("N0");

                c.AlignRight()
                    .Text(value)
                    .FontColor(
                        row.CashOut != 0
                            ? OutRed
                            : TextDark)
                    .FontSize(7.5f);
            });


            // --------------------------------------------------------
            // BALANCE
            // --------------------------------------------------------
            Cell(c =>
                c.AlignRight()
                    .Text(FormatBalance(row.Balance))
                    .Bold()
                    .FontColor(
                        row.Balance < 0
                            ? OutRed
                            : InGreen)
                    .FontSize(7.5f));
        }


        // ============================================================
        // TOTALS ROW
        // ============================================================
        private static void AddTotalsRow(
            TableDescriptor table,
            decimal totalCashIn,
            decimal totalCashOut,
            decimal closingBalance)
        {
            void Cell(
                Action<IContainer> content,
                int columnSpan = 1)
            {
                table.Cell()
                    .ColumnSpan((uint)columnSpan)
                    .Background(HeaderBg)
                    .PaddingVertical(6)
                    .PaddingHorizontal(5)
                    .Element(content);
            }


            // --------------------------------------------------------
            // LABEL
            // --------------------------------------------------------
            Cell(c =>
                c.AlignRight()
                    .Text("PERIOD TOTALS")
                    .FontColor(White)
                    .Bold()
                    .FontSize(8),
                6);


            // --------------------------------------------------------
            // CASH IN
            // --------------------------------------------------------
            Cell(c =>
                c.AlignRight()
                    .Text(
                        totalCashIn == 0
                            ? "-"
                            : totalCashIn.ToString("N0"))
                    .FontColor("#82E0AA")
                    .Bold()
                    .FontSize(8));


            // --------------------------------------------------------
            // CASH OUT
            // --------------------------------------------------------
            Cell(c =>
                c.AlignRight()
                    .Text(
                        totalCashOut == 0
                            ? "-"
                            : totalCashOut.ToString("N0"))
                    .FontColor("#F1948A")
                    .Bold()
                    .FontSize(8));


            // --------------------------------------------------------
            // CLOSING BALANCE
            // --------------------------------------------------------
            Cell(c =>
                c.AlignRight()
                    .Text(FormatBalance(closingBalance))
                    .FontColor(
                        closingBalance < 0
                            ? "#F1948A"
                            : "#82E0AA")
                    .Bold()
                    .FontSize(8));
        }


        // ============================================================
        // FOOTER
        // ============================================================
        private static void ComposeFooter(
            IContainer container)
        {
            container
                .BorderTop(1)
                .BorderColor(BorderGrey)
                .PaddingTop(5)
                .Row(row =>
                {
                    row.RelativeItem()
                        .Text("EasyBiz — Accounting Software")
                        .FontSize(7.5f)
                        .FontColor("#7F8C8D");


                    row.RelativeItem()
                        .AlignCenter()
                        .Text("Computer-generated report")
                        .FontSize(7.5f)
                        .FontColor("#7F8C8D")
                        .Italic();


                    row.RelativeItem()
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Page ")
                                .FontSize(7.5f)
                                .FontColor("#7F8C8D");

                            text.CurrentPageNumber()
                                .FontSize(7.5f)
                                .FontColor("#7F8C8D");

                            text.Span(" of ")
                                .FontSize(7.5f)
                                .FontColor("#7F8C8D");

                            text.TotalPages()
                                .FontSize(7.5f)
                                .FontColor("#7F8C8D");
                        });
                });
        }


        // ============================================================
        // FORMAT BALANCE
        // ============================================================
        private static string FormatBalance(
            decimal balance)
        {
            if (balance < 0)
            {
                return $"{Math.Abs(balance):N0} OD";
            }

            return balance.ToString("N0");
        }
    }
}