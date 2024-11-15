using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Archives;

public class DbdTrickyArchivesClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyArchivesClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyArchive>> GetArchives(CancellationToken cancellationToken = default)
    {
        return Get<Dictionary<string, DbdTrickyArchive>>("archives", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyArchive?> GetArchive(string tomeId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "tome", tomeId } };
        return GetOrDefault<DbdTrickyArchive>("archives", parameters, cancellationToken);
    }
}