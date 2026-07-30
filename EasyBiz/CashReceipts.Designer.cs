namespace EasyBiz
{
    partial class CashReceipts
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            label6 = new Label();
            comboAccountId = new ComboBox();
            label5 = new Label();
            txtPreBalance = new TextBox();
            label4 = new Label();
            txtAmount = new TextBox();
            label3 = new Label();
            txtDescription = new TextBox();
            label2 = new Label();
            comboAccountName = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            sno = new DataGridViewTextBoxColumn();
            accountId = new DataGridViewTextBoxColumn();
            accountname = new DataGridViewTextBoxColumn();
            desc = new DataGridViewTextBoxColumn();
            amount = new DataGridViewTextBoxColumn();
            BtnClose = new CustomButton();
            BtnSave = new CustomButton();
            label7 = new Label();
            txtInvoiceNumber = new TextBox();
            txtTotal = new TextBox();
            BtnDeleteRow = new CustomButton();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            btnAiPredict = new Button();
            lblInWords = new Label();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.Location = new Point(43, 101);
            label6.Name = "label6";
            label6.Size = new Size(61, 23);
            label6.TabIndex = 25;
            label6.Text = "A/C ID";
            // 
            // comboAccountId
            // 
            comboAccountId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountId.Font = new Font("Segoe UI", 11F);
            comboAccountId.FormattingEnabled = true;
            comboAccountId.Location = new Point(110, 96);
            comboAccountId.Name = "comboAccountId";
            comboAccountId.Size = new Size(141, 33);
            comboAccountId.TabIndex = 1;
            comboAccountId.SelectedIndexChanged += comboAccountId_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.Location = new Point(779, 97);
            label5.Name = "label5";
            label5.Size = new Size(58, 23);
            label5.TabIndex = 23;
            label5.Text = "PreBal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPreBalance.BackColor = Color.WhiteSmoke;
            txtPreBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtPreBalance.Location = new Point(843, 92);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.ReadOnly = true;
            txtPreBalance.Size = new Size(194, 32);
            txtPreBalance.TabIndex = 22;
            txtPreBalance.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(32, 199);
            label4.Name = "label4";
            label4.Size = new Size(72, 23);
            label4.TabIndex = 21;
            label4.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtAmount.ForeColor = Color.ForestGreen;
            txtAmount.Location = new Point(110, 191);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(200, 34);
            txtAmount.TabIndex = 5;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            txtAmount.TextChanged += txtAmount_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(9, 151);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 19;
            label3.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(110, 146);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(475, 32);
            txtDescription.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(259, 102);
            label2.Name = "label2";
            label2.Size = new Size(56, 23);
            label2.TabIndex = 17;
            label2.Text = "Name";
            // 
            // comboAccountName
            // 
            comboAccountName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountName.Font = new Font("Segoe UI", 11F);
            comboAccountName.FormattingEnabled = true;
            comboAccountName.Location = new Point(320, 97);
            comboAccountName.Name = "comboAccountName";
            comboAccountName.Size = new Size(320, 33);
            comboAccountName.TabIndex = 3;
            comboAccountName.SelectedIndexChanged += comboAccountName_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 11F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(480, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(160, 32);
            dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(428, 48);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 14;
            label1.Text = "Date";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(248, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.DarkGreen;
            dataGridViewCellStyle10.Font = new Font("Segoe UI Semibold", 10.5F);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.DarkGreen;
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, accountId, accountname, desc, amount });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(43, 43, 43);
            dataGridViewCellStyle12.Padding = new Padding(8, 4, 8, 4);
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(225, 238, 254);
            dataGridViewCellStyle12.SelectionForeColor = Color.FromArgb(15, 76, 129);
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(230, 234, 238);
            dataGridView1.Location = new Point(3, 242);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1070, 265);
            dataGridView1.TabIndex = 14;
            dataGridView1.TabStop = false;
            // 
            // sno
            // 
            sno.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            sno.HeaderText = "SNo";
            sno.MinimumWidth = 6;
            sno.Name = "sno";
            sno.ReadOnly = true;
            sno.Width = 90;
            // 
            // accountId
            // 
            accountId.HeaderText = "Account ID";
            accountId.MinimumWidth = 6;
            accountId.Name = "accountId";
            accountId.Visible = false;
            // 
            // accountname
            // 
            accountname.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            accountname.HeaderText = "Account Name";
            accountname.MinimumWidth = 6;
            accountname.Name = "accountname";
            accountname.ReadOnly = true;
            accountname.Width = 177;
            // 
            // desc
            // 
            desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            desc.HeaderText = "Description";
            desc.MinimumWidth = 6;
            desc.Name = "desc";
            // 
            // amount
            // 
            amount.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Font = new Font("Segoe UI Semibold", 10.5F);
            dataGridViewCellStyle11.Format = "N2";
            amount.DefaultCellStyle = dataGridViewCellStyle11;
            amount.HeaderText = "Amount";
            amount.MinimumWidth = 6;
            amount.Name = "amount";
            amount.Width = 123;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.WhiteSmoke;
            BtnClose.BackgroundColor = Color.WhiteSmoke;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 6;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            BtnClose.ForeColor = Color.DimGray;
            BtnClose.Location = new Point(774, 3);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(121, 42);
            BtnClose.TabIndex = 7;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.DimGray;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.ForestGreen;
            BtnSave.BackgroundColor = Color.ForestGreen;
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 6;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(918, 3);
            BtnSave.Margin = new Padding(3, 3, 20, 3);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(149, 42);
            BtnSave.TabIndex = 6;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label7.Location = new Point(757, 51);
            label7.Name = "label7";
            label7.Size = new Size(80, 23);
            label7.TabIndex = 30;
            label7.Text = "Invoice #";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtInvoiceNumber.BackColor = Color.WhiteSmoke;
            txtInvoiceNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtInvoiceNumber.ForeColor = Color.FromArgb(15, 76, 129);
            txtInvoiceNumber.Location = new Point(843, 48);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(194, 32);
            txtInvoiceNumber.TabIndex = 29;
            txtInvoiceNumber.TabStop = false;
            txtInvoiceNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotal.BackColor = Color.WhiteSmoke;
            txtTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtTotal.ForeColor = Color.Red;
            txtTotal.Location = new Point(829, 6);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(226, 38);
            txtTotal.TabIndex = 31;
            txtTotal.TabStop = false;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // BtnDeleteRow
            // 
            BtnDeleteRow.BackColor = Color.White;
            BtnDeleteRow.BackgroundColor = Color.White;
            BtnDeleteRow.BorderColor = Color.Red;
            BtnDeleteRow.BorderRadius = 4;
            BtnDeleteRow.BorderSize = 1;
            BtnDeleteRow.FlatAppearance.BorderSize = 0;
            BtnDeleteRow.FlatStyle = FlatStyle.Flat;
            BtnDeleteRow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnDeleteRow.ForeColor = Color.Red;
            BtnDeleteRow.Location = new Point(20, 6);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(112, 38);
            BtnDeleteRow.TabIndex = 32;
            BtnDeleteRow.TabStop = false;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.Red;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtTotal);
            panel1.Controls.Add(BtnDeleteRow);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 513);
            panel1.Name = "panel1";
            panel1.Size = new Size(1070, 49);
            panel1.TabIndex = 33;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Controls.Add(BtnClose);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 568);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel1.Size = new Size(1070, 52);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnAiPredict);
            panel2.Controls.Add(lblInWords);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtAmount);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtDescription);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(comboAccountId);
            panel2.Controls.Add(txtInvoiceNumber);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(comboAccountName);
            panel2.Controls.Add(txtPreBalance);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1070, 233);
            panel2.TabIndex = 35;
            // 
            // btnAiPredict
            // 
            btnAiPredict.BackColor = Color.LimeGreen;
            btnAiPredict.FlatAppearance.BorderSize = 0;
            btnAiPredict.FlatStyle = FlatStyle.Flat;
            btnAiPredict.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAiPredict.ForeColor = Color.White;
            btnAiPredict.Location = new Point(591, 146);
            btnAiPredict.Name = "btnAiPredict";
            btnAiPredict.Size = new Size(49, 32);
            btnAiPredict.TabIndex = 33;
            btnAiPredict.Text = "✨";
            btnAiPredict.UseVisualStyleBackColor = false;
            // 
            // lblInWords
            // 
            lblInWords.AutoSize = true;
            lblInWords.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic);
            lblInWords.ForeColor = Color.DimGray;
            lblInWords.Location = new Point(334, 197);
            lblInWords.Name = "lblInWords";
            lblInWords.Size = new Size(19, 25);
            lblInWords.TabIndex = 32;
            lblInWords.Text = "-";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(43, 43, 43);
            label8.Location = new Point(43, 18);
            label8.Name = "label8";
            label8.Size = new Size(197, 41);
            label8.TabIndex = 31;
            label8.Text = "Cash Receipt";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 239F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.Size = new Size(1076, 623);
            tableLayoutPanel1.TabIndex = 36;
            // 
            // CashReceipts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1076, 623);
            Controls.Add(tableLayoutPanel1);
            Name = "CashReceipts";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cash Receipt Voucher";
            FormClosing += CashReceipts_FormClosing;
            Load += CashReceipts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private ComboBox comboAccountId;
        private Label label5;
        private TextBox txtPreBalance;
        private Label label4;
        private TextBox txtAmount;
        private Label label3;
        private TextBox txtDescription;
        private Label label2;
        private ComboBox comboAccountName;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private DataGridView dataGridView1;
        private CustomButton BtnClose;
        private CustomButton BtnSave;
        private Label label7;
        private TextBox txtInvoiceNumber;
        private TextBox txtTotal;
        private CustomButton BtnDeleteRow;
        private DataGridViewTextBoxColumn sno;
        private DataGridViewTextBoxColumn accountId;
        private DataGridViewTextBoxColumn accountname;
        private DataGridViewTextBoxColumn desc;
        private DataGridViewTextBoxColumn amount;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label8;
        private Label lblInWords;
        private Button btnAiPredict;
    }
}