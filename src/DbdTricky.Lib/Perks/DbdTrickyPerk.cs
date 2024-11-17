using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Perks;

public partial record DbdTrickyPerk
{
    public List<string>? Categories { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter<DbdTrickyRole>))] public required DbdTrickyRole Role { get; init; }
    public long? Character { get; init; }
    public required string Image { get; init; }
    public required int Teachable { get; init; }
    [JsonConverter(typeof(PerkTunablesJsonConverter))] public required DbdTrickyPerkTunables Tunables { get; init; }

    /// <summary>
    /// Cleans the string interpolation in the description and updates the tunables accordingly.
    /// This is useful for some perks where the description for example only contains "{2}" but no "{0}" or "{1}".
    /// </summary>
    /// <remarks>Requires <see cref="DbdTrickyPerkTunables"/> to be of type dictionary, this is usually the case with broken perks.</remarks>
    /// <returns>New instance of <see cref="DbdTrickyPerk"/> with cleaned description and updated tunables.</returns>
    [Pure]
    public DbdTrickyPerk Clean()
    {
        var description = Description;
        if (Tunables.TunablesDictionary == null) return this;
        
        var tunables = Tunables.TunablesDictionary.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        var targetsInText = StringInterpolationRegex()
            .Matches(Description)
            .Select(m => int.Parse(m.ValueSpan[1..^1]))
            .ToList();
        targetsInText.Sort();
        for (var i = 0; i < targetsInText.Count; i++)
        {
            description = Description.Replace("{" + targetsInText[i] + "}", "{" + i + "}");
            tunables[i] = tunables[targetsInText[i]];
            tunables.Remove(targetsInText[i]);
        }
    
        return this with { Description = description, Tunables = new DbdTrickyPerkTunables(tunables) };
    }
    
    [GeneratedRegex(@"\{\d+\}")]
    private static partial Regex StringInterpolationRegex();
}