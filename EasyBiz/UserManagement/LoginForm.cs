using System;
using System.Threading.Tasks; // Added for Task.Delay
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class LoginForm : Form
    {
        public UserAccount? LoggedInUser { get; private set; }
        private int _failedAttempts = 0;

        public LoginForm()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            UserRightsDatabaseHelper.InitializeUserTables();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtUsername.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                BtnExit_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // 1. Changed method signature to 'async void' for event handler
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowError("Please enter a username.");
                return;
            }

            // 2. Non-blocking rate limit
            if (_failedAttempts >= 3)
            {
                ShowError("Too many failed attempts. Please wait 5 seconds...");
                BtnLogin.Enabled = false; // Disable button to prevent double-clicks

                await Task.Delay(5000);   // Non-blocking wait (allows UI to repaint)

                BtnLogin.Enabled = true;
                _failedAttempts = 0; // Reset after waiting
            }

            // Clear previous errors before attempting authentication
            lblError.Visible = false;

            // 3. Authenticate (If this DB call is slow, consider making Authenticate async too)
            var user = UserRightsService.Authenticate(username, password);
            if (user == null)
            {
                _failedAttempts++;
                ShowError("Invalid username or password, or the account is disabled.");
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            _failedAttempts = 0;
            LoggedInUser = user;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            lblError.Refresh(); // Forces UI to paint immediately
        }

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
                // Simply call the click event directly
                BtnLogin_Click(this, EventArgs.Empty);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}