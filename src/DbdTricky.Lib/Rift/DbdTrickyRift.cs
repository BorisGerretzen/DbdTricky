namespace DbdTricky.Lib.Rift;

public class DbdTrickyRift
{
    public required int Tiers { get; init; }
    public required Dictionary<string, IEnumerable<DbdTrickyRiftReward>> Free { get; init; }
    public required Dictionary<string, IEnumerable<DbdTrickyRiftReward>> Premium { get; init; }
    public required long Start { get; init; }
    
    [JsonIgnore] public DateTime StartDateTime => DateTime.UnixEpoch.AddSeconds(Start);
}