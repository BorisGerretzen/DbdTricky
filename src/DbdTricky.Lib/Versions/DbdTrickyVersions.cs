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
    public static readonly DbdTrickyVersions LastKnown = new()
    {
        Addons = new DbdTrickyVersion { Version = "8.3.2", LastUpdate = 1731917505 },
        Archives = new DbdTrickyVersion { Version = "8.3.2", LastUpdate = 1731917159 },
        Characters = new DbdTrickyVersion { Version = "8.3.2", LastUpdate = 1731917510 },
        Customizations = new DbdTrickyVersion { Version = "8.3.2", LastUpdate = 1731917534 },
        Dlc = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555991 },
        Gamemodes = new DbdTrickyVersion { Version = "8.3.2", LastUpdate = 1732005759 },
        Items = new DbdTrickyVersion { Version = "8.3.2", LastUpdate = 1731917505 },
        Journals = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555869 },
        Maps = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555874 },
        Offerings = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728557321 },
        Perks = new DbdTrickyVersion { Version = "8.3.2", LastUpdate = 1731917506 },
        Rift = new DbdTrickyVersion { Version = "8.3.0", LastUpdate = 1728555940 }
    };
}