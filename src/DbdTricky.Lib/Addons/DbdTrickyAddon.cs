using System.Text.Json.Serialization;
using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Addons;

public class DbdTrickyAddon
{
    public required string Type { get; init; }
    [JsonPropertyName("item_type")] public string? ItemType { get; init; }
    public required List<string> Parents { get; init; } 
    public required string Name { get; init; }
    public required string Description { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter<DbdTrickyRole>))] public required DbdTrickyRole? Role { get; init; }
    public List<DbdTrickyModifier?>? Modifiers { get; init; }
    public required int Bloodweb { get; init; }
    public required string Rarity { get; init; }
    public required string Image { get; init; }
}