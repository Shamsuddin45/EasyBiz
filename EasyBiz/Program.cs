namespace EasyBiz
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    // User cancelled / closed the login window — exit quietly,
                    // never fall through to MainForm without a valid session.
                    return;
                }
            }

            Application.Run(new MainForm());
        }
    }
}