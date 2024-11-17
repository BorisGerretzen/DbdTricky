using DbdTricky.Lib.PlayerCount;

namespace DbdTricky.Tests;

public class PlayerCountClientTest
{
    [Test]
    public async Task GetPlayerCounts_ShouldReturnPlayerCounts()
    {
        var client = TestHttpClientFactory.CreateClient("/playercount", ResourceReader.Read("playercount.json"));
        var playerCountClient = new DbdTrickyPlayerCountClient(client);

        var playerCounts = await playerCountClient.GetPlayerCounts();
        Assert.That(playerCounts, Is.Not.Null);
        
        var playerCount = playerCounts[0];
        Assert.Multiple(() =>
        {
            Assert.That(playerCount, Is.Not.Null);
            Assert.That(playerCount.PlayerCount, Is.EqualTo(34796));
            Assert.That(playerCount.UpdatedAt, Is.EqualTo(1731837000));
        });
    }
}