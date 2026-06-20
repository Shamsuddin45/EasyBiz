namespace EasyBiz
{
    partial class AccountsSetup
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
            label6 = new Label();
            comboSearchId = new ComboBox();
            label3 = new Label();
            txtNewAccount = new TextBox();
            label2 = new Label();
            comboSearchName = new ComboBox();
            label1 = new Label();
            txtContact = new TextBox();
            label4 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            label7 = new Label();
            comboCategory = new ComboBox();
            groupBox1 = new GroupBox();
            BtnSave = new CustomButton();
            BtnUpdate = new CustomButton();
            BtnRefresh = new CustomButton();
            BtnClose = new CustomButton();
            numAccountId = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAccountId).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(119, 25);
            label6.Name = "label6";
            label6.Size = new Size(69, 28);
            label6.TabIndex = 19;
            label6.Text = "A/C ID";
            // 
            // comboSearchId
            // 
            comboSearchId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchId.Font = new Font("Segoe UI", 12F);
            comboSearchId.FormattingEnabled = true;
            comboSearchId.Location = new Point(194, 22);
            comboSearchId.Name = "comboSearchId";
            comboSearchId.Size = new Size(193, 36);
            comboSearchId.TabIndex = 18;
            comboSearchId.SelectedIndexChanged += comboSearchId_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(212, 270);
            label3.Name = "label3";
            label3.Size = new Size(128, 28);
            label3.TabIndex = 17;
            label3.Text = "New Account";
            // 
            // txtNewAccount
            // 
            txtNewAccount.Font = new Font("Segoe UI", 12F);
            txtNewAccount.Location = new Point(346, 267);
            txtNewAccount.Name = "txtNewAccount";
            txtNewAccount.Size = new Size(567, 34);
            txtNewAccount.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(86, 75);
            label2.Name = "label2";
            label2.Size = new Size(102, 28);
            label2.TabIndex = 15;
            label2.Text = "A/C Name";
            // 
            // comboSearchName
            // 
            comboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchName.Font = new Font("Segoe UI", 12F);
            comboSearchName.FormattingEnabled = true;
            comboSearchName.Location = new Point(194, 72);
            comboSearchName.Name = "comboSearchName";
            comboSearchName.Size = new Size(567, 36);
            comboSearchName.TabIndex = 14;
            comboSearchName.SelectedIndexChanged += comboSearchName_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(260, 370);
            label1.Name = "label1";
            label1.Size = new Size(80, 28);
            label1.TabIndex = 21;
            label1.Text = "Contact";
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 12F);
            txtContact.Location = new Point(346, 367);
            txtContact.Name = "txtContact";
            txtContact.PlaceholderText = "03xxxxxxxxx";
            txtContact.Size = new Size(229, 34);
            txtContact.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(258, 317);
            label4.Name = "label4";
            label4.Size = new Size(82, 28);
            label4.TabIndex = 23;
            label4.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(346, 317);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(567, 34);
            txtAddress.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(271, 216);
            label5.Name = "label5";
            label5.Size = new Size(69, 28);
            label5.TabIndex = 25;
            label5.Text = "A/C ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(592, 216);
            label7.Name = "label7";
            label7.Size = new Size(92, 28);
            label7.TabIndex = 27;
            label7.Text = "Category";
            // 
            // comboCategory
            // 
            comboCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCategory.Font = new Font("Segoe UI", 12F);
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "Cash", "Banks", "Assets", "Capital", "Brokers", "Personal Ledgers", "Payables", "Receivables", "Employees", "Expenses", "Others" });
            comboCategory.Location = new Point(690, 213);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(223, 36);
            comboCategory.TabIndex = 26;
            comboCategory.SelectedIndexChanged += comboCategory_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboSearchName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboSearchId);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(152, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(770, 125);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search Account";
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.LimeGreen;
            BtnSave.BackgroundColor = Color.LimeGreen;
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 8;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(734, 476);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(188, 50);
            BtnSave.TabIndex = 29;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.BackColor = Color.DarkOrange;
            BtnUpdate.BackgroundColor = Color.DarkOrange;
            BtnUpdate.BorderColor = Color.Transparent;
            BtnUpdate.BorderRadius = 8;
            BtnUpdate.BorderSize = 0;
            BtnUpdate.Enabled = false;
            BtnUpdate.FlatAppearance.BorderSize = 0;
            BtnUpdate.FlatStyle = FlatStyle.Flat;
            BtnUpdate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnUpdate.ForeColor = Color.White;
            BtnUpdate.Location = new Point(540, 476);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(188, 50);
            BtnUpdate.TabIndex = 30;
            BtnUpdate.Text = "Update (Ctrl+U)";
            BtnUpdate.TextColor = Color.White;
            BtnUpdate.UseVisualStyleBackColor = false;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            BtnRefresh.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnRefresh.BorderColor = Color.Transparent;
            BtnRefresh.BorderRadius = 8;
            BtnRefresh.BorderSize = 0;
            BtnRefresh.FlatAppearance.BorderSize = 0;
            BtnRefresh.FlatStyle = FlatStyle.Flat;
            BtnRefresh.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(346, 476);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(188, 50);
            BtnRefresh.TabIndex = 31;
            BtnRefresh.Text = "Refresh (Ctrl+R)";
            BtnRefresh.TextColor = Color.White;
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
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
            BtnClose.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(152, 476);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(188, 50);
            BtnClose.TabIndex = 32;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // numAccountId
            // 
            numAccountId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numAccountId.Location = new Point(346, 213);
            numAccountId.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numAccountId.Name = "numAccountId";
            numAccountId.ReadOnly = true;
            numAccountId.Size = new Size(188, 34);
            numAccountId.TabIndex = 33;
            // 
            // AccountsSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 543);
            Controls.Add(numAccountId);
            Controls.Add(BtnClose);
            Controls.Add(BtnRefresh);
            Controls.Add(BtnUpdate);
            Controls.Add(BtnSave);
            Controls.Add(groupBox1);
            Controls.Add(label7);
            Controls.Add(comboCategory);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtAddress);
            Controls.Add(label1);
            Controls.Add(txtContact);
            Controls.Add(label3);
            Controls.Add(txtNewAccount);
            Name = "AccountsSetup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Accounts Setup";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAccountId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private ComboBox comboSearchId;
        private Label label3;
        private TextBox txtNewAccount;
        private Label label2;
        private ComboBox comboSearchName;
        private Label label1;
        private TextBox txtContact;
        private Label label4;
        private TextBox txtAddress;
        private Label label5;
        private Label label7;
        private ComboBox comboCategory;
        private GroupBox groupBox1;
        private CustomButton BtnSave;
        private CustomButton BtnUpdate;
        private CustomButton BtnRefresh;
        private CustomButton BtnClose;
        private NumericUpDown numAccountId;
    }
}