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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(51, 47);
            label6.Name = "label6";
            label6.Size = new Size(69, 28);
            label6.TabIndex = 25;
            label6.Text = "A/C ID";
            // 
            // comboAccountId
            // 
            comboAccountId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountId.Font = new Font("Segoe UI", 12F);
            comboAccountId.FormattingEnabled = true;
            comboAccountId.Location = new Point(126, 44);
            comboAccountId.Name = "comboAccountId";
            comboAccountId.Size = new Size(193, 36);
            comboAccountId.TabIndex = 24;
            comboAccountId.SelectedIndexChanged += comboAccountId_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(325, 49);
            label5.Name = "label5";
            label5.Size = new Size(66, 28);
            label5.TabIndex = 23;
            label5.Text = "PreBal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPreBalance.Location = new Point(397, 46);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.Size = new Size(296, 34);
            txtPreBalance.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(126, 212);
            label4.Name = "label4";
            label4.Size = new Size(60, 28);
            label4.TabIndex = 21;
            label4.Text = "Debit";
            // 
            // txtDebit
            // 
            txtDebit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDebit.ForeColor = Color.LightSeaGreen;
            txtDebit.Location = new Point(192, 209);
            txtDebit.Name = "txtDebit";
            txtDebit.Size = new Size(210, 34);
            txtDebit.TabIndex = 3;
            txtDebit.TextAlign = HorizontalAlignment.Center;
            txtDebit.KeyPress += txtDebit_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(8, 156);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 19;
            label3.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(126, 156);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(567, 34);
            txtDescription.TabIndex = 2;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(18, 105);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 17;
            label2.Text = "A/C Name";
            // 
            // comboAccountName
            // 
            comboAccountName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountName.Font = new Font("Segoe UI", 12F);
            comboAccountName.FormattingEnabled = true;
            comboAccountName.Location = new Point(126, 102);
            comboAccountName.Name = "comboAccountName";
            comboAccountName.Size = new Size(567, 36);
            comboAccountName.TabIndex = 1;
            comboAccountName.SelectedIndexChanged += comboAccountName_SelectedIndexChanged;
            comboAccountName.KeyPress += comboAccountName_KeyPress;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(857, 41);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(192, 34);
            dateTimePicker1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(798, 41);
            label1.Name = "label1";
            label1.Size = new Size(53, 28);
            label1.TabIndex = 14;
            label1.Text = "Date";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, accountId, accountname, desc, debit, credit });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.Padding = new Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(8, 282);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1075, 401);
            dataGridView1.TabIndex = 26;
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
            BtnClose.Font = new Font("Segoe UI", 12F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(738, 689);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(150, 50);
            BtnClose.TabIndex = 7;
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
            BtnSave.Font = new Font("Segoe UI", 12F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(894, 689);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(188, 50);
            BtnSave.TabIndex = 6;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(413, 212);
            label7.Name = "label7";
            label7.Size = new Size(65, 28);
            label7.TabIndex = 30;
            label7.Text = "Credit";
            // 
            // txtCredit
            // 
            txtCredit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCredit.ForeColor = Color.LightSeaGreen;
            txtCredit.Location = new Point(483, 209);
            txtCredit.Name = "txtCredit";
            txtCredit.Size = new Size(210, 34);
            txtCredit.TabIndex = 4;
            txtCredit.TextAlign = HorizontalAlignment.Center;
            txtCredit.KeyPress += txtCredit_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(760, 108);
            label8.Name = "label8";
            label8.Size = new Size(91, 28);
            label8.TabIndex = 32;
            label8.Text = "Invoice #";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtInvoiceNumber.ForeColor = Color.LightSeaGreen;
            txtInvoiceNumber.Location = new Point(857, 102);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(192, 34);
            txtInvoiceNumber.TabIndex = 31;
            txtInvoiceNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // JournalVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 750);
            Controls.Add(label8);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(label7);
            Controls.Add(txtCredit);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(comboAccountId);
            Controls.Add(label5);
            Controls.Add(txtPreBalance);
            Controls.Add(label4);
            Controls.Add(txtDebit);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(comboAccountName);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Name = "JournalVoucher";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Journal Voucher";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}