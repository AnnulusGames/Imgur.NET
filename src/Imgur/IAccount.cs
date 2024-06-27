// TODO: Account API Implementation

// using System.Runtime.Serialization;

// namespace Imgur;

// public interface IAccount
// {
//     Task<Account> GetAsync(GetAccountRequest request, CancellationToken cancellationToken = default);
//     Task<AccountBlockStatus> GetBlockStatusAsync(GetAccountBlockStatusRequest request, CancellationToken cancellationToken = default);
//     Task<AccountBlockList> GetBlockedAccountsAsync(CancellationToken cancellationToken = default);
//     Task<AccountBlockStatus> BlockAsync(BlockAccountRequest request, CancellationToken cancellationToken = default);
//     Task<AccountBlockStatus> UnblockAsync(UnblockAccountRequest request, CancellationToken cancellationToken = default);
//     Task<Image[]> GetImagesAsync(GetAccountImagesRequest request, CancellationToken cancellationToken = default);
//     Task<IGalleryContent[]> GetFavoritesAsync(GetAccountFavoritesRequest request, CancellationToken cancellationToken = default);
//     Task<IGalleryContent[]> GetSubmissionsAsync(GetAccountSubmissionsRequest request, CancellationToken cancellationToken = default);
//     Task<AccountAvatar> GetAvatarAsync(GetAccountAvatarRequest request, CancellationToken cancellationToken = default);
//     Task<AvailableAvatarList> GetAvailableAvatarsAsync(GetAccountAvailableAvatarsRequest request, CancellationToken cancellationToken = default);
//     Task<AccountSettings> GetAccountSettingsAsync(CancellationToken cancellationToken = default);
//     Task<bool> ChangeAccountSettingsAsync(ChangeAccountSettingsRequest request, CancellationToken cancellationToken = default);
//     Task<GalleryProfile> GetGalleryProfileAsync(GetAccountGalleryProfileRequest request, CancellationToken cancellationToken = default);
//     Task<Album[]> GetAlbumsAsync(GetAccountAlbumsRequest request, CancellationToken cancellationToken = default);
//     Task<Comment[]> GetCommentsAsync(GetCommentRequest request, CancellationToken cancellationToken = default);
// }

// public record GetAccountRequest
// {
//     public required string UserName { get; init; }
// }

// public record GetAccountBlockStatusRequest
// {
//     public required string UserName { get; init; }
// }

// public record BlockAccountRequest
// {
//     public required string UserName { get; init; }
// }

// public record UnblockAccountRequest
// {
//     public required string UserName { get; init; }
// }

// public record GetAccountImagesRequest
// {
//     public int? Page { get; init; }
// }

// public record GetAccountAlbumsRequest
// {
//     public int? Page { get; init; }
// }

// public record GetAccountFavoritesRequest
// {
//     public required string UserName { get; init; }
//     public int Page { get; set; }
//     public FavoriteSort Sort { get; set; } = FavoriteSort.Newest;
// }

// public record GetAccountSubmissionsRequest
// {
//     public required string UserName { get; init; }
//     public int Page { get; set; }
//     public SubmissionSort Sort { get; set; } = SubmissionSort.Newest;
// }

// public record GetAccountAvailableAvatarsRequest
// {
//     public string? UserName { get; init; }
// }

// public record GetAccountAvatarRequest
// {
//     public required string UserName { get; init; }
// }

// public record ChangeAccountSettingsRequest
// {
//     public string? Bio { get; init; }
//     public bool? PublicImages { get; init; }
//     public bool? MessagesEnabled { get; init; }
//     public AlbumPrivacy? AlbumPrivacy { get; init; }
//     public bool? AcceptedGalleryTerms { get; init; }
//     public string? UserName { get; init; }
//     public bool? ShowMature { get; init; }
//     public bool? NewsletterSubscribed { get; init; }
//     public string? Avatar { get; init; }
// }

// public record GetAccountGalleryProfileRequest
// {
//     public required string UserName { get; init; }
// }

// public record GetAccountCommentsRequest
// {
//     public required string UserName { get; init; }
//     public CommentSort Sort { get; init; } = CommentSort.Newest;
//     public int Page { get; init; }
// }

// public record FollowTagRequest
// {
//     public required string TagName { get; init; }
// }

// public enum FavoriteSort
// {
//     [EnumMember(Value = "newest")]
//     Newest,
//     [EnumMember(Value = "oldest")]
//     Oldest
// }

// public enum SubmissionSort
// {
//     [EnumMember(Value = "newest")]
//     Newest,
//     [EnumMember(Value = "oldest")]
//     Oldest,
//     [EnumMember(Value = "worst")]
//     Worst,
//     [EnumMember(Value = "best")]
//     Best
// }

// public enum CommentSort
// {
//     [EnumMember(Value = "newest")]
//     Newest,
//     [EnumMember(Value = "oldest")]
//     Oldest,
//     [EnumMember(Value = "worst")]
//     Worst,
//     [EnumMember(Value = "best")]
//     Best
// }