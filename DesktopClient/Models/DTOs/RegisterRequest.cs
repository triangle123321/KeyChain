using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyManager.Models.DTOs
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty; // Initialize to avoid nullability warnings
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty; // Initialize to avoid nullability warnings
        public string Email { get; set; } = string.Empty; // Initialize to avoid nullability warnings
    }
}
