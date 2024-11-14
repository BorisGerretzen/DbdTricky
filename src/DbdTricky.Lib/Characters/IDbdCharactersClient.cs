using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Characters;

public interface IDbdCharactersClient
{
    /// <summary>
    /// Gets all characters.
    /// </summary>
    /// <param name="role">Filter by role.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Characters indexed by id.</returns>
    Task<Dictionary<long, DbdTrickyCharacter>> GetCharacters(DbdRole? role, CancellationToken cancellationToken = default);
    
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
    Task<DbdTrickyCharacter> GetRandom(DbdRole? role, bool includePerks = false, CancellationToken cancellationToken = default);
}