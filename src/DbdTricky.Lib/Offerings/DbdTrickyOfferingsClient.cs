using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Offerings;

public class DbdTrickyOfferingsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyOfferingsClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyOffering>> GetOfferings(DbdTrickyRole? role = null, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (role.HasValue) parameters.Add("role", role.Value.AsString());

        return Get<Dictionary<string, DbdTrickyOffering>>("offerings", parameters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyOffering?> GetOffering(string offeringId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "offering", offeringId } };
        return GetOrDefault<DbdTrickyOffering>("offeringinfo", parameters, cancellationToken);
    }
}