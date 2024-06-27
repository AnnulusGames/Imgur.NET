using System.Text.Json.Serialization;

namespace Imgur;

public record Topic
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("css")]
    public string? Css { get; set; }

    [JsonPropertyName("ephemeral")]
    public bool Ephemeral { get; set; }

    // TODO:...

    [JsonPropertyName("heroImage")]
    public Image? HeroImage { get; set; }

    [JsonPropertyName("isHero")]
    public bool IsHero { get; set; }
}
