using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Characters;

public class DbdTrickyCharactersClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyCharactersClient
{
    public Task<Dictionary<long, DbdTrickyCharacter>> GetCharacters(DbdTrickyRole? role, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (role.HasValue) parameters.Add("role", role.Value.ToString());

        return Get<Dictionary<long, DbdTrickyCharacter>>("characters", parameters, cancellationToken);
    }

    public Task<DbdTrickyCharacter?> GetCharacter(string characterId, bool includePerks = false, bool includeItem = false, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "character", characterId } };
        if (includePerks) parameters.Add("includeperks", null);
        if (includeItem) parameters.Add("includeitem", null);

        return GetOrDefault<DbdTrickyCharacter>("characterinfo", parameters, cancellationToken);
    }

    public Task<DbdTrickyCharacter> GetRandom(DbdTrickyRole? role, bool includePerks = false, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>();
        if (role.HasValue) parameters.Add("role", role.Value.ToString());
        if (includePerks) parameters.Add("includeperks", null);

        return Get<DbdTrickyCharacter>("randomcharacter", parameters, cancellationToken);
    }
}