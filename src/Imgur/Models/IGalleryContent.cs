using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imgur;

/// <summary>
/// An interface that represents either a GalleryImage or a GalleryAlbum.
/// </summary>
[JsonConverter(typeof(GalleryContentJsonConverter))]
public interface IGalleryContent
{
    bool IsAlbum { get; }
}

public sealed class GalleryContentJsonConverter : JsonConverter<IGalleryContent>
{
    public override IGalleryContent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var copiedReader = reader;
        while (copiedReader.Read())
        {
            if (copiedReader.TokenType == JsonTokenType.PropertyName)
            {
                if (copiedReader.GetString() == "is_album")
                {
                    copiedReader.Read();

                    var isAlbum = copiedReader.GetBoolean();
                    if (isAlbum)
                    {
                        return ((JsonConverter<GalleryAlbum>)options.GetConverter(typeof(GalleryAlbum))).Read(ref reader, typeof(GalleryAlbum), options);
                    }
                    else
                    {
                        return ((JsonConverter<GalleryImage>)options.GetConverter(typeof(GalleryImage))).Read(ref reader, typeof(GalleryImage), options);
                    }
                }
            }
        }

        throw new ArgumentException("'is_album' property is not found.");
    }

    public override void Write(Utf8JsonWriter writer, IGalleryContent value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else if (value is GalleryAlbum album)
        {
            ((JsonConverter<GalleryAlbum>)options.GetConverter(typeof(GalleryAlbum))).Write(writer, album, options);
        }
        else if (value is GalleryImage image)
        {
            ((JsonConverter<GalleryImage>)options.GetConverter(typeof(GalleryImage))).Write(writer, image, options);
        }
        else
        {
            throw new NotSupportedException($"{value.GetType().FullName} is not supported. The value must be GalleryAlbum or GalleryImage");
        }
    }
}