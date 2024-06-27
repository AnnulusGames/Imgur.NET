using System.Text.Json.Serialization;

namespace Imgur;

public record Account
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("bio")]
    public string? Bio { get; set; }

    [JsonPropertyName("reputation")]
    public float Reputation { get; set; }

    [JsonPropertyName("reputation_name")]
    public string? ReputationName { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("pro_expiration")]
    public ProExpiration ProExpiration { get; set; }
}
