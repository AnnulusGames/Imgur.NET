using System.Text.Json.Serialization;

namespace Imgur;

public record AccountSettings
{
    [JsonPropertyName("account_url")]
    public string? AccountUrl { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("public_images")]
    public bool PublicImages { get; set; }

    [JsonPropertyName("album_privacy")]
    public AlbumPrivacy AlbumPrivacy { get; set; }

    [JsonPropertyName("pro_expiration")]
    public ProExpiration ProExpiration { get; set; }

    [JsonPropertyName("accepted_gallery_terms")]
    public bool AcceptedGalleryTerms { get; set; }

    [JsonPropertyName("active_emails")]
    public string[] ActiveEmails { get; set; } = [];

    [JsonPropertyName("messaging_enabled")]
    public bool MessagingEnabled { get; set; }

    [JsonPropertyName("blocked_users")]
    public BlockedUser[] BlockedUsers { get; set; } = [];

    [JsonPropertyName("show_mature")]
    public bool ShowMature { get; set; }

    [JsonPropertyName("newsletter_subscribed")]
    public bool NewsletterSubscribed { get; init; }

    [JsonPropertyName("first_party")]
    public bool FirstParty { get; set; }
}