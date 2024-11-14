namespace DbdTricky.Lib.RankReset;

public interface IDbdTrickyRankResetClient
{
    /// <summary>
    /// Gets the next rank reset.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Next rank reset.</returns>
    Task<DbdTrickyRankReset> GetRankReset(CancellationToken cancellationToken = default);
}