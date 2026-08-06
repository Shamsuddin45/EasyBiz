using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

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
            InitThemeTab();
            ThemeManager.ApplyTheme(this);

            comboInWordsSettings.SelectedItem = GlobalConfig.AppSettings.InWords.ToString();
            comboPrintSaleReceipt.SelectedItem = GlobalConfig.AppSettings.PrintSaleReceipt.ToString();
        }

        private FlowLayoutPanel _themeSwatchPanel;        

        private void InitThemeTab()
        {
            var tabPage = new TabPage("Theme") { Padding = new Padding(10) };

            var topPanel = new Panel { Dock = DockStyle.Top, Height = 40 };

            var lbl = new Label
            {
                Text = "Choose a color theme for EasyBiz:",
                Font = new Font("Segoe UI", 11F),
                AutoSize = true,
                Location = new Point(0, 8)
            };

            var btnCustomize = new CustomButton
            {
                Text = "Customize…",
                Size = new Size(120, 30),
                Dock = DockStyle.Right,
                BorderRadius = 6,
                BackgroundColor = Color.FromArgb(52, 73, 94),
                TextColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
            btnCustomize.Click += BtnCustomizeTheme_Click;

            topPanel.Controls.Add(lbl);
            topPanel.Controls.Add(btnCustomize);           

            _themeSwatchPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0)
            };

            tabPage.Controls.Add(_themeSwatchPanel);
            tabPage.Controls.Add(topPanel);            

            RefreshThemeSwatches();            

            tabControl1.TabPages.Add(tabPage);
        }

        private void BtnCustomizeTheme_Click(object sender, EventArgs e)
        {
            // Start from whatever palette is currently active — Custom if it's
            // already active (so re-editing continues from the saved custom colors),
            // otherwise the currently applied built-in theme, as a starting point.
            var startingPalette = ThemeManager.PaletteFor(ThemeManager.CurrentTheme);

            using var dlg = new ThemeCustomizeDialog(startingPalette);
            if (dlg.ShowDialog(this) == DialogResult.OK && dlg.ResultPalette != null)
            {
                ThemeManager.SaveCustomPalette(dlg.ResultPalette);
                ThemeManager.ApplyTheme(this);
                RefreshThemeSwatches();         
            }
        }        

        private void RefreshThemeSwatches()
        {
            _themeSwatchPanel.Controls.Clear();

            foreach (AppTheme theme in Enum.GetValues(typeof(AppTheme)))
            {
                var palette = ThemeManager.PaletteFor(theme);
                bool isCurrent = theme == ThemeManager.CurrentTheme;

                var btn = new CustomButton
                {
                    Text = ThemeManager.FriendlyName(theme) + (isCurrent ? "  ✓ Active" : ""),
                    Size = new Size(160, 70),
                    Margin = new Padding(8),
                    BorderRadius = 10,
                    BackgroundColor = palette.AccentColor,
                    TextColor = Color.White,
                    Font = new Font("Segoe UI", 9.5F)
                };

                btn.Click += (s, e) =>
                {
                    ThemeManager.SaveTheme(theme);
                    ThemeManager.ApplyTheme(this);   // Repaint the Settings form itself
                    RefreshThemeSwatches();          // Move the ✓ to the new active swatch                    
                };

                _themeSwatchPanel.Controls.Add(btn);
            }
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

            for (int i = 0; i < clbFavorites.Items.Count; i++)
            {
                if (clbFavorites.GetItemChecked(i))
                {
                    selectedKeys.Add(ModuleRegistry.AllModules[i].Key);
                }
            }

            FavoritesService.SaveFavorites(selectedKeys);
            clbFavorites.Visible = true;
            MessageBox.Show("Favourites Updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FavoritesUpdated?.Invoke(this, EventArgs.Empty);
        }

        // ── Users Management tab ─────────────────────────────────────────────

        private void InitUsersTab()
        {
            if (!CurrentUser.IsAdmin)
            {
                tabPage2.Enabled = false;
                tabPage2.Text = "Users Management (Admins only)";
                return;
            }

            foreach (var module in ModuleRegistry.AllModules)
                clbUserRights.Items.Add(module.DisplayName);

            clbUserRights.Items.Add("Trial Balance");
            clbUserRights.Items.Add("Backup Data");

            LoadUsersGrid();
        }

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

        private void btnUsersManagement_Click(object sender, EventArgs e) { }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboInWordsSettings.SelectedItem != null)
            {
                GlobalConfig.AppSettings.InWords = comboInWordsSettings.SelectedItem.ToString();
                comboInWordsSettings.SelectedItem = comboInWordsSettings.SelectedItem.ToString();
            }
            if (comboPrintSaleReceipt.SelectedItem != null)
            {
                GlobalConfig.AppSettings.PrintSaleReceipt = comboPrintSaleReceipt.SelectedItem.ToString();
                comboPrintSaleReceipt.SelectedItem = comboPrintSaleReceipt.SelectedItem.ToString();
            }
            GlobalConfig.SaveSettings();
            MessageBox.Show("Settings updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}