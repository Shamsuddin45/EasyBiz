using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace EasyBiz.Forms
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            Load += AboutBox_Load;
            ThemeManager.ApplyTheme(this);
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            // Pull version straight from the assembly so this never
            // goes stale after a build.
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"Version {version.Major}.{version.Minor}.{version.Build}";

            lblCopyright.Text = $"© {DateTime.Now.Year} Shamsuddin. All rights reserved.";

            // If you have an embedded logo resource, load it here, e.g.:
            // picLogo.Image = EasyBiz.Properties.Resources.AppLogo;
        }

        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.example.com",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the link: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckUpdates_Click(object sender, EventArgs e)
        {
            // Placeholder — wire this up to your actual update-check logic
            // (e.g. a version endpoint or a GitHub releases check).
            MessageBox.Show("You're running the latest version.", "Check for Updates",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}