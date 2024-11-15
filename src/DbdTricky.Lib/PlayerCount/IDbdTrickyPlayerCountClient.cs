namespace DbdTricky.Lib.PlayerCount;

public interface IDbdTrickyPlayerCountClient
{
    /// <summary>
    /// Gets the player counts of approximately the last 24 hours in 10 minute intervals.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of player counts.</returns>
    Task<List<DbdTrickyPlayerCount>> GetPlayerCounts(CancellationToken cancellationToken = default);
}