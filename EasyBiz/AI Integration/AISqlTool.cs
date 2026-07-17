using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace EasyBiz
{
    /// <summary>
    /// Shared, provider-agnostic pieces of the AI reporting assistant:
    /// the system prompt describing the schema/rules, and the sandboxed
    /// read-only SQL executor the "run_sql_query" tool calls into.
    /// Used by every IAIChatProvider (Gemini, OpenAI, Groq, Ollama, ...)
    /// so all providers see the same schema and the same safety rules.
    /// </summary>
    public static class AISqlTool
    {
        public const string ToolName = "run_sql_query";

        public const string ToolDescription =
            "Executes a single read-only SELECT statement against the EasyBiz SQLite database and returns the matching rows as JSON. Only SELECT (or a read-only WITH ... SELECT) statements are permitted — no writes.";

        public static string BuildSystemPrompt()
        {
            return $@"You are an AI accounting assistant embedded inside EasyBiz, a desktop accounting & inventory application. You answer the user's questions about their own business data (sales, purchases, stock, accounts, cash) by calling the run_sql_query tool to fetch real data from the SQLite database — never guess or invent numbers.

Rules:
- ALWAYS call run_sql_query to fetch real data before answering any question that depends on data in the database.
- Only SELECT statements are allowed. Never attempt INSERT/UPDATE/DELETE/DROP/ALTER/PRAGMA/ATTACH.
- Keep queries efficient: use WHERE / GROUP BY / ORDER BY / LIMIT instead of pulling whole tables.
- Today's date is {DateTime.Now:yyyy-MM-dd} ({DateTime.Now:dddd}). Use this for words like 'today', 'this week', 'this month', 'yesterday'.
- Format money with thousands separators (e.g. 12,500). Don't invent a currency symbol.
- If a query returns no rows, say so plainly instead of making something up.
- Keep answers concise and business-friendly; use short bullet points for multi-row results.
- If a question is ambiguous (e.g. 'best selling' could mean quantity or revenue), pick the most sensible interpretation — usually quantity for 'most selling item' and revenue for 'top customer' — and briefly say which one you used.
- For 'most selling item' style questions, prefer summing sale_invoice_items.quantity (or .amount for revenue) grouped by product_name, joined to sale_invoices on voucher_no for the invoice_date filter, and excluding is_cancelled = 1.

Database schema (SQLite):

accounts(account_id INTEGER PK, account_name TEXT, account_type TEXT, address TEXT, mobile_number TEXT, opening_balance REAL, current_balance REAL, created_at DATETIME)
  -- account_type: Cash, Banks, Assets, Capital, Brokers, Personal Ledgers, Payables, Receivables, Employees, Expenses, Others

transactions(voucher_no INTEGER, transaction_id INTEGER PK, transaction_type TEXT, account_id INTEGER, account_name TEXT, description TEXT, debit REAL, credit REAL, transaction_date DATETIME, cheque_no TEXT)
  -- transaction_type: 'Cash Payment','Cash Receipt','Journal Voucher','Sale Invoice','Purchase Invoice','Bank Payment','Bank Receipt'
  -- each (voucher_no, transaction_type) has two or more double-entry legs

products(product_id INTEGER PK, product_name TEXT UNIQUE, description TEXT, unit TEXT, weight_unit TEXT, isUnit BOOLEAN, sale_rate REAL, purchase_rate REAL, current_qty REAL, current_weight REAL, min_stock_qty REAL, created_at DATETIME)

stock_movements(movement_id INTEGER PK, movement_date TEXT, movement_type TEXT, voucher_type TEXT, voucher_no INTEGER, product_id INTEGER, product_name TEXT, qty_in REAL, qty_out REAL, weight_in REAL, weight_out REAL, rate REAL, amount REAL, balance_qty REAL, balance_weight REAL)
  -- movement_type: 'Sale' or 'Purchase'; qty_out/weight_out for sales, qty_in/weight_in for purchases

sale_invoices(sale_id INTEGER PK, voucher_no INTEGER UNIQUE, invoice_date TEXT, account_id INTEGER, account_name TEXT, description TEXT, total_amount REAL, discount REAL, net_amount REAL, is_cancelled INTEGER, created_at DATETIME)
sale_invoice_items(item_id INTEGER PK, sale_id INTEGER, voucher_no INTEGER, product_id INTEGER, product_name TEXT, quantity REAL, weight REAL, weight_unit TEXT, rate REAL, amount REAL)

purchase_invoices(purchase_id INTEGER PK, voucher_no INTEGER UNIQUE, invoice_date TEXT, account_id INTEGER, account_name TEXT, description TEXT, total_amount REAL, discount REAL, net_amount REAL, is_cancelled INTEGER, created_at DATETIME)
purchase_invoice_items(item_id INTEGER PK, purchase_id INTEGER, voucher_no INTEGER, product_id INTEGER, product_name TEXT, quantity REAL, weight REAL, weight_unit TEXT, rate REAL, amount REAL)

cheques(cheque_id INTEGER PK, cheque_no TEXT, cheque_date TEXT, bank_account_id INTEGER, bank_account_name TEXT, party_account_id INTEGER, party_account_name TEXT, amount REAL, direction TEXT, status TEXT, description TEXT, cleared_date TEXT, created_at DATETIME)
  -- direction: 'Payable' or 'Receivable'; status: 'Issued','Cleared','Returned','Cancelled'
";
        }

        private static readonly string[] ForbiddenKeywords =
        {
            "insert", "update", "delete", "drop", "alter", "attach", "detach",
            "pragma", "vacuum", "create", "replace", "reindex", "trigger"
        };

        /// <summary>
        /// Runs a single, sandboxed, read-only SELECT against easybiz.db and
        /// returns the result (or an error) as a JSON string, ready to feed
        /// straight back to whichever model asked for it.
        /// </summary>
        public static string ExecuteReadOnlyQuery(string query)
        {
            try
            {
                string trimmed = (query ?? "").Trim().TrimEnd(';').Trim();
                if (string.IsNullOrWhiteSpace(trimmed))
                    return JsonSerializer.Serialize(new { error = "Empty query." });

                if (!trimmed.StartsWith("select", StringComparison.OrdinalIgnoreCase) &&
                    !trimmed.StartsWith("with", StringComparison.OrdinalIgnoreCase))
                {
                    return JsonSerializer.Serialize(new { error = "Only SELECT (or WITH ... SELECT) statements are allowed." });
                }

                if (trimmed.Contains(';'))
                    return JsonSerializer.Serialize(new { error = "Only a single statement is allowed (no semicolons)." });

                string lowered = trimmed.ToLowerInvariant();
                foreach (var word in ForbiddenKeywords)
                {
                    if (Regex.IsMatch(lowered, $@"\b{word}\b"))
                        return JsonSerializer.Serialize(new { error = $"Query contains a disallowed keyword: '{word}'." });
                }

                using var connection = DatabaseHelper.GetConnection();
                using var cmd = connection.CreateCommand();
                cmd.CommandText = trimmed;
                cmd.CommandTimeout = 10;

                using var reader = cmd.ExecuteReader();
                const int maxRows = 300;
                var rows = new List<Dictionary<string, object?>>();
                int colCount = reader.FieldCount;

                while (rows.Count < maxRows && reader.Read())
                {
                    var row = new Dictionary<string, object?>();
                    for (int i = 0; i < colCount; i++)
                    {
                        object val = reader.GetValue(i);
                        row[reader.GetName(i)] = val == DBNull.Value ? null : val;
                    }
                    rows.Add(row);
                }

                bool truncated = rows.Count == maxRows && reader.Read();

                return JsonSerializer.Serialize(new { row_count = rows.Count, truncated, rows });
            }
            catch (Exception ex)
            {
                // Feed the error back to the model as the tool result so it
                // can fix its own query instead of the app crashing.
                return JsonSerializer.Serialize(new { error = ex.Message });
            }
        }
    }
}
