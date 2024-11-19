namespace DbdTricky.Lib.Customizations;

public class DbdTrickyCustomizationsClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyCustomizationsClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyCustomization>> GetCustomizations(string? character = null, string? type = null, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (character is not null) parameters.Add("character", character);
        if (type is not null) parameters.Add("type", type);

        return Get<Dictionary<string, DbdTrickyCustomization>>("customizations", parameters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyCustomization?> GetCustomization(string itemId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "item", itemId } };

        return GetOrDefault<DbdTrickyCustomization>("customizationinfo", parameters, cancellationToken);
    }
}