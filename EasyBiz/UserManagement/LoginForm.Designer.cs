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

        private Label lblTitle;
        private Label lblSubtitle;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Label lblError;
        private CustomButton BtnLogin;
        private CustomButton BtnExit;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            chkShowPassword = new CheckBox();
            lblError = new Label();
            BtnLogin = new CustomButton();
            BtnExit = new CustomButton();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.MidnightBlue;
            lblTitle.Location = new Point(40, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "EasyBiz";
            //
            // lblSubtitle
            //
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10.2F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(43, 76);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(140, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Sign in to continue";
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(40, 120);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 2;
            label1.Text = "Username";
            //
            // txtUsername
            //
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(40, 148);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(320, 34);
            txtUsername.TabIndex = 0;
            txtUsername.KeyDown += txtUsername_KeyDown;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(40, 192);
            label2.Name = "label2";
            label2.Size = new Size(85, 23);
            label2.TabIndex = 4;
            label2.Text = "Password";
            //
            // txtPassword
            //
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(40, 220);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 34);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txtPassword_KeyDown;
            //
            // chkShowPassword
            //
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.Location = new Point(40, 260);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(130, 24);
            chkShowPassword.TabIndex = 2;
            chkShowPassword.Text = "Show password";
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            //
            // lblError
            //
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(40, 292);
            lblError.MaximumSize = new Size(320, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(320, 20);
            lblError.TabIndex = 5;
            lblError.Visible = false;
            //
            // BtnLogin
            //
            BtnLogin.BackColor = Color.FromArgb(52, 152, 219);
            BtnLogin.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnLogin.BorderColor = Color.Transparent;
            BtnLogin.BorderRadius = 8;
            BtnLogin.BorderSize = 0;
            BtnLogin.FlatAppearance.BorderSize = 0;
            BtnLogin.FlatStyle = FlatStyle.Flat;
            BtnLogin.Font = new Font("Segoe UI", 10.2F);
            BtnLogin.ForeColor = Color.White;
            BtnLogin.Location = new Point(40, 330);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(150, 45);
            BtnLogin.TabIndex = 3;
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
            BtnExit.Font = new Font("Segoe UI", 10.2F);
            BtnExit.ForeColor = Color.White;
            BtnExit.Location = new Point(210, 330);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(150, 45);
            BtnExit.TabIndex = 4;
            BtnExit.Text = "Exit (Esc)";
            BtnExit.TextColor = Color.White;
            BtnExit.UseVisualStyleBackColor = false;
            BtnExit.Click += BtnExit_Click;
            //
            // LoginForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 400);
            Controls.Add(BtnExit);
            Controls.Add(BtnLogin);
            Controls.Add(lblError);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - EasyBiz";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}