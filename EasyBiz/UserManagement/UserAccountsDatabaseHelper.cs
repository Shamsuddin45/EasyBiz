using Microsoft.Data.Sqlite;
using System;
using System.Security.Cryptography;

namespace EasyBiz
{
    /// <summary>
    /// Result of an authentication attempt.
    /// </summary>
    public enum LoginResult
    {
        Success,
        UserNotFound,
        WrongPassword,
        AccountInactive
    }

    /// <summary>
    /// Lightweight DTO for displaying/editing a user row (never carries the password).
    /// </summary>
    public class UserAccount
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Role { get; set; } = "User";      // "Admin" or "User"
        public bool IsActive { get; set; } = true;
        public string LastLogin { get; set; } = "";
        public string CreatedAt { get; set; } = "";
    }

    /// <summary>
    /// Handles the "users" table: schema creation, CRUD, and password
    /// hashing/verification. Passwords are never stored or compared in
    /// plain text — PBKDF2-HMACSHA256 with a random per-user salt is used.
    /// </summary>
    internal static class UserAccountsDatabaseHelper
    {
        private const int SaltSize = 16;   // 128-bit salt
        private const int KeySize = 32;    // 256-bit derived key
        private const int Iterations = 100_000;

        public const string RoleAdmin = "Admin";
        public const string RoleUser = "User";

        /// <summary>
        /// Creates the users table if it doesn't exist yet, and seeds a
        /// default administrator account (username: admin / password: admin123)
        /// the very first time the table is created so the app is never
        /// left with no way to log in.
        /// </summary>
        public static void InitializeUserTable()
        {
            using var connection = DatabaseHelper.GetConnection();

            MigrateIncompatibleUsersTableIfAny(connection);

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS users (
                        user_id       INTEGER PRIMARY KEY AUTOINCREMENT,
                        username      TEXT NOT NULL UNIQUE COLLATE NOCASE,
                        password_hash TEXT NOT NULL,
                        password_salt TEXT NOT NULL,
                        full_name     TEXT,
                        role          TEXT NOT NULL DEFAULT 'User',
                        is_active     INTEGER NOT NULL DEFAULT 1,
                        last_login    DATETIME,
                        created_at    DATETIME DEFAULT CURRENT_TIMESTAMP
                    );";
                cmd.ExecuteNonQuery();
            }

            // Seed a default admin only if the table is completely empty —
            // guarantees there's always at least one way into the app.
            using (var check = connection.CreateCommand())
            {
                check.CommandText = "SELECT COUNT(*) FROM users";
                long count = Convert.ToInt64(check.ExecuteScalar());
                if (count == 0)
                {
                    var (hash, salt) = HashPassword("admin123");
                    using var insert = connection.CreateCommand();
                    insert.CommandText = @"
                        INSERT INTO users (username, password_hash, password_salt, full_name, role, is_active)
                        VALUES ('admin', @hash, @salt, 'Administrator', 'Admin', 1)";
                    insert.Parameters.AddWithValue("@hash", hash);
                    insert.Parameters.AddWithValue("@salt", salt);
                    insert.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// If a table named "users" already exists in the .db file (e.g. left
        /// over from an earlier experiment, or a differently-shaped table that
        /// happened to share the name) but is missing the columns this system
        /// expects, "CREATE TABLE IF NOT EXISTS" would silently do nothing and
        /// every query against it would fail with errors like
        /// "no such column: user_id". Instead of losing whatever is in that
        /// table, rename it out of the way so a fresh, correct "users" table
        /// can be created right after this runs.
        /// </summary>
        private static void MigrateIncompatibleUsersTableIfAny(SqliteConnection connection)
        {
            using var checkExists = connection.CreateCommand();
            checkExists.CommandText =
                "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='users'";
            bool tableExists = Convert.ToInt64(checkExists.ExecuteScalar()) > 0;
            if (!tableExists) return;

            var existingColumns = new System.Collections.Generic.HashSet<string>(
                StringComparer.OrdinalIgnoreCase);
            using (var pragma = connection.CreateCommand())
            {
                pragma.CommandText = "PRAGMA table_info(users)";
                using var reader = pragma.ExecuteReader();
                while (reader.Read())
                    existingColumns.Add(reader.GetString(reader.GetOrdinal("name")));
            }

            string[] requiredColumns =
            {
                "user_id", "username", "password_hash", "password_salt",
                "role", "is_active"
            };

            bool isCompatible = true;
            foreach (var col in requiredColumns)
            {
                if (!existingColumns.Contains(col))
                {
                    isCompatible = false;
                    break;
                }
            }

            if (isCompatible) return;

            string backupName = $"users_backup_{DateTime.Now:yyyyMMdd_HHmmss}";
            using var rename = connection.CreateCommand();
            rename.CommandText = $"ALTER TABLE users RENAME TO {backupName}";
            rename.ExecuteNonQuery();
        }

        // ── Password hashing ──────────────────────────────────────────────
        public static (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(
                password, saltBytes, Iterations, HashAlgorithmName.SHA256, KeySize);
            return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
        }

        private static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] attemptHash = Rfc2898DeriveBytes.Pbkdf2(
                password, saltBytes, Iterations, HashAlgorithmName.SHA256, KeySize);
            byte[] storedHashBytes = Convert.FromBase64String(storedHash);
            return CryptographicOperations.FixedTimeEquals(attemptHash, storedHashBytes);
        }

        // ── Authentication ────────────────────────────────────────────────
        public static LoginResult TryLogin(string username, string password, out UserAccount? user)
        {
            user = null;
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT user_id, username, password_hash, password_salt,
                       full_name, role, is_active
                FROM users
                WHERE username = @u COLLATE NOCASE";
            cmd.Parameters.AddWithValue("@u", username.Trim());

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return LoginResult.UserNotFound;

            int userId = reader.GetInt32(0);
            string dbUsername = reader.GetString(1);
            string hash = reader.GetString(2);
            string salt = reader.GetString(3);
            string fullName = reader.IsDBNull(4) ? "" : reader.GetString(4);
            string role = reader.GetString(5);
            bool isActive = reader.GetInt32(6) == 1;
            reader.Close();

            if (!isActive)
                return LoginResult.AccountInactive;

            if (!VerifyPassword(password, hash, salt))
                return LoginResult.WrongPassword;

            // Record last login time
            using (var upd = connection.CreateCommand())
            {
                upd.CommandText = "UPDATE users SET last_login = CURRENT_TIMESTAMP WHERE user_id = @id";
                upd.Parameters.AddWithValue("@id", userId);
                upd.ExecuteNonQuery();
            }

            user = new UserAccount
            {
                UserId = userId,
                Username = dbUsername,
                FullName = fullName,
                Role = role,
                IsActive = isActive
            };
            return LoginResult.Success;
        }

        // ── CRUD for User Management screen ───────────────────────────────
        public static System.Collections.Generic.List<UserAccount> GetAllUsers()
        {
            var list = new System.Collections.Generic.List<UserAccount>();
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT user_id, username, full_name, role, is_active,
                       IFNULL(last_login,''), IFNULL(created_at,'')
                FROM users
                ORDER BY username COLLATE NOCASE";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new UserAccount
                {
                    UserId = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    FullName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Role = reader.GetString(3),
                    IsActive = reader.GetInt32(4) == 1,
                    LastLogin = reader.GetString(5),
                    CreatedAt = reader.GetString(6)
                });
            }
            return list;
        }

        public static bool UsernameExists(string username, int excludeUserId = 0)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM users WHERE username = @u COLLATE NOCASE AND user_id != @id";
            cmd.Parameters.AddWithValue("@u", username.Trim());
            cmd.Parameters.AddWithValue("@id", excludeUserId);
            return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
        }

        public static void CreateUser(string username, string password, string fullName, string role)
        {
            var (hash, salt) = HashPassword(password);
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO users (username, password_hash, password_salt, full_name, role, is_active)
                VALUES (@u, @h, @s, @f, @r, 1)";
            cmd.Parameters.AddWithValue("@u", username.Trim());
            cmd.Parameters.AddWithValue("@h", hash);
            cmd.Parameters.AddWithValue("@s", salt);
            cmd.Parameters.AddWithValue("@f", fullName.Trim());
            cmd.Parameters.AddWithValue("@r", role);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateUser(int userId, string fullName, string role)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE users SET full_name = @f, role = @r WHERE user_id = @id";
            cmd.Parameters.AddWithValue("@f", fullName.Trim());
            cmd.Parameters.AddWithValue("@r", role);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static void ResetPassword(int userId, string newPassword)
        {
            var (hash, salt) = HashPassword(newPassword);
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE users SET password_hash = @h, password_salt = @s WHERE user_id = @id";
            cmd.Parameters.AddWithValue("@h", hash);
            cmd.Parameters.AddWithValue("@s", salt);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static void SetActive(int userId, bool isActive)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE users SET is_active = @a WHERE user_id = @id";
            cmd.Parameters.AddWithValue("@a", isActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Number of active Admin accounts — used to stop the last admin being locked out.</summary>
        public static int CountActiveAdmins(int excludeUserId = 0)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT COUNT(*) FROM users
                WHERE role = 'Admin' AND is_active = 1 AND user_id != @id";
            cmd.Parameters.AddWithValue("@id", excludeUserId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}