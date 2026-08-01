namespace EasyBiz
{
    partial class ViewLedger
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
            comboSearchName = new ComboBox();
            label2 = new Label();
            comboSearchId = new ComboBox();
            label6 = new Label();
            BtnLoadLedger = new CustomButton();
            BtnExportPdf = new CustomButton();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            checkAllDates = new CheckBox();
            dataGridView1 = new DataGridView();
            sno = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            voucher_no = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            debit = new DataGridViewTextBoxColumn();
            credit = new DataGridViewTextBoxColumn();
            balance = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboSearchName
            // 
            comboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchName.Font = new Font("Segoe UI", 11F);
            comboSearchName.FormattingEnabled = true;
            comboSearchName.Location = new Point(190, 45);
            comboSearchName.Name = "comboSearchName";
            comboSearchName.Size = new Size(350, 33);
            comboSearchName.TabIndex = 2;
            comboSearchName.SelectedIndexChanged += comboSearchName_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(186, 20);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 15;
            label2.Text = "A/C Name";
            // 
            // comboSearchId
            // 
            comboSearchId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchId.Font = new Font("Segoe UI", 11F);
            comboSearchId.FormattingEnabled = true;
            comboSearchId.Location = new Point(20, 45);
            comboSearchId.Name = "comboSearchId";
            comboSearchId.Size = new Size(150, 33);
            comboSearchId.TabIndex = 1;
            comboSearchId.SelectedIndexChanged += comboSearchId_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Location = new Point(16, 20);
            label6.Name = "label6";
            label6.Size = new Size(58, 21);
            label6.TabIndex = 19;
            label6.Text = "A/C ID";
            // 
            // BtnLoadLedger
            // 
            BtnLoadLedger.BackColor = Color.FromArgb(13, 110, 253);
            BtnLoadLedger.BackgroundColor = Color.FromArgb(13, 110, 253);
            BtnLoadLedger.BorderColor = Color.Transparent;
            BtnLoadLedger.BorderRadius = 4;
            BtnLoadLedger.BorderSize = 0;
            BtnLoadLedger.FlatAppearance.BorderSize = 0;
            BtnLoadLedger.FlatStyle = FlatStyle.Flat;
            BtnLoadLedger.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnLoadLedger.ForeColor = Color.White;
            BtnLoadLedger.Location = new Point(980, 43);
            BtnLoadLedger.Name = "BtnLoadLedger";
            BtnLoadLedger.Size = new Size(110, 36);
            BtnLoadLedger.TabIndex = 6;
            BtnLoadLedger.Text = "Load";
            BtnLoadLedger.TextColor = Color.White;
            BtnLoadLedger.UseVisualStyleBackColor = false;
            // 
            // BtnExportPdf
            // 
            BtnExportPdf.BackColor = Color.FromArgb(220, 53, 69);
            BtnExportPdf.BackgroundColor = Color.FromArgb(220, 53, 69);
            BtnExportPdf.BorderColor = Color.Transparent;
            BtnExportPdf.BorderRadius = 4;
            BtnExportPdf.BorderSize = 0;
            BtnExportPdf.FlatAppearance.BorderSize = 0;
            BtnExportPdf.FlatStyle = FlatStyle.Flat;
            BtnExportPdf.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            BtnExportPdf.ForeColor = Color.White;
            BtnExportPdf.Location = new Point(1110, 43);
            BtnExportPdf.Name = "BtnExportPdf";
            BtnExportPdf.Size = new Size(160, 36);
            BtnExportPdf.TabIndex = 7;
            BtnExportPdf.Text = "Export PDF";
            BtnExportPdf.TextColor = Color.White;
            BtnExportPdf.UseVisualStyleBackColor = false;
            BtnExportPdf.Click += BtnExportPdf_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Font = new Font("Segoe UI", 11F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(560, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(130, 32);
            dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(556, 20);
            label1.Name = "label1";
            label1.Size = new Size(48, 21);
            label1.TabIndex = 32;
            label1.Text = "From";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 11F);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(710, 45);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(130, 32);
            dateTimePicker2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(706, 20);
            label3.Name = "label3";
            label3.Size = new Size(27, 21);
            label3.TabIndex = 34;
            label3.Text = "To";
            // 
            // checkAllDates
            // 
            checkAllDates.AutoSize = true;
            checkAllDates.Checked = true;
            checkAllDates.CheckState = CheckState.Checked;
            checkAllDates.Font = new Font("Segoe UI", 10.2F);
            checkAllDates.Location = new Point(860, 49);
            checkAllDates.Name = "checkAllDates";
            checkAllDates.Size = new Size(97, 27);
            checkAllDates.TabIndex = 5;
            checkAllDates.Text = "All dates";
            checkAllDates.UseVisualStyleBackColor = true;
            checkAllDates.CheckedChanged += checkAllDates_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, date, voucher_no, type, description, debit, credit, balance });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView1.Location = new Point(3, 103);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 42;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1283, 530);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // sno
            // 
            sno.HeaderText = "S.No";
            sno.MinimumWidth = 4;
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
            // voucher_no
            // 
            voucher_no.HeaderText = "Voucher#";
            voucher_no.MinimumWidth = 6;
            voucher_no.Name = "voucher_no";
            voucher_no.ReadOnly = true;
            // 
            // type
            // 
            type.HeaderText = "Type";
            type.MinimumWidth = 6;
            type.Name = "type";
            type.ReadOnly = true;
            // 
            // description
            // 
            description.HeaderText = "Description";
            description.MinimumWidth = 8;
            description.Name = "description";
            description.ReadOnly = true;
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
            // balance
            // 
            balance.HeaderText = "Balance";
            balance.MinimumWidth = 6;
            balance.Name = "balance";
            balance.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(BtnExportPdf);
            panel1.Controls.Add(BtnLoadLedger);
            panel1.Controls.Add(comboSearchName);
            panel1.Controls.Add(checkAllDates);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(comboSearchId);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1289, 100);
            panel1.TabIndex = 37;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1289, 636);
            tableLayoutPanel1.TabIndex = 35;
            // 
            // ViewLedger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1289, 636);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ViewLedger";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View Ledger";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSearchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSearchId;
        private System.Windows.Forms.Label label6;
        private EasyBiz.CustomButton BtnLoadLedger;
        private EasyBiz.CustomButton BtnExportPdf;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkAllDates;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn voucher_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}