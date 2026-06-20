using EasyBiz;
using Microsoft.Data.Sqlite; // or whatever DB driver you use
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// ============================================================
//  MODELS
// ============================================================

public enum AccountCategory
{
    Cash,
    Banks,
    Assets,
    Capital,
    Brokers,
    PersonalLedgers,
    Payables,
    Receivables,
    Employees,
    Expenses,
    Others
}

public record TrialBalanceEntry(
    int AccountId,
    string AccountName,
    AccountCategory Category,
    decimal? Debit,
    decimal? Credit
);

public class TrialBalanceReport
{
    public required string CompanyName { get; init; }
    public required string ReportTitle { get; init; }
    public required DateOnly PeriodEndDate { get; init; }
    public string? PreparedBy { get; init; }
    public string Currency { get; init; } = "PKR";
    public required IReadOnlyList<TrialBalanceEntry> Entries { get; init; }

    public decimal TotalDebits => Entries.Sum(e => e.Debit ?? 0m);
    public decimal TotalCredits => Entries.Sum(e => e.Credit ?? 0m);
    public bool IsBalanced => TotalDebits == TotalCredits;

    public IEnumerable<IGrouping<AccountCategory, TrialBalanceEntry>> GroupedEntries =>
        Entries.GroupBy(e => e.Category);

    /// <summary>
    /// Loads all accounts from the database and maps current_balance
    /// to Debit or Credit based on account_type convention:
    ///   Debit-normal  : Cash, Banks, Assets, Receivables, Expenses
    ///   Credit-normal : Capital, Brokers, PersonalLedgers, Payables, Employees, Others
    /// </summary>
    public static TrialBalanceReport LoadFromDatabase(
        string companyName,
        string reportTitle,
        DateOnly periodEndDate,
        string? preparedBy = null,
        string currency = "PKR")
    {
        var entries = new List<TrialBalanceEntry>();

        using var connection = DatabaseHelper.GetConnection();
        using var command = connection.CreateCommand();
        command.CommandText =
            "SELECT account_id, account_name, account_type, current_balance " +
            "FROM accounts ORDER BY account_id";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string type = reader.GetString(2);
            decimal balance = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3);

            AccountCategory cat = ParseCategory(type);

            // current_balance convention (derived from PostEntry logic):
            //   Cash/Assets/Expenses/Others  → balance += amount on debit, so positive = Debit
            //   Payables/Receivables/Employees/Capital/Brokers/PersonalLedgers
            //                                → balance -= amount on credit, so negative = Credit
            //
            // Rule: positive balance → Debit column, negative balance → Credit column.
            // Zero balance → omit both (show dashes).
            decimal? debit = balance > 0 ? balance : (decimal?)null;
            decimal? credit = balance < 0 ? Math.Abs(balance) : (decimal?)null;

            entries.Add(new TrialBalanceEntry(id, name, cat, debit, credit));
        }

        return new TrialBalanceReport
        {
            CompanyName = companyName,
            ReportTitle = reportTitle,
            PeriodEndDate = periodEndDate,
            PreparedBy = preparedBy,
            Currency = currency,
            Entries = entries
        };
    }

    private static AccountCategory ParseCategory(string type) => type switch
    {
        "Cash" => AccountCategory.Cash,
        "Banks" => AccountCategory.Banks,
        "Assets" => AccountCategory.Assets,
        "Capital" => AccountCategory.Capital,
        "Brokers" => AccountCategory.Brokers,
        "Personal Ledgers" => AccountCategory.PersonalLedgers,
        "Payables" => AccountCategory.Payables,
        "Receivables" => AccountCategory.Receivables,
        "Employees" => AccountCategory.Employees,
        "Expenses" => AccountCategory.Expenses,
        _ => AccountCategory.Others
    };


}

// ============================================================
//  DOCUMENT
// ============================================================

/// <summary>
/// QuestPDF document that renders a full Trial Balance PDF,
/// listing every individual account (not just category totals).
///
/// Simplest usage — load straight from DB:
///   QuestPDF.Settings.License = LicenseType.Community;
///   var report = TrialBalanceReport.LoadFromDatabase("EasyBiz", "Trial Balance",
///                    new DateOnly(...), "Finance Dept", "PKR");
///   new TrialBalanceDocument(report).GeneratePdf(path);
///
/// Or pass your own entries manually (original usage still works):
///   var report = new TrialBalanceReport { ..., Entries = [ ... ] };
///   new TrialBalanceDocument(report).GeneratePdf(path);
/// </summary>
public class TrialBalanceDocument : IDocument
{
    // ── Palette ───────────────────────────────────────────────────────────
    private const string HeaderBg = "#1E3A5F";
    private const string HeaderFg = "#FFFFFF";
    private const string HeaderMuted = "#B0C4D8";
    private const string SectionBg = "#D8E4F0";
    private const string SectionFg = "#1E3A5F";
    private const string AltRowBg = "#F7F9FC";
    private const string BorderColor = "#C5D0DE";
    private const string SubtotalBg = "#EBF0F7";
    private const string TotalsBg = "#1E3A5F";
    private const string TotalsFg = "#FFFFFF";
    private const string GreenColor = "#1A7F37";
    private const string RedColor = "#C0392B";

    // ── Column widths ─────────────────────────────────────────────────────
    // A4 (595pt) - 35pt margins x2 = 525pt usable, minus 6pt padding x2 = 513pt
    // Fixed cols: 75 + 100 + 100 = 275pt → ColName gets remaining ~238pt via RelativeItem
    private const float ColCode = 75f;
    private const float ColDebit = 100f;
    private const float ColCredit = 100f;

    private readonly TrialBalanceReport _report;

    public TrialBalanceDocument(TrialBalanceReport report) => _report = report;

    // ── IDocument ─────────────────────────────────────────────────────────
    public DocumentMetadata GetMetadata() => new()
    {
        Title = _report.ReportTitle,
        Author = _report.PreparedBy ?? "Accounting System",
        Subject = $"Trial Balance – {_report.PeriodEndDate:MMMM d, yyyy}",
        Creator = "TrialBalanceDocument / QuestPDF"
    };

    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(35, Unit.Point);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(ts => ts.FontFamily("Arial").FontSize(9));

            page.Header().Element(Header);
            page.Content().Element(Content);
            page.Footer().Element(Footer);
        });
    }

    // ── Header ────────────────────────────────────────────────────────────
    private void Header(IContainer c) =>
        c.Background(HeaderBg).Padding(14).Column(col =>
        {
            col.Item()
               .Text(_report.CompanyName)
               .FontColor(HeaderFg).FontSize(16).Bold();

            col.Item().PaddingTop(2)
               .Text(_report.ReportTitle)
               .FontColor(HeaderFg).FontSize(11);

            col.Item().PaddingTop(6).Row(row =>
            {
                row.AutoItem()
                   .Text($"Period ending: {_report.PeriodEndDate:MMMM d, yyyy}")
                   .FontColor(HeaderMuted).FontSize(8);

                row.RelativeItem();

                if (_report.PreparedBy is not null)
                    row.AutoItem()
                       .Text($"Prepared by: {_report.PreparedBy}")
                       .FontColor(HeaderMuted).FontSize(8);
            });
        });

    // ── Content ───────────────────────────────────────────────────────────
    private void Content(IContainer c) =>
        c.PaddingVertical(8).Column(col =>
        {
            col.Item().Element(ColumnHeaders);
            col.Item().Height(1).Background(BorderColor);

            bool alt = false;
            foreach (var group in _report.GroupedEntries)
            {
                var key = group.Key;
                var accounts = group.ToList();

                // Category header
                col.Item().Element(c => SectionHeader(c, key));

                // Every individual account in this category
                foreach (var entry in accounts)
                {
                    bool isAlt = alt;
                    col.Item().Element(c => EntryRow(c, entry, isAlt));
                    alt = !alt;
                }

                // Category subtotal
                col.Item().Element(c => CategorySubtotal(c, key, accounts));
                col.Item().Height(1).Background(BorderColor);
            }

            col.Item().PaddingTop(4).Element(GrandTotals);
            col.Item().PaddingTop(8).Element(BalanceBanner);
        });

    // ── Column headers ────────────────────────────────────────────────────
    private void ColumnHeaders(IContainer c) =>
        c.Background(SectionBg).Padding(5).Row(row =>
        {
            row.ConstantItem(ColCode).Text("Acc. No").Bold().FontColor(SectionFg);
            row.RelativeItem().Text("Account Name").Bold().FontColor(SectionFg);
            row.ConstantItem(ColDebit).AlignRight()
               .Text($"Debit ({_report.Currency})").Bold().FontColor(SectionFg);
            row.ConstantItem(ColCredit).AlignRight()
               .Text($"Credit ({_report.Currency})").Bold().FontColor(SectionFg);
        });

    // ── Section header ────────────────────────────────────────────────────
    private static void SectionHeader(IContainer c, AccountCategory cat) =>
        c.Background(SectionBg).PaddingVertical(4).PaddingHorizontal(5)
         .Text(CategoryLabel(cat)).Bold().FontSize(8.5f).FontColor(SectionFg);

    // ── Individual account row ────────────────────────────────────────────
    private static void EntryRow(IContainer c, TrialBalanceEntry e, bool alt) =>
        c.Background(alt ? AltRowBg : Colors.White)
         .BorderBottom(0.5f).BorderColor(BorderColor)
         .Padding(4).Row(row =>
         {
             row.ConstantItem(ColCode)
                .Text(e.AccountId.ToString())
                .FontColor("#5A6978");

             row.RelativeItem()
                .Text(e.AccountName);

             row.ConstantItem(ColDebit).AlignRight()
                .Text(e.Debit.HasValue ? Fmt(e.Debit.Value) : "–")
                .FontColor(e.Debit.HasValue ? Colors.Black : "#BBBBBB");

             row.ConstantItem(ColCredit).AlignRight()
                .Text(e.Credit.HasValue ? Fmt(e.Credit.Value) : "–")
                .FontColor(e.Credit.HasValue ? Colors.Black : "#BBBBBB");
         });

    // ── Category subtotal ─────────────────────────────────────────────────
    private static void CategorySubtotal(
        IContainer c, AccountCategory cat, IEnumerable<TrialBalanceEntry> entries)
    {
        decimal d = entries.Sum(e => e.Debit ?? 0m);
        decimal cr = entries.Sum(e => e.Credit ?? 0m);

        c.Background(SubtotalBg).Padding(4).Row(row =>
        {
            row.ConstantItem(ColCode);  // empty spacer
            row.RelativeItem().AlignRight().PaddingRight(8)
               .Text($"Subtotal – {CategoryLabel(cat)}")
               .Italic().FontSize(8).FontColor(SectionFg);

            row.ConstantItem(ColDebit).AlignRight()
               .Text(d > 0 ? Fmt(d) : "–").Bold().FontSize(8);

            row.ConstantItem(ColCredit).AlignRight()
               .Text(cr > 0 ? Fmt(cr) : "–").Bold().FontSize(8);
        });
    }

    // ── Grand totals ──────────────────────────────────────────────────────
    private void GrandTotals(IContainer c) =>
        c.Background(TotalsBg).Padding(6).Row(row =>
        {
            row.ConstantItem(ColCode);  // empty spacer
            row.RelativeItem()
               .Text("GRAND TOTAL").Bold().FontSize(10).FontColor(TotalsFg);

            row.ConstantItem(ColDebit).AlignRight()
               .Text(Fmt(_report.TotalDebits)).Bold().FontSize(10).FontColor(TotalsFg);

            row.ConstantItem(ColCredit).AlignRight()
               .Text(Fmt(_report.TotalCredits)).Bold().FontSize(10).FontColor(TotalsFg);
        });

    // ── Balance banner ────────────────────────────────────────────────────
    private void BalanceBanner(IContainer c)
    {
        bool ok = _report.IsBalanced;
        string msg = ok
            ? "✓  Trial balance is IN BALANCE"
            : $"✗  OUT OF BALANCE — Difference: {Fmt(Math.Abs(_report.TotalDebits - _report.TotalCredits))}";

        c.Border(1).BorderColor(ok ? GreenColor : RedColor)
         .Background(ok ? "#EAFAF1" : "#FDEDEC")
         .Padding(8)
         .Text(msg).Bold().FontSize(10).FontColor(ok ? GreenColor : RedColor);
    }

    // ── Footer ────────────────────────────────────────────────────────────
    private static void Footer(IContainer c) =>
        c.BorderTop(0.5f).BorderColor(BorderColor).PaddingTop(4).Row(row =>
        {
            row.RelativeItem()
               .Text($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}")
               .FontSize(7.5f).FontColor("#888888");

            row.AutoItem().Text(t =>
            {
                t.Span("Page ").FontSize(7.5f).FontColor("#888888");
                t.CurrentPageNumber().FontSize(7.5f).FontColor("#888888");
                t.Span(" of ").FontSize(7.5f).FontColor("#888888");
                t.TotalPages().FontSize(7.5f).FontColor("#888888");
            });
        });

    // ── Helpers ───────────────────────────────────────────────────────────
    private static string Fmt(decimal v) => v.ToString("N2");

    private static string CategoryLabel(AccountCategory c) => c switch
    {
        AccountCategory.Cash => "Cash",
        AccountCategory.Banks => "Banks",
        AccountCategory.Assets => "Assets",
        AccountCategory.Capital => "Capital",
        AccountCategory.Brokers => "Brokers",
        AccountCategory.PersonalLedgers => "Personal Ledgers",
        AccountCategory.Payables => "Payables",
        AccountCategory.Receivables => "Receivables",
        AccountCategory.Employees => "Employees",
        AccountCategory.Expenses => "Expenses",
        AccountCategory.Others => "Others",
        _ => c.ToString()
    };
}