namespace EasyBiz
{
    partial class EditTransactions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboType = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtVoucherNo = new TextBox();
            BtnGo = new CustomButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // comboType
            // 
            comboType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboType.Font = new Font("Segoe UI", 12F);
            comboType.FormattingEnabled = true;
            comboType.Items.AddRange(new object[] { "Cash Payment", "Cash Receipt", "Journal Voucher", "Bank Payment", "Bank Receipt", "Sale Invoice", "Purchase Invoice" });
            comboType.Location = new Point(275, 132);
            comboType.Name = "comboType";
            comboType.Size = new Size(223, 36);
            comboType.TabIndex = 0;
            comboType.SelectedIndexChanged += comboType_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F);
            label1.Location = new Point(275, 96);
            label1.Name = "label1";
            label1.Size = new Size(171, 24);
            label1.TabIndex = 1;
            label1.Text = "Transaction Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F);
            label2.Location = new Point(275, 200);
            label2.Name = "label2";
            label2.Size = new Size(117, 24);
            label2.TabIndex = 2;
            label2.Text = "Voucher no:";
            // 
            // txtVoucherNo
            // 
            txtVoucherNo.Font = new Font("Segoe UI", 12F);
            txtVoucherNo.Location = new Point(275, 237);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.Size = new Size(223, 34);
            txtVoucherNo.TabIndex = 3;
            txtVoucherNo.TextAlign = HorizontalAlignment.Center;
            txtVoucherNo.KeyDown += txtVoucherNo_KeyDown;
            // 
            // BtnGo
            // 
            BtnGo.BackColor = Color.FromArgb(52, 152, 219);
            BtnGo.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnGo.BorderColor = Color.Transparent;
            BtnGo.BorderRadius = 8;
            BtnGo.BorderSize = 0;
            BtnGo.FlatAppearance.BorderSize = 0;
            BtnGo.FlatStyle = FlatStyle.Flat;
            BtnGo.Font = new Font("Segoe UI", 12F);
            BtnGo.ForeColor = Color.White;
            BtnGo.Location = new Point(301, 310);
            BtnGo.Name = "BtnGo";
            BtnGo.Size = new Size(171, 45);
            BtnGo.TabIndex = 4;
            BtnGo.Text = "Ready !";
            BtnGo.TextColor = Color.White;
            BtnGo.UseVisualStyleBackColor = false;
            BtnGo.Click += BtnGo_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackgroundImage = Properties.Resources.Edit;
            tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Zoom;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Location = new Point(24, 132);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(206, 136);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // EditTransactions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 429);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(BtnGo);
            Controls.Add(txtVoucherNo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboType);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditTransactions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Transactions";
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox comboType;
        private Label label1;
        private Label label2;
        private TextBox txtVoucherNo;
        private CustomButton BtnGo;
        private TableLayoutPanel tableLayoutPanel1;
    }
}