using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyManager.Models.DTOs
{
    public class GetAllGamesRequest
    {
        public string token { get; set; } = string.Empty; // Initialize to avoid nullability warnings               
    }
}
