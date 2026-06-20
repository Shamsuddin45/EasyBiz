using System;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class EditTransactions : Form
    {
        public EditTransactions()
        {
            InitializeComponent();
            comboType.SelectedIndex = 0;
        }

        private void GetTransactions()
        {
            if (string.IsNullOrWhiteSpace(txtVoucherNo.Text))
            {
                MessageBox.Show("Please enter a voucher number.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtVoucherNo.Text, out int voucherNumber))
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
                        var form = new CashPayments();
                        form.LoadTransactionForEditing(voucherNumber);
                        form.ShowDialog();
                        break;
                    }
                case "Cash Receipt":
                    {
                        var form = new CashReceipts();
                        form.LoadTransactionForEditing(voucherNumber);
                        form.ShowDialog();
                        break;
                    }
                case "Journal Voucher":
                    {
                        var form = new JournalVoucher();
                        form.LoadTransactionForEditing(voucherNumber);
                        form.ShowDialog();
                        break;
                    }
                case "Sale Invoice":
                    {
                        var form = new SaleInvoice();
                        form.LoadTransactionForEditing(voucherNumber);
                        form.ShowDialog();
                        break;
                    }
                case "Purchase Invoice":
                    {
                        var form = new PurchaseInvoice();
                        form.LoadTransactionForEditing(voucherNumber);
                        form.ShowDialog();
                        break;
                    }
                case "Bank Payment":
                    {
                        var form = new BankPayment();
                        form.LoadTransactionForEditing(voucherNumber);
                        form.ShowDialog();
                        break;
                    }
                case "Bank Receipt":
                    {
                        var form = new BankReceipt();
                        form.LoadTransactionForEditing(voucherNumber);
                        form.ShowDialog();
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
    }
}