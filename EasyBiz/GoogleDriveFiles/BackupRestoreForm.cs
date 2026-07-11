using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyBiz
{
    /// <summary>
    /// Simple Backup / Restore dialog for Google Drive. All controls are
    /// created in code (no Designer.cs) to keep this a single drop-in file.
    /// </summary>
    public partial class BackupRestoreForm : Form
    {
        private readonly Label lblStatus = new Label();
        private readonly ListBox lstBackups = new ListBox();
        private readonly CustomButton btnBackupNow = new CustomButton();
        private readonly CustomButton btnRestore = new CustomButton();
        private readonly CustomButton btnRefresh = new CustomButton();
        private readonly CustomButton btnSignOut = new CustomButton();
        private readonly CustomButton btnClose = new CustomButton();

        private List<DriveBackupInfo> _backups = new List<DriveBackupInfo>();

        public BackupRestoreForm()
        {
            Text = "Backup & Restore (Google Drive)";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(560, 470);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            var lblTitle = new Label
            {
                Text = "Google Drive Backup",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };

            lblStatus.Text = "Ready.";
            lblStatus.ForeColor = Color.DimGray;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.AutoSize = false;
            lblStatus.Location = new Point(20, 50);
            lblStatus.Size = new Size(520, 40);

            var lblList = new Label
            {
                Text = "Available backups (most recent first):",
                Font = new Font("Segoe UI", 9.5F),
                AutoSize = true,
                Location = new Point(20, 95)
            };

            lstBackups.Font = new Font("Segoe UI", 10F);
            lstBackups.Location = new Point(20, 120);
            lstBackups.Size = new Size(520, 220);

            btnBackupNow.Text = "Backup Now";
            btnBackupNow.BackColor = Color.FromArgb(52, 152, 219);
            btnBackupNow.BackgroundColor = Color.FromArgb(52, 152, 219);
            btnBackupNow.ForeColor = Color.White;
            btnBackupNow.TextColor = Color.White;
            btnBackupNow.Location = new Point(20, 355);
            btnBackupNow.Size = new Size(150, 45);
            btnBackupNow.Click += BtnBackupNow_Click;

            btnRestore.Text = "Restore Selected";
            btnRestore.BackColor = Color.DarkOrange;
            btnRestore.BackgroundColor = Color.DarkOrange;
            btnRestore.ForeColor = Color.White;
            btnRestore.TextColor = Color.White;
            btnRestore.Location = new Point(180, 355);
            btnRestore.Size = new Size(150, 45);
            btnRestore.Click += BtnRestore_Click;

            btnRefresh.Text = "Refresh List";
            btnRefresh.BackColor = Color.ForestGreen;
            btnRefresh.BackgroundColor = Color.ForestGreen;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.TextColor = Color.White;
            btnRefresh.Location = new Point(340, 355);
            btnRefresh.Size = new Size(110, 45);
            btnRefresh.Click += async (s, e) => await LoadBackupsAsync();

            btnSignOut.Text = "Sign Out";
            btnSignOut.BackColor = Color.Gray;
            btnSignOut.BackgroundColor = Color.Gray;
            btnSignOut.ForeColor = Color.White;
            btnSignOut.TextColor = Color.White;
            btnSignOut.Location = new Point(460, 355);
            btnSignOut.Size = new Size(80, 45);
            btnSignOut.Click += (s, e) =>
            {
                GoogleDriveBackupService.SignOut();
                lstBackups.Items.Clear();
                _backups.Clear();
                SetStatus("Signed out. Click 'Refresh List' or 'Backup Now' to sign in again.");
            };

            btnClose.Text = "Close";
            btnClose.BackColor = Color.Tomato;
            btnClose.BackgroundColor = Color.Tomato;
            btnClose.ForeColor = Color.White;
            btnClose.TextColor = Color.White;
            btnClose.Location = new Point(20, 410);
            btnClose.Size = new Size(100, 40);
            btnClose.Click += (s, e) => Close();

            Controls.AddRange(new Control[]
            {
                lblTitle, lblStatus, lblList, lstBackups,
                btnBackupNow, btnRestore, btnRefresh, btnSignOut, btnClose
            });

            Load += async (s, e) => await LoadBackupsAsync();
        }

        private void SetStatus(string text)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetStatus(text))); return; }
            lblStatus.Text = text;
        }

        private void SetBusy(bool busy)
        {
            if (InvokeRequired) { Invoke(new Action(() => SetBusy(busy))); return; }
            btnBackupNow.Enabled = !busy;
            btnRestore.Enabled = !busy;
            btnRefresh.Enabled = !busy;
            btnSignOut.Enabled = !busy;
            lstBackups.Enabled = !busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }

        private async Task LoadBackupsAsync()
        {
            if (!GoogleDriveBackupService.IsConfigured)
            {
                SetStatus("Google Drive is not set up yet. See README-GoogleDriveBackup.md for setup steps.");
                return;
            }

            SetBusy(true);
            SetStatus("Loading backups from Google Drive...");
            try
            {
                _backups = await GoogleDriveBackupService.ListBackupsAsync();
                lstBackups.Items.Clear();
                foreach (var b in _backups)
                {
                    lstBackups.Items.Add(
                        $"{b.CreatedUtc.ToLocalTime():dd-MMM-yyyy hh:mm tt}   —   {b.FileName}   ({b.SizeBytes / 1024.0:N0} KB)");
                }
                SetStatus(_backups.Count == 0
                    ? "No backups found yet. Click 'Backup Now' to create the first one."
                    : $"{_backups.Count} backup(s) found.");
            }
            catch (Exception ex)
            {
                SetStatus("Could not load backups.");
                MessageBox.Show("Failed to load backups from Google Drive:\n\n" + ex.Message,
                    "Google Drive Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async void BtnBackupNow_Click(object sender, EventArgs e)
        {
            if (!GoogleDriveBackupService.IsConfigured)
            {
                MessageBox.Show(
                    "Google Drive is not set up yet.\n\n" +
                    "See README-GoogleDriveBackup.md for the one-time setup steps " +
                    "(Google Cloud project + client_secret.json).",
                    "Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "This will upload a fresh copy of your current EasyBiz database to Google Drive.\n\nContinue?",
                "Confirm Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            SetBusy(true);
            var progress = new Progress<string>(SetStatus);
            try
            {
                var result = await GoogleDriveBackupService.BackupNowAsync(progress);
                MessageBox.Show(
                    $"Backup completed successfully!\n\nFile: {result.FileName}\nSize: {result.SizeBytes / 1024.0:N0} KB",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadBackupsAsync();
            }
            catch (Exception ex)
            {
                SetStatus("Backup failed.");
                MessageBox.Show("Backup failed:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async void BtnRestore_Click(object sender, EventArgs e)
        {
            int idx = lstBackups.SelectedIndex;
            if (idx < 0 || idx >= _backups.Count)
            {
                MessageBox.Show("Please select a backup from the list first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var chosen = _backups[idx];

            var confirm = MessageBox.Show(
                "This will REPLACE your current EasyBiz data with the backup taken on:\n\n" +
                $"{chosen.CreatedUtc.ToLocalTime():dd-MMM-yyyy hh:mm tt}\n\n" +
                "Your current database will be saved as a .bak file first, just in case.\n\n" +
                "EasyBiz must restart after this. Continue?",
                "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            SetBusy(true);
            var progress = new Progress<string>(SetStatus);
            try
            {
                await GoogleDriveBackupService.RestoreAsync(chosen.FileId, progress);

                MessageBox.Show(
                    "Restore complete. EasyBiz will now close — please reopen it to use the restored data.",
                    "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }
            catch (Exception ex)
            {
                SetStatus("Restore failed. Your original database was not modified.");
                MessageBox.Show("Restore failed:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
            }
        }
    }
}
