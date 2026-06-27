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
            addNewToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem = new ToolStripMenuItem();
            itemMovementToolStripMenuItem = new ToolStripMenuItem();
            saleInvoiceToolStripMenuItem = new ToolStripMenuItem();
            purchaseInvoiceToolStripMenuItem = new ToolStripMenuItem();
            bankToolStripMenuItem = new ToolStripMenuItem();
            bankPaymentToolStripMenuItem = new ToolStripMenuItem();
            bankReceiptToolStripMenuItem = new ToolStripMenuItem();
            chequeBookToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            viewLedgerToolStripMenuItem = new ToolStripMenuItem();
            trialBalancesToolStripMenuItem = new ToolStripMenuItem();
            stockReportToolStripMenuItem = new ToolStripMenuItem();
            cashBookToolStripMenuItem = new ToolStripMenuItem();
            BtnBankReceipt = new CustomButton();
            BtnBankPayment = new CustomButton();
            BtnChequeBook = new CustomButton();
            BtnSettings = new CustomButton();
            BtnBackupData = new CustomButton();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnAccountsSetup
            // 
            BtnAccountsSetup.Anchor = AnchorStyles.Top;
            BtnAccountsSetup.BackColor = Color.Transparent;
            BtnAccountsSetup.BackgroundColor = Color.Transparent;
            BtnAccountsSetup.BorderColor = Color.Black;
            BtnAccountsSetup.BorderRadius = 15;
            BtnAccountsSetup.BorderSize = 2;
            BtnAccountsSetup.FlatAppearance.BorderSize = 0;
            BtnAccountsSetup.FlatStyle = FlatStyle.Flat;
            BtnAccountsSetup.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAccountsSetup.ForeColor = Color.MidnightBlue;
            BtnAccountsSetup.Image = Properties.Resources.add_user;
            BtnAccountsSetup.ImageAlign = ContentAlignment.TopCenter;
            BtnAccountsSetup.Location = new Point(8, 4);
            BtnAccountsSetup.Margin = new Padding(3, 4, 3, 4);
            BtnAccountsSetup.Name = "BtnAccountsSetup";
            BtnAccountsSetup.Padding = new Padding(6);
            BtnAccountsSetup.Size = new Size(200, 118);
            BtnAccountsSetup.TabIndex = 0;
            BtnAccountsSetup.Text = "Accounts Setup";
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
            BtnCashPayment.BorderColor = Color.Black;
            BtnCashPayment.BorderRadius = 15;
            BtnCashPayment.BorderSize = 2;
            BtnCashPayment.FlatAppearance.BorderSize = 0;
            BtnCashPayment.FlatStyle = FlatStyle.Flat;
            BtnCashPayment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCashPayment.ForeColor = Color.Black;
            BtnCashPayment.Image = Properties.Resources.money_pay;
            BtnCashPayment.ImageAlign = ContentAlignment.TopCenter;
            BtnCashPayment.Location = new Point(442, 4);
            BtnCashPayment.Margin = new Padding(3, 4, 3, 4);
            BtnCashPayment.Name = "BtnCashPayment";
            BtnCashPayment.Padding = new Padding(6);
            BtnCashPayment.Size = new Size(200, 118);
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
            BtnCashReceipt.BorderColor = Color.Black;
            BtnCashReceipt.BorderRadius = 15;
            BtnCashReceipt.BorderSize = 2;
            BtnCashReceipt.FlatAppearance.BorderSize = 0;
            BtnCashReceipt.FlatStyle = FlatStyle.Flat;
            BtnCashReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCashReceipt.ForeColor = Color.Black;
            BtnCashReceipt.Image = Properties.Resources.money_receive;
            BtnCashReceipt.ImageAlign = ContentAlignment.TopCenter;
            BtnCashReceipt.Location = new Point(659, 4);
            BtnCashReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnCashReceipt.Name = "BtnCashReceipt";
            BtnCashReceipt.Padding = new Padding(6);
            BtnCashReceipt.Size = new Size(200, 118);
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
            BtnJournalVoucher.BorderColor = Color.Black;
            BtnJournalVoucher.BorderRadius = 15;
            BtnJournalVoucher.BorderSize = 2;
            BtnJournalVoucher.FlatAppearance.BorderSize = 0;
            BtnJournalVoucher.FlatStyle = FlatStyle.Flat;
            BtnJournalVoucher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnJournalVoucher.ForeColor = Color.Black;
            BtnJournalVoucher.Image = Properties.Resources.journal_voucher;
            BtnJournalVoucher.ImageAlign = ContentAlignment.TopCenter;
            BtnJournalVoucher.Location = new Point(876, 4);
            BtnJournalVoucher.Margin = new Padding(3, 4, 3, 4);
            BtnJournalVoucher.Name = "BtnJournalVoucher";
            BtnJournalVoucher.Padding = new Padding(6);
            BtnJournalVoucher.Size = new Size(200, 118);
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
            BtnCashBook.BorderColor = Color.Black;
            BtnCashBook.BorderRadius = 15;
            BtnCashBook.BorderSize = 2;
            BtnCashBook.FlatAppearance.BorderSize = 0;
            BtnCashBook.FlatStyle = FlatStyle.Flat;
            BtnCashBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCashBook.ForeColor = Color.Black;
            BtnCashBook.Image = Properties.Resources.cash_book;
            BtnCashBook.ImageAlign = ContentAlignment.TopCenter;
            BtnCashBook.Location = new Point(8, 257);
            BtnCashBook.Margin = new Padding(3, 4, 3, 4);
            BtnCashBook.Name = "BtnCashBook";
            BtnCashBook.Padding = new Padding(6);
            BtnCashBook.Size = new Size(200, 120);
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
            BtnLedgerReport.BorderColor = Color.Black;
            BtnLedgerReport.BorderRadius = 15;
            BtnLedgerReport.BorderSize = 2;
            BtnLedgerReport.FlatAppearance.BorderSize = 0;
            BtnLedgerReport.FlatStyle = FlatStyle.Flat;
            BtnLedgerReport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnLedgerReport.ForeColor = Color.Black;
            BtnLedgerReport.Image = Properties.Resources.ledger;
            BtnLedgerReport.ImageAlign = ContentAlignment.TopCenter;
            BtnLedgerReport.Location = new Point(225, 257);
            BtnLedgerReport.Margin = new Padding(3, 4, 3, 4);
            BtnLedgerReport.Name = "BtnLedgerReport";
            BtnLedgerReport.Padding = new Padding(6);
            BtnLedgerReport.Size = new Size(200, 120);
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
            BtnEditTransactions.BorderColor = Color.Black;
            BtnEditTransactions.BorderRadius = 15;
            BtnEditTransactions.BorderSize = 2;
            BtnEditTransactions.FlatAppearance.BorderSize = 0;
            BtnEditTransactions.FlatStyle = FlatStyle.Flat;
            BtnEditTransactions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnEditTransactions.ForeColor = Color.Black;
            BtnEditTransactions.Image = Properties.Resources.Edit;
            BtnEditTransactions.ImageAlign = ContentAlignment.TopCenter;
            BtnEditTransactions.Location = new Point(1094, 4);
            BtnEditTransactions.Margin = new Padding(3, 4, 3, 4);
            BtnEditTransactions.Name = "BtnEditTransactions";
            BtnEditTransactions.Padding = new Padding(6);
            BtnEditTransactions.Size = new Size(200, 118);
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
            BtnOpeningBalances.BorderColor = Color.Black;
            BtnOpeningBalances.BorderRadius = 15;
            BtnOpeningBalances.BorderSize = 2;
            BtnOpeningBalances.FlatAppearance.BorderSize = 0;
            BtnOpeningBalances.FlatStyle = FlatStyle.Flat;
            BtnOpeningBalances.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnOpeningBalances.ForeColor = Color.Black;
            BtnOpeningBalances.Image = Properties.Resources.opening_balance;
            BtnOpeningBalances.ImageAlign = ContentAlignment.TopCenter;
            BtnOpeningBalances.Location = new Point(1094, 130);
            BtnOpeningBalances.Margin = new Padding(3, 4, 3, 4);
            BtnOpeningBalances.Name = "BtnOpeningBalances";
            BtnOpeningBalances.Padding = new Padding(6);
            BtnOpeningBalances.Size = new Size(200, 119);
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
            BtnTrialBalance.BorderColor = Color.Black;
            BtnTrialBalance.BorderRadius = 15;
            BtnTrialBalance.BorderSize = 2;
            BtnTrialBalance.FlatAppearance.BorderSize = 0;
            BtnTrialBalance.FlatStyle = FlatStyle.Flat;
            BtnTrialBalance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnTrialBalance.ForeColor = Color.Black;
            BtnTrialBalance.Image = Properties.Resources.trial_balance;
            BtnTrialBalance.ImageAlign = ContentAlignment.TopCenter;
            BtnTrialBalance.Location = new Point(442, 257);
            BtnTrialBalance.Margin = new Padding(3, 4, 3, 4);
            BtnTrialBalance.Name = "BtnTrialBalance";
            BtnTrialBalance.Padding = new Padding(6);
            BtnTrialBalance.Size = new Size(200, 120);
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
            BtnSalesInvoice.BorderColor = Color.Black;
            BtnSalesInvoice.BorderRadius = 15;
            BtnSalesInvoice.BorderSize = 2;
            BtnSalesInvoice.FlatAppearance.BorderSize = 0;
            BtnSalesInvoice.FlatStyle = FlatStyle.Flat;
            BtnSalesInvoice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnSalesInvoice.ForeColor = Color.Black;
            BtnSalesInvoice.Image = Properties.Resources.sale;
            BtnSalesInvoice.ImageAlign = ContentAlignment.TopCenter;
            BtnSalesInvoice.Location = new Point(659, 130);
            BtnSalesInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnSalesInvoice.Name = "BtnSalesInvoice";
            BtnSalesInvoice.Padding = new Padding(6);
            BtnSalesInvoice.Size = new Size(200, 119);
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
            BtnProductSetup.BorderColor = Color.Black;
            BtnProductSetup.BorderRadius = 15;
            BtnProductSetup.BorderSize = 2;
            BtnProductSetup.FlatAppearance.BorderSize = 0;
            BtnProductSetup.FlatStyle = FlatStyle.Flat;
            BtnProductSetup.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnProductSetup.ForeColor = Color.Black;
            BtnProductSetup.Image = Properties.Resources.add_product;
            BtnProductSetup.ImageAlign = ContentAlignment.TopCenter;
            BtnProductSetup.Location = new Point(225, 4);
            BtnProductSetup.Margin = new Padding(3, 4, 3, 4);
            BtnProductSetup.Name = "BtnProductSetup";
            BtnProductSetup.Padding = new Padding(6);
            BtnProductSetup.Size = new Size(200, 118);
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
            BtnPurchaseInvoice.BorderColor = Color.Black;
            BtnPurchaseInvoice.BorderRadius = 15;
            BtnPurchaseInvoice.BorderSize = 2;
            BtnPurchaseInvoice.FlatAppearance.BorderSize = 0;
            BtnPurchaseInvoice.FlatStyle = FlatStyle.Flat;
            BtnPurchaseInvoice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnPurchaseInvoice.ForeColor = Color.Black;
            BtnPurchaseInvoice.Image = Properties.Resources.purchase;
            BtnPurchaseInvoice.ImageAlign = ContentAlignment.TopCenter;
            BtnPurchaseInvoice.Location = new Point(876, 130);
            BtnPurchaseInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnPurchaseInvoice.Name = "BtnPurchaseInvoice";
            BtnPurchaseInvoice.Padding = new Padding(6);
            BtnPurchaseInvoice.Size = new Size(200, 119);
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
            BtnStockReport.BorderColor = Color.Black;
            BtnStockReport.BorderRadius = 15;
            BtnStockReport.BorderSize = 2;
            BtnStockReport.FlatAppearance.BorderSize = 0;
            BtnStockReport.FlatStyle = FlatStyle.Flat;
            BtnStockReport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnStockReport.ForeColor = Color.Black;
            BtnStockReport.Image = Properties.Resources.stock_report;
            BtnStockReport.ImageAlign = ContentAlignment.TopCenter;
            BtnStockReport.Location = new Point(659, 257);
            BtnStockReport.Margin = new Padding(3, 4, 3, 4);
            BtnStockReport.Name = "BtnStockReport";
            BtnStockReport.Padding = new Padding(6);
            BtnStockReport.Size = new Size(200, 120);
            BtnStockReport.TabIndex = 14;
            BtnStockReport.Text = "Stock Report\r\n";
            BtnStockReport.TextColor = Color.Black;
            BtnStockReport.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnStockReport.UseVisualStyleBackColor = false;
            BtnStockReport.Click += BtnStockReport_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, addNewToolStripMenuItem, itemMovementToolStripMenuItem, bankToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1303, 31);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { cashPaymentToolStripMenuItem, cashReceiptToolStripMenuItem, journalVoucherToolStripMenuItem, editTransactionsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(118, 27);
            toolStripMenuItem1.Text = "Transactions";
            // 
            // cashPaymentToolStripMenuItem
            // 
            cashPaymentToolStripMenuItem.Name = "cashPaymentToolStripMenuItem";
            cashPaymentToolStripMenuItem.ShortcutKeys = Keys.F1;
            cashPaymentToolStripMenuItem.Size = new Size(249, 28);
            cashPaymentToolStripMenuItem.Text = "Cash Payment";
            cashPaymentToolStripMenuItem.Click += BtnCashPayment_Click;
            // 
            // cashReceiptToolStripMenuItem
            // 
            cashReceiptToolStripMenuItem.Name = "cashReceiptToolStripMenuItem";
            cashReceiptToolStripMenuItem.ShortcutKeys = Keys.F2;
            cashReceiptToolStripMenuItem.Size = new Size(249, 28);
            cashReceiptToolStripMenuItem.Text = "Cash Receipt";
            cashReceiptToolStripMenuItem.Click += BtnCashReceipt_Click;
            // 
            // journalVoucherToolStripMenuItem
            // 
            journalVoucherToolStripMenuItem.Name = "journalVoucherToolStripMenuItem";
            journalVoucherToolStripMenuItem.ShortcutKeys = Keys.F3;
            journalVoucherToolStripMenuItem.Size = new Size(249, 28);
            journalVoucherToolStripMenuItem.Text = "Journal Voucher";
            journalVoucherToolStripMenuItem.Click += BtnJournalVoucher_Click;
            // 
            // editTransactionsToolStripMenuItem
            // 
            editTransactionsToolStripMenuItem.Name = "editTransactionsToolStripMenuItem";
            editTransactionsToolStripMenuItem.ShortcutKeys = Keys.F6;
            editTransactionsToolStripMenuItem.Size = new Size(249, 28);
            editTransactionsToolStripMenuItem.Text = "Edit Transactions";
            editTransactionsToolStripMenuItem.Click += BtnEditTransactions_Click;
            // 
            // addNewToolStripMenuItem
            // 
            addNewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { accountToolStripMenuItem, productToolStripMenuItem });
            addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            addNewToolStripMenuItem.Size = new Size(74, 27);
            addNewToolStripMenuItem.Text = "Create";
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            accountToolStripMenuItem.Size = new Size(266, 28);
            accountToolStripMenuItem.Text = "Account Setup";
            accountToolStripMenuItem.Click += BtnAccountsSetup_Click;
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            productToolStripMenuItem.Size = new Size(266, 28);
            productToolStripMenuItem.Text = "Product Setup";
            productToolStripMenuItem.Click += BtnProductSetup_Click;
            // 
            // itemMovementToolStripMenuItem
            // 
            itemMovementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saleInvoiceToolStripMenuItem, purchaseInvoiceToolStripMenuItem });
            itemMovementToolStripMenuItem.Name = "itemMovementToolStripMenuItem";
            itemMovementToolStripMenuItem.Size = new Size(84, 27);
            itemMovementToolStripMenuItem.Text = "Product";
            // 
            // saleInvoiceToolStripMenuItem
            // 
            saleInvoiceToolStripMenuItem.Name = "saleInvoiceToolStripMenuItem";
            saleInvoiceToolStripMenuItem.ShortcutKeys = Keys.F5;
            saleInvoiceToolStripMenuItem.Size = new Size(249, 28);
            saleInvoiceToolStripMenuItem.Text = "Sale Invoice";
            saleInvoiceToolStripMenuItem.Click += BtnSalesInvoice_Click;
            // 
            // purchaseInvoiceToolStripMenuItem
            // 
            purchaseInvoiceToolStripMenuItem.Name = "purchaseInvoiceToolStripMenuItem";
            purchaseInvoiceToolStripMenuItem.ShortcutKeys = Keys.F4;
            purchaseInvoiceToolStripMenuItem.Size = new Size(249, 28);
            purchaseInvoiceToolStripMenuItem.Text = "Purchase Invoice";
            purchaseInvoiceToolStripMenuItem.Click += BtnPurchaseInvoice_Click;
            // 
            // bankToolStripMenuItem
            // 
            bankToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bankPaymentToolStripMenuItem, bankReceiptToolStripMenuItem, chequeBookToolStripMenuItem });
            bankToolStripMenuItem.Name = "bankToolStripMenuItem";
            bankToolStripMenuItem.Size = new Size(61, 27);
            bankToolStripMenuItem.Text = "Bank";
            // 
            // bankPaymentToolStripMenuItem
            // 
            bankPaymentToolStripMenuItem.Name = "bankPaymentToolStripMenuItem";
            bankPaymentToolStripMenuItem.ShortcutKeys = Keys.F9;
            bankPaymentToolStripMenuItem.Size = new Size(256, 28);
            bankPaymentToolStripMenuItem.Text = "Bank Payment";
            bankPaymentToolStripMenuItem.Click += BtnBankPayment_Click;
            // 
            // bankReceiptToolStripMenuItem
            // 
            bankReceiptToolStripMenuItem.Name = "bankReceiptToolStripMenuItem";
            bankReceiptToolStripMenuItem.ShortcutKeys = Keys.F10;
            bankReceiptToolStripMenuItem.Size = new Size(256, 28);
            bankReceiptToolStripMenuItem.Text = "Bank Receipt";
            bankReceiptToolStripMenuItem.Click += BtnBankReceipt_Click;
            // 
            // chequeBookToolStripMenuItem
            // 
            chequeBookToolStripMenuItem.Name = "chequeBookToolStripMenuItem";
            chequeBookToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            chequeBookToolStripMenuItem.Size = new Size(256, 28);
            chequeBookToolStripMenuItem.Text = "Cheque Book";
            chequeBookToolStripMenuItem.Click += BtnChequeBook_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewLedgerToolStripMenuItem, trialBalancesToolStripMenuItem, stockReportToolStripMenuItem, cashBookToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(82, 27);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // viewLedgerToolStripMenuItem
            // 
            viewLedgerToolStripMenuItem.Name = "viewLedgerToolStripMenuItem";
            viewLedgerToolStripMenuItem.ShortcutKeys = Keys.F7;
            viewLedgerToolStripMenuItem.Size = new Size(232, 28);
            viewLedgerToolStripMenuItem.Text = "View Ledger";
            viewLedgerToolStripMenuItem.Click += BtnLedgerReport_Click;
            // 
            // trialBalancesToolStripMenuItem
            // 
            trialBalancesToolStripMenuItem.Name = "trialBalancesToolStripMenuItem";
            trialBalancesToolStripMenuItem.ShortcutKeys = Keys.F12;
            trialBalancesToolStripMenuItem.Size = new Size(232, 28);
            trialBalancesToolStripMenuItem.Text = "Trial Balances";
            trialBalancesToolStripMenuItem.Click += BtnTrialBalance_Click;
            // 
            // stockReportToolStripMenuItem
            // 
            stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
            stockReportToolStripMenuItem.ShortcutKeys = Keys.F11;
            stockReportToolStripMenuItem.Size = new Size(232, 28);
            stockReportToolStripMenuItem.Text = "Stock Report";
            stockReportToolStripMenuItem.Click += BtnStockReport_Click;
            // 
            // cashBookToolStripMenuItem
            // 
            cashBookToolStripMenuItem.Name = "cashBookToolStripMenuItem";
            cashBookToolStripMenuItem.ShortcutKeys = Keys.F8;
            cashBookToolStripMenuItem.Size = new Size(232, 28);
            cashBookToolStripMenuItem.Text = "Cash Book ";
            cashBookToolStripMenuItem.Click += BtnCashBook_Click;
            // 
            // BtnBankReceipt
            // 
            BtnBankReceipt.Anchor = AnchorStyles.Top;
            BtnBankReceipt.BackColor = Color.Transparent;
            BtnBankReceipt.BackgroundColor = Color.Transparent;
            BtnBankReceipt.BorderColor = Color.Black;
            BtnBankReceipt.BorderRadius = 15;
            BtnBankReceipt.BorderSize = 2;
            BtnBankReceipt.FlatAppearance.BorderSize = 0;
            BtnBankReceipt.FlatStyle = FlatStyle.Flat;
            BtnBankReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnBankReceipt.ForeColor = Color.Black;
            BtnBankReceipt.Image = Properties.Resources.bank_received;
            BtnBankReceipt.ImageAlign = ContentAlignment.TopCenter;
            BtnBankReceipt.Location = new Point(225, 130);
            BtnBankReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnBankReceipt.Name = "BtnBankReceipt";
            BtnBankReceipt.Padding = new Padding(6);
            BtnBankReceipt.Size = new Size(200, 119);
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
            BtnBankPayment.BorderColor = Color.Black;
            BtnBankPayment.BorderRadius = 15;
            BtnBankPayment.BorderSize = 2;
            BtnBankPayment.FlatAppearance.BorderSize = 0;
            BtnBankPayment.FlatStyle = FlatStyle.Flat;
            BtnBankPayment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnBankPayment.ForeColor = Color.Black;
            BtnBankPayment.Image = Properties.Resources.bank_payment;
            BtnBankPayment.ImageAlign = ContentAlignment.TopCenter;
            BtnBankPayment.Location = new Point(8, 130);
            BtnBankPayment.Margin = new Padding(3, 4, 3, 4);
            BtnBankPayment.Name = "BtnBankPayment";
            BtnBankPayment.Padding = new Padding(6);
            BtnBankPayment.Size = new Size(200, 119);
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
            BtnChequeBook.BorderColor = Color.Black;
            BtnChequeBook.BorderRadius = 15;
            BtnChequeBook.BorderSize = 2;
            BtnChequeBook.FlatAppearance.BorderSize = 0;
            BtnChequeBook.FlatStyle = FlatStyle.Flat;
            BtnChequeBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnChequeBook.ForeColor = Color.Black;
            BtnChequeBook.Image = Properties.Resources.cheque_book;
            BtnChequeBook.ImageAlign = ContentAlignment.TopCenter;
            BtnChequeBook.Location = new Point(442, 130);
            BtnChequeBook.Margin = new Padding(3, 4, 3, 4);
            BtnChequeBook.Name = "BtnChequeBook";
            BtnChequeBook.Padding = new Padding(6);
            BtnChequeBook.Size = new Size(200, 119);
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
            BtnSettings.BorderColor = Color.Black;
            BtnSettings.BorderRadius = 15;
            BtnSettings.BorderSize = 2;
            BtnSettings.FlatAppearance.BorderSize = 0;
            BtnSettings.FlatStyle = FlatStyle.Flat;
            BtnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnSettings.ForeColor = Color.Black;
            BtnSettings.Image = Properties.Resources.settings;
            BtnSettings.ImageAlign = ContentAlignment.TopCenter;
            BtnSettings.Location = new Point(876, 257);
            BtnSettings.Margin = new Padding(3, 4, 3, 4);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Padding = new Padding(6);
            BtnSettings.Size = new Size(200, 120);
            BtnSettings.TabIndex = 19;
            BtnSettings.Text = "Settings";
            BtnSettings.TextColor = Color.Black;
            BtnSettings.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnSettings.UseVisualStyleBackColor = false;
            // 
            // BtnBackupData
            // 
            BtnBackupData.Anchor = AnchorStyles.Top;
            BtnBackupData.BackColor = Color.Transparent;
            BtnBackupData.BackgroundColor = Color.Transparent;
            BtnBackupData.BorderColor = Color.Black;
            BtnBackupData.BorderRadius = 15;
            BtnBackupData.BorderSize = 2;
            BtnBackupData.FlatAppearance.BorderSize = 0;
            BtnBackupData.FlatStyle = FlatStyle.Flat;
            BtnBackupData.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnBackupData.ForeColor = Color.Black;
            BtnBackupData.Image = Properties.Resources.data_backup;
            BtnBackupData.ImageAlign = ContentAlignment.TopCenter;
            BtnBackupData.Location = new Point(1094, 257);
            BtnBackupData.Margin = new Padding(3, 4, 3, 4);
            BtnBackupData.Name = "BtnBackupData";
            BtnBackupData.Padding = new Padding(6);
            BtnBackupData.Size = new Size(200, 120);
            BtnBackupData.TabIndex = 20;
            BtnBackupData.Text = "Backup Data";
            BtnBackupData.TextColor = Color.Black;
            BtnBackupData.TextImageRelation = TextImageRelation.ImageAboveText;
            BtnBackupData.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666718F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
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
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 31);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Size = new Size(1303, 381);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1303, 818);
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
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem itemMovementToolStripMenuItem;
        private ToolStripMenuItem saleInvoiceToolStripMenuItem;
        private ToolStripMenuItem purchaseInvoiceToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem viewLedgerToolStripMenuItem;
        private ToolStripMenuItem trialBalancesToolStripMenuItem;
        private ToolStripMenuItem stockReportToolStripMenuItem;
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
    }
}
