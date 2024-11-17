using DbdTricky.Lib.RankReset;

namespace DbdTricky.Tests;

public class RankResetClientTest
{
    [Test]
    public async Task GetRankReset_ShouldReturnRankReset()
    {
        var client = TestHttpClientFactory.CreateClient("/rankreset", ResourceReader.Read("rankreset.json"));
        var rankResetClient = new DbdTrickyRankResetClient(client);

        var rankReset = await rankResetClient.GetRankReset();
        Assert.That(rankReset, Is.Not.Null);
        
        Assert.That(rankReset.RankReset, Is.EqualTo(1734076800));
    }
}