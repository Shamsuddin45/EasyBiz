namespace EasyBiz
{
    partial class CashPayments
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            comboAccountName = new ComboBox();
            label2 = new Label();
            txtDescription = new TextBox();
            label3 = new Label();
            txtAmount = new TextBox();
            label4 = new Label();
            BtnSave = new CustomButton();
            BtnClose = new CustomButton();
            label5 = new Label();
            txtPreBalance = new TextBox();
            label6 = new Label();
            comboAccountId = new ComboBox();
            dataGridView1 = new DataGridView();
            sno = new DataGridViewTextBoxColumn();
            accountId = new DataGridViewTextBoxColumn();
            accountname = new DataGridViewTextBoxColumn();
            desc = new DataGridViewTextBoxColumn();
            amount = new DataGridViewTextBoxColumn();
            label7 = new Label();
            txtInvoiceNumber = new TextBox();
            txtTotal = new TextBox();
            BtnDeleteRow = new CustomButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            lblInWords = new Label();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(741, 24);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 0;
            label1.Text = "Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(741, 50);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(192, 34);
            dateTimePicker1.TabIndex = 1;
            // 
            // comboAccountName
            // 
            comboAccountName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountName.Font = new Font("Segoe UI", 12F);
            comboAccountName.FormattingEnabled = true;
            comboAccountName.Location = new Point(117, 75);
            comboAccountName.Name = "comboAccountName";
            comboAccountName.Size = new Size(567, 36);
            comboAccountName.TabIndex = 3;
            comboAccountName.SelectedIndexChanged += comboAccountName_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(21, 83);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.TabIndex = 3;
            label2.Text = "A/C Name";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(117, 117);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(567, 34);
            txtDescription.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(15, 125);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 5;
            label3.Text = "Description";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.Red;
            txtAmount.Location = new Point(117, 165);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(210, 34);
            txtAmount.TabIndex = 5;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            txtAmount.TextChanged += txtAmount_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(39, 173);
            label4.Name = "label4";
            label4.Size = new Size(72, 23);
            label4.TabIndex = 7;
            label4.Text = "Amount";
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
            BtnSave.Location = new Point(1080, 3);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(147, 36);
            BtnSave.TabIndex = 6;
            BtnSave.Text = "Save (Ctrl+S)";
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
            BtnClose.Location = new Point(941, 3);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(133, 36);
            BtnClose.TabIndex = 7;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(410, 41);
            label5.Name = "label5";
            label5.Size = new Size(58, 23);
            label5.TabIndex = 11;
            label5.Text = "PreBal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPreBalance.Location = new Point(474, 35);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.Size = new Size(210, 34);
            txtPreBalance.TabIndex = 10;
            txtPreBalance.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(50, 38);
            label6.Name = "label6";
            label6.Size = new Size(61, 23);
            label6.TabIndex = 13;
            label6.Text = "A/C ID";
            // 
            // comboAccountId
            // 
            comboAccountId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountId.Font = new Font("Segoe UI", 12F);
            comboAccountId.FormattingEnabled = true;
            comboAccountId.Location = new Point(117, 33);
            comboAccountId.Name = "comboAccountId";
            comboAccountId.Size = new Size(241, 36);
            comboAccountId.TabIndex = 2;
            comboAccountId.SelectedIndexChanged += comboAccountId_SelectedIndexChanged;
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
            dataGridViewCellStyle2.BackColor = Color.Tomato;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.5F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 48;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, accountId, accountname, desc, amount });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(43, 43, 43);
            dataGridViewCellStyle4.Padding = new Padding(8, 4, 8, 4);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(225, 238, 254);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(15, 76, 129);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(230, 234, 238);
            dataGridView1.Location = new Point(3, 219);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 44;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1230, 271);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            amount.DefaultCellStyle = dataGridViewCellStyle3;
            amount.HeaderText = "Amount";
            amount.MinimumWidth = 6;
            amount.Name = "amount";
            amount.Width = 123;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F);
            label7.Location = new Point(741, 93);
            label7.Name = "label7";
            label7.Size = new Size(79, 23);
            label7.TabIndex = 16;
            label7.Text = "Invoice #";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtInvoiceNumber.ForeColor = Color.Red;
            txtInvoiceNumber.Location = new Point(741, 125);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(192, 34);
            txtInvoiceNumber.TabIndex = 15;
            txtInvoiceNumber.TabStop = false;
            txtInvoiceNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotal.ForeColor = Color.Red;
            txtTotal.Location = new Point(983, 3);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(226, 34);
            txtTotal.TabIndex = 17;
            txtTotal.TabStop = false;
            txtTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnDeleteRow
            // 
            BtnDeleteRow.BackColor = Color.Red;
            BtnDeleteRow.BackgroundColor = Color.Red;
            BtnDeleteRow.BorderColor = Color.Transparent;
            BtnDeleteRow.BorderRadius = 2;
            BtnDeleteRow.BorderSize = 0;
            BtnDeleteRow.FlatAppearance.BorderSize = 0;
            BtnDeleteRow.FlatStyle = FlatStyle.Flat;
            BtnDeleteRow.ForeColor = Color.White;
            BtnDeleteRow.Location = new Point(3, 3);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(115, 34);
            BtnDeleteRow.TabIndex = 18;
            BtnDeleteRow.TabStop = false;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.White;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Controls.Add(BtnClose);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 577);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel1.Size = new Size(1230, 43);
            flowLayoutPanel1.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnDeleteRow);
            panel1.Controls.Add(txtTotal);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 496);
            panel1.Name = "panel1";
            panel1.Size = new Size(1230, 75);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblInWords);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(txtAmount);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtDescription);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtPreBalance);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(comboAccountId);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(comboAccountName);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtInvoiceNumber);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1230, 210);
            panel2.TabIndex = 21;
            // 
            // lblInWords
            // 
            lblInWords.AutoSize = true;
            lblInWords.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInWords.Location = new Point(352, 167);
            lblInWords.Name = "lblInWords";
            lblInWords.Size = new Size(20, 28);
            lblInWords.TabIndex = 18;
            lblInWords.Text = "-";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1020, 59);
            label8.Name = "label8";
            label8.Size = new Size(152, 76);
            label8.TabIndex = 17;
            label8.Text = "Cash \r\nPayments";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34.83146F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.62279F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.1621189F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.70465469F));
            tableLayoutPanel1.Size = new Size(1236, 623);
            tableLayoutPanel1.TabIndex = 22;
            // 
            // CashPayments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 623);
            Controls.Add(tableLayoutPanel1);
            Name = "CashPayments";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cash Payment Voucher";
            FormClosing += CashPayments_FormClosing;
            Load += CashPayments_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboAccountName;
        private Label label2;
        private TextBox txtDescription;
        private Label label3;
        private TextBox txtAmount;
        private Label label4;
        private CustomButton BtnSave;
        private CustomButton BtnClose;
        private Label label5;
        private TextBox txtPreBalance;
        private Label label6;
        private ComboBox comboAccountId;
        private DataGridView dataGridView1;
        private Label label7;
        private TextBox txtInvoiceNumber;
        private TextBox txtTotal;
        private CustomButton BtnDeleteRow;
        private DataGridViewTextBoxColumn sno;
        private DataGridViewTextBoxColumn accountId;
        private DataGridViewTextBoxColumn accountname;
        private DataGridViewTextBoxColumn desc;
        private DataGridViewTextBoxColumn amount;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label8;
        private Label lblInWords;
    }
}