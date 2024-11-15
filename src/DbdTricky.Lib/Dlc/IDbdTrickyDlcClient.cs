namespace DbdTricky.Lib.Dlc;

public interface IDbdTrickyDlcClient
{
    /// <summary>
    /// Get all DLCs.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>DLCs indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyDlc>> GetDlcs(CancellationToken cancellationToken = default);
}