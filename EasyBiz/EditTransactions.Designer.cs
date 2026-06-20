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
            SuspendLayout();

            // comboType — now includes Bank Payment and Bank Receipt
            comboType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboType.Font = new Font("Segoe UI", 12F);
            comboType.FormattingEnabled = true;
            comboType.Items.AddRange(new object[]
            {
                "Cash Payment",
                "Cash Receipt",
                "Journal Voucher",
                "Bank Payment",       // NEW
                "Bank Receipt",       // NEW
                "Sale Invoice",
                "Purchase Invoice"
            });
            comboType.Location = new Point(169, 93);
            comboType.Name = "comboType";
            comboType.Size = new Size(223, 36);
            comboType.TabIndex = 0;

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(22, 101);
            label1.Name = "label1";
            label1.Size = new Size(141, 23);
            label1.TabIndex = 1;
            label1.Text = "Transaction Type:";

            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(61, 169);
            label2.Name = "label2";
            label2.Size = new Size(102, 23);
            label2.TabIndex = 2;
            label2.Text = "Voucher no:";

            // txtVoucherNo
            txtVoucherNo.Font = new Font("Segoe UI", 12F);
            txtVoucherNo.Location = new Point(169, 161);
            txtVoucherNo.Name = "txtVoucherNo";
            txtVoucherNo.Size = new Size(223, 34);
            txtVoucherNo.TabIndex = 3;

            // BtnGo
            BtnGo.BackColor = Color.FromArgb(52, 152, 219);
            BtnGo.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnGo.BorderColor = Color.Transparent;
            BtnGo.BorderRadius = 8;
            BtnGo.BorderSize = 0;
            BtnGo.FlatAppearance.BorderSize = 0;
            BtnGo.FlatStyle = FlatStyle.Flat;
            BtnGo.Font = new Font("Segoe UI", 12F);
            BtnGo.ForeColor = Color.White;
            BtnGo.Location = new Point(260, 228);
            BtnGo.Name = "BtnGo";
            BtnGo.Size = new Size(133, 45);
            BtnGo.TabIndex = 4;
            BtnGo.Text = "Go";
            BtnGo.TextColor = Color.White;
            BtnGo.UseVisualStyleBackColor = false;
            BtnGo.Click += BtnGo_Click;

            // EditTransactions form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 332);
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
    }
}