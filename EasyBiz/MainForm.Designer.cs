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
            customButton1 = new CustomButton();
            customButton2 = new CustomButton();
            BtnCashDetails = new CustomButton();
            toolTip1 = new ToolTip(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnAccountsSetup
            // 
            BtnAccountsSetup.BackColor = Color.BlueViolet;
            BtnAccountsSetup.BackgroundColor = Color.BlueViolet;
            BtnAccountsSetup.BorderColor = Color.Transparent;
            BtnAccountsSetup.BorderRadius = 15;
            BtnAccountsSetup.BorderSize = 0;
            BtnAccountsSetup.FlatAppearance.BorderSize = 0;
            BtnAccountsSetup.FlatStyle = FlatStyle.Flat;
            BtnAccountsSetup.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAccountsSetup.ForeColor = Color.White;
            BtnAccountsSetup.Location = new Point(12, 34);
            BtnAccountsSetup.Margin = new Padding(3, 4, 3, 4);
            BtnAccountsSetup.Name = "BtnAccountsSetup";
            BtnAccountsSetup.Size = new Size(185, 100);
            BtnAccountsSetup.TabIndex = 0;
            BtnAccountsSetup.Text = "Accounts Setup\r\n[CTRL+A]";
            BtnAccountsSetup.TextColor = Color.White;
            BtnAccountsSetup.UseVisualStyleBackColor = false;
            BtnAccountsSetup.Click += BtnAccountsSetup_Click;
            // 
            // BtnCashPayment
            // 
            BtnCashPayment.BackColor = Color.Tomato;
            BtnCashPayment.BackgroundColor = Color.Tomato;
            BtnCashPayment.BorderColor = Color.Transparent;
            BtnCashPayment.BorderRadius = 15;
            BtnCashPayment.BorderSize = 0;
            BtnCashPayment.FlatAppearance.BorderSize = 0;
            BtnCashPayment.FlatStyle = FlatStyle.Flat;
            BtnCashPayment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCashPayment.ForeColor = Color.White;
            BtnCashPayment.Location = new Point(394, 34);
            BtnCashPayment.Margin = new Padding(3, 4, 3, 4);
            BtnCashPayment.Name = "BtnCashPayment";
            BtnCashPayment.Size = new Size(185, 100);
            BtnCashPayment.TabIndex = 1;
            BtnCashPayment.Text = "Cash Payment \r\n[F1]";
            BtnCashPayment.TextColor = Color.White;
            BtnCashPayment.UseVisualStyleBackColor = false;
            BtnCashPayment.Click += BtnCashPayment_Click;
            // 
            // BtnCashReceipt
            // 
            BtnCashReceipt.BackColor = Color.LimeGreen;
            BtnCashReceipt.BackgroundColor = Color.LimeGreen;
            BtnCashReceipt.BorderColor = Color.Transparent;
            BtnCashReceipt.BorderRadius = 15;
            BtnCashReceipt.BorderSize = 0;
            BtnCashReceipt.FlatAppearance.BorderSize = 0;
            BtnCashReceipt.FlatStyle = FlatStyle.Flat;
            BtnCashReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCashReceipt.ForeColor = Color.White;
            BtnCashReceipt.Location = new Point(585, 34);
            BtnCashReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnCashReceipt.Name = "BtnCashReceipt";
            BtnCashReceipt.Size = new Size(185, 100);
            BtnCashReceipt.TabIndex = 2;
            BtnCashReceipt.Text = "Cash Receipt\r\n[F2]";
            BtnCashReceipt.TextColor = Color.White;
            BtnCashReceipt.UseVisualStyleBackColor = false;
            BtnCashReceipt.Click += BtnCashReceipt_Click;
            // 
            // BtnJournalVoucher
            // 
            BtnJournalVoucher.BackColor = Color.LightSeaGreen;
            BtnJournalVoucher.BackgroundColor = Color.LightSeaGreen;
            BtnJournalVoucher.BorderColor = Color.Transparent;
            BtnJournalVoucher.BorderRadius = 15;
            BtnJournalVoucher.BorderSize = 0;
            BtnJournalVoucher.FlatAppearance.BorderSize = 0;
            BtnJournalVoucher.FlatStyle = FlatStyle.Flat;
            BtnJournalVoucher.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnJournalVoucher.ForeColor = Color.White;
            BtnJournalVoucher.Location = new Point(776, 34);
            BtnJournalVoucher.Margin = new Padding(3, 4, 3, 4);
            BtnJournalVoucher.Name = "BtnJournalVoucher";
            BtnJournalVoucher.Size = new Size(185, 100);
            BtnJournalVoucher.TabIndex = 3;
            BtnJournalVoucher.Text = "Journal Voucher\r\n[F3]";
            BtnJournalVoucher.TextColor = Color.White;
            BtnJournalVoucher.UseVisualStyleBackColor = false;
            BtnJournalVoucher.Click += BtnJournalVoucher_Click;
            // 
            // BtnCashBook
            // 
            BtnCashBook.BackColor = Color.Goldenrod;
            BtnCashBook.BackgroundColor = Color.Goldenrod;
            BtnCashBook.BorderColor = Color.Transparent;
            BtnCashBook.BorderRadius = 15;
            BtnCashBook.BorderSize = 0;
            BtnCashBook.FlatAppearance.BorderSize = 0;
            BtnCashBook.FlatStyle = FlatStyle.Flat;
            BtnCashBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCashBook.ForeColor = Color.White;
            BtnCashBook.Location = new Point(12, 246);
            BtnCashBook.Margin = new Padding(3, 4, 3, 4);
            BtnCashBook.Name = "BtnCashBook";
            BtnCashBook.Size = new Size(185, 100);
            BtnCashBook.TabIndex = 4;
            BtnCashBook.Text = "Cash Book\r\n[F8]";
            BtnCashBook.TextColor = Color.White;
            BtnCashBook.UseVisualStyleBackColor = false;
            BtnCashBook.Click += BtnCashBook_Click;
            // 
            // BtnLedgerReport
            // 
            BtnLedgerReport.BackColor = Color.RoyalBlue;
            BtnLedgerReport.BackgroundColor = Color.RoyalBlue;
            BtnLedgerReport.BorderColor = Color.Transparent;
            BtnLedgerReport.BorderRadius = 15;
            BtnLedgerReport.BorderSize = 0;
            BtnLedgerReport.FlatAppearance.BorderSize = 0;
            BtnLedgerReport.FlatStyle = FlatStyle.Flat;
            BtnLedgerReport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnLedgerReport.ForeColor = Color.White;
            BtnLedgerReport.Location = new Point(203, 246);
            BtnLedgerReport.Margin = new Padding(3, 4, 3, 4);
            BtnLedgerReport.Name = "BtnLedgerReport";
            BtnLedgerReport.Size = new Size(185, 100);
            BtnLedgerReport.TabIndex = 5;
            BtnLedgerReport.Text = "Ledger Report\r\n[F7]";
            BtnLedgerReport.TextColor = Color.White;
            BtnLedgerReport.UseVisualStyleBackColor = false;
            BtnLedgerReport.Click += BtnLedgerReport_Click;
            // 
            // BtnEditTransactions
            // 
            BtnEditTransactions.BackColor = Color.DimGray;
            BtnEditTransactions.BackgroundColor = Color.DimGray;
            BtnEditTransactions.BorderColor = Color.Transparent;
            BtnEditTransactions.BorderRadius = 15;
            BtnEditTransactions.BorderSize = 0;
            BtnEditTransactions.FlatAppearance.BorderSize = 0;
            BtnEditTransactions.FlatStyle = FlatStyle.Flat;
            BtnEditTransactions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnEditTransactions.ForeColor = Color.White;
            BtnEditTransactions.Location = new Point(967, 34);
            BtnEditTransactions.Margin = new Padding(3, 4, 3, 4);
            BtnEditTransactions.Name = "BtnEditTransactions";
            BtnEditTransactions.Size = new Size(185, 100);
            BtnEditTransactions.TabIndex = 6;
            BtnEditTransactions.Text = "Edit Transactions [F6]";
            BtnEditTransactions.TextColor = Color.White;
            BtnEditTransactions.UseVisualStyleBackColor = false;
            BtnEditTransactions.Click += BtnEditTransactions_Click;
            // 
            // BtnOpeningBalances
            // 
            BtnOpeningBalances.BackColor = Color.FromArgb(255, 128, 0);
            BtnOpeningBalances.BackgroundColor = Color.FromArgb(255, 128, 0);
            BtnOpeningBalances.BorderColor = Color.Transparent;
            BtnOpeningBalances.BorderRadius = 15;
            BtnOpeningBalances.BorderSize = 0;
            BtnOpeningBalances.FlatAppearance.BorderSize = 0;
            BtnOpeningBalances.FlatStyle = FlatStyle.Flat;
            BtnOpeningBalances.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnOpeningBalances.ForeColor = Color.White;
            BtnOpeningBalances.Location = new Point(967, 140);
            BtnOpeningBalances.Margin = new Padding(3, 4, 3, 4);
            BtnOpeningBalances.Name = "BtnOpeningBalances";
            BtnOpeningBalances.Size = new Size(185, 100);
            BtnOpeningBalances.TabIndex = 9;
            BtnOpeningBalances.Text = "Opening Balances\r\n[CTRL+O]";
            BtnOpeningBalances.TextColor = Color.White;
            BtnOpeningBalances.UseVisualStyleBackColor = false;
            BtnOpeningBalances.Click += BtnOpeningBalances_Click;
            // 
            // BtnTrialBalance
            // 
            BtnTrialBalance.BackColor = Color.FromArgb(192, 0, 192);
            BtnTrialBalance.BackgroundColor = Color.FromArgb(192, 0, 192);
            BtnTrialBalance.BorderColor = Color.Transparent;
            BtnTrialBalance.BorderRadius = 15;
            BtnTrialBalance.BorderSize = 0;
            BtnTrialBalance.FlatAppearance.BorderSize = 0;
            BtnTrialBalance.FlatStyle = FlatStyle.Flat;
            BtnTrialBalance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnTrialBalance.ForeColor = Color.White;
            BtnTrialBalance.Location = new Point(394, 246);
            BtnTrialBalance.Margin = new Padding(3, 4, 3, 4);
            BtnTrialBalance.Name = "BtnTrialBalance";
            BtnTrialBalance.Size = new Size(185, 100);
            BtnTrialBalance.TabIndex = 10;
            BtnTrialBalance.Text = "Trial Balance\r\n[F12]";
            BtnTrialBalance.TextColor = Color.White;
            BtnTrialBalance.UseVisualStyleBackColor = false;
            BtnTrialBalance.Click += BtnTrialBalance_Click;
            // 
            // BtnSalesInvoice
            // 
            BtnSalesInvoice.BackColor = Color.DarkCyan;
            BtnSalesInvoice.BackgroundColor = Color.DarkCyan;
            BtnSalesInvoice.BorderColor = Color.Transparent;
            BtnSalesInvoice.BorderRadius = 15;
            BtnSalesInvoice.BorderSize = 0;
            BtnSalesInvoice.FlatAppearance.BorderSize = 0;
            BtnSalesInvoice.FlatStyle = FlatStyle.Flat;
            BtnSalesInvoice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnSalesInvoice.ForeColor = Color.White;
            BtnSalesInvoice.Location = new Point(585, 140);
            BtnSalesInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnSalesInvoice.Name = "BtnSalesInvoice";
            BtnSalesInvoice.Size = new Size(185, 100);
            BtnSalesInvoice.TabIndex = 11;
            BtnSalesInvoice.Text = "Sales Invoice\r\n[F5]";
            BtnSalesInvoice.TextColor = Color.White;
            BtnSalesInvoice.UseVisualStyleBackColor = false;
            BtnSalesInvoice.Click += BtnSalesInvoice_Click;
            // 
            // BtnProductSetup
            // 
            BtnProductSetup.BackColor = Color.SeaGreen;
            BtnProductSetup.BackgroundColor = Color.SeaGreen;
            BtnProductSetup.BorderColor = Color.Transparent;
            BtnProductSetup.BorderRadius = 15;
            BtnProductSetup.BorderSize = 0;
            BtnProductSetup.FlatAppearance.BorderSize = 0;
            BtnProductSetup.FlatStyle = FlatStyle.Flat;
            BtnProductSetup.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnProductSetup.ForeColor = Color.White;
            BtnProductSetup.Location = new Point(203, 34);
            BtnProductSetup.Margin = new Padding(3, 4, 3, 4);
            BtnProductSetup.Name = "BtnProductSetup";
            BtnProductSetup.Size = new Size(185, 100);
            BtnProductSetup.TabIndex = 12;
            BtnProductSetup.Text = "Product Setup\r\n[CTRL+P]";
            BtnProductSetup.TextColor = Color.White;
            BtnProductSetup.UseVisualStyleBackColor = false;
            BtnProductSetup.Click += BtnProductSetup_Click;
            // 
            // BtnPurchaseInvoice
            // 
            BtnPurchaseInvoice.BackColor = Color.ForestGreen;
            BtnPurchaseInvoice.BackgroundColor = Color.ForestGreen;
            BtnPurchaseInvoice.BorderColor = Color.Transparent;
            BtnPurchaseInvoice.BorderRadius = 15;
            BtnPurchaseInvoice.BorderSize = 0;
            BtnPurchaseInvoice.FlatAppearance.BorderSize = 0;
            BtnPurchaseInvoice.FlatStyle = FlatStyle.Flat;
            BtnPurchaseInvoice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnPurchaseInvoice.ForeColor = Color.White;
            BtnPurchaseInvoice.Location = new Point(776, 140);
            BtnPurchaseInvoice.Margin = new Padding(3, 4, 3, 4);
            BtnPurchaseInvoice.Name = "BtnPurchaseInvoice";
            BtnPurchaseInvoice.Size = new Size(185, 100);
            BtnPurchaseInvoice.TabIndex = 13;
            BtnPurchaseInvoice.Text = "Purchase Invoice\r\n[F4]";
            BtnPurchaseInvoice.TextColor = Color.White;
            BtnPurchaseInvoice.UseVisualStyleBackColor = false;
            BtnPurchaseInvoice.Click += BtnPurchaseInvoice_Click;
            // 
            // BtnStockReport
            // 
            BtnStockReport.BackColor = Color.DodgerBlue;
            BtnStockReport.BackgroundColor = Color.DodgerBlue;
            BtnStockReport.BorderColor = Color.Transparent;
            BtnStockReport.BorderRadius = 15;
            BtnStockReport.BorderSize = 0;
            BtnStockReport.FlatAppearance.BorderSize = 0;
            BtnStockReport.FlatStyle = FlatStyle.Flat;
            BtnStockReport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnStockReport.ForeColor = Color.White;
            BtnStockReport.Location = new Point(585, 246);
            BtnStockReport.Margin = new Padding(3, 4, 3, 4);
            BtnStockReport.Name = "BtnStockReport";
            BtnStockReport.Size = new Size(185, 100);
            BtnStockReport.TabIndex = 14;
            BtnStockReport.Text = "Stock Report\r\n[F11]";
            BtnStockReport.TextColor = Color.White;
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
            menuStrip1.Size = new Size(1164, 31);
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
            BtnBankReceipt.BackColor = Color.LimeGreen;
            BtnBankReceipt.BackgroundColor = Color.LimeGreen;
            BtnBankReceipt.BorderColor = Color.Transparent;
            BtnBankReceipt.BorderRadius = 15;
            BtnBankReceipt.BorderSize = 0;
            BtnBankReceipt.FlatAppearance.BorderSize = 0;
            BtnBankReceipt.FlatStyle = FlatStyle.Flat;
            BtnBankReceipt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnBankReceipt.ForeColor = Color.White;
            BtnBankReceipt.Location = new Point(203, 140);
            BtnBankReceipt.Margin = new Padding(3, 4, 3, 4);
            BtnBankReceipt.Name = "BtnBankReceipt";
            BtnBankReceipt.Size = new Size(185, 100);
            BtnBankReceipt.TabIndex = 17;
            BtnBankReceipt.Text = "Bank Receipt\r\n[F10]";
            BtnBankReceipt.TextColor = Color.White;
            BtnBankReceipt.UseVisualStyleBackColor = false;
            BtnBankReceipt.Click += BtnBankReceipt_Click;
            // 
            // BtnBankPayment
            // 
            BtnBankPayment.BackColor = Color.Tomato;
            BtnBankPayment.BackgroundColor = Color.Tomato;
            BtnBankPayment.BorderColor = Color.Transparent;
            BtnBankPayment.BorderRadius = 15;
            BtnBankPayment.BorderSize = 0;
            BtnBankPayment.FlatAppearance.BorderSize = 0;
            BtnBankPayment.FlatStyle = FlatStyle.Flat;
            BtnBankPayment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnBankPayment.ForeColor = Color.White;
            BtnBankPayment.Location = new Point(12, 140);
            BtnBankPayment.Margin = new Padding(3, 4, 3, 4);
            BtnBankPayment.Name = "BtnBankPayment";
            BtnBankPayment.Size = new Size(185, 100);
            BtnBankPayment.TabIndex = 16;
            BtnBankPayment.Text = "Bank Payment\r\n[F9]";
            BtnBankPayment.TextColor = Color.White;
            BtnBankPayment.UseVisualStyleBackColor = false;
            BtnBankPayment.Click += BtnBankPayment_Click;
            // 
            // BtnChequeBook
            // 
            BtnChequeBook.BackColor = Color.DeepSkyBlue;
            BtnChequeBook.BackgroundColor = Color.DeepSkyBlue;
            BtnChequeBook.BorderColor = Color.Transparent;
            BtnChequeBook.BorderRadius = 15;
            BtnChequeBook.BorderSize = 0;
            BtnChequeBook.FlatAppearance.BorderSize = 0;
            BtnChequeBook.FlatStyle = FlatStyle.Flat;
            BtnChequeBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnChequeBook.ForeColor = Color.White;
            BtnChequeBook.Location = new Point(394, 140);
            BtnChequeBook.Margin = new Padding(3, 4, 3, 4);
            BtnChequeBook.Name = "BtnChequeBook";
            BtnChequeBook.Size = new Size(185, 100);
            BtnChequeBook.TabIndex = 18;
            BtnChequeBook.Text = "Cheque Book\r\n[CTRL+C]";
            BtnChequeBook.TextColor = Color.White;
            BtnChequeBook.UseVisualStyleBackColor = false;
            BtnChequeBook.Click += BtnChequeBook_Click;
            // 
            // customButton1
            // 
            customButton1.BackColor = Color.DarkSlateGray;
            customButton1.BackgroundColor = Color.DarkSlateGray;
            customButton1.BorderColor = Color.Transparent;
            customButton1.BorderRadius = 15;
            customButton1.BorderSize = 0;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customButton1.ForeColor = Color.White;
            customButton1.Location = new Point(776, 246);
            customButton1.Margin = new Padding(3, 4, 3, 4);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(185, 100);
            customButton1.TabIndex = 19;
            customButton1.Text = "Settings \r\n(Ctrl+S)";
            customButton1.TextColor = Color.White;
            customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton2
            // 
            customButton2.BackColor = Color.MediumBlue;
            customButton2.BackgroundColor = Color.MediumBlue;
            customButton2.BorderColor = Color.Transparent;
            customButton2.BorderRadius = 15;
            customButton2.BorderSize = 0;
            customButton2.FlatAppearance.BorderSize = 0;
            customButton2.FlatStyle = FlatStyle.Flat;
            customButton2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customButton2.ForeColor = Color.White;
            customButton2.Location = new Point(967, 246);
            customButton2.Margin = new Padding(3, 4, 3, 4);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(185, 100);
            customButton2.TabIndex = 20;
            customButton2.Text = "Backup\r\nData";
            customButton2.TextColor = Color.White;
            customButton2.UseVisualStyleBackColor = false;
            // 
            // BtnCashDetails
            // 
            BtnCashDetails.BackColor = Color.Black;
            BtnCashDetails.BackgroundColor = Color.Black;
            BtnCashDetails.BorderColor = Color.Transparent;
            BtnCashDetails.BorderRadius = 15;
            BtnCashDetails.BorderSize = 0;
            BtnCashDetails.FlatAppearance.BorderSize = 0;
            BtnCashDetails.FlatStyle = FlatStyle.Flat;
            BtnCashDetails.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCashDetails.ForeColor = Color.White;
            BtnCashDetails.Location = new Point(12, 457);
            BtnCashDetails.Margin = new Padding(3, 4, 3, 4);
            BtnCashDetails.Name = "BtnCashDetails";
            BtnCashDetails.Size = new Size(376, 100);
            BtnCashDetails.TabIndex = 21;
            BtnCashDetails.Text = "Cash: 0.00\r\nBanks: 0.00";
            BtnCashDetails.TextColor = Color.White;
            toolTip1.SetToolTip(BtnCashDetails, "Click to refresh details.");
            BtnCashDetails.UseVisualStyleBackColor = false;
            BtnCashDetails.Click += BtnCashDetails_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1164, 570);
            Controls.Add(BtnCashDetails);
            Controls.Add(customButton2);
            Controls.Add(customButton1);
            Controls.Add(BtnChequeBook);
            Controls.Add(BtnBankReceipt);
            Controls.Add(BtnBankPayment);
            Controls.Add(BtnStockReport);
            Controls.Add(BtnPurchaseInvoice);
            Controls.Add(BtnProductSetup);
            Controls.Add(BtnSalesInvoice);
            Controls.Add(BtnTrialBalance);
            Controls.Add(BtnOpeningBalances);
            Controls.Add(BtnEditTransactions);
            Controls.Add(BtnLedgerReport);
            Controls.Add(BtnCashBook);
            Controls.Add(BtnJournalVoucher);
            Controls.Add(BtnCashReceipt);
            Controls.Add(BtnCashPayment);
            Controls.Add(BtnAccountsSetup);
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
        private CustomButton customButton1;
        private CustomButton customButton2;
        private CustomButton BtnCashDetails;
        private ToolTip toolTip1;
    }
}
