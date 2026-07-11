using System;
using System.Drawing;
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
            comboRole.Items.Add("Administrator");
            comboRole.Items.Add("User");
            comboRole.SelectedIndex = 1;

            LoadUsers();
            ClearForm();
        }

        private void LoadUsers()
        {
            dataGridView1.Rows.Clear();
            foreach (var u in UserRightsService.GetAllUsers())
            {
                int r = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[r];
                row.Cells["colUserId"].Value = u.UserId;
                row.Cells["colUsername"].Value = u.Username;
                row.Cells["colFullName"].Value = u.FullName;
                row.Cells["colRole"].Value = u.IsAdmin ? "Administrator" : "User";
                row.Cells["colActive"].Value = u.IsActive ? "Active" : "Deactivated";
                row.Cells["colLastLogin"].Value = "Never"; // Not tracked in current schema
                row.Cells["colCreated"].Value = "N/A"; // Not tracked in current schema

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
            string role = row.Cells["colRole"].Value?.ToString() ?? "User";
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
            bool isAdmin = (comboRole.SelectedItem?.ToString() ?? "User") == "Administrator";

            if (string.IsNullOrWhiteSpace(username))
            { MessageBox.Show("Username is required."); return; }

            if (username.Length < 3)
            { MessageBox.Show("Username must be at least 3 characters."); return; }

            // Check if username exists
            var allUsers = UserRightsService.GetAllUsers();
            foreach (var u in allUsers)
            {
                if (string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("That username is already taken.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            { MessageBox.Show("Password must be at least 6 characters."); return; }

            if (password != confirm)
            { MessageBox.Show("Password and confirmation do not match."); return; }

            try
            {
                UserRightsService.CreateUser(username, password, fullName, isAdmin);
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
            bool isAdmin = (comboRole.SelectedItem?.ToString() ?? "User") == "Administrator";

            // Get current user data
            var allUsers = UserRightsService.GetAllUsers();
            UserAccount? currentUser = null;
            foreach (var u in allUsers)
            {
                if (u.UserId == _selectedUserId.Value)
                {
                    currentUser = u;
                    break;
                }
            }

            if (currentUser == null) return;

            // Guard: don't allow demoting/deactivating the last remaining admin.
            if (!isAdmin && currentUser.IsAdmin && UserRightsService.IsLastAdmin(_selectedUserId.Value))
            {
                MessageBox.Show(
                    "At least one active Administrator must remain. You cannot change this user's role.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // We need to preserve the current active status
            bool isActive = currentUser.IsActive;
            UserRightsService.UpdateUser(_selectedUserId.Value, fullName, isAdmin, isActive);
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

            UserRightsService.ResetPassword(_selectedUserId.Value, password);
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
                var allUsers = UserRightsService.GetAllUsers();
                UserAccount? selectedUser = null;
                foreach (var u in allUsers)
                {
                    if (u.UserId == _selectedUserId.Value)
                    {
                        selectedUser = u;
                        break;
                    }
                }

                if (selectedUser != null && selectedUser.IsAdmin && UserRightsService.IsLastAdmin(_selectedUserId.Value))
                {
                    MessageBox.Show(
                        "At least one active Administrator must remain. You cannot deactivate this user.",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_selectedUserId == CurrentUser.UserId)
                {
                    MessageBox.Show("You cannot deactivate the account you're currently logged in with.");
                    return;
                }
            }

            // Get current user data to preserve other fields
            var allUsersList = UserRightsService.GetAllUsers();
            UserAccount? targetUser = null;
            foreach (var u in allUsersList)
            {
                if (u.UserId == _selectedUserId.Value)
                {
                    targetUser = u;
                    break;
                }
            }

            if (targetUser != null)
            {
                UserRightsService.UpdateUser(
                    _selectedUserId.Value,
                    targetUser.FullName,
                    targetUser.IsAdmin,
                    !currentlyActive);
                LoadUsers();
                ClearForm();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearForm();

        private void BtnClose_Click(object sender, EventArgs e) => Close();
    }
}