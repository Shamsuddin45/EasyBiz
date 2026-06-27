using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class AccountsSetup : Form
    {
        public AccountsSetup()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            comboCategory.SelectedItem = "Receivables";
            LoadAccounts();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtNewAccount.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    if (BtnSave.Enabled)
                        BtnSave_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.U:
                    if (BtnUpdate.Enabled)
                        BtnUpdate_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.R:
                    BtnRefresh_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Escape:
                    BtnClose_Click(this, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void LoadAccounts()
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT account_id, account_name FROM accounts ORDER BY account_name";

                using (var reader = command.ExecuteReader())
                {
                    comboSearchName.Items.Clear();
                    comboSearchId.Items.Clear();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        comboSearchName.Items.Add(name);
                        comboSearchId.Items.Add(id.ToString());
                    }
                }
            }
        }
        public void LoadAccountDetails(int accountId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT account_id, account_name, account_type, address, mobile_number, current_balance FROM accounts WHERE account_id = @id";
                command.Parameters.AddWithValue("@id", accountId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        numAccountId.Value = reader.GetInt32(0);
                        txtNewAccount.Text = reader.GetString(1);
                        comboCategory.SelectedItem = reader.GetString(2);
                        txtAddress.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        txtContact.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        // You can also show balance if needed
                        // lblBalance.Text = reader.GetDecimal(5).ToString("N2");
                    }
                }
            }
        }

        public void RefreshForm()
        {
            txtNewAccount.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            comboSearchId.SelectedIndex = -1;
            comboSearchName.SelectedIndex = -1;
            numAccountId.Value = PeekNextAccountId(comboCategory.SelectedItem.ToString());
            LoadAccounts();
            txtNewAccount.Focus();
        }

        public int GetNextAccountId(string category)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT last_id FROM account_id_tracker WHERE category = @category";
                command.Parameters.AddWithValue("@category", category);

                var result = command.ExecuteScalar();
                int nextId;

                if (result == null || result == DBNull.Value)
                {
                    // Category not seeded yet → insert default base ID
                    nextId = GetDefaultId(category);
                    using (var insertCmd = connection.CreateCommand())
                    {
                        insertCmd.CommandText = "INSERT INTO account_id_tracker (category, last_id) VALUES (@category, @id)";
                        insertCmd.Parameters.AddWithValue("@category", category);
                        insertCmd.Parameters.AddWithValue("@id", nextId);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Increment existing ID
                    nextId = Convert.ToInt32(result) + 1;
                    using (var updateCmd = connection.CreateCommand())
                    {
                        updateCmd.CommandText = "UPDATE account_id_tracker SET last_id = @id WHERE category = @category";
                        updateCmd.Parameters.AddWithValue("@id", nextId);
                        updateCmd.Parameters.AddWithValue("@category", category);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                return nextId;
            }
        }
        public int PeekNextAccountId(string category)
        {
            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT last_id FROM account_id_tracker WHERE category = @category";
                command.Parameters.AddWithValue("@category", category);

                var result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    return GetDefaultId(category); // show starting ID
                }
                else
                {
                    return Convert.ToInt32(result) + 1; // show next available ID
                }
            }
        }

        private int GetDefaultId(string category)
        {
            switch (category)
            {
                case "Cash": return 10001;
                case "Banks": return 20001;
                case "Assets": return 30001;
                case "Capital": return 40001;
                case "Brokers": return 50001;
                case "Personal Ledgers": return 60001;
                case "Payables": return 70001;
                case "Receivables": return 80001;
                case "Employees": return 90001;
                case "Expenses": return 100001;
                case "Others": return 110001;
                default: return 1;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Creates a new account record in the database
        /// </summary>
        public void CreateAccount(string accountName, string accountType, string address, string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(accountName))
            {
                MessageBox.Show("Please enter an account name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    // Check if account already exists
                    using (var checkCommand = connection.CreateCommand())
                    {
                        checkCommand.CommandText = @"
                    SELECT COUNT(*)
                    FROM accounts
                    WHERE LOWER(account_name) = LOWER(@name)";

                        checkCommand.Parameters.AddWithValue("@name", accountName.Trim());

                        long count = (long)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("An account with this name already exists.",
                                "Duplicate Account",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int nextId = GetNextAccountId(accountType);

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                    INSERT INTO accounts
                    (account_id, account_name, account_type, address, mobile_number, current_balance)
                    VALUES
                    (@id, @name, @type, @address, @mobile, @current);";

                        command.Parameters.AddWithValue("@id", nextId);
                        command.Parameters.AddWithValue("@name", accountName.Trim());
                        command.Parameters.AddWithValue("@type", accountType);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@mobile", mobileNumber);
                        command.Parameters.AddWithValue("@current", 0);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Account created successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    RefreshForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating account: " + ex.Message);
                }
            }
        }

        public void UpdateAccount(int accountId, string accountName, string accountType, string address, string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(accountName))
            {
                MessageBox.Show("Please enter an account name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    command.CommandText =
                    @"
            UPDATE accounts
            SET account_name = @name,
                account_type = @type,
                address = @address,
                mobile_number = @mobile
            WHERE account_id = @id;
            ";
                    command.Parameters.AddWithValue("@id", accountId);
                    command.Parameters.AddWithValue("@name", accountName);
                    command.Parameters.AddWithValue("@type", accountType);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@mobile", mobileNumber);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshForm();
                        LoadAccounts(); // refresh combo boxes
                    }
                    else
                    {
                        MessageBox.Show("No account found with the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating account: " + ex.Message);
                }
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            CreateAccount(txtNewAccount.Text, comboCategory.SelectedItem.ToString(), txtAddress.Text, txtContact.Text);
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboSearchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSearchName.SelectedIndex >= 0)
            {
                comboSearchId.SelectedIndex = comboSearchName.SelectedIndex;
                int accountId = int.Parse(comboSearchId.SelectedItem.ToString());
                LoadAccountDetails(accountId);
            }
            BtnSave.Enabled = false;
        }

        private void comboSearchId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSearchId.SelectedIndex >= 0)
            {
                comboSearchName.SelectedIndex = comboSearchId.SelectedIndex;
                int accountId = int.Parse(comboSearchId.SelectedItem.ToString());
                LoadAccountDetails(accountId);
            }
            BtnSave.Enabled = false;
            BtnUpdate.Enabled = true;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount((int)numAccountId.Value, txtNewAccount.Text, comboCategory.SelectedItem.ToString(),
                          txtAddress.Text, txtContact.Text);
            BtnSave.Enabled = true;
            BtnUpdate.Enabled = false;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void txtNewAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtAddress.Focus(); }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtContact.Focus(); }
        }

        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (BtnSave.Enabled == true) { BtnSave.Focus(); }
                else { BtnUpdate.Focus(); }
            }
        }

        private void AccountsSetup_Load(object sender, EventArgs e)
        {

        }

        private void AccountsSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtNewAccount.Text != "" || txtAddress.Text != "" || txtContact.Text != "")
            {
                var result = MessageBox.Show("Are you sure you want to close the Accounts Setup?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else { e.Cancel = false; }
        }

        private void comboCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numAccountId.Value = PeekNextAccountId(comboCategory.SelectedItem.ToString());
                txtNewAccount.Focus();
            }
    }
    }
}

