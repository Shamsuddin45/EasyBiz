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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dateTo = new DateTimePicker();
            label3 = new Label();
            dateFrom = new DateTimePicker();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            sno = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            accontname = new DataGridViewTextBoxColumn();
            desc = new DataGridViewTextBoxColumn();
            debit = new DataGridViewTextBoxColumn();
            credit = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            BtnExport = new CustomButton();
            BtnLoad = new CustomButton();
            lblTotalDr = new Label();
            lblTotalCr = new Label();
            lblRunningBalance = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dateTo
            // 
            dateTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTo.Format = DateTimePickerFormat.Short;
            dateTo.Location = new Point(573, 56);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(192, 34);
            dateTo.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(535, 56);
            label3.Name = "label3";
            label3.Size = new Size(32, 28);
            label3.TabIndex = 38;
            label3.Text = "To";
            // 
            // dateFrom
            // 
            dateFrom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateFrom.Format = DateTimePickerFormat.Short;
            dateFrom.Location = new Point(333, 55);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(192, 34);
            dateFrom.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(269, 55);
            label1.Name = "label1";
            label1.Size = new Size(58, 28);
            label1.TabIndex = 37;
            label1.Text = "From";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, date, type, accontname, desc, debit, credit });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1624, 439);
            dataGridView1.TabIndex = 40;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // sno
            // 
            sno.HeaderText = "Sno";
            sno.MinimumWidth = 6;
            sno.Name = "sno";
            sno.ReadOnly = true;
            // 
            // date
            // 
            date.HeaderText = "Date";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.ReadOnly = true;
            // 
            // type
            // 
            type.HeaderText = "Type";
            type.MinimumWidth = 6;
            type.Name = "type";
            type.ReadOnly = true;
            // 
            // accontname
            // 
            accontname.HeaderText = "Account Name";
            accontname.MinimumWidth = 6;
            accontname.Name = "accontname";
            accontname.ReadOnly = true;
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
            panel1.Controls.Add(BtnExport);
            panel1.Controls.Add(BtnLoad);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateFrom);
            panel1.Controls.Add(dateTo);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1630, 120);
            panel1.TabIndex = 41;
            // 
            // BtnExport
            // 
            BtnExport.BackColor = Color.RoyalBlue;
            BtnExport.BackgroundColor = Color.RoyalBlue;
            BtnExport.BorderColor = Color.Transparent;
            BtnExport.BorderRadius = 8;
            BtnExport.BorderSize = 0;
            BtnExport.FlatAppearance.BorderSize = 0;
            BtnExport.FlatStyle = FlatStyle.Flat;
            BtnExport.ForeColor = Color.White;
            BtnExport.Location = new Point(914, 56);
            BtnExport.Name = "BtnExport";
            BtnExport.Size = new Size(127, 36);
            BtnExport.TabIndex = 42;
            BtnExport.Text = "Export [F1]";
            BtnExport.TextColor = Color.White;
            BtnExport.UseVisualStyleBackColor = false;
            BtnExport.Click += BtnExport_Click;
            // 
            // BtnLoad
            // 
            BtnLoad.BackColor = Color.ForestGreen;
            BtnLoad.BackgroundColor = Color.ForestGreen;
            BtnLoad.BorderColor = Color.Transparent;
            BtnLoad.BorderRadius = 8;
            BtnLoad.BorderSize = 0;
            BtnLoad.FlatAppearance.BorderSize = 0;
            BtnLoad.FlatStyle = FlatStyle.Flat;
            BtnLoad.ForeColor = Color.White;
            BtnLoad.Location = new Point(781, 56);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(127, 36);
            BtnLoad.TabIndex = 41;
            BtnLoad.Text = "Load [F5]";
            BtnLoad.TextColor = Color.White;
            BtnLoad.UseVisualStyleBackColor = false;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // lblTotalDr
            // 
            lblTotalDr.AutoSize = true;
            lblTotalDr.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalDr.ForeColor = Color.Red;
            lblTotalDr.Location = new Point(15, 9);
            lblTotalDr.Name = "lblTotalDr";
            lblTotalDr.Size = new Size(83, 28);
            lblTotalDr.TabIndex = 42;
            lblTotalDr.Text = "Debit: -";
            // 
            // lblTotalCr
            // 
            lblTotalCr.AutoSize = true;
            lblTotalCr.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCr.ForeColor = Color.ForestGreen;
            lblTotalCr.Location = new Point(15, 44);
            lblTotalCr.Name = "lblTotalCr";
            lblTotalCr.Size = new Size(88, 28);
            lblTotalCr.TabIndex = 43;
            lblTotalCr.Text = "Credit: -";
            // 
            // lblRunningBalance
            // 
            lblRunningBalance.AutoSize = true;
            lblRunningBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRunningBalance.ForeColor = Color.Black;
            lblRunningBalance.Location = new Point(15, 79);
            lblRunningBalance.Name = "lblRunningBalance";
            lblRunningBalance.Size = new Size(105, 28);
            lblRunningBalance.TabIndex = 44;
            lblRunningBalance.Text = "Balance: -";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalCr);
            panel2.Controls.Add(lblRunningBalance);
            panel2.Controls.Add(lblTotalDr);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 571);
            panel2.Name = "panel2";
            panel2.Size = new Size(1630, 119);
            panel2.TabIndex = 45;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(1630, 451);
            panel3.TabIndex = 46;
            // 
            // CashBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1630, 690);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CashBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CashBook";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTo;
        private Label label3;
        private DateTimePicker dateFrom;
        private Label label1;        
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn sno;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn accontname;
        private DataGridViewTextBoxColumn desc;
        private DataGridViewTextBoxColumn debit;
        private DataGridViewTextBoxColumn credit;
        private Panel panel1;
        private CustomButton BtnLoad;
        private CustomButton BtnExport;
        private Label lblTotalDr;
        private Label lblTotalCr;
        private Label lblRunningBalance;
        private Panel panel2;
        private Panel panel3;
    }
}