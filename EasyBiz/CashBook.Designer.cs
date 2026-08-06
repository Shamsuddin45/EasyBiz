namespace EasyBiz
{
    partial class CashBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dateTo = new DateTimePicker();
            label3 = new Label();
            dateFrom = new DateTimePicker();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            sno = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            accountname = new DataGridViewTextBoxColumn();
            desc = new DataGridViewTextBoxColumn();
            debit = new DataGridViewTextBoxColumn();
            credit = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            lblInfo = new Label();
            BtnExport = new CustomButton();
            BtnLoad = new CustomButton();
            lblTotalDr = new Label();
            lblTotalCr = new Label();
            lblRunningBalance = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dateTo
            // 
            dateTo.Font = new Font("Segoe UI", 11F);
            dateTo.Format = DateTimePickerFormat.Short;
            dateTo.Location = new Point(320, 20);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(160, 32);
            dateTo.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(280, 24);
            label3.Name = "label3";
            label3.Size = new Size(31, 25);
            label3.TabIndex = 38;
            label3.Text = "To";
            // 
            // dateFrom
            // 
            dateFrom.Font = new Font("Segoe UI", 11F);
            dateFrom.Format = DateTimePickerFormat.Short;
            dateFrom.Location = new Point(80, 20);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(160, 32);
            dateFrom.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(15, 24);
            label1.Name = "label1";
            label1.Size = new Size(57, 25);
            label1.TabIndex = 37;
            label1.Text = "From";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(250, 250, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, date, type, accountname, desc, debit, credit });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(227, 242, 253);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
            dataGridView1.Location = new Point(0, 70);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1080, 438);
            dataGridView1.TabIndex = 40;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // sno
            // 
            sno.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            sno.HeaderText = "Sno";
            sno.MinimumWidth = 6;
            sno.Name = "sno";
            sno.ReadOnly = true;
            sno.Width = 81;
            // 
            // date
            // 
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.ReadOnly = true;
            date.Width = 88;
            // 
            // type
            // 
            type.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            type.HeaderText = "Type";
            type.MinimumWidth = 6;
            type.Name = "type";
            type.ReadOnly = true;
            type.Width = 88;
            // 
            // accountname
            // 
            accountname.HeaderText = "Account Name";
            accountname.MinimumWidth = 6;
            accountname.Name = "accountname";
            accountname.ReadOnly = true;
            // 
            // desc
            // 
            desc.HeaderText = "Description";
            desc.MinimumWidth = 6;
            desc.Name = "desc";
            desc.ReadOnly = true;
            // 
            // debit
            // 
            debit.HeaderText = "Debit";
            debit.MinimumWidth = 6;
            debit.Name = "debit";
            debit.ReadOnly = true;
            // 
            // credit
            // 
            credit.HeaderText = "Credit";
            credit.MinimumWidth = 6;
            credit.Name = "credit";
            credit.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblInfo);
            panel1.Controls.Add(BtnExport);
            panel1.Controls.Add(BtnLoad);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateFrom);
            panel1.Controls.Add(dateTo);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 70);
            panel1.TabIndex = 41;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfo.ForeColor = Color.DarkGray;
            lblInfo.Location = new Point(877, 20);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(445, 34);
            lblInfo.TabIndex = 43;
            lblInfo.Text = "Note: \r\nSale and Purchase is not included You can view them at Stock Report Form.";
            // 
            // BtnExport
            // 
            BtnExport.BackColor = Color.FromArgb(22, 160, 133);
            BtnExport.BackgroundColor = Color.FromArgb(22, 160, 133);
            BtnExport.BorderColor = Color.Transparent;
            BtnExport.BorderRadius = 6;
            BtnExport.BorderSize = 0;
            BtnExport.FlatAppearance.BorderSize = 0;
            BtnExport.FlatStyle = FlatStyle.Flat;
            BtnExport.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnExport.ForeColor = Color.White;
            BtnExport.Location = new Point(650, 16);
            BtnExport.Name = "BtnExport";
            BtnExport.Size = new Size(180, 40);
            BtnExport.TabIndex = 42;
            BtnExport.Text = "View / Export [F1]";
            BtnExport.TextColor = Color.White;
            BtnExport.UseVisualStyleBackColor = false;
            BtnExport.Click += BtnExport_Click;
            // 
            // BtnLoad
            // 
            BtnLoad.BackColor = Color.FromArgb(41, 128, 185);
            BtnLoad.BackgroundColor = Color.FromArgb(41, 128, 185);
            BtnLoad.BorderColor = Color.Transparent;
            BtnLoad.BorderRadius = 6;
            BtnLoad.BorderSize = 0;
            BtnLoad.FlatAppearance.BorderSize = 0;
            BtnLoad.FlatStyle = FlatStyle.Flat;
            BtnLoad.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnLoad.ForeColor = Color.White;
            BtnLoad.Location = new Point(500, 16);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(140, 40);
            BtnLoad.TabIndex = 41;
            BtnLoad.Text = "Load [F5]";
            BtnLoad.TextColor = Color.White;
            BtnLoad.UseVisualStyleBackColor = false;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // lblTotalDr
            // 
            lblTotalDr.AutoSize = true;
            lblTotalDr.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalDr.ForeColor = Color.FromArgb(192, 57, 43);
            lblTotalDr.Location = new Point(143, 12);
            lblTotalDr.Margin = new Padding(10, 12, 30, 10);
            lblTotalDr.Name = "lblTotalDr";
            lblTotalDr.Size = new Size(83, 28);
            lblTotalDr.TabIndex = 42;
            lblTotalDr.Text = "Debit: -";
            // 
            // lblTotalCr
            // 
            lblTotalCr.AutoSize = true;
            lblTotalCr.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalCr.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalCr.Location = new Point(15, 12);
            lblTotalCr.Margin = new Padding(15, 12, 30, 10);
            lblTotalCr.Name = "lblTotalCr";
            lblTotalCr.Size = new Size(88, 28);
            lblTotalCr.TabIndex = 43;
            lblTotalCr.Text = "Credit: -";
            // 
            // lblRunningBalance
            // 
            lblRunningBalance.AutoSize = true;
            lblRunningBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRunningBalance.ForeColor = Color.FromArgb(44, 62, 80);
            lblRunningBalance.Location = new Point(266, 12);
            lblRunningBalance.Margin = new Padding(10, 12, 30, 10);
            lblRunningBalance.Name = "lblRunningBalance";
            lblRunningBalance.Size = new Size(105, 28);
            lblRunningBalance.TabIndex = 44;
            lblRunningBalance.Text = "Balance: -";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.WhiteSmoke;
            flowLayoutPanel1.Controls.Add(lblTotalCr);
            flowLayoutPanel1.Controls.Add(lblTotalDr);
            flowLayoutPanel1.Controls.Add(lblRunningBalance);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 508);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1080, 50);
            flowLayoutPanel1.TabIndex = 45;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(1080, 558);
            tableLayoutPanel1.TabIndex = 46;
            // 
            // CashBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1080, 558);
            Controls.Add(tableLayoutPanel1);
            Name = "CashBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CashBook";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private EasyBiz.CustomButton BtnLoad;
        private EasyBiz.CustomButton BtnExport;
        private System.Windows.Forms.Label lblTotalDr;
        private System.Windows.Forms.Label lblTotalCr;
        private System.Windows.Forms.Label lblRunningBalance;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn sno;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn accountname;
        private DataGridViewTextBoxColumn desc;
        private DataGridViewTextBoxColumn debit;
        private DataGridViewTextBoxColumn credit;
        private Label lblInfo;
    }
}