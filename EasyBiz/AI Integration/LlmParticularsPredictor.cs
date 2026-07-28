using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBiz.AI_Integration
{
    public class LlmParticularsPredictor
    {
        public async Task<string> PredictAsync(PredictionContext ctx, List<string> priorExamples)
        {
            var accountName = GetAccountName(ctx.AccountId);

            var prompt = $@"Suggest a short, professional accounting transaction description in easy english (max 12 words). 
Reply with ONLY the text, no quotes, no explanation.

Transaction type: {ctx.TransactionType}
Account: {accountName} Do not write account name because it is already choosed by user
Amount: {ctx.Amount:N2}
Date: {ctx.Date:yyyy-MM-dd} Do not write dates because user already choosed it
{(priorExamples.Any() ? "Past descriptions used for this account:\n- " + string.Join("\n- ", priorExamples) : "")}";

            var provider = AIProviderFactory.Create();
            try { return await provider.CompleteAsync(prompt); }
            catch { return null; } // no key set, provider unreachable, etc. — fail quietly, local match already covers most cases
        }

        private static string GetAccountName(int? accountId)
        {
            if (accountId == null) return "";

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT account_name FROM accounts WHERE account_id = @id";
            cmd.Parameters.AddWithValue("@id", accountId.Value);
            var result = cmd.ExecuteScalar();
            return result?.ToString() ?? "";
        }
    }
}
