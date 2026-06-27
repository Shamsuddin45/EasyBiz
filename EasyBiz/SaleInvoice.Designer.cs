namespace EasyBiz
{
    partial class SaleInvoice
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
            label1 = new Label();
            comboPaymentMode = new ComboBox();
            label2 = new Label();
            txtVoucherNo = new TextBox();
            label3 = new Label();
            label4 = new Label();
            comboPartyId = new ComboBox();
            comboPartyName = new ComboBox();
            comboProduct = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblStockQty = new Label();
            lblStockWt = new Label();
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
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            dateInvoice = new DateTimePicker();
            txtDescription = new TextBox();
            label13 = new Label();
            BtnAddItem = new CustomButton();
            BtnDeleteRow = new CustomButton();
            BtnSave = new CustomButton();
            BtnClose = new CustomButton();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            lblHeader = new Label();
            lblAmount = new Label();
            txtQty = new TextBox();
            txtWeight = new TextBox();
            txtRate = new TextBox();
            txtDiscount = new TextBox();
            txtAmount = new TextBox();
            txtTotal = new TextBox();
            txtNetAmount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(332, 100);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 0;
            label1.Text = "Payment Mode";
            // 
            // comboPaymentMode
            // 
            comboPaymentMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPaymentMode.Font = new Font("Segoe UI", 12F);
            comboPaymentMode.FormattingEnabled = true;
            comboPaymentMode.Location = new Point(482, 97);
            comboPaymentMode.Name = "comboPaymentMode";
            comboPaymentMode.Size = new Size(165, 36);
            comboPaymentMode.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(15, 97);
            label2.Name = "label2";
            label2.Size = new Size(119, 28);
            label2.TabIndex = 2;
            label2.Text = "Voucher No:";
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 12F);
            txtVoucherNo.Location = new Point(140, 97);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new Size(165, 34);
            txtVoucherNo.TabIndex = 3;
            txtVoucherNo.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(50, 156);
            label3.Name = "label3";
            label3.Size = new Size(80, 28);
            label3.TabIndex = 4;
            label3.Text = "Party ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(17, 197);
            label4.Name = "label4";
            label4.Size = new Size(113, 28);
            label4.TabIndex = 5;
            label4.Text = "Party Name";
            // 
            // comboPartyId
            // 
            comboPartyId.Font = new Font("Segoe UI", 12F);
            comboPartyId.FormattingEnabled = true;
            comboPartyId.Location = new Point(136, 153);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new Size(165, 36);
            comboPartyId.TabIndex = 6;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // comboPartyName
            // 
            comboPartyName.Font = new Font("Segoe UI", 12F);
            comboPartyName.FormattingEnabled = true;
            comboPartyName.Location = new Point(136, 197);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(344, 36);
            comboPartyName.TabIndex = 7;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // comboProduct
            // 
            comboProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProduct.FormattingEnabled = true;
            comboProduct.Location = new Point(6, 328);
            comboProduct.Name = "comboProduct";
            comboProduct.Size = new Size(342, 39);
            comboProduct.TabIndex = 8;
            comboProduct.SelectedIndexChanged += comboProduct_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 295);
            label5.Name = "label5";
            label5.Size = new Size(81, 28);
            label5.TabIndex = 9;
            label5.Text = "Product";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(615, 300);
            label6.Name = "label6";
            label6.Size = new Size(44, 23);
            label6.TabIndex = 10;
            label6.Text = "Rate";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(354, 300);
            label7.Name = "label7";
            label7.Size = new Size(37, 23);
            label7.TabIndex = 12;
            label7.Text = "Qty";
            // 
            // lblStockQty
            // 
            lblStockQty.AutoSize = true;
            lblStockQty.Font = new Font("Segoe UI", 12F);
            lblStockQty.Location = new Point(6, 72);
            lblStockQty.Name = "lblStockQty";
            lblStockQty.Size = new Size(79, 28);
            lblStockQty.TabIndex = 14;
            lblStockQty.Text = "Weight:";
            // 
            // lblStockWt
            // 
            lblStockWt.AutoSize = true;
            lblStockWt.Font = new Font("Segoe UI", 12F);
            lblStockWt.Location = new Point(6, 35);
            lblStockWt.Name = "lblStockWt";
            lblStockWt.Size = new Size(48, 28);
            lblStockWt.TabIndex = 15;
            lblStockWt.Text = "Qty:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(485, 300);
            label8.Name = "label8";
            label8.Size = new Size(64, 23);
            label8.TabIndex = 17;
            label8.Text = "Weight";
            // 
            // gridItems
            // 
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colUnit, colQty, colWeight, colWeightUnit, colRate, colAmount });
            gridItems.Location = new Point(6, 373);
            gridItems.Name = "gridItems";
            gridItems.RowHeadersWidth = 51;
            gridItems.Size = new Size(1252, 188);
            gridItems.TabIndex = 18;
            // 
            // colProductId
            // 
            colProductId.HeaderText = "Id";
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
            colProductName.Width = 150;
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(1032, 570);
            label9.Name = "label9";
            label9.Size = new Size(54, 28);
            label9.TabIndex = 19;
            label9.Text = "Total";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(966, 673);
            label10.Name = "label10";
            label10.Size = new Size(120, 28);
            label10.TabIndex = 21;
            label10.Text = "Net Amount";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(997, 622);
            label11.Name = "label11";
            label11.Size = new Size(89, 28);
            label11.TabIndex = 23;
            label11.Text = "Discount";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(656, 100);
            label12.Name = "label12";
            label12.Size = new Size(53, 28);
            label12.TabIndex = 25;
            label12.Text = "Date";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new Font("Segoe UI", 12F);
            dateInvoice.Format = DateTimePickerFormat.Short;
            dateInvoice.Location = new Point(715, 97);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new Size(177, 34);
            dateInvoice.TabIndex = 26;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(615, 199);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(277, 34);
            txtDescription.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(497, 202);
            label13.Name = "label13";
            label13.Size = new Size(112, 28);
            label13.TabIndex = 27;
            label13.Text = "Description";
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
            BtnAddItem.Location = new Point(966, 328);
            BtnAddItem.Name = "BtnAddItem";
            BtnAddItem.Size = new Size(124, 34);
            BtnAddItem.TabIndex = 32;
            BtnAddItem.Text = "Add Item";
            BtnAddItem.TextColor = Color.White;
            BtnAddItem.UseVisualStyleBackColor = false;
            BtnAddItem.Click += BtnAddItem_Click;
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
            BtnDeleteRow.Location = new Point(6, 567);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(128, 34);
            BtnDeleteRow.TabIndex = 33;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.White;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
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
            BtnSave.Location = new Point(1058, 785);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(188, 50);
            BtnSave.TabIndex = 34;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
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
            BtnClose.Location = new Point(911, 785);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(141, 50);
            BtnClose.TabIndex = 35;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStockWt);
            groupBox1.Controls.Add(lblStockQty);
            groupBox1.Location = new Point(938, 97);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stock Details";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1258, 60);
            panel1.TabIndex = 37;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(542, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(185, 38);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Sales Invoice";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 10.2F);
            lblAmount.Location = new Point(744, 300);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(72, 23);
            lblAmount.TabIndex = 38;
            lblAmount.Text = "Amount";
            // 
            // txtQty
            // 
            txtQty.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQty.Location = new Point(354, 328);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(125, 38);
            txtQty.TabIndex = 40;
            txtQty.Text = "0";
            txtQty.TextAlign = HorizontalAlignment.Right;
            txtQty.TextChanged += txtQty_TextChanged;
            txtQty.KeyDown += txtQty_KeyDown;
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWeight.Location = new Point(482, 328);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(125, 38);
            txtWeight.TabIndex = 41;
            txtWeight.Text = "0";
            txtWeight.TextAlign = HorizontalAlignment.Right;
            txtWeight.TextChanged += txtWeight_TextChanged;
            txtWeight.KeyDown += txtWeight_KeyDown;
            // 
            // txtRate
            // 
            txtRate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRate.Location = new Point(613, 328);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(125, 38);
            txtRate.TabIndex = 42;
            txtRate.Text = "0";
            txtRate.TextAlign = HorizontalAlignment.Right;
            txtRate.TextChanged += txtRate_TextChanged;
            txtRate.KeyDown += txtRate_KeyDown;
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiscount.Location = new Point(1092, 617);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(154, 38);
            txtDiscount.TabIndex = 43;
            txtDiscount.Text = "0";
            txtDiscount.TextAlign = HorizontalAlignment.Right;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            txtDiscount.KeyDown += txtDiscount_KeyDown;
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(744, 328);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(211, 38);
            txtAmount.TabIndex = 44;
            txtAmount.Text = "0";
            txtAmount.TextAlign = HorizontalAlignment.Right;
            txtAmount.TextChanged += txtAmount_TextChanged;
            txtAmount.KeyDown += txtAmount_KeyDown;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(1091, 565);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(156, 38);
            txtTotal.TabIndex = 45;
            // 
            // txtNetAmount
            // 
            txtNetAmount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNetAmount.Location = new Point(1092, 668);
            txtNetAmount.Name = "txtNetAmount";
            txtNetAmount.Size = new Size(155, 38);
            txtNetAmount.TabIndex = 46;
            // 
            // SaleInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 847);
            Controls.Add(txtNetAmount);
            Controls.Add(txtTotal);
            Controls.Add(txtAmount);
            Controls.Add(txtDiscount);
            Controls.Add(txtRate);
            Controls.Add(txtWeight);
            Controls.Add(txtQty);
            Controls.Add(lblAmount);
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
            Controls.Add(txtVoucherNo);
            Controls.Add(label2);
            Controls.Add(comboPaymentMode);
            Controls.Add(label1);
            Name = "SaleInvoice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SaleInvoice";
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboPaymentMode;
        private Label label2;
        private TextBox txtVoucherNo;
        private Label label3;
        private Label label4;
        private ComboBox comboPartyId;
        private ComboBox comboPartyName;
        private ComboBox comboProduct;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblStockQty;
        private Label lblStockWt;
        private Label label8;
        private DataGridView gridItems;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private DateTimePicker dateInvoice;
        private TextBox txtDescription;
        private Label label13;        
        private CustomButton BtnAddItem;
        private CustomButton BtnDeleteRow;
        private CustomButton BtnSave;
        private CustomButton BtnClose;
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
        private Label lblAmount;
        private TextBox txtQty;
        private TextBox txtWeight;
        private TextBox txtRate;
        private TextBox txtDiscount;
        private TextBox txtAmount;
        private TextBox txtTotal;
        private TextBox txtNetAmount;
    }
}