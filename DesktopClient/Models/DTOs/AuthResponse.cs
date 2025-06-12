using GameKeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyManager.Models.DTOs
{
    public class AuthResponse
    {
        public User? User { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsSuccess => User != null && string.IsNullOrEmpty(ErrorMessage);
    }
}
