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
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAccountId).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(74, 43);
            label6.Name = "label6";
            label6.Size = new Size(50, 23);
            label6.TabIndex = 19;
            label6.Text = "By ID";
            // 
            // comboSearchId
            // 
            comboSearchId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchId.Font = new Font("Segoe UI", 11F);
            comboSearchId.FormattingEnabled = true;
            comboSearchId.Location = new Point(130, 38);
            comboSearchId.Name = "comboSearchId";
            comboSearchId.Size = new Size(200, 33);
            comboSearchId.TabIndex = 1;
            comboSearchId.SelectedIndexChanged += comboSearchId_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(32, 265);
            label3.Name = "label3";
            label3.Size = new Size(112, 23);
            label3.TabIndex = 17;
            label3.Text = "New Account";
            // 
            // txtNewAccount
            // 
            txtNewAccount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtNewAccount.Font = new Font("Segoe UI", 11F);
            txtNewAccount.Location = new Point(150, 260);
            txtNewAccount.Name = "txtNewAccount";
            txtNewAccount.Size = new Size(520, 32);
            txtNewAccount.TabIndex = 5;
            txtNewAccount.KeyDown += txtNewAccount_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(43, 93);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 15;
            label2.Text = "By Name";
            // 
            // comboSearchName
            // 
            comboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchName.Font = new Font("Segoe UI", 11F);
            comboSearchName.FormattingEnabled = true;
            comboSearchName.Location = new Point(130, 88);
            comboSearchName.Name = "comboSearchName";
            comboSearchName.Size = new Size(490, 33);
            comboSearchName.TabIndex = 2;
            comboSearchName.SelectedIndexChanged += comboSearchName_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(384, 325);
            label1.Name = "label1";
            label1.Size = new Size(70, 23);
            label1.TabIndex = 21;
            label1.Text = "Contact";
            // 
            // txtContact
            // 
            txtContact.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtContact.Font = new Font("Segoe UI", 11F);
            txtContact.Location = new Point(460, 320);
            txtContact.Name = "txtContact";
            txtContact.PlaceholderText = "03xxxxxxxxx";
            txtContact.Size = new Size(210, 32);
            txtContact.TabIndex = 7;
            txtContact.KeyDown += txtContact_KeyDown;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(74, 325);
            label4.Name = "label4";
            label4.Size = new Size(70, 23);
            label4.TabIndex = 23;
            label4.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtAddress.Font = new Font("Segoe UI", 11F);
            txtAddress.Location = new Point(150, 320);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 32);
            txtAddress.TabIndex = 6;
            txtAddress.KeyDown += txtAddress_KeyDown;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(83, 204);
            label5.Name = "label5";
            label5.Size = new Size(61, 23);
            label5.TabIndex = 25;
            label5.Text = "A/C ID";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(375, 204);
            label7.Name = "label7";
            label7.Size = new Size(79, 23);
            label7.TabIndex = 27;
            label7.Text = "Category";
            // 
            // comboCategory
            // 
            comboCategory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboCategory.Font = new Font("Segoe UI", 11F);
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "Cash", "Banks", "Assets", "Capital", "Brokers", "Personal Ledgers", "Payables", "Receivables", "Employees", "Expenses", "Others" });
            comboCategory.Location = new Point(460, 200);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(210, 33);
            comboCategory.TabIndex = 4;
            comboCategory.SelectedIndexChanged += comboCategory_SelectedIndexChanged_1;
            comboCategory.KeyDown += comboCategory_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboSearchName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboSearchId);
            groupBox1.Controls.Add(label6);
            groupBox1.Font = new Font("Segoe UI", 9.5F);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(650, 150);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search Account";
            // 
            // BtnSave
            // 
            BtnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnSave.BackColor = Color.LimeGreen;
            BtnSave.BackgroundColor = Color.LimeGreen;
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 8;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI Semibold", 9.5F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(529, 427);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(145, 45);
            BtnSave.TabIndex = 8;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnUpdate.BackColor = Color.DarkOrange;
            BtnUpdate.BackgroundColor = Color.DarkOrange;
            BtnUpdate.BorderColor = Color.Transparent;
            BtnUpdate.BorderRadius = 8;
            BtnUpdate.BorderSize = 0;
            BtnUpdate.Enabled = false;
            BtnUpdate.FlatAppearance.BorderSize = 0;
            BtnUpdate.FlatStyle = FlatStyle.Flat;
            BtnUpdate.Font = new Font("Segoe UI Semibold", 9.5F);
            BtnUpdate.ForeColor = Color.White;
            BtnUpdate.Location = new Point(341, 427);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(182, 45);
            BtnUpdate.TabIndex = 9;
            BtnUpdate.Text = "Update (Ctrl+U)";
            BtnUpdate.TextColor = Color.White;
            BtnUpdate.UseVisualStyleBackColor = false;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BtnRefresh
            // 
            BtnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            BtnRefresh.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnRefresh.BorderColor = Color.Transparent;
            BtnRefresh.BorderRadius = 8;
            BtnRefresh.BorderSize = 0;
            BtnRefresh.FlatAppearance.BorderSize = 0;
            BtnRefresh.FlatStyle = FlatStyle.Flat;
            BtnRefresh.Font = new Font("Segoe UI Semibold", 9.5F);
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(160, 427);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(175, 45);
            BtnRefresh.TabIndex = 10;
            BtnRefresh.Text = "Refresh (Ctrl+R)";
            BtnRefresh.TextColor = Color.White;
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnClose.BackColor = Color.Tomato;
            BtnClose.BackgroundColor = Color.Tomato;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 8;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI Semibold", 9.5F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(34, 427);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(120, 45);
            BtnClose.TabIndex = 11;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // numAccountId
            // 
            numAccountId.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numAccountId.Font = new Font("Segoe UI", 11F);
            numAccountId.Location = new Point(150, 200);
            numAccountId.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numAccountId.Name = "numAccountId";
            numAccountId.ReadOnly = true;
            numAccountId.Size = new Size(200, 32);
            numAccountId.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMargin = new Size(10, 10);
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(comboCategory);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(BtnUpdate);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtContact);
            panel1.Controls.Add(numAccountId);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(txtNewAccount);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(BtnSave);
            panel1.Controls.Add(BtnRefresh);
            panel1.Controls.Add(BtnClose);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(708, 500);
            panel1.TabIndex = 34;
            // 
            // AccountsSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(708, 500);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimumSize = new Size(726, 547);
            Name = "AccountsSetup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Accounts Setup";
            FormClosing += AccountsSetup_FormClosing;
            Load += AccountsSetup_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAccountId).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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
        private Panel panel1;
    }
}