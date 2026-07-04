namespace EasyBiz
{
    partial class Settings
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            BtnSaveFavorites = new CustomButton();
            clbFavorites = new CheckedListBox();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BtnSaveFavorites);
            tabPage1.Controls.Add(clbFavorites);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Favourties";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnSaveFavorites
            // 
            BtnSaveFavorites.BackColor = Color.FromArgb(52, 152, 219);
            BtnSaveFavorites.BackgroundColor = Color.FromArgb(52, 152, 219);
            BtnSaveFavorites.BorderColor = Color.Transparent;
            BtnSaveFavorites.BorderRadius = 15;
            BtnSaveFavorites.BorderSize = 0;
            BtnSaveFavorites.FlatAppearance.BorderSize = 0;
            BtnSaveFavorites.FlatStyle = FlatStyle.Flat;
            BtnSaveFavorites.ForeColor = Color.White;
            BtnSaveFavorites.Location = new Point(203, 329);
            BtnSaveFavorites.Name = "BtnSaveFavorites";
            BtnSaveFavorites.Size = new Size(151, 41);
            BtnSaveFavorites.TabIndex = 1;
            BtnSaveFavorites.Text = "Save Setting";
            BtnSaveFavorites.TextColor = Color.White;
            BtnSaveFavorites.UseVisualStyleBackColor = false;
            BtnSaveFavorites.Click += btnSave_Click;
            // 
            // clbFavorites
            // 
            clbFavorites.CheckOnClick = true;
            clbFavorites.FormattingEnabled = true;
            clbFavorites.Location = new Point(6, 33);
            clbFavorites.Name = "clbFavorites";
            clbFavorites.Size = new Size(348, 290);
            clbFavorites.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Settings";
            Text = "Settings";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckedListBox clbFavorites;
        private CustomButton BtnSaveFavorites;
    }
}