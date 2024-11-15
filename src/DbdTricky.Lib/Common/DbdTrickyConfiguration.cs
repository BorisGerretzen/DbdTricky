namespace DbdTricky.Lib.Common;

public class DbdTrickyConfiguration
{
    public string BaseUrl { get; init; } = "https://dbd.tricky.lol/api";
    
    /// <summary>
    /// TODO, don't know how to authenticate yet.
    /// </summary>
    public string? ApiKey { get; init; }
    
    public string UserAgent { get; init; } = "DbdTricky.Lib";
}