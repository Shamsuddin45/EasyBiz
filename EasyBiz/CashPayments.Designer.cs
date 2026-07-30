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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
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
            btnAiPredict = new Button();
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
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(100, 100, 100);
            label1.Location = new Point(432, 29);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 0;
            label1.Text = "Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(484, 24);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(166, 34);
            dateTimePicker1.TabIndex = 1;
            // 
            // comboAccountName
            // 
            comboAccountName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountName.Font = new Font("Segoe UI", 12F);
            comboAccountName.FormattingEnabled = true;
            comboAccountName.Location = new Point(346, 78);
            comboAccountName.Name = "comboAccountName";
            comboAccountName.Size = new Size(304, 36);
            comboAccountName.TabIndex = 3;
            comboAccountName.SelectedIndexChanged += comboAccountName_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(284, 83);
            label2.Name = "label2";
            label2.Size = new Size(56, 23);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(121, 125);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(474, 34);
            txtDescription.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(19, 131);
            label3.Name = "label3";
            label3.Size = new Size(96, 23);
            label3.TabIndex = 5;
            label3.Text = "Description";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.FromArgb(220, 53, 69);
            txtAmount.Location = new Point(121, 170);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(210, 38);
            txtAmount.TabIndex = 5;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            txtAmount.TextChanged += txtAmount_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(43, 180);
            label4.Name = "label4";
            label4.Size = new Size(72, 23);
            label4.TabIndex = 7;
            label4.Text = "Amount";
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(0, 120, 215);
            BtnSave.BackgroundColor = Color.FromArgb(0, 120, 215);
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 6;
            BtnSave.BorderSize = 0;
            BtnSave.Cursor = Cursors.Hand;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(956, 8);
            BtnSave.Margin = new Padding(3, 8, 20, 3);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(140, 42);
            BtnSave.TabIndex = 6;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.White;
            BtnClose.BackgroundColor = Color.White;
            BtnClose.BorderColor = Color.FromArgb(200, 200, 200);
            BtnClose.BorderRadius = 6;
            BtnClose.BorderSize = 1;
            BtnClose.Cursor = Cursors.Hand;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            BtnClose.ForeColor = Color.FromArgb(64, 64, 64);
            BtnClose.Location = new Point(823, 8);
            BtnClose.Margin = new Padding(3, 8, 10, 3);
            BtnClose.Name = "BtnClose";
            BtnClose.RightToLeft = RightToLeft.No;
            BtnClose.Size = new Size(110, 42);
            BtnClose.TabIndex = 7;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.FromArgb(64, 64, 64);
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(761, 81);
            label5.Name = "label5";
            label5.Size = new Size(58, 23);
            label5.TabIndex = 11;
            label5.Text = "PreBal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPreBalance.BackColor = Color.FromArgb(248, 249, 250);
            txtPreBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtPreBalance.Location = new Point(825, 75);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.ReadOnly = true;
            txtPreBalance.Size = new Size(192, 34);
            txtPreBalance.TabIndex = 10;
            txtPreBalance.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Location = new Point(54, 83);
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
            comboAccountId.Location = new Point(121, 78);
            comboAccountId.Name = "comboAccountId";
            comboAccountId.Size = new Size(126, 36);
            comboAccountId.TabIndex = 2;
            comboAccountId.SelectedIndexChanged += comboAccountId_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(248, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(41, 50, 65);
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 10.5F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(41, 50, 65);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.ColumnHeadersHeight = 48;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, accountId, accountname, desc, amount });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10.5F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(43, 43, 43);
            dataGridViewCellStyle8.Padding = new Padding(8, 4, 8, 4);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(225, 238, 254);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(15, 76, 129);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(230, 234, 238);
            dataGridView1.Location = new Point(20, 260);
            dataGridView1.Margin = new Padding(20, 0, 20, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 44;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1059, 253);
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
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            amount.DefaultCellStyle = dataGridViewCellStyle7;
            amount.HeaderText = "Amount";
            amount.MinimumWidth = 6;
            amount.Name = "amount";
            amount.Width = 123;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(740, 34);
            label7.Name = "label7";
            label7.Size = new Size(80, 23);
            label7.TabIndex = 16;
            label7.Text = "Invoice #";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtInvoiceNumber.BackColor = Color.FromArgb(248, 249, 250);
            txtInvoiceNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtInvoiceNumber.ForeColor = Color.FromArgb(220, 53, 69);
            txtInvoiceNumber.Location = new Point(825, 29);
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
            txtTotal.BackColor = Color.White;
            txtTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtTotal.ForeColor = Color.FromArgb(220, 53, 69);
            txtTotal.Location = new Point(833, 8);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(226, 43);
            txtTotal.TabIndex = 17;
            txtTotal.TabStop = false;
            txtTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnDeleteRow
            // 
            BtnDeleteRow.BackColor = Color.White;
            BtnDeleteRow.BackgroundColor = Color.White;
            BtnDeleteRow.BorderColor = Color.FromArgb(220, 53, 69);
            BtnDeleteRow.BorderRadius = 4;
            BtnDeleteRow.BorderSize = 1;
            BtnDeleteRow.Cursor = Cursors.Hand;
            BtnDeleteRow.FlatAppearance.BorderSize = 0;
            BtnDeleteRow.FlatStyle = FlatStyle.Flat;
            BtnDeleteRow.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            BtnDeleteRow.ForeColor = Color.FromArgb(220, 53, 69);
            BtnDeleteRow.Location = new Point(0, 10);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(115, 38);
            BtnDeleteRow.TabIndex = 18;
            BtnDeleteRow.TabStop = false;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.FromArgb(220, 53, 69);
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(245, 246, 250);
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Controls.Add(BtnClose);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 573);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
            flowLayoutPanel1.Size = new Size(1099, 60);
            flowLayoutPanel1.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(BtnDeleteRow);
            panel1.Controls.Add(txtTotal);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 513);
            panel1.Margin = new Padding(20, 0, 20, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1059, 60);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnAiPredict);
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
            panel2.Location = new Point(20, 20);
            panel2.Margin = new Padding(20);
            panel2.Name = "panel2";
            panel2.Size = new Size(1059, 220);
            panel2.TabIndex = 21;
            // 
            // btnAiPredict
            // 
            btnAiPredict.BackColor = Color.OrangeRed;
            btnAiPredict.Cursor = Cursors.Hand;
            btnAiPredict.FlatAppearance.BorderSize = 0;
            btnAiPredict.FlatStyle = FlatStyle.Flat;
            btnAiPredict.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnAiPredict.ForeColor = Color.White;
            btnAiPredict.Location = new Point(601, 125);
            btnAiPredict.Name = "btnAiPredict";
            btnAiPredict.Size = new Size(49, 34);
            btnAiPredict.TabIndex = 19;
            btnAiPredict.Text = "✨";
            btnAiPredict.UseVisualStyleBackColor = false;
            // 
            // lblInWords
            // 
            lblInWords.AutoSize = true;
            lblInWords.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInWords.ForeColor = Color.FromArgb(100, 100, 100);
            lblInWords.Location = new Point(368, 178);
            lblInWords.Name = "lblInWords";
            lblInWords.Size = new Size(19, 25);
            lblInWords.TabIndex = 18;
            lblInWords.Text = "-";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(41, 50, 65);
            label8.Location = new Point(19, 12);
            label8.Name = "label8";
            label8.Size = new Size(265, 50);
            label8.TabIndex = 17;
            label8.Text = "Cash Payment";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(245, 246, 250);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(1099, 633);
            tableLayoutPanel1.TabIndex = 22;
            // 
            // CashPayments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(1099, 633);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(1000, 600);
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
        private Button btnAiPredict;
    }
}