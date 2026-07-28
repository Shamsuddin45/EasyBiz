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
            panel2 = new Panel();
            lblInWords = new Label();
            btnAiPredict = new Button();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(316, 454);
            label2.Name = "label2";
            label2.Size = new Size(83, 23);
            label2.TabIndex = 2;
            label2.Text = "Voucher#";
            label2.Visible = false;
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 12F);
            txtVoucherNo.Location = new Point(405, 450);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new Size(161, 34);
            txtVoucherNo.TabIndex = 3;
            txtVoucherNo.TabStop = false;
            txtVoucherNo.TextAlign = HorizontalAlignment.Center;
            txtVoucherNo.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(201, 29);
            label3.Name = "label3";
            label3.Size = new Size(70, 23);
            label3.TabIndex = 4;
            label3.Text = "Party ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(372, 29);
            label4.Name = "label4";
            label4.Size = new Size(99, 23);
            label4.TabIndex = 5;
            label4.Text = "Party Name";
            // 
            // comboPartyId
            // 
            comboPartyId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPartyId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPartyId.Font = new Font("Segoe UI", 12F);
            comboPartyId.FormattingEnabled = true;
            comboPartyId.Location = new Point(201, 55);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new Size(165, 36);
            comboPartyId.TabIndex = 3;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // comboPartyName
            // 
            comboPartyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPartyName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPartyName.Font = new Font("Segoe UI", 12F);
            comboPartyName.FormattingEnabled = true;
            comboPartyName.Location = new Point(372, 55);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(344, 36);
            comboPartyName.TabIndex = 4;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // comboProduct
            // 
            comboProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboProduct.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProduct.FormattingEnabled = true;
            comboProduct.Location = new Point(17, 211);
            comboProduct.Name = "comboProduct";
            comboProduct.Size = new Size(328, 39);
            comboProduct.TabIndex = 6;
            comboProduct.SelectedIndexChanged += comboProduct_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(18, 180);
            label5.Name = "label5";
            label5.Size = new Size(81, 28);
            label5.TabIndex = 9;
            label5.Text = "Product";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(612, 185);
            label6.Name = "label6";
            label6.Size = new Size(44, 23);
            label6.TabIndex = 10;
            label6.Text = "Rate";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(351, 185);
            label7.Name = "label7";
            label7.Size = new Size(37, 23);
            label7.TabIndex = 12;
            label7.Text = "Qty";
            // 
            // lblStockQty
            // 
            lblStockQty.AutoSize = true;
            lblStockQty.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblStockQty.Location = new Point(6, 72);
            lblStockQty.Name = "lblStockQty";
            lblStockQty.Size = new Size(62, 20);
            lblStockQty.TabIndex = 14;
            lblStockQty.Text = "Weight:";
            // 
            // lblStockWt
            // 
            lblStockWt.AutoSize = true;
            lblStockWt.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblStockWt.Location = new Point(6, 35);
            lblStockWt.Name = "lblStockWt";
            lblStockWt.Size = new Size(37, 20);
            lblStockWt.TabIndex = 15;
            lblStockWt.Text = "Qty:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(482, 185);
            label8.Name = "label8";
            label8.Size = new Size(64, 23);
            label8.TabIndex = 17;
            label8.Text = "Weight";
            // 
            // gridItems
            // 
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colProductId, colProductName, colUnit, colQty, colWeight, colWeightUnit, colRate, colAmount });
            gridItems.Location = new Point(17, 258);
            gridItems.Name = "gridItems";
            gridItems.RowHeadersWidth = 51;
            gridItems.Size = new Size(935, 188);
            gridItems.TabIndex = 11;
            gridItems.TabStop = false;
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
            colWeightUnit.HeaderText = "Wt-Unit";
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
            label9.Font = new Font("Microsoft Sans Serif", 10.2F);
            label9.Location = new Point(745, 464);
            label9.Name = "label9";
            label9.Size = new Size(46, 20);
            label9.TabIndex = 19;
            label9.Text = "Total";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.2F);
            label10.Location = new Point(693, 557);
            label10.Name = "label10";
            label10.Size = new Size(97, 20);
            label10.TabIndex = 21;
            label10.Text = "Net Amount";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10.2F);
            label11.Location = new Point(715, 507);
            label11.Name = "label11";
            label11.Size = new Size(76, 20);
            label11.TabIndex = 23;
            label11.Text = "Discount";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F);
            label12.Location = new Point(18, 31);
            label12.Name = "label12";
            label12.Size = new Size(46, 23);
            label12.TabIndex = 25;
            label12.Text = "Date";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new Font("Segoe UI", 12F);
            dateInvoice.Format = DateTimePickerFormat.Short;
            dateInvoice.Location = new Point(18, 57);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new Size(177, 34);
            dateInvoice.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(201, 100);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(442, 34);
            txtDescription.TabIndex = 5;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F);
            label13.Location = new Point(99, 105);
            label13.Name = "label13";
            label13.Size = new Size(96, 23);
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
            BtnAddItem.Location = new Point(152, 450);
            BtnAddItem.Name = "BtnAddItem";
            BtnAddItem.Size = new Size(124, 34);
            BtnAddItem.TabIndex = 11;
            BtnAddItem.Text = "Add Item";
            BtnAddItem.TextColor = Color.White;
            BtnAddItem.UseVisualStyleBackColor = false;
            BtnAddItem.Visible = false;
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
            BtnDeleteRow.Location = new Point(18, 450);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(128, 34);
            BtnDeleteRow.TabIndex = 33;
            BtnDeleteRow.TabStop = false;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.White;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Visible = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.LawnGreen;
            BtnSave.BackgroundColor = Color.LawnGreen;
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 15;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSave.ForeColor = Color.Black;
            BtnSave.Location = new Point(797, 610);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(155, 39);
            BtnSave.TabIndex = 13;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.Black;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Snow;
            BtnClose.BackgroundColor = Color.Snow;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 15;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 9F);
            BtnClose.ForeColor = Color.Red;
            BtnClose.Location = new Point(672, 610);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(113, 39);
            BtnClose.TabIndex = 14;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.Red;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStockWt);
            groupBox1.Controls.Add(lblStockQty);
            groupBox1.Location = new Point(737, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(245, 125);
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
            panel1.Size = new Size(994, 60);
            panel1.TabIndex = 37;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(405, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(185, 38);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Sales Invoice";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 10.2F);
            lblAmount.Location = new Point(741, 185);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(72, 23);
            lblAmount.TabIndex = 38;
            lblAmount.Text = "Amount";
            // 
            // txtQty
            // 
            txtQty.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQty.Location = new Point(351, 213);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(125, 38);
            txtQty.TabIndex = 7;
            txtQty.Text = "0";
            txtQty.TextAlign = HorizontalAlignment.Right;
            txtQty.TextChanged += txtQty_TextChanged;
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWeight.Location = new Point(479, 213);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(125, 38);
            txtWeight.TabIndex = 8;
            txtWeight.Text = "0";
            txtWeight.TextAlign = HorizontalAlignment.Right;
            txtWeight.TextChanged += txtWeight_TextChanged;
            // 
            // txtRate
            // 
            txtRate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRate.Location = new Point(610, 213);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(125, 38);
            txtRate.TabIndex = 9;
            txtRate.Text = "0";
            txtRate.TextAlign = HorizontalAlignment.Right;
            txtRate.TextChanged += txtRate_TextChanged;
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiscount.Location = new Point(797, 498);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(154, 38);
            txtDiscount.TabIndex = 12;
            txtDiscount.Text = "0";
            txtDiscount.TextAlign = HorizontalAlignment.Right;
            txtDiscount.TextChanged += txtDiscount_TextChanged;
            txtDiscount.KeyDown += txtDiscount_KeyDown;
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(741, 213);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(211, 38);
            txtAmount.TabIndex = 10;
            txtAmount.Text = "0";
            txtAmount.TextAlign = HorizontalAlignment.Right;
            txtAmount.TextChanged += txtAmount_TextChanged;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(796, 454);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(156, 38);
            txtTotal.TabIndex = 45;
            txtTotal.TabStop = false;
            // 
            // txtNetAmount
            // 
            txtNetAmount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNetAmount.Location = new Point(797, 545);
            txtNetAmount.Name = "txtNetAmount";
            txtNetAmount.ReadOnly = true;
            txtNetAmount.Size = new Size(155, 38);
            txtNetAmount.TabIndex = 46;
            txtNetAmount.TabStop = false;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(btnAiPredict);
            panel2.Controls.Add(lblInWords);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtVoucherNo);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(comboPartyId);
            panel2.Controls.Add(comboPartyName);
            panel2.Controls.Add(comboProduct);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(gridItems);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(dateInvoice);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(txtDescription);
            panel2.Controls.Add(BtnAddItem);
            panel2.Controls.Add(BtnDeleteRow);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(lblAmount);
            panel2.Controls.Add(txtQty);
            panel2.Controls.Add(txtWeight);
            panel2.Controls.Add(txtRate);
            panel2.Controls.Add(txtAmount);
            panel2.Controls.Add(BtnSave);
            panel2.Controls.Add(txtNetAmount);
            panel2.Controls.Add(BtnClose);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(txtDiscount);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(994, 661);
            panel2.TabIndex = 47;
            // 
            // lblInWords
            // 
            lblInWords.AutoSize = true;
            lblInWords.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInWords.Location = new Point(32, 557);
            lblInWords.Name = "lblInWords";
            lblInWords.Size = new Size(20, 28);
            lblInWords.TabIndex = 47;
            lblInWords.Text = "-";
            // 
            // btnAiPredict
            // 
            btnAiPredict.Location = new Point(649, 100);
            btnAiPredict.Name = "btnAiPredict";
            btnAiPredict.Size = new Size(67, 34);
            btnAiPredict.TabIndex = 48;
            btnAiPredict.Text = "✨ AI";
            btnAiPredict.UseVisualStyleBackColor = true;
            // 
            // SaleInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 721);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SaleInvoice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sale Invoice";
            FormClosing += SaleInvoice_FormClosing;
            Load += SaleInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private Label lblAmount;
        private TextBox txtQty;
        private TextBox txtWeight;
        private TextBox txtRate;
        private TextBox txtDiscount;
        private TextBox txtAmount;
        private TextBox txtTotal;
        private TextBox txtNetAmount;
        private Panel panel2;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colUnit;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colWeight;
        private DataGridViewTextBoxColumn colWeightUnit;
        private DataGridViewTextBoxColumn colRate;
        private DataGridViewTextBoxColumn colAmount;
        private Label lblInWords;
        private Button btnAiPredict;
    }
}