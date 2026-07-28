using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EasyBiz
{
    public class LocalHistoryPredictor
    {
        public List<(string Description, int Count)> GetTopMatches(PredictionContext ctx, int limit = 5)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var sql = @"
            SELECT description, COUNT(*) as cnt
            FROM transactions
            WHERE account_id = @accountId
              AND transaction_type = @type
              AND description IS NOT NULL AND description <> ''
            GROUP BY description
            ORDER BY cnt DESC, MAX(transaction_date) DESC
            LIMIT @limit";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@accountId", ctx.AccountId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@type", ctx.TransactionType);
            cmd.Parameters.AddWithValue("@limit", limit);

            var results = new List<(string, int)>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                results.Add((reader.GetString(0), reader.GetInt32(1)));

            return results;
        }
    }
    }