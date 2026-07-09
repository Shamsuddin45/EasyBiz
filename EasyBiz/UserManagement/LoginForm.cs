using System;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class LoginForm : Form
    {
        private int _failedAttempts = 0;
        private const int MaxAttemptsBeforeSlowdown = 3;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DatabaseHelper.InitializeDatabase();
            UserAccountsDatabaseHelper.InitializeUserTable();
            txtUsername.Focus();
        }

        private void AttemptLogin()
        {
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter both username and password.";
                return;
            }

            BtnLogin.Enabled = false;
            Cursor = Cursors.WaitCursor;

            LoginResult result;
            UserAccount? user;
            try
            {
                result = UserAccountsDatabaseHelper.TryLogin(username, password, out user);
            }
            finally
            {
                Cursor = Cursors.Default;
                BtnLogin.Enabled = true;
            }

            switch (result)
            {
                case LoginResult.Success:
                    CurrentSession.SetUser(user!);
                    lastlogin(username);
                    DialogResult = DialogResult.OK;
                    Close();
                    break;

                case LoginResult.UserNotFound:
                case LoginResult.WrongPassword:
                    _failedAttempts++;
                    lblError.Text = "Invalid username or password.";
                    txtPassword.Clear();
                    txtPassword.Focus();
                    if (_failedAttempts >= MaxAttemptsBeforeSlowdown)
                    {
                        // Small friction after repeated failures — not a hard
                        // lockout, just discourages rapid-fire guessing.
                        System.Threading.Thread.Sleep(1000);
                    }
                    break;

                case LoginResult.AccountInactive:
                    lblError.Text = "This account has been deactivated. Contact your Admin";
                    break;
            }
        }

        public void lastlogin(string username)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE users SET last_login = @LastLogin WHERE Username = @Username";
                    command.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e) => AttemptLogin();

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AttemptLogin();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the window is closed (X button) without a successful login,
            // treat it the same as pressing Exit.
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }
    }
}
