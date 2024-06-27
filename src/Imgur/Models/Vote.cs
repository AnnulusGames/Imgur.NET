using System.Text.Json.Serialization;

namespace Imgur;

public record Vote
{
    [JsonPropertyName("ups")]
    public int Ups { get; set; }

    [JsonPropertyName("downs")]
    public int Downs { get; set; }
}