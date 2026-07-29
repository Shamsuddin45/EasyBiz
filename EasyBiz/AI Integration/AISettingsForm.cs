using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyBiz
{
    /// <summary>
    /// Lets the user pick which AI provider powers the reporting assistant
    /// (Gemini, ChatGPT/OpenAI, Groq, or a local Ollama server) and enter
    /// that provider's API key / model / base URL. Built entirely in code
    /// (no Designer.cs), same pattern as the old GeminiSettingsForm.
    /// Replaces GeminiSettingsForm.
    /// </summary>
    public class AISettingsForm : Form
    {
        private readonly ComboBox comboProvider;
        private readonly Label lblKeyOrUrl;
        private readonly TextBox txtKeyOrUrl;
        private readonly CheckBox chkShowKey;
        private readonly Label lblModel;
        private readonly TextBox txtModel;
        private readonly Label lblHint;
        private readonly CustomButton btnSave;
        private readonly CustomButton btnCancel;

        public AISettingsForm()
        {
            Text = "AI Assistant — Settings";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(480, 380);

            var lblProvider = new Label
            {
                Text = "AI Provider",
                Location = new Point(20, 16),
                AutoSize = true,
                Font = new Font("Segoe UI", 10.2F)
            };
            comboProvider = new ComboBox
            {
                Location = new Point(20, 40),
                Width = 440,
                Font = new Font("Segoe UI", 11F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboProvider.Items.AddRange(new object[]
            {
                "Gemini",
                "OpenAI (ChatGPT)",
                "Groq",
                "Ollama (local)"
            });
            comboProvider.SelectedIndexChanged += ComboProvider_SelectedIndexChanged;

            lblKeyOrUrl = new Label
            {
                Text = "API Key",
                Location = new Point(20, 84),
                AutoSize = true,
                Font = new Font("Segoe UI", 10.2F)
            };
            txtKeyOrUrl = new TextBox
            {
                Location = new Point(20, 108),
                Width = 440,
                Font = new Font("Segoe UI", 11F),
                UseSystemPasswordChar = true
            };

            chkShowKey = new CheckBox
            {
                Text = "Show",
                Location = new Point(20, 140),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F)
            };
            chkShowKey.CheckedChanged += (s, e) =>
                txtKeyOrUrl.UseSystemPasswordChar = AIProviderFactory.RequiresApiKey(SelectedProviderKey()) && !chkShowKey.Checked;

            lblModel = new Label
            {
                Text = "Model",
                Location = new Point(20, 172),
                AutoSize = true,
                Font = new Font("Segoe UI", 10.2F)
            };
            txtModel = new TextBox
            {
                Location = new Point(20, 196),
                Width = 440,
                Font = new Font("Segoe UI", 11F)
            };

            lblHint = new Label
            {
                Location = new Point(20, 230),
                Size = new Size(440, 60),
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 8.5F)
            };

            btnSave = new CustomButton
            {
                Text = "Save",
                BackColor = Color.FromArgb(52, 152, 219),
                BackgroundColor = Color.FromArgb(52, 152, 219),
                Location = new Point(264, 320),
                Size = new Size(90, 36)
            };
            btnSave.Click += BtnSave_Click;

            btnCancel = new CustomButton
            {
                Text = "Cancel",
                BackColor = Color.Gray,
                BackgroundColor = Color.Gray,
                Location = new Point(364, 320),
                Size = new Size(96, 36)
            };
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(lblProvider);
            Controls.Add(comboProvider);
            Controls.Add(lblKeyOrUrl);
            Controls.Add(txtKeyOrUrl);
            Controls.Add(chkShowKey);
            Controls.Add(lblModel);
            Controls.Add(txtModel);
            Controls.Add(lblHint);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            Load += AISettingsForm_Load;
        }

        private string SelectedProviderKey() => comboProvider.SelectedIndex switch
        {
            0 => "Gemini",
            1 => "OpenAI",
            2 => "Groq",
            3 => "Ollama",
            _ => "Gemini"
        };

        private void AISettingsForm_Load(object sender, EventArgs e)
        {
            AISettingsHelper.InitializeAISettingsTable();
            string current = AISettingsHelper.GetSetting(AIProviderFactory.KeyProvider, "Gemini");
            comboProvider.SelectedIndex = current switch
            {
                "OpenAI" => 1,
                "Groq" => 2,
                "Ollama" => 3,
                _ => 0
            };
            LoadFieldsForCurrentProvider();
        }

        private void ComboProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFieldsForCurrentProvider();
        }

        private void LoadFieldsForCurrentProvider()
        {
            string provider = SelectedProviderKey();

            if (provider == "Ollama")
            {
                lblKeyOrUrl.Text = "Ollama Base URL";
                chkShowKey.Visible = false;
                txtKeyOrUrl.UseSystemPasswordChar = false;
                txtKeyOrUrl.Text = AISettingsHelper.GetSetting("OllamaBaseUrl", "http://localhost:11434");
                txtModel.Text = AISettingsHelper.GetSetting("OllamaModel", AIProviderFactory.DefaultModelFor("Ollama"));
                lblHint.Text = "Ollama runs models locally — no API key needed. Make sure Ollama " +
                               "is running and you've pulled a tool-capable model, e.g.:\n" +
                               "    ollama pull llama3.1";
            }
            else
            {
                lblKeyOrUrl.Text = "API Key";
                chkShowKey.Visible = true;
                txtKeyOrUrl.UseSystemPasswordChar = !chkShowKey.Checked;

                string keySetting = provider switch
                {
                    "OpenAI" => "OpenAIApiKey",
                    "Groq" => "GroqApiKey",
                    _ => "GeminiApiKey"
                };
                string modelSetting = provider switch
                {
                    "OpenAI" => "OpenAIModel",
                    "Groq" => "GroqModel",
                    _ => "GeminiModel"
                };

                txtKeyOrUrl.Text = AISettingsHelper.GetSetting(keySetting, "");
                txtModel.Text = AISettingsHelper.GetSetting(modelSetting, AIProviderFactory.DefaultModelFor(provider));

                lblHint.Text = provider switch
                {
                    "OpenAI" => "Get a key at platform.openai.com/api-keys. Any current chat model with tool/function-calling support works (e.g. gpt-4o-mini, gpt-4o).",
                    "Groq" => "Get a free key at console.groq.com/keys. Groq runs open models (Llama, etc.) extremely fast.",
                    _ => "Get a free API key at aistudio.google.com/apikey. If Google releases a newer/faster model, just type its name here."
                };
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string provider = SelectedProviderKey();

            if (AIProviderFactory.RequiresApiKey(provider) && string.IsNullOrWhiteSpace(txtKeyOrUrl.Text))
            {
                MessageBox.Show("Please enter an API key for this provider.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AISettingsHelper.SaveSetting(AIProviderFactory.KeyProvider, provider);

            string model = string.IsNullOrWhiteSpace(txtModel.Text)
                ? AIProviderFactory.DefaultModelFor(provider)
                : txtModel.Text.Trim();

            switch (provider)
            {
                case "OpenAI":
                    AISettingsHelper.SaveSetting("OpenAIApiKey", txtKeyOrUrl.Text.Trim());
                    AISettingsHelper.SaveSetting("OpenAIModel", model);
                    break;
                case "Groq":
                    AISettingsHelper.SaveSetting("GroqApiKey", txtKeyOrUrl.Text.Trim());
                    AISettingsHelper.SaveSetting("GroqModel", model);
                    break;
                case "Ollama":
                    AISettingsHelper.SaveSetting("OllamaBaseUrl",
                        string.IsNullOrWhiteSpace(txtKeyOrUrl.Text) ? "http://localhost:11434" : txtKeyOrUrl.Text.Trim());
                    AISettingsHelper.SaveSetting("OllamaModel", model);
                    break;
                default: // Gemini
                    AISettingsHelper.SaveSetting("GeminiApiKey", txtKeyOrUrl.Text.Trim());
                    AISettingsHelper.SaveSetting("GeminiModel", model);
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
