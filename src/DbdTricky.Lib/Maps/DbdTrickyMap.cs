namespace DbdTricky.Lib.Maps;

public class DbdTrickyMap
{
    public string? Alias { get; init; }
    public required string Realm { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public string? Dlc { get; init; }
    public string? Image { get; init; }
}