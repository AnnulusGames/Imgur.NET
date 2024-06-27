namespace Imgur;

public partial class ImgurClient : IImage
{
    public IImage Image => this;

    async Task<bool> IImage.DeleteAsync(DeleteImageRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/image/{request.ImageHash}", UriKind.RelativeOrAbsolute)
            : new Uri($"image/{request.ImageHash}", UriKind.Relative);

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

    async Task<bool> IImage.FavoriteAsync(FavoriteImageRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/image/{request.ImageHash}/favorite", UriKind.RelativeOrAbsolute)
            : new Uri($"image/{request.ImageHash}/favorite", UriKind.Relative);

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

    async Task<Image> IImage.GetAsync(GetImageRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/image/{request.ImageHash}", UriKind.RelativeOrAbsolute)
            : new Uri($"image/{request.ImageHash}", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Get, requestUri);
        AddAuthorizationHeader(message);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<Image>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<Image> IImage.UploadAsync(UploadImageRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new("https://api.imgur.com/3/image", UriKind.RelativeOrAbsolute)
            : new Uri("image", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);

        var content = new MultipartFormDataContent
        {
            { new StringContent(request.Type.ToString()), "type" },
        };

        if (request.Image.Stream != null) content.Add(new StreamContent(request.Image.Stream), "image");
        else if (request.Image.Bytes != null) content.Add(new ByteArrayContent(request.Image.Bytes), "image");
        else if (request.Image.Text != null) content.Add(new StringContent(request.Image.Text), "image");

        if (request.Title != null) content.Add(new StringContent(request.Title), "title");
        if (request.Description != null) content.Add(new StringContent(request.Description), "description");

        message.Content = content;

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<Image>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<bool> IImage.UploadInformationAsync(UploadImageInformationRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/image/{request.ImageHash}", UriKind.RelativeOrAbsolute)
            : new Uri($"image/{request.ImageHash}", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);

        var content = new MultipartFormDataContent();

        if (request.Title != null) content.Add(new StringContent(request.Title), "title");
        if (request.Description != null) content.Add(new StringContent(request.Description), "description");

        message.Content = content;

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