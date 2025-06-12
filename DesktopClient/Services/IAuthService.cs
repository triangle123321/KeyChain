using GameKeyManager.Models;
using GameKeyManager.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyManager.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateAsync(string username, string password);
        void Logout();
        bool IsAuthenticated { get; }
        User? CurrentUser { get; }
    }

}
