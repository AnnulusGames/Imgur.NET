// TODO: Gallery API Implementation

// using System.Runtime.Serialization;

// namespace Imgur;

// public interface IGallery
// {
//     Task<GalleryAlbum[]> GetAsync(GetGalleryRequest request, CancellationToken cancellationToken = default);
//     Task<GalleryAlbum[]> GetSubredditGalleriesAsync(GetGalleryRequest request, CancellationToken cancellationToken = default);
//     Task<GalleryImage> GetSubredditImageAsync(GetSubredditImageRequest request, CancellationToken cancellationToken = default);
// }

// public record GetGalleryRequest
// {
//     public GallerySection Section { get; init; } = GallerySection.Hot;
//     public GallerySort Sort { get; init; } = GallerySort.Viral;
//     public int Page { get; init; }
//     public GalleryWindow Window { get; init; } = GalleryWindow.Day;
//     public bool? ShowViral { get; init; }
//     public bool? ShowMature { get; init; }
// }

// public record GetSubredditGalleriesRequest
// {
//     public required string Subreddit { get; init; }
//     public SubredditGallerySort Sort { get; init; } = SubredditGallerySort.Time;
//     public int Page { get; init; }
//     public GalleryWindow Window { get; init; } = GalleryWindow.Day;
// }

// public record GetSubredditImageRequest
// {
//     public required string Subreddit { get; init; }
//     public required string ImageId { get; init; }
// }

// public enum GallerySection
// {
//     [EnumMember(Value = "hot")]
//     Hot,
//     [EnumMember(Value = "top")]
//     Top,
//     [EnumMember(Value = "users")]
//     User
// }

// public enum GallerySort
// {
//     [EnumMember(Value = "viral")]
//     Viral,
//     [EnumMember(Value = "top")]
//     Top,
//     [EnumMember(Value = "time")]
//     Time,
//     [EnumMember(Value = "rising")]
//     Rising,
// }

// public enum SubredditGallerySort
// {
//     [EnumMember(Value = "top")]
//     Top,
//     [EnumMember(Value = "time")]
//     Time,
// }

// public enum GalleryWindow
// {
//     [EnumMember(Value = "day")]
//     Day,
//     [EnumMember(Value = "week")]
//     Week,
//     [EnumMember(Value = "month")]
//     Month,
//     [EnumMember(Value = "year")]
//     Year,
//     [EnumMember(Value = "all")]
//     All,
// }