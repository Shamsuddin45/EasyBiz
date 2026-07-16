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

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckedListBox clbFavorites;
        private CustomButton BtnSaveFavorites;
        private CustomButton btnUsersManagement;

        private DataGridView gridUsers;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewCheckBoxColumn colIsAdmin;
        private DataGridViewCheckBoxColumn colIsActive;

        private GroupBox grpAddUser;
        private Label label_newUsername;
        private TextBox txtNewUsername;
        private Label label_newPassword;
        private TextBox txtNewPassword;
        private Label label_newFullName;
        private TextBox txtNewFullName;
        private CheckBox chkNewIsAdmin;
        private CustomButton BtnAddUser;

        private GroupBox grpEditUser;
        private CheckBox chkEditIsAdmin;
        private CheckBox chkEditIsActive;
        private CustomButton BtnUpdateUser;
        private Label label_resetPassword;
        private TextBox txtResetPassword;
        private CustomButton BtnResetPassword;
        private CustomButton BtnDeleteUser;

        private GroupBox grpRights;
        private CheckedListBox clbUserRights;
        private CustomButton BtnSaveRights;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            label1 = new Label();
            comboBox1 = new ComboBox();
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
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(980, 640);
            tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.Transparent;
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(comboBox1);
            tabPage3.Controls.Add(btnUpdate);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(972, 607);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "General";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 116);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 4;
            label1.Text = "Sale receipt print";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Always ask", "Auto print", "Don't print" });
            comboBox1.Location = new Point(58, 139);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(238, 31);
            comboBox1.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(192, 0, 0);
            btnUpdate.BackgroundColor = Color.FromArgb(192, 0, 0);
            btnUpdate.BorderColor = Color.Transparent;
            btnUpdate.BorderRadius = 2;
            btnUpdate.BorderSize = 0;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(58, 226);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(153, 34);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.TextColor = Color.White;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BtnSaveFavorites);
            tabPage1.Controls.Add(clbFavorites);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(972, 607);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Favourites";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnSaveFavorites
            // 
            BtnSaveFavorites.BackColor = Color.LimeGreen;
            BtnSaveFavorites.BackgroundColor = Color.LimeGreen;
            BtnSaveFavorites.BorderColor = Color.Transparent;
            BtnSaveFavorites.BorderRadius = 10;
            BtnSaveFavorites.BorderSize = 0;
            BtnSaveFavorites.FlatAppearance.BorderSize = 0;
            BtnSaveFavorites.FlatStyle = FlatStyle.Flat;
            BtnSaveFavorites.ForeColor = Color.White;
            BtnSaveFavorites.Location = new Point(287, 486);
            BtnSaveFavorites.Name = "BtnSaveFavorites";
            BtnSaveFavorites.Size = new Size(133, 41);
            BtnSaveFavorites.TabIndex = 1;
            BtnSaveFavorites.Text = "Update";
            BtnSaveFavorites.TextColor = Color.White;
            BtnSaveFavorites.UseVisualStyleBackColor = false;
            BtnSaveFavorites.Click += btnSave_Click;
            // 
            // clbFavorites
            // 
            clbFavorites.BackColor = Color.WhiteSmoke;
            clbFavorites.BorderStyle = BorderStyle.None;
            clbFavorites.CheckOnClick = true;
            clbFavorites.Font = new Font("Segoe UI", 10F);
            clbFavorites.ForeColor = Color.DimGray;
            clbFavorites.FormattingEnabled = true;
            clbFavorites.Location = new Point(20, 20);
            clbFavorites.Name = "clbFavorites";
            clbFavorites.Size = new Size(400, 450);
            clbFavorites.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(gridUsers);
            tabPage2.Controls.Add(grpAddUser);
            tabPage2.Controls.Add(grpEditUser);
            tabPage2.Controls.Add(grpRights);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(972, 607);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Users Management";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridUsers
            // 
            gridUsers.AllowUserToAddRows = false;
            gridUsers.AllowUserToDeleteRows = false;
            gridUsers.AllowUserToResizeRows = false;
            gridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridUsers.ColumnHeadersHeight = 29;
            gridUsers.Columns.AddRange(new DataGridViewColumn[] { colUserId, colUsername, colFullName, colIsAdmin, colIsActive });
            gridUsers.Location = new Point(15, 15);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.ReadOnly = true;
            gridUsers.RowHeadersVisible = false;
            gridUsers.RowHeadersWidth = 51;
            gridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new Size(940, 200);
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
            grpAddUser.Controls.Add(label_newUsername);
            grpAddUser.Controls.Add(txtNewUsername);
            grpAddUser.Controls.Add(label_newPassword);
            grpAddUser.Controls.Add(txtNewPassword);
            grpAddUser.Controls.Add(label_newFullName);
            grpAddUser.Controls.Add(txtNewFullName);
            grpAddUser.Controls.Add(chkNewIsAdmin);
            grpAddUser.Controls.Add(BtnAddUser);
            grpAddUser.Location = new Point(15, 225);
            grpAddUser.Name = "grpAddUser";
            grpAddUser.Size = new Size(300, 260);
            grpAddUser.TabIndex = 1;
            grpAddUser.TabStop = false;
            grpAddUser.Text = "Add New User";
            // 
            // label_newUsername
            // 
            label_newUsername.AutoSize = true;
            label_newUsername.Location = new Point(15, 30);
            label_newUsername.Name = "label_newUsername";
            label_newUsername.Size = new Size(75, 20);
            label_newUsername.TabIndex = 0;
            label_newUsername.Text = "Username";
            // 
            // txtNewUsername
            // 
            txtNewUsername.Font = new Font("Segoe UI", 10.5F);
            txtNewUsername.Location = new Point(15, 52);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new Size(260, 31);
            txtNewUsername.TabIndex = 1;
            // 
            // label_newPassword
            // 
            label_newPassword.AutoSize = true;
            label_newPassword.Location = new Point(15, 88);
            label_newPassword.Name = "label_newPassword";
            label_newPassword.Size = new Size(70, 20);
            label_newPassword.TabIndex = 2;
            label_newPassword.Text = "Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 10.5F);
            txtNewPassword.Location = new Point(15, 110);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(260, 31);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label_newFullName
            // 
            label_newFullName.AutoSize = true;
            label_newFullName.Location = new Point(15, 146);
            label_newFullName.Name = "label_newFullName";
            label_newFullName.Size = new Size(76, 20);
            label_newFullName.TabIndex = 4;
            label_newFullName.Text = "Full Name";
            // 
            // txtNewFullName
            // 
            txtNewFullName.Font = new Font("Segoe UI", 10.5F);
            txtNewFullName.Location = new Point(15, 168);
            txtNewFullName.Name = "txtNewFullName";
            txtNewFullName.Size = new Size(260, 31);
            txtNewFullName.TabIndex = 5;
            // 
            // chkNewIsAdmin
            // 
            chkNewIsAdmin.AutoSize = true;
            chkNewIsAdmin.Location = new Point(15, 205);
            chkNewIsAdmin.Name = "chkNewIsAdmin";
            chkNewIsAdmin.Size = new Size(96, 24);
            chkNewIsAdmin.TabIndex = 6;
            chkNewIsAdmin.Text = "Is Admin?";
            // 
            // BtnAddUser
            // 
            BtnAddUser.BackColor = Color.ForestGreen;
            BtnAddUser.BackgroundColor = Color.ForestGreen;
            BtnAddUser.BorderColor = Color.Transparent;
            BtnAddUser.BorderRadius = 8;
            BtnAddUser.BorderSize = 0;
            BtnAddUser.FlatAppearance.BorderSize = 0;
            BtnAddUser.FlatStyle = FlatStyle.Flat;
            BtnAddUser.ForeColor = Color.White;
            BtnAddUser.Location = new Point(130, 202);
            BtnAddUser.Name = "BtnAddUser";
            BtnAddUser.Size = new Size(145, 36);
            BtnAddUser.TabIndex = 7;
            BtnAddUser.Text = "Add User";
            BtnAddUser.TextColor = Color.White;
            BtnAddUser.UseVisualStyleBackColor = false;
            BtnAddUser.Click += BtnAddUser_Click;
            // 
            // grpEditUser
            // 
            grpEditUser.Controls.Add(chkEditIsAdmin);
            grpEditUser.Controls.Add(chkEditIsActive);
            grpEditUser.Controls.Add(BtnUpdateUser);
            grpEditUser.Controls.Add(label_resetPassword);
            grpEditUser.Controls.Add(txtResetPassword);
            grpEditUser.Controls.Add(BtnResetPassword);
            grpEditUser.Controls.Add(BtnDeleteUser);
            grpEditUser.Location = new Point(330, 225);
            grpEditUser.Name = "grpEditUser";
            grpEditUser.Size = new Size(300, 260);
            grpEditUser.TabIndex = 2;
            grpEditUser.TabStop = false;
            grpEditUser.Text = "Edit Selected User";
            // 
            // chkEditIsAdmin
            // 
            chkEditIsAdmin.AutoSize = true;
            chkEditIsAdmin.Enabled = false;
            chkEditIsAdmin.Location = new Point(15, 30);
            chkEditIsAdmin.Name = "chkEditIsAdmin";
            chkEditIsAdmin.Size = new Size(96, 24);
            chkEditIsAdmin.TabIndex = 0;
            chkEditIsAdmin.Text = "Is Admin?";
            // 
            // chkEditIsActive
            // 
            chkEditIsActive.AutoSize = true;
            chkEditIsActive.Enabled = false;
            chkEditIsActive.Location = new Point(150, 30);
            chkEditIsActive.Name = "chkEditIsActive";
            chkEditIsActive.Size = new Size(93, 24);
            chkEditIsActive.TabIndex = 1;
            chkEditIsActive.Text = "Is Active?";
            // 
            // BtnUpdateUser
            // 
            BtnUpdateUser.BackColor = Color.FromArgb(52, 152, 219);
            BtnUpdateUser.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnUpdateUser.BorderColor = Color.Transparent;
            BtnUpdateUser.BorderRadius = 8;
            BtnUpdateUser.BorderSize = 0;
            BtnUpdateUser.Enabled = false;
            BtnUpdateUser.FlatAppearance.BorderSize = 0;
            BtnUpdateUser.FlatStyle = FlatStyle.Flat;
            BtnUpdateUser.ForeColor = Color.White;
            BtnUpdateUser.Location = new Point(15, 65);
            BtnUpdateUser.Name = "BtnUpdateUser";
            BtnUpdateUser.Size = new Size(260, 34);
            BtnUpdateUser.TabIndex = 2;
            BtnUpdateUser.Text = "Save Admin/Active flags";
            BtnUpdateUser.TextColor = Color.White;
            BtnUpdateUser.UseVisualStyleBackColor = false;
            BtnUpdateUser.Click += BtnUpdateUser_Click;
            // 
            // label_resetPassword
            // 
            label_resetPassword.AutoSize = true;
            label_resetPassword.Location = new Point(15, 112);
            label_resetPassword.Name = "label_resetPassword";
            label_resetPassword.Size = new Size(104, 20);
            label_resetPassword.TabIndex = 3;
            label_resetPassword.Text = "New Password";
            // 
            // txtResetPassword
            // 
            txtResetPassword.Font = new Font("Segoe UI", 10.5F);
            txtResetPassword.Location = new Point(15, 134);
            txtResetPassword.Name = "txtResetPassword";
            txtResetPassword.Size = new Size(260, 31);
            txtResetPassword.TabIndex = 4;
            txtResetPassword.UseSystemPasswordChar = true;
            // 
            // BtnResetPassword
            // 
            BtnResetPassword.BackColor = Color.DarkOrange;
            BtnResetPassword.BackgroundColor = Color.DarkOrange;
            BtnResetPassword.BorderColor = Color.Transparent;
            BtnResetPassword.BorderRadius = 8;
            BtnResetPassword.BorderSize = 0;
            BtnResetPassword.Enabled = false;
            BtnResetPassword.FlatAppearance.BorderSize = 0;
            BtnResetPassword.FlatStyle = FlatStyle.Flat;
            BtnResetPassword.ForeColor = Color.White;
            BtnResetPassword.Location = new Point(15, 170);
            BtnResetPassword.Name = "BtnResetPassword";
            BtnResetPassword.Size = new Size(260, 34);
            BtnResetPassword.TabIndex = 5;
            BtnResetPassword.Text = "Reset Password";
            BtnResetPassword.TextColor = Color.White;
            BtnResetPassword.UseVisualStyleBackColor = false;
            BtnResetPassword.Click += BtnResetPassword_Click;
            // 
            // BtnDeleteUser
            // 
            BtnDeleteUser.BackColor = Color.Firebrick;
            BtnDeleteUser.BackgroundColor = Color.Firebrick;
            BtnDeleteUser.BorderColor = Color.Transparent;
            BtnDeleteUser.BorderRadius = 8;
            BtnDeleteUser.BorderSize = 0;
            BtnDeleteUser.Enabled = false;
            BtnDeleteUser.FlatAppearance.BorderSize = 0;
            BtnDeleteUser.FlatStyle = FlatStyle.Flat;
            BtnDeleteUser.ForeColor = Color.White;
            BtnDeleteUser.Location = new Point(15, 210);
            BtnDeleteUser.Name = "BtnDeleteUser";
            BtnDeleteUser.Size = new Size(260, 34);
            BtnDeleteUser.TabIndex = 6;
            BtnDeleteUser.Text = "Delete User";
            BtnDeleteUser.TextColor = Color.White;
            BtnDeleteUser.UseVisualStyleBackColor = false;
            BtnDeleteUser.Click += BtnDeleteUser_Click;
            // 
            // grpRights
            // 
            grpRights.Controls.Add(clbUserRights);
            grpRights.Controls.Add(BtnSaveRights);
            grpRights.Location = new Point(645, 225);
            grpRights.Name = "grpRights";
            grpRights.Size = new Size(310, 370);
            grpRights.TabIndex = 3;
            grpRights.TabStop = false;
            grpRights.Text = "Module Rights (selected user)";
            // 
            // clbUserRights
            // 
            clbUserRights.CheckOnClick = true;
            clbUserRights.Enabled = false;
            clbUserRights.Font = new Font("Segoe UI", 9.5F);
            clbUserRights.FormattingEnabled = true;
            clbUserRights.Location = new Point(12, 25);
            clbUserRights.Name = "clbUserRights";
            clbUserRights.Size = new Size(286, 268);
            clbUserRights.TabIndex = 0;
            // 
            // BtnSaveRights
            // 
            BtnSaveRights.BackColor = Color.SeaGreen;
            BtnSaveRights.BackgroundColor = Color.SeaGreen;
            BtnSaveRights.BorderColor = Color.Transparent;
            BtnSaveRights.BorderRadius = 8;
            BtnSaveRights.BorderSize = 0;
            BtnSaveRights.Enabled = false;
            BtnSaveRights.FlatAppearance.BorderSize = 0;
            BtnSaveRights.FlatStyle = FlatStyle.Flat;
            BtnSaveRights.ForeColor = Color.White;
            BtnSaveRights.Location = new Point(12, 322);
            BtnSaveRights.Name = "BtnSaveRights";
            BtnSaveRights.Size = new Size(286, 36);
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
            btnUsersManagement.TabStop = false;
            btnUsersManagement.TextColor = Color.White;
            btnUsersManagement.UseVisualStyleBackColor = false;
            btnUsersManagement.Visible = false;
            btnUsersManagement.Click += btnUsersManagement_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 640);
            Controls.Add(tabControl1);
            Controls.Add(btnUsersManagement);
            MinimumSize = new Size(996, 679);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
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

        private TabPage tabPage3;
        private CustomButton btnUpdate;
        private Label label1;
        private ComboBox comboBox1;
    }
}