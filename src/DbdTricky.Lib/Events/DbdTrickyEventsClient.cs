﻿namespace DbdTricky.Lib.Events;

public class DbdTrickyEventsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyEventsClient
{
    /// <inheritdoc />
    public Task<List<DbdTrickyEvent>> GetEvents(CancellationToken cancellationToken = default)
    {
        return Get<List<DbdTrickyEvent>>("events", null, cancellationToken);
    }
}