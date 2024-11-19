namespace DbdTricky.Lib.Characters;

public interface IDbdTrickyCharactersClient
{
    /// <summary>
    /// Gets all characters.
    /// </summary>
    /// <param name="role">Filter by role.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Characters indexed by id.</returns>
    Task<Dictionary<long, DbdTrickyCharacter>> GetCharacters(DbdTrickyRole? role = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets a character by id.
    /// </summary>
    /// <param name="characterId">Character id.</param>
    /// <param name="includePerks">Whether to include perks.</param>
    /// <param name="includeItem">Whether to include </param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyCharacter?> GetCharacter(string characterId, bool includePerks = false, bool includeItem = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a random character.
    /// </summary>
    /// <param name="role">Filter by role.</param>
    /// <param name="includePerks">Whether to include perks.</param>
    /// <param name="cancellationToken"></param>
    Task<DbdTrickyCharacter> GetRandom(DbdTrickyRole? role = null, bool includePerks = false, CancellationToken cancellationToken = default);
}