using System.Net;
using DbdTricky.Lib.Addons;
using DbdTricky.Lib.Common;
using DbdTricky.Tests.Infrastructure;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace DbdTricky.Tests;

public class AddonsClientTest
{
    [Test]
    public async Task GetAddons_ShouldReturnAddons()
    {
        var client = TestHttpClientFactory.CreateClient("/addons", ResourceReader.Read("addons.json"));
        var addonsClient = new DbdTrickyAddonsClient(client);

        var addons = await addonsClient.GetAddons();
        Assert.That(addons, Is.Not.Null);

        var addon = addons["BP_K35Power_Addon_20"];
        Assert.That(addon, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(addon.Type, Is.EqualTo("poweraddon"));
            Assert.That(addon.ItemType, Is.Null);
            Assert.That(addon.Parents, Has.Count.EqualTo(1));
            Assert.That(addon.Parents[0], Is.EqualTo("Item_Slasher_K35Power"));
            Assert.That(addon.Name, Is.EqualTo("Iridescent OSS Report"));
            Assert.That(addon.Description,
                Is.EqualTo(
                    "The report was redacted to the point of being meaningless. But still, theorists tried to extract meaning from it.<br><br><b>Decreases</b> Teleport cooldown by <b>5 seconds</b>.The Decoy left behind after The Unknown teleports takes <b>10 seconds</b> longer to disappear.When created, the Decoy has the same Terror Radius and Red Stain as The Unknown."));
            Assert.That(addon.Role, Is.EqualTo(DbdTrickyRole.Killer));
            Assert.That(addon.Modifiers, Has.Count.EqualTo(1));
            Assert.That(addon.Modifiers[0].Key, Is.EqualTo("K35.ModifyTeleportCooldownMultiplicative"));
            Assert.That(addon.Modifiers[0].Value, Is.EqualTo(0.800000011920929));
            Assert.That(addon.Bloodweb, Is.EqualTo(1));
            Assert.That(addon.Rarity, Is.EqualTo("ultrarare"));
            Assert.That(addon.Image, Is.EqualTo("UI/Icons/ItemAddons/Applepie/iconAddon_iridescentOSSReport.png"));
        });
    }
    
    [Test]
    public async Task GetAddons_WithFilters_ShouldIncludeQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/addons?role=killer&item_type=flashlight&item=Item_Survivor_Flashlight", ResourceReader.Read("addons.json"));
        var addonsClient = new DbdTrickyAddonsClient(client);

        var addons = await addonsClient.GetAddons(DbdTrickyRole.Killer, "flashlight", "Item_Survivor_Flashlight");
        Assert.That(addons, Is.Not.Null);
    }
    
    [Test]
    public async Task GetAddon_ShouldReturnAddon()
    {
        var client = TestHttpClientFactory.CreateClient("/addoninfo?addon=ADDON_flashlight_lonflifebattery", ResourceReader.Read("addoninfo.json"));
        var addonsClient = new DbdTrickyAddonsClient(client);

        var addon = await addonsClient.GetAddon("ADDON_flashlight_lonflifebattery");
        Assert.That(addon, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(addon.Type, Is.EqualTo("itemaddon"));
            Assert.That(addon.ItemType, Is.EqualTo("flashlight"));
            Assert.That(addon.Parents, Has.Count.EqualTo(0));
            Assert.That(addon.Name, Is.EqualTo("Long Life Battery"));
            Assert.That(addon.Description, Is.EqualTo("A recent model of battery that lasts longer.<br><br>Adds <b>6 seconds</b> of use to the Flashlight."));
            Assert.That(addon.Role, Is.EqualTo(DbdTrickyRole.Survivor));
            Assert.That(addon.Modifiers, Has.Count.EqualTo(1));
            Assert.That(addon.Modifiers[0].Key, Is.EqualTo("ModifyItemMaxCharge"));
            Assert.That(addon.Modifiers[0].Value, Is.EqualTo(6));
            Assert.That(addon.Bloodweb, Is.EqualTo(1));
            Assert.That(addon.Rarity, Is.EqualTo("rare"));
            Assert.That(addon.Image, Is.EqualTo("UI/Icons/ItemAddons/iconAddon_longLifeBattery.png"));
        });
    }
    
    [Test]
    public async Task GetAddon_WhenDoesNotExist_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/addoninfo?addon=test", statusCode: HttpStatusCode.NotFound);
        var addonsClient = new DbdTrickyAddonsClient(client);

        var addon = await addonsClient.GetAddon("test");
        Assert.That(addon, Is.Null);
    }
}