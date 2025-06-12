using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyManager.Models.DTOs

{
    public class GetAllGamesResponse
    {
        public List<Game> Games { get; set; } = new();
        public string? ErrorMessage { get; set; }
    }
}
