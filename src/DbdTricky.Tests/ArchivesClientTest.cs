using System.Net;
using DbdTricky.Lib.Archives;
using DbdTricky.Lib.Common;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class ArchivesClientTest
{
    [Test]
    public async Task GetArchives_ShouldReturnArchives()
    {
        var client = TestHttpClientFactory.CreateClient("/archives", ResourceReader.Read("archives.json"));
        var archivesClient = new DbdTrickyArchivesClient(client);
        
        var archives = await archivesClient.GetArchives();
        Assert.That(archives, Is.Not.Null);
        
        var archive = archives["Anniversary2022"];
        Assert.That(archive, Is.Not.Null);
        
        Assert.Multiple(() =>
        {
            Assert.That(archive.Name, Is.EqualTo("TWISTED MASQUERADE"));
            Assert.That(archive.Levels, Has.Count.EqualTo(2));
            
            var level1 = archive.Levels["1"];
            Assert.That(level1, Is.Not.Null);
            Assert.That(level1.Nodes, Has.Count.EqualTo(24));
            Assert.That(level1.Start, Is.EqualTo(1655393400));
            
            var node1 = level1.Nodes[0];
            Assert.That(node1, Is.Not.Null);
            Assert.That(node1.Name, Is.EqualTo("Community: Salvation or Sacrifice"));
            Assert.That(node1.Role, Is.EqualTo(DbdTrickyRole.Shared));
            Assert.That(node1.Objective, Is.EqualTo("Complete a total of <b>10</b> of the following as Survivor or Killer:<ul><li><b>Safely unhook Survivor(s).</b></li><li><b>Hook Survivor(s).</b></li></ul>"));
            Assert.That(node1.Rewards, Has.Count.EqualTo(2));
            Assert.That(node1.Rewards[0].Type, Is.EqualTo("currency"));
            Assert.That(node1.Rewards[0].Id, Is.EqualTo("riftfragments"));
            Assert.That(node1.Rewards[0].Amount, Is.EqualTo(3));
            Assert.That(node1.Rewards[1].Type, Is.EqualTo("currency"));
            Assert.That(node1.Rewards[1].Id, Is.EqualTo("bloodpoints"));
            Assert.That(node1.Rewards[1].Amount, Is.EqualTo(15000));
        });
    }
    
    [Test]
    public async Task GetArchive_ShouldReturnArchive()
    {
        var client = TestHttpClientFactory.CreateClient("/archives?tome=Anniversary2022", ResourceReader.Read("archive.json"));
        var archivesClient = new DbdTrickyArchivesClient(client);

        var archive = await archivesClient.GetArchive("Anniversary2022");
        Assert.That(archive, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(archive.Name, Is.EqualTo("TWISTED MASQUERADE"));
            Assert.That(archive.Levels, Has.Count.EqualTo(2));

            var level1 = archive.Levels["1"];
            Assert.That(level1, Is.Not.Null);
            Assert.That(level1.Nodes, Has.Count.EqualTo(24));
            Assert.That(level1.Start, Is.EqualTo(1655393400));

            var node1 = level1.Nodes[0];
            Assert.That(node1, Is.Not.Null);
            Assert.That(node1.Name, Is.EqualTo("Community: Salvation or Sacrifice"));
            Assert.That(node1.Role, Is.EqualTo(DbdTrickyRole.Shared));
            Assert.That(node1.Objective, Is.EqualTo("Complete a total of <b>10</b> of the following as Survivor or Killer:<ul><li><b>Safely unhook Survivor(s).</b></li><li><b>Hook Survivor(s).</b></li></ul>"));
            Assert.That(node1.Rewards, Has.Count.EqualTo(2));
            Assert.That(node1.Rewards[0].Type, Is.EqualTo("currency"));
            Assert.That(node1.Rewards[0].Id, Is.EqualTo("riftfragments"));
            Assert.That(node1.Rewards[0].Amount, Is.EqualTo(3));
            Assert.That(node1.Rewards[1].Type, Is.EqualTo("currency"));
            Assert.That(node1.Rewards[1].Id, Is.EqualTo("bloodpoints"));
            Assert.That(node1.Rewards[1].Amount, Is.EqualTo(15000));
        });
    }
    
    [Test]
    public async Task GetArchive_WhenArchiveNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/archives?tome=Anniversary2022", statusCode: HttpStatusCode.NotFound);
        var archivesClient = new DbdTrickyArchivesClient(client);

        var archive = await archivesClient.GetArchive("Anniversary2022");
        Assert.That(archive, Is.Null);
    }
}