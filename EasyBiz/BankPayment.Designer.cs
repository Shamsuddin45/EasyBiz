namespace EasyBiz
{
    partial class BankPayment
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
            panelContainer = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLines).BeginInit();
            panelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SteelBlue;
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1209, 47);
            panelHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(449, 6);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(311, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Bank Payment Voucher";
            // 
            // comboBankId
            // 
            comboBankId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBankId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBankId.Font = new Font("Segoe UI", 11F);
            comboBankId.Location = new Point(116, 160);
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
            comboBankName.Location = new Point(340, 160);
            comboBankName.Name = "comboBankName";
            comboBankName.Size = new Size(415, 33);
            comboBankName.TabIndex = 2;
            comboBankName.SelectedIndexChanged += comboBankName_SelectedIndexChanged;
            // 
            // label_bankId
            // 
            label_bankId.AutoSize = true;
            label_bankId.Font = new Font("Segoe UI", 10.2F);
            label_bankId.Location = new Point(46, 163);
            label_bankId.Name = "label_bankId";
            label_bankId.Size = new Size(69, 23);
            label_bankId.TabIndex = 3;
            label_bankId.Text = "Bank ID";
            // 
            // label_bankName
            // 
            label_bankName.AutoSize = true;
            label_bankName.Font = new Font("Segoe UI", 10.2F);
            label_bankName.Location = new Point(283, 165);
            label_bankName.Name = "label_bankName";
            label_bankName.Size = new Size(51, 23);
            label_bankName.TabIndex = 4;
            label_bankName.Text = "Bank:";
            // 
            // label_bankBal
            // 
            label_bankBal.AutoSize = true;
            label_bankBal.Font = new Font("Segoe UI", 10.2F);
            label_bankBal.Location = new Point(778, 161);
            label_bankBal.Name = "label_bankBal";
            label_bankBal.Size = new Size(75, 23);
            label_bankBal.TabIndex = 5;
            label_bankBal.Text = "Bank Bal";
            // 
            // txtBankBalance
            // 
            txtBankBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtBankBalance.Location = new Point(859, 161);
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
            comboPartyId.Location = new Point(116, 196);
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
            comboPartyName.Location = new Point(340, 196);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(415, 33);
            comboPartyName.TabIndex = 8;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // label_partyId
            // 
            label_partyId.AutoSize = true;
            label_partyId.Font = new Font("Segoe UI", 10.2F);
            label_partyId.Location = new Point(45, 199);
            label_partyId.Name = "label_partyId";
            label_partyId.Size = new Size(70, 23);
            label_partyId.TabIndex = 9;
            label_partyId.Text = "Party ID";
            // 
            // label_partyName
            // 
            label_partyName.AutoSize = true;
            label_partyName.Font = new Font("Segoe UI", 10.2F);
            label_partyName.Location = new Point(283, 201);
            label_partyName.Name = "label_partyName";
            label_partyName.Size = new Size(52, 23);
            label_partyName.TabIndex = 10;
            label_partyName.Text = "Party:";
            // 
            // label_preBal
            // 
            label_preBal.AutoSize = true;
            label_preBal.Font = new Font("Segoe UI", 10.2F);
            label_preBal.Location = new Point(790, 202);
            label_preBal.Name = "label_preBal";
            label_preBal.Size = new Size(63, 23);
            label_preBal.TabIndex = 11;
            label_preBal.Text = "Pre Bal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtPreBalance.Location = new Point(859, 197);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.ReadOnly = true;
            txtPreBalance.Size = new Size(200, 32);
            txtPreBalance.TabIndex = 12;
            // 
            // label_date
            // 
            label_date.AutoSize = true;
            label_date.Font = new Font("Segoe UI", 10.2F);
            label_date.Location = new Point(340, 63);
            label_date.Name = "label_date";
            label_date.Size = new Size(46, 23);
            label_date.TabIndex = 13;
            label_date.Text = "Date";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new Font("Segoe UI", 11F);
            dateInvoice.Format = DateTimePickerFormat.Short;
            dateInvoice.Location = new Point(340, 89);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new Size(178, 32);
            dateInvoice.TabIndex = 14;
            // 
            // label_voucher
            // 
            label_voucher.AutoSize = true;
            label_voucher.Font = new Font("Segoe UI", 10.2F);
            label_voucher.Location = new Point(116, 63);
            label_voucher.Name = "label_voucher";
            label_voucher.Size = new Size(83, 23);
            label_voucher.TabIndex = 15;
            label_voucher.Text = "Voucher#";
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtVoucherNo.ForeColor = Color.Red;
            txtVoucherNo.Location = new Point(116, 89);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new Size(160, 32);
            txtVoucherNo.TabIndex = 16;
            txtVoucherNo.TextAlign = HorizontalAlignment.Center;
            // 
            // label_cheque
            // 
            label_cheque.AutoSize = true;
            label_cheque.Font = new Font("Segoe UI", 10.2F);
            label_cheque.Location = new Point(55, 257);
            label_cheque.Name = "label_cheque";
            label_cheque.Size = new Size(60, 23);
            label_cheque.TabIndex = 17;
            label_cheque.Text = "Cheq#";
            // 
            // txtChequeNo
            // 
            txtChequeNo.Font = new Font("Segoe UI", 11F);
            txtChequeNo.Location = new Point(116, 252);
            txtChequeNo.Name = "txtChequeNo";
            txtChequeNo.Size = new Size(160, 32);
            txtChequeNo.TabIndex = 18;
            // 
            // label_desc
            // 
            label_desc.AutoSize = true;
            label_desc.Font = new Font("Segoe UI", 10.2F);
            label_desc.Location = new Point(292, 257);
            label_desc.Name = "label_desc";
            label_desc.Size = new Size(46, 23);
            label_desc.TabIndex = 19;
            label_desc.Text = "Desc";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(340, 252);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(415, 32);
            txtDescription.TabIndex = 20;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // label_amount
            // 
            label_amount.AutoSize = true;
            label_amount.Font = new Font("Segoe UI", 10.2F);
            label_amount.Location = new Point(781, 257);
            label_amount.Name = "label_amount";
            label_amount.Size = new Size(72, 23);
            label_amount.TabIndex = 21;
            label_amount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.Red;
            txtAmount.Location = new Point(859, 249);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(200, 34);
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
            gridLines.Location = new Point(3, 312);
            gridLines.MultiSelect = false;
            gridLines.Name = "gridLines";
            gridLines.RowHeadersVisible = false;
            gridLines.RowHeadersWidth = 51;
            gridLines.RowTemplate.Height = 38;
            gridLines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLines.Size = new Size(1186, 225);
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
            colPartyName.HeaderText = "Party / Payee";
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
            label_total.Location = new Point(909, 546);
            label_total.Name = "label_total";
            label_total.Size = new Size(64, 28);
            label_total.TabIndex = 24;
            label_total.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.ForeColor = Color.Red;
            txtTotal.Location = new Point(979, 543);
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
            BtnDeleteRow.Location = new Point(12, 543);
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
            BtnSave.BackColor = Color.SteelBlue;
            BtnSave.BackgroundColor = Color.SteelBlue;
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 8;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 10.2F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(572, 595);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(205, 50);
            BtnSave.TabIndex = 27;
            BtnSave.Text = "Post Payment (Ctrl+S)";
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
            BtnClose.Font = new Font("Segoe UI", 10.2F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(432, 595);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(134, 50);
            BtnClose.TabIndex = 28;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // panelContainer
            // 
            panelContainer.AutoScroll = true;
            panelContainer.AutoScrollMargin = new Size(10, 10);
            panelContainer.Controls.Add(gridLines);
            panelContainer.Controls.Add(txtTotal);
            panelContainer.Controls.Add(label_total);
            panelContainer.Controls.Add(BtnDeleteRow);
            panelContainer.Controls.Add(txtAmount);
            panelContainer.Controls.Add(label_amount);
            panelContainer.Controls.Add(txtDescription);
            panelContainer.Controls.Add(label_desc);
            panelContainer.Controls.Add(comboBankId);
            panelContainer.Controls.Add(txtChequeNo);
            panelContainer.Controls.Add(comboBankName);
            panelContainer.Controls.Add(label_cheque);
            panelContainer.Controls.Add(label_bankId);
            panelContainer.Controls.Add(txtVoucherNo);
            panelContainer.Controls.Add(label_bankName);
            panelContainer.Controls.Add(label_voucher);
            panelContainer.Controls.Add(label_bankBal);
            panelContainer.Controls.Add(txtPreBalance);
            panelContainer.Controls.Add(txtBankBalance);
            panelContainer.Controls.Add(label_preBal);
            panelContainer.Controls.Add(label_date);
            panelContainer.Controls.Add(comboPartyId);
            panelContainer.Controls.Add(dateInvoice);
            panelContainer.Controls.Add(label_partyId);
            panelContainer.Controls.Add(label_partyName);
            panelContainer.Controls.Add(comboPartyName);
            panelContainer.Controls.Add(BtnSave);
            panelContainer.Controls.Add(BtnClose);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1209, 656);
            panelContainer.TabIndex = 32;
            // 
            // BankPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 656);
            Controls.Add(panelHeader);
            Controls.Add(panelContainer);
            Name = "BankPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bank Payment Voucher";
            FormClosing += BankPayment_FormClosing;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLines).EndInit();
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
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
        private Panel panelContainer;
    }
}