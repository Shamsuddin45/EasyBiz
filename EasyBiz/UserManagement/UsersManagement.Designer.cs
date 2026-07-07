namespace EasyBiz
{
    partial class UsersManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelForm = new Panel();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            comboRole = new ComboBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtConfirmPassword = new TextBox();
            BtnAdd = new CustomButton();
            BtnUpdate = new CustomButton();
            BtnResetPassword = new CustomButton();
            BtnToggleActive = new CustomButton();
            BtnClear = new CustomButton();
            dataGridView1 = new DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colActive = new DataGridViewTextBoxColumn();
            colLastLogin = new DataGridViewTextBoxColumn();
            colCreated = new DataGridViewTextBoxColumn();
            BtnClose = new CustomButton();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // panelForm
            //
            panelForm.BackColor = Color.WhiteSmoke;
            panelForm.Controls.Add(BtnClear);
            panelForm.Controls.Add(BtnToggleActive);
            panelForm.Controls.Add(BtnResetPassword);
            panelForm.Controls.Add(BtnUpdate);
            panelForm.Controls.Add(BtnAdd);
            panelForm.Controls.Add(txtConfirmPassword);
            panelForm.Controls.Add(label5);
            panelForm.Controls.Add(txtPassword);
            panelForm.Controls.Add(label4);
            panelForm.Controls.Add(comboRole);
            panelForm.Controls.Add(label3);
            panelForm.Controls.Add(txtFullName);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(txtUsername);
            panelForm.Controls.Add(label1);
            panelForm.Dock = DockStyle.Top;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Padding = new Padding(16);
            panelForm.Size = new Size(1000, 190);
            panelForm.TabIndex = 0;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(83, 23);
            label1.TabIndex = 0;
            label1.Text = "Username";
            //
            // txtUsername
            //
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(20, 46);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 34);
            txtUsername.TabIndex = 1;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(256, 20);
            label2.Name = "label2";
            label2.Size = new Size(80, 23);
            label2.TabIndex = 2;
            label2.Text = "Full Name";
            //
            // txtFullName
            //
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(256, 46);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(260, 34);
            txtFullName.TabIndex = 2;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(532, 20);
            label3.Name = "label3";
            label3.Size = new Size(43, 23);
            label3.TabIndex = 4;
            label3.Text = "Role";
            //
            // comboRole
            //
            comboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRole.Font = new Font("Segoe UI", 12F);
            comboRole.FormattingEnabled = true;
            comboRole.Location = new Point(532, 46);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(150, 36);
            comboRole.TabIndex = 3;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(20, 90);
            label4.Name = "label4";
            label4.Size = new Size(180, 23);
            label4.TabIndex = 6;
            label4.Text = "Password (new user / reset)";
            //
            // txtPassword
            //
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(20, 116);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(220, 34);
            txtPassword.TabIndex = 4;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(256, 90);
            label5.Name = "label5";
            label5.Size = new Size(130, 23);
            label5.TabIndex = 8;
            label5.Text = "Confirm Password";
            //
            // txtConfirmPassword
            //
            txtConfirmPassword.Font = new Font("Segoe UI", 12F);
            txtConfirmPassword.Location = new Point(256, 116);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(260, 34);
            txtConfirmPassword.TabIndex = 5;
            //
            // BtnAdd
            //
            BtnAdd.BackColor = Color.LimeGreen;
            BtnAdd.BackgroundColor = Color.LimeGreen;
            BtnAdd.BorderColor = Color.Transparent;
            BtnAdd.BorderRadius = 8;
            BtnAdd.BorderSize = 0;
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnAdd.FlatStyle = FlatStyle.Flat;
            BtnAdd.Font = new Font("Segoe UI", 9.5F);
            BtnAdd.ForeColor = Color.White;
            BtnAdd.Location = new Point(532, 100);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(140, 44);
            BtnAdd.TabIndex = 6;
            BtnAdd.Text = "Add User";
            BtnAdd.TextColor = Color.White;
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
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
            BtnUpdate.Font = new Font("Segoe UI", 9.5F);
            BtnUpdate.ForeColor = Color.White;
            BtnUpdate.Location = new Point(682, 100);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(140, 44);
            BtnUpdate.TabIndex = 7;
            BtnUpdate.Text = "Update Details";
            BtnUpdate.TextColor = Color.White;
            BtnUpdate.UseVisualStyleBackColor = false;
            BtnUpdate.Click += BtnUpdate_Click;
            //
            // BtnResetPassword
            //
            BtnResetPassword.BackColor = Color.FromArgb(52, 152, 219);
            BtnResetPassword.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnResetPassword.BorderColor = Color.Transparent;
            BtnResetPassword.BorderRadius = 8;
            BtnResetPassword.BorderSize = 0;
            BtnResetPassword.Enabled = false;
            BtnResetPassword.FlatAppearance.BorderSize = 0;
            BtnResetPassword.FlatStyle = FlatStyle.Flat;
            BtnResetPassword.Font = new Font("Segoe UI", 9.5F);
            BtnResetPassword.ForeColor = Color.White;
            BtnResetPassword.Location = new Point(832, 100);
            BtnResetPassword.Name = "BtnResetPassword";
            BtnResetPassword.Size = new Size(140, 44);
            BtnResetPassword.TabIndex = 8;
            BtnResetPassword.Text = "Reset Password";
            BtnResetPassword.TextColor = Color.White;
            BtnResetPassword.UseVisualStyleBackColor = false;
            BtnResetPassword.Click += BtnResetPassword_Click;
            //
            // BtnToggleActive
            //
            BtnToggleActive.BackColor = Color.Tomato;
            BtnToggleActive.BackgroundColor = Color.Tomato;
            BtnToggleActive.BorderColor = Color.Transparent;
            BtnToggleActive.BorderRadius = 8;
            BtnToggleActive.BorderSize = 0;
            BtnToggleActive.Enabled = false;
            BtnToggleActive.FlatAppearance.BorderSize = 0;
            BtnToggleActive.FlatStyle = FlatStyle.Flat;
            BtnToggleActive.Font = new Font("Segoe UI", 9.5F);
            BtnToggleActive.ForeColor = Color.White;
            BtnToggleActive.Location = new Point(532, 150);
            BtnToggleActive.Name = "BtnToggleActive";
            BtnToggleActive.Size = new Size(220, 30);
            BtnToggleActive.TabIndex = 9;
            BtnToggleActive.Text = "Deactivate / Activate";
            BtnToggleActive.TextColor = Color.White;
            BtnToggleActive.UseVisualStyleBackColor = false;
            BtnToggleActive.Click += BtnToggleActive_Click;
            //
            // BtnClear
            //
            BtnClear.BackColor = Color.Gray;
            BtnClear.BackgroundColor = Color.Gray;
            BtnClear.BorderColor = Color.Transparent;
            BtnClear.BorderRadius = 8;
            BtnClear.BorderSize = 0;
            BtnClear.FlatAppearance.BorderSize = 0;
            BtnClear.FlatStyle = FlatStyle.Flat;
            BtnClear.Font = new Font("Segoe UI", 9.5F);
            BtnClear.ForeColor = Color.White;
            BtnClear.Location = new Point(758, 150);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(214, 30);
            BtnClear.TabIndex = 10;
            BtnClear.Text = "Clear / New User";
            BtnClear.TextColor = Color.White;
            BtnClear.UseVisualStyleBackColor = false;
            BtnClear.Click += BtnClear_Click;
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 42;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colUserId, colUsername, colFullName, colRole, colActive, colLastLogin, colCreated });
            dataGridViewCellStyle2.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(0, 190);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1000, 400);
            dataGridView1.TabIndex = 1;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
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
            // colRole
            //
            colRole.HeaderText = "Role";
            colRole.MinimumWidth = 6;
            colRole.Name = "colRole";
            colRole.ReadOnly = true;
            //
            // colActive
            //
            colActive.HeaderText = "Status";
            colActive.MinimumWidth = 6;
            colActive.Name = "colActive";
            colActive.ReadOnly = true;
            //
            // colLastLogin
            //
            colLastLogin.HeaderText = "Last Login";
            colLastLogin.MinimumWidth = 6;
            colLastLogin.Name = "colLastLogin";
            colLastLogin.ReadOnly = true;
            //
            // colCreated
            //
            colCreated.HeaderText = "Created";
            colCreated.MinimumWidth = 6;
            colCreated.Name = "colCreated";
            colCreated.ReadOnly = true;
            //
            // BtnClose
            //
            BtnClose.BackColor = Color.FromArgb(192, 64, 0);
            BtnClose.BackgroundColor = Color.FromArgb(192, 64, 0);
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 8;
            BtnClose.BorderSize = 0;
            BtnClose.Dock = DockStyle.Bottom;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 10.2F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(0, 590);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(1000, 50);
            BtnClose.TabIndex = 2;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            //
            // UsersManagement
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 640);
            Controls.Add(dataGridView1);
            Controls.Add(BtnClose);
            Controls.Add(panelForm);
            MinimizeBox = false;
            Name = "UsersManagement";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Management";
            Load += UsersManagement_Load;
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private Panel panelForm;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtFullName;
        private Label label3;
        private ComboBox comboRole;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtConfirmPassword;
        private CustomButton BtnAdd;
        private CustomButton BtnUpdate;
        private CustomButton BtnResetPassword;
        private CustomButton BtnToggleActive;
        private CustomButton BtnClear;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colActive;
        private DataGridViewTextBoxColumn colLastLogin;
        private DataGridViewTextBoxColumn colCreated;
        private CustomButton BtnClose;
    }
}
