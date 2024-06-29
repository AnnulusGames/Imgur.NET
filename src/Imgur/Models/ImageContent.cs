using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imgur;

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

// write-only json converter
public sealed class ImageContentJsonConverter : JsonConverter<ImageContent>
{
    public override ImageContent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }

    public override void Write(Utf8JsonWriter writer, ImageContent value, JsonSerializerOptions options)
    {
        if (value.Stream != null)
        {
            JsonSerializer.Serialize(writer, value.Stream, options);
        }
        else if (value.Bytes != null)
        {
            JsonSerializer.Serialize(writer, value.Bytes, options);
        }
        else if (value.Text != null)
        {
            JsonSerializer.Serialize(writer, value.Text, options);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
