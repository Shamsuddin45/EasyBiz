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
            splitMain = new SplitContainer();
            pnlTop = new Panel();
            txtQuery = new TextBox();
            lblRecent = new Label();
            cboRecentQueries = new ComboBox();
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
            splitMain.Dock = DockStyle.Fill;
            splitMain.FixedPanel = FixedPanel.Panel1;
            splitMain.Location = new Point(0, 0);
            splitMain.Name = "splitMain";
            splitMain.Orientation = Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(pnlTop);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(pnlBottom);
            splitMain.Size = new Size(984, 661);
            splitMain.SplitterDistance = 220;
            splitMain.TabIndex = 0;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(txtQuery);
            pnlTop.Controls.Add(lblRecent);
            pnlTop.Controls.Add(cboRecentQueries);
            pnlTop.Controls.Add(pnlButtons);
            pnlTop.Dock = DockStyle.Fill;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(8);
            pnlTop.Size = new Size(984, 220);
            pnlTop.TabIndex = 0;
            // 
            // txtQuery
            // 
            txtQuery.AcceptsReturn = true;
            txtQuery.AcceptsTab = true;
            txtQuery.Dock = DockStyle.Fill;
            txtQuery.Font = new Font("Consolas", 10.5F);
            txtQuery.Location = new Point(8, 64);
            txtQuery.Multiline = true;
            txtQuery.Name = "txtQuery";
            txtQuery.ScrollBars = ScrollBars.Both;
            txtQuery.Size = new Size(968, 111);
            txtQuery.TabIndex = 0;
            txtQuery.WordWrap = false;
            txtQuery.KeyDown += txtQuery_KeyDown;
            // 
            // lblRecent
            // 
            lblRecent.AutoSize = true;
            lblRecent.Dock = DockStyle.Top;
            lblRecent.Location = new Point(8, 36);
            lblRecent.Name = "lblRecent";
            lblRecent.Padding = new Padding(0, 4, 0, 4);
            lblRecent.Size = new Size(57, 28);
            lblRecent.TabIndex = 3;
            lblRecent.Text = "Recent:";
            // 
            // cboRecentQueries
            // 
            cboRecentQueries.Dock = DockStyle.Top;
            cboRecentQueries.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRecentQueries.Location = new Point(8, 8);
            cboRecentQueries.Name = "cboRecentQueries";
            cboRecentQueries.Size = new Size(968, 28);
            cboRecentQueries.TabIndex = 4;
            cboRecentQueries.SelectedIndexChanged += cboRecentQueries_SelectedIndexChanged;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnExecute);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnExportCsv);
            pnlButtons.Controls.Add(chkAllowWrites);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(8, 175);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(0, 6, 0, 0);
            pnlButtons.Size = new Size(968, 37);
            pnlButtons.TabIndex = 1;
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(3, 9);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(130, 28);
            btnExecute.TabIndex = 0;
            btnExecute.Text = "Execute (F5)";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(139, 9);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(90, 28);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.Location = new Point(235, 9);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(130, 28);
            btnExportCsv.TabIndex = 2;
            btnExportCsv.Text = "Export CSV";
            btnExportCsv.UseVisualStyleBackColor = true;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // chkAllowWrites
            // 
            chkAllowWrites.ForeColor = Color.DarkRed;
            chkAllowWrites.Location = new Point(371, 9);
            chkAllowWrites.Name = "chkAllowWrites";
            chkAllowWrites.Size = new Size(260, 24);
            chkAllowWrites.TabIndex = 3;
            chkAllowWrites.Text = "Allow INSERT / UPDATE / DELETE / DDL";
            chkAllowWrites.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(dgvResults);
            pnlBottom.Controls.Add(statusStrip);
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Location = new Point(0, 0);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(984, 437);
            pnlBottom.TabIndex = 0;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.ColumnHeadersHeight = 29;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.Location = new Point(0, 0);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 30;
            dgvResults.Size = new Size(984, 411);
            dgvResults.TabIndex = 0;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, lblRowCount, lblElapsed });
            statusStrip.Location = new Point(0, 411);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(984, 26);
            statusStrip.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(877, 20);
            lblStatus.Spring = true;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRowCount
            // 
            lblRowCount.Name = "lblRowCount";
            lblRowCount.Size = new Size(52, 20);
            lblRowCount.Text = "0 rows";
            // 
            // lblElapsed
            // 
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new Size(40, 20);
            lblElapsed.Text = "0 ms";
            // 
            // SqlQueryRunnerForm
            // 
            ClientSize = new Size(984, 661);
            Controls.Add(splitMain);
            KeyPreview = true;
            MinimumSize = new Size(700, 450);
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
    }
}