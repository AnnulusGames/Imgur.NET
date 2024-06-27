using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imgur;

public interface IImage
{
    Task<Image> GetAsync(GetImageRequest request, CancellationToken cancellationToken = default);
    Task<Image> UploadAsync(UploadImageRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(DeleteImageRequest request, CancellationToken cancellationToken = default);
    Task<bool> UploadInformationAsync(UploadImageInformationRequest request, CancellationToken cancellationToken = default);
    Task<bool> FavoriteAsync(FavoriteImageRequest request, CancellationToken cancellationToken = default);
}

public record GetImageRequest
{
    public required string ImageHash { get; init; }
}

public record UploadImageRequest
{
    public required ImageContent Image { get; init; }
    public required ImageContentType Type { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
}

public record ImageContent
{
    public Stream? Stream { get; private init; }
    public byte[]? Bytes { get; private init; }
    public string? Text { get; private init; }

    ImageContent()
    {
    }

    public static implicit operator ImageContent(Stream stream)
    {
        return new ImageContent
        {
            Stream = stream
        };
    }

    public static implicit operator ImageContent(byte[] bytes)
    {
        return new ImageContent
        {
            Bytes = bytes
        };
    }

    public static implicit operator ImageContent(string text)
    {
        return new ImageContent
        {
            Text = text
        };
    }
}

public enum ImageContentType
{
    [EnumMember(Value = "file")]
    File,
    [EnumMember(Value = "base64")]
    Base64,
    [EnumMember(Value = "url")]
    Url,
    [EnumMember(Value = "raw")]
    Raw
}

public record DeleteImageRequest
{
    public required string ImageHash { get; init; }
}

public record UploadImageInformationRequest
{
    public required string ImageHash { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
}

public record FavoriteImageRequest
{
    public required string ImageHash { get; init; }
}
