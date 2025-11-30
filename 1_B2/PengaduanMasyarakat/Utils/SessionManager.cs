using PengaduanMasyarakat.Models;

namespace PengaduanMasyarakat.Utils
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool IsAdmin()
        {
            return CurrentUser != null && CurrentUser.Role == "admin";
        }
    }
}