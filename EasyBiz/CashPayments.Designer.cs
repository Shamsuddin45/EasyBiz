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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(800, 42);
            label1.Name = "label1";
            label1.Size = new Size(53, 28);
            label1.TabIndex = 0;
            label1.Text = "Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(859, 42);
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
            comboAccountName.Location = new Point(128, 103);
            comboAccountName.Name = "comboAccountName";
            comboAccountName.Size = new Size(567, 36);
            comboAccountName.TabIndex = 2;
            comboAccountName.SelectedIndexChanged += comboAccountName_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(20, 106);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 3;
            label2.Text = "A/C Name";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(128, 157);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(567, 34);
            txtDescription.TabIndex = 4;
            txtDescription.KeyPress += txtDescription_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(10, 157);
            label3.Name = "label3";
            label3.Size = new Size(112, 28);
            label3.TabIndex = 5;
            label3.Text = "Description";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.Red;
            txtAmount.Location = new Point(485, 211);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(210, 34);
            txtAmount.TabIndex = 6;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(396, 214);
            label4.Name = "label4";
            label4.Size = new Size(83, 28);
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
            BtnSave.Font = new Font("Segoe UI", 12F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(551, 771);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(188, 50);
            BtnSave.TabIndex = 8;
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
            BtnClose.Font = new Font("Segoe UI", 12F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(389, 771);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(156, 50);
            BtnClose.TabIndex = 9;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(327, 47);
            label5.Name = "label5";
            label5.Size = new Size(66, 28);
            label5.TabIndex = 11;
            label5.Text = "PreBal";
            // 
            // txtPreBalance
            // 
            txtPreBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPreBalance.Location = new Point(399, 47);
            txtPreBalance.Name = "txtPreBalance";
            txtPreBalance.Size = new Size(296, 34);
            txtPreBalance.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(53, 48);
            label6.Name = "label6";
            label6.Size = new Size(69, 28);
            label6.TabIndex = 13;
            label6.Text = "A/C ID";
            // 
            // comboAccountId
            // 
            comboAccountId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboAccountId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboAccountId.Font = new Font("Segoe UI", 12F);
            comboAccountId.FormattingEnabled = true;
            comboAccountId.Location = new Point(128, 45);
            comboAccountId.Name = "comboAccountId";
            comboAccountId.Size = new Size(193, 36);
            comboAccountId.TabIndex = 12;
            comboAccountId.SelectedIndexChanged += comboAccountId_SelectedIndexChanged;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, accountId, accountname, desc, amount });
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
            dataGridView1.Location = new Point(10, 276);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1075, 437);
            dataGridView1.TabIndex = 14;
            // 
            // sno
            // 
            sno.HeaderText = "Sno";
            sno.MinimumWidth = 6;
            sno.Name = "sno";
            // 
            // accountId
            // 
            accountId.HeaderText = "account id";
            accountId.MinimumWidth = 6;
            accountId.Name = "accountId";
            accountId.Visible = false;
            // 
            // accountname
            // 
            accountname.HeaderText = "Account Name";
            accountname.MinimumWidth = 6;
            accountname.Name = "accountname";
            // 
            // desc
            // 
            desc.HeaderText = "Description";
            desc.MinimumWidth = 6;
            desc.Name = "desc";
            // 
            // amount
            // 
            amount.HeaderText = "Amount";
            amount.MinimumWidth = 6;
            amount.Name = "amount";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(762, 111);
            label7.Name = "label7";
            label7.Size = new Size(91, 28);
            label7.TabIndex = 16;
            label7.Text = "Invoice #";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtInvoiceNumber.ForeColor = Color.Red;
            txtInvoiceNumber.Location = new Point(859, 106);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(192, 34);
            txtInvoiceNumber.TabIndex = 15;
            txtInvoiceNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotal.ForeColor = Color.Red;
            txtTotal.Location = new Point(859, 719);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(226, 34);
            txtTotal.TabIndex = 17;
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
            BtnDeleteRow.Location = new Point(10, 719);
            BtnDeleteRow.Name = "BtnDeleteRow";
            BtnDeleteRow.Size = new Size(134, 34);
            BtnDeleteRow.TabIndex = 18;
            BtnDeleteRow.Text = "Delete Row";
            BtnDeleteRow.TextColor = Color.White;
            BtnDeleteRow.UseVisualStyleBackColor = false;
            BtnDeleteRow.Click += BtnDeleteRow_Click;
            // 
            // CashPayments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 833);
            Controls.Add(BtnDeleteRow);
            Controls.Add(txtTotal);
            Controls.Add(label7);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(comboAccountId);
            Controls.Add(label5);
            Controls.Add(txtPreBalance);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(label4);
            Controls.Add(txtAmount);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(comboAccountName);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Name = "CashPayments";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cash Payment Voucher";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridViewTextBoxColumn sno;
        private DataGridViewTextBoxColumn accountId;
        private DataGridViewTextBoxColumn accountname;
        private DataGridViewTextBoxColumn desc;
        private DataGridViewTextBoxColumn amount;
        private TextBox txtTotal;
        private CustomButton BtnDeleteRow;
    }
}