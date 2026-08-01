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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            label7 = new Label();
            panel2 = new Panel();
            label8 = new Label();
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
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(140, 22);
            label1.Name = "label1";
            label1.Size = new Size(49, 23);
            label1.TabIndex = 0;
            label1.Text = "From";
            // 
            // dateFrom
            // 
            dateFrom.Font = new Font("Segoe UI", 10.8F);
            dateFrom.Format = DateTimePickerFormat.Short;
            dateFrom.Location = new Point(195, 18);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(140, 31);
            dateFrom.TabIndex = 2;
            // 
            // dateTo
            // 
            dateTo.Font = new Font("Segoe UI", 10.8F);
            dateTo.Format = DateTimePickerFormat.Short;
            dateTo.Location = new Point(390, 18);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(140, 31);
            dateTo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(355, 22);
            label2.Name = "label2";
            label2.Size = new Size(27, 23);
            label2.TabIndex = 2;
            label2.Text = "To";
            // 
            // gridStock
            // 
            gridStock.AllowUserToAddRows = false;
            gridStock.BackgroundColor = Color.White;
            gridStock.BorderStyle = BorderStyle.None;
            gridStock.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            gridStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridStock.ColumnHeadersHeight = 40;
            gridStock.Columns.AddRange(new DataGridViewColumn[] { csNo, csId, csProduct, csUnit, csQty, csWeight, csWeightUnit, csMinQty, csSaleRate, csPurRate, csValue });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridStock.DefaultCellStyle = dataGridViewCellStyle2;
            gridStock.Dock = DockStyle.Fill;
            gridStock.EnableHeadersVisualStyles = false;
            gridStock.Location = new Point(15, 35);
            gridStock.Name = "gridStock";
            gridStock.RowHeadersVisible = false;
            gridStock.RowHeadersWidth = 51;
            gridStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridStock.Size = new Size(1894, 350);
            gridStock.TabIndex = 4;
            // 
            // csNo
            // 
            csNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            csNo.HeaderText = "Sr#";
            csNo.MinimumWidth = 6;
            csNo.Name = "csNo";
            csNo.Width = 62;
            // 
            // csId
            // 
            csId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            csId.HeaderText = "Id";
            csId.MinimumWidth = 6;
            csId.Name = "csId";
            csId.Width = 52;
            // 
            // csProduct
            // 
            csProduct.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            csProduct.HeaderText = "Product";
            csProduct.MinimumWidth = 6;
            csProduct.Name = "csProduct";
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
            comboProductFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboProductFilter.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboProductFilter.Font = new Font("Segoe UI", 10.8F);
            comboProductFilter.FormattingEnabled = true;
            comboProductFilter.Location = new Point(325, 71);
            comboProductFilter.Name = "comboProductFilter";
            comboProductFilter.Size = new Size(323, 33);
            comboProductFilter.TabIndex = 6;
            comboProductFilter.SelectedIndexChanged += comboProductFilter_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(245, 75);
            label3.Name = "label3";
            label3.Size = new Size(74, 23);
            label3.TabIndex = 6;
            label3.Text = "Product:";
            // 
            // gridMovements
            // 
            gridMovements.AllowUserToAddRows = false;
            gridMovements.BackgroundColor = Color.White;
            gridMovements.BorderStyle = BorderStyle.None;
            gridMovements.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridMovements.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridMovements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridMovements.ColumnHeadersHeight = 40;
            gridMovements.Columns.AddRange(new DataGridViewColumn[] { smNo, smDate, smVoucher, smProduct, smQtyIn, smQtyOut, smWtIn, smWtOut, smRate, smAmount, smBalQty, smBalWt });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridMovements.DefaultCellStyle = dataGridViewCellStyle3;
            gridMovements.Dock = DockStyle.Fill;
            gridMovements.EnableHeadersVisualStyles = false;
            gridMovements.Location = new Point(15, 45);
            gridMovements.Name = "gridMovements";
            gridMovements.RowHeadersVisible = false;
            gridMovements.RowHeadersWidth = 51;
            gridMovements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMovements.Size = new Size(1894, 403);
            gridMovements.TabIndex = 7;
            // 
            // smNo
            // 
            smNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            smNo.HeaderText = "Sr#";
            smNo.MinimumWidth = 6;
            smNo.Name = "smNo";
            smNo.Width = 62;
            // 
            // smDate
            // 
            smDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            smDate.HeaderText = "Date";
            smDate.MinimumWidth = 6;
            smDate.Name = "smDate";
            smDate.Width = 73;
            // 
            // smVoucher
            // 
            smVoucher.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            smVoucher.HeaderText = "Voucher";
            smVoucher.MinimumWidth = 6;
            smVoucher.Name = "smVoucher";
            // 
            // smProduct
            // 
            smProduct.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            smProduct.HeaderText = "Product";
            smProduct.MinimumWidth = 6;
            smProduct.Name = "smProduct";
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
            BtnLoadMovements.BackColor = Color.FromArgb(52, 152, 219);
            BtnLoadMovements.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnLoadMovements.BorderColor = Color.Transparent;
            BtnLoadMovements.BorderRadius = 4;
            BtnLoadMovements.BorderSize = 0;
            BtnLoadMovements.FlatStyle = FlatStyle.Flat;
            BtnLoadMovements.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnLoadMovements.ForeColor = Color.White;
            BtnLoadMovements.Location = new Point(550, 16);
            BtnLoadMovements.Name = "BtnLoadMovements";
            BtnLoadMovements.Size = new Size(120, 35);
            BtnLoadMovements.TabIndex = 4;
            BtnLoadMovements.Text = "Load";
            BtnLoadMovements.TextColor = Color.White;
            BtnLoadMovements.UseVisualStyleBackColor = false;
            BtnLoadMovements.Click += BtnLoadMovements_Click;
            // 
            // BtnExportMovements
            // 
            BtnExportMovements.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnExportMovements.BackColor = Color.FromArgb(46, 204, 113);
            BtnExportMovements.BackgroundColor = Color.FromArgb(46, 204, 113);
            BtnExportMovements.BorderColor = Color.Transparent;
            BtnExportMovements.BorderRadius = 4;
            BtnExportMovements.BorderSize = 0;
            BtnExportMovements.FlatStyle = FlatStyle.Flat;
            BtnExportMovements.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnExportMovements.ForeColor = Color.White;
            BtnExportMovements.Location = new Point(1635, 22);
            BtnExportMovements.Name = "BtnExportMovements";
            BtnExportMovements.Size = new Size(247, 40);
            BtnExportMovements.TabIndex = 13;
            BtnExportMovements.Text = "Export Movements [F1]";
            BtnExportMovements.TextColor = Color.White;
            BtnExportMovements.UseVisualStyleBackColor = false;
            BtnExportMovements.Click += BtnExportMovements_Click;
            // 
            // BtnExportSummary
            // 
            BtnExportSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnExportSummary.BackColor = Color.DodgerBlue;
            BtnExportSummary.BackgroundColor = Color.DodgerBlue;
            BtnExportSummary.BorderColor = Color.Transparent;
            BtnExportSummary.BorderRadius = 4;
            BtnExportSummary.BorderSize = 0;
            BtnExportSummary.FlatStyle = FlatStyle.Flat;
            BtnExportSummary.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnExportSummary.ForeColor = Color.White;
            BtnExportSummary.Location = new Point(1635, 70);
            BtnExportSummary.Name = "BtnExportSummary";
            BtnExportSummary.Size = new Size(247, 40);
            BtnExportSummary.TabIndex = 14;
            BtnExportSummary.Text = "Export Stock Summary [F2]";
            BtnExportSummary.TextColor = Color.White;
            BtnExportSummary.UseVisualStyleBackColor = false;
            BtnExportSummary.Click += BtnExportSummary_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(gridStock);
            panel1.Controls.Add(label7);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 578);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15, 0, 15, 15);
            panel1.Size = new Size(1924, 400);
            panel1.TabIndex = 15;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(44, 62, 80);
            label7.Location = new Point(15, 0);
            label7.Name = "label7";
            label7.Size = new Size(1894, 35);
            label7.TabIndex = 5;
            label7.Text = "Items Stock";
            // 
            // panel2
            // 
            panel2.Controls.Add(gridMovements);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 120);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15, 10, 15, 10);
            panel2.Size = new Size(1924, 458);
            panel2.TabIndex = 16;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(44, 62, 80);
            label8.Location = new Point(15, 10);
            label8.Name = "label8";
            label8.Size = new Size(1894, 35);
            label8.TabIndex = 8;
            label8.Text = "Movements";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
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
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1924, 120);
            panel3.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(1062, 74);
            label6.Name = "label6";
            label6.Size = new Size(80, 23);
            label6.TabIndex = 21;
            label6.Text = "Payment:";
            // 
            // comboPaymentFilter
            // 
            comboPaymentFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPaymentFilter.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPaymentFilter.Font = new Font("Segoe UI", 10.8F);
            comboPaymentFilter.FormattingEnabled = true;
            comboPaymentFilter.Location = new Point(1147, 70);
            comboPaymentFilter.Name = "comboPaymentFilter";
            comboPaymentFilter.Size = new Size(160, 33);
            comboPaymentFilter.TabIndex = 8;
            comboPaymentFilter.SelectedIndexChanged += comboPaymentFilter_SelectedIndexChanged;
            // 
            // checkAllDates
            // 
            checkAllDates.AutoSize = true;
            checkAllDates.Checked = true;
            checkAllDates.CheckState = CheckState.Checked;
            checkAllDates.Font = new Font("Segoe UI", 10.2F);
            checkAllDates.Location = new Point(25, 20);
            checkAllDates.Name = "checkAllDates";
            checkAllDates.Size = new Size(99, 27);
            checkAllDates.TabIndex = 1;
            checkAllDates.Text = "All Dates";
            checkAllDates.CheckedChanged += checkAllDates_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(25, 75);
            label5.Name = "label5";
            label5.Size = new Size(49, 23);
            label5.TabIndex = 18;
            label5.Text = "Type:";
            // 
            // comboMovementType
            // 
            comboMovementType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboMovementType.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboMovementType.Font = new Font("Segoe UI", 10.8F);
            comboMovementType.FormattingEnabled = true;
            comboMovementType.Location = new Point(80, 71);
            comboMovementType.Name = "comboMovementType";
            comboMovementType.Size = new Size(150, 33);
            comboMovementType.TabIndex = 5;
            comboMovementType.SelectedIndexChanged += comboMovementType_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(654, 75);
            label4.Name = "label4";
            label4.Size = new Size(52, 23);
            label4.TabIndex = 16;
            label4.Text = "Party:";
            // 
            // comboPartyFilter
            // 
            comboPartyFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPartyFilter.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPartyFilter.Font = new Font("Segoe UI", 10.8F);
            comboPartyFilter.FormattingEnabled = true;
            comboPartyFilter.Location = new Point(709, 71);
            comboPartyFilter.Name = "comboPartyFilter";
            comboPartyFilter.Size = new Size(347, 33);
            comboPartyFilter.TabIndex = 7;
            comboPartyFilter.SelectedIndexChanged += comboPartyFilter_SelectedIndexChanged;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(245, 246, 250);
            panelContainer.Controls.Add(panel2);
            panelContainer.Controls.Add(panel1);
            panelContainer.Controls.Add(panel3);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1924, 978);
            panelContainer.TabIndex = 15;
            // 
            // StockReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(1924, 978);
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
        private Label label7;
        private Label label8;
    }
}