using System.Text.Json;
using GitHubActivityApp.Entities;

namespace GitHubActivityApp.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GitHubEvent>?> GetUserActivity(string username)
        {
            var url = $"https://api.github.com/users/{username}/events";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            request.Headers.Add("User-Agent", "GitHubActivityApp");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<GitHubEvent>>(jsonString);
        }
    }
}