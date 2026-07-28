using System;
using System.Windows.Forms;
using System.Drawing;

namespace EasyBiz
{
    public partial class EditTransactions : Form
    {
        public EditTransactions()
        {
            InitializeComponent();
            comboType.SelectedIndex = 0;
            ThemeManager.ApplyTheme(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) 
            { 
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OpenTransaction<T>(int voucherNo)
            where T : Form, new()
        {
            dynamic form = new T();
            if (form.LoadTransactionForEditing(voucherNo))
            {
                form.ShowDialog();
            }
            
        }

        private void GetTransactions()
        {

            if (!int.TryParse(txtVoucherNo.Text.Trim(), out int voucherNumber))
            {
                MessageBox.Show("Voucher number must be a whole number.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string transactionType = comboType.SelectedItem!.ToString()!;

            switch (transactionType)
            {
                case "Cash Payment":
                    {
                        OpenTransaction<CashPayments>(voucherNumber);
                        break;
                    }
                case "Cash Receipt":
                    {
                        OpenTransaction<CashReceipts>(voucherNumber);
                        break;
                    }
                case "Journal Voucher":
                    {
                        OpenTransaction<JournalVoucher>(voucherNumber);
                        break;
                    }
                case "Sale Invoice":
                    {
                        OpenTransaction<SaleInvoice>(voucherNumber);
                        break;
                    }
                case "Purchase Invoice":
                    {
                        OpenTransaction<PurchaseInvoice>(voucherNumber);
                        break;
                    }
                case "Bank Payment":
                    {
                        OpenTransaction<BankPayment>(voucherNumber);
                        break;
                    }
                case "Bank Receipt":
                    {
                        OpenTransaction<BankReceipt>(voucherNumber);
                        break;
                    }
                default:
                    MessageBox.Show($"Unknown transaction type: {transactionType}");
                    break;
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            GetTransactions();
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVoucherNo.Focus();
        }

        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnGo.PerformClick();
            }
        }

        private void txtVoucherNo_TextChanged(object sender, EventArgs e)
        {
            bool hasText = !string.IsNullOrWhiteSpace(txtVoucherNo.Text);

            BtnGo.Enabled = hasText;
            BtnGo.BackColor = hasText
                ? Color.DodgerBlue
                : Color.Silver;
        }
    }
}