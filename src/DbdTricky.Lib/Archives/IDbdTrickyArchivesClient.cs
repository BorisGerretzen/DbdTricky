namespace DbdTricky.Lib.Archives;

public interface IDbdTrickyArchivesClient
{
    /// <summary>
    /// Gets all archives.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Archives indexed by tome id.</returns>
    Task<Dictionary<string, DbdTrickyArchive>> GetArchives(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets archive by id.
    /// </summary>
    /// <param name="tomeId">Tome to retrieve.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyArchive?> GetArchive(string tomeId, CancellationToken cancellationToken = default);
}