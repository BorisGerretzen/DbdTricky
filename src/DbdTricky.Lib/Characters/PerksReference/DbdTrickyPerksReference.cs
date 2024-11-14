using DbdTricky.Lib.Perks;

namespace DbdTricky.Lib.Characters;

/// <summary>
/// Represents a reference to a list of perks.
/// Depending on the context, either <see cref="Ids"/> or <see cref="Perks"/> will be set.
/// </summary>
public class DbdTrickyPerksReference
{
    /// <summary>
    /// When the perks are retrieved through <see cref="IDbdCharactersClient.GetCharacters"/>.
    /// </summary>
    public List<string>? Ids { get; init; }
    
    /// <summary>
    /// When the perks are retrieved through <see cref="IDbdCharactersClient.GetCharacter"/> or <see cref="IDbdCharactersClient.GetRandom"/>.
    /// </summary>
    public List<DbdTrickyPerk>? Perks { get; init; }
}