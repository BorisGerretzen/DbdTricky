namespace DbdTricky.Lib.Offerings;

public interface IDbdTrickyOfferingsClient
{
    /// <summary>
    /// Get all offerings.
    /// </summary>
    /// <param name="role">Filter by role.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Offerings indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyOffering>> GetOfferings(DbdTrickyRole? role = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get an offering by id.
    /// </summary>
    /// <param name="offeringId">Offering id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyOffering?> GetOffering(string offeringId, CancellationToken cancellationToken = default);
}