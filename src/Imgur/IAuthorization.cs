using System.Text.Json.Serialization;

namespace Imgur;

public interface IAuthorization
{
    string GetAuthorizationUrl(string state);
    Task<GenerateAccessTokenResponse> GenerateAccessTokenAsync(GenerateAccessTokenRequest request, CancellationToken cancellationToken = default);
}

public record GenerateAccessTokenRequest
{
    public required string RefreshToken { get; init; }
}

public record GenerateAccessTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; } = default!;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; init; } = default!;

    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; init; }

    [JsonPropertyName("account_id")]
    public long AccountId { get; init; }

    [JsonPropertyName("account_username")]
    public string AccountUserName { get; init; } = default!;
}