using System.Text.Json.Serialization;
using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Characters;

public class DbdTrickyCharacter
{
    public required string Name { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter<DbdTrickyRole>))] public required DbdTrickyRole Role { get; init; }
    public required string Image { get; init; }
    public required string Difficulty { get; init; }
    public required string Gender { get; init; }
    public required string Height { get; init; }
    public required string Bio { get; init; }
    public required string Story { get; init; }
    public Dictionary<string, float>? Tunables { get; init; }
    [JsonConverter(typeof(ItemReferenceJsonConverter))] public DbdTrickyItemReference? Item { get; init; }
    public required List<string> Outfit { get; init; }
    public string? Dlc { get; init; }
    [JsonConverter(typeof(PerksReferenceJsonConverter))] public required DbdTrickyPerksReference Perks { get; init; }
}