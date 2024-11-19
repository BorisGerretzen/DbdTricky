namespace DbdTricky.Lib.Events;

public class DbdTrickyEvent
{
    public required string Event { get; init; }
    public required string Type { get; init; }
    public required string Name { get; init; }
    public required float Multiplier { get; init; }
    public required long Start { get; init; }
    public required long End { get; init; }
    
    [JsonIgnore] public DateTime StartDateTime => DateTime.UnixEpoch.AddSeconds(Start);
    [JsonIgnore] public DateTime EndDateTime => DateTime.UnixEpoch.AddSeconds(End);
}