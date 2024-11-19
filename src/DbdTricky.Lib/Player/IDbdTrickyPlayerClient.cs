namespace DbdTricky.Lib.Player;

public interface IDbdTrickyPlayerClient
{
    /// <summary>
    /// Get a leaderboard stat for a player.
    /// </summary>
    /// <param name="steamId">Steam id of the player.</param>
    /// <param name="stat">Stat key, see <see cref="DbdTrickyStat"/> for a list of stats.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if player not found.</returns>
    Task<DbdTrickyLeaderboardStat?> GetLeaderBoardStat(long steamId, string stat = DbdTrickyStat.Bloodpoints, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the adept status of all characters for a player.
    /// </summary>
    /// <param name="steamId">Steam id of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if player not found.</returns>
    Task<DbdTrickyPlayerAdepts?> GetAdepts(long steamId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all the stats for a player.
    /// </summary>
    /// <param name="steamId">Steam id of the player.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if player not found.</returns>
    Task<DbdTrickyPlayerStats?> GetStats(long steamId, CancellationToken cancellationToken = default);
}