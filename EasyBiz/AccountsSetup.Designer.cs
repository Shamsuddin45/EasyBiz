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
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(71, 45);
            label6.Name = "label6";
            label6.Size = new Size(61, 23);
            label6.TabIndex = 19;
            label6.Text = "A/C ID";
            // 
            // comboSearchId
            // 
            comboSearchId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchId.Font = new Font("Segoe UI", 12F);
            comboSearchId.FormattingEnabled = true;
            comboSearchId.Location = new Point(138, 37);
            comboSearchId.Name = "comboSearchId";
            comboSearchId.Size = new Size(178, 36);
            comboSearchId.TabIndex = 1;
            comboSearchId.SelectedIndexChanged += comboSearchId_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(32, 295);
            label3.Name = "label3";
            label3.Size = new Size(112, 23);
            label3.TabIndex = 17;
            label3.Text = "New Account";
            // 
            // txtNewAccount
            // 
            txtNewAccount.Font = new Font("Segoe UI", 12F);
            txtNewAccount.Location = new Point(150, 287);
            txtNewAccount.Name = "txtNewAccount";
            txtNewAccount.Size = new Size(503, 34);
            txtNewAccount.TabIndex = 4;
            txtNewAccount.KeyDown += txtNewAccount_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(42, 87);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.TabIndex = 15;
            label2.Text = "A/C Name";
            // 
            // comboSearchName
            // 
            comboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchName.Font = new Font("Segoe UI", 12F);
            comboSearchName.FormattingEnabled = true;
            comboSearchName.Location = new Point(138, 79);
            comboSearchName.Name = "comboSearchName";
            comboSearchName.Size = new Size(497, 36);
            comboSearchName.TabIndex = 2;
            comboSearchName.SelectedIndexChanged += comboSearchName_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(399, 347);
            label1.Name = "label1";
            label1.Size = new Size(70, 23);
            label1.TabIndex = 21;
            label1.Text = "Contact";
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 12F);
            txtContact.Location = new Point(475, 339);
            txtContact.Name = "txtContact";
            txtContact.PlaceholderText = "03xxxxxxxxx";
            txtContact.Size = new Size(178, 34);
            txtContact.TabIndex = 6;
            txtContact.KeyDown += txtContact_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(74, 347);
            label4.Name = "label4";
            label4.Size = new Size(70, 23);
            label4.TabIndex = 23;
            label4.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(150, 339);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(245, 34);
            txtAddress.TabIndex = 5;
            txtAddress.KeyDown += txtAddress_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(83, 244);
            label5.Name = "label5";
            label5.Size = new Size(61, 23);
            label5.TabIndex = 25;
            label5.Text = "A/C ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(345, 243);
            label7.Name = "label7";
            label7.Size = new Size(79, 23);
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
            comboCategory.Location = new Point(430, 236);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(223, 36);
            comboCategory.TabIndex = 3;
            comboCategory.KeyDown += comboCategory_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboSearchName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboSearchId);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(641, 174);
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
            BtnSave.Font = new Font("Segoe UI", 9F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(524, 462);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(123, 51);
            BtnSave.TabIndex = 7;
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
            BtnUpdate.Font = new Font("Segoe UI", 9F);
            BtnUpdate.ForeColor = Color.White;
            BtnUpdate.Location = new Point(395, 462);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(123, 51);
            BtnUpdate.TabIndex = 8;
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
            BtnRefresh.Font = new Font("Segoe UI", 9F);
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(266, 462);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(123, 51);
            BtnRefresh.TabIndex = 9;
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
            BtnClose.Font = new Font("Segoe UI", 9F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(137, 462);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(123, 51);
            BtnClose.TabIndex = 10;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // numAccountId
            // 
            numAccountId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numAccountId.Location = new Point(150, 236);
            numAccountId.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numAccountId.Name = "numAccountId";
            numAccountId.ReadOnly = true;
            numAccountId.Size = new Size(178, 34);
            numAccountId.TabIndex = 33;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoScrollMargin = new Size(10, 10);
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
            panel1.Size = new Size(708, 554);
            panel1.TabIndex = 34;
            // 
            // AccountsSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 554);
            Controls.Add(panel1);
            MaximizeBox = false;
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