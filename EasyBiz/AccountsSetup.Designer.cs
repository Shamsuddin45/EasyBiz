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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAccountId).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(104, 19);
            label6.Name = "label6";
            label6.Size = new Size(55, 21);
            label6.TabIndex = 19;
            label6.Text = "A/C ID";
            // 
            // comboSearchId
            // 
            comboSearchId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchId.Font = new Font("Segoe UI", 12F);
            comboSearchId.FormattingEnabled = true;
            comboSearchId.Location = new Point(170, 16);
            comboSearchId.Margin = new Padding(3, 2, 3, 2);
            comboSearchId.Name = "comboSearchId";
            comboSearchId.Size = new Size(169, 29);
            comboSearchId.TabIndex = 1;
            comboSearchId.SelectedIndexChanged += comboSearchId_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(52, 58);
            label3.Name = "label3";
            label3.Size = new Size(102, 21);
            label3.TabIndex = 17;
            label3.Text = "New Account";
            // 
            // txtNewAccount
            // 
            txtNewAccount.Font = new Font("Segoe UI", 12F);
            txtNewAccount.Location = new Point(170, 56);
            txtNewAccount.Margin = new Padding(3, 2, 3, 2);
            txtNewAccount.Name = "txtNewAccount";
            txtNewAccount.Size = new Size(497, 29);
            txtNewAccount.TabIndex = 4;
            txtNewAccount.KeyDown += txtNewAccount_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(75, 56);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 15;
            label2.Text = "A/C Name";
            // 
            // comboSearchName
            // 
            comboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchName.Font = new Font("Segoe UI", 12F);
            comboSearchName.FormattingEnabled = true;
            comboSearchName.Location = new Point(170, 54);
            comboSearchName.Margin = new Padding(3, 2, 3, 2);
            comboSearchName.Name = "comboSearchName";
            comboSearchName.Size = new Size(497, 29);
            comboSearchName.TabIndex = 2;
            comboSearchName.SelectedIndexChanged += comboSearchName_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(94, 134);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 21;
            label1.Text = "Contact";
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 12F);
            txtContact.Location = new Point(170, 134);
            txtContact.Margin = new Padding(3, 2, 3, 2);
            txtContact.Name = "txtContact";
            txtContact.PlaceholderText = "03xxxxxxxxx";
            txtContact.Size = new Size(201, 29);
            txtContact.TabIndex = 6;
            txtContact.KeyDown += txtContact_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(93, 95);
            label4.Name = "label4";
            label4.Size = new Size(66, 21);
            label4.TabIndex = 23;
            label4.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(170, 95);
            txtAddress.Margin = new Padding(3, 2, 3, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(497, 29);
            txtAddress.TabIndex = 5;
            txtAddress.KeyDown += txtAddress_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(104, 20);
            label5.Name = "label5";
            label5.Size = new Size(55, 21);
            label5.TabIndex = 25;
            label5.Text = "A/C ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(385, 20);
            label7.Name = "label7";
            label7.Size = new Size(73, 21);
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
            comboCategory.Location = new Point(471, 18);
            comboCategory.Margin = new Padding(3, 2, 3, 2);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(196, 29);
            comboCategory.TabIndex = 3;
            comboCategory.KeyDown += comboCategory_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboSearchName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboSearchId);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(3, 2);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(674, 103);
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
            BtnSave.Location = new Point(387, 2);
            BtnSave.Margin = new Padding(3, 2, 3, 2);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(122, 38);
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
            BtnUpdate.Location = new Point(259, 2);
            BtnUpdate.Margin = new Padding(3, 2, 3, 2);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(122, 38);
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
            BtnRefresh.Location = new Point(131, 2);
            BtnRefresh.Margin = new Padding(3, 2, 3, 2);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(122, 38);
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
            BtnClose.Location = new Point(3, 2);
            BtnClose.Margin = new Padding(3, 2, 3, 2);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(122, 38);
            BtnClose.TabIndex = 10;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // numAccountId
            // 
            numAccountId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numAccountId.Location = new Point(170, 18);
            numAccountId.Margin = new Padding(3, 2, 3, 2);
            numAccountId.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numAccountId.Name = "numAccountId";
            numAccountId.ReadOnly = true;
            numAccountId.Size = new Size(164, 29);
            numAccountId.TabIndex = 33;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Controls.Add(BtnUpdate);
            flowLayoutPanel1.Controls.Add(BtnRefresh);
            flowLayoutPanel1.Controls.Add(BtnClose);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(215, 355);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(512, 42);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboCategory);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtContact);
            panel1.Controls.Add(numAccountId);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(txtNewAccount);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(3, 137);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(724, 214);
            panel1.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.5911674F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.0755072F));
            tableLayoutPanel1.Size = new Size(730, 407);
            tableLayoutPanel1.TabIndex = 36;
            // 
            // AccountsSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 407);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AccountsSetup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Accounts Setup";
            FormClosing += AccountsSetup_FormClosing;
            Load += AccountsSetup_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAccountId).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}