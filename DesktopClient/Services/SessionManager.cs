using GameKeyManager.Models;

namespace GameKeyManager.Services
{
    public static class SessionManager
    {
        public static User? CurrentUser { get; set; }
    }
}