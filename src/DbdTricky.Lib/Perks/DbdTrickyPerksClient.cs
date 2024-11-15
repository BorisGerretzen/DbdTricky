using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Perks;

public class DbdTrickyPerksClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyPerksClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyPerk>> GetPerks(string? character = null, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (character != null) parameters.Add("character", character);

        return Get<Dictionary<string, DbdTrickyPerk>>("perks", parameters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyPerk?> GetPerk(string perkId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "perk", perkId } };
        return GetOrDefault<DbdTrickyPerk>("perkinfo", parameters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyPerk>> GetRandom(DbdTrickyRole? role, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (role.HasValue) parameters.Add("role", role.Value.ToString());

        return Get<Dictionary<string, DbdTrickyPerk>>("randomperks", parameters, cancellationToken);
    }
}