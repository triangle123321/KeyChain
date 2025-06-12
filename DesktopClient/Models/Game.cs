using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameKeyManager.Models
{
    public class Game
    {
        public int Id { get; set; } // Local identifier for the game
        public string Title { get; set; } = string.Empty; // Game title, initialized to avoid nullability warnings
        public string Platform { get; set; } = string.Empty; // Game platform, initialized to avoid nullability warnings
        public string? PurchaseDate { get; set; }
        public string? Price { get; set; }
        public string ProductKey { get; set; } = string.Empty; // Product key, initialized to avoid nullability warnings
        public string? Notes { get; set; }
        public bool Used { get; set; } = false; // Indicates if the game has been used or redeemed
        public Guid? Uuid { get; set; } = null; // Unique identifier for the game, will be recieved from backend upon sync
    }
}
