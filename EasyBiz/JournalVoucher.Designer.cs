namespace EasyBiz
{
    partial class JournalVoucher
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
            label6 = new Label();
            comboAccountId = new ComboBox();
            label5 = new Label();
            txtPreBalance = new TextBox();
            label4 = new Label();
            txtDebit = new TextBox();
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
            debit = new DataGridViewTextBoxColumn();
            credit = new DataGridViewTextBoxColumn();
            BtnClose = new CustomButton();
            BtnSave = new CustomButton();
            label7 = new Label();
            txtCredit = new TextBox();
            label8 = new Label();
            txtInvoiceNumber = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label9 = new Label();
            btnAiPredict = new Button();
            lblInWords = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(53, 70);
            label6.Name = "label6";
            label6.Size = new Size(61, 23);
            label6.TabIndex = 1;
            label6.Text = "A/C ID";
            // 
            // comboAccountId
            // 
            comboAccountId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountId.Font = new Font("Segoe UI", 11F);
            comboAccountId.FormattingEnabled = true;
            comboAccountId.Location = new Point(120, 65);
            comboAccountId.Name = "comboAccountId";
            comboAccountId.Size = new Size(150, 33);
            comboAccountId.TabIndex = 1;
            comboAccountId.SelectedIndexChanged += comboAccountId_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(853, 71);
            label5.Name = "label5";
            label5.Size = new Size(63, 23);
            label5.TabIndex = 3;
            label5.Text = "Pre Bal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPreBalance.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtPreBalance.Location = new Point(922, 66);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.ReadOnly = true;
            txtPreBalance.Size = new Size(128, 32);
            txtPreBalance.TabIndex = 4;
            txtPreBalance.TabStop = false;
            txtPreBalance.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(63, 170);
            label4.Name = "label4";
            label4.Size = new Size(51, 23);
            label4.TabIndex = 7;
            label4.Text = "Debit";
            // 
            // txtDebit
            // 
            txtDebit.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtDebit.ForeColor = Color.LightSeaGreen;
            txtDebit.Location = new Point(120, 165);
            txtDebit.Name = "txtDebit";
            txtDebit.Size = new Size(150, 32);
            txtDebit.TabIndex = 5;
            txtDebit.TextAlign = HorizontalAlignment.Right;
            txtDebit.TextChanged += txtDebit_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(20, 120);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 5;
            label3.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(120, 115);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(530, 32);
            txtDescription.TabIndex = 3;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(285, 70);
            label2.Name = "label2";
            label2.Size = new Size(56, 23);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // comboAccountName
            // 
            comboAccountName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountName.Font = new Font("Segoe UI", 11F);
            comboAccountName.FormattingEnabled = true;
            comboAccountName.Location = new Point(347, 65);
            comboAccountName.Name = "comboAccountName";
            comboAccountName.Size = new Size(363, 33);
            comboAccountName.TabIndex = 2;
            comboAccountName.SelectedIndexChanged += comboAccountName_SelectedIndexChanged;
            comboAccountName.KeyPress += comboAccountName_KeyPress;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 11F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(560, 20);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(150, 32);
            dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(510, 25);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 13;
            label1.Text = "Date";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, accountId, accountname, desc, debit, credit });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
            dataGridView1.Location = new Point(3, 238);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1096, 299);
            dataGridView1.TabIndex = 1;
            dataGridView1.TabStop = false;
            // 
            // sno
            // 
            sno.FillWeight = 40F;
            sno.HeaderText = "SNo";
            sno.MinimumWidth = 6;
            sno.Name = "sno";
            sno.ReadOnly = true;
            // 
            // accountId
            // 
            accountId.HeaderText = "Account ID";
            accountId.MinimumWidth = 6;
            accountId.Name = "accountId";
            accountId.ReadOnly = true;
            accountId.Visible = false;
            // 
            // accountname
            // 
            accountname.FillWeight = 160F;
            accountname.HeaderText = "Account Name";
            accountname.MinimumWidth = 6;
            accountname.Name = "accountname";
            accountname.ReadOnly = true;
            // 
            // desc
            // 
            desc.FillWeight = 200F;
            desc.HeaderText = "Description";
            desc.MinimumWidth = 6;
            desc.Name = "desc";
            desc.ReadOnly = true;
            // 
            // debit
            // 
            debit.FillWeight = 80F;
            debit.HeaderText = "Debit";
            debit.MinimumWidth = 6;
            debit.Name = "debit";
            debit.ReadOnly = true;
            // 
            // credit
            // 
            credit.FillWeight = 80F;
            credit.HeaderText = "Credit";
            credit.MinimumWidth = 6;
            credit.Name = "credit";
            credit.ReadOnly = true;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.FromArgb(231, 76, 60);
            BtnClose.BackgroundColor = Color.FromArgb(231, 76, 60);
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 8;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(799, 7);
            BtnClose.Margin = new Padding(5, 3, 5, 3);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(123, 36);
            BtnClose.TabIndex = 8;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(52, 152, 219);
            BtnSave.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 8;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(932, 7);
            BtnSave.Margin = new Padding(5, 3, 5, 3);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(149, 36);
            BtnSave.TabIndex = 7;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(285, 170);
            label7.Name = "label7";
            label7.Size = new Size(56, 23);
            label7.TabIndex = 9;
            label7.Text = "Credit";
            // 
            // txtCredit
            // 
            txtCredit.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtCredit.ForeColor = Color.LightSeaGreen;
            txtCredit.Location = new Point(347, 163);
            txtCredit.Name = "txtCredit";
            txtCredit.Size = new Size(150, 32);
            txtCredit.TabIndex = 6;
            txtCredit.TextAlign = HorizontalAlignment.Right;
            txtCredit.TextChanged += txtCredit_TextChanged;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(866, 30);
            label8.Name = "label8";
            label8.Size = new Size(50, 23);
            label8.TabIndex = 14;
            label8.Text = "Vou#";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtInvoiceNumber.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            txtInvoiceNumber.ForeColor = Color.LightSeaGreen;
            txtInvoiceNumber.Location = new Point(922, 25);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(128, 32);
            txtInvoiceNumber.TabIndex = 15;
            txtInvoiceNumber.TabStop = false;
            txtInvoiceNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Controls.Add(BtnClose);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 543);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 4, 10, 0);
            flowLayoutPanel1.Size = new Size(1096, 47);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtInvoiceNumber);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(comboAccountId);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboAccountName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtPreBalance);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(btnAiPredict);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtDebit);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtCredit);
            panel1.Controls.Add(lblInWords);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1096, 229);
            panel1.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(45, 45, 48);
            label9.Location = new Point(20, 14);
            label9.Name = "label9";
            label9.Size = new Size(214, 37);
            label9.TabIndex = 0;
            label9.Text = "Journal Voucher";
            // 
            // btnAiPredict
            // 
            btnAiPredict.BackColor = Color.FromArgb(235, 243, 250);
            btnAiPredict.FlatAppearance.BorderColor = Color.FromArgb(180, 210, 235);
            btnAiPredict.FlatStyle = FlatStyle.Flat;
            btnAiPredict.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAiPredict.ForeColor = Color.FromArgb(41, 128, 185);
            btnAiPredict.Location = new Point(656, 114);
            btnAiPredict.Name = "btnAiPredict";
            btnAiPredict.Size = new Size(54, 33);
            btnAiPredict.TabIndex = 4;
            btnAiPredict.Text = "✨";
            btnAiPredict.UseVisualStyleBackColor = false;
            // 
            // lblInWords
            // 
            lblInWords.AutoSize = true;
            lblInWords.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInWords.ForeColor = Color.DimGray;
            lblInWords.Location = new Point(537, 168);
            lblInWords.Name = "lblInWords";
            lblInWords.Size = new Size(17, 23);
            lblInWords.TabIndex = 11;
            lblInWords.Text = "-";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 235F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel1.Size = new Size(1102, 593);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // JournalVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 593);
            Controls.Add(tableLayoutPanel1);
            Name = "JournalVoucher";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Journal Voucher";
            FormClosing += JournalVoucher_FormClosing;
            Load += JournalVoucher_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private ComboBox comboAccountId;
        private Label label5;
        private TextBox txtPreBalance;
        private Label label4;
        private TextBox txtDebit;
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
        private TextBox txtCredit;
        private Label label8;
        private TextBox txtInvoiceNumber;
        private DataGridViewTextBoxColumn sno;
        private DataGridViewTextBoxColumn accountId;
        private DataGridViewTextBoxColumn accountname;
        private DataGridViewTextBoxColumn desc;
        private DataGridViewTextBoxColumn debit;
        private DataGridViewTextBoxColumn credit;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label9;
        private Label lblInWords;
        private Button btnAiPredict;
    }
}