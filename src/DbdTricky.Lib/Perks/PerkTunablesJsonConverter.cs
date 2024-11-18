using System.Text.Json;
using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Perks;

public class PerkTunablesJsonConverter : JsonConverter<DbdTrickyPerkTunables>
{
    public override DbdTrickyPerkTunables? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.StartObject => new DbdTrickyPerkTunables(JsonSerializer.Deserialize<Dictionary<int, List<string>>>(ref reader, options)),
            JsonTokenType.StartArray => new DbdTrickyPerkTunables(JsonSerializer.Deserialize<List<List<string>>>(ref reader, options)),
            JsonTokenType.Null when Nullable.GetUnderlyingType(typeToConvert) is not null => null,
            JsonTokenType.Null => throw new JsonException("Cannot convert null to non-nullable type"),
            _ => throw new JsonException("Expected object or array")
        };
    }

    public override void Write(Utf8JsonWriter writer, DbdTrickyPerkTunables value, JsonSerializerOptions options)
    {
        if (value.TunablesDictionary is not null)
            JsonSerializer.Serialize(writer, value.TunablesDictionary, options);
        else if (value.TunablesList is not null)
            JsonSerializer.Serialize(writer, value.TunablesList, options);
        else
            throw new JsonException("Either TunablesDictionary or TunablesList must be set");
    }
}