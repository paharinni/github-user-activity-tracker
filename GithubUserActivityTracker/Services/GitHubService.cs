using System.Text.Json;

namespace GithubUserActivityTracker.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch recent activity for a given GitHub username
        public async Task<List<GitHubEvent>?> GetUserActivity(string username)
        {
            var url = $"https://api.github.com/users/{username}/events";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            // GitHub API requires a user agent in the headers
            request.Headers.Add("User-Agent", "GitHubActivityApp");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if the response code is not 2xx

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<GitHubEvent>>(jsonString);
        }
    }
}