namespace DbdTricky.Lib.Rift;

public class DbdTrickyRiftReward
{
    [JsonConverter(typeof(IntOrStringJsonConverter))] public required int Amount { get; init; }
    public required string Id { get; init; }
    public required string Type { get; init; }
}