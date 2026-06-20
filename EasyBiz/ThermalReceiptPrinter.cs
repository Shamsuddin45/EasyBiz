using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EasyBiz
{
    /// <summary>One printable line item on the receipt.</summary>
    public class ReceiptItem
    {
        public string ProductName { get; set; } = "";
        public decimal Qty { get; set; }
        public decimal Weight { get; set; }
        public string Unit { get; set; } = "";
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }

    /// <summary>Everything needed to render one receipt.</summary>
    public class ReceiptData
    {
        public string ShopName { get; set; } = "EasyBiz";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public int VoucherNo { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public string CustomerName { get; set; } = "";
        public string PaymentMode { get; set; } = "";
        public List<ReceiptItem> Items { get; set; } = new();
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public string FooterNote { get; set; } = "Thank you for your business!";
    }

    /// <summary>
    /// Prints a narrow "till roll" receipt for a Sale Invoice using the printer's
    /// ordinary Windows driver — no ESC/POS commands required. Works with any
    /// thermal/POS printer installed as a regular Windows printer (Epson TM-T,
    /// Star, Xprinter, Bixolon, etc.), as well as a generic inkjet/laser for testing.
    /// </summary>
    public static class ThermalReceiptPrinter
    {
        /// <summary>Roll width in mm — 80 is most common, 58 for smaller registers.</summary>
        public static int PaperWidthMM = 80;

        /// <summary>Leave blank to use the Windows default printer.</summary>
        public static string PrinterName = "";

        private static readonly Font FontTitle = new("Consolas", 12f, FontStyle.Bold);
        private static readonly Font FontBold = new("Consolas", 9.5f, FontStyle.Bold);
        private static readonly Font FontNormal = new("Consolas", 9f);
        private static readonly Font FontSmall = new("Consolas", 8f);

        /// <summary>
        /// Prints the receipt. Pass preview:true while you're tuning the layout —
        /// it opens a PrintPreviewDialog instead of sending to the printer.
        /// </summary>
        public static void Print(ReceiptData data, bool preview = false)
        {
            using var doc = new PrintDocument();

            if (!string.IsNullOrWhiteSpace(PrinterName))
                doc.PrinterSettings.PrinterName = PrinterName;

            int widthHundredths = MmToHundredthsInch(PaperWidthMM);

            // Most thermal/POS drivers auto-feed & auto-cut based on the actual
            // content drawn, not the nominal page length, so a generous fixed
            // height is fine — it will not print a strip of blank paper.
            int heightHundredths = 1200; // 12" — comfortably covers a long item list

            doc.DefaultPageSettings.PaperSize =
                new PaperSize("EasyBizReceipt", widthHundredths, heightHundredths);
            doc.DefaultPageSettings.Margins = new Margins(8, 8, 8, 8);
            doc.OriginAtMargins = true;

            doc.PrintPage += (s, e) => DrawReceipt(e, data);

            if (preview)
            {
                using var pv = new PrintPreviewDialog
                {
                    Document = doc,
                    Width = 480,
                    Height = 720,
                    StartPosition = FormStartPosition.CenterScreen
                };
                pv.ShowDialog();
            }
            else
            {
                doc.Print();
            }
        }

        private static int MmToHundredthsInch(int mm) => (int)Math.Round(mm / 25.4 * 100);

        private static void DrawReceipt(PrintPageEventArgs e, ReceiptData data)
        {
            var g = e.Graphics!;
            float width = e.MarginBounds.Width;
            float left = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            void Center(string text, Font font)
            {
                var sz = g.MeasureString(text, font);
                g.DrawString(text, font, Brushes.Black, left + Math.Max(0, (width - sz.Width) / 2), y);
                y += sz.Height;
            }

            void Line(string text, Font font)
            {
                var sz = g.MeasureString(text, font, (int)width);
                g.DrawString(text, font, Brushes.Black, new RectangleF(left, y, width, sz.Height));
                y += sz.Height;
            }

            void Cols(string l, string r, Font font)
            {
                g.DrawString(l, font, Brushes.Black, left, y);
                var rSz = g.MeasureString(r, font);
                g.DrawString(r, font, Brushes.Black, left + width - rSz.Width, y);
                y += font.GetHeight(g);
            }

            void Rule()
            {
                y += 2;
                g.DrawLine(Pens.Black, left, y, left + width, y);
                y += 5;
            }

            // ── Header ───────────────────────────────────────────────
            Center(data.ShopName, FontTitle);
            if (!string.IsNullOrWhiteSpace(data.Address)) Center(data.Address, FontSmall);
            if (!string.IsNullOrWhiteSpace(data.Phone)) Center("Tel: " + data.Phone, FontSmall);
            y += 4;
            Rule();

            // ── Invoice meta ─────────────────────────────────────────
            Cols($"Invoice #{data.VoucherNo}", data.InvoiceDate.ToString("dd-MMM-yy HH:mm"), FontNormal);
            if (!string.IsNullOrWhiteSpace(data.CustomerName))
                Line($"Customer: {data.CustomerName}", FontNormal);
            if (!string.IsNullOrWhiteSpace(data.PaymentMode))
                Line($"Payment : {data.PaymentMode}", FontNormal);
            Rule();

            // ── Items ────────────────────────────────────────────────
            foreach (var item in data.Items)
            {
                Line(item.ProductName, FontBold);
                string qtyPart = item.Qty > 0
                    ? $"{item.Qty:N2} {item.Unit} x {item.Rate:N2}"
                    : $"{item.Weight:N3} x {item.Rate:N2}";
                Cols(qtyPart, item.Amount.ToString("N2"), FontNormal);
            }
            Rule();

            // ── Totals ───────────────────────────────────────────────
            Cols("Sub Total", data.Total.ToString("N2"), FontNormal);
            if (data.Discount > 0)
                Cols("Discount", data.Discount.ToString("N2"), FontNormal);
            y += 2;
            Cols("NET TOTAL", data.NetAmount.ToString("N2"), FontTitle);
            y += 6;
            Rule();

            // ── Footer ───────────────────────────────────────────────
            if (!string.IsNullOrWhiteSpace(data.FooterNote))
                Center(data.FooterNote, FontSmall);

            e.HasMorePages = false;
        }
    }
}