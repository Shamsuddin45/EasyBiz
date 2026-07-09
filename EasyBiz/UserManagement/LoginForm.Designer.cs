namespace EasyBiz
{
    partial class LoginForm
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
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelBody = new Panel();
            panel1 = new Panel();
            BtnExit = new CustomButton();
            BtnLogin = new CustomButton();
            lblError = new Label();
            chkShowPassword = new CheckBox();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            panelHeader.SuspendLayout();
            panelBody.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(735, 110);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10.2F);
            lblSubtitle.ForeColor = Color.FromArgb(220, 235, 250);
            lblSubtitle.Location = new Point(27, 76);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(206, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Please sign in to continue";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(151, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "EasyBiz";
            // 
            // panelBody
            // 
            panelBody.Controls.Add(panel1);
            panelBody.Controls.Add(BtnExit);
            panelBody.Controls.Add(BtnLogin);
            panelBody.Controls.Add(lblError);
            panelBody.Controls.Add(chkShowPassword);
            panelBody.Controls.Add(txtPassword);
            panelBody.Controls.Add(label2);
            panelBody.Controls.Add(txtUsername);
            panelBody.Controls.Add(label1);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 110);
            panelBody.Name = "panelBody";
            panelBody.Padding = new Padding(24);
            panelBody.Size = new Size(735, 320);
            panelBody.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.login;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Location = new Point(502, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(206, 185);
            panel1.TabIndex = 8;
            // 
            // BtnExit
            // 
            BtnExit.BackColor = Color.Tomato;
            BtnExit.BackgroundColor = Color.Tomato;
            BtnExit.BorderColor = Color.Transparent;
            BtnExit.BorderRadius = 8;
            BtnExit.BorderSize = 0;
            BtnExit.FlatAppearance.BorderSize = 0;
            BtnExit.FlatStyle = FlatStyle.Flat;
            BtnExit.Font = new Font("Segoe UI", 11F);
            BtnExit.ForeColor = Color.White;
            BtnExit.Location = new Point(213, 232);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(180, 46);
            BtnExit.TabIndex = 7;
            BtnExit.Text = "Exit";
            BtnExit.TextColor = Color.White;
            BtnExit.UseVisualStyleBackColor = false;
            BtnExit.Click += BtnExit_Click;
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.FromArgb(41, 128, 185);
            BtnLogin.BackgroundColor = Color.FromArgb(41, 128, 185);
            BtnLogin.BorderColor = Color.Transparent;
            BtnLogin.BorderRadius = 8;
            BtnLogin.BorderSize = 0;
            BtnLogin.FlatAppearance.BorderSize = 0;
            BtnLogin.FlatStyle = FlatStyle.Flat;
            BtnLogin.Font = new Font("Segoe UI", 11F);
            BtnLogin.ForeColor = Color.White;
            BtnLogin.Location = new Point(27, 232);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(180, 46);
            BtnLogin.TabIndex = 6;
            BtnLogin.Text = "Login";
            BtnLogin.TextColor = Color.White;
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(27, 200);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 21);
            lblError.TabIndex = 5;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9.5F);
            chkShowPassword.Location = new Point(27, 166);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(142, 25);
            chkShowPassword.TabIndex = 4;
            chkShowPassword.Text = "Show password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(27, 124);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(366, 34);
            txtPassword.TabIndex = 3;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(27, 98);
            label2.Name = "label2";
            label2.Size = new Size(80, 23);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(27, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(366, 34);
            txtUsername.TabIndex = 1;
            txtUsername.KeyDown += txtUsername_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(27, 24);
            label1.Name = "label1";
            label1.Size = new Size(87, 23);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(735, 430);
            Controls.Add(panelBody);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EasyBiz - Login";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelBody;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Label lblError;
        private CustomButton BtnLogin;
        private CustomButton BtnExit;
        private Panel panel1;
    }
}
