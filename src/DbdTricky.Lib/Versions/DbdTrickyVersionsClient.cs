using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Versions;

public class DbdTrickyVersionsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyVersionsClient
{
    public Task<DbdTrickyVersions> GetVersions(CancellationToken cancellationToken = default)
    {
        return Get<DbdTrickyVersions>("versions", null, cancellationToken);
    }
}