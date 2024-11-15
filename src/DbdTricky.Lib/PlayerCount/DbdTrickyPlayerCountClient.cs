using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.PlayerCount;

public class DbdTrickyPlayerCountClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyPlayerCountClient
{
    public Task<List<DbdTrickyPlayerCount>> GetPlayerCounts(CancellationToken cancellationToken = default)
    {
        return Get<List<DbdTrickyPlayerCount>>("playercount", null, cancellationToken);
    }
}