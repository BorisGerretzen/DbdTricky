namespace DbdTricky.Lib.TopStats;

public interface IDbdTopStatsClient
{
    /// <summary>
    /// Get the top stats for a specific stat.
    /// </summary>
    /// <param name="statName">Stat name to retrieve, see <see cref="DbdTrickyTopStats"/> for available stats.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Top players and corresponding values.</returns>
    Task<List<DbdTrickyTopStat>> GetTopStats(string statName = DbdTrickyTopStats.Bloodpoints, CancellationToken cancellationToken = default);
}