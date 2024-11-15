using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Items;

public class DbdTrickyItemsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyItemsClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyItem>> GetItems(DbdTrickyRole? role = null, string? type = null, string? itemType = null, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if(role.HasValue) parameters.Add("role", role.Value.ToString());
        if(!string.IsNullOrWhiteSpace(type)) parameters.Add("type", type);
        if(!string.IsNullOrWhiteSpace(itemType)) parameters.Add("itemtype", itemType);
        
        return Get<Dictionary<string, DbdTrickyItem>>("items", parameters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyItem?> GetItem(string itemId, bool includeAddons = false, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "item", itemId } };
        if(includeAddons) parameters.Add("includeaddons", null);
        
        return GetOrDefault<DbdTrickyItem>("iteminfo", parameters, cancellationToken);
    }
}