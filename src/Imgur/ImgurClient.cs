using System.Net.Http.Json;
using System.Text.Json;

namespace Imgur;

public interface IImgurClient
{
    IAuthorization Authorization { get; }
    IImage Image { get; }
    IAlbum Album { get; }
    IComment Comment { get; }
}

public partial class ImgurClient : IImgurClient, IDisposable
{
    public string ClientId { get; init; } = Environment.GetEnvironmentVariable("IMGUR_CLIENT_ID") ?? "";
    public string ClientSecret { get; init; } = Environment.GetEnvironmentVariable("IMGUR_CLIENT_SECRET") ?? "";
    public string AccessToken { get; set; } = "";
    public bool ConfigureAwait { get; set; } = false;

    readonly HttpClient httpClient;
    public HttpClient HttpClient => httpClient;

    public ImgurClient(HttpMessageHandler handler, bool disposeHandler)
    {
        httpClient = new(handler, disposeHandler);
    }

    public ImgurClient()
        : this(new HttpClientHandler(), true)
    {
    }

    public ImgurClient(HttpMessageHandler handler)
        : this(handler, true)
    {
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }

    void AddAuthorizationHeader(HttpRequestMessage message)
    {
        if (AccessToken == null) message.Headers.Add("Authorization", $"Client-ID {ClientId}");
        else message.Headers.Add("Authorization", $"Bearer {AccessToken}");
    }

    ByteArrayContent CreateJsonContent<T>(T value)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(value, ImgurJsonSerializerContext.Default.Options);
        var content = new ByteArrayContent(bytes);
        content.Headers.Add("Content-Type", "application/json");
        return content;
    }

    async Task<T> DeserializeContentAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
    {
#if NET6_0_OR_GREATER
        var result = await response.Content.ReadFromJsonAsync<T>(ImgurJsonSerializerContext.Default.Options, cancellationToken)
            .ConfigureAwait(ConfigureAwait);
#else
        var result = JsonSerializer.Deserialize<T>(await response.Content.ReadAsByteArrayAsync().ConfigureAwait(ConfigureAwait), ImgurJsonSerializerContext.Default.Options);
#endif
        return result!;
    }
}