using System.Text.Json.Serialization;

namespace Imgur;

public record AccountAvatar
{
    [JsonPropertyName("avatar")]
    public string? AvatarUrl { get; set; }

    [JsonPropertyName("avatar_name")]
    public string? AvatarName { get; set; }
}
