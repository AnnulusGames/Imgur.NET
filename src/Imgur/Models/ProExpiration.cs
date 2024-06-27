using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imgur;

[JsonConverter(typeof(ProExpirationJsonConverter))]
public readonly record struct ProExpiration
{
    public ProExpiration(long expirationDate)
    {
        ExpirationDate = expirationDate;
    }

    public long? ExpirationDate { get; }

    public static implicit operator ProExpiration(long dateTime)
    {
        return new(dateTime);
    }

    public static implicit operator ProExpiration(DateTime dateTime)
    {
        return new(dateTime.Ticks);
    }

    public static implicit operator bool(ProExpiration proExpiration)
    {
        return proExpiration.ExpirationDate != null;
    }
}

internal sealed class ProExpirationJsonConverter : JsonConverter<ProExpiration>
{
    public override ProExpiration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (Utf8Parser.TryParse(reader.ValueSpan, out long value1, out _)) return value1;

        if (!Utf8Parser.TryParse(reader.ValueSpan, out bool value2, out _) || value2)
        {
            throw new JsonException("ProExpiration must be long value or false");
        }

        return default;
    }

    public override void Write(Utf8JsonWriter writer, ProExpiration value, JsonSerializerOptions options)
    {
        if (!value) writer.WriteBooleanValue(false);
        else writer.WriteNumberValue(value.ExpirationDate!.Value);
    }
}
