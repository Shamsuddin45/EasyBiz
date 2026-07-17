using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace EasyBiz
{
    public partial class ProductSetup : Form
    {
        public ProductSetup()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            comboUnit.Items.AddRange(new[] { "PCS", "KG", "TON", "MTR", "LTR", "BAG", "BOX" });
            comboWeightUnit.Items.AddRange(new[] { "KG", "TON", "G", "LBS", "MUN" });
            comboUnit.SelectedItem = "PCS";
            comboWeightUnit.SelectedItem = "KG";
            comboSelectUnit.SelectedItem = "Quantity"; // Default selection            
            ClearForm();
            ThemeManager.ApplyTheme(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    // focus to the next control                
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    return true;

                case Keys.Control | Keys.S:
                    BtnSave_Click(this, EventArgs.Empty);
                    return true;

                case Keys.Control | Keys.U:
                    BtnUpdate_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F5:
                    BtnRefresh_Click(this, EventArgs.Empty);
                    return true;

                case Keys.F1:
                    comboSearch.Focus();
                    return true;

                case Keys.Escape:
                    BtnClose_Click(this, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        
        private void LoadProducts()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();                

                using var cmd = conn.CreateCommand();                
                cmd.CommandText = "SELECT product_id, product_name FROM products ORDER BY product_name";

                using var reader = cmd.ExecuteReader();

                comboSearch.BeginUpdate(); // Prevents UI flickering during bulk add
                comboSearch.Items.Clear();

                while (reader.Read())
                {
                    comboSearch.Items.Add(new ProductItem
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1).Trim()
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                comboSearch.EndUpdate();
            }
        }
        public class ProductItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name; // ensures combo shows only the name
        }


        private void LoadProductDetails(int productId)
        {
            BtnUpdate.Enabled = true;
            BtnSave.Enabled = false;

            try
            {
                using var conn = DatabaseHelper.GetConnection();                

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT product_name, description, unit, weight_unit, 
                                   sale_rate, purchase_rate, min_stock_qty, isUnit 
                            FROM products WHERE product_id = @id";
                cmd.Parameters.AddWithValue("@id", productId);

                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    txtProductName.Text = r.GetString(0);
                    txtDescription.Text = r.IsDBNull(1) ? "" : r.GetString(1);
                    comboUnit.Text = r.IsDBNull(2) ? "" : r.GetString(2);
                    comboWeightUnit.Text = r.IsDBNull(3) ? "" : r.GetString(3);

                    // Safer conversion to decimal for NumericUpDown controls
                    numSaleRate.Value = r.IsDBNull(4) ? 0 : Convert.ToDecimal(r.GetValue(4));
                    numPurchaseRate.Value = r.IsDBNull(5) ? 0 : Convert.ToDecimal(r.GetValue(5));
                    numMinStock.Value = r.IsDBNull(6) ? 0 : Convert.ToDecimal(r.GetValue(6));

                    // Handles smallint/int conversion to bool cleanly
                    bool isUnit = Convert.ToInt32(r.GetValue(7)) == 1;
                    comboSelectUnit.Text = isUnit ? "Quantity" : "Weight";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowVoucherNo()
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqliteCommand(
                "SELECT COALESCE(MAX(product_id), 0) + 1 FROM products", conn);
            numProductId.Text = cmd.ExecuteScalar()!.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            { MessageBox.Show("Product name is required."); return; }

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO products (product_name, description, unit, weight_unit,
                                      isUnit, sale_rate, purchase_rate, min_stock_qty)
                VALUES (@name, @desc, @unit, @wu, @isUnit, @sr, @pr, @min)";
            cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@unit", comboUnit.Text);
            cmd.Parameters.AddWithValue("@wu", comboWeightUnit.Text);
            if (comboSelectUnit.SelectedItem == "Quantity")
            {
                cmd.Parameters.AddWithValue("@isUnit", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@isUnit", 0);
            }
            cmd.Parameters.AddWithValue("@sr", (double)numSaleRate.Value);
            cmd.Parameters.AddWithValue("@pr", (double)numPurchaseRate.Value);
            cmd.Parameters.AddWithValue("@min", (double)numMinStock.Value);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearForm();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (numProductId.Value == 0 && comboSearch.SelectedItem == null) { MessageBox.Show("Select a product first."); return; }
            if (string.IsNullOrWhiteSpace(txtProductName.Text)) { MessageBox.Show("Product name is required."); return; }

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE products SET product_name=@name, description=@desc, unit=@unit,
                    weight_unit=@wu, sale_rate=@sr, purchase_rate=@pr, min_stock_qty=@min
                WHERE product_id=@id";
            cmd.Parameters.AddWithValue("@id", (int)numProductId.Value);
            cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim());
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@unit", comboUnit.Text);
            cmd.Parameters.AddWithValue("@wu", comboWeightUnit.Text);
            cmd.Parameters.AddWithValue("@sr", (double)numSaleRate.Value);
            cmd.Parameters.AddWithValue("@pr", (double)numPurchaseRate.Value);
            cmd.Parameters.AddWithValue("@min", (double)numMinStock.Value);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product updated!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSearch.SelectedItem == null) return;            
            var item = (ProductItem)comboSearch.SelectedItem;            
            int productId = item.Id;
            numProductId.Value = productId;
            LoadProductDetails(productId);
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            txtDescription.Clear();
            numSaleRate.Value = 0;
            numPurchaseRate.Value = 0;
            numMinStock.Value = 0;
            comboSearch.SelectedIndex = -1;
            ShowVoucherNo();
            BtnUpdate.Enabled = false;
            BtnSave.Enabled = true;
            txtProductName.Focus();
        }
        private void BtnRefresh_Click(object sender, EventArgs e) => ClearForm();
        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSelectUnit.SelectedItem == "Weight")
            {
                comboUnit.Enabled = false;
                comboWeightUnit.Enabled = true;
            }
            else
            {
                comboUnit.Enabled = true;
                comboWeightUnit.Enabled = false;
            }
        }

        private void ProductSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtProductName.Text != "" || txtDescription.Text != "" || numSaleRate.Value != 0 || numPurchaseRate.Value != 0)
            {
                var result = MessageBox.Show("Are you sure you want to close the Product Setup?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void ProductSetup_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
