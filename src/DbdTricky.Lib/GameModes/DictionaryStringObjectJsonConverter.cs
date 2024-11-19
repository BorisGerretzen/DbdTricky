using System.Text.Json;

namespace DbdTricky.Lib.GameModes;

public class DictionaryStringObjectJsonConverter : JsonConverter<Dictionary<string, object?>>
{
    public override Dictionary<string, object?> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token.");
        }

        var dictionary = new Dictionary<string, object?>();

        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType != JsonTokenType.PropertyName) continue;
            var key = reader.GetString() ?? throw new JsonException("Expected string key.");
            reader.Read();

            var value = ReadValue(ref reader, options);
            dictionary[key] = value;
        }

        return dictionary;
    }

    private object? ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.Number => reader.TryGetInt64(out var l) ? l : reader.GetDouble(),
            JsonTokenType.String => reader.GetString() ?? string.Empty,
            JsonTokenType.StartArray => ReadArray(ref reader, options),
            JsonTokenType.StartObject => Read(ref reader, typeof(Dictionary<string, object?>), options),
            JsonTokenType.Null => null,
            _ => throw new JsonException($"Unexpected token: {reader.TokenType}")
        };
    }

    private List<object?> ReadArray(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var list = new List<object?>();

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            list.Add(ReadValue(ref reader, options));
        }

        return list;
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, object?> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        foreach (var kvp in value)
        {
            writer.WritePropertyName(kvp.Key);
            JsonSerializer.Serialize(writer, kvp.Value, options);
        }
        writer.WriteEndObject();
    }
}