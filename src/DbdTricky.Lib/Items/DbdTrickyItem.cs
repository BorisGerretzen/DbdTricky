using System.Text.Json.Serialization;
using DbdTricky.Lib.Addons;
using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Items;

public class DbdTrickyItem
{
    public required string Type { get; init; }
    [JsonPropertyName("item_type")] public string? ItemType { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter<DbdTrickyRole>))] public DbdTrickyRole? Role { get; init; }
    public List<DbdTrickyModifier>? Modifiers { get; init; }
    public required int Bloodweb { get; init; }
    public string? Event { get; init; }
    public required string Rarity { get; init; }
    public required string Image { get; init; }
    
    /// <summary>
    /// Addons indexed by id.
    /// Only present when the item is of type <c>power</c> and data is retrieved through <see cref="IDbdTrickyItemsClient.GetItem"/>.
    /// </summary>
    public Dictionary<string, DbdTrickyAddon>? Addons { get; init; }
}