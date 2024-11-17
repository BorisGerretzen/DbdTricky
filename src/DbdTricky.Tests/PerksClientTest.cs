using System.Net;
using DbdTricky.Lib.Common;
using DbdTricky.Lib.Perks;

namespace DbdTricky.Tests;

public class PerksClientTest
{
    [Test]
    public async Task GetPerks_ShouldReturnPerks()
    {
        var client = TestHttpClientFactory.CreateClient("/perks", ResourceReader.Read("perks.json"));
        var perksClient = new DbdTrickyPerksClient(client);

        var perks = await perksClient.GetPerks();
        Assert.That(perks, Is.Not.Null);
        
        var perk = perks["TrailofTorment"];
        Assert.Multiple(() =>
        {
            Assert.That(perk, Is.Not.Null);
            Assert.That(perk.Categories, Is.EquivalentTo(new[] { "trickery" }));
            Assert.That(perk.Name, Is.EqualTo("Trail of Torment"));
            Assert.That(perk.Description, Is.EqualTo("You guide your victims along a path of pain and punishment.<br><br>After damaging a generator, you become <b>Undetectable</b> until the generator stops regressing.\u00a0During this time, the generator\u2019s yellow aura is revealed to Survivors.<br><br>This effect can only trigger once every {2}\u00a0seconds.<br><br>Undetectable hides the Killer's aura, Terror Radius, and Red Stain."));
            Assert.That(perk.Role, Is.EqualTo(DbdTrickyRole.Killer));
            Assert.That(perk.Character, Is.EqualTo(268435475));
            Assert.That(perk.Tunables.TunablesDictionary, Is.EquivalentTo(new Dictionary<int, string[]>
            {
                { 0, ["16"] },
                { 2, ["60", "45", "30"] }
            }));
            Assert.That(perk.Teachable, Is.EqualTo(35));
            Assert.That(perk.Image, Is.EqualTo("UI/Icons/Perks/Wales/iconPerks_trailOfTorment.png"));
        });
    }
    
    [Test]
    public async Task GetPerks_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/perks?character=268435475", ResourceReader.Read("perks.json"));
        var perksClient = new DbdTrickyPerksClient(client);

        var perks = await perksClient.GetPerks("268435475");
        Assert.That(perks, Is.Not.Null);
    }
    
    [Test]
    public async Task GetPerk_ShouldReturnPerk()
    {
        var client = TestHttpClientFactory.CreateClient("/perkinfo?perk=Adrenaline", ResourceReader.Read("perkinfo.json"));
        var perksClient = new DbdTrickyPerksClient(client);

        var perk = await perksClient.GetPerk("Adrenaline");
        Assert.Multiple(() =>
        {
            Assert.That(perk, Is.Not.Null);
            Assert.That(perk.Categories, Is.EquivalentTo(new[] { "navigation", "adaptation" }));
            Assert.That(perk.Name, Is.EqualTo("Adrenaline"));
            Assert.That(perk.Description, Is.EqualTo("You are fuelled by unexpected energy when on the verge of escape.<br><br>This perk activates when the exit gates are powered.<br><br>Instantly heal one health state if you are injured or in the dying state and sprint at {0}% of your normal running speed for {1} seconds.<br><br>Adrenaline ignores the Exhausted status effect. Causes the <b>Exhausted</b> status effect for {2} seconds.<br><br>Exhausted prevents Survivors from activating exhausting perks."));
            Assert.That(perk.Role, Is.EqualTo(DbdTrickyRole.Survivor));
            Assert.That(perk.Character, Is.EqualTo(1));
            Assert.That(perk.Tunables.TunablesList, Is.EquivalentTo(new List<List<string>>
            {
                new() { "150" },
                new() { "3" },
                new() { "60", "50", "40" }
            }));
            Assert.That(perk.Teachable, Is.EqualTo(40));
            Assert.That(perk.Image, Is.EqualTo("UI/Icons/Perks/iconPerks_adrenaline.png"));
        });
    }
    
    [Test]
    public async Task GetPerk_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/perkinfo?perk=NotFound", statusCode: HttpStatusCode.NotFound);
        var perksClient = new DbdTrickyPerksClient(client);

        var perk = await perksClient.GetPerk("NotFound");
        Assert.That(perk, Is.Null);
    }
    
    [Test]
    public async Task GetRandom_ShouldReturnPerk()
    {
        var client = TestHttpClientFactory.CreateClient("/randomperks", ResourceReader.Read("randomperks.json"));
        var perksClient = new DbdTrickyPerksClient(client);

        var perks = await perksClient.GetRandom();
        Assert.That(perks, Is.Not.Null);
        
        var perk = perks["DecisiveStrike"];
        Assert.Multiple(() =>
        {
            Assert.That(perk, Is.Not.Null);
            Assert.That(perk.Categories, Is.EquivalentTo(new[] { "adaptation" }));
            Assert.That(perk.Name, Is.EqualTo("Decisive Strike"));
            Assert.That(perk.Description, Is.EqualTo("Stab at your aggressor in an attempt to escape.<br><br>After being unhooked or unhooking yourself, <b>Decisive Strike</b> activates for {0} seconds.<br><br>While active, complete a Skill Check when grabbed by the Killer to escape, stunning them for {1} seconds.<li>Succeeding or failing the Skill Check disables <b>Decisive Strike</b>.</li><li>You become the Obsession after stunning the Killer.</li><li>The perk and its effects are disabled if the exit gates are powered.</li><br><br><b>Increases</b> your chance to be the Obsession.<br><br>Taking any Conspicuous Action will deactivate <b>Decisive Strike</b>.<br><br>The Killer can only be <b>obsessed</b> with one Survivor at a time."));
            Assert.That(perk.Role, Is.EqualTo(DbdTrickyRole.Survivor));
            Assert.That(perk.Character, Is.EqualTo(5));
            Assert.That(perk.Tunables.TunablesList, Is.EquivalentTo(new List<List<string>>
            {
                new() { "40", "50", "60" },
                new() { "4" }
            }));
            Assert.That(perk.Teachable, Is.EqualTo(40));
            Assert.That(perk.Image, Is.EqualTo("UI/Icons/Perks/DLC2/iconPerks_decisiveStrike.png"));
        });
        
        perk = perks["Vigil"];
        Assert.Multiple(() =>
        {
            Assert.That(perk, Is.Not.Null);
            Assert.That(perk.Categories, Is.EquivalentTo(new[] { "support" }));
            Assert.That(perk.Name, Is.EqualTo("Vigil"));
            Assert.That(perk.Description, Is.EqualTo("You look over your friends even in dire situations. You and your allies within a {0} meter range recover from the <b>Blindness, Broken, Exhausted, Exposed, Hemorrhage, Hindered, Mangled</b> and <b>Oblivious</b> status effects {1}% faster. Once out of range, this effect persists for {2} seconds."));
            Assert.That(perk.Role, Is.EqualTo(DbdTrickyRole.Survivor));
            Assert.That(perk.Character, Is.EqualTo(11));
            Assert.That(perk.Tunables.TunablesList, Is.EquivalentTo(new List<List<string>>
            {
                new() { "8" },
                new() { "20", "25", "30" },
                new() { "15" }
            }));
            Assert.That(perk.Teachable, Is.EqualTo(40));
            Assert.That(perk.Image, Is.EqualTo("UI/Icons/Perks/England/iconPerks_vigil.png"));
        });
        
        perk = perks["WellMakeIt"];
        Assert.Multiple(() =>
        {
            Assert.That(perk, Is.Not.Null);
            Assert.That(perk.Categories, Is.EquivalentTo(new[] { "safeguard" }));
            Assert.That(perk.Name, Is.EqualTo("We'll make it"));
            Assert.That(perk.Description, Is.EqualTo("Helping others heightens your morale.<br><br>When you rescue a Survivor from a hook, gain a {0}% speed increase while healing others for {1} seconds."));
            Assert.That(perk.Role, Is.EqualTo(DbdTrickyRole.Survivor));
            Assert.That(perk.Character, Is.EqualTo(null));
            Assert.That(perk.Tunables.TunablesList, Is.EquivalentTo(new List<List<string>>
            {
                new() { "100" },
                new() { "30", "60", "90" }
            }));
            Assert.That(perk.Teachable, Is.EqualTo(0));
            Assert.That(perk.Image, Is.EqualTo("UI/Icons/Perks/iconPerks_wellMakeIt.png"));
        });
        
        perk = perks["S37P03"];
        Assert.Multiple(() =>
        {
            Assert.That(perk, Is.Not.Null);
            Assert.That(perk.Categories, Is.EquivalentTo(new[] { "adaptation" }));
            Assert.That(perk.Name, Is.EqualTo("Scavenger"));
            Assert.That(perk.Description, Is.EqualTo("Where others see junk, you see valuable improvised tools.<br><br>While you are holding an empty toolbox, <i>Scavenger</i> activates.<br><br>Succeeding a great skill check while repairing gains {0} token, up to {1}.<br><br>When you reach maximum tokens, lose all tokens and automatically recharge your toolbox to full. Then, your generator repair speed is {2}% slower for {3} seconds.<br><br>This perk grants the ability to rummage through an opened chest once per Trial and will guarantee a basic Toolbox."));
            Assert.That(perk.Role, Is.EqualTo(DbdTrickyRole.Survivor));
            Assert.That(perk.Character, Is.EqualTo(36));
            Assert.That(perk.Tunables.TunablesList, Is.EquivalentTo(new List<List<string>>
            {
                new() { "1" }, 
                new() { "5" }, 
                new() { "50" }, 
                new() { "40", "35", "30" }
            }));
            Assert.That(perk.Teachable, Is.EqualTo(40));
            Assert.That(perk.Image, Is.EqualTo("UI/Icons/Perks/Umbra/IconPerks_scavenger.png"));
        });
    }
    
    [Test]
    public async Task GetRandom_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/randomperks?role=killer", ResourceReader.Read("randomperks.json"));
        var perksClient = new DbdTrickyPerksClient(client);

        var perks = await perksClient.GetRandom(DbdTrickyRole.Killer);
        Assert.That(perks, Is.Not.Null);
    }
}