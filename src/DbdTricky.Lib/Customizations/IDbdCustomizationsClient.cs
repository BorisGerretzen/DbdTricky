namespace DbdTricky.Lib.Customizations;

public interface IDbdCustomizationsClient
{
    /// <summary>
    /// Get all customizations.
    /// </summary>
    /// <param name="character">Filter by character id.</param>
    /// <param name="type">Filter by type.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Customizations indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyCustomization>> GetCustomizations(string? character, string? type, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get a customization by item id.
    /// </summary>
    /// <param name="itemId">Item id.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyCustomization?> GetCustomization(string itemId, CancellationToken cancellationToken = default);
}