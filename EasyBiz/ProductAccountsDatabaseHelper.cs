using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace EasyBiz
{
    /// <summary>
    /// Gives every product a matching row in the accounts table (category
    /// "Products") so it can be posted to like any other account (Cash
    /// Payment/Receipt, Journal Voucher, Bank Payment/Receipt) and shows up
    /// in View Ledger automatically.
    ///
    /// Call InitializeProductAccountLinks() once at startup (already wired
    /// into MainForm.cs and ProductSetup.cs) — safe to call repeatedly.
    /// </summary>
    internal static class ProductAccountsDatabaseHelper
    {
        private const string Category = "Products";
        private const int BaseId = 120000; // sits above the existing 10000-110000 ranges

        public static void InitializeProductAccountLinks()
        {
            using var conn = DatabaseHelper.GetConnection();

            // Nullable FK back to products — lets us find a product's stock
            // from its linked account, and an account's product (if any).
            try
            {
                using var alter = conn.CreateCommand();
                alter.CommandText = "ALTER TABLE accounts ADD COLUMN linked_product_id INTEGER DEFAULT NULL";
                alter.ExecuteNonQuery();
            }
            catch { /* column already exists — ignore */ }

            using (var seed = conn.CreateCommand())
            {
                seed.CommandText = "INSERT OR IGNORE INTO account_id_tracker (category, last_id) VALUES (@c, @id)";
                seed.Parameters.AddWithValue("@c", Category);
                seed.Parameters.AddWithValue("@id", BaseId);
                seed.ExecuteNonQuery();
            }

            SyncMissingProductAccounts(conn);
        }

        /// <summary>Backfills accounts for any pre-existing product that doesn't have one yet.</summary>
        private static void SyncMissingProductAccounts(SqliteConnection conn)
        {
            var missing = new List<(int ProductId, string Name)>();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT p.product_id, p.product_name
                    FROM products p
                    WHERE NOT EXISTS (
                        SELECT 1 FROM accounts a WHERE a.linked_product_id = p.product_id
                    )";
                using var r = cmd.ExecuteReader();
                while (r.Read())
                    missing.Add((r.GetInt32(0), r.GetString(1)));
            }

            foreach (var (productId, name) in missing)
                CreateProductAccount(conn, productId, name);
        }

        /// <summary>Creates the linked account for a newly-saved product. Returns the new account_id.</summary>
        public static int CreateProductAccount(SqliteConnection conn, int productId, string productName)
        {
            int nextId;
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT last_id FROM account_id_tracker WHERE category=@c";
                cmd.Parameters.AddWithValue("@c", Category);
                var result = cmd.ExecuteScalar();
                nextId = (result == null || result == DBNull.Value)
                    ? BaseId + 1
                    : Convert.ToInt32(result) + 1;
            }

            using (var upd = conn.CreateCommand())
            {
                upd.CommandText = @"
                    INSERT INTO account_id_tracker (category, last_id) VALUES (@c, @id)
                    ON CONFLICT(category) DO UPDATE SET last_id = @id";
                upd.Parameters.AddWithValue("@c", Category);
                upd.Parameters.AddWithValue("@id", nextId);
                upd.ExecuteNonQuery();
            }

            using (var ins = conn.CreateCommand())
            {
                ins.CommandText = @"
                    INSERT INTO accounts (account_id, account_name, account_type, linked_product_id, current_balance)
                    VALUES (@id, @name, @cat, @pid, 0)";
                ins.Parameters.AddWithValue("@id", nextId);
                ins.Parameters.AddWithValue("@name", productName);
                ins.Parameters.AddWithValue("@cat", Category);
                ins.Parameters.AddWithValue("@pid", productId);
                ins.ExecuteNonQuery();
            }

            return nextId;
        }

        /// <summary>Keeps the linked account's name in sync when a product is renamed.</summary>
        public static void RenameProductAccount(int productId, string newName)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE accounts SET account_name = @name WHERE linked_product_id = @pid";
            cmd.Parameters.AddWithValue("@name", newName);
            cmd.Parameters.AddWithValue("@pid", productId);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Returns current stock for the product linked to this account_id,
        /// or null if the account isn't a product account.
        /// </summary>
        public static (double Qty, double Weight, bool IsUnit, string Unit, string WeightUnit, double MinStockQty)? GetStockForAccount(int accountId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT p.current_qty, p.current_weight, p.isUnit, p.unit, p.weight_unit, p.min_stock_qty
                FROM accounts a
                JOIN products p ON p.product_id = a.linked_product_id
                WHERE a.account_id = @id";
            cmd.Parameters.AddWithValue("@id", accountId);

            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return (
                    r.GetDouble(0),
                    r.GetDouble(1),
                    Convert.ToInt32(r.GetValue(2)) == 1,
                    r.GetString(3),
                    r.GetString(4),
                    r.GetDouble(5));
            }
            return null;
        }
    }
}