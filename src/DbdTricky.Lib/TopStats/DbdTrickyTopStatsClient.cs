using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.TopStats;

public class DbdTrickyTopStatsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyTopStatsClient
{
    /// <inheritdoc />
    public Task<List<DbdTrickyTopStat>> GetTopStats(string statName = DbdTrickyStat.Bloodpoints, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "stat", statName } };
        return Get<List<DbdTrickyTopStat>>("topstats", parameters, cancellationToken);
    }
}