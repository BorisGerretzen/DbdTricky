namespace DbdTricky.Lib.Versions;

public class DbdTrickyVersions
{
    public required DbdTrickyVersion Addons { get; init; }
    public required DbdTrickyVersion Archives { get; init; }
    public required DbdTrickyVersion Characters { get; init; }
    public required DbdTrickyVersion Customizations { get; init; }
    public required DbdTrickyVersion Dlc { get; init; }
    public required DbdTrickyVersion Gamemodes { get; init; }
    public required DbdTrickyVersion Items { get; init; }
    public required DbdTrickyVersion Journals { get; init; }
    public required DbdTrickyVersion Maps { get; init; }
    public required DbdTrickyVersion Offerings { get; init; }
    public required DbdTrickyVersion Perks { get; init; }
    public required DbdTrickyVersion Rift { get; init; }
    
    /// <summary>
    /// The versions of the API when this library was last updated.
    /// </summary>
    public static readonly DbdTrickyVersions LibraryLastUpdated = new()
    {
        Addons = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728557468 },
        Archives = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1729246248 },
        Characters = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555771 },
        Customizations = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555967 },
        Dlc = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555991 },
        Gamemodes = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555849 },
        Items = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728557461 },
        Journals = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555869 },
        Maps = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555874 },
        Offerings = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728557321 },
        Perks = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728557476 },
        Rift = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555940 }
    };
}