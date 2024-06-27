using System.Text.Json.Serialization;

namespace Imgur;

public record CreatedComment
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
}