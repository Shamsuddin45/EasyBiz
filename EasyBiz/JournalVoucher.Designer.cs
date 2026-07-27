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
            lblInWords = new Label();
            label9 = new Label();
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
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(60, 56);
            label6.Name = "label6";
            label6.Size = new Size(61, 23);
            label6.TabIndex = 25;
            label6.Text = "A/C ID";
            // 
            // comboAccountId
            // 
            comboAccountId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountId.Font = new Font("Segoe UI", 12F);
            comboAccountId.FormattingEnabled = true;
            comboAccountId.Location = new Point(127, 48);
            comboAccountId.Name = "comboAccountId";
            comboAccountId.Size = new Size(193, 36);
            comboAccountId.TabIndex = 2;
            comboAccountId.SelectedIndexChanged += comboAccountId_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(420, 58);
            label5.Name = "label5";
            label5.Size = new Size(58, 23);
            label5.TabIndex = 23;
            label5.Text = "PreBal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPreBalance.Location = new Point(484, 50);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.Size = new Size(210, 34);
            txtPreBalance.TabIndex = 22;
            txtPreBalance.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(136, 191);
            label4.Name = "label4";
            label4.Size = new Size(51, 23);
            label4.TabIndex = 21;
            label4.Text = "Debit";
            // 
            // txtDebit
            // 
            txtDebit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDebit.ForeColor = Color.LightSeaGreen;
            txtDebit.Location = new Point(193, 183);
            txtDebit.Name = "txtDebit";
            txtDebit.Size = new Size(210, 34);
            txtDebit.TabIndex = 5;
            txtDebit.TextAlign = HorizontalAlignment.Center;
            txtDebit.TextChanged += txtDebit_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(25, 145);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 19;
            label3.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(127, 137);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(567, 34);
            txtDescription.TabIndex = 4;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(31, 103);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.TabIndex = 17;
            label2.Text = "A/C Name";
            // 
            // comboAccountName
            // 
            comboAccountName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountName.Font = new Font("Segoe UI", 12F);
            comboAccountName.FormattingEnabled = true;
            comboAccountName.Location = new Point(127, 95);
            comboAccountName.Name = "comboAccountName";
            comboAccountName.Size = new Size(567, 36);
            comboAccountName.TabIndex = 3;
            comboAccountName.SelectedIndexChanged += comboAccountName_SelectedIndexChanged;
            comboAccountName.KeyPress += comboAccountName_KeyPress;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(752, 50);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(192, 34);
            dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(700, 56);
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
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
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, accountId, accountname, desc, debit, credit });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(3, 244);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1259, 287);
            dataGridView1.TabIndex = 26;
            dataGridView1.TabStop = false;
            // 
            // sno
            // 
            sno.HeaderText = "Sno";
            sno.MinimumWidth = 6;
            sno.Name = "sno";
            sno.ReadOnly = true;
            // 
            // accountId
            // 
            accountId.HeaderText = "account id";
            accountId.MinimumWidth = 6;
            accountId.Name = "accountId";
            accountId.ReadOnly = true;
            accountId.Visible = false;
            // 
            // accountname
            // 
            accountname.HeaderText = "Account Name";
            accountname.MinimumWidth = 6;
            accountname.Name = "accountname";
            accountname.ReadOnly = true;
            // 
            // desc
            // 
            desc.HeaderText = "Description";
            desc.MinimumWidth = 6;
            desc.Name = "desc";
            desc.ReadOnly = true;
            // 
            // debit
            // 
            debit.HeaderText = "Debit";
            debit.MinimumWidth = 6;
            debit.Name = "debit";
            debit.ReadOnly = true;
            // 
            // credit
            // 
            credit.HeaderText = "Credit";
            credit.MinimumWidth = 6;
            credit.Name = "credit";
            credit.ReadOnly = true;
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
            BtnClose.Location = new Point(966, 3);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(123, 38);
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
            BtnSave.Font = new Font("Segoe UI", 10.2F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(1095, 3);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(161, 38);
            BtnSave.TabIndex = 7;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(422, 191);
            label7.Name = "label7";
            label7.Size = new Size(56, 23);
            label7.TabIndex = 30;
            label7.Text = "Credit";
            // 
            // txtCredit
            // 
            txtCredit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCredit.ForeColor = Color.LightSeaGreen;
            txtCredit.Location = new Point(484, 183);
            txtCredit.Name = "txtCredit";
            txtCredit.Size = new Size(210, 34);
            txtCredit.TabIndex = 6;
            txtCredit.TextAlign = HorizontalAlignment.Center;
            txtCredit.TextChanged += txtCredit_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(700, 103);
            label8.Name = "label8";
            label8.Size = new Size(43, 23);
            label8.TabIndex = 32;
            label8.Text = "Inv#";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtInvoiceNumber.ForeColor = Color.LightSeaGreen;
            txtInvoiceNumber.Location = new Point(752, 97);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(192, 34);
            txtInvoiceNumber.TabIndex = 31;
            txtInvoiceNumber.TabStop = false;
            txtInvoiceNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Controls.Add(BtnClose);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 542);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1259, 48);
            flowLayoutPanel1.TabIndex = 33;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblInWords);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtCredit);
            panel1.Controls.Add(txtDebit);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboAccountId);
            panel1.Controls.Add(txtInvoiceNumber);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtPreBalance);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboAccountName);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1259, 235);
            panel1.TabIndex = 34;
            // 
            // lblInWords
            // 
            lblInWords.AutoSize = true;
            lblInWords.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInWords.Location = new Point(723, 186);
            lblInWords.Name = "lblInWords";
            lblInWords.Size = new Size(20, 28);
            lblInWords.TabIndex = 34;
            lblInWords.Text = "-";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(1029, 50);
            label9.Name = "label9";
            label9.Size = new Size(133, 76);
            label9.TabIndex = 33;
            label9.Text = "Journal \r\nVoucher";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40.64081F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.4097824F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.94940948F));
            tableLayoutPanel1.Size = new Size(1265, 593);
            tableLayoutPanel1.TabIndex = 35;
            // 
            // JournalVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 593);
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
    }
}