using System.Text.Json.Serialization;

namespace DbdTricky.Lib.GameModes;

public class DbdTrickyGameMode
{
    public string? Name { get; init; }
    [JsonConverter(typeof(DictionaryStringObjectJsonConverter))] public required Dictionary<string, object?> Modifiers { get; init; }
    public Dictionary<string, float>? Mutators { get; init; }
    public int LimitedTime { get; init; }
}