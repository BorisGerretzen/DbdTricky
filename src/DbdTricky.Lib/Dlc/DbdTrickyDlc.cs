using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Dlc;

public class DbdTrickyDlc
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required long SteamId { get; init; }
    public long Time { get; init; }
    
    [JsonIgnore] public DateTime DateTime => DateTime.UnixEpoch.AddSeconds(Time);
}