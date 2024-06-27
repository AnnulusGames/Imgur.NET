using System.Text.Json.Serialization;

namespace Imgur;

public record Tag
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("followers")]
    public int Followers { get; set; }

    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }

    [JsonPropertyName("following")]
    public bool Following { get; set; }

    [JsonPropertyName("is_whitelisted")]
    public bool IsWhitelisted { get; set; }

    [JsonPropertyName("background_hash")]
    public string? BackgroundHash { get; set; }

    [JsonPropertyName("thumbnail_hash")]
    public string? ThumbnailHash { get; set; }

    [JsonPropertyName("accent")]
    public string? Accent { get; set; }

    [JsonPropertyName("background_is_animated")]
    public bool? BackgroundIsAnimated { get; set; }

    [JsonPropertyName("thumbnail_is_animated")]
    public bool? ThumbnailIsAnimated { get; set; }

    [JsonPropertyName("logo_hash")]
    public string? LogoHash { get; set; }

    [JsonPropertyName("logo_destination_url")]
    public string? LogoDestinationUrl { get; set; }

    [JsonPropertyName("is_promoted")]
    public bool IsPromoted { get; set; }

    [JsonPropertyName("items")]
    public IGalleryContent[] Items { get; set; } = [];
}
