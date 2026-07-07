using System;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class UsersManagement : Form
    {
        private int? _selectedUserId = null;

        public UsersManagement()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UsersManagement_Load(object sender, EventArgs e)
        {
            comboRole.Items.Clear();
            comboRole.Items.Add(UserAccountsDatabaseHelper.RoleAdmin);
            comboRole.Items.Add(UserAccountsDatabaseHelper.RoleUser);
            comboRole.SelectedIndex = 1;

            LoadUsers();
            ClearForm();
        }

        private void LoadUsers()
        {
            dataGridView1.Rows.Clear();
            foreach (var u in UserAccountsDatabaseHelper.GetAllUsers())
            {
                int r = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[r];
                row.Cells["colUserId"].Value = u.UserId;
                row.Cells["colUsername"].Value = u.Username;
                row.Cells["colFullName"].Value = u.FullName;
                row.Cells["colRole"].Value = u.Role;
                row.Cells["colActive"].Value = u.IsActive ? "Active" : "Deactivated";
                row.Cells["colLastLogin"].Value = string.IsNullOrEmpty(u.LastLogin) ? "Never" : u.LastLogin;
                row.Cells["colCreated"].Value = u.CreatedAt;

                if (!u.IsActive)
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Italic);
                }
            }
        }

        private void ClearForm()
        {
            _selectedUserId = null;
            txtUsername.Clear();
            txtUsername.ReadOnly = false;
            txtFullName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            comboRole.SelectedIndex = 1;

            BtnAdd.Enabled = true;
            BtnUpdate.Enabled = false;
            BtnResetPassword.Enabled = false;
            BtnToggleActive.Enabled = false;
            BtnToggleActive.Text = "Deactivate / Activate";

            dataGridView1.ClearSelection();
            txtUsername.Focus();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            _selectedUserId = Convert.ToInt32(row.Cells["colUserId"].Value);
            txtUsername.Text = row.Cells["colUsername"].Value?.ToString() ?? "";
            txtUsername.ReadOnly = true; // username is not editable once created
            txtFullName.Text = row.Cells["colFullName"].Value?.ToString() ?? "";
            string role = row.Cells["colRole"].Value?.ToString() ?? UserAccountsDatabaseHelper.RoleUser;
            comboRole.SelectedItem = role;
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            bool isActive = (row.Cells["colActive"].Value?.ToString() ?? "") == "Active";
            BtnToggleActive.Text = isActive ? "Deactivate User" : "Activate User";

            BtnAdd.Enabled = false;
            BtnUpdate.Enabled = true;
            BtnResetPassword.Enabled = true;
            BtnToggleActive.Enabled = true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;
            string role = comboRole.SelectedItem?.ToString() ?? UserAccountsDatabaseHelper.RoleUser;

            if (string.IsNullOrWhiteSpace(username))
            { MessageBox.Show("Username is required."); return; }

            if (username.Length < 3)
            { MessageBox.Show("Username must be at least 3 characters."); return; }

            if (UserAccountsDatabaseHelper.UsernameExists(username))
            { MessageBox.Show("That username is already taken."); return; }

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            { MessageBox.Show("Password must be at least 6 characters."); return; }

            if (password != confirm)
            { MessageBox.Show("Password and confirmation do not match."); return; }

            try
            {
                UserAccountsDatabaseHelper.CreateUser(username, password, fullName, role);
                MessageBox.Show("User created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating user: " + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null) return;

            string fullName = txtFullName.Text.Trim();
            string role = comboRole.SelectedItem?.ToString() ?? UserAccountsDatabaseHelper.RoleUser;

            // Guard: don't allow demoting/deactivating the last remaining admin.
            if (role != UserAccountsDatabaseHelper.RoleAdmin &&
                UserAccountsDatabaseHelper.CountActiveAdmins(_selectedUserId.Value) == 0)
            {
                MessageBox.Show(
                    "At least one active Administrator must remain. You cannot change this user's role.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserAccountsDatabaseHelper.UpdateUser(_selectedUserId.Value, fullName, role);
            MessageBox.Show("User details updated.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
            ClearForm();
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null) return;

            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            { MessageBox.Show("Enter a new password of at least 6 characters in the Password field."); return; }

            if (password != confirm)
            { MessageBox.Show("Password and confirmation do not match."); return; }

            var result = MessageBox.Show(
                $"Reset password for '{txtUsername.Text}'?",
                "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            UserAccountsDatabaseHelper.ResetPassword(_selectedUserId.Value, password);
            MessageBox.Show("Password has been reset.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        private void BtnToggleActive_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null) return;

            bool currentlyActive = BtnToggleActive.Text == "Deactivate User";

            if (currentlyActive)
            {
                // Guard: don't allow deactivating the last remaining admin.
                var row = dataGridView1.SelectedRows[0];
                string role = row.Cells["colRole"].Value?.ToString() ?? "";
                if (role == UserAccountsDatabaseHelper.RoleAdmin &&
                    UserAccountsDatabaseHelper.CountActiveAdmins(_selectedUserId.Value) == 0)
                {
                    MessageBox.Show(
                        "At least one active Administrator must remain. You cannot deactivate this user.",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_selectedUserId == CurrentSession.UserId)
                {
                    MessageBox.Show("You cannot deactivate the account you're currently logged in with.");
                    return;
                }
            }

            UserAccountsDatabaseHelper.SetActive(_selectedUserId.Value, !currentlyActive);
            LoadUsers();
            ClearForm();
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        private void BtnClose_Click(object sender, EventArgs e) => Close();
    }
}
