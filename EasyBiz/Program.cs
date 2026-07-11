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

            // Require login before the app is usable at all.
            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK || login.LoggedInUser == null)
                    return; // user cancelled / clicked Exit

                var user = login.LoggedInUser;
                CurrentUser.Set(user.UserId, user.Username, user.FullName, user.IsAdmin);
            }

            Application.Run(new MainForm());
        }
    }
}