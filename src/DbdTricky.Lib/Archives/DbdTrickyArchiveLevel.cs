using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Archives;

public class DbdTrickyArchiveLevel
{
    public required long Start { get; init; }
    [JsonIgnore] public DateTime StartDateTime => DateTime.UnixEpoch.AddSeconds(Start);
}