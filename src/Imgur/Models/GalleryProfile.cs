using System.Text.Json.Serialization;

namespace Imgur;

public record GalleryProfile
{
    [JsonPropertyName("total_gallery_comments")]
    public int TotalGalleryComments { get; set; }

    [JsonPropertyName("total_gallery_favorites")]
    public int TotalGalleryFavorites { get; set; }

    [JsonPropertyName("total_gallery_submissions")]
    public int TotalGallerySubmissions { get; set; }

    [JsonPropertyName("trophies")]
    public Trophy[] Trophies { get; set; } = [];
}

public record Trophy
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("name_clean")]
    public string? NameClean { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("data")]
    public string? Data { get; set; }

    [JsonPropertyName("data_link")]
    public string? DataLink { get; set; }

    [JsonPropertyName("datetime")]
    public long DateTime { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
}