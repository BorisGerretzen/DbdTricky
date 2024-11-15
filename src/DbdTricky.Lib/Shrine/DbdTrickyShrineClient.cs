using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Shrine;

public class DbdTrickyShrineClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyShrineClient
{
    /// <inheritdoc />
    public Task<DbdTrickyShrine> GetShrine(bool includePerkInfo = false, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (includePerkInfo) parameters.Add("includeperkinfo", "1");
        
        return Get<DbdTrickyShrine>("shrine", parameters, cancellationToken);
    }
}