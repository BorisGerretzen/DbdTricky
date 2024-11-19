namespace DbdTricky.Lib.RankReset;

public class DbdTrickyRankReset
{
    public required long RankReset { get; init; }
    
    [JsonIgnore] public DateTime RankResetDateTime => DateTime.UnixEpoch.AddSeconds(RankReset);
}