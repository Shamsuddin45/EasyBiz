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
            BtnAccountsSetup = new CustomButton();
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
            BtnBankReceipt = new CustomButton();
            BtnBankPayment = new CustomButton();
            BtnChequeBook = new CustomButton();
            BtnSettings = new CustomButton();
            BtnBackupData = new CustomButton();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlFavorites = new FlowLayoutPanel();
            stockReportToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            btnLogout = new CustomButton();
            lblUsername = new Label();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnAccountsSetup
            // 
            BtnAccountsSetup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            BtnAccountsSetup.BackColor = Color.Transparent;
            BtnAccountsSetup.BackgroundColor = Color.Transparent;
            BtnAccountsSetup.BorderColor = Color.Transparent;
            BtnAccountsSetup.BorderRadius = 15;
            BtnAccountsSetup.BorderSize = 2;
            BtnAccountsSetup.FlatAppearance.BorderSize = 0;
            BtnAccountsSetup.FlatStyle = FlatStyle.Flat;
            BtnAccountsSetup.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnAccountsSetup.ForeColor = Color.MidnightBlue;
            BtnAccountsSetup.Image = Properties.Resources.add_user;
            BtnAccountsSetup.Location = new Point(3, 4);
            BtnAccountsSetup.Margin = new Padding(3, 4, 3, 4);
            BtnAccountsSetup.Name = "BtnAccountsSetup";
            BtnAccountsSetup.Padding = new Padding(6);
            BtnAccountsSetup.Size = new Size(148, 125);
            BtnAccountsSetup.TabIndex = 0;
            BtnAccountsSetup.Text = "Accounts Setup";
            BtnAccountsSetup.TextAlign = ContentAlignment.BottomCenter;
            BtnAccountsSetup.TextColor = Color.MidnightBlue;
            BtnAccountsSetup.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnAccountsSetup.UseVisualStyleBackColor = false;
            BtnAccountsSetup.Click += BtnAccountsSetup_Click;
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
            BtnCashPayment.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnCashPayment.ForeColor = Color.Black;
            BtnCashPayment.Image = Properties.Resources.money_pay;
            BtnCashPayment.Location = new Point(311, 4);
            BtnCashPayment.Margin = new Padding(3, 4, 3, 4);
            BtnCashPayment.Name = "BtnCashPayment";
            BtnCashPayment.Padding = new Padding(6);
            BtnCashPayment.Size = new Size(148, 125);
            BtnCashPayment.TabIndex = 1;
            BtnCashPayment.Text = "Cash Payment ";
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
            BtnCashReceipt.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnCashReceipt.ForeColor = Color.Black;
            BtnCashReceipt.Image = Properties.Resources.money_receive;
            BtnCashReceipt.Location = new Point(465, 4);
            BtnCashReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnCashReceipt.Name = "BtnCashReceipt";
            BtnCashReceipt.Padding = new Padding(6);
            BtnCashReceipt.Size = new Size(148, 125);
            BtnCashReceipt.TabIndex = 2;
            BtnCashReceipt.Text = "Cash Receipt\r\n";
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
            BtnJournalVoucher.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnJournalVoucher.ForeColor = Color.Black;
            BtnJournalVoucher.Image = Properties.Resources.journal_voucher;
            BtnJournalVoucher.Location = new Point(619, 4);
            BtnJournalVoucher.Margin = new Padding(3, 4, 3, 4);
            BtnJournalVoucher.Name = "BtnJournalVoucher";
            BtnJournalVoucher.Padding = new Padding(6);
            BtnJournalVoucher.Size = new Size(148, 125);
            BtnJournalVoucher.TabIndex = 3;
            BtnJournalVoucher.Text = "Journal Voucher";
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
            BtnCashBook.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnCashBook.ForeColor = Color.Black;
            BtnCashBook.Image = Properties.Resources.cash_book;
            BtnCashBook.Location = new Point(3, 270);
            BtnCashBook.Margin = new Padding(3, 4, 3, 4);
            BtnCashBook.Name = "BtnCashBook";
            BtnCashBook.Padding = new Padding(6);
            BtnCashBook.Size = new Size(148, 127);
            BtnCashBook.TabIndex = 4;
            BtnCashBook.Text = "Cash Book\r\n";
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
            BtnLedgerReport.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnLedgerReport.ForeColor = Color.Black;
            BtnLedgerReport.Image = Properties.Resources.ledger;
            BtnLedgerReport.Location = new Point(157, 270);
            BtnLedgerReport.Margin = new Padding(3, 4, 3, 4);
            BtnLedgerReport.Name = "BtnLedgerReport";
            BtnLedgerReport.Padding = new Padding(6);
            BtnLedgerReport.Size = new Size(148, 127);
            BtnLedgerReport.TabIndex = 5;
            BtnLedgerReport.Text = "Ledger Report\r\n";
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
            BtnEditTransactions.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnEditTransactions.ForeColor = Color.Black;
            BtnEditTransactions.Image = Properties.Resources.Edit;
            BtnEditTransactions.Location = new Point(773, 4);
            BtnEditTransactions.Margin = new Padding(3, 4, 3, 4);
            BtnEditTransactions.Name = "BtnEditTransactions";
            BtnEditTransactions.Padding = new Padding(6);
            BtnEditTransactions.Size = new Size(151, 125);
            BtnEditTransactions.TabIndex = 6;
            BtnEditTransactions.Text = "Edit Transactions";
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
            BtnOpeningBalances.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnOpeningBalances.ForeColor = Color.Black;
            BtnOpeningBalances.Image = Properties.Resources.opening_balance;
            BtnOpeningBalances.Location = new Point(773, 137);
            BtnOpeningBalances.Margin = new Padding(3, 4, 3, 4);
            BtnOpeningBalances.Name = "BtnOpeningBalances";
            BtnOpeningBalances.Padding = new Padding(6);
            BtnOpeningBalances.Size = new Size(151, 125);
            BtnOpeningBalances.TabIndex = 9;
            BtnOpeningBalances.Text = "Opening Balances";
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
            BtnTrialBalance.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnTrialBalance.ForeColor = Color.Black;
            BtnTrialBalance.Image = Properties.Resources.trial_balance;
            BtnTrialBalance.Location = new Point(311, 270);
            BtnTrialBalance.Margin = new Padding(3, 4, 3, 4);
            BtnTrialBalance.Name = "BtnTrialBalance";
            BtnTrialBalance.Padding = new Padding(6);
            BtnTrialBalance.Size = new Size(148, 127);
            BtnTrialBalance.TabIndex = 10;
            BtnTrialBalance.Text = "Trial Balance\r\n";
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
            BtnSalesInvoice.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnSalesInvoice.ForeColor = Color.Black;
            BtnSalesInvoice.Image = Properties.Resources.sale;
            BtnSalesInvoice.Location = new Point(465, 137);
            BtnSalesInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnSalesInvoice.Name = "BtnSalesInvoice";
            BtnSalesInvoice.Padding = new Padding(6);
            BtnSalesInvoice.Size = new Size(148, 125);
            BtnSalesInvoice.TabIndex = 11;
            BtnSalesInvoice.Text = "Sales Invoice\r\n";
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
            BtnProductSetup.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnProductSetup.ForeColor = Color.Black;
            BtnProductSetup.Image = Properties.Resources.add_product;
            BtnProductSetup.Location = new Point(157, 4);
            BtnProductSetup.Margin = new Padding(3, 4, 3, 4);
            BtnProductSetup.Name = "BtnProductSetup";
            BtnProductSetup.Padding = new Padding(6);
            BtnProductSetup.Size = new Size(148, 125);
            BtnProductSetup.TabIndex = 12;
            BtnProductSetup.Text = "Product Setup\r\n";
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
            BtnPurchaseInvoice.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnPurchaseInvoice.ForeColor = Color.Black;
            BtnPurchaseInvoice.Image = Properties.Resources.purchase;
            BtnPurchaseInvoice.Location = new Point(619, 137);
            BtnPurchaseInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnPurchaseInvoice.Name = "BtnPurchaseInvoice";
            BtnPurchaseInvoice.Padding = new Padding(6);
            BtnPurchaseInvoice.Size = new Size(148, 125);
            BtnPurchaseInvoice.TabIndex = 13;
            BtnPurchaseInvoice.Text = "Purchase Invoice\r\n";
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
            BtnStockReport.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnStockReport.ForeColor = Color.Black;
            BtnStockReport.Image = Properties.Resources.stock_report;
            BtnStockReport.Location = new Point(465, 270);
            BtnStockReport.Margin = new Padding(3, 4, 3, 4);
            BtnStockReport.Name = "BtnStockReport";
            BtnStockReport.Padding = new Padding(6);
            BtnStockReport.Size = new Size(148, 127);
            BtnStockReport.TabIndex = 14;
            BtnStockReport.Text = "Stock Report\r\n";
            BtnStockReport.TextColor = Color.Black;
            BtnStockReport.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnStockReport.UseVisualStyleBackColor = false;
            BtnStockReport.Click += BtnStockReport_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, bankToolStripMenuItem, addNewToolStripMenuItem, itemMovementToolStripMenuItem, reportsToolStripMenuItem });
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
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cashBookToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(74, 24);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // cashBookToolStripMenuItem
            // 
            cashBookToolStripMenuItem.Name = "cashBookToolStripMenuItem";
            cashBookToolStripMenuItem.ShortcutKeys = Keys.F8;
            cashBookToolStripMenuItem.Size = new Size(189, 26);
            cashBookToolStripMenuItem.Text = "Cash Book ";
            cashBookToolStripMenuItem.Click += BtnCashBook_Click;
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
            BtnBankReceipt.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnBankReceipt.ForeColor = Color.Black;
            BtnBankReceipt.Image = Properties.Resources.bank_received;
            BtnBankReceipt.Location = new Point(157, 137);
            BtnBankReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnBankReceipt.Name = "BtnBankReceipt";
            BtnBankReceipt.Padding = new Padding(6);
            BtnBankReceipt.Size = new Size(148, 125);
            BtnBankReceipt.TabIndex = 17;
            BtnBankReceipt.Text = "Bank Receipt\r\n";
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
            BtnBankPayment.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnBankPayment.ForeColor = Color.Black;
            BtnBankPayment.Image = Properties.Resources.bank_payment;
            BtnBankPayment.Location = new Point(3, 137);
            BtnBankPayment.Margin = new Padding(3, 4, 3, 4);
            BtnBankPayment.Name = "BtnBankPayment";
            BtnBankPayment.Padding = new Padding(6);
            BtnBankPayment.Size = new Size(148, 125);
            BtnBankPayment.TabIndex = 16;
            BtnBankPayment.Text = "Bank Payment";
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
            BtnChequeBook.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnChequeBook.ForeColor = Color.Black;
            BtnChequeBook.Image = Properties.Resources.cheque_book;
            BtnChequeBook.Location = new Point(311, 137);
            BtnChequeBook.Margin = new Padding(3, 4, 3, 4);
            BtnChequeBook.Name = "BtnChequeBook";
            BtnChequeBook.Padding = new Padding(6);
            BtnChequeBook.Size = new Size(148, 125);
            BtnChequeBook.TabIndex = 18;
            BtnChequeBook.Text = "Cheque Book\r\n";
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
            BtnSettings.BorderRadius = 15;
            BtnSettings.BorderSize = 2;
            BtnSettings.FlatAppearance.BorderSize = 0;
            BtnSettings.FlatStyle = FlatStyle.Flat;
            BtnSettings.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnSettings.ForeColor = Color.Black;
            BtnSettings.Image = Properties.Resources.settings;
            BtnSettings.Location = new Point(619, 270);
            BtnSettings.Margin = new Padding(3, 4, 3, 4);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Padding = new Padding(6);
            BtnSettings.Size = new Size(148, 127);
            BtnSettings.TabIndex = 19;
            BtnSettings.Text = "Settings";
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
            BtnBackupData.BorderRadius = 15;
            BtnBackupData.BorderSize = 2;
            BtnBackupData.FlatAppearance.BorderSize = 0;
            BtnBackupData.FlatStyle = FlatStyle.Flat;
            BtnBackupData.Font = new Font("Microsoft Sans Serif", 10.2F);
            BtnBackupData.ForeColor = Color.Black;
            BtnBackupData.Image = Properties.Resources.data_backup;
            BtnBackupData.Location = new Point(773, 270);
            BtnBackupData.Margin = new Padding(3, 4, 3, 4);
            BtnBackupData.Name = "BtnBackupData";
            BtnBackupData.Padding = new Padding(6);
            BtnBackupData.Size = new Size(151, 127);
            BtnBackupData.TabIndex = 20;
            BtnBackupData.Text = "Backup Data";
            BtnBackupData.TextColor = Color.Black;
            BtnBackupData.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBackupData.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666641F));
            tableLayoutPanel1.Controls.Add(BtnAccountsSetup, 0, 0);
            tableLayoutPanel1.Controls.Add(BtnBackupData, 5, 2);
            tableLayoutPanel1.Controls.Add(BtnProductSetup, 1, 0);
            tableLayoutPanel1.Controls.Add(BtnSettings, 4, 2);
            tableLayoutPanel1.Controls.Add(BtnCashPayment, 2, 0);
            tableLayoutPanel1.Controls.Add(BtnStockReport, 3, 2);
            tableLayoutPanel1.Controls.Add(BtnChequeBook, 2, 1);
            tableLayoutPanel1.Controls.Add(BtnTrialBalance, 2, 2);
            tableLayoutPanel1.Controls.Add(BtnPurchaseInvoice, 4, 1);
            tableLayoutPanel1.Controls.Add(BtnLedgerReport, 1, 2);
            tableLayoutPanel1.Controls.Add(BtnOpeningBalances, 5, 1);
            tableLayoutPanel1.Controls.Add(BtnCashBook, 0, 2);
            tableLayoutPanel1.Controls.Add(BtnCashReceipt, 3, 0);
            tableLayoutPanel1.Controls.Add(BtnSalesInvoice, 3, 1);
            tableLayoutPanel1.Controls.Add(BtnBankReceipt, 1, 1);
            tableLayoutPanel1.Controls.Add(BtnJournalVoucher, 4, 0);
            tableLayoutPanel1.Controls.Add(BtnBankPayment, 0, 1);
            tableLayoutPanel1.Controls.Add(BtnEditTransactions, 5, 0);
            tableLayoutPanel1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableLayoutPanel1.Location = new Point(265, 31);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3328667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3328667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3342628F));
            tableLayoutPanel1.Size = new Size(927, 401);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // pnlFavorites
            // 
            pnlFavorites.AutoScroll = true;
            pnlFavorites.Dock = DockStyle.Left;
            pnlFavorites.Location = new Point(0, 28);
            pnlFavorites.Name = "pnlFavorites";
            pnlFavorites.Size = new Size(259, 645);
            pnlFavorites.TabIndex = 22;
            // 
            // stockReportToolStripMenuItem
            // 
            stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
            stockReportToolStripMenuItem.ShortcutKeys = Keys.F11;
            stockReportToolStripMenuItem.Size = new Size(235, 26);
            stockReportToolStripMenuItem.Text = "Stock Report";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(lblUsername);
            panel1.Location = new Point(897, 613);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 60);
            panel1.TabIndex = 23;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BackgroundColor = Color.Transparent;
            btnLogout.BorderColor = Color.Transparent;
            btnLogout.BorderRadius = 2;
            btnLogout.BorderSize = 0;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Red;
            btnLogout.Location = new Point(206, 7);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(66, 50);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "\u23fb";
            btnLogout.TextColor = Color.Red;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.GrayText;
            lblUsername.Location = new Point(33, 21);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(167, 28);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Logged In: Admin";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1192, 673);
            Controls.Add(panel1);
            Controls.Add(pnlFavorites);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EasyBiz: By Shamsuddin";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomButton BtnAccountsSetup;
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
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel pnlFavorites;
        private ToolStripMenuItem viewLedgerToolStripMenuItem;
        private ToolStripMenuItem trialBalancesToolStripMenuItem;
        private ToolStripMenuItem stockReportToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem stocToolStripMenuItem;
        private Panel panel1;
        private CustomButton btnLogout;
        private Label lblUsername;
    }
}
