using DbdTricky.Lib.Common;
using DbdTricky.Lib.Versions;

var configuration = new DbdTrickyConfiguration();
var http = new HttpClient
{
    BaseAddress = new Uri(configuration.BaseUrl),
    DefaultRequestHeaders =
    {
        { "User-Agent", configuration.UserAgent },
    }
};

var versionsClient = new DbdTrickyVersionsClient(http);
var current = await versionsClient.GetVersions();
var lastKnown = DbdTrickyVersions.LastKnown;

var properties = typeof(DbdTrickyVersions).GetProperties();
foreach (var property in properties)
{
    var currentVersion = (DbdTrickyVersion?)property.GetValue(current) ?? throw new InvalidOperationException($"Current version for property {property.Name} is null.");
    var lastKnownVersion = (DbdTrickyVersion?)property.GetValue(lastKnown) ?? throw new InvalidOperationException($"Last known version for property {property.Name} is null.");

    if (currentVersion > lastKnownVersion)
    {
        Console.WriteLine($"New version detected for {property.Name}: {currentVersion.Version} (last known: {lastKnownVersion.Version})");
    }
}

