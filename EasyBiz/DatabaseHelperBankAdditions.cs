using Microsoft.Data.Sqlite;
using System;

namespace EasyBiz
{
    /// <summary>
    /// Bank/cheque schema additions.
    /// Call BankDatabaseHelper.InitializeBankTables() once at startup
    /// (already wired in the updated MainForm.cs).
    /// Safe to call repeatedly — uses CREATE IF NOT EXISTS and
    /// silently ignores the "column already exists" error from ALTER TABLE.
    /// </summary>
    internal static class BankDatabaseHelper
    {
        public static void InitializeBankTables()
        {
            using var conn = DatabaseHelper.GetConnection();

            // Add cheque_no column to transactions if missing
            try
            {
                using var alter = conn.CreateCommand();
                alter.CommandText = "ALTER TABLE transactions ADD COLUMN cheque_no TEXT DEFAULT ''";
                alter.ExecuteNonQuery();
            }
            catch { /* column already exists — ignore */ }

            // Create the cheques register table
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS cheques (
                    cheque_id           INTEGER PRIMARY KEY AUTOINCREMENT,
                    cheque_no           TEXT    NOT NULL,
                    cheque_date         TEXT    NOT NULL,
                    bank_account_id     INTEGER NOT NULL,
                    bank_account_name   TEXT    NOT NULL,
                    party_account_id    INTEGER NOT NULL,
                    party_account_name  TEXT    NOT NULL,
                    amount              REAL    NOT NULL DEFAULT 0,
                    direction           TEXT    NOT NULL DEFAULT 'Payable',
                    status              TEXT    NOT NULL DEFAULT 'Issued',
                    description         TEXT,
                    cleared_date        TEXT,
                    created_at          DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (bank_account_id)  REFERENCES accounts(account_id),
                    FOREIGN KEY (party_account_id) REFERENCES accounts(account_id)
                );
                CREATE INDEX IF NOT EXISTS idx_cheques_no     ON cheques(cheque_no);
                CREATE INDEX IF NOT EXISTS idx_cheques_status ON cheques(status);
            ";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Wipes all cheque records. Call alongside DatabaseHelper.ClearDatabase()
        /// if you want a full reset.
        /// </summary>
        public static void ClearCheques()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM cheques";
            cmd.ExecuteNonQuery();
            using var seq = conn.CreateCommand();
            seq.CommandText = "DELETE FROM sqlite_sequence WHERE name='cheques'";
            try { seq.ExecuteNonQuery(); } catch { }
        }
    }
}