namespace EasyBiz
{
    partial class ChequeBook
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
            panelInput = new Panel();
            label_bankId = new Label();
            comboBankId = new ComboBox();
            label_bankName = new Label();
            comboBankName = new ComboBox();
            label_chequeNo = new Label();
            txtChequeNo = new TextBox();
            label_date = new Label();
            dateCheque = new DateTimePicker();
            label_amount = new Label();
            txtAmount = new TextBox();
            label_partyId = new Label();
            comboPartyId = new ComboBox();
            label_partyName = new Label();
            comboPartyName = new ComboBox();
            label_direction = new Label();
            comboDirection = new ComboBox();
            label_desc = new Label();
            txtDesc = new TextBox();
            BtnAddCheque = new CustomButton();
            panelFilter = new Panel();
            label_search = new Label();
            txtSearchCheque = new TextBox();
            label_statusFilter = new Label();
            comboStatus = new ComboBox();
            BtnRefresh = new CustomButton();
            gridCheques = new DataGridView();
            colChequeId = new DataGridViewTextBoxColumn();
            colChequeNo = new DataGridViewTextBoxColumn();
            colChequeDate = new DataGridViewTextBoxColumn();
            colBankName = new DataGridViewTextBoxColumn();
            colPartyName = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colDirection = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colClearedDate = new DataGridViewTextBoxColumn();
            panelActions = new Panel();
            lblSummary = new Label();
            BtnClear = new CustomButton();
            BtnReturn = new CustomButton();
            BtnCancel = new CustomButton();
            BtnClose = new CustomButton();
            panelHeader.SuspendLayout();
            panelInput.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCheques).BeginInit();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(70, 130, 180);
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1400, 55);
            panelHeader.TabIndex = 3;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(560, 10);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(331, 40);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Cheque Book Manager";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.FromArgb(240, 248, 255);
            panelInput.Controls.Add(label_bankId);
            panelInput.Controls.Add(comboBankId);
            panelInput.Controls.Add(label_bankName);
            panelInput.Controls.Add(comboBankName);
            panelInput.Controls.Add(label_chequeNo);
            panelInput.Controls.Add(txtChequeNo);
            panelInput.Controls.Add(label_date);
            panelInput.Controls.Add(dateCheque);
            panelInput.Controls.Add(label_amount);
            panelInput.Controls.Add(txtAmount);
            panelInput.Controls.Add(label_partyId);
            panelInput.Controls.Add(comboPartyId);
            panelInput.Controls.Add(label_partyName);
            panelInput.Controls.Add(comboPartyName);
            panelInput.Controls.Add(label_direction);
            panelInput.Controls.Add(comboDirection);
            panelInput.Controls.Add(label_desc);
            panelInput.Controls.Add(txtDesc);
            panelInput.Controls.Add(BtnAddCheque);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(0, 55);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1400, 200);
            panelInput.TabIndex = 2;
            // 
            // label_bankId
            // 
            label_bankId.AutoSize = true;
            label_bankId.Font = new Font("Segoe UI", 10F);
            label_bankId.Location = new Point(12, 18);
            label_bankId.Name = "label_bankId";
            label_bankId.Size = new Size(69, 23);
            label_bankId.TabIndex = 0;
            label_bankId.Text = "Bank ID";
            // 
            // comboBankId
            // 
            comboBankId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBankId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBankId.Font = new Font("Segoe UI", 10F);
            comboBankId.Location = new Point(87, 15);
            comboBankId.Name = "comboBankId";
            comboBankId.Size = new Size(130, 31);
            comboBankId.TabIndex = 1;
            comboBankId.SelectedIndexChanged += comboBankId_SelectedIndexChanged;
            // 
            // label_bankName
            // 
            label_bankName.AutoSize = true;
            label_bankName.Font = new Font("Segoe UI", 10F);
            label_bankName.Location = new Point(224, 18);
            label_bankName.Name = "label_bankName";
            label_bankName.Size = new Size(98, 23);
            label_bankName.TabIndex = 2;
            label_bankName.Text = "Bank Name";
            // 
            // comboBankName
            // 
            comboBankName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBankName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBankName.Font = new Font("Segoe UI", 10F);
            comboBankName.Location = new Point(328, 15);
            comboBankName.Name = "comboBankName";
            comboBankName.Size = new Size(339, 31);
            comboBankName.TabIndex = 3;
            comboBankName.SelectedIndexChanged += comboBankName_SelectedIndexChanged;
            // 
            // label_chequeNo
            // 
            label_chequeNo.AutoSize = true;
            label_chequeNo.Font = new Font("Segoe UI", 10F);
            label_chequeNo.Location = new Point(673, 20);
            label_chequeNo.Name = "label_chequeNo";
            label_chequeNo.Size = new Size(84, 23);
            label_chequeNo.TabIndex = 4;
            label_chequeNo.Text = "Cheque #";
            // 
            // txtChequeNo
            // 
            txtChequeNo.Font = new Font("Segoe UI", 10F);
            txtChequeNo.Location = new Point(763, 15);
            txtChequeNo.Name = "txtChequeNo";
            txtChequeNo.Size = new Size(150, 30);
            txtChequeNo.TabIndex = 5;
            // 
            // label_date
            // 
            label_date.AutoSize = true;
            label_date.Font = new Font("Segoe UI", 10F);
            label_date.Location = new Point(919, 18);
            label_date.Name = "label_date";
            label_date.Size = new Size(46, 23);
            label_date.TabIndex = 6;
            label_date.Text = "Date";
            // 
            // dateCheque
            // 
            dateCheque.Font = new Font("Segoe UI", 10F);
            dateCheque.Format = DateTimePickerFormat.Short;
            dateCheque.Location = new Point(971, 15);
            dateCheque.Name = "dateCheque";
            dateCheque.Size = new Size(160, 30);
            dateCheque.TabIndex = 7;
            // 
            // label_amount
            // 
            label_amount.AutoSize = true;
            label_amount.Font = new Font("Segoe UI", 10F);
            label_amount.Location = new Point(1150, 18);
            label_amount.Name = "label_amount";
            label_amount.Size = new Size(72, 23);
            label_amount.TabIndex = 8;
            label_amount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtAmount.Location = new Point(1228, 13);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(160, 32);
            txtAmount.TabIndex = 9;
            // 
            // label_partyId
            // 
            label_partyId.AutoSize = true;
            label_partyId.Font = new Font("Segoe UI", 10F);
            label_partyId.Location = new Point(12, 68);
            label_partyId.Name = "label_partyId";
            label_partyId.Size = new Size(70, 23);
            label_partyId.TabIndex = 10;
            label_partyId.Text = "Party ID";
            // 
            // comboPartyId
            // 
            comboPartyId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPartyId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPartyId.Font = new Font("Segoe UI", 10F);
            comboPartyId.Location = new Point(87, 68);
            comboPartyId.Name = "comboPartyId";
            comboPartyId.Size = new Size(130, 31);
            comboPartyId.TabIndex = 11;
            comboPartyId.SelectedIndexChanged += comboPartyId_SelectedIndexChanged;
            // 
            // label_partyName
            // 
            label_partyName.AutoSize = true;
            label_partyName.Font = new Font("Segoe UI", 10F);
            label_partyName.Location = new Point(223, 75);
            label_partyName.Name = "label_partyName";
            label_partyName.Size = new Size(99, 23);
            label_partyName.TabIndex = 12;
            label_partyName.Text = "Party Name";
            // 
            // comboPartyName
            // 
            comboPartyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboPartyName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboPartyName.Font = new Font("Segoe UI", 10F);
            comboPartyName.Location = new Point(328, 72);
            comboPartyName.Name = "comboPartyName";
            comboPartyName.Size = new Size(339, 31);
            comboPartyName.TabIndex = 13;
            comboPartyName.SelectedIndexChanged += comboPartyName_SelectedIndexChanged;
            // 
            // label_direction
            // 
            label_direction.AutoSize = true;
            label_direction.Font = new Font("Segoe UI", 10F);
            label_direction.Location = new Point(689, 72);
            label_direction.Name = "label_direction";
            label_direction.Size = new Size(45, 23);
            label_direction.TabIndex = 14;
            label_direction.Text = "Type";
            // 
            // comboDirection
            // 
            comboDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDirection.Font = new Font("Segoe UI", 10F);
            comboDirection.Location = new Point(740, 69);
            comboDirection.Name = "comboDirection";
            comboDirection.Size = new Size(200, 31);
            comboDirection.TabIndex = 15;
            // 
            // label_desc
            // 
            label_desc.AutoSize = true;
            label_desc.Font = new Font("Segoe UI", 10F);
            label_desc.Location = new Point(946, 71);
            label_desc.Name = "label_desc";
            label_desc.Size = new Size(96, 23);
            label_desc.TabIndex = 16;
            label_desc.Text = "Description";
            // 
            // txtDesc
            // 
            txtDesc.Font = new Font("Segoe UI", 10F);
            txtDesc.Location = new Point(1048, 69);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(340, 30);
            txtDesc.TabIndex = 17;
            // 
            // BtnAddCheque
            // 
            BtnAddCheque.BackColor = Color.FromArgb(70, 130, 180);
            BtnAddCheque.BackgroundColor = Color.FromArgb(70, 130, 180);
            BtnAddCheque.BorderColor = Color.Transparent;
            BtnAddCheque.BorderRadius = 8;
            BtnAddCheque.BorderSize = 0;
            BtnAddCheque.FlatAppearance.BorderSize = 0;
            BtnAddCheque.FlatStyle = FlatStyle.Flat;
            BtnAddCheque.Font = new Font("Segoe UI", 11F);
            BtnAddCheque.ForeColor = Color.White;
            BtnAddCheque.Location = new Point(12, 120);
            BtnAddCheque.Name = "BtnAddCheque";
            BtnAddCheque.Size = new Size(180, 42);
            BtnAddCheque.TabIndex = 18;
            BtnAddCheque.Text = "Add to Register";
            BtnAddCheque.TextColor = Color.White;
            BtnAddCheque.UseVisualStyleBackColor = false;
            BtnAddCheque.Click += BtnAddCheque_Click;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(label_search);
            panelFilter.Controls.Add(txtSearchCheque);
            panelFilter.Controls.Add(label_statusFilter);
            panelFilter.Controls.Add(comboStatus);
            panelFilter.Controls.Add(BtnRefresh);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 255);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1400, 55);
            panelFilter.TabIndex = 1;
            // 
            // label_search
            // 
            label_search.AutoSize = true;
            label_search.Font = new Font("Segoe UI", 10F);
            label_search.Location = new Point(15, 15);
            label_search.Name = "label_search";
            label_search.Size = new Size(65, 23);
            label_search.TabIndex = 0;
            label_search.Text = "Search:";
            // 
            // txtSearchCheque
            // 
            txtSearchCheque.Font = new Font("Segoe UI", 10F);
            txtSearchCheque.Location = new Point(75, 12);
            txtSearchCheque.Name = "txtSearchCheque";
            txtSearchCheque.Size = new Size(280, 30);
            txtSearchCheque.TabIndex = 1;
            txtSearchCheque.TextChanged += txtSearchCheque_TextChanged;
            // 
            // label_statusFilter
            // 
            label_statusFilter.AutoSize = true;
            label_statusFilter.Font = new Font("Segoe UI", 10F);
            label_statusFilter.Location = new Point(380, 15);
            label_statusFilter.Name = "label_statusFilter";
            label_statusFilter.Size = new Size(60, 23);
            label_statusFilter.TabIndex = 2;
            label_statusFilter.Text = "Status:";
            // 
            // comboStatus
            // 
            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatus.Font = new Font("Segoe UI", 10F);
            comboStatus.Location = new Point(435, 12);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(140, 31);
            comboStatus.TabIndex = 3;
            comboStatus.SelectedIndexChanged += comboStatus_SelectedIndexChanged;
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.ForestGreen;
            BtnRefresh.BackgroundColor = Color.ForestGreen;
            BtnRefresh.BorderColor = Color.Transparent;
            BtnRefresh.BorderRadius = 6;
            BtnRefresh.BorderSize = 0;
            BtnRefresh.FlatAppearance.BorderSize = 0;
            BtnRefresh.FlatStyle = FlatStyle.Flat;
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(590, 10);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(110, 34);
            BtnRefresh.TabIndex = 4;
            BtnRefresh.Text = "Refresh";
            BtnRefresh.TextColor = Color.White;
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // gridCheques
            // 
            gridCheques.AllowUserToAddRows = false;
            gridCheques.AllowUserToDeleteRows = false;
            gridCheques.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            gridCheques.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridCheques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridCheques.BackgroundColor = Color.White;
            gridCheques.BorderStyle = BorderStyle.None;
            gridCheques.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridCheques.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            gridCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridCheques.ColumnHeadersHeight = 42;
            gridCheques.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridCheques.Columns.AddRange(new DataGridViewColumn[] { colChequeId, colChequeNo, colChequeDate, colBankName, colPartyName, colAmount, colDirection, colStatus, colDesc, colClearedDate });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridCheques.DefaultCellStyle = dataGridViewCellStyle3;
            gridCheques.Dock = DockStyle.Fill;
            gridCheques.EnableHeadersVisualStyles = false;
            gridCheques.GridColor = Color.LightGray;
            gridCheques.Location = new Point(0, 310);
            gridCheques.MultiSelect = false;
            gridCheques.Name = "gridCheques";
            gridCheques.ReadOnly = true;
            gridCheques.RowHeadersVisible = false;
            gridCheques.RowHeadersWidth = 51;
            gridCheques.RowTemplate.Height = 38;
            gridCheques.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCheques.Size = new Size(1400, 480);
            gridCheques.TabIndex = 0;
            gridCheques.SelectionChanged += gridCheques_SelectionChanged;
            // 
            // colChequeId
            // 
            colChequeId.HeaderText = "ID";
            colChequeId.MinimumWidth = 6;
            colChequeId.Name = "colChequeId";
            colChequeId.ReadOnly = true;
            colChequeId.Visible = false;
            // 
            // colChequeNo
            // 
            colChequeNo.HeaderText = "Cheque #";
            colChequeNo.MinimumWidth = 6;
            colChequeNo.Name = "colChequeNo";
            colChequeNo.ReadOnly = true;
            // 
            // colChequeDate
            // 
            colChequeDate.HeaderText = "Date";
            colChequeDate.MinimumWidth = 6;
            colChequeDate.Name = "colChequeDate";
            colChequeDate.ReadOnly = true;
            // 
            // colBankName
            // 
            colBankName.HeaderText = "Bank";
            colBankName.MinimumWidth = 6;
            colBankName.Name = "colBankName";
            colBankName.ReadOnly = true;
            // 
            // colPartyName
            // 
            colPartyName.HeaderText = "Party";
            colPartyName.MinimumWidth = 6;
            colPartyName.Name = "colPartyName";
            colPartyName.ReadOnly = true;
            // 
            // colAmount
            // 
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            // 
            // colDirection
            // 
            colDirection.HeaderText = "Direction";
            colDirection.MinimumWidth = 6;
            colDirection.Name = "colDirection";
            colDirection.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colDesc
            // 
            colDesc.HeaderText = "Description";
            colDesc.MinimumWidth = 6;
            colDesc.Name = "colDesc";
            colDesc.ReadOnly = true;
            // 
            // colClearedDate
            // 
            colClearedDate.HeaderText = "Cleared Date";
            colClearedDate.MinimumWidth = 6;
            colClearedDate.Name = "colClearedDate";
            colClearedDate.ReadOnly = true;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.WhiteSmoke;
            panelActions.Controls.Add(lblSummary);
            panelActions.Controls.Add(BtnClear);
            panelActions.Controls.Add(BtnReturn);
            panelActions.Controls.Add(BtnCancel);
            panelActions.Controls.Add(BtnClose);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 790);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(1400, 110);
            panelActions.TabIndex = 4;
            // 
            // lblSummary
            // 
            lblSummary.Font = new Font("Segoe UI", 10F);
            lblSummary.ForeColor = Color.DimGray;
            lblSummary.Location = new Point(15, 10);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(1100, 28);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "Loading...";
            // 
            // BtnClear
            // 
            BtnClear.BackColor = Color.DarkGreen;
            BtnClear.BackgroundColor = Color.DarkGreen;
            BtnClear.BorderColor = Color.Transparent;
            BtnClear.BorderRadius = 8;
            BtnClear.BorderSize = 0;
            BtnClear.Enabled = false;
            BtnClear.FlatAppearance.BorderSize = 0;
            BtnClear.FlatStyle = FlatStyle.Flat;
            BtnClear.Font = new Font("Segoe UI", 11F);
            BtnClear.ForeColor = Color.White;
            BtnClear.Location = new Point(250, 40);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(175, 48);
            BtnClear.TabIndex = 1;
            BtnClear.Text = "Mark Cleared ✓";
            BtnClear.TextColor = Color.White;
            BtnClear.UseVisualStyleBackColor = false;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.BackColor = Color.DarkRed;
            BtnReturn.BackgroundColor = Color.DarkRed;
            BtnReturn.BorderColor = Color.Transparent;
            BtnReturn.BorderRadius = 8;
            BtnReturn.BorderSize = 0;
            BtnReturn.Enabled = false;
            BtnReturn.FlatAppearance.BorderSize = 0;
            BtnReturn.FlatStyle = FlatStyle.Flat;
            BtnReturn.Font = new Font("Segoe UI", 11F);
            BtnReturn.ForeColor = Color.White;
            BtnReturn.Location = new Point(440, 40);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(175, 48);
            BtnReturn.TabIndex = 2;
            BtnReturn.Text = "Mark Returned ✗";
            BtnReturn.TextColor = Color.White;
            BtnReturn.UseVisualStyleBackColor = false;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.DimGray;
            BtnCancel.BackgroundColor = Color.DimGray;
            BtnCancel.BorderColor = Color.Transparent;
            BtnCancel.BorderRadius = 8;
            BtnCancel.BorderSize = 0;
            BtnCancel.Enabled = false;
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatStyle = FlatStyle.Flat;
            BtnCancel.Font = new Font("Segoe UI", 11F);
            BtnCancel.ForeColor = Color.White;
            BtnCancel.Location = new Point(630, 40);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(175, 48);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "Cancel Cheque";
            BtnCancel.TextColor = Color.White;
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Tomato;
            BtnClose.BackgroundColor = Color.Tomato;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 8;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 11F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(900, 40);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(155, 48);
            BtnClose.TabIndex = 4;
            BtnClose.Text = "Close";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // ChequeBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 900);
            Controls.Add(gridCheques);
            Controls.Add(panelFilter);
            Controls.Add(panelInput);
            Controls.Add(panelHeader);
            Controls.Add(panelActions);
            Name = "ChequeBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cheque Book Manager";
            WindowState = FormWindowState.Maximized;
            FormClosing += ChequeBook_FormClosing;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridCheques).EndInit();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelHeader, panelInput, panelFilter, panelActions;
        private Label lblHeader;
        private ComboBox comboBankId, comboBankName, comboPartyId, comboPartyName;
        private Label label_bankId, label_bankName, label_partyId, label_partyName;
        private TextBox txtChequeNo, txtAmount, txtDesc;
        private Label label_chequeNo, label_date, label_amount, label_direction, label_desc;
        private DateTimePicker dateCheque;
        private ComboBox comboDirection;
        private CustomButton BtnAddCheque;
        private Label label_search, label_statusFilter;
        private TextBox txtSearchCheque;
        private ComboBox comboStatus;
        private CustomButton BtnRefresh;
        private DataGridView gridCheques;
        private DataGridViewTextBoxColumn colChequeId, colChequeNo, colChequeDate, colBankName,
            colPartyName, colAmount, colDirection, colStatus, colDesc, colClearedDate;
        private Label lblSummary;
        private CustomButton BtnClear, BtnReturn, BtnCancel, BtnClose;
    }
}