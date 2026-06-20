namespace EasyBiz
{
    partial class OpeningBalances
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colDrCr = new DataGridViewComboBoxColumn();
            BtnSave = new CustomButton();
            BtnRefresh = new CustomButton();
            BtnClose = new CustomButton();
            lblNote = new Label();
            label1 = new Label();
            txtSearchAccount = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colType, colAmount, colDrCr });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(12, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 42;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1120, 527);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // colId
            // 
            colId.FillWeight = 60F;
            colId.HeaderText = "A/C ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.FillWeight = 220F;
            colName.HeaderText = "Account Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colType
            // 
            colType.HeaderText = "Category";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colAmount
            // 
            colAmount.FillWeight = 130F;
            colAmount.HeaderText = "Opening Balance";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            // 
            // colDrCr
            // 
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            colDrCr.DefaultCellStyle = dataGridViewCellStyle3;
            colDrCr.FillWeight = 70F;
            colDrCr.HeaderText = "Dr / Cr";
            colDrCr.Items.AddRange(new object[] { "Dr", "Cr" });
            colDrCr.MinimumWidth = 6;
            colDrCr.Name = "colDrCr";
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.LimeGreen;
            BtnSave.BackgroundColor = Color.LimeGreen;
            BtnSave.BorderColor = Color.Transparent;
            BtnSave.BorderRadius = 8;
            BtnSave.BorderSize = 0;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 11F);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(972, 676);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(160, 48);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "Save (Ctrl+S)";
            BtnSave.TextColor = Color.White;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            BtnRefresh.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnRefresh.BorderColor = Color.Transparent;
            BtnRefresh.BorderRadius = 8;
            BtnRefresh.BorderSize = 0;
            BtnRefresh.FlatAppearance.BorderSize = 0;
            BtnRefresh.FlatStyle = FlatStyle.Flat;
            BtnRefresh.Font = new Font("Segoe UI", 11F);
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(796, 676);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(160, 48);
            BtnRefresh.TabIndex = 2;
            BtnRefresh.Text = "Refresh [F5]";
            BtnRefresh.TextColor = Color.White;
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Tomato;
            BtnClose.BackgroundColor = Color.Tomato;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 8;
            BtnClose.BorderSize = 0;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Segoe UI", 11F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(644, 676);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(136, 48);
            BtnClose.TabIndex = 3;
            BtnClose.Text = "Close (Esc)";
            BtnClose.TextColor = Color.White;
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // lblNote
            // 
            lblNote.Font = new Font("Segoe UI", 10F);
            lblNote.ForeColor = Color.DimGray;
            lblNote.Location = new Point(12, 102);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(820, 28);
            lblNote.TabIndex = 0;
            lblNote.Text = "Enter opening balances for each account. Leave blank for zero. Click Save when done.";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(25, 44);
            label1.Name = "label1";
            label1.Size = new Size(138, 28);
            label1.TabIndex = 4;
            label1.Text = "Search Account:";
            // 
            // txtSearchAccount
            // 
            txtSearchAccount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchAccount.Location = new Point(169, 38);
            txtSearchAccount.Name = "txtSearchAccount";
            txtSearchAccount.Size = new Size(611, 34);
            txtSearchAccount.TabIndex = 5;
            txtSearchAccount.TextChanged += txtSearchAccount_TextChanged;
            // 
            // OpeningBalances
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 740);
            Controls.Add(txtSearchAccount);
            Controls.Add(label1);
            Controls.Add(lblNote);
            Controls.Add(dataGridView1);
            Controls.Add(BtnSave);
            Controls.Add(BtnRefresh);
            Controls.Add(BtnClose);
            Name = "OpeningBalances";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Opening Balances";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewComboBoxColumn colDrCr;
        private CustomButton BtnSave;
        private CustomButton BtnRefresh;
        private CustomButton BtnClose;
        private Label lblNote;
        private Label label1;
        private TextBox txtSearchAccount;
    }
}