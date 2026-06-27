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
            numQty = new NumericUpDown();
            label7 = new Label();
            numRate = new NumericUpDown();
            label6 = new Label();
            lblStockWt = new Label();
            lblStockQty = new Label();
            label8 = new Label();
            numWeight = new NumericUpDown();
            gridItems = new DataGridView();
            numDiscount = new NumericUpDown();
            numNetAmount = new NumericUpDown();
            numTotal = new NumericUpDown();
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
            colProductId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colWeight = new DataGridViewTextBoxColumn();
            colWeightUnit = new DataGridViewTextBoxColumn();
            colRate = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNetAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTotal).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 12F);
            txtVoucherNo.Location = new Point(146, 163);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new Size(165, 34);
            txtVoucherNo.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(21, 163);
            label2.Name = "label2";
            label2.Size = new Size(119, 28);
            label2.TabIndex = 4;
            label2.Text = "Voucher No:";
            // 
            // comboPaymentMode
            // 
            comboPaymentMode.Font = new Font("Segoe UI", 12F);
            comboPaymentMode.FormattingEnabled = true;
            comboPaymentMode.Location = new Point(480, 163);
            comboPaymentMode.Name = "comboPaymentMode";
            comboPaymentMode.Size = new Size(165, 36);
            comboPaymentMode.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(330, 166);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 6;
            label1.Text = "Payment Mode";
            // 
            // comboPartyName
            // 
            comboPartyName.Font = new Font("Segoe UI", 12F);
            comboPartyName.FormattingEnabled = true;
            comboPartyName.Location = new Point(146, 305);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(344, 36);
            comboPartyName.TabIndex = 11;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // comboPartyId
            // 
            comboPartyId.Font = new Font("Segoe UI", 12F);
            comboPartyId.FormattingEnabled = true;
            comboPartyId.Location = new Point(146, 261);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new Size(165, 36);
            comboPartyId.TabIndex = 10;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(27, 305);
            label4.Name = "label4";
            label4.Size = new Size(113, 28);
            label4.TabIndex = 9;
            label4.Text = "Party Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(60, 264);
            label3.Name = "label3";
            label3.Size = new Size(80, 28);
            label3.TabIndex = 8;
            label3.Text = "Party ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(146, 367);
            label5.Name = "label5";
            label5.Size = new Size(81, 28);
            label5.TabIndex = 13;
            label5.Text = "Product";
            // 
            // comboProduct
            // 
            comboProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProduct.FormattingEnabled = true;
            comboProduct.Location = new Point(146, 398);
            comboProduct.Name = "comboProduct";
            comboProduct.Size = new Size(344, 39);
            comboProduct.TabIndex = 12;
            comboProduct.SelectedIndexChanged += comboProduct_SelectedIndexChanged;
            // 
            // numQty
            // 
            numQty.Font = new Font("Segoe UI", 13.8F);
            numQty.Location = new Point(640, 398);
            numQty.Margin = new Padding(2);
            numQty.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numQty.Name = "numQty";
            numQty.Size = new Size(107, 38);
            numQty.TabIndex = 17;
            numQty.TextAlign = HorizontalAlignment.Right;
            numQty.ThousandsSeparator = true;
            numQty.UpDownAlign = LeftRightAlignment.Left;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(640, 368);
            label7.Name = "label7";
            label7.Size = new Size(44, 28);
            label7.TabIndex = 16;
            label7.Text = "Qty";
            // 
            // numRate
            // 
            numRate.Font = new Font("Segoe UI", 13.8F);
            numRate.Location = new Point(504, 399);
            numRate.Margin = new Padding(2);
            numRate.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numRate.Name = "numRate";
            numRate.Size = new Size(132, 38);
            numRate.TabIndex = 15;
            numRate.TextAlign = HorizontalAlignment.Right;
            numRate.ThousandsSeparator = true;
            numRate.UpDownAlign = LeftRightAlignment.Left;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(504, 369);
            label6.Name = "label6";
            label6.Size = new Size(51, 28);
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
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(751, 368);
            label8.Name = "label8";
            label8.Size = new Size(75, 28);
            label8.TabIndex = 21;
            label8.Text = "Weight";
            // 
            // numWeight
            // 
            numWeight.Font = new Font("Segoe UI", 13.8F);
            numWeight.Location = new Point(751, 398);
            numWeight.Margin = new Padding(2);
            numWeight.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numWeight.Name = "numWeight";
            numWeight.RightToLeft = RightToLeft.No;
            numWeight.Size = new Size(121, 38);
            numWeight.TabIndex = 20;
            numWeight.TextAlign = HorizontalAlignment.Right;
            numWeight.ThousandsSeparator = true;
            numWeight.UpDownAlign = LeftRightAlignment.Left;
            // 
            // gridItems
            // 
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colUnit, colQty, colWeight, colWeightUnit, colRate, colAmount });
            gridItems.Location = new Point(146, 441);
            gridItems.Name = "gridItems";
            gridItems.RowHeadersWidth = 51;
            gridItems.Size = new Size(1057, 188);
            gridItems.TabIndex = 22;
            // 
            // numDiscount
            // 
            numDiscount.Font = new Font("Segoe UI", 12F);
            numDiscount.Location = new Point(240, 634);
            numDiscount.Margin = new Padding(2);
            numDiscount.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(132, 34);
            numDiscount.TabIndex = 37;
            // 
            // numNetAmount
            // 
            numNetAmount.Font = new Font("Segoe UI", 12F);
            numNetAmount.Location = new Point(1037, 636);
            numNetAmount.Margin = new Padding(2);
            numNetAmount.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numNetAmount.Name = "numNetAmount";
            numNetAmount.Size = new Size(166, 34);
            numNetAmount.TabIndex = 36;
            numNetAmount.ThousandsSeparator = true;
            // 
            // numTotal
            // 
            numTotal.Font = new Font("Segoe UI", 12F);
            numTotal.Location = new Point(751, 636);
            numTotal.Margin = new Padding(2);
            numTotal.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            numTotal.Name = "numTotal";
            numTotal.Size = new Size(156, 34);
            numTotal.TabIndex = 35;
            numTotal.ThousandsSeparator = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(146, 636);
            label11.Name = "label11";
            label11.Size = new Size(89, 28);
            label11.TabIndex = 34;
            label11.Text = "Discount";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(912, 638);
            label10.Name = "label10";
            label10.Size = new Size(120, 28);
            label10.TabIndex = 33;
            label10.Text = "Net Amount";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(692, 636);
            label9.Name = "label9";
            label9.Size = new Size(54, 28);
            label9.TabIndex = 32;
            label9.Text = "Total";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new Font("Segoe UI", 12F);
            dateInvoice.Format = DateTimePickerFormat.Short;
            dateInvoice.Location = new Point(737, 163);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new Size(177, 34);
            dateInvoice.TabIndex = 39;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(678, 166);
            label12.Name = "label12";
            label12.Size = new Size(53, 28);
            label12.TabIndex = 38;
            label12.Text = "Date";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(615, 307);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(308, 34);
            txtDescription.TabIndex = 41;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(497, 310);
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
            BtnDeleteRow.Location = new Point(1065, 399);
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
            BtnAddItem.Location = new Point(929, 400);
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
            groupBox1.Location = new Point(929, 154);
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
            // PurchaseInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 797);
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
            Controls.Add(numDiscount);
            Controls.Add(numNetAmount);
            Controls.Add(numTotal);
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
            Controls.Add(comboPaymentMode);
            Controls.Add(label1);
            Controls.Add(txtVoucherNo);
            Controls.Add(label2);
            Name = "PurchaseInvoice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PurchaseInvoice";
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNetAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTotal).EndInit();
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
        private NumericUpDown numQty;
        private Label label7;
        private NumericUpDown numRate;
        private Label label6;
        private Label lblStockWt;
        private Label lblStockQty;
        private Label label8;
        private NumericUpDown numWeight;
        private DataGridView gridItems;
        private NumericUpDown numDiscount;
        private NumericUpDown numNetAmount;
        private NumericUpDown numTotal;
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
    }
}