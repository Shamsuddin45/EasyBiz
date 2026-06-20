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
            numRate = new NumericUpDown();
            numQty = new NumericUpDown();
            label7 = new Label();
            lblStockQty = new Label();
            lblStockWt = new Label();
            numWeight = new NumericUpDown();
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
            numTotal = new NumericUpDown();
            numNetAmount = new NumericUpDown();
            numDiscount = new NumericUpDown();
            BtnAddItem = new CustomButton();
            BtnDeleteRow = new CustomButton();
            BtnSave = new CustomButton();
            BtnClose = new CustomButton();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            lblHeader = new Label();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNetAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(329, 153);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 0;
            label1.Text = "Payment Mode";
            // 
            // comboPaymentMode
            // 
            comboPaymentMode.Font = new Font("Segoe UI", 12F);
            comboPaymentMode.FormattingEnabled = true;
            comboPaymentMode.Location = new Point(479, 150);
            comboPaymentMode.Name = "comboPaymentMode";
            comboPaymentMode.Size = new Size(165, 36);
            comboPaymentMode.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 150);
            label2.Name = "label2";
            label2.Size = new Size(119, 28);
            label2.TabIndex = 2;
            label2.Text = "Voucher No:";
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 12F);
            txtVoucherNo.Location = new Point(137, 150);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new Size(165, 34);
            txtVoucherNo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(45, 239);
            label3.Name = "label3";
            label3.Size = new Size(80, 28);
            label3.TabIndex = 4;
            label3.Text = "Party ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 280);
            label4.Name = "label4";
            label4.Size = new Size(113, 28);
            label4.TabIndex = 5;
            label4.Text = "Party Name";
            // 
            // comboPartyId
            // 
            comboPartyId.Font = new Font("Segoe UI", 12F);
            comboPartyId.FormattingEnabled = true;
            comboPartyId.Location = new Point(131, 236);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new Size(165, 36);
            comboPartyId.TabIndex = 6;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // comboPartyName
            // 
            comboPartyName.Font = new Font("Segoe UI", 12F);
            comboPartyName.FormattingEnabled = true;
            comboPartyName.Location = new Point(131, 280);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(344, 36);
            comboPartyName.TabIndex = 7;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // comboProduct
            // 
            comboProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProduct.FormattingEnabled = true;
            comboProduct.Location = new Point(131, 353);
            comboProduct.Name = "comboProduct";
            comboProduct.Size = new Size(342, 39);
            comboProduct.TabIndex = 8;
            comboProduct.SelectedIndexChanged += comboProduct_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(131, 325);
            label5.Name = "label5";
            label5.Size = new Size(81, 28);
            label5.TabIndex = 9;
            label5.Text = "Product";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(479, 325);
            label6.Name = "label6";
            label6.Size = new Size(51, 28);
            label6.TabIndex = 10;
            label6.Text = "Rate";
            // 
            // numRate
            // 
            numRate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numRate.Location = new Point(479, 354);
            numRate.Margin = new Padding(2);
            numRate.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numRate.Name = "numRate";
            numRate.Size = new Size(132, 38);
            numRate.TabIndex = 11;
            numRate.ThousandsSeparator = true;
            numRate.UpDownAlign = LeftRightAlignment.Left;
            numRate.UseWaitCursor = true;
            // 
            // numQty
            // 
            numQty.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numQty.Location = new Point(615, 354);
            numQty.Margin = new Padding(2);
            numQty.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numQty.Name = "numQty";
            numQty.Size = new Size(93, 38);
            numQty.TabIndex = 13;
            numQty.ThousandsSeparator = true;
            numQty.UpDownAlign = LeftRightAlignment.Left;
            numQty.UseWaitCursor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(615, 324);
            label7.Name = "label7";
            label7.Size = new Size(44, 28);
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
            // numWeight
            // 
            numWeight.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numWeight.Location = new Point(712, 355);
            numWeight.Margin = new Padding(2);
            numWeight.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numWeight.Name = "numWeight";
            numWeight.Size = new Size(121, 38);
            numWeight.TabIndex = 16;
            numWeight.ThousandsSeparator = true;
            numWeight.UpDownAlign = LeftRightAlignment.Left;
            numWeight.UseWaitCursor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(715, 325);
            label8.Name = "label8";
            label8.Size = new Size(75, 28);
            label8.TabIndex = 17;
            label8.Text = "Weight";
            // 
            // gridItems
            // 
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colUnit, colQty, colWeight, colWeightUnit, colRate, colAmount });
            gridItems.Location = new Point(131, 398);
            gridItems.Name = "gridItems";
            gridItems.RowHeadersWidth = 51;
            gridItems.Size = new Size(1057, 188);
            gridItems.TabIndex = 18;
            // 
            // colProductId
            // 
            colProductId.HeaderText = "Product Id";
            colProductId.MinimumWidth = 6;
            colProductId.Name = "colProductId";
            colProductId.Width = 125;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            colProductName.Width = 125;
            // 
            // colUnit
            // 
            colUnit.HeaderText = "Unit";
            colUnit.MinimumWidth = 6;
            colUnit.Name = "colUnit";
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
            label9.Location = new Point(673, 595);
            label9.Name = "label9";
            label9.Size = new Size(54, 28);
            label9.TabIndex = 19;
            label9.Text = "Total";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(897, 593);
            label10.Name = "label10";
            label10.Size = new Size(120, 28);
            label10.TabIndex = 21;
            label10.Text = "Net Amount";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(136, 593);
            label11.Name = "label11";
            label11.Size = new Size(89, 28);
            label11.TabIndex = 23;
            label11.Text = "Discount";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(653, 153);
            label12.Name = "label12";
            label12.Size = new Size(53, 28);
            label12.TabIndex = 25;
            label12.Text = "Date";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new Font("Segoe UI", 12F);
            dateInvoice.Format = DateTimePickerFormat.Short;
            dateInvoice.Location = new Point(712, 150);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new Size(177, 34);
            dateInvoice.TabIndex = 26;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(617, 280);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(308, 34);
            txtDescription.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(499, 283);
            label13.Name = "label13";
            label13.Size = new Size(112, 28);
            label13.TabIndex = 27;
            label13.Text = "Description";
            // 
            // numTotal
            // 
            numTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numTotal.Location = new Point(732, 591);
            numTotal.Margin = new Padding(2);
            numTotal.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numTotal.Name = "numTotal";
            numTotal.Size = new Size(156, 38);
            numTotal.TabIndex = 29;
            numTotal.ThousandsSeparator = true;
            // 
            // numNetAmount
            // 
            numNetAmount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numNetAmount.Location = new Point(1022, 589);
            numNetAmount.Margin = new Padding(2);
            numNetAmount.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numNetAmount.Name = "numNetAmount";
            numNetAmount.Size = new Size(166, 38);
            numNetAmount.TabIndex = 30;
            numNetAmount.ThousandsSeparator = true;
            // 
            // numDiscount
            // 
            numDiscount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numDiscount.Location = new Point(230, 591);
            numDiscount.Margin = new Padding(2);
            numDiscount.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(132, 38);
            numDiscount.TabIndex = 31;
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
            BtnAddItem.Location = new Point(913, 358);
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
            BtnDeleteRow.Location = new Point(1043, 358);
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
            BtnSave.Location = new Point(1000, 680);
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
            BtnClose.Location = new Point(853, 680);
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
            groupBox1.Location = new Point(930, 147);
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
            // SaleInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 754);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(BtnDeleteRow);
            Controls.Add(BtnAddItem);
            Controls.Add(numDiscount);
            Controls.Add(numNetAmount);
            Controls.Add(numTotal);
            Controls.Add(txtDescription);
            Controls.Add(label13);
            Controls.Add(dateInvoice);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(gridItems);
            Controls.Add(label8);
            Controls.Add(numWeight);
            Controls.Add(numQty);
            Controls.Add(label7);
            Controls.Add(numRate);
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
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNetAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
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
        private NumericUpDown numRate;
        private NumericUpDown numQty;
        private Label label7;
        private Label lblStockQty;
        private Label lblStockWt;
        private NumericUpDown numWeight;
        private Label label8;
        private DataGridView gridItems;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private DateTimePicker dateInvoice;
        private TextBox txtDescription;
        private Label label13;
        private NumericUpDown numTotal;
        private NumericUpDown numNetAmount;
        private NumericUpDown numDiscount;
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
    }
}