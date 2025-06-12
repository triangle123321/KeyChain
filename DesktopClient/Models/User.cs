using System.ComponentModel.DataAnnotations;

namespace GameKeyManager.Models
{
    public class User
    {
        public string? Username { get; set; }
        public string? Token { get; set; } // For session management
        [EmailAddress]
        public string Email { get; set; } = string.Empty; // Initialize to avoid nullability warnings
    }
}