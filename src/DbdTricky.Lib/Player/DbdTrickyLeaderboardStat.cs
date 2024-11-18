using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Player;

public class DbdTrickyLeaderboardStat
{
    public required string Stat { get; init; }
    public required long Value { get; init; }
    public required int Position { get; init; }
    [JsonPropertyName("updated_at")] public required long UpdatedAt { get; init; }
    
    [JsonIgnore] public DateTime UpdatedAtDateTime => DateTime.UnixEpoch.AddSeconds(UpdatedAt);
}