using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Items;

public interface IDbdItemsClient
{
    /// <summary>
    /// Get all items
    /// </summary>
    /// <param name="role">Filter by role.</param>
    /// <param name="type">Filter by type (<c>"item"</c>, <c>"power"</c>, <c>"none"</c>).</param>
    /// <param name="itemType">Filter by item type (<c>"medkit"</c>, <c>"map"</c>, <c>"flashlight"</c>, <c>"firecracker"</c>, <c>"toolbox"</c>, <c>null</c>)</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Items indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyItem>> GetItems(DbdRole? role = null, string? type = null, string? itemType = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get an item by id.
    /// </summary>
    /// <param name="itemId">Item id.</param>
    /// <param name="includeAddons">Whether to include addons in the response, is only set if <see cref="DbdTrickyItem.Type"/> is <c>"power"</c>.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyItem?> GetItem(string itemId, bool includeAddons = false, CancellationToken cancellationToken = default);
}