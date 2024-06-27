using System.Text.Json.Serialization;

namespace Imgur;

public record TagVote
{
    [JsonPropertyName("ups")]
    public int Ups { get; set; }

    [JsonPropertyName("downs")]
    public int Downs { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("author")]
    public string? Author { get; set; }
}
