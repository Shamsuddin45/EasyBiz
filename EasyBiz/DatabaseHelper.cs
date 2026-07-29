using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace EasyBiz
{
    internal class DatabaseHelper
    {
        private static readonly string _dbFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "EasyBiz");

        private static readonly string _dbPath = Path.Combine(_dbFolder, "easybiz.db");

        // Foreign Keys=True is set at the connection-string level as a defense-in-depth
        // measure — the PRAGMA below still runs on every connection open in case any
        // future code path builds a raw connection without going through GetConnection().
        private static readonly string _connectionString =
            $"Data Source={_dbPath};Foreign Keys=True";

        // NEW: expose the resolved path so Program.cs (migration) and
        // GoogleDriveBackupService (backup source file) can reference it
        // instead of hardcoding "easybiz.db" again.
        public static string DatabasePath => _dbPath;

        static DatabaseHelper()
        {
            Directory.CreateDirectory(_dbFolder);
        }

        public static SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // WAL lets readers and a writer work concurrently instead of blocking
                // on the whole-file lock that the default "delete" journal mode uses.
                // busy_timeout makes SQLite retry internally for up to 5s instead of
                // throwing "database is locked" immediately when a brief collision
                // does happen (e.g. a grid refresh overlapping a save).
                command.CommandText =
                    "PRAGMA journal_mode = WAL;" +
                    "PRAGMA busy_timeout = 5000;" +
                    "PRAGMA foreign_keys = ON;";
                command.ExecuteNonQuery();
            }

            return connection;
        }

        public static void InitializeDatabase()
        {
            using (var connection = GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;
                    command.CommandText =
                @"
                -- Accounts table
                CREATE TABLE IF NOT EXISTS accounts (
                    account_id INTEGER PRIMARY KEY,
                    account_name TEXT NOT NULL,
                    account_type TEXT NOT NULL,
                    address TEXT,
                    mobile_number TEXT,
                    opening_balance REAL DEFAULT 0,                    
                    current_balance REAL DEFAULT 0,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                );

                -- Tracker table
                CREATE TABLE IF NOT EXISTS account_id_tracker (
                    category TEXT PRIMARY KEY,
                    last_id INTEGER NOT NULL
                );

                -- Transactions table
                CREATE TABLE IF NOT EXISTS transactions (
                    voucher_no INTEGER NOT NULL,
                    transaction_id INTEGER PRIMARY KEY,
                    transaction_type TEXT NOT NULL,
                    account_id INTEGER NOT NULL,
                    account_name TEXT NOT NULL,
                    description TEXT,
                    debit REAL NOT NULL DEFAULT 0,
                    credit REAL NOT NULL DEFAULT 0,
                    transaction_date DATETIME DEFAULT CURRENT_TIMESTAMP,                                        
                    FOREIGN KEY (account_id) REFERENCES accounts(account_id) ON DELETE CASCADE                    
                );

                -- Seed default Cash account
                INSERT INTO accounts (account_id, account_name, account_type)
                SELECT 10001, 'Cash In Hand', 'Cash'
                WHERE NOT EXISTS (
                    SELECT 1 FROM accounts WHERE account_id = 10001
                );

                -- Seed initial tracker values
                INSERT OR IGNORE INTO account_id_tracker (category, last_id) VALUES
                ('Cash', 10000), ('Banks', 20000), ('Assets', 30000),
                ('Capital', 40000), ('Brokers', 50000), ('Personal Ledgers', 60000),
                ('Payables', 70000), ('Receivables', 80000), ('Employees', 90000),
                ('Expenses', 100000), ('Others', 110000);

                -- ── Added Inventory and Invoice Tables ──

                -- Products / Item Master
                CREATE TABLE IF NOT EXISTS products (
                    product_id   INTEGER PRIMARY KEY AUTOINCREMENT,
                    product_name TEXT NOT NULL UNIQUE,
                    description  TEXT,
                    unit         TEXT DEFAULT 'N/A',   -- PCS, KG, TON, MTR, LTR, etc.
                    weight_unit  TEXT DEFAULT 'N/A',    -- KG, MUN, TON, G, LBS
                    isUnit       BOOLEAN DEFAULT 1,    -- 1 = unit based, 0 = weight based
                    sale_rate    REAL DEFAULT 0,
                    purchase_rate REAL DEFAULT 0,
                    current_qty  REAL DEFAULT 0,               -- pieces / units in stock
                    current_weight REAL DEFAULT 0,             -- weight in stock (weight_unit)
                    min_stock_qty REAL DEFAULT 0,              -- reorder level
                    created_at   DATETIME DEFAULT CURRENT_TIMESTAMP
                );

                -- Stock Movements (audit trail)
                CREATE TABLE IF NOT EXISTS stock_movements (
                    movement_id      INTEGER PRIMARY KEY AUTOINCREMENT,
                    movement_date    TEXT NOT NULL,
                    movement_type    TEXT NOT NULL,   -- 'Purchase', 'Sale', 'Adjustment'
                    voucher_type     TEXT NOT NULL,   -- 'Purchase Invoice', 'Sale Invoice'
                    voucher_no       INTEGER NOT NULL,
                    product_id       INTEGER NOT NULL,
                    product_name     TEXT NOT NULL,
                    qty_in           REAL DEFAULT 0,
                    qty_out          REAL DEFAULT 0,
                    weight_in        REAL DEFAULT 0,
                    weight_out       REAL DEFAULT 0,
                    rate             REAL DEFAULT 0,
                    amount           REAL DEFAULT 0,
                    balance_qty      REAL DEFAULT 0,  -- running qty after this movement
                    balance_weight   REAL DEFAULT 0,  -- running weight after this movement
                    FOREIGN KEY (product_id) REFERENCES products(product_id)
                );

                -- Sale Invoice Header
                CREATE TABLE IF NOT EXISTS sale_invoices (
                    sale_id         INTEGER PRIMARY KEY AUTOINCREMENT,
                    voucher_no      INTEGER NOT NULL UNIQUE,
                    invoice_date    TEXT NOT NULL,
                    account_id      INTEGER NOT NULL,
                    account_name    TEXT NOT NULL,
                    description     TEXT,
                    total_amount    REAL DEFAULT 0,
                    discount        REAL DEFAULT 0,
                    net_amount      REAL DEFAULT 0,
                    -- payment_mode    TEXT DEFAULT 'Credit',  -- Cash / Credit
                    is_cancelled    INTEGER DEFAULT 0,
                    created_at      DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (account_id) REFERENCES accounts(account_id)
                );

                -- Sale Invoice Line Items
                CREATE TABLE IF NOT EXISTS sale_invoice_items (
                    item_id         INTEGER PRIMARY KEY AUTOINCREMENT,
                    sale_id         INTEGER NOT NULL,
                    voucher_no      INTEGER NOT NULL,
                    product_id      INTEGER NOT NULL,
                    product_name    TEXT NOT NULL,
                    quantity        REAL DEFAULT 0,                    
                    weight          REAL DEFAULT 0,
                    weight_unit     TEXT DEFAULT 'KG',                    
                    rate            REAL DEFAULT 0,
                    amount          REAL DEFAULT 0,
                    FOREIGN KEY (sale_id)    REFERENCES sale_invoices(sale_id),
                    FOREIGN KEY (product_id) REFERENCES products(product_id)
                );

                -- Purchase Invoice Header
                CREATE TABLE IF NOT EXISTS purchase_invoices (
                    purchase_id     INTEGER PRIMARY KEY AUTOINCREMENT,
                    voucher_no      INTEGER NOT NULL UNIQUE,
                    invoice_date    TEXT NOT NULL,
                    account_id      INTEGER NOT NULL,
                    account_name    TEXT NOT NULL,
                    description     TEXT,
                    total_amount    REAL DEFAULT 0,
                    discount        REAL DEFAULT 0,
                    net_amount      REAL DEFAULT 0,
                    -- payment_mode    TEXT DEFAULT 'Credit',
                    is_cancelled    INTEGER DEFAULT 0,
                    created_at      DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (account_id) REFERENCES accounts(account_id)
                );

                -- Purchase Invoice Line Items
                CREATE TABLE IF NOT EXISTS purchase_invoice_items (
                    item_id         INTEGER PRIMARY KEY AUTOINCREMENT,
                    purchase_id     INTEGER NOT NULL,
                    voucher_no      INTEGER NOT NULL,
                    product_id      INTEGER NOT NULL,
                    product_name    TEXT NOT NULL,
                    quantity        REAL DEFAULT 0,
                    weight          REAL DEFAULT 0,
                    weight_unit     TEXT DEFAULT 'KG',
                    rate            REAL DEFAULT 0,
                    amount          REAL DEFAULT 0,
                    FOREIGN KEY (purchase_id) REFERENCES purchase_invoices(purchase_id),
                    FOREIGN KEY (product_id)  REFERENCES products(product_id)
                );

                CREATE TABLE IF NOT EXISTS UserFavorites (
                    ModuleKey TEXT PRIMARY KEY,
                    SortOrder INTEGER NOT NULL
                );

                -- ── Indexes on FK / date / voucher_no columns ──
                -- Speeds up ledger lookups, stock reports, and voucher-based joins
                -- as transaction history grows; without these, every filtered
                -- report does a full table scan.
                CREATE INDEX IF NOT EXISTS idx_transactions_account   ON transactions(account_id);
                CREATE INDEX IF NOT EXISTS idx_transactions_date      ON transactions(transaction_date);
                CREATE INDEX IF NOT EXISTS idx_transactions_voucher   ON transactions(voucher_no);

                CREATE INDEX IF NOT EXISTS idx_stockmov_product       ON stock_movements(product_id);
                CREATE INDEX IF NOT EXISTS idx_stockmov_voucher       ON stock_movements(voucher_no);
                CREATE INDEX IF NOT EXISTS idx_stockmov_date          ON stock_movements(movement_date);

                CREATE INDEX IF NOT EXISTS idx_saleinv_account        ON sale_invoices(account_id);
                CREATE INDEX IF NOT EXISTS idx_saleinv_date           ON sale_invoices(invoice_date);
                CREATE INDEX IF NOT EXISTS idx_saleitems_sale         ON sale_invoice_items(sale_id);
                CREATE INDEX IF NOT EXISTS idx_saleitems_product      ON sale_invoice_items(product_id);
                CREATE INDEX IF NOT EXISTS idx_saleitems_voucher      ON sale_invoice_items(voucher_no);

                CREATE INDEX IF NOT EXISTS idx_purchinv_account       ON purchase_invoices(account_id);
                CREATE INDEX IF NOT EXISTS idx_purchinv_date          ON purchase_invoices(invoice_date);
                CREATE INDEX IF NOT EXISTS idx_purchitems_purchase    ON purchase_invoice_items(purchase_id);
                CREATE INDEX IF NOT EXISTS idx_purchitems_product     ON purchase_invoice_items(product_id);
                CREATE INDEX IF NOT EXISTS idx_purchitems_voucher     ON purchase_invoice_items(voucher_no);
                ";

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }

                // Re-enable foreign key enforcement after schema changes
                using (var pragmaOn = connection.CreateCommand())
                {
                    pragmaOn.CommandText = "PRAGMA foreign_keys = ON;";
                    pragmaOn.ExecuteNonQuery();
                }
            }
        }

        public static void ClearDatabase()
        {
            using (var connection = GetConnection())
            {
                // Temporarily disable foreign key enforcement while clearing/reseeding
                using (var pragmaOff = connection.CreateCommand())
                {
                    pragmaOff.CommandText = "PRAGMA foreign_keys = OFF;";
                    pragmaOff.ExecuteNonQuery();
                }

                using (var transaction = connection.BeginTransaction())
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;

                    command.CommandText = @"
                    -- Wipe out all table records
                    DELETE FROM stock_movements;
                    DELETE FROM sale_invoice_items;
                    DELETE FROM sale_invoices;
                    DELETE FROM purchase_invoice_items;
                    DELETE FROM purchase_invoices;
                    DELETE FROM products;
                    DELETE FROM transactions;
                    DELETE FROM accounts;
                    DELETE FROM account_id_tracker;

                    -- Reset SQLite Autoincrement counters
                    DELETE FROM sqlite_sequence WHERE name IN 
                    ('products', 'stock_movements', 'sale_invoices', 'sale_invoice_items', 'purchase_invoices', 'purchase_invoice_items');

                    -- Reseed default Cash account
                    INSERT INTO accounts (account_id, account_name, account_type)
                    VALUES (10001, 'Cash In Hand', 'Cash');

                    -- Reseed tracker values
                    INSERT INTO account_id_tracker (category, last_id) VALUES
                    ('Cash', 10000), ('Banks', 20000), ('Assets', 30000),
                    ('Capital', 40000), ('Brokers', 50000), ('Personal Ledgers', 60000),
                    ('Payables', 70000), ('Receivables', 80000), ('Employees', 90000),
                    ('Expenses', 100000), ('Others', 110000);
                    ";

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }

                // Re-enable foreign key enforcement after clearing/reseeding
                using (var pragmaOn = connection.CreateCommand())
                {
                    pragmaOn.CommandText = "PRAGMA foreign_keys = ON;";
                    pragmaOn.ExecuteNonQuery();
                }
            }
        }
    }
}