namespace DbdTricky.Lib.Versions;

public interface IDbdTrickyVersionsClient
{
    /// <summary>
    /// Gets the versions of the different APIs.
    /// Compare with <see cref="DbdTrickyVersions.LastKnown"/> to see if the library is outdated.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Version for each API.</returns>
    Task<DbdTrickyVersions> GetVersions(CancellationToken cancellationToken = default);
}