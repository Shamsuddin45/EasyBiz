using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EasyBiz
{
    public partial class ViewReports : Form
    {
        public ViewReports()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        public ViewReports(string pdfFilePath)
        {
            InitializeComponent();

            // Assuming your PdfViewerControl on this form is named `pdfViewerControl1`
            if (File.Exists(pdfFilePath))
            {
                pdfViewerControl1.Load(pdfFilePath);
                pdfViewerControl1.ZoomTo(125); // Set zoom level to 125%
            }
        }
    }
}
