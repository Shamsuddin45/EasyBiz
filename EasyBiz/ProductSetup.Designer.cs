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
            ((System.ComponentModel.ISupportInitialize)numSaleRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPurchaseRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numProductId).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(717, 14);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 0;
            label1.Text = "Search Product";
            // 
            // comboSearch
            // 
            comboSearch.Font = new Font("Segoe UI", 12F);
            comboSearch.FormattingEnabled = true;
            comboSearch.Location = new Point(717, 45);
            comboSearch.Name = "comboSearch";
            comboSearch.Size = new Size(311, 36);
            comboSearch.TabIndex = 1;
            comboSearch.SelectedIndexChanged += comboSearch_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(22, 101);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 2;
            label2.Text = "Product Name";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 12F);
            txtProductName.Location = new Point(166, 98);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(441, 34);
            txtProductName.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(166, 146);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(441, 67);
            txtDescription.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(45, 149);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 4;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(111, 240);
            label4.Name = "label4";
            label4.Size = new Size(49, 28);
            label4.TabIndex = 6;
            label4.Text = "Unit";
            // 
            // comboUnit
            // 
            comboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboUnit.Font = new Font("Segoe UI", 12F);
            comboUnit.FormattingEnabled = true;
            comboUnit.Location = new Point(166, 237);
            comboUnit.Name = "comboUnit";
            comboUnit.Size = new Size(151, 36);
            comboUnit.TabIndex = 7;
            // 
            // comboWeightUnit
            // 
            comboWeightUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboWeightUnit.Font = new Font("Segoe UI", 12F);
            comboWeightUnit.FormattingEnabled = true;
            comboWeightUnit.Location = new Point(456, 237);
            comboWeightUnit.Name = "comboWeightUnit";
            comboWeightUnit.Size = new Size(151, 36);
            comboWeightUnit.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(333, 242);
            label5.Name = "label5";
            label5.Size = new Size(117, 28);
            label5.TabIndex = 8;
            label5.Text = "Weight Unit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(65, 307);
            label6.Name = "label6";
            label6.Size = new Size(92, 28);
            label6.TabIndex = 10;
            label6.Text = "Sale Rate";
            // 
            // numSaleRate
            // 
            numSaleRate.Font = new Font("Segoe UI", 12F);
            numSaleRate.Location = new Point(166, 305);
            numSaleRate.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numSaleRate.Name = "numSaleRate";
            numSaleRate.Size = new Size(150, 34);
            numSaleRate.TabIndex = 11;
            // 
            // numPurchaseRate
            // 
            numPurchaseRate.Font = new Font("Segoe UI", 12F);
            numPurchaseRate.Location = new Point(479, 305);
            numPurchaseRate.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numPurchaseRate.Name = "numPurchaseRate";
            numPurchaseRate.Size = new Size(128, 34);
            numPurchaseRate.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(340, 307);
            label7.Name = "label7";
            label7.Size = new Size(133, 28);
            label7.TabIndex = 12;
            label7.Text = "Purchase Rate";
            // 
            // numMinStock
            // 
            numMinStock.Font = new Font("Segoe UI", 12F);
            numMinStock.Location = new Point(166, 358);
            numMinStock.Maximum = new decimal(new int[] { 1215752191, 23, 0, 131072 });
            numMinStock.Name = "numMinStock";
            numMinStock.Size = new Size(150, 34);
            numMinStock.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.IndianRed;
            label8.Location = new Point(21, 360);
            label8.Name = "label8";
            label8.Size = new Size(136, 28);
            label8.TabIndex = 14;
            label8.Text = "Min Stock Qty";
            toolTipMinStockQty.SetToolTip(label8, "Enter a minimum stock quantity. \r\nProduct row will turn red in the Stock Report when the available stock reaches or falls below this quantity.");
            // 
            // numProductId
            // 
            numProductId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numProductId.Location = new Point(166, 43);
            numProductId.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numProductId.Name = "numProductId";
            numProductId.ReadOnly = true;
            numProductId.Size = new Size(150, 34);
            numProductId.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(55, 45);
            label9.Name = "label9";
            label9.Size = new Size(105, 28);
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
            BtnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(848, 503);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(180, 50);
            BtnSave.TabIndex = 18;
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
            BtnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnUpdate.ForeColor = Color.White;
            BtnUpdate.Location = new Point(629, 503);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(213, 50);
            BtnUpdate.TabIndex = 19;
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
            BtnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(479, 503);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(144, 50);
            BtnRefresh.TabIndex = 20;
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
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(329, 503);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(144, 50);
            BtnClose.TabIndex = 21;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // ProductSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 565);
            Controls.Add(BtnClose);
            Controls.Add(BtnRefresh);
            Controls.Add(BtnUpdate);
            Controls.Add(BtnSave);
            Controls.Add(numProductId);
            Controls.Add(label9);
            Controls.Add(numMinStock);
            Controls.Add(label8);
            Controls.Add(numPurchaseRate);
            Controls.Add(label7);
            Controls.Add(numSaleRate);
            Controls.Add(label6);
            Controls.Add(comboWeightUnit);
            Controls.Add(label5);
            Controls.Add(comboUnit);
            Controls.Add(label4);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(txtProductName);
            Controls.Add(label2);
            Controls.Add(comboSearch);
            Controls.Add(label1);
            Name = "ProductSetup";
            Text = "Product Setup";
            ((System.ComponentModel.ISupportInitialize)numSaleRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPurchaseRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numProductId).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}