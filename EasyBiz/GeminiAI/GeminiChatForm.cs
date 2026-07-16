using System;
using System.Drawing;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyBiz
{
    public class GeminiChatForm : Form
    {
        private RichTextBox chatLog;
        private TextBox txtInput;
        private CustomButton btnSend;
        private CustomButton btnClear;
        private CustomButton btnSettings;
        private Label lblStatus;
        private FlowLayoutPanel suggestionPanel; // Container for dynamic suggestions

        private JsonArray _conversation = new JsonArray();
        private bool _busy;

        // Modern Color Palette
        private readonly Color ColorPrimary = Color.FromArgb(79, 70, 229);    // Indigo accent
        private readonly Color ColorBackground = Color.FromArgb(248, 249, 250); // Off-white/Light gray
        private readonly Color ColorTextDark = Color.FromArgb(33, 37, 41);     // Deep charcoal
        private readonly Color ColorTextMuted = Color.FromArgb(108, 117, 125); // Slate gray
        private readonly Color ColorDanger = Color.FromArgb(239, 68, 68);      // Modern soft red
        private readonly Color ColorSuggestionBg = Color.FromArgb(238, 242, 255); // Soft indigo tint

        // Pool of random business questions
        private readonly string[] _suggestionPool = new string[]
        {
            "What is the most selling item today?",
            "What's my current cash balance?",
            "Top 5 customers by sales this month",
            "Show me a summary of today's sales",
            "Which items are currently low on stock?",
            "What was our total revenue last week?",
            "Show me the latest 5 invoices",
            "Which customers have overdue payments?",
            "What is the total value of our current inventory?",
            "Show purchase history for [Customer Name]",
            "What is our profit margin on today's sales?",
            "Which products need to be reordered this week?",
            "Show me sales breakdown by category for this month",
            "List all payments received today"
        };

        public GeminiChatForm()
        {
            Text = "AI Assistant (Gemini)";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(840, 720); // Slightly adjusted height for suggestion chips.
            MinimumSize = new Size(600, 520);
            BackColor = ColorBackground;

            BuildUi();
            ResetConversation();
            txtInput.Select();
        }

        private void BuildUi()
        {
            // ── TOP PANEL (Header) ───────────────────────────────────────────
            var topPanel = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.White, Padding = new Padding(16, 0, 16, 0) };
            var headerBorder = new Panel { Dock = DockStyle.Bottom, Height = 1, BackColor = Color.FromArgb(233, 236, 239) };
            topPanel.Controls.Add(headerBorder);

            var lblTitle = new Label { Text = "EasyBiz AI Assistant", ForeColor = ColorTextDark, Font = new Font("Segoe UI", 13F, FontStyle.Bold), AutoSize = true, Location = new Point(16, 18) };
            btnSettings = new CustomButton { Text = "⚙ Settings", Font = new Font("Segoe UI Semibold", 9.5F), BackColor = ColorBackground, ForeColor = ColorTextDark, BackgroundColor = ColorBackground, Size = new Size(110, 34), Cursor = Cursors.Hand };
            btnSettings.Click += (s, e) => { using var f = new GeminiSettingsForm(); f.ShowDialog(this); };
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(btnSettings);

            void LayoutTopPanel() => btnSettings.Location = new Point(topPanel.ClientSize.Width - btnSettings.Width - 16, 13);
            topPanel.Resize += (s, e) => LayoutTopPanel();
            topPanel.HandleCreated += (s, e) => LayoutTopPanel();

            // ── CHAT LOG (Main Canvas) ───────────────────────────────────────
            chatLog = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, BackColor = Color.White, Font = new Font("Segoe UI", 10.5F), BorderStyle = BorderStyle.None, Margin = new Padding(0), BulletIndent = 10 };
            var chatContainer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(24, 20, 24, 10) };
            chatContainer.Controls.Add(chatLog);

            // ── BOTTOM PANEL (Input Controls & Suggestions) ──────────────────
            var bottomPanel = new Panel { Dock = DockStyle.Bottom, Height = 165, BackColor = ColorBackground, Padding = new Padding(20, 5, 20, 16) };
            lblStatus = new Label { Text = "", Dock = DockStyle.Top, Height = 22, ForeColor = ColorTextMuted, Font = new Font("Segoe UI Italic", 9F) };

            // Dynamic Suggestion Chips Row
            suggestionPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 36,
                Margin = new Padding(0),
                Padding = new Padding(0),
                WrapContents = false,
                AutoScroll = false
            };

            var inputRow = new Panel { Dock = DockStyle.Fill };
            var txtInputWrapper = new Panel { BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Height = 42, Padding = new Padding(8, 9, 8, 4) };
            txtInput = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F), BorderStyle = BorderStyle.None, ForeColor = ColorTextDark, BackColor = Color.White };
            txtInput.KeyDown += TxtInput_KeyDown;
            txtInputWrapper.Controls.Add(txtInput);

            btnSend = new CustomButton { Text = "Send Query", Font = new Font("Segoe UI Semibold", 10F), BackColor = ColorPrimary, BackgroundColor = ColorPrimary, ForeColor = Color.White, Size = new Size(110, 42), Cursor = Cursors.Hand };
            btnSend.Click += async (s, e) => await SendCurrentMessageAsync();

            btnClear = new CustomButton { Text = "Clear Chat", Font = new Font("Segoe UI Semibold", 10F), BackColor = Color.White, BackgroundColor = Color.White, ForeColor = ColorDanger, Size = new Size(100, 42), Cursor = Cursors.Hand };
            btnClear.Click += (s, e) => ResetConversation();

            void LayoutInputRow()
            {
                btnClear.Location = new Point(inputRow.Width - btnClear.Width, 10);
                btnSend.Location = new Point(btnClear.Left - btnSend.Width - 8, 10);
                txtInputWrapper.Location = new Point(0, 10);
                txtInputWrapper.Width = Math.Max(150, btnSend.Left - 12);
            }
            inputRow.Resize += (s, e) => LayoutInputRow();
            inputRow.Controls.Add(txtInputWrapper);
            inputRow.Controls.Add(btnSend);
            inputRow.Controls.Add(btnClear);
            inputRow.HandleCreated += (s, e) => LayoutInputRow();

            bottomPanel.Controls.Add(inputRow);
            bottomPanel.Controls.Add(suggestionPanel);
            bottomPanel.Controls.Add(lblStatus);

            Controls.Add(chatContainer);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
        }

        private void GenerateRandomSuggestions()
        {
            suggestionPanel.Controls.Clear();

            // Randomly select 3 unique options from our pool
            var rand = new Random();
            var indices = new System.Collections.Generic.HashSet<int>();
            while (indices.Count < Math.Min(3, _suggestionPool.Length))
            {
                indices.Add(rand.Next(_suggestionPool.Length));
            }

            foreach (int index in indices)
            {
                string text = _suggestionPool[index];

                // Use a sleek CustomButton for modern rounded/flat looks
                var chip = new CustomButton
                {
                    Text = text,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    BackColor = ColorSuggestionBg,
                    ForeColor = ColorPrimary,
                    BackgroundColor = ColorSuggestionBg,
                    AutoSize = true,
                    Height = 28,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(0, 0, 8, 0)
                };

                // Click event: Inject into textbox and focus instantly
                chip.Click += (s, e) =>
                {
                    txtInput.Text = text;
                    txtInput.Focus();
                    txtInput.SelectionStart = txtInput.Text.Length; // Put cursor at end
                };

                suggestionPanel.Controls.Add(chip);
            }
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                _ = SendCurrentMessageAsync();
            }
        }

        private void ResetConversation()
        {
            _conversation = new JsonArray();
            chatLog.Clear();
            AppendSystemLine($"Hi {CurrentUser.FullName}, How can I help you with your business metrics?");
            GenerateRandomSuggestions();
            txtInput.Select();
        }

        private async Task SendCurrentMessageAsync()
        {
            if (_busy) return;

            string question = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(question)) return;

            AISettingsHelper.InitializeAISettingsTable();
            string apiKey = AISettingsHelper.GetSetting("GeminiApiKey", "");
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("Please set up your Gemini API key first (Settings button, top-right).", "API Key Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using var f = new GeminiSettingsForm();
                f.ShowDialog(this);
                return;
            }
            string model = AISettingsHelper.GetSetting("GeminiModel", "gemini-3.5-flash");

            AppendUserLine(question);
            txtInput.Clear();

            _busy = true;
            btnSend.Enabled = false;
            lblStatus.Text = "⚡ Formulating database insights...";

            try
            {
                var service = new GeminiService(apiKey, model);
                string answer = await service.AskAsync(_conversation, question);
                AppendAssistantLine(answer);
            }
            catch (Exception ex)
            {
                AppendErrorLine("Error: " + ex.Message);
            }
            finally
            {
                _busy = false;
                btnSend.Enabled = true;
                lblStatus.Text = "";
                txtInput.Focus();
                // Rotate suggestions for the next question
                GenerateRandomSuggestions();
            }
        }

        // ── Render Helpers (Modern Stylings) ────────────────────────────────

        private void AppendSystemLine(string text) => AppendLine("ℹ  " + text, ColorTextDark, boldHeader: true);
        private void AppendUserLine(string text) => AppendLine("You\n" + text, ColorPrimary, boldHeader: true);
        private void AppendAssistantLine(string text) => AppendLine("Assistant\n" + text, ColorTextDark, boldHeader: true);
        private void AppendErrorLine(string text) => AppendLine("⚠️ " + text, ColorDanger, boldHeader: true);

        private void AppendLine(string text, Color textColor, bool boldHeader = false, bool italic = false)
        {
            chatLog.SelectionStart = chatLog.TextLength;
            chatLog.SelectionLength = 0;

            if (boldHeader && text.Contains("\n"))
            {
                int splitIndex = text.IndexOf('\n');
                string header = text.Substring(0, splitIndex + 1);
                string body = text.Substring(splitIndex + 1);

                chatLog.SelectionColor = (textColor == ColorTextDark) ? ColorPrimary : textColor;
                chatLog.SelectionFont = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                chatLog.AppendText(header);

                chatLog.SelectionColor = textColor == ColorPrimary ? ColorTextDark : textColor;
                chatLog.SelectionFont = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                chatLog.AppendText(body);
            }
            else
            {
                chatLog.SelectionColor = textColor;
                var style = italic ? FontStyle.Italic : FontStyle.Regular;
                chatLog.SelectionFont = new Font("Segoe UI", 10.5F, style);
                chatLog.AppendText(text);
            }

            chatLog.AppendText(Environment.NewLine + Environment.NewLine);
            chatLog.ScrollToCaret();
        }
    }
}