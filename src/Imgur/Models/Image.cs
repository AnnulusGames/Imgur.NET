using System.Text.Json.Serialization;

namespace Imgur;

public record Image
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("datetime")]
    public long DateTime { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("animated")]
    public bool Animated { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("bandwidth")]
    public int Bandwidth { get; set; }

    [JsonPropertyName("deletehash")]
    public string? DeleteHash { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("section")]
    public string? Section { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("gifv")]
    public string? Gifv { get; set; }

    [JsonPropertyName("mp4")]
    public string? Mp4 { get; set; }

    [JsonPropertyName("mp4_size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Mp4Size { get; set; }

    [JsonPropertyName("looping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Looping { get; set; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    [JsonPropertyName("nsfw")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Nsfw { get; set; }

    [JsonPropertyName("vote")]
    public string? Vote { get; set; }

    [JsonPropertyName("in_gallery")]
    public bool InGallery { get; set; }
}
