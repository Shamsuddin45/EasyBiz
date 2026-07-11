using System.Collections.Generic;

namespace EasyBiz
{
    public static class FavoritesService
    {
        // Convenience overloads default to the currently logged-in user,
        // so existing call sites (MainForm, Settings) don't need to change.
        public static List<string> GetFavoriteKeys() => GetFavoriteKeys(CurrentUser.UserId);

        public static List<string> GetFavoriteKeys(int userId)
        {
            var keys = new List<string>();
            using (var conn = DatabaseHelper.GetConnection())
            {
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
            }
            return keys;
        }

        // Replaces the current user's whole favourites list with the given keys, in order.
        public static void SaveFavorites(List<string> orderedKeys) => SaveFavorites(CurrentUser.UserId, orderedKeys);

        public static void SaveFavorites(int userId, List<string> orderedKeys)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var tx = conn.BeginTransaction())
                {
                    using (var del = conn.CreateCommand())
                    {
                        del.Transaction = tx;
                        del.CommandText = "DELETE FROM user_favorites WHERE user_id = @u";
                        del.Parameters.AddWithValue("@u", userId);
                        del.ExecuteNonQuery();
                    }

                    for (int i = 0; i < orderedKeys.Count; i++)
                    {
                        using (var ins = conn.CreateCommand())
                        {
                            ins.Transaction = tx;
                            ins.CommandText = "INSERT INTO user_favorites (user_id, module_key, sort_order) VALUES ($u, $key, $order)";
                            ins.Parameters.AddWithValue("$u", userId);
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