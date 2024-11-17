using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Addons;

public class DbdTrickyAddonsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyAddonsClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyAddon>> GetAddons(DbdTrickyRole? role = null, string? itemType = null, string? item = null,
        CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (role.HasValue) parameters.Add("role", role.Value.AsString());
        if (itemType != null) parameters.Add("item_type", itemType);
        if (item != null) parameters.Add("item", item);

        return Get<Dictionary<string, DbdTrickyAddon>>("addons", parameters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyAddon?> GetAddon(string addonId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "addon", addonId } };
        return GetOrDefault<DbdTrickyAddon>("addoninfo", parameters, cancellationToken);
    }
}