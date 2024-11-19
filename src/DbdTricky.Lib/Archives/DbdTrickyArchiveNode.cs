namespace DbdTricky.Lib.Archives;

public class DbdTrickyArchiveNode
{
    public required string Name { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter<DbdTrickyRole>))] public required DbdTrickyRole Role { get; init; }
    public string? Objective { get; init; }
    public required List<DbdTrickyArchiveReward> Rewards { get; init; }
}