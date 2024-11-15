using DbdTricky.Lib.Items;

namespace DbdTricky.Lib.Characters;

/// <summary>
/// Represents a reference to an item.
/// Depending on the context, either <see cref="Id"/> or <see cref="Item"/> will be set.
/// </summary>
public class DbdTrickyItemReference
{
    /// <summary>
    /// When the item is retrieved through <see cref="IDbdTrickyCharactersClient.GetCharacters"/>.
    /// </summary>
    public string? Id { get; init; }
    
    /// <summary>
    /// When the item is retrieved through <see cref="IDbdTrickyCharactersClient.GetCharacter"/>.
    /// </summary>
    public DbdTrickyItem? Item { get; init; }
}