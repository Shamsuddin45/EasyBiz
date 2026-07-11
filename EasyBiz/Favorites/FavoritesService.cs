using System.Collections.Generic;

namespace EasyBiz
{
    public static class FavoritesService
    {
        public static List<string> GetFavoriteKeys() => GetFavoriteKeys(CurrentUser.UserId);

        public static List<string> GetFavoriteKeys(int userId)
        {
            var keys = new List<string>();
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT module_key FROM user_favorites WHERE user_id = @u ORDER BY sort_order";
                cmd.Parameters.AddWithValue("@u", userId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        keys.Add(reader.GetString(0));
                }
            }
            return keys;
        }

        // New Helper: Quick check to see if the user has any favorites at all
        public static bool HasFavorites() => HasFavorites(CurrentUser.UserId);

        public static bool HasFavorites(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(1) FROM user_favorites WHERE user_id = @u";
                cmd.Parameters.AddWithValue("@u", userId);
                // Convert.ToInt32 handles potential DB nulls safely, though COUNT always returns a number
                return System.Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public static void SaveFavorites(List<string> orderedKeys) => SaveFavorites(CurrentUser.UserId, orderedKeys);

        public static void SaveFavorites(int userId, List<string> orderedKeys)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                using (var del = conn.CreateCommand())
                {
                    del.Transaction = tx;
                    del.CommandText = "DELETE FROM user_favorites WHERE user_id = @u";
                    del.Parameters.AddWithValue("@u", userId);
                    del.ExecuteNonQuery();
                }

                if (orderedKeys != null && orderedKeys.Count > 0)
                {
                    // Reusing a single command object is much faster and cleaner
                    using (var ins = conn.CreateCommand())
                    {
                        ins.Transaction = tx;
                        // Fixed: Swapped '$' syntax back to '@' to match your DELETE/SELECT statements
                        ins.CommandText = "INSERT INTO user_favorites (user_id, module_key, sort_order) VALUES (@u, @key, @order)";

                        var uParam = ins.Parameters.Add("@u", (Microsoft.Data.Sqlite.SqliteType)System.Data.DbType.Int32);
                        var keyParam = ins.Parameters.Add("@key", (Microsoft.Data.Sqlite.SqliteType)System.Data.DbType.String);
                        var orderParam = ins.Parameters.Add("@order", (Microsoft.Data.Sqlite.SqliteType)System.Data.DbType.Int32);

                        uParam.Value = userId;

                        for (int i = 0; i < orderedKeys.Count; i++)
                        {
                            keyParam.Value = orderedKeys[i];
                            orderParam.Value = i;
                            ins.ExecuteNonQuery();
                        }
                    }
                }

                tx.Commit();
            }
        }
    }
}