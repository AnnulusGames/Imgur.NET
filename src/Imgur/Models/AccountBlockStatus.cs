using System.Text.Json.Serialization;

namespace Imgur;

public record AccountBlockStatus
{
    [JsonPropertyName("blocked")]
    public bool Blocked { get; set; }
}