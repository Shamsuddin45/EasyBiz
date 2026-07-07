namespace EasyBiz
{
    /// <summary>
    /// Holds who is currently logged in, for the lifetime of the running
    /// application. Set once by LoginForm right after a successful login,
    /// read anywhere (e.g. to gate Users Management to Admins, or to show
    /// the user's name in the main window title).
    /// </summary>
    public static class CurrentSession
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; } = "";
        public static string FullName { get; private set; } = "";
        public static string Role { get; private set; } = "";

        public static bool IsLoggedIn => UserId != 0;
        public static bool IsAdmin => Role == UserAccountsDatabaseHelper.RoleAdmin;

        public static void SetUser(UserAccount user)
        {
            UserId = user.UserId;
            Username = user.Username;
            FullName = string.IsNullOrWhiteSpace(user.FullName) ? user.Username : user.FullName;
            Role = user.Role;
        }

        public static void Clear()
        {
            UserId = 0;
            Username = "";
            FullName = "";
            Role = "";
        }
    }
}
