using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Archives;

public class DbdTrickyArchive
{
    public required string Name { get; init; }
    public Dictionary<string, DbdTrickyArchiveLevel> Levels { get; init; } = new();
    public required long Start { get; init; }
    public required long End { get; init; }
    
    [JsonIgnore] public DateTime StartDateTime => DateTime.UnixEpoch.AddSeconds(Start);
    [JsonIgnore] public DateTime EndDateTime => DateTime.UnixEpoch.AddSeconds(End);
}