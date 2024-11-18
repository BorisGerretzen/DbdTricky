using DbdTricky.Lib.KillSwitch;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class KillSwitchClientTest
{
    [Test]
    public async Task GetKillSwitch_ShouldReturnKillSwitch() {
        var client = TestHttpClientFactory.CreateClient("/killswitch", ResourceReader.Read("killswitch.json"));
        var killSwitchClient = new DbdTrickyKillSwitchClient(client);

        var killSwitch = await killSwitchClient.GetKillSwitch();
        Assert.That(killSwitch, Is.Not.Null);
        
        var item = killSwitch[0];
        Assert.Multiple(() =>
        {
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Item, Is.EqualTo("EclipseThemeOffering"));
            Assert.That(item.Type, Is.EqualTo("offering"));
        });
    }
}