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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboSearchName
            // 
            comboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchName.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchName.Font = new Font("Segoe UI", 12F);
            comboSearchName.FormattingEnabled = true;
            comboSearchName.Location = new Point(399, 121);
            comboSearchName.Name = "comboSearchName";
            comboSearchName.Size = new Size(479, 36);
            comboSearchName.TabIndex = 5;
            comboSearchName.SelectedIndexChanged += comboSearchName_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(303, 129);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.TabIndex = 15;
            label2.Text = "A/C Name";
            // 
            // comboSearchId
            // 
            comboSearchId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboSearchId.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboSearchId.Font = new Font("Segoe UI", 12F);
            comboSearchId.FormattingEnabled = true;
            comboSearchId.Location = new Point(83, 121);
            comboSearchId.Name = "comboSearchId";
            comboSearchId.Size = new Size(192, 36);
            comboSearchId.TabIndex = 4;
            comboSearchId.SelectedIndexChanged += comboSearchId_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(16, 129);
            label6.Name = "label6";
            label6.Size = new Size(61, 23);
            label6.TabIndex = 19;
            label6.Text = "A/C ID";
            // 
            // BtnLoadLedger
            // 
            BtnLoadLedger.BackColor = Color.FromArgb(52, 152, 219);
            BtnLoadLedger.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnLoadLedger.BorderColor = Color.Transparent;
            BtnLoadLedger.BorderRadius = 4;
            BtnLoadLedger.BorderSize = 0;
            BtnLoadLedger.FlatAppearance.BorderSize = 0;
            BtnLoadLedger.FlatStyle = FlatStyle.Flat;
            BtnLoadLedger.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnLoadLedger.ForeColor = Color.White;
            BtnLoadLedger.Location = new Point(518, 57);
            BtnLoadLedger.Name = "BtnLoadLedger";
            BtnLoadLedger.Size = new Size(125, 34);
            BtnLoadLedger.TabIndex = 6;
            BtnLoadLedger.Text = "Load";
            BtnLoadLedger.TextColor = Color.White;
            BtnLoadLedger.UseVisualStyleBackColor = false;
            // 
            // BtnExportPdf
            // 
            BtnExportPdf.BackColor = Color.Red;
            BtnExportPdf.BackgroundColor = Color.Red;
            BtnExportPdf.BorderColor = Color.Transparent;
            BtnExportPdf.BorderRadius = 4;
            BtnExportPdf.BorderSize = 0;
            BtnExportPdf.FlatAppearance.BorderSize = 0;
            BtnExportPdf.FlatStyle = FlatStyle.Flat;
            BtnExportPdf.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnExportPdf.ForeColor = Color.White;
            BtnExportPdf.Location = new Point(649, 57);
            BtnExportPdf.Name = "BtnExportPdf";
            BtnExportPdf.Size = new Size(229, 34);
            BtnExportPdf.TabIndex = 7;
            BtnExportPdf.Text = "Export PDF";
            BtnExportPdf.TextColor = Color.White;
            BtnExportPdf.UseVisualStyleBackColor = false;
            BtnExportPdf.Click += BtnExportPdf_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(83, 57);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(192, 34);
            dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 64);
            label1.Name = "label1";
            label1.Size = new Size(49, 23);
            label1.TabIndex = 32;
            label1.Text = "From";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(320, 57);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(192, 34);
            dateTimePicker2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(287, 64);
            label3.Name = "label3";
            label3.Size = new Size(27, 23);
            label3.TabIndex = 34;
            label3.Text = "To";
            // 
            // checkAllDates
            // 
            checkAllDates.AutoSize = true;
            checkAllDates.Checked = true;
            checkAllDates.CheckState = CheckState.Checked;
            checkAllDates.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkAllDates.Location = new Point(320, 22);
            checkAllDates.Name = "checkAllDates";
            checkAllDates.Size = new Size(104, 29);
            checkAllDates.TabIndex = 3;
            checkAllDates.Text = "All Dates";
            checkAllDates.UseVisualStyleBackColor = true;
            checkAllDates.CheckedChanged += checkAllDates_CheckedChanged;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { sno, date, voucher_no, type, description, debit, credit, balance });
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
            dataGridView1.Location = new Point(2, 186);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1185, 708);
            dataGridView1.TabIndex = 36;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // sno
            // 
            sno.HeaderText = "Sno";
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
            // ViewLedger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 636);
            Controls.Add(dataGridView1);
            Controls.Add(checkAllDates);
            Controls.Add(dateTimePicker2);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(comboSearchName);
            Controls.Add(label2);
            Controls.Add(BtnExportPdf);
            Controls.Add(comboSearchId);
            Controls.Add(BtnLoadLedger);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ViewLedger";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ViewLedger";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboSearchName;
        private Label label2;
        private ComboBox comboSearchId;
        private Label label6;
        private CustomButton BtnLoadLedger;
        private CustomButton BtnExportPdf;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private CheckBox checkAllDates;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn sno;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn voucher_no;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn debit;
        private DataGridViewTextBoxColumn credit;
        private DataGridViewTextBoxColumn balance;
    }
}