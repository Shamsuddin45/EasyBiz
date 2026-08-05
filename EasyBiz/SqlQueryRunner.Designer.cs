namespace EasyBiz.Forms
{
    partial class SqlQueryRunnerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            splitMain = new SplitContainer();
            pnlTop = new Panel();
            txtQuery = new TextBox();
            label1 = new Label();
            cboRecentQueries = new ComboBox();
            lblRecent = new Label();
            pnlButtons = new FlowLayoutPanel();
            btnExecute = new Button();
            btnClear = new Button();
            btnExportCsv = new Button();
            chkAllowWrites = new CheckBox();
            pnlBottom = new Panel();
            dgvResults = new DataGridView();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            lblRowCount = new ToolStripStatusLabel();
            lblElapsed = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            pnlTop.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // splitMain
            // 
            splitMain.BackColor = Color.FromArgb(230, 230, 230);
            splitMain.Dock = DockStyle.Fill;
            splitMain.FixedPanel = FixedPanel.Panel1;
            splitMain.Location = new Point(0, 0);
            splitMain.Name = "splitMain";
            splitMain.Orientation = Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.BackColor = Color.FromArgb(250, 250, 252);
            splitMain.Panel1.Controls.Add(pnlTop);
            splitMain.Panel1.Padding = new Padding(10);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(pnlBottom);
            splitMain.Size = new Size(1008, 729);
            splitMain.SplitterDistance = 260;
            splitMain.TabIndex = 0;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Transparent;
            pnlTop.Controls.Add(txtQuery);
            pnlTop.Controls.Add(label1);
            pnlTop.Controls.Add(cboRecentQueries);
            pnlTop.Controls.Add(lblRecent);
            pnlTop.Controls.Add(pnlButtons);
            pnlTop.Dock = DockStyle.Fill;
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(988, 240);
            pnlTop.TabIndex = 0;
            // 
            // txtQuery
            // 
            txtQuery.AcceptsReturn = true;
            txtQuery.AcceptsTab = true;
            txtQuery.BorderStyle = BorderStyle.FixedSingle;
            txtQuery.Dock = DockStyle.Fill;
            txtQuery.Font = new Font("Consolas", 11F);
            txtQuery.Location = new Point(0, 99);
            txtQuery.Multiline = true;
            txtQuery.Name = "txtQuery";
            txtQuery.PlaceholderText = "SELECT * FROM accounts;";
            txtQuery.ScrollBars = ScrollBars.Both;
            txtQuery.Size = new Size(988, 93);
            txtQuery.TabIndex = 0;
            txtQuery.WordWrap = false;
            txtQuery.KeyDown += txtQuery_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(0, 65);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 6, 0, 8);
            label1.Size = new Size(39, 34);
            label1.TabIndex = 5;
            label1.Text = "-----";
            // 
            // cboRecentQueries
            // 
            cboRecentQueries.Dock = DockStyle.Top;
            cboRecentQueries.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRecentQueries.FlatStyle = FlatStyle.Flat;
            cboRecentQueries.Font = new Font("Segoe UI", 10F);
            cboRecentQueries.FormattingEnabled = true;
            cboRecentQueries.Location = new Point(0, 34);
            cboRecentQueries.Margin = new Padding(8);
            cboRecentQueries.Name = "cboRecentQueries";
            cboRecentQueries.Size = new Size(988, 31);
            cboRecentQueries.TabIndex = 4;
            cboRecentQueries.SelectedIndexChanged += cboRecentQueries_SelectedIndexChanged;
            // 
            // lblRecent
            // 
            lblRecent.AutoSize = true;
            lblRecent.Dock = DockStyle.Top;
            lblRecent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblRecent.ForeColor = Color.FromArgb(64, 64, 64);
            lblRecent.Location = new Point(0, 0);
            lblRecent.Name = "lblRecent";
            lblRecent.Padding = new Padding(0, 6, 0, 8);
            lblRecent.Size = new Size(59, 34);
            lblRecent.TabIndex = 3;
            lblRecent.Text = "Recent:";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnExecute);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnExportCsv);
            pnlButtons.Controls.Add(chkAllowWrites);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 192);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(0, 10, 0, 0);
            pnlButtons.Size = new Size(988, 48);
            pnlButtons.TabIndex = 1;
            // 
            // btnExecute
            // 
            btnExecute.BackColor = Color.FromArgb(0, 120, 215);
            btnExecute.Cursor = Cursors.Hand;
            btnExecute.FlatAppearance.BorderSize = 0;
            btnExecute.FlatStyle = FlatStyle.Flat;
            btnExecute.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnExecute.ForeColor = Color.White;
            btnExecute.Location = new Point(3, 13);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(140, 32);
            btnExecute.TabIndex = 0;
            btnExecute.Text = "Execute (F5)";
            btnExecute.UseVisualStyleBackColor = false;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.Location = new Point(149, 13);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 32);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.White;
            btnExportCsv.Cursor = Cursors.Hand;
            btnExportCsv.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Font = new Font("Segoe UI", 9.5F);
            btnExportCsv.Location = new Point(255, 13);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(140, 32);
            btnExportCsv.TabIndex = 2;
            btnExportCsv.Text = "Export CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // chkAllowWrites
            // 
            chkAllowWrites.AutoSize = true;
            chkAllowWrites.Font = new Font("Segoe UI", 9.5F);
            chkAllowWrites.ForeColor = Color.FromArgb(192, 0, 0);
            chkAllowWrites.Location = new Point(408, 14);
            chkAllowWrites.Margin = new Padding(10, 4, 3, 3);
            chkAllowWrites.Name = "chkAllowWrites";
            chkAllowWrites.Size = new Size(304, 25);
            chkAllowWrites.TabIndex = 3;
            chkAllowWrites.Text = "Allow INSERT / UPDATE / DELETE / DDL";
            chkAllowWrites.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(dgvResults);
            pnlBottom.Controls.Add(statusStrip);
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Location = new Point(0, 0);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1008, 465);
            pnlBottom.TabIndex = 0;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 248, 250);
            dgvResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(235, 235, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvResults.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 230, 250);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvResults.DefaultCellStyle = dataGridViewCellStyle3;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.GridColor = Color.FromArgb(224, 224, 224);
            dgvResults.Location = new Point(0, 0);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.RowTemplate.Height = 32;
            dgvResults.Size = new Size(1008, 439);
            dgvResults.TabIndex = 0;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(240, 240, 240);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblRowCount, lblElapsed });
            statusStrip.Location = new Point(0, 439);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1008, 26);
            statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(890, 20);
            lblStatus.Spring = true;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRowCount
            // 
            lblRowCount.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblRowCount.Name = "lblRowCount";
            lblRowCount.Size = new Size(53, 20);
            lblRowCount.Text = "0 rows";
            // 
            // lblElapsed
            // 
            lblElapsed.Margin = new Padding(10, 3, 0, 2);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new Size(40, 21);
            lblElapsed.Text = "0 ms";
            // 
            // SqlQueryRunnerForm
            // 
            BackColor = Color.FromArgb(250, 250, 252);
            ClientSize = new Size(1008, 729);
            Controls.Add(splitMain);
            Font = new Font("Segoe UI", 9.5F);
            KeyPreview = true;
            MinimumSize = new Size(800, 500);
            Name = "SqlQueryRunnerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SQL Query Runner";
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.CheckBox chkAllowWrites;
        private System.Windows.Forms.ComboBox cboRecentQueries;
        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblRowCount;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsed;
        private Label label1;
    }
}