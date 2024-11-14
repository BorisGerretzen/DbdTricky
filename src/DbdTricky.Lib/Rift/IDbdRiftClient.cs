namespace DbdTricky.Lib.Rift;

public interface IDbdRiftClient
{
    /// <summary>
    /// Gets all rifts.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Rifts indexed by tome id.</returns>
    Task<Dictionary<string, DbdTrickyRift>> GetRifts(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets a rift by id.
    /// </summary>
    /// <param name="tomeId">Tome id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyRift?> GetRift(string tomeId, CancellationToken cancellationToken = default);
}