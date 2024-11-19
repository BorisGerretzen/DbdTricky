namespace DbdTricky.Lib.Perks;

public interface IDbdTrickyPerksClient
{
    /// <summary>
    /// Get all perks.
    /// </summary>
    /// <param name="character">Filter by character.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Perks indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyPerk>> GetPerks(string? character = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets a perk by id.
    /// </summary>
    /// <param name="perkId">Perk id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyPerk?> GetPerk(string perkId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get 4 random perks.
    /// </summary>
    /// <param name="role">Filter by role.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>4 random perks indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyPerk>> GetRandom(DbdTrickyRole? role = null, CancellationToken cancellationToken = default);
}