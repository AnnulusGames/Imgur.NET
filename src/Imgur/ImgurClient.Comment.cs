namespace Imgur;

public partial class ImgurClient : IComment
{
    public IComment Comment => this;

    async Task<CreatedComment> IComment.CreateAsync(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/comment", UriKind.RelativeOrAbsolute)
            : new Uri($"comment", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);
        message.Content = CreateJsonContent(request);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<CreatedComment>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<bool> IComment.DeleteAsync(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/comment/{request.CommentId}", UriKind.RelativeOrAbsolute)
            : new Uri($"comment/{request.CommentId}", UriKind.Relative);

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

    async Task<Comment> IComment.GetAsync(GetCommentRequest request, CancellationToken cancellationToken)
    {
        Uri requestUri;
        if (request.WithReplies)
        {
            requestUri = HttpClient.BaseAddress == null
                ? new Uri($"https://api.imgur.com/3/comment/{request.CommentId}/replies", UriKind.RelativeOrAbsolute)
                : new Uri($"comment/{request.CommentId}/replies", UriKind.Relative);
        }
        else
        {
            requestUri = HttpClient.BaseAddress == null
                ? new Uri($"https://api.imgur.com/3/comment/{request.CommentId}", UriKind.RelativeOrAbsolute)
                : new Uri($"comment/{request.CommentId}", UriKind.Relative);
        }

        var message = new HttpRequestMessage(HttpMethod.Get, requestUri);
        AddAuthorizationHeader(message);

        var response = await httpClient.SendAsync(message, cancellationToken)
            .ConfigureAwait(ConfigureAwait);

        switch ((int)response.StatusCode)
        {
            case 200:
                return (await DeserializeContentAsync<ImgurResponse<Comment>>(response, cancellationToken)).Data!;
            default:
                throw await ImgurException.CreateAsync(response, cancellationToken).ConfigureAwait(ConfigureAwait);
        }
    }

    async Task<bool> IComment.ReportAsync(ReportCommentRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/comment/{request.CommentId}/report", UriKind.RelativeOrAbsolute)
            : new Uri($"comment/{request.CommentId}/report", UriKind.Relative);

        var message = new HttpRequestMessage(HttpMethod.Post, requestUri);
        AddAuthorizationHeader(message);

        if (request.ReportReason != null)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(((int)request.ReportReason).ToString()), "reason" }
            };

            message.Content = content;
        }

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

    async Task<bool> IComment.VoteAsync(VoteCommentRequest request, CancellationToken cancellationToken)
    {
        var requestUri = HttpClient.BaseAddress == null
            ? new Uri($"https://api.imgur.com/3/comment/{request.CommentId}/vote/{request.Type}", UriKind.RelativeOrAbsolute)
            : new Uri($"comment/{request.CommentId}/vote/{request.Type}", UriKind.Relative);

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
}