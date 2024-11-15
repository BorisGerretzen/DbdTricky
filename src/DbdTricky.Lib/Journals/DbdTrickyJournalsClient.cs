using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Journals;

public class DbdTrickyJournalsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyJournalsClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyJournal>> GetJournals(CancellationToken cancellationToken = default)
    {
        return Get<Dictionary<string, DbdTrickyJournal>>("journals", null, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyJournal?> GetJournal(string tomeId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "tome", tomeId } };
        return GetOrDefault<DbdTrickyJournal>("journals", parameters, cancellationToken);
    }
}