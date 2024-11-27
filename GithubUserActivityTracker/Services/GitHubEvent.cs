using System.Text.Json.Serialization;

namespace GithubUserActivityTracker.Services;

public class GitHubEvent
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
}