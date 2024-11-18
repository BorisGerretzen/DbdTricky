using System.Net;
using DbdTricky.Lib.Rift;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class RiftClientTest
{
    [Test]
    public async Task GetRifts_ShouldReturnRifts()
    {
        var client = TestHttpClientFactory.CreateClient("/rifts", ResourceReader.Read("rift.json"));
        var riftClient = new DbdTrickyRiftsClient(client);

        var rifts = await riftClient.GetRifts();
        Assert.That(rifts, Is.Not.Null);
        
        var rift = rifts["Tome18"];
        Assert.Multiple(() =>
        {
            Assert.That(rift, Is.Not.Null);
            Assert.That(rift.Tiers, Is.EqualTo(85));
            Assert.That(rift.Free, Is.Not.Null);
            var free = rift.Free["1"].First();
            Assert.That(free, Is.Not.Null);
            Assert.That(free.Amount, Is.EqualTo(100000));
            Assert.That(free.Id, Is.EqualTo("Bloodpoints"));
            Assert.That(free.Type, Is.EqualTo("currency"));
            var premium = rift.Premium["1"].ToList();
            Assert.That(premium, Is.Not.Null);
            Assert.That(premium.Count, Is.EqualTo(3));
            var premiumItem = premium.First();
            Assert.That(premiumItem, Is.Not.Null);
            Assert.That(premiumItem.Amount, Is.EqualTo(1));
            Assert.That(premiumItem.Id, Is.EqualTo("S40_Head010"));
            Assert.That(premiumItem.Type, Is.EqualTo("item"));
            Assert.That(rift.Start, Is.EqualTo(1706716800));
        });
    }

    [Test]
    public async Task GetRift_ShouldReturnRift()
    {
        var client = TestHttpClientFactory.CreateClient("/rifts?tome=Tome01", ResourceReader.Read("rift_single.json"));
        var riftClient = new DbdTrickyRiftsClient(client);

        var rift = await riftClient.GetRift("Tome01");
        Assert.That(rift, Is.Not.Null);
    }
    
    [Test]
    public async Task GetRift_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/rifts?tome=Tome01", statusCode: HttpStatusCode.NotFound);
        var riftClient = new DbdTrickyRiftsClient(client);

        var rift = await riftClient.GetRift("Tome01");
        Assert.That(rift, Is.Null);
    }
}