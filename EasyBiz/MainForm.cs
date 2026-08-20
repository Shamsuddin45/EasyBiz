using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Runtime.CompilerServices;
using System.Drawing;
using EasyBiz.Forms;
using Syncfusion.Windows.Forms.PdfViewer;
using System.Net.NetworkInformation;


namespace EasyBiz
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            BtnBackupData.Click += BtnBackupData_Click;
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JAaF5cXmFCd1p/TH5YfUNzdUVEY1ZUTXxaS1ZhSXxVdk1jXH9fdHdVRWhaU0Z9XEY=");
            // Ensure bank-specific DB tables exist
            DatabaseHelper.InitializeDatabase();
            BankDatabaseHelper.InitializeBankTables();
            ProductAccountsDatabaseHelper.InitializeProductAccountLinks();
            //ShowCashDetails();
            ThemeManager.LoadSavedTheme();
            ThemeManager.ApplyTheme(this);
            ThemeManager.ThemeChanged += (s, e) =>
            {
                if (!IsDisposed)
                    ThemeManager.ApplyTheme(this);
                setupButtons();

                // Only reload favorites on theme change if they are actually visible
                if (pnlFavorites.Visible)
                    LoadFavoritesPanel();
            };

            Text = $"EasyBiz: By Shamsuddin — {CurrentUser.FullName}" +
                   (CurrentUser.IsAdmin ? " [Admin]" : "");
        }

        /*public void ShowCashDetails()
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
                                                                                        
                            lblShowBalanceDetail.Text =
                                $"Cash: {cashBalance:N2}\nBanks: {bankBalance:N2}";                                                 
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
        }*/
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // ── Transactions ──────────────────────────────────────────────
                case Keys.F1:
                    if (BtnCashPayment.Enabled) BtnCashPayment_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F2:
                    if (BtnCashReceipt.Enabled) BtnCashReceipt_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F3:
                    if (BtnJournalVoucher.Enabled) BtnJournalVoucher_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F4:
                    if (BtnPurchaseInvoice.Enabled) BtnPurchaseInvoice_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F5:
                    if (BtnSalesInvoice.Enabled) BtnSalesInvoice_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F6:
                    if (BtnEditTransactions.Enabled) BtnEditTransactions_Click(this, EventArgs.Empty);
                    return true;

                // ── Reports ───────────────────────────────────────────────────
                case Keys.F7:
                    if (BtnLedgerReport.Enabled) BtnLedgerReport_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F8:
                    if (BtnCashBook.Enabled) BtnCashBook_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F9:
                    if (BtnBankPayment.Enabled) BtnBankPayment_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F10:
                    if (BtnBankReceipt.Enabled) BtnBankReceipt_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F11:
                    if (BtnStockReport.Enabled) BtnStockReport_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F12:
                    if (BtnTrialBalance.Enabled) BtnTrialBalance_Click(this, EventArgs.Empty);
                    return true;

                // ── Setup / master data ───────────────────────────────────────
                case Keys.Control | Keys.A:
                    if (BtnAccountsSetup.Enabled) BtnAccountsSetup_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.P:
                    if (BtnProductSetup.Enabled) BtnProductSetup_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.O:
                    if (BtnOpeningBalances.Enabled) BtnOpeningBalances_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.C:
                    if (BtnChequeBook.Enabled) BtnChequeBook_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.G:
                    btnAiAssistant_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.S:
                    BtnSettings_Click(this, EventArgs.Empty);
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
                preparedBy: CurrentUser.FullName,
                currency: "PKR"
            );

            // Define your target directory (e.g., the system's Application Data folder)
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            folderPath = Path.Combine(folderPath, "CashbookAIReports");


            // Ensure the directory exists; create it if it doesn't
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Combine folder path and file name to get the full file path
            string filePath = Path.Combine(folderPath, "TrialBalanceReport.pdf");
            // Pass the file path to the ViewReports form and show it
            ViewReports viewReports = new ViewReports(filePath);
            viewReports.ShowDialog();

            // Generate the PDF
            new TrialBalanceDocument(report).GeneratePdf(filePath);

        }

        private void BtnSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                SaleInvoice saleInvoice = new SaleInvoice();
                saleInvoice.ShowDialog();
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
                ProductSetup productSetup = new ProductSetup();
                productSetup.ShowDialog();
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
                PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
                purchaseInvoice.ShowDialog();
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
                StockReport stockReport = new StockReport();
                stockReport.ShowDialog();
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
                OpeningBalances openingBalances = new OpeningBalances();
                openingBalances.ShowDialog();
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
                BankPayment bankPayment = new BankPayment();
                bankPayment.ShowDialog();
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
                BankReceipt bankReceipt = new BankReceipt();
                bankReceipt.ShowDialog();
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
                ChequeBook chequeBook = new ChequeBook();
                chequeBook.ShowDialog();
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

        private void BtnBackupData_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new BackupRestoreForm())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setupButtons()
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

            const double imageWidthRatio = 0.32;
            const double imageHeightRatio = 0.32;

            foreach (Button btn in buttons)
            {
                if (btn?.Image == null)
                    continue;

                int width = (int)(btn.Width * imageWidthRatio);
                int height = (int)(btn.Height * imageHeightRatio);

                System.Drawing.Image original = btn.Image;
                btn.Image = ResizeImage(original, width, height);
                btn.ForeColor = ThemeManager.Current.ForeColor;

                original.Dispose();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setupButtons();
            GlobalConfig.LoadSettings();
            lblUsername.Text = $"Welcome: {CurrentUser.FullName}";
            ApplyUserRights();

            // Sync Favorites Panel visibility with user config on application load
            bool isFavEnabled = GlobalConfig.AppSettings.EnableFavorites && FavoritesService.HasFavorites();
            enableFavoritesPanelToolStripMenuItem.Checked = isFavEnabled;
            pnlFavorites.Visible = isFavEnabled;

            if (isFavEnabled)
            {
                LoadFavoritesPanel();
            }
        }

        private void LoadFavoritesPanel()
        {
            // Abort if panel shouldn't be visible to save resources
            if (!pnlFavorites.Visible) return;

            // Dispose old favorite buttons to prevent memory leaks and UI glitches,
            // while keeping lblFavHeader intact. Controls.Clear() causes memory leaks for dynamic controls.
            for (int i = pnlFavorites.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = pnlFavorites.Controls[i];
                if (ctrl != lblFavHeader)
                {
                    pnlFavorites.Controls.RemoveAt(i);
                    ctrl.Dispose();
                }
            }

            // Guarantee header is present just in case
            if (!pnlFavorites.Controls.Contains(lblFavHeader))
            {
                pnlFavorites.Controls.Add(lblFavHeader);
            }

            var favoriteKeys = FavoritesService.GetFavoriteKeys();
            if (favoriteKeys == null) return;

            foreach (var key in favoriteKeys)
            {
                var module = ModuleRegistry.GetByKey(key);
                if (module == null) continue; // module might've been removed from registry

                var btn = new CustomButton
                {
                    Text = module.DisplayName,
                    Width = 220,
                    Height = 70,
                    Tag = module.FormType,
                    Margin = new Padding(2),
                    BackgroundColor = ThemeManager.Current.MenuBackColor,
                    TextColor = ThemeManager.Current.MenuForeColor,
                    BorderSize = 1,
                    BorderColor = ThemeManager.Current.MenuForeColor
                };
                btn.Click += FavoriteButton_Click;
                pnlFavorites.Controls.Add(btn);
            }
        }

        private void FavoriteButton_Click(object sender, EventArgs e)
        {
            var formType = (System.Type)((Button)sender).Tag;

            // Guard against a favorited module the user no longer has rights to
            // (e.g. an admin revoked access after the favorite was saved).
            if (!CurrentUser.IsAdmin)
            {
                var module = ModuleRegistry.AllModules.Find(m => m.FormType == formType);
                if (module != null)
                {
                    var allowed = UserRightsService.GetAllowedModuleKeys(CurrentUser.UserId, CurrentUser.IsAdmin);
                    if (!allowed.Contains(module.Key))
                    {
                        MessageBox.Show(
                            "You do not have permission to open this module. Please contact an administrator.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            var form = (Form)System.Activator.CreateInstance(formType);
            //form.MdiParent = this;   // remove this line if you're not using MDI
            form.Show();
        }

        /// <summary>
        /// Disables buttons and menu items on MainForm that the current
        /// non-admin user does not have rights to. Admins are never restricted.
        /// </summary>
        private void ApplyUserRights()
        {
            if (CurrentUser.IsAdmin)
                return;

            var allowed = UserRightsService.GetAllowedModuleKeys(CurrentUser.UserId, CurrentUser.IsAdmin);

            void Restrict(CustomButton button, string rightKey)
            {
                bool hasAccess = allowed.Contains(rightKey);
                button.Enabled = hasAccess;
                if (!hasAccess)
                {
                    button.BackgroundColor = System.Drawing.Color.Gainsboro;
                    button.TextColor = System.Drawing.Color.Gray;
                }
            }

            Restrict(BtnAccountsSetup, "accountssetup");
            Restrict(BtnCashPayment, "cashpayment");
            Restrict(BtnCashReceipt, "cashreceipt");
            Restrict(BtnJournalVoucher, "journalvoucher");
            Restrict(BtnCashBook, "cashbook");
            Restrict(BtnLedgerReport, "viewledger");
            Restrict(BtnEditTransactions, "edittransactions");
            Restrict(BtnOpeningBalances, "openingbalances");
            Restrict(BtnTrialBalance, "trialbalance");
            Restrict(BtnSalesInvoice, "saleinvoice");
            Restrict(BtnProductSetup, "productsetup");
            Restrict(BtnPurchaseInvoice, "purchaseinvoice");
            Restrict(BtnStockReport, "stockreport");
            Restrict(BtnBankPayment, "bankpayment");
            Restrict(BtnBankReceipt, "bankreceipt");
            Restrict(BtnChequeBook, "chequebook");
            Restrict(BtnSettings, "settings");
            Restrict(BtnBackupData, "backupdata");

            // Menu items bypass button.Enabled entirely, so gate them too.
            cashPaymentToolStripMenuItem.Enabled = allowed.Contains("cashpayment");
            cashReceiptToolStripMenuItem.Enabled = allowed.Contains("cashreceipt");
            journalVoucherToolStripMenuItem.Enabled = allowed.Contains("journalvoucher");
            editTransactionsToolStripMenuItem.Enabled = allowed.Contains("edittransactions");
            accountToolStripMenuItem.Enabled = allowed.Contains("accountssetup");
            productToolStripMenuItem.Enabled = allowed.Contains("productsetup");
            saleInvoiceToolStripMenuItem.Enabled = allowed.Contains("saleinvoice");
            purchaseInvoiceToolStripMenuItem.Enabled = allowed.Contains("purchaseinvoice");
            stocToolStripMenuItem.Enabled = allowed.Contains("stockreport");
            bankPaymentToolStripMenuItem.Enabled = allowed.Contains("bankpayment");
            bankReceiptToolStripMenuItem.Enabled = allowed.Contains("bankreceipt");
            chequeBookToolStripMenuItem.Enabled = allowed.Contains("chequebook");
            cashBookToolStripMenuItem.Enabled = allowed.Contains("cashbook");
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new Settings())
            {
                settingsForm.FavoritesUpdated += (s, e) =>
                {
                    // Keep visibility matched in case it was toggled during the Settings session
                    bool isFavEnabled = GlobalConfig.AppSettings.EnableFavorites && FavoritesService.HasFavorites();
                    enableFavoritesPanelToolStripMenuItem.Checked = isFavEnabled;
                    pnlFavorites.Visible = isFavEnabled;

                    if (isFavEnabled)
                    {
                        LoadFavoritesPanel();
                    }

                    ApplyUserRights();
                };
                settingsForm.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private async void btnAiAssistant_Click(object sender, EventArgs e)
        {
            // Disable button temporarily to prevent multiple clicks while checking
            btnAiAssistant.Enabled = false;

            try
            {
                bool hasInternet = await HasInternetConnectionAsync();

                if (!hasInternet)
                {
                    MessageBox.Show(
                        "Internet connection is required to use the AI Assistant. Please check your connection and try again.",
                        "No Internet Connection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                new AIChatForm().Show(); // non-modal window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnAiAssistant.Enabled = true;
            }
        }

        // Helper method to verify actual web connectivity
        private async Task<bool> HasInternetConnectionAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Set a short timeout so the user isn't left waiting if offline
                    client.Timeout = TimeSpan.FromSeconds(3);

                    // Ping a highly reliable public server (e.g., Cloudflare or Google)
                    HttpResponseMessage response = await client.GetAsync("https://www.cloudflare.com/favicon.ico");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        private void enableFavoritesPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Using 'Click' instead of 'CheckStateChanged' prevents re-entrancy issues.
            bool isChecked = enableFavoritesPanelToolStripMenuItem.Checked;

            if (isChecked)
            {
                if (!FavoritesService.HasFavorites())
                {
                    MessageBox.Show(
                        "You have no favorites set up. Please go to Settings > Favorites to add some.",
                        "No Favorites", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Revert the check state since they can't enable it
                    GlobalConfig.AppSettings.EnableFavorites = false;
                    enableFavoritesPanelToolStripMenuItem.Checked = false;
                    pnlFavorites.Visible = false;
                }
                else
                {
                    GlobalConfig.AppSettings.EnableFavorites = true;
                    pnlFavorites.Visible = true;
                    LoadFavoritesPanel();
                }
            }
            else
            {
                GlobalConfig.AppSettings.EnableFavorites = false;
                pnlFavorites.Visible = false;
            }

            GlobalConfig.SaveSettings();
        }

        private void abountMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void sqlQueryRunnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlQueryRunnerForm sqlqueryform = new SqlQueryRunnerForm();
            sqlqueryform.ShowDialog();
        }
    }
}