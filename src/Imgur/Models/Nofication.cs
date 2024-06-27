using System.Text.Json.Serialization;

namespace Imgur;

public record Nofication
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("viewed")]
    public bool Viewed { get; set; }

    [JsonPropertyName("content")]
    public IGalleryContent? Content { get; set; }
}
