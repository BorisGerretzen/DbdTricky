using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Customizations;

public class DbdTrickyCustomizationsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyCustomizationsClient
{
    public Task<Dictionary<string, DbdTrickyCustomization>> GetCustomizations(string? character, string? type, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (character is not null) parameters.Add("character", character);
        if (type is not null) parameters.Add("type", type);

        return Get<Dictionary<string, DbdTrickyCustomization>>("customizations", parameters, cancellationToken);
    }

    public Task<DbdTrickyCustomization?> GetCustomization(string itemId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "item", itemId } };

        return GetOrDefault<DbdTrickyCustomization>("customizations", parameters, cancellationToken);
    }
}