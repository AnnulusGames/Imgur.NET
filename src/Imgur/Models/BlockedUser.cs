using System.Text.Json.Serialization;

namespace Imgur;

public record BlockedUser
{
    [JsonPropertyName("blocked_id")]
    public long BlockedId { get; set; }

    [JsonPropertyName("blocked_url")]
    public string? BlockedURL { get; set; }
}