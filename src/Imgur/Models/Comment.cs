using System.Text.Json.Serialization;

namespace Imgur;

public record Comment
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("image_id")]
    public string? ImageId { get; set; }

    [JsonPropertyName("comment")]
    public string? CommentText { get; set; }

    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("author_id")]
    public int AuthorId { get; set; }

    [JsonPropertyName("on_album")]
    public bool OnAlbum { get; set; }

    [JsonPropertyName("album_cover")]
    public string? AlbumCover { get; set; }

    [JsonPropertyName("ups")]
    public int Ups { get; set; }

    [JsonPropertyName("downs")]
    public int Downs { get; set; }

    [JsonPropertyName("points")]
    public float Points { get; set; }

    [JsonPropertyName("datetime")]
    public long DateTime { get; set; }

    [JsonPropertyName("parent_id")]
    public int? ParentId { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("vode")]
    public string? Vode { get; set; }

    [JsonPropertyName("children")]
    public Comment[] Children { get; set; } = [];
}