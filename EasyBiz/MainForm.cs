using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Runtime.CompilerServices;

namespace EasyBiz
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Ensure bank-specific DB tables exist
            DatabaseHelper.InitializeDatabase();
            BankDatabaseHelper.InitializeBankTables();
            ShowCashDetails();            
        }


        public void ShowCashDetails()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                SELECT
                    COALESCE(SUM(CASE WHEN account_type = 'Cash' THEN current_balance ELSE 0 END), 0) AS CashBalance,
                    COALESCE(SUM(CASE WHEN account_type = 'Banks' THEN current_balance ELSE 0 END), 0) AS BankBalance
                FROM accounts;";

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal cashBalance = reader.GetDecimal(0);
                            decimal bankBalance = reader.GetDecimal(1);

                           /* 
                            BtnCashDetails.Text =
                                $"Cash: {cashBalance:N2}\nBanks: {bankBalance:N2}";
                            if (cashBalance < 0 || bankBalance < 0)
                            {
                                BtnCashDetails.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                BtnCashDetails.ForeColor = System.Drawing.Color.Green;
                            }
                           */
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load cash details.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // ── Transactions ──────────────────────────────────────────────
                case Keys.F1:
                    BtnCashPayment_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F2:
                    BtnCashReceipt_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F3:
                    BtnJournalVoucher_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F4:
                    BtnPurchaseInvoice_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F5:
                    BtnSalesInvoice_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F6:
                    BtnEditTransactions_Click(this, EventArgs.Empty);
                    return true;

                // ── Reports ───────────────────────────────────────────────────
                case Keys.F7:
                    BtnLedgerReport_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F8:
                    BtnCashBook_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F9:
                    BtnBankPayment_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F10:
                    BtnBankReceipt_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F11:
                    BtnStockReport_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F12:
                    BtnTrialBalance_Click(this, EventArgs.Empty);
                    return true;

                // ── Setup / master data ───────────────────────────────────────
                case Keys.Control | Keys.A:
                    BtnAccountsSetup_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.P:
                    BtnProductSetup_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.O:
                    BtnOpeningBalances_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.C:
                    BtnChequeBook_Click(this, EventArgs.Empty);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnCashPayment_Click(object sender, EventArgs e)
        {
            try
            {
                CashPayments cash_payments = new CashPayments();
                cash_payments.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCashReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                CashReceipts cash_receipts = new CashReceipts();
                cash_receipts.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnJournalVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                JournalVoucher journal_voucher = new JournalVoucher();
                journal_voucher.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAccountsSetup_Click(object sender, EventArgs e)
        {
            try
            {
                AccountsSetup accountsSetup = new AccountsSetup();
                accountsSetup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLedgerReport_Click(object sender, EventArgs e)
        {
            try
            {
                ViewLedger viewLedger = new ViewLedger();
                viewLedger.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCashBook_Click(object sender, EventArgs e)
        {
            try
            {
                CashBook cashBook = new CashBook();
                cashBook.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
            */
        }

        private void BtnEditTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                EditTransactions editTransactions = new EditTransactions();
                editTransactions.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTrialBalance_Click(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var report = TrialBalanceReport.LoadFromDatabase(
                companyName: "EasyBiz",
                reportTitle: "Trial Balance",
                periodEndDate: DateOnly.FromDateTime(DateTime.Now),
                preparedBy: "Finance Dept",
                currency: "PKR"
            );

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save Trial Balance Report";
            saveFileDialog.FileName = "TrialBalanceReport.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new TrialBalanceDocument(report).GeneratePdf(saveFileDialog.FileName);
                var open = MessageBox.Show(
                    "Trial Balance report generated successfully. Do you want to open it?",
                    "Report Generated", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (open == DialogResult.Yes)
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(saveFileDialog.FileName)
                        { UseShellExecute = true });
            }
        }

        private void BtnSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                new SaleInvoice().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnProductSetup_Click(object sender, EventArgs e)
        {
            try
            {
                new ProductSetup().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                new PurchaseInvoice().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStockReport_Click(object sender, EventArgs e)
        {
            try
            {
                new StockReport().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnOpeningBalances_Click(object sender, EventArgs e)
        {
            try
            {
                new OpeningBalances().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ── NEW: Bank transactions ────────────────────────────────────────────

        private void BtnBankPayment_Click(object sender, EventArgs e)
        {
            try
            {
                new BankPayment().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBankReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                new BankReceipt().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnChequeBook_Click(object sender, EventArgs e)
        {
            try
            {
                new ChequeBook().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                g.DrawImage(image, 0, 0, width, height);
            }

            return resized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Button[] buttons =
            {
        BtnCashPayment,
        BtnCashReceipt,
        BtnJournalVoucher,
        BtnPurchaseInvoice,
        BtnSalesInvoice,
        BtnEditTransactions,
        BtnLedgerReport,
        BtnCashBook,
        BtnBankPayment,
        BtnBankReceipt,
        BtnStockReport,
        BtnTrialBalance,
        BtnAccountsSetup,
        BtnProductSetup,
        BtnOpeningBalances,
        BtnChequeBook,
        BtnSettings,
        BtnBackupData
    };

            const double imageWidthRatio = 0.25;
            const double imageHeightRatio = 0.45;

            foreach (Button btn in buttons)
            {
                if (btn?.Image == null)
                    continue;

                int width = (int)(btn.Width * imageWidthRatio);
                int height = (int)(btn.Height * imageHeightRatio);

                System.Drawing.Image original = btn.Image;
                btn.Image = ResizeImage(original, width, height);

                original.Dispose();
            }
        }

        private void BtnCashDetails_Click(object sender, EventArgs e)
        {
            ShowCashDetails();
        }
    }
}