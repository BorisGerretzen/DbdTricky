using System.Text.Json;
using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Common;

public class IntOrStringJsonConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                return reader.GetInt32();
            case JsonTokenType.String:
            {
                var str = reader.GetString();
                if (int.TryParse(str, out var value)) return value;
                throw new JsonException($"Cannot convert {str} to int");
            }
            default:
                throw new JsonException();
        }
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}