using System.Text.Json.Serialization;

namespace Imgur;

[JsonSerializable(typeof(Account))]
[JsonSerializable(typeof(AccountSettings))]
[JsonSerializable(typeof(Album))]
[JsonSerializable(typeof(CreatedAlbum))]
[JsonSerializable(typeof(Comment))]
[JsonSerializable(typeof(CreatedComment))]
[JsonSerializable(typeof(Conversation))]
[JsonSerializable(typeof(GalleryAlbum))]
[JsonSerializable(typeof(GalleryImage))]
[JsonSerializable(typeof(IGalleryContent))]
[JsonSerializable(typeof(GalleryProfile))]
[JsonSerializable(typeof(Image))]
[JsonSerializable(typeof(Message))]
[JsonSerializable(typeof(Nofication))]
[JsonSerializable(typeof(Tag))]
[JsonSerializable(typeof(TagVote))]
[JsonSerializable(typeof(Topic))]
[JsonSerializable(typeof(Vote))]
[JsonSerializable(typeof(ProExpiration))]
[JsonSerializable(typeof(CreateAlbumRequest))]
[JsonSerializable(typeof(CreateCommentRequest))]
[JsonSerializable(typeof(GenerateAccessTokenResponse))]
[JsonSerializable(typeof(ImgurResponse<Account>))]
[JsonSerializable(typeof(ImgurResponse<AccountSettings>))]
[JsonSerializable(typeof(ImgurResponse<Album>))]
[JsonSerializable(typeof(ImgurResponse<Album[]>))]
[JsonSerializable(typeof(ImgurResponse<CreatedAlbum>))]
[JsonSerializable(typeof(ImgurResponse<Comment>))]
[JsonSerializable(typeof(ImgurResponse<Comment[]>))]
[JsonSerializable(typeof(ImgurResponse<CreatedComment>))]
[JsonSerializable(typeof(ImgurResponse<Conversation>))]
[JsonSerializable(typeof(ImgurResponse<GalleryAlbum>))]
[JsonSerializable(typeof(ImgurResponse<GalleryImage>))]
[JsonSerializable(typeof(ImgurResponse<IGalleryContent>))]
[JsonSerializable(typeof(ImgurResponse<GalleryProfile>))]
[JsonSerializable(typeof(ImgurResponse<Image>))]
[JsonSerializable(typeof(ImgurResponse<Image[]>))]
[JsonSerializable(typeof(ImgurResponse<bool>))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, UseStringEnumConverter = true)]
public partial class ImgurJsonSerializerContext : JsonSerializerContext;