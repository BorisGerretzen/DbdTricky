namespace DbdTricky.Lib.Maps;

public interface IDbdTrickyMapsClient
{
    /// <summary>
    /// Get all maps
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Maps indexed by map id.</returns>
    Task<Dictionary<string, DbdTrickyMap>> GetMaps(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get a map by id.
    /// </summary>
    /// <param name="mapId">Map id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyMap?> GetMap(string mapId, CancellationToken cancellationToken = default);
}