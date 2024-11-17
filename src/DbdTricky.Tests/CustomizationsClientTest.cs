using System.Net;
using DbdTricky.Lib.Common;
using DbdTricky.Lib.Customizations;

namespace DbdTricky.Tests;

public class CustomizationsClientTest
{
    /**
     * "S30_outfit_009": {
        "type": "outfit",
        "category": null,
        "name": "Supernatural Investigator",
        "description": "He happened upon a journal from the 1950s, written by a navigator whose crew went missing.",
        "collection": "Days Gone By Collection",
        "character": 29,
        "role": null,
        "rarity": "veryrare",
        "outfit": null,
        "items": [
            "S30_Head009",
            "S30_Torso009",
            "S30_Legs009"
        ],
        "image": "UI/Icons/Customization/S30/S30_outfit_009.png"
    },
     */
    [Test]
    public async Task GetCustomizations_ShouldReturnCustomizations()
    {
        var client = TestHttpClientFactory.CreateClient("/customizations", ResourceReader.Read("customizations.json"));
        var customizationsClient = new DbdTrickyCustomizationsClient(client);

        var customizations = await customizationsClient.GetCustomizations();
        Assert.That(customizations, Is.Not.Null);
        
        var customization = customizations["S30_outfit_009"];
        Assert.Multiple(() =>
        {
            Assert.That(customization, Is.Not.Null);
            Assert.That(customization.Type, Is.EqualTo("outfit"));
            Assert.That(customization.Name, Is.EqualTo("Supernatural Investigator"));
            Assert.That(customization.Description, Is.EqualTo("He happened upon a journal from the 1950s, written by a navigator whose crew went missing."));
            Assert.That(customization.Collection, Is.EqualTo("Days Gone By Collection"));
            Assert.That(customization.Character, Is.EqualTo(29));
            Assert.That(customization.Rarity, Is.EqualTo("veryrare"));
            Assert.That(customization.Items, Is.EquivalentTo(new[] { "S30_Head009", "S30_Torso009", "S30_Legs009" }));
            Assert.That(customization.Image, Is.EqualTo("UI/Icons/Customization/S30/S30_outfit_009.png"));
        });
    }

    [Test]
    public async Task GetCustomizations_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/customizations?character=29&type=outfit", ResourceReader.Read("customizations.json"));
        var customizationsClient = new DbdTrickyCustomizationsClient(client);

        var customizations = await customizationsClient.GetCustomizations("29", "outfit");
        Assert.That(customizations, Is.Not.Null);
    }
    
    [Test]
    public async Task GetCustomization_ShouldReturnCustomization()
    {
        var client = TestHttpClientFactory.CreateClient("/customizationinfo?item=ZA_020", ResourceReader.Read("customizationinfo.json"));
        var customizationsClient = new DbdTrickyCustomizationsClient(client);

        var customization = await customizationsClient.GetCustomization("ZA_020");
        Assert.Multiple(() =>
        {
            Assert.That(customization, Is.Not.Null);
            Assert.That(customization.Type, Is.EqualTo("charm"));
            Assert.That(customization.Name, Is.EqualTo("Mangled Unicorn"));
            Assert.That(customization.Description, Is.EqualTo("A carnival prize with a gaping entry wound that bleeds stuffing."));
            Assert.That(customization.Collection, Is.EqualTo("Killer Memorabilia"));
            Assert.That(customization.Role, Is.EqualTo(DbdTrickyRole.Killer));
            Assert.That(customization.Rarity, Is.EqualTo("rare"));
            Assert.That(customization.Image, Is.EqualTo("UI/Icons/Customization/ZA_020.png"));
        });
    }

    [Test]
    public async Task GetCustomization_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/customizationinfo?item=ZA_020", statusCode: HttpStatusCode.NotFound);
        var customizationsClient = new DbdTrickyCustomizationsClient(client);

        var customization = await customizationsClient.GetCustomization("ZA_020");
        Assert.That(customization, Is.Null);
    }
}