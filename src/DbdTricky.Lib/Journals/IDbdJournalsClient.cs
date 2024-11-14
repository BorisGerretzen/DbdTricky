namespace DbdTricky.Lib.Journals;

public interface IDbdJournalsClient
{
    /// <summary>
    /// Get all journals
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Journals indexed by tome id.</returns>
    Task<Dictionary<string, DbdTrickyJournal>> GetJournals(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get a specific journal
    /// </summary>
    /// <param name="tomeId">Tome id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found</returns>
    Task<DbdTrickyJournal?> GetJournal(string tomeId, CancellationToken cancellationToken = default);
}