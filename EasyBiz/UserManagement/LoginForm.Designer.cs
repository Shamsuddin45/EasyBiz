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
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelBody = new Panel();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            lblError = new Label();
            BtnLogin = new CustomButton();
            BtnExit = new CustomButton();
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
            panelHeader.Size = new Size(420, 110);
            panelHeader.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "EasyBiz";
            //
            // lblSubtitle
            //
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10.2F);
            lblSubtitle.ForeColor = Color.FromArgb(220, 235, 250);
            lblSubtitle.Location = new Point(27, 76);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(150, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Please sign in to continue";
            //
            // panelBody
            //
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
            panelBody.Size = new Size(420, 290);
            panelBody.TabIndex = 1;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(27, 24);
            label1.Name = "label1";
            label1.Size = new Size(83, 23);
            label1.TabIndex = 0;
            label1.Text = "Username";
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
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(27, 98);
            label2.Name = "label2";
            label2.Size = new Size(77, 23);
            label2.TabIndex = 2;
            label2.Text = "Password";
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
            // chkShowPassword
            //
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9.5F);
            chkShowPassword.Location = new Point(27, 166);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(130, 27);
            chkShowPassword.TabIndex = 4;
            chkShowPassword.Text = "Show password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
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
            // LoginForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 400);
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
    }
}
