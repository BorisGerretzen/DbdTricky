using DbdTricky.Lib.Versions;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class VersionClientTest
{
    [Test]
    public async Task GetVersions_ShouldReturnVersions()
    {
        var client = TestHttpClientFactory.CreateClient("/versions", ResourceReader.Read("versions.json"));
        var versionsClient = new DbdTrickyVersionsClient(client);

        var versions = await versionsClient.GetVersions();
        Assert.That(versions, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(versions.Addons.Version, Is.EqualTo("8.3.2"));
            Assert.That(versions.Addons.LastUpdate, Is.EqualTo(1731917505));
            
            Assert.That(versions.Archives.Version, Is.EqualTo("8.3.2"));
            Assert.That(versions.Archives.LastUpdate, Is.EqualTo(1731917159));
            
            Assert.That(versions.Characters.Version, Is.EqualTo("8.3.2"));
            Assert.That(versions.Characters.LastUpdate, Is.EqualTo(1731917510));
            
            Assert.That(versions.Customizations.Version, Is.EqualTo("8.3.2"));
            Assert.That(versions.Customizations.LastUpdate, Is.EqualTo(1731917534));
            
            Assert.That(versions.Dlc.Version, Is.EqualTo("8.3.0"));
            Assert.That(versions.Dlc.LastUpdate, Is.EqualTo(1728555991));
            
            Assert.That(versions.Gamemodes.Version, Is.EqualTo("8.3.0"));
            Assert.That(versions.Gamemodes.LastUpdate, Is.EqualTo(1728555849));
            
            Assert.That(versions.Items.Version, Is.EqualTo("8.3.2"));
            Assert.That(versions.Items.LastUpdate, Is.EqualTo(1731917505));
            
            Assert.That(versions.Journals.Version, Is.EqualTo("8.3.0"));
            Assert.That(versions.Journals.LastUpdate, Is.EqualTo(1728555869));
            
            Assert.That(versions.Maps.Version, Is.EqualTo("8.3.0"));
            Assert.That(versions.Maps.LastUpdate, Is.EqualTo(1728555874));
            
            Assert.That(versions.Offerings.Version, Is.EqualTo("8.3.0"));
            Assert.That(versions.Offerings.LastUpdate, Is.EqualTo(1728557321));
            
            Assert.That(versions.Perks.Version, Is.EqualTo("8.3.2"));
            Assert.That(versions.Perks.LastUpdate, Is.EqualTo(1731917506));
            
            Assert.That(versions.Rift.Version, Is.EqualTo("8.3.0"));
            Assert.That(versions.Rift.LastUpdate, Is.EqualTo(1728555940));
        });
    }
}