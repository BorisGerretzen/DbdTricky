namespace DbdTricky.Lib.Maps;

public class DbdTrickyMapsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyMapsClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyMap>> GetMaps(CancellationToken cancellationToken = default)
    {
        return Get<Dictionary<string, DbdTrickyMap>>("maps", null, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyMap?> GetMap(string mapId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "map", mapId } };
        return GetOrDefault<DbdTrickyMap>("mapinfo", parameters, cancellationToken);
    }
}