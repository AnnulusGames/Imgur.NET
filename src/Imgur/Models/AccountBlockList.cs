using System.Text.Json.Serialization;

namespace Imgur;

public record AccountBlockList
{
    [JsonPropertyName("items")]
    public AccountBlockListItem[] Items { get; set; } = [];
}

public record AccountBlockListItem
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}