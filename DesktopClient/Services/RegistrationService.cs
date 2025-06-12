using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GameKeyManager.Models.DTOs;
using GameKeyManager.Helpers;
using GameKeyManager.Models;
using System.Text.Json;
using System.Diagnostics;

namespace GameKeyManager.Services
{
    public class RegistrationService
    {
        private static readonly HttpClient _httpClient = new();

        public static async Task<AuthResponse> RegisterAsync(string username, string password, string email)
        {
            var payload = new RegisterRequest
            {
                Username = username,
                Password = password,
                Email = email
            };
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            try
            {
                Debug.WriteLine($"Sending Registration request to backend: {payload}");
                var response = await _httpClient.PostAsync($"{ApiConfig.BaseUrl}/auth/register", content);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var user = JsonSerializer.Deserialize<User>(json);
                    return new AuthResponse { User = user, ErrorMessage = null };
                }
                else
                {
                    Debug.WriteLine($"Registration failed with status code: {response.StatusCode}");
                    return new AuthResponse
                    {
                        User = null,
                        ErrorMessage = "Registration failed. Please try again."
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP Request failed: {ex.Message}");
                return new AuthResponse
                {
                    User = null,
                    ErrorMessage = "Network error. Please try again."
                };
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"JSON Deserialization failed: {ex.Message}");
                return new AuthResponse
                {
                    User = null,
                    ErrorMessage = "Invalid response from server."
                };
            }
        }
    }
}
