using Microsoft.Data.Sqlite;

namespace EasyBiz
{
    /// <summary>
    /// Schema additions for the login / user-rights / per-user-favorites feature.
    /// Call UserRightsDatabaseHelper.InitializeUserTables() once at startup
    /// (wired into LoginForm's constructor and safe to call repeatedly).
    /// </summary>
    internal static class UserRightsDatabaseHelper
    {
        public static void InitializeUserTables()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS users (
                    user_id      INTEGER PRIMARY KEY AUTOINCREMENT,
                    username     TEXT NOT NULL UNIQUE,
                    password     TEXT NOT NULL,
                    full_name    TEXT,
                    is_admin     INTEGER NOT NULL DEFAULT 0,
                    is_active    INTEGER NOT NULL DEFAULT 1,
                    created_at   DATETIME DEFAULT CURRENT_TIMESTAMP
                );

                -- Per-user, per-module access flags. Absence of a row for a
                -- (user_id, module_key) pair means 'no access' for non-admins.
                -- Admin users bypass this table entirely (see UserRightsService).
                CREATE TABLE IF NOT EXISTS user_rights (
                    user_id      INTEGER NOT NULL,
                    module_key   TEXT    NOT NULL,
                    can_access   INTEGER NOT NULL DEFAULT 1,
                    PRIMARY KEY (user_id, module_key),
                    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
                );

                -- Per-user favorites list (replaces the old global UserFavorites table).
                CREATE TABLE IF NOT EXISTS user_favorites (
                    user_id      INTEGER NOT NULL,
                    module_key   TEXT    NOT NULL,
                    sort_order   INTEGER NOT NULL,
                    PRIMARY KEY (user_id, module_key),
                    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
                );

                -- Seed a default admin account (admin / admin123) the very first
                -- time this runs, so there is always a way to log in initially.
                INSERT INTO users (username, password, full_name, is_admin, is_active)
                SELECT 'admin', @adminPassword, 'Administrator', 1, 1
                WHERE NOT EXISTS (SELECT 1 FROM users);
            ";

            // Hash the default admin password
            string hashedAdminPassword = BCrypt.Net.BCrypt.HashPassword("admin123", workFactor: 12);
            cmd.Parameters.AddWithValue("@adminPassword", hashedAdminPassword);

            cmd.ExecuteNonQuery();

            // One-time migration: carry any existing global favorites over to the
            // default admin user so nobody's saved favorites just disappear.
            MigrateLegacyFavoritesIfAny(conn);
        }

        private static void MigrateLegacyFavoritesIfAny(SqliteConnection conn)
        {
            bool legacyTableExists;
            using (var check = conn.CreateCommand())
            {
                check.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='UserFavorites'";
                legacyTableExists = System.Convert.ToInt64(check.ExecuteScalar()) > 0;
            }
            if (!legacyTableExists) return;

            using var already = conn.CreateCommand();
            already.CommandText = "SELECT COUNT(*) FROM user_favorites";
            long alreadyMigrated = System.Convert.ToInt64(already.ExecuteScalar());
            if (alreadyMigrated > 0) return; // only migrate once, into a fresh table

            using var adminId = conn.CreateCommand();
            adminId.CommandText = "SELECT user_id FROM users WHERE is_admin = 1 ORDER BY user_id LIMIT 1";
            var idResult = adminId.ExecuteScalar();
            if (idResult == null) return;
            int targetUserId = System.Convert.ToInt32(idResult);

            using var legacy = conn.CreateCommand();
            legacy.CommandText = "SELECT ModuleKey, SortOrder FROM UserFavorites ORDER BY SortOrder";
            using var reader = legacy.ExecuteReader();
            using var tx = conn.BeginTransaction();
            while (reader.Read())
            {
                using var ins = conn.CreateCommand();
                ins.Transaction = tx;
                ins.CommandText = "INSERT OR IGNORE INTO user_favorites (user_id, module_key, sort_order) VALUES (@u, @k, @o)";
                ins.Parameters.AddWithValue("@u", targetUserId);
                ins.Parameters.AddWithValue("@k", reader.GetString(0));
                ins.Parameters.AddWithValue("@o", reader.GetInt32(1));
                ins.ExecuteNonQuery();
            }
            tx.Commit();
        }
    }
}