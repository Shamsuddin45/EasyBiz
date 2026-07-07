namespace EasyBiz
{
    partial class ProductSetup
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            comboSearch = new ComboBox();
            label2 = new Label();
            txtProductName = new TextBox();
            txtDescription = new TextBox();
            label3 = new Label();
            label4 = new Label();
            comboUnit = new ComboBox();
            comboWeightUnit = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            numSaleRate = new NumericUpDown();
            numPurchaseRate = new NumericUpDown();
            label7 = new Label();
            numMinStock = new NumericUpDown();
            label8 = new Label();
            numProductId = new NumericUpDown();
            label9 = new Label();
            BtnSave = new CustomButton();
            BtnUpdate = new CustomButton();
            BtnRefresh = new CustomButton();
            BtnClose = new CustomButton();
            toolTipMinStockQty = new ToolTip(components);
            comboSelectUnit = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            panelContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)numSaleRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPurchaseRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numProductId).BeginInit();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F);
            label1.Location = new Point(691, 26);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 0;
            label1.Text = "*Search Product";
            toolTipMinStockQty.SetToolTip(label1, "Select a product to view or edit its details");
            // 
            // comboSearch
            // 
            comboSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearch.Font = new Font("Segoe UI", 12F);
            comboSearch.FormattingEnabled = true;
            comboSearch.Location = new Point(693, 49);
            comboSearch.Name = "comboSearch";
            comboSearch.Size = new Size(311, 36);
            comboSearch.TabIndex = 1;
            comboSearch.TabStop = false;
            comboSearch.SelectedIndexChanged += comboSearch_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F);
            label2.Location = new Point(70, 112);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 2;
            label2.Text = "Product Name";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductName.Location = new Point(192, 100);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(457, 38);
            txtProductName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(192, 148);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "optional";
            txtDescription.Size = new Size(457, 34);
            txtDescription.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F);
            label3.Location = new Point(91, 158);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 4;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F);
            label4.Location = new Point(146, 225);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 6;
            label4.Text = "Unit";
            // 
            // comboUnit
            // 
            comboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboUnit.Font = new Font("Segoe UI", 12F);
            comboUnit.FormattingEnabled = true;
            comboUnit.Location = new Point(191, 215);
            comboUnit.Name = "comboUnit";
            comboUnit.Size = new Size(151, 36);
            comboUnit.TabIndex = 3;
            // 
            // comboWeightUnit
            // 
            comboWeightUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboWeightUnit.Font = new Font("Segoe UI", 12F);
            comboWeightUnit.FormattingEnabled = true;
            comboWeightUnit.Location = new Point(504, 215);
            comboWeightUnit.Name = "comboWeightUnit";
            comboWeightUnit.Size = new Size(144, 36);
            comboWeightUnit.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.2F);
            label5.Location = new Point(402, 223);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 8;
            label5.Text = "Weight Unit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10.2F);
            label6.Location = new Point(104, 316);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 10;
            label6.Text = "Sale Rate";
            // 
            // numSaleRate
            // 
            numSaleRate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numSaleRate.Location = new Point(192, 307);
            numSaleRate.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numSaleRate.Name = "numSaleRate";
            numSaleRate.Size = new Size(150, 38);
            numSaleRate.TabIndex = 5;
            numSaleRate.TextAlign = HorizontalAlignment.Center;
            numSaleRate.ThousandsSeparator = true;
            // 
            // numPurchaseRate
            // 
            numPurchaseRate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numPurchaseRate.Location = new Point(505, 305);
            numPurchaseRate.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numPurchaseRate.Name = "numPurchaseRate";
            numPurchaseRate.Size = new Size(144, 38);
            numPurchaseRate.TabIndex = 6;
            numPurchaseRate.TextAlign = HorizontalAlignment.Center;
            numPurchaseRate.ThousandsSeparator = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 10.2F);
            label7.Location = new Point(379, 316);
            label7.Name = "label7";
            label7.Size = new Size(120, 20);
            label7.TabIndex = 12;
            label7.Text = "Purchase Rate";
            // 
            // numMinStock
            // 
            numMinStock.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numMinStock.Location = new Point(192, 360);
            numMinStock.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numMinStock.Name = "numMinStock";
            numMinStock.Size = new Size(150, 38);
            numMinStock.TabIndex = 7;
            numMinStock.TextAlign = HorizontalAlignment.Center;
            numMinStock.ThousandsSeparator = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 10.2F);
            label8.ForeColor = Color.IndianRed;
            label8.Location = new Point(65, 371);
            label8.Name = "label8";
            label8.Size = new Size(120, 20);
            label8.TabIndex = 14;
            label8.Text = "*Min Stock Qty";
            toolTipMinStockQty.SetToolTip(label8, "Enter a minimum stock quantity. \r\nProduct row will turn red in the Stock Report when the available stock reaches or falls below this quantity.");
            // 
            // numProductId
            // 
            numProductId.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numProductId.Location = new Point(192, 45);
            numProductId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numProductId.Name = "numProductId";
            numProductId.ReadOnly = true;
            numProductId.Size = new Size(150, 38);
            numProductId.TabIndex = 17;
            numProductId.TabStop = false;
            numProductId.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10.2F);
            label9.Location = new Point(97, 56);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 16;
            label9.Text = "Product ID";
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(52, 152, 219);
            BtnSave.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 10;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 10.2F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(785, 151);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(153, 50);
            BtnSave.TabIndex = 9;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.BackColor = Color.FromArgb(0, 192, 0);
            BtnUpdate.BackgroundColor = Color.FromArgb(0, 192, 0);
            BtnUpdate.BorderColor = Color.Transparent;
            BtnUpdate.BorderRadius = 10;
            BtnUpdate.BorderSize = 0;
            BtnUpdate.Enabled = false;
            BtnUpdate.FlatAppearance.BorderSize = 0;
            BtnUpdate.FlatStyle = FlatStyle.Flat;
            BtnUpdate.Font = new Font("Segoe UI", 10.2F);
            BtnUpdate.ForeColor = Color.White;
            BtnUpdate.Location = new Point(785, 207);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(153, 50);
            BtnUpdate.TabIndex = 10;
            BtnUpdate.Text = "Update (Ctrl+U)";
            BtnUpdate.TextColor = Color.White;
            BtnUpdate.UseVisualStyleBackColor = false;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.Chocolate;
            BtnRefresh.BackgroundColor = Color.Chocolate;
            BtnRefresh.BorderColor = Color.Transparent;
            BtnRefresh.BorderRadius = 10;
            BtnRefresh.BorderSize = 0;
            BtnRefresh.FlatAppearance.BorderSize = 0;
            BtnRefresh.FlatStyle = FlatStyle.Flat;
            BtnRefresh.Font = new Font("Segoe UI", 10.2F);
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(785, 263);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(153, 50);
            BtnRefresh.TabIndex = 11;
            BtnRefresh.Text = "Refresh [F5]";
            BtnRefresh.TextColor = Color.White;
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Firebrick;
            BtnClose.BackgroundColor = Color.Firebrick;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 10;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 10.2F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(785, 319);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(153, 50);
            BtnClose.TabIndex = 12;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // comboSelectUnit
            // 
            comboSelectUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSelectUnit.Font = new Font("Segoe UI", 12F);
            comboSelectUnit.FormattingEnabled = true;
            comboSelectUnit.Items.AddRange(new object[] { "Weight", "Quantity" });
            comboSelectUnit.Location = new Point(478, 47);
            comboSelectUnit.Name = "comboSelectUnit";
            comboSelectUnit.Size = new Size(172, 36);
            comboSelectUnit.TabIndex = 8;
            comboSelectUnit.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10.2F);
            label10.Location = new Point(392, 56);
            label10.Name = "label10";
            label10.Size = new Size(80, 20);
            label10.TabIndex = 22;
            label10.Text = "Unit type:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10.2F);
            label11.ForeColor = SystemColors.ButtonShadow;
            label11.Location = new Point(828, 26);
            label11.Name = "label11";
            label11.Size = new Size(38, 20);
            label11.TabIndex = 24;
            label11.Text = "[F1]";
            // 
            // panelContainer
            // 
            panelContainer.AutoScroll = true;
            panelContainer.AutoScrollMargin = new Size(10, 10);
            panelContainer.Controls.Add(label11);
            panelContainer.Controls.Add(comboSelectUnit);
            panelContainer.Controls.Add(label10);
            panelContainer.Controls.Add(BtnClose);
            panelContainer.Controls.Add(BtnRefresh);
            panelContainer.Controls.Add(BtnUpdate);
            panelContainer.Controls.Add(BtnSave);
            panelContainer.Controls.Add(numProductId);
            panelContainer.Controls.Add(label9);
            panelContainer.Controls.Add(numMinStock);
            panelContainer.Controls.Add(label8);
            panelContainer.Controls.Add(numPurchaseRate);
            panelContainer.Controls.Add(label7);
            panelContainer.Controls.Add(numSaleRate);
            panelContainer.Controls.Add(label6);
            panelContainer.Controls.Add(comboWeightUnit);
            panelContainer.Controls.Add(label5);
            panelContainer.Controls.Add(comboUnit);
            panelContainer.Controls.Add(label4);
            panelContainer.Controls.Add(txtDescription);
            panelContainer.Controls.Add(label3);
            panelContainer.Controls.Add(txtProductName);
            panelContainer.Controls.Add(label2);
            panelContainer.Controls.Add(comboSearch);
            panelContainer.Controls.Add(label1);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1040, 460);
            panelContainer.TabIndex = 25;
            // 
            // ProductSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 460);
            Controls.Add(panelContainer);
            Name = "ProductSetup";
            Text = "Product Setup";
            FormClosing += ProductSetup_FormClosing;
            Load += ProductSetup_Load;
            ((System.ComponentModel.ISupportInitialize)numSaleRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPurchaseRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numProductId).EndInit();
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboSearch;
        private Label label2;
        private TextBox txtProductName;
        private TextBox txtDescription;
        private Label label3;
        private Label label4;
        private ComboBox comboUnit;
        private ComboBox comboWeightUnit;
        private Label label5;
        private Label label6;
        private NumericUpDown numSaleRate;
        private NumericUpDown numPurchaseRate;
        private Label label7;
        private NumericUpDown numMinStock;
        private Label label8;
        private NumericUpDown numProductId;
        private Label label9;
        private CustomButton BtnSave;
        private CustomButton BtnUpdate;
        private CustomButton BtnRefresh;
        private CustomButton BtnClose;
        private ToolTip toolTipMinStockQty;
        private ComboBox comboSelectUnit;
        private Label label10;
        private Label label11;
        private Panel panelContainer;
    }
}