using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class Settings : Form
    {
        private List<UserAccount> _users = new();

        public Settings()
        {
            InitializeComponent();
            InitFavoritesTab();
            InitUsersTab();
        }

        // ── Favourites tab (unchanged behaviour, now scoped to CurrentUser) ──

        private void InitFavoritesTab()
        {
            foreach (var module in ModuleRegistry.AllModules)
                clbFavorites.Items.Add(module.DisplayName);
            LoadFavoriteSelections();
        }

        private void LoadFavoriteSelections()
        {
            var favoriteKeys = FavoritesService.GetFavoriteKeys();
            for (int i = 0; i < ModuleRegistry.AllModules.Count; i++)
            {
                if (favoriteKeys.Contains(ModuleRegistry.AllModules[i].Key))
                    clbFavorites.SetItemChecked(i, true);
            }
        }

        public event EventHandler FavoritesUpdated;

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedKeys = new List<string>();

            // 1. Correctly map the checked display names back to their registry keys
            for (int i = 0; i < clbFavorites.Items.Count; i++)
            {
                if (clbFavorites.GetItemChecked(i))
                {
                    selectedKeys.Add(ModuleRegistry.AllModules[i].Key);
                }
            }

            // 2. Save the mapped keys to the database
            FavoritesService.SaveFavorites(selectedKeys);

            // 3. Keep the settings checkbox list visible (or change its visibility if desired)
            clbFavorites.Visible = true;

            MessageBox.Show("Favourites Updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. This fires the event that tells the ALREADY open MainForm to redraw itself!
            FavoritesUpdated?.Invoke(this, EventArgs.Empty);
        }

        // ── Users Management tab ─────────────────────────────────────────────

        private void InitUsersTab()
        {
            // Only admins may manage users and rights. Non-admins still see
            // the tab (so they know it exists) but it's disabled.
            if (!CurrentUser.IsAdmin)
            {
                tabPage2.Enabled = false;
                tabPage2.Text = "Users Management (Admins only)";
                return;
            }

            foreach (var module in ModuleRegistry.AllModules)
                clbUserRights.Items.Add(module.DisplayName);

            // Extra rights that gate MainForm buttons but aren't launchable
            // "modules" in ModuleRegistry (Trial Balance and Backup Data are
            // handled inline on MainForm rather than as separate forms).
            clbUserRights.Items.Add("Trial Balance");
            clbUserRights.Items.Add("Backup Data");

            LoadUsersGrid();
        }

        /// <summary>Maps a clbUserRights list index back to its module/right key.</summary>
        private static string RightKeyForIndex(int index)
        {
            if (index < ModuleRegistry.AllModules.Count)
                return ModuleRegistry.AllModules[index].Key;

            int extra = index - ModuleRegistry.AllModules.Count;
            return extra switch
            {
                0 => "trialbalance",
                1 => "backupdata",
                _ => ""
            };
        }

        private void LoadUsersGrid()
        {
            _users = UserRightsService.GetAllUsers();
            gridUsers.Rows.Clear();
            foreach (var u in _users)
            {
                int ri = gridUsers.Rows.Add();
                var row = gridUsers.Rows[ri];
                row.Cells["colUserId"].Value = u.UserId;
                row.Cells["colUsername"].Value = u.Username;
                row.Cells["colFullName"].Value = u.FullName;
                row.Cells["colIsAdmin"].Value = u.IsAdmin;
                row.Cells["colIsActive"].Value = u.IsActive;
            }
        }

        private UserAccount SelectedUser()
        {
            if (gridUsers.SelectedRows.Count == 0) return null;
            int userId = Convert.ToInt32(gridUsers.SelectedRows[0].Cells["colUserId"].Value);
            return _users.FirstOrDefault(u => u.UserId == userId);
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text;
            string fullName = txtNewFullName.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UserRightsService.CreateUser(username, password, fullName, chkNewIsAdmin.Checked);
                MessageBox.Show("User created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewUsername.Clear();
                txtNewPassword.Clear();
                txtNewFullName.Clear();
                chkNewIsAdmin.Checked = false;
                LoadUsersGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create user (username may already exist).\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridUsers_SelectionChanged(object sender, EventArgs e)
        {
            var user = SelectedUser();
            bool hasSelection = user != null;

            BtnDeleteUser.Enabled = hasSelection;
            BtnResetPassword.Enabled = hasSelection;
            BtnSaveRights.Enabled = hasSelection;
            chkEditIsAdmin.Enabled = hasSelection;
            chkEditIsActive.Enabled = hasSelection;
            BtnUpdateUser.Enabled = hasSelection;
            clbUserRights.Enabled = hasSelection && user?.IsAdmin != true;

            if (user == null)
            {
                for (int i = 0; i < clbUserRights.Items.Count; i++)
                    clbUserRights.SetItemChecked(i, false);
                return;
            }

            chkEditIsAdmin.Checked = user.IsAdmin;
            chkEditIsActive.Checked = user.IsActive;

            var allowed = UserRightsService.GetAllowedModuleKeys(user.UserId, user.IsAdmin);
            for (int i = 0; i < clbUserRights.Items.Count; i++)
            {
                string key = RightKeyForIndex(i);
                clbUserRights.SetItemChecked(i, allowed.Contains(key));
            }
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            var user = SelectedUser();
            if (user == null) return;

            // Guard: don't allow removing admin status from the last remaining admin.
            if (user.IsAdmin && !chkEditIsAdmin.Checked && UserRightsService.IsLastAdmin(user.UserId))
            {
                MessageBox.Show("This is the last remaining admin account — it must stay an admin.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkEditIsAdmin.Checked = true;
                return;
            }

            UserRightsService.UpdateUser(user.UserId, user.FullName, chkEditIsAdmin.Checked, chkEditIsActive.Checked);
            MessageBox.Show("User updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsersGrid();
        }

        private void BtnSaveRights_Click(object sender, EventArgs e)
        {
            var user = SelectedUser();
            if (user == null) return;

            if (user.IsAdmin)
            {
                MessageBox.Show("Admins automatically have full access; rights are not restricted for admins.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var allowedKeys = new List<string>();
            for (int i = 0; i < clbUserRights.Items.Count; i++)
            {
                if (clbUserRights.GetItemChecked(i))
                    allowedKeys.Add(RightKeyForIndex(i));
            }

            UserRightsService.SaveRights(user.UserId, allowedKeys);
            MessageBox.Show("Rights saved for " + user.Username + ".", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            var user = SelectedUser();
            if (user == null) return;

            string newPassword = txtResetPassword.Text;
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Enter a new password first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserRightsService.ResetPassword(user.UserId, newPassword);
            txtResetPassword.Clear();
            MessageBox.Show("Password reset for " + user.Username + ".", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            var user = SelectedUser();
            if (user == null) return;

            if (user.UserId == CurrentUser.UserId)
            {
                MessageBox.Show("You cannot delete the account you are currently logged in with.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UserRightsService.IsLastAdmin(user.UserId))
            {
                MessageBox.Show("This is the last remaining admin account and cannot be deleted.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Delete user '{user.Username}'? This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            UserRightsService.DeleteUser(user.UserId);
            LoadUsersGrid();
        }

        // Legacy handler kept only so the hidden compatibility button (see
        // Designer) still compiles; the real Users Management UI above
        // replaces what this button used to open.
        private void btnUsersManagement_Click(object sender, EventArgs e)
        {
        }
    }
}