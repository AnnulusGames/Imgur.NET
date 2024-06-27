using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Imgur;

public record Album
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("datetime")]
    public long DateTime { get; set; }

    [JsonPropertyName("cover")]
    public string? Cover { get; set; }

    [JsonPropertyName("cover_width")]
    public int CoverWidth { get; set; }

    [JsonPropertyName("cover_height")]
    public int CoverHeight { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("account_url")]
    public string? AccountUrl { get; set; }

    [JsonPropertyName("privacy")]
    public AlbumPrivacy Privacy { get; set; }

    [JsonPropertyName("layout")]
    public AlbumLayout Layout { get; set; }

    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    [JsonPropertyName("nsfw")]
    public bool? Nsfw { get; set; }

    [JsonPropertyName("section")]
    public string? Section { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("deletehash")]
    public string? DeleteHash { get; set; }

    [JsonPropertyName("images_count")]
    public int ImagesCount { get; set; }

    [JsonPropertyName("images")]
    public Image[] Images { get; set; } = [];

    [JsonPropertyName("in_gallery")]
    public bool InGallery { get; set; }
}

public enum AlbumPrivacy
{
    [EnumMember(Value = "public")]
    Public,
    [EnumMember(Value = "hidden")]
    Hidden,
    [EnumMember(Value = "secret")]
    Secret
}

public enum AlbumLayout
{
    [EnumMember(Value = "blog")]
    Blog,
    [EnumMember(Value = "grid")]
    Grid,
    [EnumMember(Value = "horizontal")]
    Horizontal,
    [EnumMember(Value = "vertical")]
    Vertical,
}

public record CreatedAlbum
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("deletehash")]
    public string DeleteHash { get; set; } = default!;
}