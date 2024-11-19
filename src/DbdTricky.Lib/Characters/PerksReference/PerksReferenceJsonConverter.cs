using System.Text.Json;
using DbdTricky.Lib.Perks;

namespace DbdTricky.Lib.Characters;

public class PerksReferenceJsonConverter : JsonConverter<DbdTrickyPerksReference>
{
    public override DbdTrickyPerksReference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if(reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Expected array");
        
        var ids = new List<string>();
        var perks = new List<DbdTrickyPerk>();
        
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
                break;

            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    ids.Add(reader.GetString() ?? string.Empty);
                    break;
                case JsonTokenType.StartObject:
                {
                    var perk = JsonSerializer.Deserialize<DbdTrickyPerk>(ref reader, options);
                    if (perk != null)
                    {
                        perks.Add(perk);
                    }

                    break;
                }
                case JsonTokenType.Null when Nullable.GetUnderlyingType(typeToConvert) != null: // Only return null if the type is nullable
                    return null;
                default:
                    throw new JsonException("Unexpected JSON token.");
            }
        }
        
        if(ids.Count != 0 && perks.Count != 0) throw new JsonException("Expected either ids or perks, not both");
        
        return new DbdTrickyPerksReference
        {
            Ids = ids.Count > 0 ? ids : null, 
            Perks = perks.Count > 0 ? perks : null
        };
    }

    public override void Write(Utf8JsonWriter writer, DbdTrickyPerksReference value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        
        if(value.Ids?.Count > 0 && value.Perks?.Count > 0) throw new JsonException("Expected either ids or perks, not both");
        
        if (value.Ids != null)
        {
            foreach (var id in value.Ids)
            {
                writer.WriteStringValue(id);
            }
        }

        if (value.Perks != null)
        {
            foreach (var perk in value.Perks)
            {
                JsonSerializer.Serialize(writer, perk, options);
            }
        }

        writer.WriteEndArray();
    }
}