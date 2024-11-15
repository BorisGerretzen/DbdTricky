using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Events;

public class DbdTrickyEventsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyEventsClient
{
    public Task<List<DbdTrickyEvent>> GetEvents(CancellationToken cancellationToken = default)
    {
        return Get<List<DbdTrickyEvent>>("events", null, cancellationToken);
    }
}