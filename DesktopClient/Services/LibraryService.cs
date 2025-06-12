using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GameKeyManager.Models;
using GameKeyManager.Models.DTOs;
using GameKeyManager.Helpers;

namespace GameKeyManager.Services
{
    public class LibraryService
    {
        // This service will handle game-related operations like adding, updating, deleting games  
        // and fetching game lists from the backend API.  
        private static readonly HttpClient _httpClient = new();

        public static async Task<GetAllGamesResponse> GetGamesAsync()
        {
            var games = new GetAllGamesResponse
            {
                Games = [], // Initialize to avoid null reference
                ErrorMessage = null
            };

            try
            {
                // Ensure CurrentUser and Token are not null before accessing them
                if (SessionManager.CurrentUser?.Token == null)
                {
                    games.ErrorMessage = "User is not authenticated.";
                    return games;
                }

                // Set the Authorization header for this request
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.CurrentUser.Token);

                var response = await _httpClient.GetAsync($"{ApiConfig.BaseUrl}/games");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var deserializedGames = JsonSerializer.Deserialize<GetAllGamesResponse>(json);

                    if (deserializedGames != null)
                    {
                        games = deserializedGames;
                    }
                }
                else
                {
                    games.ErrorMessage = "Failed to fetch games from the API.";
                }
            }
            catch (Exception ex)
            {
                games.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return games; // Ensure no null reference is returned
        }


    }
}
