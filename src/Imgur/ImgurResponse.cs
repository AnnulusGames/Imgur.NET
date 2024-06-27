using System.Text.Json.Serialization;

namespace Imgur;

public record ImgurResponse<T>
{
    [JsonPropertyName("status")]
    public int Status { get; init; }

    [JsonPropertyName("success")]
    public bool Success { get; init; }

    [JsonPropertyName("data")]
    public T? Data { get; init; }
}
