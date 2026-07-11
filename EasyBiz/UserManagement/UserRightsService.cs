using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EasyBiz
{
    public class UserAccount
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string FullName { get; set; } = "";
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }

    public static class UserRightsService
    {
        // ── Authentication ───────────────────────────────────────────────
        public static UserAccount? Authenticate(string username, string password)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT user_id, username, password, full_name, is_admin, is_active
                                 FROM users WHERE username = @u";
            cmd.Parameters.AddWithValue("@u", username.Trim());

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            bool active = r.GetInt32(5) == 1;
            if (!active) return null;

            // Get the stored hashed password
            string storedHash = r.GetString(2);

            // Verify the password against the stored hash
            bool passwordValid = BCrypt.Net.BCrypt.Verify(password, storedHash);
            if (!passwordValid) return null;

            return new UserAccount
            {
                UserId = r.GetInt32(0),
                Username = r.GetString(1),
                FullName = r.IsDBNull(3) ? "" : r.GetString(3),
                IsAdmin = r.GetInt32(4) == 1,
                IsActive = true
            };
        }

        // ── User CRUD ─────────────────────────────────────────────────────
        public static List<UserAccount> GetAllUsers()
        {
            var list = new List<UserAccount>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT user_id, username, full_name, is_admin, is_active FROM users ORDER BY username";
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new UserAccount
                {
                    UserId = r.GetInt32(0),
                    Username = r.GetString(1),
                    FullName = r.IsDBNull(2) ? "" : r.GetString(2),
                    IsAdmin = r.GetInt32(3) == 1,
                    IsActive = r.GetInt32(4) == 1
                });
            }
            return list;
        }

        public static void CreateUser(string username, string password, string fullName, bool isAdmin)
        {
            // Hash the password before storing
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO users (username, password, full_name, is_admin, is_active)
                                 VALUES (@u, @p, @f, @a, 1)";
            cmd.Parameters.AddWithValue("@u", username.Trim());
            cmd.Parameters.AddWithValue("@p", hashedPassword);
            cmd.Parameters.AddWithValue("@f", fullName ?? "");
            cmd.Parameters.AddWithValue("@a", isAdmin ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateUser(int userId, string fullName, bool isAdmin, bool isActive)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE users SET full_name=@f, is_admin=@a, is_active=@act WHERE user_id=@id";
            cmd.Parameters.AddWithValue("@f", fullName ?? "");
            cmd.Parameters.AddWithValue("@a", isAdmin ? 1 : 0);
            cmd.Parameters.AddWithValue("@act", isActive ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        public static void ResetPassword(int userId, string newPassword)
        {
            // Hash the new password before storing
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword, workFactor: 12);

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE users SET password=@p WHERE user_id=@id";
            cmd.Parameters.AddWithValue("@p", hashedPassword);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Prevents deleting the very last remaining admin account.</summary>
        public static bool IsLastAdmin(int userId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var check = conn.CreateCommand();
            check.CommandText = "SELECT is_admin FROM users WHERE user_id=@id";
            check.Parameters.AddWithValue("@id", userId);
            var result = check.ExecuteScalar();
            if (result == null || Convert.ToInt32(result) == 0) return false;

            using var count = conn.CreateCommand();
            count.CommandText = "SELECT COUNT(*) FROM users WHERE is_admin = 1";
            long adminCount = Convert.ToInt64(count.ExecuteScalar());
            return adminCount <= 1;
        }

        public static void DeleteUser(int userId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM users WHERE user_id=@id";
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        // ── Rights ───────────────────────────────────────────────────────
        /// <summary>
        /// Returns the set of module keys this user is allowed to open.
        /// Admins always get every key in ModuleRegistry plus the two
        /// extra MainForm-only keys ("trialbalance", "backupdata") — admins
        /// are never restricted by the user_rights table.
        /// </summary>
        public static HashSet<string> GetAllowedModuleKeys(int userId, bool isAdmin)
        {
            var set = new HashSet<string>();

            if (isAdmin)
            {
                foreach (var m in ModuleRegistry.AllModules) set.Add(m.Key);
                set.Add("trialbalance");
                set.Add("backupdata");
                return set;
            }

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT module_key FROM user_rights WHERE user_id=@id AND can_access=1";
            cmd.Parameters.AddWithValue("@id", userId);
            using var r = cmd.ExecuteReader();
            while (r.Read()) set.Add(r.GetString(0));
            return set;
        }

        /// <summary>Overwrites the full rights list for a user with the given set of module keys.</summary>
        public static void SaveRights(int userId, IEnumerable<string> allowedModuleKeys)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var tx = conn.BeginTransaction();

            using (var del = conn.CreateCommand())
            {
                del.Transaction = tx;
                del.CommandText = "DELETE FROM user_rights WHERE user_id=@id";
                del.Parameters.AddWithValue("@id", userId);
                del.ExecuteNonQuery();
            }

            foreach (var key in allowedModuleKeys)
            {
                using var ins = conn.CreateCommand();
                ins.Transaction = tx;
                ins.CommandText = "INSERT INTO user_rights (user_id, module_key, can_access) VALUES (@id, @k, 1)";
                ins.Parameters.AddWithValue("@id", userId);
                ins.Parameters.AddWithValue("@k", key);
                ins.ExecuteNonQuery();
            }

            tx.Commit();
        }
    }
}