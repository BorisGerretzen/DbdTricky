using DbdTricky.Lib.TopStats;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class TopStatsClientTest
{
    [Test]
    public async Task GetTopStats_ShouldReturnTopStats()
    {
        var client = TestHttpClientFactory.CreateClient("/topstats", ResourceReader.Read("topstats.json"));
        var topStatsClient = new DbdTrickyTopStatsClient(client);

        var topStats = await topStatsClient.GetTopStats();
        Assert.That(topStats, Is.Not.Null);
        
        var topStat = topStats[0];
        Assert.Multiple(() =>
        {
            Assert.That(topStat, Is.Not.Null);
            Assert.That(topStat.SteamId, Is.EqualTo(99999999999999999));
            Assert.That(topStat.Persona, Is.EqualTo("User1"));
            Assert.That(topStat.Value, Is.EqualTo(4569287268));
            
            topStat = topStats[1];
            Assert.That(topStat, Is.Not.Null);
            Assert.That(topStat.SteamId, Is.EqualTo(88888888888888888));
            Assert.That(topStat.Persona, Is.EqualTo("User2"));
            Assert.That(topStat.Value, Is.EqualTo(4456982187));
        });
    }
    
    [Test]
    public async Task GetTopStats_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/topstats?stat=escaped", ResourceReader.Read("topstats.json"));
        var topStatsClient = new DbdTrickyTopStatsClient(client);

        var topStats = await topStatsClient.GetTopStats(DbdTrickyTopStats.Escaped);
        Assert.That(topStats, Is.Not.Null);
    }
}