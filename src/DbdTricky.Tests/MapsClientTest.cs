using System.Net;
using DbdTricky.Lib.Maps;

namespace DbdTricky.Tests;

public class MapsClientTest
{
    [Test]
    public async Task GetMaps_ShouldReturnMaps()
    {
        var client = TestHttpClientFactory.CreateClient("/maps", ResourceReader.Read("maps.json"));
        var mapsClient = new DbdTrickyMapsClient(client);

        var maps = await mapsClient.GetMaps();
        Assert.That(maps, Is.Not.Null);

        var map = maps["Apl_Level_01"];
        Assert.Multiple(() =>
        {
            Assert.That(map, Is.Not.Null);
            Assert.That(map.Alias, Is.EqualTo("greenvillesquare"));
            Assert.That(map.Realm, Is.EqualTo("Withered Isle"));
            Assert.That(map.Name, Is.EqualTo("Greenville Square"));
            Assert.That(map.Description, Is.Not.Empty);
            Assert.That(map.Dlc, Is.EqualTo("Applepie"));
            Assert.That(map.Image, Is.EqualTo("UI/Icons/Maps/Applepie/iconMap_Apl_Level01.png"));
        });
    }
    
    [Test]
    public async Task GetMap_ShouldReturnMap()
    {
        var client = TestHttpClientFactory.CreateClient("/mapinfo?map=Brl_Temple", ResourceReader.Read("mapinfo.json"));
        var mapsClient = new DbdTrickyMapsClient(client);

        var map = await mapsClient.GetMap("Brl_Temple");
        Assert.That(map, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(map.Alias, Is.EqualTo("templeofpurgation"));
            Assert.That(map.Realm, Is.EqualTo("Red Forest"));
            Assert.That(map.Name, Is.EqualTo("The Temple of Purgation"));
            Assert.That(map.Description, Is.Not.Empty);
            Assert.That(map.Dlc, Is.EqualTo("mali"));
            Assert.That(map.Image, Is.EqualTo("UI/Icons/Maps/Saturn/iconMap_Brl_Temple.png"));
        });
    }
    
    [Test]
    public async Task GetMap_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/mapinfo?map=Unknown", statusCode: HttpStatusCode.NotFound);
        var mapsClient = new DbdTrickyMapsClient(client);

        var map = await mapsClient.GetMap("Unknown");
        Assert.That(map, Is.Null);
    }
}