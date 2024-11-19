using System.Text.Json;
using DbdTricky.Lib.Items;

namespace DbdTricky.Lib.Characters;

public class ItemReferenceJsonConverter : JsonConverter<DbdTrickyItemReference>
{
    public override DbdTrickyItemReference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
            {
                var id = reader.GetString();
                return new DbdTrickyItemReference { Id = id };
            }
            case JsonTokenType.StartObject:
            {
                var item = JsonSerializer.Deserialize<DbdTrickyItem>(ref reader, options);
                return new DbdTrickyItemReference { Item = item };
            }
            case JsonTokenType.Null when Nullable.GetUnderlyingType(typeToConvert) != null: // Only return null if the type is nullable
                return null;
            default:
                throw new JsonException("Expected either a string or an object.");
        }
    }

    public override void Write(Utf8JsonWriter writer, DbdTrickyItemReference value, JsonSerializerOptions options)
    {
        if (value is { Id: not null, Item: not null })
            throw new JsonException("Expected either Id or Item, not both.");

        if (value.Id != null)
        {
            writer.WriteStringValue(value.Id);
            return;
        }

        if (value.Item != null)
        {
            JsonSerializer.Serialize(writer, value.Item, options);
            return;
        }

        throw new JsonException("Expected either Id or Item to be set.");
    }
}