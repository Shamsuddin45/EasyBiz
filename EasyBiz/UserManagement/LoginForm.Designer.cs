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
        private Panel pndUsernameLine; // Modern bottom-line border accent
        private Panel pndPasswordLine; // Modern bottom-line border accent

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
            pndUsernameLine = new Panel();
            pndPasswordLine = new Panel();
            BtnExit = new CustomButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(45, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(155, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "EasyBiz";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(158, 158, 158);
            lblSubtitle.Location = new Point(49, 89);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(216, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome back! Please sign in.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(117, 117, 117);
            label1.Location = new Point(45, 145);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(250, 250, 250);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(33, 33, 33);
            txtUsername.Location = new Point(49, 172);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(310, 27);
            txtUsername.TabIndex = 0;
            txtUsername.KeyDown += txtUsername_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(117, 117, 117);
            label2.Location = new Point(45, 225);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(250, 250, 250);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(33, 33, 33);
            txtPassword.Location = new Point(49, 252);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(310, 25);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(117, 117, 117);
            chkShowPassword.Location = new Point(49, 295);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(134, 24);
            chkShowPassword.TabIndex = 2;
            chkShowPassword.Text = "Show password";
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(211, 47, 47);
            lblError.Location = new Point(45, 332);
            lblError.MaximumSize = new Size(310, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 5;
            lblError.Visible = false;
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.FromArgb(10, 110, 255);
            BtnLogin.BackgroundColor = Color.FromArgb(10, 110, 255);
            BtnLogin.BorderColor = Color.Transparent;
            BtnLogin.BorderRadius = 6;
            BtnLogin.BorderSize = 0;
            BtnLogin.Cursor = Cursors.Hand;
            BtnLogin.FlatAppearance.BorderSize = 0;
            BtnLogin.FlatStyle = FlatStyle.Flat;
            BtnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            BtnLogin.ForeColor = Color.White;
            BtnLogin.Location = new Point(45, 365);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(310, 45);
            BtnLogin.TabIndex = 3;
            BtnLogin.Text = "Log In";
            BtnLogin.TextColor = Color.White;
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // pndUsernameLine
            // 
            pndUsernameLine.BackColor = Color.FromArgb(224, 224, 224);
            pndUsernameLine.Location = new Point(49, 200);
            pndUsernameLine.Name = "pndUsernameLine";
            pndUsernameLine.Size = new Size(310, 2);
            pndUsernameLine.TabIndex = 1;
            // 
            // pndPasswordLine
            // 
            pndPasswordLine.BackColor = Color.FromArgb(224, 224, 224);
            pndPasswordLine.Location = new Point(49, 280);
            pndPasswordLine.Name = "pndPasswordLine";
            pndPasswordLine.Size = new Size(310, 2);
            pndPasswordLine.TabIndex = 0;
            // 
            // BtnExit
            // 
            BtnExit.BackColor = Color.FromArgb(192, 0, 0);
            BtnExit.BackgroundColor = Color.FromArgb(192, 0, 0);
            BtnExit.BorderColor = Color.Transparent;
            BtnExit.BorderRadius = 6;
            BtnExit.BorderSize = 0;
            BtnExit.Cursor = Cursors.Hand;
            BtnExit.FlatAppearance.BorderSize = 0;
            BtnExit.FlatStyle = FlatStyle.Flat;
            BtnExit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            BtnExit.ForeColor = Color.White;
            BtnExit.Location = new Point(45, 416);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(310, 45);
            BtnExit.TabIndex = 6;
            BtnExit.Text = "Exit";
            BtnExit.TextColor = Color.White;
            BtnExit.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 490);
            Controls.Add(BtnExit);
            Controls.Add(pndPasswordLine);
            Controls.Add(pndUsernameLine);
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
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private CustomButton BtnExit;
    }
}