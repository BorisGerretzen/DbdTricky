﻿namespace DbdTricky.Lib.Rift;

public class DbdTrickyRiftsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyRiftClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyRift>> GetRifts(CancellationToken cancellationToken = default)
    {
        return Get<Dictionary<string, DbdTrickyRift>>("rifts", null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyRift?> GetRift(string tomeId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "tome", tomeId } };
        return GetOrDefault<DbdTrickyRift?>("rifts", parameters, cancellationToken);
    }
}