using System.Net;
using DbdTricky.Lib.Common;
using DbdTricky.Lib.Items;
using DbdTricky.Tests.Infrastructure;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace DbdTricky.Tests;

public class ItemsClientTest
{
    [Test]
    public async Task GetItems_ShouldReturnItems()
    {
        var client = TestHttpClientFactory.CreateClient("/items", ResourceReader.Read("items.json"));
        var itemsClient = new DbdTrickyItemsClient(client);

        var items = await itemsClient.GetItems();
        Assert.That(items, Is.Not.Null);
        
        var item = items["Item_Camper_AlexsToolbox"];
        Assert.Multiple(() =>
        {
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Type, Is.EqualTo("item"));
            Assert.That(item.ItemType, Is.EqualTo("toolbox"));
            Assert.That(item.Name, Is.EqualTo("Alex's Toolbox"));
            Assert.That(item.Description, Is.EqualTo("A metal box containing mainly saws and vice grips of varying sizes but also other tools. Even though the content of this Toolbox is clearly aimed at destructive deeds, it can be used to repair various mechanical components as well.<br><br><b>18 charges</b>.<b>Increases</b> repair speed by <b>10%</b>.Unlocks the <b>sabotage</b> action.<b>Increases</b> sabotage speed by <b>100%</b>.<br><br>Repairing a generator requires <b>90</b> charges.<br><br>Sabotaging a hook requires <b>6</b> charges."));
            Assert.That(item.Role, Is.EqualTo(DbdTrickyRole.Survivor));
            Assert.Multiple(() =>
            {
                var modifiers = item.Modifiers;
                Assert.That(modifiers, Is.Not.Null);
                
                var modifier = modifiers[0];
                Assert.That(modifier, Is.Not.Null);
                Assert.That(modifier.Key, Is.EqualTo("ModifyItemMaxCharge"));
                Assert.That(modifier.Value, Is.EqualTo(24));
                
                modifier = modifiers[1];
                Assert.That(modifier, Is.Not.Null);
                Assert.That(modifier.Conditions, Is.EqualTo("PlayerIsRepairingWithToolbox_C"));
                Assert.That(modifier.Key, Is.EqualTo("ActionSpeed"));
                Assert.That(modifier.Value, Is.EqualTo(0.10000000149011612));
                
                modifier = modifiers[2];
                Assert.That(modifier, Is.Not.Null);
                Assert.That(modifier.Key, Is.EqualTo("ActionSpeed"));
                Assert.That(modifier.Value, Is.EqualTo(0.5));
            });
            Assert.That(item.Bloodweb, Is.EqualTo(1));
            Assert.That(item.Event, Is.Null);
            Assert.That(item.Rarity, Is.EqualTo("veryrare"));
            Assert.That(item.Image, Is.EqualTo("UI/Icons/Items/iconItems_toolboxAlexs.png"));
        });
    }
    
    [Test]
    public async Task GetItems_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/items?role=killer&type=power&itemtype=trap", ResourceReader.Read("items.json"));
        var itemsClient = new DbdTrickyItemsClient(client);

        var items = await itemsClient.GetItems(DbdTrickyRole.Killer, "power", "trap");
        Assert.That(items, Is.Not.Null);
    }

    [Test]
    [Ignore("Might have found bug in dbdtricky where modifiers is string encoded json")]
    public async Task GetItem_ShouldReturnItem()
    {
        var client = TestHttpClientFactory.CreateClient("/iteminfo?item=Item_Slasher_TormentMode&includeaddons", ResourceReader.Read("iteminfo.json"));
        var itemsClient = new DbdTrickyItemsClient(client);

        var item = await itemsClient.GetItem("Item_Slasher_TormentMode", true);
        Assert.Multiple(() =>
        {
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Type, Is.EqualTo("power"));
            Assert.That(item.ItemType, Is.Null);
            Assert.That(item.Name, Is.EqualTo("Rites of Judgment"));
            Assert.That(item.Description, Is.Not.Empty);
            Assert.That(item.Role, Is.EqualTo(DbdTrickyRole.Killer));
            Assert.That(item.Modifiers, Is.Null);
            Assert.That(item.Bloodweb, Is.EqualTo(0));
            Assert.That(item.Event, Is.Null);
            Assert.That(item.Rarity, Is.EqualTo("common"));
            Assert.That(item.Image, Is.EqualTo("UI/Icons/Powers/Wales/iconPowers_Wales_ritesOfJudgement"));
            Assert.Multiple(() =>
            {
                var addons = item.Addons;
                Assert.That(addons, Is.Not.Null);

                var addon = addons["ADDON_TormentMode_BlackStrap"];
                Assert.That(addon, Is.Not.Null);
                Assert.That(addon.Type, Is.EqualTo("poweraddon"));
                Assert.That(addon.ItemType, Is.Null);
                Assert.That(addon.Name, Is.EqualTo("Black Strap"));
                Assert.That(addon.Description, Is.Not.Empty);
                Assert.That(addon.Role, Is.EqualTo(DbdTrickyRole.Killer));
                Assert.That(addon.Modifiers, Is.Not.Null);
                Assert.That(addon.Bloodweb, Is.EqualTo(1));
                Assert.That(addon.Rarity, Is.EqualTo("common"));
                Assert.That(addon.Image, Is.EqualTo("UI/Icons/ItemAddons/Wales/iconAddon_blackStrap"));
            });
        });
    }
    
    [Test]
    public async Task GetItem_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/iteminfo?item=Item_Slasher_TormentMode", statusCode: HttpStatusCode.NotFound);
        var itemsClient = new DbdTrickyItemsClient(client);

        var item = await itemsClient.GetItem("Item_Slasher_TormentMode");
        Assert.That(item, Is.Null);
    }
}