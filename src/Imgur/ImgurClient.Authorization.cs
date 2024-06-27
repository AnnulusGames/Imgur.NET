
namespace Imgur;

public partial class ImgurClient : IAuthorization
{
    public IAuthorization Authorization => this;

    async Task<GenerateAccessTokenResponse> IAuthorization.GenerateAccessTokenAsync(GenerateAccessTokenRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/oauth2/token", UriKind.RelativeOrAbsolute)
            : new Uri($"oauth2/token", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);

        var content = new MultipartFormDataContent
        {
            { new StringContent(request.RefreshToken), "refresh_token" },
            { new StringContent(ClientId), "client_id" },
            { new StringContent(ClientSecret), "client_secret" },
            { new StringContent("refresh_token"), "grant_type" }
        };

        message.Content = content;

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return await DeserializeContentAsync<GenerateAccessTokenResponse>(response, cancellationToken);
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    string IAuthorization.GetAuthorizationUrl(string state)
    {
        return $"https://api.imgur.com/oauth2/authorize?client_id={ClientId}&response_type=token&state={state}";
    }
}