namespace EasyBiz
{
    partial class Settings
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

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckedListBox clbFavorites;
        private CustomButton BtnSaveFavorites;
        private CustomButton btnUsersManagement;

        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsAdmin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsActive;

        private System.Windows.Forms.GroupBox grpAddUser;
        private System.Windows.Forms.Label label_newUsername;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.Label label_newPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label_newFullName;
        private System.Windows.Forms.TextBox txtNewFullName;
        private System.Windows.Forms.CheckBox chkNewIsAdmin;
        private CustomButton BtnAddUser;

        private System.Windows.Forms.GroupBox grpEditUser;
        private System.Windows.Forms.CheckBox chkEditIsAdmin;
        private System.Windows.Forms.CheckBox chkEditIsActive;
        private CustomButton BtnUpdateUser;
        private System.Windows.Forms.Label label_resetPassword;
        private System.Windows.Forms.TextBox txtResetPassword;
        private CustomButton BtnResetPassword;
        private CustomButton BtnDeleteUser;

        private System.Windows.Forms.GroupBox grpRights;
        private System.Windows.Forms.CheckedListBox clbUserRights;
        private CustomButton BtnSaveRights;

        private CustomButton btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboInWordsSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboPrintSaleReceipt;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            label2 = new Label();
            comboPrintSaleReceipt = new ComboBox();
            label1 = new Label();
            comboInWordsSettings = new ComboBox();
            btnUpdate = new CustomButton();
            tabPage1 = new TabPage();
            BtnSaveFavorites = new CustomButton();
            clbFavorites = new CheckedListBox();
            tabPage2 = new TabPage();
            gridUsers = new DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colIsAdmin = new DataGridViewCheckBoxColumn();
            colIsActive = new DataGridViewCheckBoxColumn();
            grpAddUser = new GroupBox();
            label_newUsername = new Label();
            txtNewUsername = new TextBox();
            label_newPassword = new Label();
            txtNewPassword = new TextBox();
            label_newFullName = new Label();
            txtNewFullName = new TextBox();
            chkNewIsAdmin = new CheckBox();
            BtnAddUser = new CustomButton();
            grpEditUser = new GroupBox();
            chkEditIsAdmin = new CheckBox();
            chkEditIsActive = new CheckBox();
            BtnUpdateUser = new CustomButton();
            label_resetPassword = new Label();
            txtResetPassword = new TextBox();
            BtnResetPassword = new CustomButton();
            BtnDeleteUser = new CustomButton();
            grpRights = new GroupBox();
            clbUserRights = new CheckedListBox();
            BtnSaveRights = new CustomButton();
            btnUsersManagement = new CustomButton();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            grpAddUser.SuspendLayout();
            grpEditUser.SuspendLayout();
            grpRights.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(15, 8);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(980, 632);
            tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(comboPrintSaleReceipt);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(comboInWordsSettings);
            tabPage3.Controls.Add(btnUpdate);
            tabPage3.Location = new Point(4, 42);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(30);
            tabPage3.Size = new Size(972, 746);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "General";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(33, 130);
            label2.Name = "label2";
            label2.Size = new Size(137, 23);
            label2.TabIndex = 6;
            label2.Text = "Print sale receipt";
            // 
            // comboPrintSaleReceipt
            // 
            comboPrintSaleReceipt.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPrintSaleReceipt.FormattingEnabled = true;
            comboPrintSaleReceipt.Items.AddRange(new object[] { "Auto print", "Do not print", "Always ask" });
            comboPrintSaleReceipt.Location = new Point(33, 156);
            comboPrintSaleReceipt.Name = "comboPrintSaleReceipt";
            comboPrintSaleReceipt.Size = new Size(350, 31);
            comboPrintSaleReceipt.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(33, 40);
            label1.Name = "label1";
            label1.Size = new Size(185, 23);
            label1.TabIndex = 4;
            label1.Text = "Show amount in words";
            // 
            // comboInWordsSettings
            // 
            comboInWordsSettings.DropDownStyle = ComboBoxStyle.DropDownList;
            comboInWordsSettings.FormattingEnabled = true;
            comboInWordsSettings.Items.AddRange(new object[] { "Off", "English", "Sindhi" });
            comboInWordsSettings.Location = new Point(33, 66);
            comboInWordsSettings.Name = "comboInWordsSettings";
            comboInWordsSettings.Size = new Size(350, 31);
            comboInWordsSettings.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(41, 128, 185);
            btnUpdate.BackgroundColor = Color.FromArgb(41, 128, 185);
            btnUpdate.BorderColor = Color.Transparent;
            btnUpdate.BorderRadius = 4;
            btnUpdate.BorderSize = 0;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(33, 220);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 40);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Save Settings";
            btnUpdate.TextColor = Color.White;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(BtnSaveFavorites);
            tabPage1.Controls.Add(clbFavorites);
            tabPage1.Location = new Point(4, 42);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(20);
            tabPage1.Size = new Size(972, 746);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Favourites";
            // 
            // BtnSaveFavorites
            // 
            BtnSaveFavorites.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSaveFavorites.BackColor = Color.FromArgb(39, 174, 96);
            BtnSaveFavorites.BackgroundColor = Color.FromArgb(39, 174, 96);
            BtnSaveFavorites.BorderColor = Color.Transparent;
            BtnSaveFavorites.BorderRadius = 4;
            BtnSaveFavorites.BorderSize = 0;
            BtnSaveFavorites.FlatAppearance.BorderSize = 0;
            BtnSaveFavorites.FlatStyle = FlatStyle.Flat;
            BtnSaveFavorites.ForeColor = Color.White;
            BtnSaveFavorites.Location = new Point(799, 526);
            BtnSaveFavorites.Name = "BtnSaveFavorites";
            BtnSaveFavorites.Size = new Size(150, 42);
            BtnSaveFavorites.TabIndex = 1;
            BtnSaveFavorites.Text = "Save Favourites";
            BtnSaveFavorites.TextColor = Color.White;
            BtnSaveFavorites.UseVisualStyleBackColor = false;
            BtnSaveFavorites.Click += btnSave_Click;
            // 
            // clbFavorites
            // 
            clbFavorites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbFavorites.BackColor = Color.White;
            clbFavorites.BorderStyle = BorderStyle.FixedSingle;
            clbFavorites.CheckOnClick = true;
            clbFavorites.ForeColor = Color.FromArgb(64, 64, 64);
            clbFavorites.FormattingEnabled = true;
            clbFavorites.Location = new Point(23, 23);
            clbFavorites.Name = "clbFavorites";
            clbFavorites.Size = new Size(926, 477);
            clbFavorites.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(gridUsers);
            tabPage2.Controls.Add(grpAddUser);
            tabPage2.Controls.Add(grpEditUser);
            tabPage2.Controls.Add(grpRights);
            tabPage2.Location = new Point(4, 42);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(15);
            tabPage2.Size = new Size(972, 586);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Users Management";
            // 
            // gridUsers
            // 
            gridUsers.AllowUserToAddRows = false;
            gridUsers.AllowUserToDeleteRows = false;
            gridUsers.AllowUserToResizeRows = false;
            gridUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridUsers.BackgroundColor = Color.White;
            gridUsers.BorderStyle = BorderStyle.Fixed3D;
            gridUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridUsers.ColumnHeadersHeight = 40;
            gridUsers.Columns.AddRange(new DataGridViewColumn[] { colUserId, colUsername, colFullName, colIsAdmin, colIsActive });
            gridUsers.EnableHeadersVisualStyles = false;
            gridUsers.Location = new Point(18, 18);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.ReadOnly = true;
            gridUsers.RowHeadersVisible = false;
            gridUsers.RowHeadersWidth = 51;
            gridUsers.RowTemplate.Height = 35;
            gridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new Size(936, 210);
            gridUsers.TabIndex = 0;
            gridUsers.SelectionChanged += gridUsers_SelectionChanged;
            // 
            // colUserId
            // 
            colUserId.HeaderText = "ID";
            colUserId.MinimumWidth = 6;
            colUserId.Name = "colUserId";
            colUserId.ReadOnly = true;
            colUserId.Visible = false;
            // 
            // colUsername
            // 
            colUsername.HeaderText = "Username";
            colUsername.MinimumWidth = 6;
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Full Name";
            colFullName.MinimumWidth = 6;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colIsAdmin
            // 
            colIsAdmin.HeaderText = "Admin";
            colIsAdmin.MinimumWidth = 6;
            colIsAdmin.Name = "colIsAdmin";
            colIsAdmin.ReadOnly = true;
            // 
            // colIsActive
            // 
            colIsActive.HeaderText = "Active";
            colIsActive.MinimumWidth = 6;
            colIsActive.Name = "colIsActive";
            colIsActive.ReadOnly = true;
            // 
            // grpAddUser
            // 
            grpAddUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAddUser.Controls.Add(label_newUsername);
            grpAddUser.Controls.Add(txtNewUsername);
            grpAddUser.Controls.Add(label_newPassword);
            grpAddUser.Controls.Add(txtNewPassword);
            grpAddUser.Controls.Add(label_newFullName);
            grpAddUser.Controls.Add(txtNewFullName);
            grpAddUser.Controls.Add(chkNewIsAdmin);
            grpAddUser.Controls.Add(BtnAddUser);
            grpAddUser.Location = new Point(18, 235);
            grpAddUser.Name = "grpAddUser";
            grpAddUser.Size = new Size(305, 300);
            grpAddUser.TabIndex = 1;
            grpAddUser.TabStop = false;
            grpAddUser.Text = "Add New User";
            // 
            // label_newUsername
            // 
            label_newUsername.AutoSize = true;
            label_newUsername.Location = new Point(16, 25);
            label_newUsername.Name = "label_newUsername";
            label_newUsername.Size = new Size(87, 23);
            label_newUsername.TabIndex = 0;
            label_newUsername.Text = "Username";
            // 
            // txtNewUsername
            // 
            txtNewUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewUsername.Location = new Point(20, 50);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new Size(265, 30);
            txtNewUsername.TabIndex = 1;
            // 
            // label_newPassword
            // 
            label_newPassword.AutoSize = true;
            label_newPassword.Location = new Point(16, 85);
            label_newPassword.Name = "label_newPassword";
            label_newPassword.Size = new Size(80, 23);
            label_newPassword.TabIndex = 2;
            label_newPassword.Text = "Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPassword.Location = new Point(20, 110);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(265, 30);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label_newFullName
            // 
            label_newFullName.AutoSize = true;
            label_newFullName.Location = new Point(16, 145);
            label_newFullName.Name = "label_newFullName";
            label_newFullName.Size = new Size(87, 23);
            label_newFullName.TabIndex = 4;
            label_newFullName.Text = "Full Name";
            // 
            // txtNewFullName
            // 
            txtNewFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewFullName.Location = new Point(20, 170);
            txtNewFullName.Name = "txtNewFullName";
            txtNewFullName.Size = new Size(265, 30);
            txtNewFullName.TabIndex = 5;
            // 
            // chkNewIsAdmin
            // 
            chkNewIsAdmin.AutoSize = true;
            chkNewIsAdmin.Location = new Point(20, 225);
            chkNewIsAdmin.Name = "chkNewIsAdmin";
            chkNewIsAdmin.Size = new Size(107, 27);
            chkNewIsAdmin.TabIndex = 6;
            chkNewIsAdmin.Text = "Is Admin?";
            // 
            // BtnAddUser
            // 
            BtnAddUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnAddUser.BackColor = Color.FromArgb(39, 174, 96);
            BtnAddUser.BackgroundColor = Color.FromArgb(39, 174, 96);
            BtnAddUser.BorderColor = Color.Transparent;
            BtnAddUser.BorderRadius = 4;
            BtnAddUser.BorderSize = 0;
            BtnAddUser.FlatStyle = FlatStyle.Flat;
            BtnAddUser.ForeColor = Color.White;
            BtnAddUser.Location = new Point(140, 220);
            BtnAddUser.Name = "BtnAddUser";
            BtnAddUser.Size = new Size(145, 40);
            BtnAddUser.TabIndex = 7;
            BtnAddUser.Text = "Add User";
            BtnAddUser.TextColor = Color.White;
            BtnAddUser.UseVisualStyleBackColor = false;
            BtnAddUser.Click += BtnAddUser_Click;
            // 
            // grpEditUser
            // 
            grpEditUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpEditUser.Controls.Add(chkEditIsAdmin);
            grpEditUser.Controls.Add(chkEditIsActive);
            grpEditUser.Controls.Add(BtnUpdateUser);
            grpEditUser.Controls.Add(label_resetPassword);
            grpEditUser.Controls.Add(txtResetPassword);
            grpEditUser.Controls.Add(BtnResetPassword);
            grpEditUser.Controls.Add(BtnDeleteUser);
            grpEditUser.Location = new Point(335, 235);
            grpEditUser.Name = "grpEditUser";
            grpEditUser.Size = new Size(305, 300);
            grpEditUser.TabIndex = 2;
            grpEditUser.TabStop = false;
            grpEditUser.Text = "Edit Selected User";
            // 
            // chkEditIsAdmin
            // 
            chkEditIsAdmin.AutoSize = true;
            chkEditIsAdmin.Location = new Point(20, 35);
            chkEditIsAdmin.Name = "chkEditIsAdmin";
            chkEditIsAdmin.Size = new Size(107, 27);
            chkEditIsAdmin.TabIndex = 0;
            chkEditIsAdmin.Text = "Is Admin?";
            // 
            // chkEditIsActive
            // 
            chkEditIsActive.AutoSize = true;
            chkEditIsActive.Location = new Point(150, 35);
            chkEditIsActive.Name = "chkEditIsActive";
            chkEditIsActive.Size = new Size(103, 27);
            chkEditIsActive.TabIndex = 1;
            chkEditIsActive.Text = "Is Active?";
            // 
            // BtnUpdateUser
            // 
            BtnUpdateUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnUpdateUser.BackColor = Color.FromArgb(41, 128, 185);
            BtnUpdateUser.BackgroundColor = Color.FromArgb(41, 128, 185);
            BtnUpdateUser.BorderColor = Color.Transparent;
            BtnUpdateUser.BorderRadius = 4;
            BtnUpdateUser.BorderSize = 0;
            BtnUpdateUser.FlatStyle = FlatStyle.Flat;
            BtnUpdateUser.ForeColor = Color.White;
            BtnUpdateUser.Location = new Point(20, 70);
            BtnUpdateUser.Name = "BtnUpdateUser";
            BtnUpdateUser.Size = new Size(265, 40);
            BtnUpdateUser.TabIndex = 2;
            BtnUpdateUser.Text = "Save Admin/Active flags";
            BtnUpdateUser.TextColor = Color.White;
            BtnUpdateUser.UseVisualStyleBackColor = false;
            BtnUpdateUser.Click += BtnUpdateUser_Click;
            // 
            // label_resetPassword
            // 
            label_resetPassword.AutoSize = true;
            label_resetPassword.Location = new Point(16, 120);
            label_resetPassword.Name = "label_resetPassword";
            label_resetPassword.Size = new Size(119, 23);
            label_resetPassword.TabIndex = 3;
            label_resetPassword.Text = "New Password";
            // 
            // txtResetPassword
            // 
            txtResetPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtResetPassword.Location = new Point(20, 145);
            txtResetPassword.Name = "txtResetPassword";
            txtResetPassword.Size = new Size(265, 30);
            txtResetPassword.TabIndex = 4;
            txtResetPassword.UseSystemPasswordChar = true;
            // 
            // BtnResetPassword
            // 
            BtnResetPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnResetPassword.BackColor = Color.FromArgb(230, 126, 34);
            BtnResetPassword.BackgroundColor = Color.FromArgb(230, 126, 34);
            BtnResetPassword.BorderColor = Color.Transparent;
            BtnResetPassword.BorderRadius = 4;
            BtnResetPassword.BorderSize = 0;
            BtnResetPassword.FlatStyle = FlatStyle.Flat;
            BtnResetPassword.ForeColor = Color.White;
            BtnResetPassword.Location = new Point(20, 185);
            BtnResetPassword.Name = "BtnResetPassword";
            BtnResetPassword.Size = new Size(265, 40);
            BtnResetPassword.TabIndex = 5;
            BtnResetPassword.Text = "Reset Password";
            BtnResetPassword.TextColor = Color.White;
            BtnResetPassword.UseVisualStyleBackColor = false;
            BtnResetPassword.Click += BtnResetPassword_Click;
            // 
            // BtnDeleteUser
            // 
            BtnDeleteUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BtnDeleteUser.BackColor = Color.FromArgb(231, 76, 60);
            BtnDeleteUser.BackgroundColor = Color.FromArgb(231, 76, 60);
            BtnDeleteUser.BorderColor = Color.Transparent;
            BtnDeleteUser.BorderRadius = 4;
            BtnDeleteUser.BorderSize = 0;
            BtnDeleteUser.FlatStyle = FlatStyle.Flat;
            BtnDeleteUser.ForeColor = Color.White;
            BtnDeleteUser.Location = new Point(20, 240);
            BtnDeleteUser.Name = "BtnDeleteUser";
            BtnDeleteUser.Size = new Size(265, 40);
            BtnDeleteUser.TabIndex = 6;
            BtnDeleteUser.Text = "Delete User";
            BtnDeleteUser.TextColor = Color.White;
            BtnDeleteUser.UseVisualStyleBackColor = false;
            BtnDeleteUser.Click += BtnDeleteUser_Click;
            // 
            // grpRights
            // 
            grpRights.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grpRights.Controls.Add(clbUserRights);
            grpRights.Controls.Add(BtnSaveRights);
            grpRights.Location = new Point(650, 235);
            grpRights.Name = "grpRights";
            grpRights.Size = new Size(305, 300);
            grpRights.TabIndex = 3;
            grpRights.TabStop = false;
            grpRights.Text = "Module Rights (selected user)";
            // 
            // clbUserRights
            // 
            clbUserRights.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbUserRights.BorderStyle = BorderStyle.FixedSingle;
            clbUserRights.CheckOnClick = true;
            clbUserRights.FormattingEnabled = true;
            clbUserRights.Location = new Point(20, 35);
            clbUserRights.Name = "clbUserRights";
            clbUserRights.Size = new Size(265, 177);
            clbUserRights.TabIndex = 0;
            // 
            // BtnSaveRights
            // 
            BtnSaveRights.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnSaveRights.BackColor = Color.FromArgb(46, 204, 113);
            BtnSaveRights.BackgroundColor = Color.FromArgb(46, 204, 113);
            BtnSaveRights.BorderColor = Color.Transparent;
            BtnSaveRights.BorderRadius = 4;
            BtnSaveRights.BorderSize = 0;
            BtnSaveRights.FlatStyle = FlatStyle.Flat;
            BtnSaveRights.ForeColor = Color.White;
            BtnSaveRights.Location = new Point(20, 240);
            BtnSaveRights.Name = "BtnSaveRights";
            BtnSaveRights.Size = new Size(265, 40);
            BtnSaveRights.TabIndex = 1;
            BtnSaveRights.Text = "Save Rights";
            BtnSaveRights.TextColor = Color.White;
            BtnSaveRights.UseVisualStyleBackColor = false;
            BtnSaveRights.Click += BtnSaveRights_Click;
            // 
            // btnUsersManagement
            // 
            btnUsersManagement.BackColor = Color.FromArgb(52, 152, 219);
            btnUsersManagement.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnUsersManagement.BorderColor = Color.Transparent;
            btnUsersManagement.BorderRadius = 1;
            btnUsersManagement.BorderSize = 0;
            btnUsersManagement.FlatStyle = FlatStyle.Flat;
            btnUsersManagement.ForeColor = Color.White;
            btnUsersManagement.Location = new Point(0, 0);
            btnUsersManagement.Name = "btnUsersManagement";
            btnUsersManagement.Size = new Size(1, 1);
            btnUsersManagement.TabIndex = 99;
            btnUsersManagement.TextColor = Color.White;
            btnUsersManagement.UseVisualStyleBackColor = false;
            btnUsersManagement.Visible = false;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(980, 632);
            Controls.Add(tabControl1);
            Controls.Add(btnUsersManagement);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(996, 679);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings - EasyBiz";
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            grpAddUser.ResumeLayout(false);
            grpAddUser.PerformLayout();
            grpEditUser.ResumeLayout(false);
            grpEditUser.PerformLayout();
            grpRights.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}