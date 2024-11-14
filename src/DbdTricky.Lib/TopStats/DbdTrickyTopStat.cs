namespace DbdTricky.Lib.TopStats;

public class DbdTrickyTopStat
{
    public required long SteamId { get; init; }
    public required string Persona { get; init; }
    public object? Fancy { get; init; }
    public required long Value { get; init; }
}