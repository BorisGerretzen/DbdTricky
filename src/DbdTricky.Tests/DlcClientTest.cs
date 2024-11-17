using DbdTricky.Lib.Dlc;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class DlcClientTest
{
    [Test]
    public async Task GetDlcs_ShouldReturnDlcs()
    {
        var client = TestHttpClientFactory.CreateClient("/dlc", ResourceReader.Read("dlc.json"));
        var dlcClient = new DbdTrickyDlcClient(client);

        var dlcs = await dlcClient.GetDlcs();
        Assert.That(dlcs, Is.Not.Null);
        
        var dlc = dlcs["halloween"];
        Assert.Multiple(() =>
        {
            Assert.That(dlc, Is.Not.Null);
            Assert.That(dlc.Name, Is.EqualTo("The Halloween® Chapter"));
            Assert.That(dlc.Description, Is.Not.Empty);
            Assert.That(dlc.SteamId, Is.EqualTo(530711));
            Assert.That(dlc.Time, Is.EqualTo(1477314000));
        });
    }
}