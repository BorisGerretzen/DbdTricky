namespace DbdTricky.Lib.Events;

public interface IDbdEventsClient
{
    /// <summary>
    /// Gets a list of all events.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of events.</returns>
    Task<List<DbdTrickyEvent>> GetEvents(CancellationToken cancellationToken = default);
}