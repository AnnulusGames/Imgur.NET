using System.Net;

namespace Imgur;

public class ImgurException(HttpStatusCode status, string? message) : Exception(message)
{
    public HttpStatusCode Status { get; } = status;

    internal static async Task<ImgurException> CreateAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
#if NET6_0_OR_GREATER
        return new ImgurException(response.StatusCode, await response.Content.ReadAsStringAsync(cancellationToken));
#else
        return new ImgurException(response.StatusCode, await response.Content.ReadAsStringAsync());
#endif
    }
}