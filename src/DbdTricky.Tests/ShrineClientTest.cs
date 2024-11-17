using DbdTricky.Lib.Shrine;

namespace DbdTricky.Tests;

public class ShrineClientTest
{
    [Test]
    public async Task GetShrine_ShouldReturnShrine()
    {
        var client = TestHttpClientFactory.CreateClient("/shrine", ResourceReader.Read("shrine.json"));
        var shrineClient = new DbdTrickyShrineClient(client);

        var shrine = await shrineClient.GetShrine();
        Assert.That(shrine, Is.Not.Null);
        
        Assert.Multiple(() =>
        {
            Assert.That(shrine.Id, Is.EqualTo(247));
            Assert.That(shrine.Perks, Has.Count.EqualTo(4));
            Assert.That(shrine.Perks[0].Id, Is.EqualTo("Coulrophobia"));
            Assert.That(shrine.Perks[0].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[0].Shards, Is.EqualTo(2000));
            Assert.That(shrine.Perks[1].Id, Is.EqualTo("Enduring"));
            Assert.That(shrine.Perks[1].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[1].Shards, Is.EqualTo(2000));
            Assert.That(shrine.Perks[2].Id, Is.EqualTo("S43P01"));
            Assert.That(shrine.Perks[2].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[2].Shards, Is.EqualTo(2000));
            Assert.That(shrine.Perks[3].Id, Is.EqualTo("S43P03"));
            Assert.That(shrine.Perks[3].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[3].Shards, Is.EqualTo(2000));
            Assert.That(shrine.Start, Is.EqualTo(1731423600));
            Assert.That(shrine.End, Is.EqualTo(1732028399));
        });
    }
    
    [Test]
    public async Task GetShrine_WithPerks_ShouldReturnShrine()
    {
        var client = TestHttpClientFactory.CreateClient("/shrine?includeperkinfo=1", ResourceReader.Read("shrine_with_perks.json"));
        var shrineClient = new DbdTrickyShrineClient(client);

        var shrine = await shrineClient.GetShrine(true);
        Assert.That(shrine, Is.Not.Null);
        
        Assert.Multiple(() =>
        {
            Assert.That(shrine.Id, Is.EqualTo(247));
            Assert.That(shrine.Perks, Has.Count.EqualTo(4));
            Assert.That(shrine.Perks[0].Id, Is.EqualTo("coulrophobia"));
            Assert.That(shrine.Perks[0].Name, Is.EqualTo("Coulrophobia"));
            Assert.That(shrine.Perks[0].Description, Is.Not.Empty);
            Assert.That(shrine.Perks[0].Image, Is.EqualTo("UI/Icons/Perks/Guam/iconPerks_coulrophobia.png"));
            Assert.That(shrine.Perks[0].Character, Is.EqualTo("The Clown"));
            Assert.That(shrine.Perks[0].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[0].Shards, Is.EqualTo(2000));
            
            Assert.That(shrine.Perks[1].Id, Is.EqualTo("enduring"));
            Assert.That(shrine.Perks[1].Name, Is.EqualTo("Enduring"));
            Assert.That(shrine.Perks[1].Description, Is.Not.Empty);
            Assert.That(shrine.Perks[1].Image, Is.EqualTo("UI/Icons/Perks/iconPerks_enduring.png"));
            Assert.That(shrine.Perks[1].Character, Is.EqualTo("The Hillbilly"));
            Assert.That(shrine.Perks[1].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[1].Shards, Is.EqualTo(2000));
            
            Assert.That(shrine.Perks[2].Id, Is.EqualTo("s43p01"));
            Assert.That(shrine.Perks[2].Name, Is.EqualTo("Finesse"));
            Assert.That(shrine.Perks[2].Description, Is.Not.Empty);
            Assert.That(shrine.Perks[2].Image, Is.EqualTo("UI/Icons/Perks/Donut/iconPerks_Finesse.png"));
            Assert.That(shrine.Perks[2].Character, Is.EqualTo("Lara Croft"));
            Assert.That(shrine.Perks[2].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[2].Shards, Is.EqualTo(2000));
            
            Assert.That(shrine.Perks[3].Id, Is.EqualTo("s43p03"));
            Assert.That(shrine.Perks[3].Name, Is.EqualTo("Specialist"));
            Assert.That(shrine.Perks[3].Description, Is.Not.Empty);
            Assert.That(shrine.Perks[3].Image, Is.EqualTo("UI/Icons/Perks/Donut/iconPerks_Specialist.png"));
            Assert.That(shrine.Perks[3].Character, Is.EqualTo("Lara Croft"));
            Assert.That(shrine.Perks[3].BloodPoints, Is.EqualTo(100000));
            Assert.That(shrine.Perks[3].Shards, Is.EqualTo(2000));
            
            Assert.That(shrine.Start, Is.EqualTo(1731423600));
            Assert.That(shrine.End, Is.EqualTo(1732028399));
        });
    }
}