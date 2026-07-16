using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyBiz
{
    /// <summary>
    /// Small dialog for entering/saving the Gemini API key and model name.
    /// Built entirely in code (no Designer.cs) to keep this a drop-in file.
    /// </summary>
    public class GeminiSettingsForm : Form
    {
        private readonly TextBox txtApiKey;
        private readonly TextBox txtModel;
        private readonly CheckBox chkShowKey;
        private readonly CustomButton btnSave;
        private readonly CustomButton btnCancel;

        public GeminiSettingsForm()
        {
            Text = "AI Assistant — Gemini Settings";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(480, 270);

            var lblKey = new Label
            {
                Text = "Google Gemini API Key",
                Location = new Point(20, 18),
                AutoSize = true,
                Font = new Font("Segoe UI", 10.2F)
            };
            txtApiKey = new TextBox
            {
                Location = new Point(20, 44),
                Width = 440,
                Font = new Font("Segoe UI", 11F),
                UseSystemPasswordChar = true
            };

            chkShowKey = new CheckBox
            {
                Text = "Show key",
                Location = new Point(20, 76),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F)
            };
            chkShowKey.CheckedChanged += (s, e) => txtApiKey.UseSystemPasswordChar = !chkShowKey.Checked;

            var lblModel = new Label
            {
                Text = "Model",
                Location = new Point(20, 106),
                AutoSize = true,
                Font = new Font("Segoe UI", 10.2F)
            };
            txtModel = new TextBox
            {
                Location = new Point(20, 131),
                Width = 440,
                Font = new Font("Segoe UI", 11F),
                Text = "gemini-3.5-flash"
            };

            var lblHint = new Label
            {
                Text = "Get a free API key at aistudio.google.com/apikey. If Google releases a " +
                       "newer/faster model, just type its name here (e.g. gemini-2.5-pro).",
                Location = new Point(20, 164),
                Size = new Size(440, 44),
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 8.5F)
            };

            btnSave = new CustomButton
            {
                Text = "Save",
                BackColor = Color.FromArgb(52, 152, 219),
                BackgroundColor = Color.FromArgb(52, 152, 219),
                Location = new Point(264, 216),
                Size = new Size(90, 36)
            };
            btnSave.Click += BtnSave_Click;

            btnCancel = new CustomButton
            {
                Text = "Cancel",
                BackColor = Color.Gray,
                BackgroundColor = Color.Gray,
                Location = new Point(364, 216),
                Size = new Size(96, 36)
            };
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(lblKey);
            Controls.Add(txtApiKey);
            Controls.Add(chkShowKey);
            Controls.Add(lblModel);
            Controls.Add(txtModel);
            Controls.Add(lblHint);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            Load += GeminiSettingsForm_Load;
        }

        private void GeminiSettingsForm_Load(object sender, EventArgs e)
        {
            AISettingsHelper.InitializeAISettingsTable();
            txtApiKey.Text = AISettingsHelper.GetSetting("GeminiApiKey", "");
            string savedModel = AISettingsHelper.GetSetting("GeminiModel", "");
            if (!string.IsNullOrWhiteSpace(savedModel))
                txtModel.Text = savedModel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApiKey.Text))
            {
                MessageBox.Show("Please enter your Gemini API key.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AISettingsHelper.SaveSetting("GeminiApiKey", txtApiKey.Text.Trim());
            AISettingsHelper.SaveSetting("GeminiModel",
                string.IsNullOrWhiteSpace(txtModel.Text) ? "gemini-3.5-flash" : txtModel.Text.Trim());

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
