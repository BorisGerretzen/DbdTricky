namespace DbdTricky.Lib.PlayerCount;

public class DbdTrickyPlayerCount
{
    public required int PlayerCount { get; init; }
    [JsonPropertyName("updated_at")] public required long UpdatedAt { get; init; }
    
    [JsonIgnore] public DateTime UpdatedAtDateTime => DateTime.UnixEpoch.AddSeconds(UpdatedAt);
}