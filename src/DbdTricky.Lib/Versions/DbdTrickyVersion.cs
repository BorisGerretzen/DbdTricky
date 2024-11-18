using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Versions;

public class DbdTrickyVersion
{
    public required string Version { get; init; }
    public required long LastUpdate { get; init; }
    
    [JsonIgnore] public DateTime LastUpdateDateTime => DateTime.UnixEpoch.AddSeconds(LastUpdate);
}