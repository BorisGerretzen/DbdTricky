namespace DbdTricky.Lib.Addons;

public interface IDbdTrickyAddonsClient
{
    /// <summary>
    /// Gets all addons.
    /// </summary>
    /// <param name="role">Filter by role.</param>
    /// <param name="itemType">Filter by item type (<c>"flashlight"</c>, <c>"toolbox"</c>, <c>"medkit"</c>, <c>"map"</c>, <c>null</c>).</param> 
    /// <param name="item">Get addons for specific item (only returns something for killer powers).</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Addons indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyAddon>> GetAddons(DbdTrickyRole? role = null, string? itemType = null, string? item = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets addon by id.
    /// </summary>
    /// <param name="addonId">Addon id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyAddon?> GetAddon(string addonId, CancellationToken cancellationToken = default);
}