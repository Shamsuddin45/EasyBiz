// ============================================================================
// How to wire this into your existing MainForm.cs — 2 small edits, no
// changes to MainForm.Designer.cs needed.
// ============================================================================

// 1) In the MainForm() constructor, right after InitializeComponent(),
//    add this one line to hook up the button that's already on the form:
//
//    public MainForm()
//    {
//        InitializeComponent();
//        BtnBackupData.Click += BtnBackupData_Click;   // <-- ADD THIS LINE
//
//        DatabaseHelper.InitializeDatabase();
//        BankDatabaseHelper.InitializeBankTables();
//        ShowCashDetails();
//    }


// 2) Add this new method anywhere else in the MainForm class
//    (e.g. right after BtnChequeBook_Click):

/*private void BtnBackupData_Click(object sender, EventArgs e)
{
    try
    {
        using (var form = new BackupRestoreForm())
        {
            form.ShowDialog();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}*/
