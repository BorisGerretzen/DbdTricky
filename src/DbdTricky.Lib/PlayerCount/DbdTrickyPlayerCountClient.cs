namespace DbdTricky.Lib.PlayerCount;

public class DbdTrickyPlayerCountClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyPlayerCountClient
{
    /// <inheritdoc />
    public Task<List<DbdTrickyPlayerCount>> GetPlayerCounts(CancellationToken cancellationToken = default)
    {
        return Get<List<DbdTrickyPlayerCount>>("playercount", null, cancellationToken);
    }
}