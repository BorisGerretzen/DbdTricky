using System.Net;
using DbdTricky.Lib.Common;
using DbdTricky.Lib.Offerings;
using DbdTricky.Tests.Infrastructure;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace DbdTricky.Tests;

public class OfferingsClientTest
{
    [Test]
    public async Task GetOfferings_ShouldReturnOfferings()
    {
        var client = TestHttpClientFactory.CreateClient("/offerings", ResourceReader.Read("offerings.json"));
        var offeringsClient = new DbdTrickyOfferingsClient(client);

        var offerings = await offeringsClient.GetOfferings();
        Assert.That(offerings, Is.Not.Null);
        
        var offering = offerings["Anniversary2024Offering"];
        Assert.Multiple(() =>
        {
            Assert.That(offering, Is.Not.Null);
            Assert.That(offering.Type, Is.EqualTo("points"));
            Assert.That(offering.Tags, Is.EquivalentTo(new[] { "notavailableinpartymode", "stack" }));
            Assert.That(offering.Name, Is.EqualTo("SCREECH COBBLER"));
            Assert.That(offering.Description, Is.EqualTo("If you listen really closely, you can almost hear it screaming for more ice cream.<br><br>Grants <b>108%</b> bonus Bloodpoints in all categories for all players this trial.Reveals the aura of Invitation within <b>16 meters.</b>Create <b>1</b> more chest."));
            Assert.That(offering.Rarity, Is.EqualTo("specialevent"));
            Assert.That(offering.Retired, Is.EqualTo(0));
            Assert.That(offering.Image, Is.EqualTo("UI/Icons/Favors/Anniversary/iconsFavors_8thAnniversary.png"));
        });
    }
    
    [Test]
    public async Task GetOfferings_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/offerings?role=killer", ResourceReader.Read("offerings.json"));
        var offeringsClient = new DbdTrickyOfferingsClient(client);

        var offerings = await offeringsClient.GetOfferings(DbdTrickyRole.Killer);
        Assert.That(offerings, Is.Not.Null);
    }
    
    [Test]
    public async Task GetOffering_ShouldReturnOffering()
    {
        var client = TestHttpClientFactory.CreateClient("/offeringinfo?offering=BloodyPartyStreamers", ResourceReader.Read("offeringinfo.json"));
        var offeringsClient = new DbdTrickyOfferingsClient(client);

        var offering = await offeringsClient.GetOffering("BloodyPartyStreamers");
        Assert.Multiple(() =>
        {
            Assert.That(offering, Is.Not.Null);
            Assert.That(offering.Type, Is.EqualTo("points"));
            Assert.That(offering.Tags, Is.EquivalentTo(new[] { "stack", "notavailableinpartymode" }));
            Assert.That(offering.Name, Is.EqualTo("Bloody Party Streamers"));
            Assert.That(offering.Description, Is.EqualTo("Grants <b>100%</b> bonus Bloodpoints in all categories for all players this trial."));
            Assert.That(offering.Rarity, Is.EqualTo("rare"));
            Assert.That(offering.Retired, Is.EqualTo(0));
            Assert.That(offering.Image, Is.EqualTo("UI/Icons/Favors/Anniversary/iconFavors_bloodyPartyStreamers.png"));
        });
    }
    
    [Test]
    public async Task GetOffering_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/offeringinfo?offering=BloodyPartyStreamers", statusCode: HttpStatusCode.NotFound);
        var offeringsClient = new DbdTrickyOfferingsClient(client);

        var offering = await offeringsClient.GetOffering("BloodyPartyStreamers");
        Assert.That(offering, Is.Null);
    }
}