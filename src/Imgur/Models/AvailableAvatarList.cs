using System.Text.Json.Serialization;

namespace Imgur;

public record AvailableAvatarList
{
    [JsonPropertyName("available_avatars")]
    public AvailableAvatar[] AvailableAvatars { get; set; } = [];

    [JsonPropertyName("available_avatars_count")]
    public int AvailableAvatarsCount { get; set; }

    [JsonPropertyName("avatars_are_default")]
    public bool AvatarsAreDefault { get; set; }
}

public record AvailableAvatar
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }
}