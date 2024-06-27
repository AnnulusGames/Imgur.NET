using System.Text.Json.Serialization;

namespace Imgur;

public record GalleryImage : IGalleryContent
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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DeleteHash { get; set; }

    [JsonPropertyName("link")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Link { get; set; }

    [JsonPropertyName("gifv")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Gifv { get; set; }

    [JsonPropertyName("mp4")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Mp4 { get; set; }

    [JsonPropertyName("mp4_size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Mp4Size { get; set; }

    [JsonPropertyName("looping")]
    public bool? Looping { get; set; }

    [JsonPropertyName("vote")]
    public string? Vote { get; set; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    [JsonPropertyName("nsfw")]
    public bool? Nsfw { get; set; }

    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }

    [JsonPropertyName("topic")]
    public string? Topic { get; set; }

    [JsonPropertyName("topic_id")]
    public int? TopicId { get; set; }

    [JsonPropertyName("section")]
    public string? Section { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("account_url")]
    public string? AccountUrl { get; set; }

    [JsonPropertyName("ups")]
    public int? Ups { get; set; }

    [JsonPropertyName("downs")]
    public int? Downs { get; set; }

    [JsonPropertyName("points")]
    public int? Points { get; set; }

    [JsonPropertyName("score")]
    public int? Score { get; set; }

    [JsonPropertyName("is_album")]
    public bool IsAlbum { get; set; }

    [JsonPropertyName("in_most_viral")]
    public bool InMostViral { get; set; }

    [JsonPropertyName("tags")]
    public Tag[] Tags { get; set; } = [];
}
