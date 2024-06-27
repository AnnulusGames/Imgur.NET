namespace Imgur;

public partial class ImgurClient : IAlbum
{
    public IAlbum Album => this;

    async Task<bool> IAlbum.AddImagesAsync(AddImagesToAlbumRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/album/{request.AlbumHash}/add", UriKind.RelativeOrAbsolute)
            : new Uri($"album/{request.AlbumHash}/add", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);

        message.Content = CreateJsonContent(request);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<bool>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<CreatedAlbum> IAlbum.CreateAsync(CreateAlbumRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/album", UriKind.RelativeOrAbsolute)
            : new Uri($"album", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);

        message.Content = CreateJsonContent(request);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<CreatedAlbum>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<bool> IAlbum.DeleteAsync(DeleteAlbumRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/album/{request.AlbumHash}", UriKind.RelativeOrAbsolute)
            : new Uri($"album/{request.AlbumHash}", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Delete, requestUri);
        AddAuthorizationHeader(message);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<bool>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<bool> IAlbum.FavoriteAsync(FavoriteAlbumRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/album/{request.AlbumHash}/favorite", UriKind.RelativeOrAbsolute)
            : new Uri($"album/{request.AlbumHash}/favorite", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<bool>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<Album> IAlbum.GetAsync(GetAlbumRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/album/{request.AlbumHash}", UriKind.RelativeOrAbsolute)
            : new Uri($"album/{request.AlbumHash}", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Get, requestUri);
        AddAuthorizationHeader(message);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<Album>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<bool> IAlbum.RemoveImagesAsync(RemoveImagesFromAlbumRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/album/{request.AlbumHash}/remove_images", UriKind.RelativeOrAbsolute)
            : new Uri($"album/{request.AlbumHash}/remove_images", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);

        message.Content = CreateJsonContent(request);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<bool>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<bool> IAlbum.UpdateAsync(UpdateAlbumRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/album/{request.AlbumHash}", UriKind.RelativeOrAbsolute)
            : new Uri($"album/{request.AlbumHash}", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Put, requestUri);
        AddAuthorizationHeader(message);

        message.Content = CreateJsonContent(request);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<bool>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }
}