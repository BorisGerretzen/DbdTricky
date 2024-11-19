namespace DbdTricky.Lib.Shrine;

public class DbdTrickyShrine
{
    public required int Id { get; init; }
    /// <summary>
    /// The perks available in the shrine.
    /// Nullable fields are only present when called with <c>includePerkInfo</c> set to <c>true</c>.
    /// </summary>
    public required List<DbdTrickyShrinePerk> Perks { get; init; }
    public required long Start { get; init; }
    public required long End { get; init; }
    
    [JsonIgnore] public DateTime StartDateTime => DateTime.UnixEpoch.AddSeconds(Start);
    [JsonIgnore] public DateTime EndDateTime => DateTime.UnixEpoch.AddSeconds(End);
}

public class DbdTrickyShrinePerk
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? Image { get; init; }
    public string? Character { get; init; }
    public required int BloodPoints { get; init; }
    public required int Shards { get; init; }
}