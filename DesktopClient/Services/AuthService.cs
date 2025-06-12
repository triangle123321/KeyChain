using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GameKeyManager.Helpers;


// Services/AuthService.cs
using GameKeyManager.Models;
using GameKeyManager.Models.DTOs;

namespace GameKeyManager.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private User? _currentUser;

        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<AuthResponse> AuthenticateAsync(string username, string password)
        {
            var payload = new AuthRequest
            {
                Username = username,
                Password = password
            };
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            try
            {
                Debug.WriteLine($"Sending Auth request to backend: {payload}");

                var response = await _httpClient.PostAsync($"{ApiConfig.BaseUrl}/auth/register", content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var user = JsonSerializer.Deserialize<User>(json);
                    return new AuthResponse { User = user, ErrorMessage = null };
                }
                else
                {
                    Debug.WriteLine($"Authentication failed with status code: {response.StatusCode}");
                    return new AuthResponse
                    {
                        User = null,
                        ErrorMessage = "Invalid username or password."
                    };
                }

            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP Request failed: {ex.Message}");
                // Handle network errors or log them as needed
                return new AuthResponse
                {
                    User = null,
                    ErrorMessage = "Network error. Please try again."
                };
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON Deserialization failed: {ex.Message}");
                // Handle JSON parsing errors or log them as needed
                return new AuthResponse
                {
                    User = null,
                    ErrorMessage = "Server response error."
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred: {ex.Message}");
                // Handle any other unexpected errors or log them as needed
                return new AuthResponse
                {
                    User = null,
                    ErrorMessage = "An unexpected error occurred."
                };
            }
        }
        public void Logout()
        {
            _currentUser = null;
            // Optionally clear tokens, cookies, etc.
        }

        public bool IsAuthenticated => _currentUser != null;
        public User? CurrentUser => _currentUser;
    }
}