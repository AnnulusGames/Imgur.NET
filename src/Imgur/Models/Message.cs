using System.Text.Json.Serialization;

namespace Imgur;

public record Message
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("sender_id")]
    public int SenderId { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("conversation_id")]
    public int ConversationId { get; set; }

    [JsonPropertyName("datetime")]
    public long DateTime { get; set; }
}
