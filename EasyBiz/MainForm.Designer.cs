namespace EasyBiz
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            BtnCashPayment = new CustomButton();
            BtnCashReceipt = new CustomButton();
            BtnJournalVoucher = new CustomButton();
            BtnCashBook = new CustomButton();
            BtnLedgerReport = new CustomButton();
            BtnEditTransactions = new CustomButton();
            BtnOpeningBalances = new CustomButton();
            BtnTrialBalance = new CustomButton();
            BtnSalesInvoice = new CustomButton();
            BtnProductSetup = new CustomButton();
            BtnPurchaseInvoice = new CustomButton();
            BtnStockReport = new CustomButton();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            cashPaymentToolStripMenuItem = new ToolStripMenuItem();
            cashReceiptToolStripMenuItem = new ToolStripMenuItem();
            journalVoucherToolStripMenuItem = new ToolStripMenuItem();
            editTransactionsToolStripMenuItem = new ToolStripMenuItem();
            bankToolStripMenuItem = new ToolStripMenuItem();
            bankPaymentToolStripMenuItem = new ToolStripMenuItem();
            bankReceiptToolStripMenuItem = new ToolStripMenuItem();
            chequeBookToolStripMenuItem = new ToolStripMenuItem();
            addNewToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            viewLedgerToolStripMenuItem = new ToolStripMenuItem();
            trialBalancesToolStripMenuItem = new ToolStripMenuItem();
            itemMovementToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem = new ToolStripMenuItem();
            saleInvoiceToolStripMenuItem = new ToolStripMenuItem();
            purchaseInvoiceToolStripMenuItem = new ToolStripMenuItem();
            stocToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            cashBookToolStripMenuItem = new ToolStripMenuItem();
            aIAssistantToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem1 = new ToolStripMenuItem();
            enableFavoritesPanelToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            abountMeToolStripMenuItem = new ToolStripMenuItem();
            BtnBankReceipt = new CustomButton();
            BtnBankPayment = new CustomButton();
            BtnChequeBook = new CustomButton();
            BtnSettings = new CustomButton();
            BtnBackupData = new CustomButton();
            toolTip1 = new ToolTip(components);
            btnLogout = new CustomButton();
            btnAiAssistant = new CustomButton();
            pnlFavorites = new FlowLayoutPanel();
            lblFavHeader = new Label();
            stockReportToolStripMenuItem = new ToolStripMenuItem();
            lblUsername = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            BtnAccountsSetup = new CustomButton();
            sqlQueryRunnerToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            pnlFavorites.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // BtnCashPayment
            // 
            BtnCashPayment.Anchor = AnchorStyles.Top;
            BtnCashPayment.BackColor = Color.Transparent;
            BtnCashPayment.BackgroundColor = Color.Transparent;
            BtnCashPayment.BorderColor = Color.Transparent;
            BtnCashPayment.BorderRadius = 15;
            BtnCashPayment.BorderSize = 2;
            BtnCashPayment.FlatAppearance.BorderSize = 0;
            BtnCashPayment.FlatStyle = FlatStyle.Flat;
            BtnCashPayment.Font = new Font("Trebuchet MS", 10.2F);
            BtnCashPayment.ForeColor = Color.Black;
            BtnCashPayment.Image = Properties.Resources.money_pay;
            BtnCashPayment.Location = new Point(311, 4);
            BtnCashPayment.Margin = new Padding(3, 4, 3, 4);
            BtnCashPayment.Name = "BtnCashPayment";
            BtnCashPayment.Padding = new Padding(6);
            BtnCashPayment.Size = new Size(148, 125);
            BtnCashPayment.TabIndex = 1;
            BtnCashPayment.Text = "Cash Payment ";
            BtnCashPayment.TextAlign = ContentAlignment.BottomCenter;
            BtnCashPayment.TextColor = Color.Black;
            BtnCashPayment.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCashPayment.UseVisualStyleBackColor = false;
            BtnCashPayment.Click += BtnCashPayment_Click;
            // 
            // BtnCashReceipt
            // 
            BtnCashReceipt.Anchor = AnchorStyles.Top;
            BtnCashReceipt.BackColor = Color.Transparent;
            BtnCashReceipt.BackgroundColor = Color.Transparent;
            BtnCashReceipt.BorderColor = Color.Transparent;
            BtnCashReceipt.BorderRadius = 15;
            BtnCashReceipt.BorderSize = 2;
            BtnCashReceipt.FlatAppearance.BorderSize = 0;
            BtnCashReceipt.FlatStyle = FlatStyle.Flat;
            BtnCashReceipt.Font = new Font("Trebuchet MS", 10.2F);
            BtnCashReceipt.ForeColor = Color.Black;
            BtnCashReceipt.Image = Properties.Resources.money_receive;
            BtnCashReceipt.Location = new Point(465, 4);
            BtnCashReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnCashReceipt.Name = "BtnCashReceipt";
            BtnCashReceipt.Padding = new Padding(6);
            BtnCashReceipt.Size = new Size(148, 125);
            BtnCashReceipt.TabIndex = 2;
            BtnCashReceipt.Text = "Cash Receipt\r\n";
            BtnCashReceipt.TextAlign = ContentAlignment.BottomCenter;
            BtnCashReceipt.TextColor = Color.Black;
            BtnCashReceipt.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCashReceipt.UseVisualStyleBackColor = false;
            BtnCashReceipt.Click += BtnCashReceipt_Click;
            // 
            // BtnJournalVoucher
            // 
            BtnJournalVoucher.Anchor = AnchorStyles.Top;
            BtnJournalVoucher.BackColor = Color.Transparent;
            BtnJournalVoucher.BackgroundColor = Color.Transparent;
            BtnJournalVoucher.BorderColor = Color.Transparent;
            BtnJournalVoucher.BorderRadius = 15;
            BtnJournalVoucher.BorderSize = 2;
            BtnJournalVoucher.FlatAppearance.BorderSize = 0;
            BtnJournalVoucher.FlatStyle = FlatStyle.Flat;
            BtnJournalVoucher.Font = new Font("Trebuchet MS", 10.2F);
            BtnJournalVoucher.ForeColor = Color.Black;
            BtnJournalVoucher.Image = Properties.Resources.journal_voucher;
            BtnJournalVoucher.Location = new Point(619, 4);
            BtnJournalVoucher.Margin = new Padding(3, 4, 3, 4);
            BtnJournalVoucher.Name = "BtnJournalVoucher";
            BtnJournalVoucher.Padding = new Padding(6);
            BtnJournalVoucher.Size = new Size(148, 125);
            BtnJournalVoucher.TabIndex = 3;
            BtnJournalVoucher.Text = "Journal Voucher";
            BtnJournalVoucher.TextAlign = ContentAlignment.BottomCenter;
            BtnJournalVoucher.TextColor = Color.Black;
            BtnJournalVoucher.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnJournalVoucher.UseVisualStyleBackColor = false;
            BtnJournalVoucher.Click += BtnJournalVoucher_Click;
            // 
            // BtnCashBook
            // 
            BtnCashBook.Anchor = AnchorStyles.Top;
            BtnCashBook.BackColor = Color.Transparent;
            BtnCashBook.BackgroundColor = Color.Transparent;
            BtnCashBook.BorderColor = Color.Transparent;
            BtnCashBook.BorderRadius = 15;
            BtnCashBook.BorderSize = 2;
            BtnCashBook.FlatAppearance.BorderSize = 0;
            BtnCashBook.FlatStyle = FlatStyle.Flat;
            BtnCashBook.Font = new Font("Trebuchet MS", 10.2F);
            BtnCashBook.ForeColor = Color.Black;
            BtnCashBook.Image = Properties.Resources.cash_book;
            BtnCashBook.Location = new Point(3, 270);
            BtnCashBook.Margin = new Padding(3, 4, 3, 4);
            BtnCashBook.Name = "BtnCashBook";
            BtnCashBook.Padding = new Padding(6);
            BtnCashBook.Size = new Size(148, 127);
            BtnCashBook.TabIndex = 4;
            BtnCashBook.Text = "Cash Book\r\n";
            BtnCashBook.TextAlign = ContentAlignment.BottomCenter;
            BtnCashBook.TextColor = Color.Black;
            BtnCashBook.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnCashBook.UseVisualStyleBackColor = false;
            BtnCashBook.Click += BtnCashBook_Click;
            // 
            // BtnLedgerReport
            // 
            BtnLedgerReport.Anchor = AnchorStyles.Top;
            BtnLedgerReport.BackColor = Color.Transparent;
            BtnLedgerReport.BackgroundColor = Color.Transparent;
            BtnLedgerReport.BorderColor = Color.Transparent;
            BtnLedgerReport.BorderRadius = 15;
            BtnLedgerReport.BorderSize = 2;
            BtnLedgerReport.FlatAppearance.BorderSize = 0;
            BtnLedgerReport.FlatStyle = FlatStyle.Flat;
            BtnLedgerReport.Font = new Font("Trebuchet MS", 10.2F);
            BtnLedgerReport.ForeColor = Color.Black;
            BtnLedgerReport.Image = Properties.Resources.ledger;
            BtnLedgerReport.Location = new Point(157, 270);
            BtnLedgerReport.Margin = new Padding(3, 4, 3, 4);
            BtnLedgerReport.Name = "BtnLedgerReport";
            BtnLedgerReport.Padding = new Padding(6);
            BtnLedgerReport.Size = new Size(148, 127);
            BtnLedgerReport.TabIndex = 5;
            BtnLedgerReport.Text = "Ledger Report\r\n";
            BtnLedgerReport.TextAlign = ContentAlignment.BottomCenter;
            BtnLedgerReport.TextColor = Color.Black;
            BtnLedgerReport.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnLedgerReport.UseVisualStyleBackColor = false;
            BtnLedgerReport.Click += BtnLedgerReport_Click;
            // 
            // BtnEditTransactions
            // 
            BtnEditTransactions.Anchor = AnchorStyles.Top;
            BtnEditTransactions.BackColor = Color.Transparent;
            BtnEditTransactions.BackgroundColor = Color.Transparent;
            BtnEditTransactions.BorderColor = Color.Transparent;
            BtnEditTransactions.BorderRadius = 15;
            BtnEditTransactions.BorderSize = 2;
            BtnEditTransactions.FlatAppearance.BorderSize = 0;
            BtnEditTransactions.FlatStyle = FlatStyle.Flat;
            BtnEditTransactions.Font = new Font("Trebuchet MS", 10.2F);
            BtnEditTransactions.ForeColor = Color.Black;
            BtnEditTransactions.Image = Properties.Resources.Edit;
            BtnEditTransactions.Location = new Point(773, 4);
            BtnEditTransactions.Margin = new Padding(3, 4, 3, 4);
            BtnEditTransactions.Name = "BtnEditTransactions";
            BtnEditTransactions.Padding = new Padding(6);
            BtnEditTransactions.Size = new Size(151, 125);
            BtnEditTransactions.TabIndex = 6;
            BtnEditTransactions.Text = "Edit Transactions";
            BtnEditTransactions.TextAlign = ContentAlignment.BottomCenter;
            BtnEditTransactions.TextColor = Color.Black;
            BtnEditTransactions.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnEditTransactions.UseVisualStyleBackColor = false;
            BtnEditTransactions.Click += BtnEditTransactions_Click;
            // 
            // BtnOpeningBalances
            // 
            BtnOpeningBalances.Anchor = AnchorStyles.Top;
            BtnOpeningBalances.BackColor = Color.Transparent;
            BtnOpeningBalances.BackgroundColor = Color.Transparent;
            BtnOpeningBalances.BorderColor = Color.Transparent;
            BtnOpeningBalances.BorderRadius = 15;
            BtnOpeningBalances.BorderSize = 2;
            BtnOpeningBalances.FlatAppearance.BorderSize = 0;
            BtnOpeningBalances.FlatStyle = FlatStyle.Flat;
            BtnOpeningBalances.Font = new Font("Trebuchet MS", 10.2F);
            BtnOpeningBalances.ForeColor = Color.Black;
            BtnOpeningBalances.Image = Properties.Resources.opening_balance;
            BtnOpeningBalances.Location = new Point(773, 137);
            BtnOpeningBalances.Margin = new Padding(3, 4, 3, 4);
            BtnOpeningBalances.Name = "BtnOpeningBalances";
            BtnOpeningBalances.Padding = new Padding(6);
            BtnOpeningBalances.Size = new Size(151, 125);
            BtnOpeningBalances.TabIndex = 9;
            BtnOpeningBalances.Text = "Opening Balances";
            BtnOpeningBalances.TextAlign = ContentAlignment.BottomCenter;
            BtnOpeningBalances.TextColor = Color.Black;
            BtnOpeningBalances.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnOpeningBalances.UseVisualStyleBackColor = false;
            BtnOpeningBalances.Click += BtnOpeningBalances_Click;
            // 
            // BtnTrialBalance
            // 
            BtnTrialBalance.Anchor = AnchorStyles.Top;
            BtnTrialBalance.BackColor = Color.Transparent;
            BtnTrialBalance.BackgroundColor = Color.Transparent;
            BtnTrialBalance.BorderColor = Color.Transparent;
            BtnTrialBalance.BorderRadius = 15;
            BtnTrialBalance.BorderSize = 2;
            BtnTrialBalance.FlatAppearance.BorderSize = 0;
            BtnTrialBalance.FlatStyle = FlatStyle.Flat;
            BtnTrialBalance.Font = new Font("Trebuchet MS", 10.2F);
            BtnTrialBalance.ForeColor = Color.Black;
            BtnTrialBalance.Image = Properties.Resources.trial_balance;
            BtnTrialBalance.Location = new Point(311, 270);
            BtnTrialBalance.Margin = new Padding(3, 4, 3, 4);
            BtnTrialBalance.Name = "BtnTrialBalance";
            BtnTrialBalance.Padding = new Padding(6);
            BtnTrialBalance.Size = new Size(148, 127);
            BtnTrialBalance.TabIndex = 10;
            BtnTrialBalance.Text = "Trial Balance\r\n";
            BtnTrialBalance.TextAlign = ContentAlignment.BottomCenter;
            BtnTrialBalance.TextColor = Color.Black;
            BtnTrialBalance.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnTrialBalance.UseVisualStyleBackColor = false;
            BtnTrialBalance.Click += BtnTrialBalance_Click;
            // 
            // BtnSalesInvoice
            // 
            BtnSalesInvoice.Anchor = AnchorStyles.Top;
            BtnSalesInvoice.BackColor = Color.Transparent;
            BtnSalesInvoice.BackgroundColor = Color.Transparent;
            BtnSalesInvoice.BorderColor = Color.Transparent;
            BtnSalesInvoice.BorderRadius = 15;
            BtnSalesInvoice.BorderSize = 2;
            BtnSalesInvoice.FlatAppearance.BorderSize = 0;
            BtnSalesInvoice.FlatStyle = FlatStyle.Flat;
            BtnSalesInvoice.Font = new Font("Trebuchet MS", 10.2F);
            BtnSalesInvoice.ForeColor = Color.Black;
            BtnSalesInvoice.Image = Properties.Resources.sale;
            BtnSalesInvoice.Location = new Point(465, 137);
            BtnSalesInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnSalesInvoice.Name = "BtnSalesInvoice";
            BtnSalesInvoice.Padding = new Padding(6);
            BtnSalesInvoice.Size = new Size(148, 125);
            BtnSalesInvoice.TabIndex = 11;
            BtnSalesInvoice.Text = "Sales Invoice\r\n";
            BtnSalesInvoice.TextAlign = ContentAlignment.BottomCenter;
            BtnSalesInvoice.TextColor = Color.Black;
            BtnSalesInvoice.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnSalesInvoice.UseVisualStyleBackColor = false;
            BtnSalesInvoice.Click += BtnSalesInvoice_Click;
            // 
            // BtnProductSetup
            // 
            BtnProductSetup.Anchor = AnchorStyles.Top;
            BtnProductSetup.BackColor = Color.Transparent;
            BtnProductSetup.BackgroundColor = Color.Transparent;
            BtnProductSetup.BorderColor = Color.Transparent;
            BtnProductSetup.BorderRadius = 15;
            BtnProductSetup.BorderSize = 2;
            BtnProductSetup.FlatAppearance.BorderSize = 0;
            BtnProductSetup.FlatStyle = FlatStyle.Flat;
            BtnProductSetup.Font = new Font("Trebuchet MS", 10.2F);
            BtnProductSetup.ForeColor = Color.Black;
            BtnProductSetup.Image = Properties.Resources.add_product;
            BtnProductSetup.Location = new Point(3, 4);
            BtnProductSetup.Margin = new Padding(3, 4, 3, 4);
            BtnProductSetup.Name = "BtnProductSetup";
            BtnProductSetup.Padding = new Padding(6);
            BtnProductSetup.Size = new Size(148, 125);
            BtnProductSetup.TabIndex = 12;
            BtnProductSetup.Text = "Product Setup\r\n";
            BtnProductSetup.TextAlign = ContentAlignment.BottomCenter;
            BtnProductSetup.TextColor = Color.Black;
            BtnProductSetup.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnProductSetup.UseVisualStyleBackColor = false;
            BtnProductSetup.Click += BtnProductSetup_Click;
            // 
            // BtnPurchaseInvoice
            // 
            BtnPurchaseInvoice.Anchor = AnchorStyles.Top;
            BtnPurchaseInvoice.BackColor = Color.Transparent;
            BtnPurchaseInvoice.BackgroundColor = Color.Transparent;
            BtnPurchaseInvoice.BorderColor = Color.Transparent;
            BtnPurchaseInvoice.BorderRadius = 15;
            BtnPurchaseInvoice.BorderSize = 2;
            BtnPurchaseInvoice.FlatAppearance.BorderSize = 0;
            BtnPurchaseInvoice.FlatStyle = FlatStyle.Flat;
            BtnPurchaseInvoice.Font = new Font("Trebuchet MS", 10.2F);
            BtnPurchaseInvoice.ForeColor = Color.Black;
            BtnPurchaseInvoice.Image = Properties.Resources.purchase;
            BtnPurchaseInvoice.Location = new Point(619, 137);
            BtnPurchaseInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnPurchaseInvoice.Name = "BtnPurchaseInvoice";
            BtnPurchaseInvoice.Padding = new Padding(6);
            BtnPurchaseInvoice.Size = new Size(148, 125);
            BtnPurchaseInvoice.TabIndex = 13;
            BtnPurchaseInvoice.Text = "Purchase Invoice\r\n";
            BtnPurchaseInvoice.TextAlign = ContentAlignment.BottomCenter;
            BtnPurchaseInvoice.TextColor = Color.Black;
            BtnPurchaseInvoice.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnPurchaseInvoice.UseVisualStyleBackColor = false;
            BtnPurchaseInvoice.Click += BtnPurchaseInvoice_Click;
            // 
            // BtnStockReport
            // 
            BtnStockReport.Anchor = AnchorStyles.Top;
            BtnStockReport.BackColor = Color.Transparent;
            BtnStockReport.BackgroundColor = Color.Transparent;
            BtnStockReport.BorderColor = Color.Transparent;
            BtnStockReport.BorderRadius = 15;
            BtnStockReport.BorderSize = 2;
            BtnStockReport.FlatAppearance.BorderSize = 0;
            BtnStockReport.FlatStyle = FlatStyle.Flat;
            BtnStockReport.Font = new Font("Trebuchet MS", 10.2F);
            BtnStockReport.ForeColor = Color.Black;
            BtnStockReport.Image = Properties.Resources.stock_report;
            BtnStockReport.Location = new Point(465, 270);
            BtnStockReport.Margin = new Padding(3, 4, 3, 4);
            BtnStockReport.Name = "BtnStockReport";
            BtnStockReport.Padding = new Padding(6);
            BtnStockReport.Size = new Size(148, 127);
            BtnStockReport.TabIndex = 14;
            BtnStockReport.Text = "Stock Report\r\n";
            BtnStockReport.TextAlign = ContentAlignment.BottomCenter;
            BtnStockReport.TextColor = Color.Black;
            BtnStockReport.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnStockReport.UseVisualStyleBackColor = false;
            BtnStockReport.Click += BtnStockReport_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, bankToolStripMenuItem, addNewToolStripMenuItem, itemMovementToolStripMenuItem, reportsToolStripMenuItem, settingsToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1192, 28);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { cashPaymentToolStripMenuItem, cashReceiptToolStripMenuItem, journalVoucherToolStripMenuItem, editTransactionsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(98, 24);
            toolStripMenuItem1.Text = "Transaction";
            // 
            // cashPaymentToolStripMenuItem
            // 
            cashPaymentToolStripMenuItem.Name = "cashPaymentToolStripMenuItem";
            cashPaymentToolStripMenuItem.ShortcutKeys = Keys.F1;
            cashPaymentToolStripMenuItem.Size = new Size(227, 26);
            cashPaymentToolStripMenuItem.Text = "Cash Payment";
            cashPaymentToolStripMenuItem.Click += BtnCashPayment_Click;
            // 
            // cashReceiptToolStripMenuItem
            // 
            cashReceiptToolStripMenuItem.Name = "cashReceiptToolStripMenuItem";
            cashReceiptToolStripMenuItem.ShortcutKeys = Keys.F2;
            cashReceiptToolStripMenuItem.Size = new Size(227, 26);
            cashReceiptToolStripMenuItem.Text = "Cash Receipt";
            cashReceiptToolStripMenuItem.Click += BtnCashReceipt_Click;
            // 
            // journalVoucherToolStripMenuItem
            // 
            journalVoucherToolStripMenuItem.Name = "journalVoucherToolStripMenuItem";
            journalVoucherToolStripMenuItem.ShortcutKeys = Keys.F3;
            journalVoucherToolStripMenuItem.Size = new Size(227, 26);
            journalVoucherToolStripMenuItem.Text = "Journal Voucher";
            journalVoucherToolStripMenuItem.Click += BtnJournalVoucher_Click;
            // 
            // editTransactionsToolStripMenuItem
            // 
            editTransactionsToolStripMenuItem.Name = "editTransactionsToolStripMenuItem";
            editTransactionsToolStripMenuItem.ShortcutKeys = Keys.F6;
            editTransactionsToolStripMenuItem.Size = new Size(227, 26);
            editTransactionsToolStripMenuItem.Text = "Edit Transactions";
            editTransactionsToolStripMenuItem.Click += BtnEditTransactions_Click;
            // 
            // bankToolStripMenuItem
            // 
            bankToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bankPaymentToolStripMenuItem, bankReceiptToolStripMenuItem, chequeBookToolStripMenuItem });
            bankToolStripMenuItem.Name = "bankToolStripMenuItem";
            bankToolStripMenuItem.Size = new Size(55, 24);
            bankToolStripMenuItem.Text = "Bank";
            // 
            // bankPaymentToolStripMenuItem
            // 
            bankPaymentToolStripMenuItem.Name = "bankPaymentToolStripMenuItem";
            bankPaymentToolStripMenuItem.ShortcutKeys = Keys.F9;
            bankPaymentToolStripMenuItem.Size = new Size(231, 26);
            bankPaymentToolStripMenuItem.Text = "Bank Payment";
            bankPaymentToolStripMenuItem.Click += BtnBankPayment_Click;
            // 
            // bankReceiptToolStripMenuItem
            // 
            bankReceiptToolStripMenuItem.Name = "bankReceiptToolStripMenuItem";
            bankReceiptToolStripMenuItem.ShortcutKeys = Keys.F10;
            bankReceiptToolStripMenuItem.Size = new Size(231, 26);
            bankReceiptToolStripMenuItem.Text = "Bank Receipt";
            bankReceiptToolStripMenuItem.Click += BtnBankReceipt_Click;
            // 
            // chequeBookToolStripMenuItem
            // 
            chequeBookToolStripMenuItem.Name = "chequeBookToolStripMenuItem";
            chequeBookToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            chequeBookToolStripMenuItem.Size = new Size(231, 26);
            chequeBookToolStripMenuItem.Text = "Cheque Book";
            chequeBookToolStripMenuItem.Click += BtnChequeBook_Click;
            // 
            // addNewToolStripMenuItem
            // 
            addNewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { accountToolStripMenuItem, viewLedgerToolStripMenuItem, trialBalancesToolStripMenuItem });
            addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            addNewToolStripMenuItem.Size = new Size(83, 24);
            addNewToolStripMenuItem.Text = "Accounts";
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            accountToolStripMenuItem.Size = new Size(240, 26);
            accountToolStripMenuItem.Text = "Account Setup";
            accountToolStripMenuItem.Click += BtnAccountsSetup_Click;
            // 
            // viewLedgerToolStripMenuItem
            // 
            viewLedgerToolStripMenuItem.Name = "viewLedgerToolStripMenuItem";
            viewLedgerToolStripMenuItem.ShortcutKeys = Keys.F7;
            viewLedgerToolStripMenuItem.Size = new Size(240, 26);
            viewLedgerToolStripMenuItem.Text = "View Ledger";
            // 
            // trialBalancesToolStripMenuItem
            // 
            trialBalancesToolStripMenuItem.Name = "trialBalancesToolStripMenuItem";
            trialBalancesToolStripMenuItem.ShortcutKeys = Keys.F12;
            trialBalancesToolStripMenuItem.Size = new Size(240, 26);
            trialBalancesToolStripMenuItem.Text = "Trial Balances";
            // 
            // itemMovementToolStripMenuItem
            // 
            itemMovementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productToolStripMenuItem, saleInvoiceToolStripMenuItem, purchaseInvoiceToolStripMenuItem, stocToolStripMenuItem });
            itemMovementToolStripMenuItem.Name = "itemMovementToolStripMenuItem";
            itemMovementToolStripMenuItem.Size = new Size(74, 24);
            itemMovementToolStripMenuItem.Text = "Product";
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            productToolStripMenuItem.Size = new Size(235, 26);
            productToolStripMenuItem.Text = "Product Setup";
            // 
            // saleInvoiceToolStripMenuItem
            // 
            saleInvoiceToolStripMenuItem.Name = "saleInvoiceToolStripMenuItem";
            saleInvoiceToolStripMenuItem.ShortcutKeys = Keys.F5;
            saleInvoiceToolStripMenuItem.Size = new Size(235, 26);
            saleInvoiceToolStripMenuItem.Text = "Sale Invoice";
            saleInvoiceToolStripMenuItem.Click += BtnSalesInvoice_Click;
            // 
            // purchaseInvoiceToolStripMenuItem
            // 
            purchaseInvoiceToolStripMenuItem.Name = "purchaseInvoiceToolStripMenuItem";
            purchaseInvoiceToolStripMenuItem.ShortcutKeys = Keys.F4;
            purchaseInvoiceToolStripMenuItem.Size = new Size(235, 26);
            purchaseInvoiceToolStripMenuItem.Text = "Purchase Invoice";
            purchaseInvoiceToolStripMenuItem.Click += BtnPurchaseInvoice_Click;
            // 
            // stocToolStripMenuItem
            // 
            stocToolStripMenuItem.Name = "stocToolStripMenuItem";
            stocToolStripMenuItem.ShortcutKeys = Keys.F11;
            stocToolStripMenuItem.Size = new Size(235, 26);
            stocToolStripMenuItem.Text = "Stock Report";
            stocToolStripMenuItem.Click += BtnStockReport_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cashBookToolStripMenuItem, aIAssistantToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(74, 24);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // cashBookToolStripMenuItem
            // 
            cashBookToolStripMenuItem.Name = "cashBookToolStripMenuItem";
            cashBookToolStripMenuItem.ShortcutKeys = Keys.F8;
            cashBookToolStripMenuItem.Size = new Size(220, 26);
            cashBookToolStripMenuItem.Text = "Cash Book ";
            cashBookToolStripMenuItem.Click += BtnCashBook_Click;
            // 
            // aIAssistantToolStripMenuItem
            // 
            aIAssistantToolStripMenuItem.Name = "aIAssistantToolStripMenuItem";
            aIAssistantToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            aIAssistantToolStripMenuItem.Size = new Size(220, 26);
            aIAssistantToolStripMenuItem.Text = "AI Assistant";
            aIAssistantToolStripMenuItem.Click += btnAiAssistant_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem1, enableFavoritesPanelToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // settingsToolStripMenuItem1
            // 
            settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            settingsToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.S;
            settingsToolStripMenuItem1.Size = new Size(239, 26);
            settingsToolStripMenuItem1.Text = "Settings";
            settingsToolStripMenuItem1.Click += BtnSettings_Click;
            // 
            // enableFavoritesPanelToolStripMenuItem
            // 
            enableFavoritesPanelToolStripMenuItem.Checked = true;
            enableFavoritesPanelToolStripMenuItem.CheckOnClick = true;
            enableFavoritesPanelToolStripMenuItem.CheckState = CheckState.Checked;
            enableFavoritesPanelToolStripMenuItem.Name = "enableFavoritesPanelToolStripMenuItem";
            enableFavoritesPanelToolStripMenuItem.Size = new Size(239, 26);
            enableFavoritesPanelToolStripMenuItem.Text = "Enable favorites panel";
            enableFavoritesPanelToolStripMenuItem.CheckStateChanged += enableFavoritesPanelToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abountMeToolStripMenuItem, sqlQueryRunnerToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(64, 24);
            aboutToolStripMenuItem.Text = "About";
            // 
            // abountMeToolStripMenuItem
            // 
            abountMeToolStripMenuItem.Name = "abountMeToolStripMenuItem";
            abountMeToolStripMenuItem.Size = new Size(224, 26);
            abountMeToolStripMenuItem.Text = "Abount Me";
            abountMeToolStripMenuItem.Click += abountMeToolStripMenuItem_Click;
            // 
            // BtnBankReceipt
            // 
            BtnBankReceipt.Anchor = AnchorStyles.Top;
            BtnBankReceipt.BackColor = Color.Transparent;
            BtnBankReceipt.BackgroundColor = Color.Transparent;
            BtnBankReceipt.BorderColor = Color.Transparent;
            BtnBankReceipt.BorderRadius = 15;
            BtnBankReceipt.BorderSize = 2;
            BtnBankReceipt.FlatAppearance.BorderSize = 0;
            BtnBankReceipt.FlatStyle = FlatStyle.Flat;
            BtnBankReceipt.Font = new Font("Trebuchet MS", 10.2F);
            BtnBankReceipt.ForeColor = Color.Black;
            BtnBankReceipt.Image = Properties.Resources.bank_received;
            BtnBankReceipt.Location = new Point(157, 137);
            BtnBankReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnBankReceipt.Name = "BtnBankReceipt";
            BtnBankReceipt.Padding = new Padding(6);
            BtnBankReceipt.Size = new Size(148, 125);
            BtnBankReceipt.TabIndex = 17;
            BtnBankReceipt.Text = "Bank Receipt\r\n";
            BtnBankReceipt.TextAlign = ContentAlignment.BottomCenter;
            BtnBankReceipt.TextColor = Color.Black;
            BtnBankReceipt.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBankReceipt.UseVisualStyleBackColor = false;
            BtnBankReceipt.Click += BtnBankReceipt_Click;
            // 
            // BtnBankPayment
            // 
            BtnBankPayment.Anchor = AnchorStyles.Top;
            BtnBankPayment.BackColor = Color.Transparent;
            BtnBankPayment.BackgroundColor = Color.Transparent;
            BtnBankPayment.BorderColor = Color.Transparent;
            BtnBankPayment.BorderRadius = 15;
            BtnBankPayment.BorderSize = 2;
            BtnBankPayment.FlatAppearance.BorderSize = 0;
            BtnBankPayment.FlatStyle = FlatStyle.Flat;
            BtnBankPayment.Font = new Font("Trebuchet MS", 10.2F);
            BtnBankPayment.ForeColor = Color.Black;
            BtnBankPayment.Image = Properties.Resources.bank_payment;
            BtnBankPayment.Location = new Point(3, 137);
            BtnBankPayment.Margin = new Padding(3, 4, 3, 4);
            BtnBankPayment.Name = "BtnBankPayment";
            BtnBankPayment.Padding = new Padding(6);
            BtnBankPayment.Size = new Size(148, 125);
            BtnBankPayment.TabIndex = 16;
            BtnBankPayment.Text = "Bank Payment";
            BtnBankPayment.TextAlign = ContentAlignment.BottomCenter;
            BtnBankPayment.TextColor = Color.Black;
            BtnBankPayment.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBankPayment.UseVisualStyleBackColor = false;
            BtnBankPayment.Click += BtnBankPayment_Click;
            // 
            // BtnChequeBook
            // 
            BtnChequeBook.Anchor = AnchorStyles.Top;
            BtnChequeBook.BackColor = Color.Transparent;
            BtnChequeBook.BackgroundColor = Color.Transparent;
            BtnChequeBook.BorderColor = Color.Transparent;
            BtnChequeBook.BorderRadius = 15;
            BtnChequeBook.BorderSize = 2;
            BtnChequeBook.FlatAppearance.BorderSize = 0;
            BtnChequeBook.FlatStyle = FlatStyle.Flat;
            BtnChequeBook.Font = new Font("Trebuchet MS", 10.2F);
            BtnChequeBook.ForeColor = Color.Black;
            BtnChequeBook.Image = Properties.Resources.cheque_book;
            BtnChequeBook.Location = new Point(311, 137);
            BtnChequeBook.Margin = new Padding(3, 4, 3, 4);
            BtnChequeBook.Name = "BtnChequeBook";
            BtnChequeBook.Padding = new Padding(6);
            BtnChequeBook.Size = new Size(148, 125);
            BtnChequeBook.TabIndex = 18;
            BtnChequeBook.Text = "Cheque Book\r\n";
            BtnChequeBook.TextAlign = ContentAlignment.BottomCenter;
            BtnChequeBook.TextColor = Color.Black;
            BtnChequeBook.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnChequeBook.UseVisualStyleBackColor = false;
            BtnChequeBook.Click += BtnChequeBook_Click;
            // 
            // BtnSettings
            // 
            BtnSettings.Anchor = AnchorStyles.Top;
            BtnSettings.BackColor = Color.Transparent;
            BtnSettings.BackgroundColor = Color.Transparent;
            BtnSettings.BorderColor = Color.Transparent;
            BtnSettings.BorderRadius = 9;
            BtnSettings.BorderSize = 2;
            BtnSettings.FlatAppearance.BorderSize = 0;
            BtnSettings.FlatStyle = FlatStyle.Flat;
            BtnSettings.Font = new Font("Trebuchet MS", 10.2F);
            BtnSettings.ForeColor = Color.Black;
            BtnSettings.Image = Properties.Resources.settings;
            BtnSettings.Location = new Point(619, 270);
            BtnSettings.Margin = new Padding(3, 4, 3, 4);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Padding = new Padding(6);
            BtnSettings.Size = new Size(148, 127);
            BtnSettings.TabIndex = 19;
            BtnSettings.Text = "Settings";
            BtnSettings.TextAlign = ContentAlignment.BottomCenter;
            BtnSettings.TextColor = Color.Black;
            BtnSettings.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnSettings.UseVisualStyleBackColor = false;
            BtnSettings.Click += BtnSettings_Click;
            // 
            // BtnBackupData
            // 
            BtnBackupData.Anchor = AnchorStyles.Top;
            BtnBackupData.BackColor = Color.Transparent;
            BtnBackupData.BackgroundColor = Color.Transparent;
            BtnBackupData.BorderColor = Color.Transparent;
            BtnBackupData.BorderRadius = 9;
            BtnBackupData.BorderSize = 2;
            BtnBackupData.FlatAppearance.BorderSize = 0;
            BtnBackupData.FlatStyle = FlatStyle.Flat;
            BtnBackupData.Font = new Font("Trebuchet MS", 10.2F);
            BtnBackupData.ForeColor = Color.Black;
            BtnBackupData.Image = Properties.Resources.data_backup;
            BtnBackupData.Location = new Point(773, 270);
            BtnBackupData.Margin = new Padding(3, 4, 3, 4);
            BtnBackupData.Name = "BtnBackupData";
            BtnBackupData.Padding = new Padding(6);
            BtnBackupData.Size = new Size(151, 127);
            BtnBackupData.TabIndex = 20;
            BtnBackupData.Text = "Backup Data";
            BtnBackupData.TextAlign = ContentAlignment.BottomCenter;
            BtnBackupData.TextColor = Color.Black;
            BtnBackupData.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBackupData.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BackgroundColor = Color.Transparent;
            btnLogout.BackgroundImage = Properties.Resources.user_logout;
            btnLogout.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogout.BorderColor = Color.Transparent;
            btnLogout.BorderRadius = 2;
            btnLogout.BorderSize = 0;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Red;
            btnLogout.Location = new Point(737, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(42, 35);
            btnLogout.TabIndex = 1;
            btnLogout.TextColor = Color.Red;
            toolTip1.SetToolTip(btnLogout, "Logout");
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAiAssistant
            // 
            btnAiAssistant.Anchor = AnchorStyles.Top;
            btnAiAssistant.BackColor = Color.Transparent;
            btnAiAssistant.BackgroundColor = Color.Transparent;
            btnAiAssistant.BackgroundImage = Properties.Resources.ai_chip_icon_png;
            btnAiAssistant.BackgroundImageLayout = ImageLayout.Zoom;
            btnAiAssistant.BorderColor = Color.Transparent;
            btnAiAssistant.BorderRadius = 9;
            btnAiAssistant.BorderSize = 2;
            btnAiAssistant.FlatAppearance.BorderSize = 0;
            btnAiAssistant.FlatStyle = FlatStyle.Flat;
            btnAiAssistant.Font = new Font("Trebuchet MS", 10.2F);
            btnAiAssistant.ForeColor = Color.Black;
            btnAiAssistant.Location = new Point(3, 405);
            btnAiAssistant.Margin = new Padding(3, 4, 3, 4);
            btnAiAssistant.Name = "btnAiAssistant";
            btnAiAssistant.Padding = new Padding(6);
            btnAiAssistant.Size = new Size(151, 127);
            btnAiAssistant.TabIndex = 21;
            btnAiAssistant.TextAlign = ContentAlignment.BottomCenter;
            btnAiAssistant.TextColor = Color.Black;
            btnAiAssistant.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(btnAiAssistant, "AI Assistant");
            btnAiAssistant.UseVisualStyleBackColor = false;
            btnAiAssistant.Click += btnAiAssistant_Click;
            // 
            // pnlFavorites
            // 
            pnlFavorites.AutoScroll = true;
            pnlFavorites.BackColor = Color.FromArgb(34, 34, 34);
            pnlFavorites.Controls.Add(lblFavHeader);
            pnlFavorites.Dock = DockStyle.Left;
            pnlFavorites.ForeColor = SystemColors.ButtonHighlight;
            pnlFavorites.Location = new Point(0, 28);
            pnlFavorites.Name = "pnlFavorites";
            pnlFavorites.Size = new Size(259, 743);
            pnlFavorites.TabIndex = 22;
            // 
            // lblFavHeader
            // 
            lblFavHeader.AutoSize = true;
            lblFavHeader.Dock = DockStyle.Top;
            lblFavHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFavHeader.Location = new Point(3, 0);
            lblFavHeader.Name = "lblFavHeader";
            lblFavHeader.Padding = new Padding(20);
            lblFavHeader.Size = new Size(185, 68);
            lblFavHeader.TabIndex = 0;
            lblFavHeader.Text = "Your Favorites";
            // 
            // stockReportToolStripMenuItem
            // 
            stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
            stockReportToolStripMenuItem.ShortcutKeys = Keys.F11;
            stockReportToolStripMenuItem.Size = new Size(235, 26);
            stockReportToolStripMenuItem.Text = "Stock Report";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.GrayText;
            lblUsername.Location = new Point(785, 0);
            lblUsername.Margin = new Padding(3, 0, 8, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(140, 41);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Unknown User";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblUsername);
            flowLayoutPanel1.Controls.Add(btnLogout);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(259, 726);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(933, 45);
            flowLayoutPanel1.TabIndex = 23;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Controls.Add(BtnProductSetup);
            flowLayoutPanel2.Controls.Add(BtnAccountsSetup);
            flowLayoutPanel2.Controls.Add(BtnCashPayment);
            flowLayoutPanel2.Controls.Add(BtnCashReceipt);
            flowLayoutPanel2.Controls.Add(BtnJournalVoucher);
            flowLayoutPanel2.Controls.Add(BtnEditTransactions);
            flowLayoutPanel2.Controls.Add(BtnBankPayment);
            flowLayoutPanel2.Controls.Add(BtnBankReceipt);
            flowLayoutPanel2.Controls.Add(BtnChequeBook);
            flowLayoutPanel2.Controls.Add(BtnSalesInvoice);
            flowLayoutPanel2.Controls.Add(BtnPurchaseInvoice);
            flowLayoutPanel2.Controls.Add(BtnOpeningBalances);
            flowLayoutPanel2.Controls.Add(BtnCashBook);
            flowLayoutPanel2.Controls.Add(BtnLedgerReport);
            flowLayoutPanel2.Controls.Add(BtnTrialBalance);
            flowLayoutPanel2.Controls.Add(BtnStockReport);
            flowLayoutPanel2.Controls.Add(BtnSettings);
            flowLayoutPanel2.Controls.Add(BtnBackupData);
            flowLayoutPanel2.Controls.Add(btnAiAssistant);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(259, 28);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(933, 698);
            flowLayoutPanel2.TabIndex = 24;
            // 
            // BtnAccountsSetup
            // 
            BtnAccountsSetup.Anchor = AnchorStyles.Top;
            BtnAccountsSetup.BackColor = Color.Transparent;
            BtnAccountsSetup.BackgroundColor = Color.Transparent;
            BtnAccountsSetup.BorderColor = Color.Transparent;
            BtnAccountsSetup.BorderRadius = 15;
            BtnAccountsSetup.BorderSize = 2;
            BtnAccountsSetup.FlatAppearance.BorderSize = 0;
            BtnAccountsSetup.FlatStyle = FlatStyle.Flat;
            BtnAccountsSetup.Font = new Font("Trebuchet MS", 10.2F);
            BtnAccountsSetup.ForeColor = Color.Black;
            BtnAccountsSetup.Image = Properties.Resources.add_user;
            BtnAccountsSetup.Location = new Point(157, 4);
            BtnAccountsSetup.Margin = new Padding(3, 4, 3, 4);
            BtnAccountsSetup.Name = "BtnAccountsSetup";
            BtnAccountsSetup.Padding = new Padding(6);
            BtnAccountsSetup.Size = new Size(148, 125);
            BtnAccountsSetup.TabIndex = 13;
            BtnAccountsSetup.Text = "Accounts Setup";
            BtnAccountsSetup.TextAlign = ContentAlignment.BottomCenter;
            BtnAccountsSetup.TextColor = Color.Black;
            BtnAccountsSetup.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnAccountsSetup.UseVisualStyleBackColor = false;
            BtnAccountsSetup.Click += BtnAccountsSetup_Click;
            // 
            // sqlQueryRunnerToolStripMenuItem
            // 
            sqlQueryRunnerToolStripMenuItem.Name = "sqlQueryRunnerToolStripMenuItem";
            sqlQueryRunnerToolStripMenuItem.Size = new Size(224, 26);
            sqlQueryRunnerToolStripMenuItem.Text = "Sql Query Runner";
            sqlQueryRunnerToolStripMenuItem.Click += sqlQueryRunnerToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1192, 771);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pnlFavorites);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EasyBiz: By Shamsuddin";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlFavorites.ResumeLayout(false);
            pnlFavorites.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CustomButton BtnCashPayment;
        private CustomButton BtnCashReceipt;
        private CustomButton BtnJournalVoucher;
        private CustomButton BtnCashBook;
        private CustomButton BtnLedgerReport;
        private CustomButton BtnEditTransactions;
        private CustomButton BtnOpeningBalances;
        private CustomButton BtnTrialBalance;
        private CustomButton BtnSalesInvoice;
        private CustomButton BtnProductSetup;
        private CustomButton BtnPurchaseInvoice;
        private CustomButton BtnStockReport;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem cashPaymentToolStripMenuItem;
        private ToolStripMenuItem cashReceiptToolStripMenuItem;
        private ToolStripMenuItem journalVoucherToolStripMenuItem;
        private ToolStripMenuItem editTransactionsToolStripMenuItem;
        private ToolStripMenuItem addNewToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem itemMovementToolStripMenuItem;
        private ToolStripMenuItem saleInvoiceToolStripMenuItem;
        private ToolStripMenuItem purchaseInvoiceToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem cashBookToolStripMenuItem;
        private CustomButton BtnBankReceipt;
        private CustomButton BtnBankPayment;
        private CustomButton BtnChequeBook;
        private ToolStripMenuItem bankToolStripMenuItem;
        private ToolStripMenuItem bankPaymentToolStripMenuItem;
        private ToolStripMenuItem bankReceiptToolStripMenuItem;
        private ToolStripMenuItem chequeBookToolStripMenuItem;
        private CustomButton BtnSettings;
        private CustomButton BtnBackupData;
        private ToolTip toolTip1;
        private ToolStripMenuItem viewLedgerToolStripMenuItem;
        private ToolStripMenuItem trialBalancesToolStripMenuItem;
        private ToolStripMenuItem stockReportToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem stocToolStripMenuItem;
        private CustomButton btnLogout;
        private Label lblUsername;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private CustomButton BtnAccountsSetup;
        public FlowLayoutPanel pnlFavorites;
        private CustomButton btnAiAssistant;
        private ToolStripMenuItem aIAssistantToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem1;
        private Label lblFavHeader;
        public ToolStripMenuItem enableFavoritesPanelToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem abountMeToolStripMenuItem;
        private ToolStripMenuItem sqlQueryRunnerToolStripMenuItem;
    }
}
