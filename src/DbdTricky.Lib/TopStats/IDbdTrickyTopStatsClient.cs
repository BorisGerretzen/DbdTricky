using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.TopStats;

public interface IDbdTrickyTopStatsClient
{
    /// <summary>
    /// Get the top stats for a specific stat.
    /// </summary>
    /// <param name="statName">Stat name to retrieve, see <see cref="DbdTrickyStat"/> for available stats.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Top players and corresponding values.</returns>
    Task<List<DbdTrickyTopStat>> GetTopStats(string statName = DbdTrickyStat.Bloodpoints, CancellationToken cancellationToken = default);
}