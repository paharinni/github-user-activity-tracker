using System.Text.Json.Serialization;

namespace GitHubActivityApp.Entities;

public class GitHubActor
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("display_login")]
    public string DisplayLogin { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; }
}