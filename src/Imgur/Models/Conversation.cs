using System.Text.Json.Serialization;

namespace Imgur;

public record Conversation
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("last_message_preview")]
    public string? LastMessagePreview { get; set; }

    [JsonPropertyName("datetime")]
    public long DateTime { get; set; }

    [JsonPropertyName("with_account_id")]
    public int WithAccountId { get; set; }

    [JsonPropertyName("with_account")]
    public string? WithAccount { get; set; }

    [JsonPropertyName("message_count")]
    public int MessageCount { get; set; }

    [JsonPropertyName("messages")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Message[]? Messages { get; set; } 

    [JsonPropertyName("done")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Done { get; set; }

    [JsonPropertyName("page")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Page { get; set; }
}