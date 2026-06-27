namespace EasyBiz
{
    partial class PurchaseInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtVoucherNo = new TextBox();
            label2 = new Label();
            comboPaymentMode = new ComboBox();
            label1 = new Label();
            comboPartyName = new ComboBox();
            comboPartyId = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            comboProduct = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            lblStockWt = new Label();
            lblStockQty = new Label();
            label8 = new Label();
            gridItems = new DataGridView();
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colWeight = new DataGridViewTextBoxColumn();
            colWeightUnit = new DataGridViewTextBoxColumn();
            colRate = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            dateInvoice = new DateTimePicker();
            label12 = new Label();
            txtDescription = new TextBox();
            label13 = new Label();
            BtnDeleteRow = new CustomButton();
            BtnAddItem = new CustomButton();
            BtnClose = new CustomButton();
            BtnSave = new CustomButton();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            lblHeader = new Label();
            label14 = new Label();
            txtQty = new TextBox();
            txtWeight = new TextBox();
            txtRate = new TextBox();
            txtAmount = new TextBox();
            txtDiscount = new TextBox();
            txtTotal = new TextBox();
            txtNetAmount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 12F);
            txtVoucherNo.Location = new Point(139, 99);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new Size(156, 34);
            txtVoucherNo.TabIndex = 5;
            txtVoucherNo.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(14, 99);
            label2.Name = "label2";
            label2.Size = new Size(119, 28);
            label2.TabIndex = 4;
            label2.Text = "Voucher No:";
            // 
            // comboPaymentMode
            // 
            comboPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMode.Font = new Font("Segoe UI", 12F);
            comboPaymentMode.FormattingEnabled = true;
            comboPaymentMode.Location = new Point(473, 99);
            comboPaymentMode.Name = "comboPaymentMode";
            comboPaymentMode.Size = new Size(165, 36);
            comboPaymentMode.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(323, 102);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 6;
            label1.Text = "Payment Mode";
            // 
            // comboPartyName
            // 
            comboPartyName.Font = new Font("Segoe UI", 12F);
            comboPartyName.FormattingEnabled = true;
            comboPartyName.Location = new Point(130, 219);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(344, 36);
            comboPartyName.TabIndex = 11;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // comboPartyId
            // 
            comboPartyId.Font = new Font("Segoe UI", 12F);
            comboPartyId.FormattingEnabled = true;
            comboPartyId.Location = new Point(130, 175);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new Size(165, 36);
            comboPartyId.TabIndex = 10;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(11, 219);
            label4.Name = "label4";
            label4.Size = new Size(113, 28);
            label4.TabIndex = 9;
            label4.Text = "Party Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(44, 178);
            label3.Name = "label3";
            label3.Size = new Size(80, 28);
            label3.TabIndex = 8;
            label3.Text = "Party ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(14, 286);
            label5.Name = "label5";
            label5.Size = new Size(81, 28);
            label5.TabIndex = 13;
            label5.Text = "Product";
            // 
            // comboProduct
            // 
            comboProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProduct.FormattingEnabled = true;
            comboProduct.Location = new Point(14, 317);
            comboProduct.Name = "comboProduct";
            comboProduct.Size = new Size(353, 39);
            comboProduct.TabIndex = 12;
            comboProduct.SelectedIndexChanged += comboProduct_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(369, 291);
            label7.Name = "label7";
            label7.Size = new Size(37, 23);
            label7.TabIndex = 16;
            label7.Text = "Qty";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(599, 291);
            label6.Name = "label6";
            label6.Size = new Size(44, 23);
            label6.TabIndex = 14;
            label6.Text = "Rate";
            // 
            // lblStockWt
            // 
            lblStockWt.AutoSize = true;
            lblStockWt.Font = new Font("Segoe UI", 12F);
            lblStockWt.Location = new Point(6, 36);
            lblStockWt.Name = "lblStockWt";
            lblStockWt.Size = new Size(48, 28);
            lblStockWt.TabIndex = 19;
            lblStockWt.Text = "Qty:";
            // 
            // lblStockQty
            // 
            lblStockQty.AutoSize = true;
            lblStockQty.Font = new Font("Segoe UI", 12F);
            lblStockQty.Location = new Point(6, 73);
            lblStockQty.Name = "lblStockQty";
            lblStockQty.Size = new Size(79, 28);
            lblStockQty.TabIndex = 18;
            lblStockQty.Text = "Weight:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(480, 291);
            label8.Name = "label8";
            label8.Size = new Size(64, 23);
            label8.TabIndex = 21;
            label8.Text = "Weight";
            // 
            // gridItems
            // 
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colUnit, colQty, colWeight, colWeightUnit, colRate, colAmount });
            gridItems.Location = new Point(14, 360);
            gridItems.Name = "gridItems";
            gridItems.RowHeadersWidth = 51;
            gridItems.Size = new Size(1232, 188);
            gridItems.TabIndex = 22;
            // 
            // colProductId
            // 
            colProductId.HeaderText = "Product Id";
            colProductId.MinimumWidth = 6;
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            colProductId.Width = 125;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colProductName.Width = 125;
            // 
            // colUnit
            // 
            colUnit.HeaderText = "Unit";
            colUnit.MinimumWidth = 6;
            colUnit.Name = "colUnit";
            colUnit.ReadOnly = true;
            colUnit.Width = 125;
            // 
            // colQty
            // 
            colQty.HeaderText = "Qty";
            colQty.MinimumWidth = 6;
            colQty.Name = "colQty";
            colQty.Width = 125;
            // 
            // colWeight
            // 
            colWeight.HeaderText = "Weight";
            colWeight.MinimumWidth = 6;
            colWeight.Name = "colWeight";
            colWeight.Width = 125;
            // 
            // colWeightUnit
            // 
            colWeightUnit.HeaderText = "Weight Unit";
            colWeightUnit.MinimumWidth = 6;
            colWeightUnit.Name = "colWeightUnit";
            colWeightUnit.ReadOnly = true;
            colWeightUnit.Width = 125;
            // 
            // colRate
            // 
            colRate.HeaderText = "Rate";
            colRate.MinimumWidth = 6;
            colRate.Name = "colRate";
            colRate.Width = 125;
            // 
            // colAmount
            // 
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            colAmount.Width = 125;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(991, 601);
            label11.Name = "label11";
            label11.Size = new Size(89, 28);
            label11.TabIndex = 34;
            label11.Text = "Discount";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(960, 646);
            label10.Name = "label10";
            label10.Size = new Size(120, 28);
            label10.TabIndex = 33;
            label10.Text = "Net Amount";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(1026, 556);
            label9.Name = "label9";
            label9.Size = new Size(54, 28);
            label9.TabIndex = 32;
            label9.Text = "Total";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new Font("Segoe UI", 12F);
            dateInvoice.Format = DateTimePickerFormat.Short;
            dateInvoice.Location = new Point(730, 99);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new Size(177, 34);
            dateInvoice.TabIndex = 39;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(671, 102);
            label12.Name = "label12";
            label12.Size = new Size(53, 28);
            label12.TabIndex = 38;
            label12.Text = "Date";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(599, 221);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(308, 34);
            txtDescription.TabIndex = 41;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(481, 224);
            label13.Name = "label13";
            label13.Size = new Size(112, 28);
            label13.TabIndex = 40;
            label13.Text = "Description";
            // 
            // BtnDeleteRow
            // 
            BtnDeleteRow.BackColor = Color.Red;
            BtnDeleteRow.BackgroundColor = Color.Red;
            BtnDeleteRow.BorderColor = Color.Transparent;
            BtnDeleteRow.BorderRadius = 2;
            BtnDeleteRow.BorderSize = 0;
            BtnDeleteRow.FlatAppearance.BorderSize = 0;
            BtnDeleteRow.FlatStyle = FlatStyle.Flat;
            BtnDeleteRow.ForeColor = Color.White;
            BtnDeleteRow.Location = new Point(14, 555);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(124, 34);
            BtnDeleteRow.TabIndex = 43;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.White;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // BtnAddItem
            // 
            BtnAddItem.BackColor = Color.FromArgb(0, 192, 0);
            BtnAddItem.BackgroundColor = Color.FromArgb(0, 192, 0);
            BtnAddItem.BorderColor = Color.Transparent;
            BtnAddItem.BorderRadius = 2;
            BtnAddItem.BorderSize = 0;
            BtnAddItem.FlatAppearance.BorderSize = 0;
            BtnAddItem.FlatStyle = FlatStyle.Flat;
            BtnAddItem.ForeColor = Color.White;
            BtnAddItem.Location = new Point(928, 322);
            BtnAddItem.Name = "BtnAddItem";
            BtnAddItem.Size = new Size(130, 34);
            BtnAddItem.TabIndex = 42;
            BtnAddItem.Text = "Add Item";
            BtnAddItem.TextColor = Color.White;
            BtnAddItem.UseVisualStyleBackColor = false;
            BtnAddItem.Click += BtnAddItem_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.OrangeRed;
            BtnClose.BackgroundColor = Color.OrangeRed;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 15;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(874, 721);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(144, 50);
            BtnClose.TabIndex = 45;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(52, 152, 219);
            BtnSave.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 15;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(1024, 721);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(179, 50);
            BtnSave.TabIndex = 44;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStockQty);
            groupBox1.Controls.Add(lblStockWt);
            groupBox1.Location = new Point(922, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(260, 125);
            groupBox1.TabIndex = 46;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stock Details";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gold;
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1258, 60);
            panel1.TabIndex = 47;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(511, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(236, 38);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Purchase Invoice";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F);
            label14.Location = new Point(708, 291);
            label14.Name = "label14";
            label14.Size = new Size(72, 23);
            label14.TabIndex = 49;
            label14.Text = "Amount";
            // 
            // txtQty
            // 
            txtQty.Font = new Font("Segoe UI", 13.8F);
            txtQty.Location = new Point(369, 316);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(108, 38);
            txtQty.TabIndex = 50;
            txtQty.Text = "0";
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Segoe UI", 13.8F);
            txtWeight.Location = new Point(480, 315);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(108, 38);
            txtWeight.TabIndex = 51;
            txtWeight.Text = "0";
            // 
            // txtRate
            // 
            txtRate.Font = new Font("Segoe UI", 13.8F);
            txtRate.Location = new Point(594, 316);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(108, 38);
            txtRate.TabIndex = 52;
            txtRate.Text = "0";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 13.8F);
            txtAmount.Location = new Point(708, 316);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(199, 38);
            txtAmount.TabIndex = 53;
            txtAmount.Text = "0";
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 13.8F);
            txtDiscount.Location = new Point(1086, 596);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(160, 38);
            txtDiscount.TabIndex = 54;
            txtDiscount.Text = "0";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 13.8F);
            txtTotal.Location = new Point(1086, 551);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(160, 38);
            txtTotal.TabIndex = 55;
            // 
            // txtNetAmount
            // 
            txtNetAmount.Font = new Font("Segoe UI", 13.8F);
            txtNetAmount.Location = new Point(1086, 641);
            txtNetAmount.Name = "txtNetAmount";
            txtNetAmount.ReadOnly = true;
            txtNetAmount.Size = new Size(160, 38);
            txtNetAmount.TabIndex = 56;
            // 
            // PurchaseInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 797);
            Controls.Add(txtNetAmount);
            Controls.Add(txtTotal);
            Controls.Add(txtDiscount);
            Controls.Add(txtAmount);
            Controls.Add(txtRate);
            Controls.Add(txtWeight);
            Controls.Add(txtQty);
            Controls.Add(label14);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(BtnDeleteRow);
            Controls.Add(BtnAddItem);
            Controls.Add(txtDescription);
            Controls.Add(label13);
            Controls.Add(dateInvoice);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(gridItems);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboProduct);
            Controls.Add(comboPartyName);
            Controls.Add(comboPartyId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboPaymentMode);
            Controls.Add(label1);
            Controls.Add(txtVoucherNo);
            Controls.Add(label2);
            Name = "PurchaseInvoice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PurchaseInvoice";
            FormClosing += PurchaseInvoice_FormClosing;
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtVoucherNo;
        private Label label2;
        private ComboBox comboPaymentMode;
        private Label label1;
        private ComboBox comboPartyName;
        private ComboBox comboPartyId;
        private Label label4;
        private Label label3;
        private Label label5;
        private ComboBox comboProduct;
        private Label label7;
        private Label label6;
        private Label lblStockWt;
        private Label lblStockQty;
        private Label label8;
        private DataGridView gridItems;
        private Label label11;
        private Label label10;
        private Label label9;
        private DateTimePicker dateInvoice;
        private Label label12;
        private TextBox txtDescription;
        private Label label13;
        private CustomButton BtnDeleteRow;
        private CustomButton BtnAddItem;
        private CustomButton BtnClose;
        private CustomButton BtnSave;
        private GroupBox groupBox1;
        private Panel panel1;
        private Label lblHeader;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnit;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colWeight;
        private DataGridViewTextBoxColumn colWeightUnit;
        private DataGridViewTextBoxColumn colRate;
        private DataGridViewTextBoxColumn colAmount;
        private Label label14;
        private TextBox txtQty;
        private TextBox txtWeight;
        private TextBox txtRate;
        private TextBox txtAmount;
        private TextBox txtDiscount;
        private TextBox txtTotal;
        private TextBox txtNetAmount;
    }
}