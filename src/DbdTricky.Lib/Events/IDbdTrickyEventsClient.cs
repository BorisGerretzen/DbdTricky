namespace DbdTricky.Lib.Events;

public interface IDbdTrickyEventsClient
{
    /// <summary>
    /// Gets a list of all events.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of events.</returns>
    Task<List<DbdTrickyEvent>> GetEvents(CancellationToken cancellationToken = default);
}