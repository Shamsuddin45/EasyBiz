namespace EasyBiz
{
    partial class BankReceipt
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblHeader = new Label();
            comboBankId = new ComboBox();
            comboBankName = new ComboBox();
            label_bankId = new Label();
            label_bankName = new Label();
            label_bankBal = new Label();
            txtBankBalance = new TextBox();
            comboPartyId = new ComboBox();
            comboPartyName = new ComboBox();
            label_partyId = new Label();
            label_partyName = new Label();
            label_preBal = new Label();
            txtPreBalance = new TextBox();
            label_date = new Label();
            dateInvoice = new DateTimePicker();
            label_voucher = new Label();
            txtVoucherNo = new TextBox();
            label_cheque = new Label();
            txtChequeNo = new TextBox();
            label_desc = new Label();
            txtDescription = new TextBox();
            label_amount = new Label();
            txtAmount = new TextBox();
            gridLines = new DataGridView();
            colSno = new DataGridViewTextBoxColumn();
            colPartyId = new DataGridViewTextBoxColumn();
            colPartyName = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colChequeNo = new DataGridViewTextBoxColumn();
            label_total = new Label();
            txtTotal = new TextBox();
            BtnDeleteRow = new CustomButton();
            BtnSave = new CustomButton();
            BtnClose = new CustomButton();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLines).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SeaGreen;
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(3, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1201, 49);
            panelHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(464, 6);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(294, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Bank Receipt Voucher";
            // 
            // comboBankId
            // 
            comboBankId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBankId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBankId.Font = new Font("Segoe UI", 11F);
            comboBankId.Location = new Point(90, 15);
            comboBankId.Name = "comboBankId";
            comboBankId.Size = new Size(160, 33);
            comboBankId.TabIndex = 1;
            comboBankId.SelectedIndexChanged += comboBankId_SelectedIndexChanged;
            // 
            // comboBankName
            // 
            comboBankName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBankName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBankName.Font = new Font("Segoe UI", 11F);
            comboBankName.Location = new Point(319, 15);
            comboBankName.Name = "comboBankName";
            comboBankName.Size = new Size(316, 33);
            comboBankName.TabIndex = 2;
            comboBankName.SelectedIndexChanged += comboBankName_SelectedIndexChanged;
            // 
            // label_bankId
            // 
            label_bankId.AutoSize = true;
            label_bankId.Font = new Font("Segoe UI", 11F);
            label_bankId.Location = new Point(13, 18);
            label_bankId.Name = "label_bankId";
            label_bankId.Size = new Size(76, 25);
            label_bankId.TabIndex = 3;
            label_bankId.Text = "Bank ID";
            // 
            // label_bankName
            // 
            label_bankName.AutoSize = true;
            label_bankName.Font = new Font("Segoe UI", 11F);
            label_bankName.Location = new Point(256, 18);
            label_bankName.Name = "label_bankName";
            label_bankName.Size = new Size(57, 25);
            label_bankName.TabIndex = 4;
            label_bankName.Text = "Bank:";
            // 
            // label_bankBal
            // 
            label_bankBal.AutoSize = true;
            label_bankBal.Font = new Font("Segoe UI", 11F);
            label_bankBal.Location = new Point(645, 18);
            label_bankBal.Name = "label_bankBal";
            label_bankBal.Size = new Size(84, 25);
            label_bankBal.TabIndex = 5;
            label_bankBal.Text = "Bank Bal";
            // 
            // txtBankBalance
            // 
            txtBankBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtBankBalance.Location = new Point(725, 15);
            txtBankBalance.Name = "txtBankBalance";
            txtBankBalance.ReadOnly = true;
            txtBankBalance.Size = new Size(200, 32);
            txtBankBalance.TabIndex = 6;
            // 
            // comboPartyId
            // 
            comboPartyId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPartyId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPartyId.Font = new Font("Segoe UI", 11F);
            comboPartyId.Location = new Point(90, 60);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new Size(160, 33);
            comboPartyId.TabIndex = 7;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // comboPartyName
            // 
            comboPartyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPartyName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPartyName.Font = new Font("Segoe UI", 11F);
            comboPartyName.Location = new Point(319, 63);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(316, 33);
            comboPartyName.TabIndex = 8;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // label_partyId
            // 
            label_partyId.AutoSize = true;
            label_partyId.Font = new Font("Segoe UI", 11F);
            label_partyId.Location = new Point(13, 63);
            label_partyId.Name = "label_partyId";
            label_partyId.Size = new Size(77, 25);
            label_partyId.TabIndex = 9;
            label_partyId.Text = "Party ID";
            // 
            // label_partyName
            // 
            label_partyName.AutoSize = true;
            label_partyName.Font = new Font("Segoe UI", 11F);
            label_partyName.Location = new Point(255, 66);
            label_partyName.Name = "label_partyName";
            label_partyName.Size = new Size(58, 25);
            label_partyName.TabIndex = 10;
            label_partyName.Text = "Party:";
            // 
            // label_preBal
            // 
            label_preBal.AutoSize = true;
            label_preBal.Font = new Font("Segoe UI", 11F);
            label_preBal.Location = new Point(655, 66);
            label_preBal.Name = "label_preBal";
            label_preBal.Size = new Size(71, 25);
            label_preBal.TabIndex = 11;
            label_preBal.Text = "Pre Bal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtPreBalance.Location = new Point(725, 63);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.ReadOnly = true;
            txtPreBalance.Size = new Size(200, 32);
            txtPreBalance.TabIndex = 12;
            // 
            // label_date
            // 
            label_date.AutoSize = true;
            label_date.Font = new Font("Segoe UI", 11F);
            label_date.Location = new Point(955, 22);
            label_date.Name = "label_date";
            label_date.Size = new Size(51, 25);
            label_date.TabIndex = 13;
            label_date.Text = "Date";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new Font("Segoe UI", 11F);
            dateInvoice.Format = DateTimePickerFormat.Short;
            dateInvoice.Location = new Point(1012, 18);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new Size(178, 32);
            dateInvoice.TabIndex = 14;
            // 
            // label_voucher
            // 
            label_voucher.AutoSize = true;
            label_voucher.Font = new Font("Segoe UI", 11F);
            label_voucher.Location = new Point(937, 123);
            label_voucher.Name = "label_voucher";
            label_voucher.Size = new Size(98, 25);
            label_voucher.TabIndex = 15;
            label_voucher.Text = "Voucher #";
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtVoucherNo.ForeColor = Color.ForestGreen;
            txtVoucherNo.Location = new Point(1041, 116);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new Size(148, 32);
            txtVoucherNo.TabIndex = 16;
            txtVoucherNo.TextAlign = HorizontalAlignment.Center;
            // 
            // label_cheque
            // 
            label_cheque.AutoSize = true;
            label_cheque.Font = new Font("Segoe UI", 11F);
            label_cheque.Location = new Point(11, 116);
            label_cheque.Name = "label_cheque";
            label_cheque.Size = new Size(72, 25);
            label_cheque.TabIndex = 17;
            label_cheque.Text = "Cheq #";
            // 
            // txtChequeNo
            // 
            txtChequeNo.Font = new Font("Segoe UI", 11F);
            txtChequeNo.Location = new Point(89, 112);
            txtChequeNo.Name = "txtChequeNo";
            txtChequeNo.Size = new Size(160, 32);
            txtChequeNo.TabIndex = 18;
            // 
            // label_desc
            // 
            label_desc.AutoSize = true;
            label_desc.Font = new Font("Segoe UI", 11F);
            label_desc.Location = new Point(270, 119);
            label_desc.Name = "label_desc";
            label_desc.Size = new Size(108, 25);
            label_desc.TabIndex = 19;
            label_desc.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(384, 116);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(480, 32);
            txtDescription.TabIndex = 20;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // label_amount
            // 
            label_amount.AutoSize = true;
            label_amount.Font = new Font("Segoe UI", 11F);
            label_amount.Location = new Point(299, 172);
            label_amount.Name = "label_amount";
            label_amount.Size = new Size(79, 25);
            label_amount.TabIndex = 21;
            label_amount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtAmount.ForeColor = Color.ForestGreen;
            txtAmount.Location = new Point(384, 169);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(203, 32);
            txtAmount.TabIndex = 22;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // gridLines
            // 
            gridLines.AllowUserToAddRows = false;
            gridLines.AllowUserToDeleteRows = false;
            gridLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            gridLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLines.BackgroundColor = Color.White;
            gridLines.BorderStyle = BorderStyle.None;
            gridLines.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridLines.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            gridLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridLines.ColumnHeadersHeight = 42;
            gridLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridLines.Columns.AddRange(new DataGridViewColumn[] { colSno, colPartyId, colPartyName, colDesc, colAmount, colChequeNo });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridLines.DefaultCellStyle = dataGridViewCellStyle3;
            gridLines.EnableHeadersVisualStyles = false;
            gridLines.GridColor = Color.LightGray;
            gridLines.Location = new Point(0, 3);
            gridLines.MultiSelect = false;
            gridLines.Name = "gridLines";
            gridLines.RowHeadersVisible = false;
            gridLines.RowHeadersWidth = 51;
            gridLines.RowTemplate.Height = 38;
            gridLines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLines.Size = new Size(1201, 292);
            gridLines.TabIndex = 23;
            // 
            // colSno
            // 
            colSno.HeaderText = "#";
            colSno.MinimumWidth = 6;
            colSno.Name = "colSno";
            colSno.ReadOnly = true;
            // 
            // colPartyId
            // 
            colPartyId.HeaderText = "Party ID";
            colPartyId.MinimumWidth = 6;
            colPartyId.Name = "colPartyId";
            colPartyId.ReadOnly = true;
            colPartyId.Visible = false;
            // 
            // colPartyName
            // 
            colPartyName.HeaderText = "Party / Payer";
            colPartyName.MinimumWidth = 6;
            colPartyName.Name = "colPartyName";
            colPartyName.ReadOnly = true;
            // 
            // colDesc
            // 
            colDesc.HeaderText = "Description";
            colDesc.MinimumWidth = 6;
            colDesc.Name = "colDesc";
            // 
            // colAmount
            // 
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            // 
            // colChequeNo
            // 
            colChequeNo.HeaderText = "Cheque #";
            colChequeNo.MinimumWidth = 6;
            colChequeNo.Name = "colChequeNo";
            // 
            // label_total
            // 
            label_total.AutoSize = true;
            label_total.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_total.Location = new Point(917, 307);
            label_total.Name = "label_total";
            label_total.Size = new Size(64, 28);
            label_total.TabIndex = 24;
            label_total.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.ForeColor = Color.ForestGreen;
            txtTotal.Location = new Point(987, 301);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(210, 34);
            txtTotal.TabIndex = 25;
            txtTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnDeleteRow
            // 
            BtnDeleteRow.BackColor = Color.Red;
            BtnDeleteRow.BackgroundColor = Color.Red;
            BtnDeleteRow.BorderColor = Color.Transparent;
            BtnDeleteRow.BorderRadius = 6;
            BtnDeleteRow.BorderSize = 0;
            BtnDeleteRow.FlatAppearance.BorderSize = 0;
            BtnDeleteRow.FlatStyle = FlatStyle.Flat;
            BtnDeleteRow.ForeColor = Color.White;
            BtnDeleteRow.Location = new Point(9, 301);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(130, 34);
            BtnDeleteRow.TabIndex = 26;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.White;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.SeaGreen;
            BtnSave.BackgroundColor = Color.SeaGreen;
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 8;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 11F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(168, 3);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(225, 50);
            BtnSave.TabIndex = 27;
            BtnSave.Text = "Post Receipt (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.FromArgb(192, 64, 0);
            BtnClose.BackgroundColor = Color.FromArgb(192, 64, 0);
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 8;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 11F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(5, 3);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(157, 50);
            BtnClose.TabIndex = 28;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(BtnSave);
            panel1.Controls.Add(BtnClose);
            panel1.Location = new Point(807, 621);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 57);
            panel1.TabIndex = 29;
            // 
            // panel2
            // 
            panel2.Controls.Add(gridLines);
            panel2.Controls.Add(BtnDeleteRow);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(label_total);
            panel2.Location = new Point(3, 269);
            panel2.Name = "panel2";
            panel2.Size = new Size(1201, 346);
            panel2.TabIndex = 30;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtAmount);
            panel3.Controls.Add(label_amount);
            panel3.Controls.Add(txtVoucherNo);
            panel3.Controls.Add(txtDescription);
            panel3.Controls.Add(comboBankId);
            panel3.Controls.Add(label_desc);
            panel3.Controls.Add(comboBankName);
            panel3.Controls.Add(txtChequeNo);
            panel3.Controls.Add(label_bankId);
            panel3.Controls.Add(label_cheque);
            panel3.Controls.Add(label_bankName);
            panel3.Controls.Add(label_voucher);
            panel3.Controls.Add(label_bankBal);
            panel3.Controls.Add(txtPreBalance);
            panel3.Controls.Add(txtBankBalance);
            panel3.Controls.Add(dateInvoice);
            panel3.Controls.Add(comboPartyId);
            panel3.Controls.Add(label_date);
            panel3.Controls.Add(comboPartyName);
            panel3.Controls.Add(label_preBal);
            panel3.Controls.Add(label_partyId);
            panel3.Controls.Add(label_partyName);
            panel3.Location = new Point(3, 58);
            panel3.Name = "panel3";
            panel3.Size = new Size(1200, 204);
            panel3.TabIndex = 31;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 3);
            tableLayoutPanel1.Controls.Add(panelHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.072289F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.7132454F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.2372627F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.898108F));
            tableLayoutPanel1.Size = new Size(1207, 687);
            tableLayoutPanel1.TabIndex = 32;
            // 
            // BankReceipt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 687);
            Controls.Add(tableLayoutPanel1);
            Name = "BankReceipt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bank Receipt Voucher";
            FormClosing += BankReceipt_FormClosing;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLines).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblHeader;
        private ComboBox comboBankId, comboBankName;
        private Label label_bankId, label_bankName, label_bankBal;
        private TextBox txtBankBalance;
        private ComboBox comboPartyId, comboPartyName;
        private Label label_partyId, label_partyName, label_preBal;
        private TextBox txtPreBalance;
        private Label label_date, label_voucher;
        private DateTimePicker dateInvoice;
        private TextBox txtVoucherNo;
        private Label label_cheque;
        private TextBox txtChequeNo;
        private Label label_desc, label_amount;
        private TextBox txtDescription, txtAmount;
        private DataGridView gridLines;
        private Label label_total;
        private TextBox txtTotal;
        private CustomButton BtnDeleteRow, BtnSave, BtnClose;
        private DataGridViewTextBoxColumn colSno;
        private DataGridViewTextBoxColumn colPartyId;
        private DataGridViewTextBoxColumn colPartyName;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colChequeNo;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
    }
}