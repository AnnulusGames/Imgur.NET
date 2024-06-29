using System.Runtime.Serialization;
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
    [JsonPropertyName("image")]
    public required ImageContent Image { get; init; }

    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ImageContentType? Type { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
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
    [JsonIgnore]
    public required string ImageHash { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}

public record FavoriteImageRequest
{
    public required string ImageHash { get; init; }
}
