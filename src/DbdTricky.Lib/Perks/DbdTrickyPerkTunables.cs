namespace DbdTricky.Lib.Perks;

public class DbdTrickyPerkTunables
{
    public Dictionary<int, List<string>>? TunablesDictionary { get; }
    public List<List<string>>? TunablesList { get; }
    
    public DbdTrickyPerkTunables(Dictionary<int, List<string>>? tunablesDictionary)
    {
        TunablesDictionary = tunablesDictionary;
    }

    public DbdTrickyPerkTunables(List<List<string>>? tunablesList)
    {
        TunablesList = tunablesList;
    }
}