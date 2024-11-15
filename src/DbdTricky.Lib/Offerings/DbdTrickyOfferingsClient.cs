﻿using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Offerings;

public class DbdTrickyOfferingsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyOfferingsClient
{
    public Task<Dictionary<string, DbdTrickyOffering>> GetOfferings(DbdTrickyRole? role = null, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (role.HasValue) parameters.Add("role", role.Value.ToString());

        return Get<Dictionary<string, DbdTrickyOffering>>("offerings", parameters, cancellationToken);
    }

    public Task<DbdTrickyOffering?> GetOffering(string offeringId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "offering", offeringId } };
        return GetOrDefault<DbdTrickyOffering>("offeringinfo", parameters, cancellationToken);
    }
}