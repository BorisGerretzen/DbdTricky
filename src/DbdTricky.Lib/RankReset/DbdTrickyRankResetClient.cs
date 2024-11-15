﻿using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.RankReset;

public class DbdTrickyRankResetClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyRankResetClient
{
    public Task<DbdTrickyRankReset> GetRankReset(CancellationToken cancellationToken = default)
    {
        return Get<DbdTrickyRankReset>("rankreset", null, cancellationToken);
    }
}