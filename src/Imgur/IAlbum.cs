using System.Text.Json.Serialization;

namespace Imgur;

public interface IAlbum
{
    Task<Album> GetAsync(GetAlbumRequest request, CancellationToken cancellationToken = default);
    Task<CreatedAlbum> CreateAsync(CreateAlbumRequest request, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(UpdateAlbumRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(DeleteAlbumRequest request, CancellationToken cancellationToken = default);
    Task<bool> FavoriteAsync(FavoriteAlbumRequest request, CancellationToken cancellationToken = default);
    Task<bool> AddImagesAsync(AddImagesToAlbumRequest request, CancellationToken cancellationToken = default);
    Task<bool> RemoveImagesAsync(RemoveImagesFromAlbumRequest request, CancellationToken cancellationToken = default);
}

public record GetAlbumRequest
{
    public required string AlbumHash { get; init; }
}

public record CreateAlbumRequest
{
    [JsonPropertyName("ids")]
    public string[]? Ids { get; init; }

    [JsonPropertyName("deletehashes")]
    public string[]? DeleteHashes { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("privacy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public AlbumPrivacy? Privacy { get; init; }

    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public AlbumLayout? Layout { get; init; }

    [JsonPropertyName("cover")]
    public string? Cover { get; init; }
}

public record UpdateAlbumRequest
{
    [JsonIgnore]
    public required string AlbumHash { get; init; }

    [JsonPropertyName("ids")]
    public string[]? Ids { get; init; }

    [JsonPropertyName("deletehashes")]
    public string[]? DeleteHashes { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("privacy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public AlbumPrivacy? Privacy { get; init; }

    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public AlbumLayout? Layout { get; init; }

    [JsonPropertyName("cover")]
    public string? Cover { get; init; }
}

public record DeleteAlbumRequest
{
    public required string AlbumHash { get; init; }
}

public record FavoriteAlbumRequest
{
    public required string AlbumHash { get; init; }
}

public record AddImagesToAlbumRequest
{
    [JsonIgnore]
    public required string AlbumHash { get; init; }

    [JsonPropertyName("ids")]
    public string[]? Ids { get; init; }

    [JsonPropertyName("deletehashes")]
    public string[]? DeleteHashes { get; init; }
}

public record RemoveImagesFromAlbumRequest
{
    [JsonIgnore]
    public required string AlbumHash { get; init; }

    [JsonPropertyName("ids")]
    public required string[] Ids { get; init; }
}