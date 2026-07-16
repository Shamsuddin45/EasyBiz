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
            BtnExportMovements = new CustomButton();
            BtnExportSummary = new CustomButton();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label6 = new Label();
            comboPaymentFilter = new ComboBox();
            checkAllDates = new CheckBox();
            label5 = new Label();
            comboMovementType = new ComboBox();
            label4 = new Label();
            comboPartyFilter = new ComboBox();
            panelContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)gridStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridMovements).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(58, 67);
            label1.Name = "label1";
            label1.Size = new Size(49, 23);
            label1.TabIndex = 0;
            label1.Text = "From";
            // 
            // dateFrom
            // 
            dateFrom.Anchor = AnchorStyles.Left;
            dateFrom.Font = new Font("Segoe UI", 12F);
            dateFrom.Format = DateTimePickerFormat.Short;
            dateFrom.Location = new Point(113, 62);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(185, 34);
            dateFrom.TabIndex = 2;
            // 
            // dateTo
            // 
            dateTo.Anchor = AnchorStyles.Left;
            dateTo.Font = new Font("Segoe UI", 12F);
            dateTo.Format = DateTimePickerFormat.Short;
            dateTo.Location = new Point(337, 60);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(185, 34);
            dateTo.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(304, 67);
            label2.Name = "label2";
            label2.Size = new Size(27, 23);
            label2.TabIndex = 2;
            label2.Text = "To";
            // 
            // gridStock
            // 
            gridStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridStock.Columns.AddRange(new DataGridViewColumn[] { csNo, csId, csProduct, csUnit, csQty, csWeight, csWeightUnit, csMinQty, csSaleRate, csPurRate, csValue });
            gridStock.Dock = DockStyle.Fill;
            gridStock.Location = new Point(0, 0);
            gridStock.Name = "gridStock";
            gridStock.RowHeadersWidth = 51;
            gridStock.Size = new Size(1421, 397);
            gridStock.TabIndex = 4;
            gridStock.TabStop = false;
            // 
            // csNo
            // 
            csNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            csNo.HeaderText = "Sr#";
            csNo.MinimumWidth = 6;
            csNo.Name = "csNo";
            csNo.Width = 60;
            // 
            // csId
            // 
            csId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            csId.HeaderText = "Id";
            csId.MinimumWidth = 6;
            csId.Name = "csId";
            csId.Width = 51;
            // 
            // csProduct
            // 
            csProduct.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            csProduct.HeaderText = "Product";
            csProduct.MinimumWidth = 6;
            csProduct.Name = "csProduct";
            csProduct.Width = 89;
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
            csWeightUnit.HeaderText = "Wt-Unit";
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
            comboProductFilter.Anchor = AnchorStyles.Left;
            comboProductFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboProductFilter.FormattingEnabled = true;
            comboProductFilter.Location = new Point(248, 150);
            comboProductFilter.Name = "comboProductFilter";
            comboProductFilter.Size = new Size(310, 36);
            comboProductFilter.TabIndex = 6;
            comboProductFilter.SelectedIndexChanged += comboProductFilter_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(248, 119);
            label3.Name = "label3";
            label3.Size = new Size(74, 23);
            label3.TabIndex = 6;
            label3.Text = "Product:";
            // 
            // gridMovements
            // 
            gridMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMovements.Columns.AddRange(new DataGridViewColumn[] { smNo, smDate, smVoucher, smProduct, smQtyIn, smQtyOut, smWtIn, smWtOut, smRate, smAmount, smBalQty, smBalWt });
            gridMovements.Dock = DockStyle.Fill;
            gridMovements.Location = new Point(0, 0);
            gridMovements.Name = "gridMovements";
            gridMovements.RowHeadersWidth = 51;
            gridMovements.Size = new Size(1421, 357);
            gridMovements.TabIndex = 7;
            gridMovements.TabStop = false;
            // 
            // smNo
            // 
            smNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            smNo.HeaderText = "Sr#";
            smNo.MinimumWidth = 6;
            smNo.Name = "smNo";
            smNo.Width = 60;
            // 
            // smDate
            // 
            smDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            smDate.HeaderText = "Date";
            smDate.MinimumWidth = 6;
            smDate.Name = "smDate";
            smDate.Width = 70;
            // 
            // smVoucher
            // 
            smVoucher.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            smVoucher.HeaderText = "Voucher";
            smVoucher.MinimumWidth = 6;
            smVoucher.Name = "smVoucher";
            smVoucher.Width = 91;
            // 
            // smProduct
            // 
            smProduct.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            smProduct.HeaderText = "Product";
            smProduct.MinimumWidth = 6;
            smProduct.Name = "smProduct";
            smProduct.Width = 89;
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
            smWtIn.HeaderText = "Wt-In";
            smWtIn.MinimumWidth = 6;
            smWtIn.Name = "smWtIn";
            smWtIn.Width = 125;
            // 
            // smWtOut
            // 
            smWtOut.HeaderText = "Wt-Out";
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
            BtnLoadMovements.Anchor = AnchorStyles.Left;
            BtnLoadMovements.BackColor = Color.FromArgb(52, 152, 219);
            BtnLoadMovements.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnLoadMovements.BorderColor = Color.Transparent;
            BtnLoadMovements.BorderRadius = 2;
            BtnLoadMovements.BorderSize = 0;
            BtnLoadMovements.FlatAppearance.BorderSize = 0;
            BtnLoadMovements.FlatStyle = FlatStyle.Flat;
            BtnLoadMovements.Font = new Font("Segoe UI", 10.2F);
            BtnLoadMovements.ForeColor = Color.White;
            BtnLoadMovements.Location = new Point(528, 58);
            BtnLoadMovements.Name = "BtnLoadMovements";
            BtnLoadMovements.Size = new Size(118, 36);
            BtnLoadMovements.TabIndex = 4;
            BtnLoadMovements.Text = "Load";
            BtnLoadMovements.TextColor = Color.White;
            BtnLoadMovements.UseVisualStyleBackColor = false;
            BtnLoadMovements.Click += BtnLoadMovements_Click;
            // 
            // BtnExportMovements
            // 
            BtnExportMovements.Anchor = AnchorStyles.Left;
            BtnExportMovements.BackColor = Color.FromArgb(0, 192, 0);
            BtnExportMovements.BackgroundColor = Color.FromArgb(0, 192, 0);
            BtnExportMovements.BorderColor = Color.Transparent;
            BtnExportMovements.BorderRadius = 8;
            BtnExportMovements.BorderSize = 0;
            BtnExportMovements.FlatAppearance.BorderSize = 0;
            BtnExportMovements.FlatStyle = FlatStyle.Flat;
            BtnExportMovements.Font = new Font("Segoe UI", 10.2F);
            BtnExportMovements.ForeColor = Color.White;
            BtnExportMovements.Location = new Point(1123, 76);
            BtnExportMovements.Name = "BtnExportMovements";
            BtnExportMovements.Size = new Size(286, 52);
            BtnExportMovements.TabIndex = 13;
            BtnExportMovements.TabStop = false;
            BtnExportMovements.Text = "Export Movements [F1]";
            BtnExportMovements.TextColor = Color.White;
            BtnExportMovements.UseVisualStyleBackColor = false;
            BtnExportMovements.Click += BtnExportMovements_Click;
            // 
            // BtnExportSummary
            // 
            BtnExportSummary.Anchor = AnchorStyles.Left;
            BtnExportSummary.BackColor = Color.DodgerBlue;
            BtnExportSummary.BackgroundColor = Color.DodgerBlue;
            BtnExportSummary.BorderColor = Color.Transparent;
            BtnExportSummary.BorderRadius = 8;
            BtnExportSummary.BorderSize = 0;
            BtnExportSummary.FlatAppearance.BorderSize = 0;
            BtnExportSummary.FlatStyle = FlatStyle.Flat;
            BtnExportSummary.Font = new Font("Segoe UI", 10.2F);
            BtnExportSummary.ForeColor = Color.White;
            BtnExportSummary.Location = new Point(1123, 134);
            BtnExportSummary.Name = "BtnExportSummary";
            BtnExportSummary.Size = new Size(286, 52);
            BtnExportSummary.TabIndex = 14;
            BtnExportSummary.TabStop = false;
            BtnExportSummary.Text = "Export Stock Summary [F2]";
            BtnExportSummary.TextColor = Color.White;
            BtnExportSummary.UseVisualStyleBackColor = false;
            BtnExportSummary.Click += BtnExportSummary_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMargin = new Size(10, 10);
            panel1.Controls.Add(gridStock);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 581);
            panel1.Name = "panel1";
            panel1.Size = new Size(1421, 397);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.AutoScrollMargin = new Size(10, 10);
            panel2.Controls.Add(gridMovements);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 224);
            panel2.Name = "panel2";
            panel2.Size = new Size(1421, 357);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(comboPaymentFilter);
            panel3.Controls.Add(checkAllDates);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(comboMovementType);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(comboPartyFilter);
            panel3.Controls.Add(BtnExportMovements);
            panel3.Controls.Add(dateTo);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(BtnLoadMovements);
            panel3.Controls.Add(dateFrom);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(BtnExportSummary);
            panel3.Controls.Add(comboProductFilter);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1421, 222);
            panel3.TabIndex = 17;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(878, 119);
            label6.Name = "label6";
            label6.Size = new Size(118, 23);
            label6.TabIndex = 21;
            label6.Text = "Payment type:";
            // 
            // comboPaymentFilter
            // 
            comboPaymentFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboPaymentFilter.FormattingEnabled = true;
            comboPaymentFilter.Location = new Point(878, 150);
            comboPaymentFilter.Name = "comboPaymentFilter";
            comboPaymentFilter.Size = new Size(185, 36);
            comboPaymentFilter.TabIndex = 8;
            comboPaymentFilter.SelectedIndexChanged += comboPaymentFilter_SelectedIndexChanged;
            // 
            // checkAllDates
            // 
            checkAllDates.AutoSize = true;
            checkAllDates.Checked = true;
            checkAllDates.CheckState = CheckState.Checked;
            checkAllDates.FlatAppearance.BorderColor = Color.Red;
            checkAllDates.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkAllDates.Location = new Point(264, 12);
            checkAllDates.Name = "checkAllDates";
            checkAllDates.Size = new Size(99, 27);
            checkAllDates.TabIndex = 1;
            checkAllDates.Text = "All Dates";
            checkAllDates.UseVisualStyleBackColor = true;
            checkAllDates.CheckedChanged += checkAllDates_CheckedChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(57, 119);
            label5.Name = "label5";
            label5.Size = new Size(49, 23);
            label5.TabIndex = 18;
            label5.Text = "Type:";
            // 
            // comboMovementType
            // 
            comboMovementType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboMovementType.FormattingEnabled = true;
            comboMovementType.Location = new Point(57, 150);
            comboMovementType.Name = "comboMovementType";
            comboMovementType.Size = new Size(185, 36);
            comboMovementType.TabIndex = 5;
            comboMovementType.SelectedIndexChanged += comboMovementType_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(564, 119);
            label4.Name = "label4";
            label4.Size = new Size(52, 23);
            label4.TabIndex = 16;
            label4.Text = "Party:";
            // 
            // comboPartyFilter
            // 
            comboPartyFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboPartyFilter.FormattingEnabled = true;
            comboPartyFilter.Location = new Point(564, 150);
            comboPartyFilter.Name = "comboPartyFilter";
            comboPartyFilter.Size = new Size(308, 36);
            comboPartyFilter.TabIndex = 7;
            comboPartyFilter.SelectedIndexChanged += comboPartyFilter_SelectedIndexChanged;
            // 
            // panelContainer
            // 
            panelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContainer.AutoScroll = true;
            panelContainer.AutoScrollMargin = new Size(10, 10);
            panelContainer.Controls.Add(panel3);
            panelContainer.Controls.Add(panel2);
            panelContainer.Controls.Add(panel1);
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1421, 978);
            panelContainer.TabIndex = 15;
            // 
            // StockReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1421, 978);
            Controls.Add(panelContainer);
            Name = "StockReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Stock Report";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)gridStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridMovements).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelContainer.ResumeLayout(false);
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
        private CustomButton BtnExportMovements;
        private CustomButton BtnExportSummary;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
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
        private Panel panelContainer;
        private ComboBox comboPartyFilter;
        private Label label4;
        private Label label5;
        private ComboBox comboMovementType;
        private CheckBox checkAllDates;
        private DataGridViewTextBoxColumn smNo;
        private DataGridViewTextBoxColumn smDate;
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
        private Label label6;
        private ComboBox comboPaymentFilter;
    }
}