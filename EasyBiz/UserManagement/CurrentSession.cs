namespace EasyBiz
{
    /// <summary>
    /// Simple static session holder for whoever is currently logged in.
    /// Set once by Program.cs right after LoginForm succeeds.
    /// </summary>
    public static class CurrentUser
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; } = "";
        public static string FullName { get; private set; } = "";
        public static bool IsAdmin { get; private set; }

        public static void Set(int userId, string username, string fullName, bool isAdmin)
        {
            UserId = userId;
            Username = username;
            FullName = fullName;
            IsAdmin = isAdmin;
        }

        public static void Clear()
        {
            UserId = 0;
            Username = "";
            FullName = "";
            IsAdmin = false;
        }
    }
}