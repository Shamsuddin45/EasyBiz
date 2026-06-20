namespace EasyBiz
{
    partial class StockReport
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
            dateFrom = new DateTimePicker();
            dateTo = new DateTimePicker();
            label2 = new Label();
            gridStock = new DataGridView();
            csNo = new DataGridViewTextBoxColumn();
            csId = new DataGridViewTextBoxColumn();
            csProduct = new DataGridViewTextBoxColumn();
            csUnit = new DataGridViewTextBoxColumn();
            csQty = new DataGridViewTextBoxColumn();
            csWeight = new DataGridViewTextBoxColumn();
            csWeightUnit = new DataGridViewTextBoxColumn();
            csMinQty = new DataGridViewTextBoxColumn();
            csSaleRate = new DataGridViewTextBoxColumn();
            csPurRate = new DataGridViewTextBoxColumn();
            csValue = new DataGridViewTextBoxColumn();
            comboProductFilter = new ComboBox();
            label3 = new Label();
            gridMovements = new DataGridView();
            smNo = new DataGridViewTextBoxColumn();
            smDate = new DataGridViewTextBoxColumn();
            smType = new DataGridViewTextBoxColumn();
            smVoucher = new DataGridViewTextBoxColumn();
            smProduct = new DataGridViewTextBoxColumn();
            smQtyIn = new DataGridViewTextBoxColumn();
            smQtyOut = new DataGridViewTextBoxColumn();
            smWtIn = new DataGridViewTextBoxColumn();
            smWtOut = new DataGridViewTextBoxColumn();
            smRate = new DataGridViewTextBoxColumn();
            smAmount = new DataGridViewTextBoxColumn();
            smBalQty = new DataGridViewTextBoxColumn();
            smBalWt = new DataGridViewTextBoxColumn();
            BtnLoadMovements = new CustomButton();
            BtnRefreshStock = new CustomButton();
            BtnClose = new CustomButton();
            label4 = new Label();
            label5 = new Label();
            BtnExportMovements = new CustomButton();
            BtnExportSummary = new CustomButton();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)gridStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridMovements).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(29, 45);
            label1.Name = "label1";
            label1.Size = new Size(58, 28);
            label1.TabIndex = 0;
            label1.Text = "From";
            // 
            // dateFrom
            // 
            dateFrom.Font = new Font("Segoe UI", 12F);
            dateFrom.Format = DateTimePickerFormat.Short;
            dateFrom.Location = new Point(93, 45);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(185, 34);
            dateFrom.TabIndex = 1;
            // 
            // dateTo
            // 
            dateTo.Font = new Font("Segoe UI", 12F);
            dateTo.Format = DateTimePickerFormat.Short;
            dateTo.Location = new Point(325, 46);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(185, 34);
            dateTo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(287, 46);
            label2.Name = "label2";
            label2.Size = new Size(32, 28);
            label2.TabIndex = 2;
            label2.Text = "To";
            // 
            // gridStock
            // 
            gridStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridStock.Columns.AddRange(new DataGridViewColumn[] { csNo, csId, csProduct, csUnit, csQty, csWeight, csWeightUnit, csMinQty, csSaleRate, csPurRate, csValue });
            gridStock.Location = new Point(64, 53);
            gridStock.Name = "gridStock";
            gridStock.RowHeadersWidth = 51;
            gridStock.Size = new Size(1432, 330);
            gridStock.TabIndex = 4;
            // 
            // csNo
            // 
            csNo.HeaderText = "Sr#";
            csNo.MinimumWidth = 6;
            csNo.Name = "csNo";
            csNo.Width = 125;
            // 
            // csId
            // 
            csId.HeaderText = "Id";
            csId.MinimumWidth = 6;
            csId.Name = "csId";
            csId.Width = 125;
            // 
            // csProduct
            // 
            csProduct.HeaderText = "Product";
            csProduct.MinimumWidth = 6;
            csProduct.Name = "csProduct";
            csProduct.Width = 125;
            // 
            // csUnit
            // 
            csUnit.HeaderText = "Unit";
            csUnit.MinimumWidth = 6;
            csUnit.Name = "csUnit";
            csUnit.Width = 125;
            // 
            // csQty
            // 
            csQty.HeaderText = "Qty";
            csQty.MinimumWidth = 6;
            csQty.Name = "csQty";
            csQty.Width = 125;
            // 
            // csWeight
            // 
            csWeight.HeaderText = "Weight";
            csWeight.MinimumWidth = 6;
            csWeight.Name = "csWeight";
            csWeight.Width = 125;
            // 
            // csWeightUnit
            // 
            csWeightUnit.HeaderText = "Weight_Unit";
            csWeightUnit.MinimumWidth = 6;
            csWeightUnit.Name = "csWeightUnit";
            csWeightUnit.Width = 125;
            // 
            // csMinQty
            // 
            csMinQty.HeaderText = "Min_Qty";
            csMinQty.MinimumWidth = 6;
            csMinQty.Name = "csMinQty";
            csMinQty.Width = 125;
            // 
            // csSaleRate
            // 
            csSaleRate.HeaderText = "Sale_Rate";
            csSaleRate.MinimumWidth = 6;
            csSaleRate.Name = "csSaleRate";
            csSaleRate.Width = 125;
            // 
            // csPurRate
            // 
            csPurRate.HeaderText = "Pur_Rate";
            csPurRate.MinimumWidth = 6;
            csPurRate.Name = "csPurRate";
            csPurRate.Width = 125;
            // 
            // csValue
            // 
            csValue.HeaderText = "Value";
            csValue.MinimumWidth = 6;
            csValue.Name = "csValue";
            csValue.Width = 125;
            // 
            // comboProductFilter
            // 
            comboProductFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProductFilter.FormattingEnabled = true;
            comboProductFilter.Location = new Point(668, 45);
            comboProductFilter.Name = "comboProductFilter";
            comboProductFilter.Size = new Size(310, 36);
            comboProductFilter.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(577, 48);
            label3.Name = "label3";
            label3.Size = new Size(85, 28);
            label3.TabIndex = 6;
            label3.Text = "Product:";
            // 
            // gridMovements
            // 
            gridMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMovements.Columns.AddRange(new DataGridViewColumn[] { smNo, smDate, smType, smVoucher, smProduct, smQtyIn, smQtyOut, smWtIn, smWtOut, smRate, smAmount, smBalQty, smBalWt });
            gridMovements.Location = new Point(64, 71);
            gridMovements.Name = "gridMovements";
            gridMovements.RowHeadersWidth = 51;
            gridMovements.Size = new Size(1688, 381);
            gridMovements.TabIndex = 7;
            // 
            // smNo
            // 
            smNo.HeaderText = "Sr#";
            smNo.MinimumWidth = 6;
            smNo.Name = "smNo";
            smNo.Width = 125;
            // 
            // smDate
            // 
            smDate.HeaderText = "Date";
            smDate.MinimumWidth = 6;
            smDate.Name = "smDate";
            smDate.Width = 125;
            // 
            // smType
            // 
            smType.HeaderText = "Type";
            smType.MinimumWidth = 6;
            smType.Name = "smType";
            smType.Width = 125;
            // 
            // smVoucher
            // 
            smVoucher.HeaderText = "Voucher";
            smVoucher.MinimumWidth = 6;
            smVoucher.Name = "smVoucher";
            smVoucher.Width = 125;
            // 
            // smProduct
            // 
            smProduct.HeaderText = "Product";
            smProduct.MinimumWidth = 6;
            smProduct.Name = "smProduct";
            smProduct.Width = 125;
            // 
            // smQtyIn
            // 
            smQtyIn.HeaderText = "Qty_In";
            smQtyIn.MinimumWidth = 6;
            smQtyIn.Name = "smQtyIn";
            smQtyIn.Width = 125;
            // 
            // smQtyOut
            // 
            smQtyOut.HeaderText = "Qty_Out";
            smQtyOut.MinimumWidth = 6;
            smQtyOut.Name = "smQtyOut";
            smQtyOut.Width = 125;
            // 
            // smWtIn
            // 
            smWtIn.HeaderText = "Weight_In";
            smWtIn.MinimumWidth = 6;
            smWtIn.Name = "smWtIn";
            smWtIn.Width = 125;
            // 
            // smWtOut
            // 
            smWtOut.HeaderText = "Weight_Out";
            smWtOut.MinimumWidth = 6;
            smWtOut.Name = "smWtOut";
            smWtOut.Width = 125;
            // 
            // smRate
            // 
            smRate.HeaderText = "Rate";
            smRate.MinimumWidth = 6;
            smRate.Name = "smRate";
            smRate.Width = 125;
            // 
            // smAmount
            // 
            smAmount.HeaderText = "Amount";
            smAmount.MinimumWidth = 6;
            smAmount.Name = "smAmount";
            smAmount.Width = 125;
            // 
            // smBalQty
            // 
            smBalQty.HeaderText = "Bal_Qty";
            smBalQty.MinimumWidth = 6;
            smBalQty.Name = "smBalQty";
            smBalQty.Width = 125;
            // 
            // smBalWt
            // 
            smBalWt.HeaderText = "Bal_Weight";
            smBalWt.MinimumWidth = 6;
            smBalWt.Name = "smBalWt";
            smBalWt.Width = 125;
            // 
            // BtnLoadMovements
            // 
            BtnLoadMovements.BackColor = Color.FromArgb(52, 152, 219);
            BtnLoadMovements.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnLoadMovements.BorderColor = Color.Transparent;
            BtnLoadMovements.BorderRadius = 2;
            BtnLoadMovements.BorderSize = 0;
            BtnLoadMovements.FlatAppearance.BorderSize = 0;
            BtnLoadMovements.FlatStyle = FlatStyle.Flat;
            BtnLoadMovements.Font = new Font("Segoe UI", 10.2F);
            BtnLoadMovements.ForeColor = Color.White;
            BtnLoadMovements.Location = new Point(990, 45);
            BtnLoadMovements.Name = "BtnLoadMovements";
            BtnLoadMovements.Size = new Size(136, 36);
            BtnLoadMovements.TabIndex = 8;
            BtnLoadMovements.Text = "Load";
            BtnLoadMovements.TextColor = Color.White;
            BtnLoadMovements.UseVisualStyleBackColor = false;
            BtnLoadMovements.Click += BtnLoadMovements_Click;
            // 
            // BtnRefreshStock
            // 
            BtnRefreshStock.BackColor = Color.FromArgb(0, 192, 0);
            BtnRefreshStock.BackgroundColor = Color.FromArgb(0, 192, 0);
            BtnRefreshStock.BorderColor = Color.Transparent;
            BtnRefreshStock.BorderRadius = 2;
            BtnRefreshStock.BorderSize = 0;
            BtnRefreshStock.FlatAppearance.BorderSize = 0;
            BtnRefreshStock.FlatStyle = FlatStyle.Flat;
            BtnRefreshStock.Font = new Font("Segoe UI", 10.2F);
            BtnRefreshStock.ForeColor = Color.White;
            BtnRefreshStock.Location = new Point(1132, 45);
            BtnRefreshStock.Name = "BtnRefreshStock";
            BtnRefreshStock.Size = new Size(136, 36);
            BtnRefreshStock.TabIndex = 9;
            BtnRefreshStock.Text = "Refresh";
            BtnRefreshStock.TextColor = Color.White;
            BtnRefreshStock.UseVisualStyleBackColor = false;
            BtnRefreshStock.Click += BtnRefreshStock_Click;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Right;
            BtnClose.BackColor = Color.FromArgb(192, 0, 0);
            BtnClose.BackgroundColor = Color.FromArgb(192, 0, 0);
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 2;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 12F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(1513, 273);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(239, 48);
            BtnClose.TabIndex = 10;
            BtnClose.Text = "Close";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(668, 6);
            label4.Name = "label4";
            label4.Size = new Size(204, 46);
            label4.TabIndex = 11;
            label4.Text = "--- Stock ---";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(707, 22);
            label5.Name = "label5";
            label5.Size = new Size(299, 46);
            label5.TabIndex = 12;
            label5.Text = "--- Movements ---";
            // 
            // BtnExportMovements
            // 
            BtnExportMovements.Anchor = AnchorStyles.Right;
            BtnExportMovements.BackColor = Color.FromArgb(192, 0, 192);
            BtnExportMovements.BackgroundColor = Color.FromArgb(192, 0, 192);
            BtnExportMovements.BorderColor = Color.Transparent;
            BtnExportMovements.BorderRadius = 2;
            BtnExportMovements.BorderSize = 0;
            BtnExportMovements.FlatAppearance.BorderSize = 0;
            BtnExportMovements.FlatStyle = FlatStyle.Flat;
            BtnExportMovements.Font = new Font("Segoe UI", 12F);
            BtnExportMovements.ForeColor = Color.White;
            BtnExportMovements.Location = new Point(1513, 147);
            BtnExportMovements.Name = "BtnExportMovements";
            BtnExportMovements.Size = new Size(239, 48);
            BtnExportMovements.TabIndex = 13;
            BtnExportMovements.Text = "Export Movements";
            BtnExportMovements.TextColor = Color.White;
            BtnExportMovements.UseVisualStyleBackColor = false;
            BtnExportMovements.Click += BtnExportMovements_Click;
            // 
            // BtnExportSummary
            // 
            BtnExportSummary.Anchor = AnchorStyles.Right;
            BtnExportSummary.BackColor = Color.FromArgb(128, 128, 255);
            BtnExportSummary.BackgroundColor = Color.FromArgb(128, 128, 255);
            BtnExportSummary.BorderColor = Color.Transparent;
            BtnExportSummary.BorderRadius = 2;
            BtnExportSummary.BorderSize = 0;
            BtnExportSummary.FlatAppearance.BorderSize = 0;
            BtnExportSummary.FlatStyle = FlatStyle.Flat;
            BtnExportSummary.Font = new Font("Segoe UI", 12F);
            BtnExportSummary.ForeColor = Color.White;
            BtnExportSummary.Location = new Point(1513, 210);
            BtnExportSummary.Name = "BtnExportSummary";
            BtnExportSummary.Size = new Size(239, 48);
            BtnExportSummary.TabIndex = 14;
            BtnExportSummary.Text = "Export Summary";
            BtnExportSummary.TextColor = Color.White;
            BtnExportSummary.UseVisualStyleBackColor = false;
            BtnExportSummary.Click += BtnExportSummary_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateFrom);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboProductFilter);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(BtnRefreshStock);
            panel1.Controls.Add(BtnLoadMovements);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1783, 109);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnClose);
            panel2.Controls.Add(BtnExportMovements);
            panel2.Controls.Add(gridStock);
            panel2.Controls.Add(BtnExportSummary);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 109);
            panel2.Name = "panel2";
            panel2.Size = new Size(1783, 399);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.Controls.Add(gridMovements);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 508);
            panel3.Name = "panel3";
            panel3.Size = new Size(1783, 482);
            panel3.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 999);
            panel4.Name = "panel4";
            panel4.Size = new Size(1783, 56);
            panel4.TabIndex = 18;
            // 
            // StockReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1783, 1055);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StockReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Stock Report";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)gridStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridMovements).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DateTimePicker dateFrom;
        private DateTimePicker dateTo;
        private Label label2;
        private DataGridView gridStock;
        private ComboBox comboProductFilter;
        private Label label3;
        private DataGridView gridMovements;
        private CustomButton BtnLoadMovements;
        private CustomButton BtnRefreshStock;
        private CustomButton BtnClose;
        private DataGridViewTextBoxColumn csNo;
        private DataGridViewTextBoxColumn csId;
        private DataGridViewTextBoxColumn csProduct;
        private DataGridViewTextBoxColumn csUnit;
        private DataGridViewTextBoxColumn csQty;
        private DataGridViewTextBoxColumn csWeight;
        private DataGridViewTextBoxColumn csWeightUnit;
        private DataGridViewTextBoxColumn csMinQty;
        private DataGridViewTextBoxColumn csSaleRate;
        private DataGridViewTextBoxColumn csPurRate;
        private DataGridViewTextBoxColumn csValue;
        private DataGridViewTextBoxColumn smNo;
        private DataGridViewTextBoxColumn smDate;
        private DataGridViewTextBoxColumn smType;
        private DataGridViewTextBoxColumn smVoucher;
        private DataGridViewTextBoxColumn smProduct;
        private DataGridViewTextBoxColumn smQtyIn;
        private DataGridViewTextBoxColumn smQtyOut;
        private DataGridViewTextBoxColumn smWtIn;
        private DataGridViewTextBoxColumn smWtOut;
        private DataGridViewTextBoxColumn smRate;
        private DataGridViewTextBoxColumn smAmount;
        private DataGridViewTextBoxColumn smBalQty;
        private DataGridViewTextBoxColumn smBalWt;
        private Label label4;
        private Label label5;
        private CustomButton BtnExportMovements;
        private CustomButton BtnExportSummary;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}