using System.Text.Json.Serialization;
using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Customizations;

public class DbdTrickyCustomization
{
    public required string Type { get; init; }
    public string? Category { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? Collection { get; init; }
    public long? Character { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter<DbdTrickyRole>))] public DbdTrickyRole? Role { get; init; }
    public required string Rarity { get; init; }
    public string? Outfit { get; init; }
    public List<string>? Items { get; init; }
    public required string Image { get; init; }
}