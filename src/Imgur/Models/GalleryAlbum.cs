using System.Text.Json.Serialization;

namespace Imgur;

public record GalleryAlbum : IGalleryContent
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

    [JsonPropertyName("ups")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Ups { get; set; }

    [JsonPropertyName("downs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Downs { get; set; }

    [JsonPropertyName("points")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Points { get; set; }

    [JsonPropertyName("score")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Score { get; set; }

    [JsonPropertyName("is_album")]
    public bool IsAlbum { get; set; } = true;

    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    [JsonPropertyName("nsfw")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Nsfw { get; set; }

    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }
    
    [JsonPropertyName("topic")]
    public string? Topic { get; set; }

    [JsonPropertyName("topic_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? TopicId { get; set; }

    [JsonPropertyName("images_count")]
    public int ImagesCount { get; set; }

    [JsonPropertyName("tags")]
    public Tag[] Tags { get; set; } = [];

    [JsonPropertyName("images")]
    public GalleryImage[] Images { get; set; } = [];

    [JsonPropertyName("in_most_viral")]
    public bool InMostViral { get; set; }
}