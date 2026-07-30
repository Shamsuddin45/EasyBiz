namespace EasyBiz
{
    partial class BankReceipt
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();

            panelHeader = new System.Windows.Forms.Panel();
            lblHeader = new System.Windows.Forms.Label();
            comboBankId = new System.Windows.Forms.ComboBox();
            comboBankName = new System.Windows.Forms.ComboBox();
            label_bankId = new System.Windows.Forms.Label();
            label_bankName = new System.Windows.Forms.Label();
            label_bankBal = new System.Windows.Forms.Label();
            txtBankBalance = new System.Windows.Forms.TextBox();
            comboPartyId = new System.Windows.Forms.ComboBox();
            comboPartyName = new System.Windows.Forms.ComboBox();
            label_partyId = new System.Windows.Forms.Label();
            label_partyName = new System.Windows.Forms.Label();
            label_preBal = new System.Windows.Forms.Label();
            txtPreBalance = new System.Windows.Forms.TextBox();
            label_date = new System.Windows.Forms.Label();
            dateInvoice = new System.Windows.Forms.DateTimePicker();
            label_voucher = new System.Windows.Forms.Label();
            txtVoucherNo = new System.Windows.Forms.TextBox();
            label_cheque = new System.Windows.Forms.Label();
            txtChequeNo = new System.Windows.Forms.TextBox();
            label_desc = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            label_amount = new System.Windows.Forms.Label();
            txtAmount = new System.Windows.Forms.TextBox();
            gridLines = new System.Windows.Forms.DataGridView();
            colSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPartyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label_total = new System.Windows.Forms.Label();
            txtTotal = new System.Windows.Forms.TextBox();
            BtnDeleteRow = new CustomButton();
            BtnSave = new CustomButton();
            BtnClose = new CustomButton();
            panelContainer = new System.Windows.Forms.Panel();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(gridLines)).BeginInit();
            panelContainer.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.SeaGreen;
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1209, 50);
            panelHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Location = new System.Drawing.Point(23, 6);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(294, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Bank Receipt Voucher";
            // 
            // label_voucher
            // 
            label_voucher.AutoSize = true;
            label_voucher.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_voucher.Location = new System.Drawing.Point(30, 20);
            label_voucher.Name = "label_voucher";
            label_voucher.Size = new System.Drawing.Size(83, 23);
            label_voucher.TabIndex = 15;
            label_voucher.Text = "Voucher #";
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            txtVoucherNo.ForeColor = System.Drawing.Color.ForestGreen;
            txtVoucherNo.Location = new System.Drawing.Point(30, 45);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.ReadOnly = true;
            txtVoucherNo.Size = new System.Drawing.Size(160, 32);
            txtVoucherNo.TabIndex = 16;
            txtVoucherNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_date
            // 
            label_date.AutoSize = true;
            label_date.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_date.Location = new System.Drawing.Point(220, 20);
            label_date.Name = "label_date";
            label_date.Size = new System.Drawing.Size(46, 23);
            label_date.TabIndex = 13;
            label_date.Text = "Date";
            // 
            // dateInvoice
            // 
            dateInvoice.Font = new System.Drawing.Font("Segoe UI", 11F);
            dateInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateInvoice.Location = new System.Drawing.Point(220, 45);
            dateInvoice.Name = "dateInvoice";
            dateInvoice.Size = new System.Drawing.Size(178, 32);
            dateInvoice.TabIndex = 14;
            // 
            // label_bankId
            // 
            label_bankId.AutoSize = true;
            label_bankId.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_bankId.Location = new System.Drawing.Point(30, 90);
            label_bankId.Name = "label_bankId";
            label_bankId.Size = new System.Drawing.Size(69, 23);
            label_bankId.TabIndex = 3;
            label_bankId.Text = "Bank ID";
            // 
            // comboBankId
            // 
            comboBankId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBankId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBankId.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBankId.Location = new System.Drawing.Point(30, 115);
            comboBankId.Name = "comboBankId";
            comboBankId.Size = new System.Drawing.Size(160, 33);
            comboBankId.TabIndex = 1;
            comboBankId.SelectedIndexChanged += comboBankId_SelectedIndexChanged;
            // 
            // label_bankName
            // 
            label_bankName.AutoSize = true;
            label_bankName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_bankName.Location = new System.Drawing.Point(220, 90);
            label_bankName.Name = "label_bankName";
            label_bankName.Size = new System.Drawing.Size(51, 23);
            label_bankName.TabIndex = 4;
            label_bankName.Text = "Bank:";
            // 
            // comboBankName
            // 
            comboBankName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBankName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBankName.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBankName.Location = new System.Drawing.Point(220, 115);
            comboBankName.Name = "comboBankName";
            comboBankName.Size = new System.Drawing.Size(415, 33);
            comboBankName.TabIndex = 2;
            comboBankName.SelectedIndexChanged += comboBankName_SelectedIndexChanged;
            // 
            // label_bankBal
            // 
            label_bankBal.AutoSize = true;
            label_bankBal.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_bankBal.Location = new System.Drawing.Point(660, 90);
            label_bankBal.Name = "label_bankBal";
            label_bankBal.Size = new System.Drawing.Size(111, 23);
            label_bankBal.TabIndex = 5;
            label_bankBal.Text = "Bank Balance";
            // 
            // txtBankBalance
            // 
            txtBankBalance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            txtBankBalance.Location = new System.Drawing.Point(660, 115);
            txtBankBalance.Name = "txtBankBalance";
            txtBankBalance.ReadOnly = true;
            txtBankBalance.Size = new System.Drawing.Size(200, 32);
            txtBankBalance.TabIndex = 6;
            // 
            // label_partyId
            // 
            label_partyId.AutoSize = true;
            label_partyId.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_partyId.Location = new System.Drawing.Point(30, 160);
            label_partyId.Name = "label_partyId";
            label_partyId.Size = new System.Drawing.Size(70, 23);
            label_partyId.TabIndex = 9;
            label_partyId.Text = "Party ID";
            // 
            // comboPartyId
            // 
            comboPartyId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboPartyId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboPartyId.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboPartyId.Location = new System.Drawing.Point(30, 185);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new System.Drawing.Size(160, 33);
            comboPartyId.TabIndex = 7;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // label_partyName
            // 
            label_partyName.AutoSize = true;
            label_partyName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_partyName.Location = new System.Drawing.Point(220, 160);
            label_partyName.Name = "label_partyName";
            label_partyName.Size = new System.Drawing.Size(52, 23);
            label_partyName.TabIndex = 10;
            label_partyName.Text = "Party:";
            // 
            // comboPartyName
            // 
            comboPartyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboPartyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboPartyName.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboPartyName.Location = new System.Drawing.Point(220, 185);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new System.Drawing.Size(415, 33);
            comboPartyName.TabIndex = 8;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // label_preBal
            // 
            label_preBal.AutoSize = true;
            label_preBal.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_preBal.Location = new System.Drawing.Point(660, 160);
            label_preBal.Name = "label_preBal";
            label_preBal.Size = new System.Drawing.Size(111, 23);
            label_preBal.TabIndex = 11;
            label_preBal.Text = "Party Balance";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            txtPreBalance.Location = new System.Drawing.Point(660, 185);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.ReadOnly = true;
            txtPreBalance.Size = new System.Drawing.Size(200, 32);
            txtPreBalance.TabIndex = 12;
            // 
            // label_cheque
            // 
            label_cheque.AutoSize = true;
            label_cheque.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_cheque.Location = new System.Drawing.Point(30, 230);
            label_cheque.Name = "label_cheque";
            label_cheque.Size = new System.Drawing.Size(81, 23);
            label_cheque.TabIndex = 17;
            label_cheque.Text = "Cheque #";
            // 
            // txtChequeNo
            // 
            txtChequeNo.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtChequeNo.Location = new System.Drawing.Point(30, 255);
            txtChequeNo.Name = "txtChequeNo";
            txtChequeNo.Size = new System.Drawing.Size(160, 32);
            txtChequeNo.TabIndex = 18;
            // 
            // label_desc
            // 
            label_desc.AutoSize = true;
            label_desc.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_desc.Location = new System.Drawing.Point(220, 230);
            label_desc.Name = "label_desc";
            label_desc.Size = new System.Drawing.Size(96, 23);
            label_desc.TabIndex = 19;
            label_desc.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtDescription.Location = new System.Drawing.Point(220, 255);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(415, 32);
            txtDescription.TabIndex = 20;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // label_amount
            // 
            label_amount.AutoSize = true;
            label_amount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            label_amount.Location = new System.Drawing.Point(660, 230);
            label_amount.Name = "label_amount";
            label_amount.Size = new System.Drawing.Size(72, 23);
            label_amount.TabIndex = 21;
            label_amount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            txtAmount.ForeColor = System.Drawing.Color.ForestGreen;
            txtAmount.Location = new System.Drawing.Point(660, 255);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new System.Drawing.Size(200, 32);
            txtAmount.TabIndex = 22;
            txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // gridLines
            // 
            gridLines.AllowUserToAddRows = false;
            gridLines.AllowUserToDeleteRows = false;
            gridLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            gridLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            gridLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridLines.BackgroundColor = System.Drawing.Color.White;
            gridLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            gridLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            gridLines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            gridLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            gridLines.ColumnHeadersHeight = 42;
            gridLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSno, colPartyId, colPartyName, colDesc, colAmount, colChequeNo });
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            gridLines.DefaultCellStyle = dataGridViewCellStyle12;
            gridLines.EnableHeadersVisualStyles = false;
            gridLines.GridColor = System.Drawing.Color.LightGray;
            gridLines.Location = new System.Drawing.Point(30, 315);
            gridLines.MultiSelect = false;
            gridLines.Name = "gridLines";
            gridLines.RowHeadersVisible = false;
            gridLines.RowHeadersWidth = 51;
            gridLines.RowTemplate.Height = 38;
            gridLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridLines.Size = new System.Drawing.Size(1149, 185);
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
            // BtnDeleteRow
            // 
            BtnDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            BtnDeleteRow.BackColor = System.Drawing.Color.Crimson;
            BtnDeleteRow.BackgroundColor = System.Drawing.Color.Crimson;
            BtnDeleteRow.BorderColor = System.Drawing.Color.Transparent;
            BtnDeleteRow.BorderRadius = 6;
            BtnDeleteRow.BorderSize = 0;
            BtnDeleteRow.FlatAppearance.BorderSize = 0;
            BtnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnDeleteRow.ForeColor = System.Drawing.Color.White;
            BtnDeleteRow.Location = new System.Drawing.Point(30, 515);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new System.Drawing.Size(130, 38);
            BtnDeleteRow.TabIndex = 26;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = System.Drawing.Color.White;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // label_total
            // 
            label_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            label_total.AutoSize = true;
            label_total.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label_total.Location = new System.Drawing.Point(895, 520);
            label_total.Name = "label_total";
            label_total.Size = new System.Drawing.Size(64, 28);
            label_total.TabIndex = 24;
            label_total.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            txtTotal.ForeColor = System.Drawing.Color.ForestGreen;
            txtTotal.Location = new System.Drawing.Point(969, 517);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new System.Drawing.Size(210, 34);
            txtTotal.TabIndex = 25;
            txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            BtnClose.BackColor = System.Drawing.Color.FromArgb(200, 60, 60);
            BtnClose.BackgroundColor = System.Drawing.Color.FromArgb(200, 60, 60);
            BtnClose.BorderColor = System.Drawing.Color.Transparent;
            BtnClose.BorderRadius = 8;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            BtnClose.ForeColor = System.Drawing.Color.White;
            BtnClose.Location = new System.Drawing.Point(839, 565);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new System.Drawing.Size(124, 50);
            BtnClose.TabIndex = 28;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = System.Drawing.Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // BtnSave
            // 
            BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            BtnSave.BackColor = System.Drawing.Color.SeaGreen;
            BtnSave.BackgroundColor = System.Drawing.Color.SeaGreen;
            BtnSave.BorderColor = System.Drawing.Color.Transparent;
            BtnSave.BorderRadius = 8;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            BtnSave.ForeColor = System.Drawing.Color.White;
            BtnSave.Location = new System.Drawing.Point(969, 565);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new System.Drawing.Size(210, 50);
            BtnSave.TabIndex = 27;
            BtnSave.Text = "Post Receipt (Ctrl+S)";
            BtnSave.TextColor = System.Drawing.Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // panelContainer
            // 
            panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            panelContainer.AutoScroll = true;
            panelContainer.Controls.Add(gridLines);
            panelContainer.Controls.Add(BtnDeleteRow);
            panelContainer.Controls.Add(txtTotal);
            panelContainer.Controls.Add(label_total);
            panelContainer.Controls.Add(BtnSave);
            panelContainer.Controls.Add(BtnClose);
            panelContainer.Controls.Add(txtAmount);
            panelContainer.Controls.Add(label_amount);
            panelContainer.Controls.Add(txtVoucherNo);
            panelContainer.Controls.Add(txtDescription);
            panelContainer.Controls.Add(comboBankId);
            panelContainer.Controls.Add(label_desc);
            panelContainer.Controls.Add(comboBankName);
            panelContainer.Controls.Add(txtChequeNo);
            panelContainer.Controls.Add(label_bankId);
            panelContainer.Controls.Add(label_cheque);
            panelContainer.Controls.Add(label_bankName);
            panelContainer.Controls.Add(label_voucher);
            panelContainer.Controls.Add(label_bankBal);
            panelContainer.Controls.Add(txtPreBalance);
            panelContainer.Controls.Add(txtBankBalance);
            panelContainer.Controls.Add(dateInvoice);
            panelContainer.Controls.Add(comboPartyId);
            panelContainer.Controls.Add(label_date);
            panelContainer.Controls.Add(comboPartyName);
            panelContainer.Controls.Add(label_preBal);
            panelContainer.Controls.Add(label_partyId);
            panelContainer.Controls.Add(label_partyName);
            panelContainer.Location = new System.Drawing.Point(0, 50);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new System.Drawing.Size(1209, 630);
            panelContainer.TabIndex = 29;
            // 
            // BankReceipt
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1209, 680);
            Controls.Add(panelContainer);
            Controls.Add(panelHeader);
            Name = "BankReceipt";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Bank Receipt Voucher";
            FormClosing += BankReceipt_FormClosing;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(gridLines)).EndInit();
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox comboBankId, comboBankName;
        private System.Windows.Forms.Label label_bankId, label_bankName, label_bankBal;
        private System.Windows.Forms.TextBox txtBankBalance;
        private System.Windows.Forms.ComboBox comboPartyId, comboPartyName;
        private System.Windows.Forms.Label label_partyId, label_partyName, label_preBal;
        private System.Windows.Forms.TextBox txtPreBalance;
        private System.Windows.Forms.Label label_date, label_voucher;
        private System.Windows.Forms.DateTimePicker dateInvoice;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Label label_cheque;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label label_desc, label_amount;
        private System.Windows.Forms.TextBox txtDescription, txtAmount;
        private System.Windows.Forms.DataGridView gridLines;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.TextBox txtTotal;
        private CustomButton BtnDeleteRow, BtnSave, BtnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChequeNo;
        private System.Windows.Forms.Panel panelContainer;
    }
}