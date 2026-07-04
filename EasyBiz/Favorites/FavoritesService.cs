using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EasyBiz
{
    public static class FavoritesService
    {
        // Returns favourite module keys in saved order.
        public static List<string> GetFavoriteKeys()
        {
            var keys = new List<string>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ModuleKey FROM UserFavorites ORDER BY SortOrder";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            keys.Add(reader.GetString(0));
                    }
                }
            }
            return keys;
        }

        // Replaces the whole favourites list with the given keys, in order.
        public static void SaveFavorites(List<string> orderedKeys)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    using (var del = conn.CreateCommand())
                    {
                        del.Transaction = tx;
                        del.CommandText = "DELETE FROM UserFavorites";
                        del.ExecuteNonQuery();
                    }

                    for (int i = 0; i < orderedKeys.Count; i++)
                    {
                        using (var ins = conn.CreateCommand())
                        {
                            ins.Transaction = tx;
                            ins.CommandText = "INSERT INTO UserFavorites (ModuleKey, SortOrder) VALUES ($key, $order)";
                            ins.Parameters.AddWithValue("$key", orderedKeys[i]);
                            ins.Parameters.AddWithValue("$order", i);
                            ins.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                }
            }
        }
    }
}