using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Imgur;

public interface IComment
{
    Task<Comment> GetAsync(GetCommentRequest request, CancellationToken cancellationToken = default);
    Task<CreatedComment> CreateAsync(CreateCommentRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(DeleteCommentRequest request, CancellationToken cancellationToken = default);
    Task<bool> VoteAsync(VoteCommentRequest request, CancellationToken cancellationToken = default);
    Task<bool> ReportAsync(ReportCommentRequest request, CancellationToken cancellationToken = default);
}

public record GetCommentRequest
{
    public required long CommentId { get; init; }
    public bool WithReplies { get; init; } = true;
}

public record CreateCommentRequest
{
    [JsonPropertyName("image_id")]
    public required string ImageId { get; init; }

    [JsonPropertyName("comment")]
    public required string Comment { get; init; }

    [JsonPropertyName("parent_id")]
    public int? ParentId { get; init; }
}

public record DeleteCommentRequest
{
    public required long CommentId { get; init; }
}

public record VoteCommentRequest
{
    public required long CommentId { get; init; }
    public required VoteType Type { get; init; }
}

public record ReportCommentRequest
{
    public required long CommentId { get; init; }
    public ReportReason? ReportReason { get; set; }
}

public enum VoteType
{
    [EnumMember(Value = "up")]
    Up,
    [EnumMember(Value = "down")]
    Down,
}

public enum ReportReason
{
    DoesNotBelongOnImgur = 1,
    Spam = 2,
    Abusive = 3,
    MatureContentNotMarkedAsMature = 4,
    Pornography = 5
}