using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyManager.Models.DTOs
{
    public class AuthRequest
    {
        public string Username { get; set; } = string.Empty; // Initialize to avoid nullability warnings
        public string Password { get; set; } = string.Empty; // Initialize to avoid nullability warnings
    }
}
