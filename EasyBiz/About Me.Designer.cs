namespace EasyBiz.Forms
{
    partial class AboutBox
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            picLogo = new PictureBox();
            lblAppName = new Label();
            lblVersion = new Label();
            lblTagline = new Label();
            lblCopyright = new Label();
            lblDeveloper = new Label();
            linkWebsite = new LinkLabel();
            pnlDivider = new Panel();
            btnOK = new Button();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.BackgroundImage = Properties.Resources.info1;
            picLogo.BackgroundImageLayout = ImageLayout.Zoom;
            picLogo.Location = new Point(34, 37);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(73, 85);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI Semibold", 16F);
            lblAppName.ForeColor = Color.FromArgb(41, 65, 90);
            lblAppName.Location = new Point(123, 40);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(107, 37);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "EasyBiz";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 9.5F);
            lblVersion.ForeColor = Color.DimGray;
            lblVersion.Location = new Point(126, 83);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(99, 21);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version 1.0.0";
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblTagline.ForeColor = Color.Gray;
            lblTagline.Location = new Point(126, 109);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(236, 20);
            lblTagline.TabIndex = 3;
            lblTagline.Text = "Inventory & Accounting Management";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 8F);
            lblCopyright.ForeColor = Color.Gray;
            lblCopyright.Location = new Point(34, 237);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(174, 19);
            lblCopyright.TabIndex = 7;
            lblCopyright.Text = "© 2026 All rights reserved.";
            // 
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.Font = new Font("Segoe UI", 9F);
            lblDeveloper.Location = new Point(34, 173);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(187, 20);
            lblDeveloper.TabIndex = 5;
            lblDeveloper.Text = "Developed by Shamsuddin";
            // 
            // linkWebsite
            // 
            linkWebsite.AutoSize = true;
            linkWebsite.Font = new Font("Segoe UI", 9F);
            linkWebsite.Location = new Point(34, 203);
            linkWebsite.Name = "linkWebsite";
            linkWebsite.Size = new Size(235, 20);
            linkWebsite.TabIndex = 6;
            linkWebsite.TabStop = true;
            linkWebsite.Text = "https://github.com/Shamsuddin45";
            linkWebsite.LinkClicked += linkWebsite_LinkClicked;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.Gainsboro;
            pnlDivider.Location = new Point(34, 153);
            pnlDivider.Margin = new Padding(3, 4, 3, 4);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(389, 1);
            pnlDivider.TabIndex = 4;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(41, 65, 90);
            btnOK.DialogResult = DialogResult.OK;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI Semibold", 9.5F);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(331, 280);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(91, 40);
            btnOK.TabIndex = 9;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // AboutBox
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 347);
            Controls.Add(btnOK);
            Controls.Add(lblCopyright);
            Controls.Add(linkWebsite);
            Controls.Add(lblDeveloper);
            Controls.Add(pnlDivider);
            Controls.Add(lblTagline);
            Controls.Add(lblVersion);
            Controls.Add(lblAppName);
            Controls.Add(picLogo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About EasyBiz";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.LinkLabel linkWebsite;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Button btnOK;
    }
}