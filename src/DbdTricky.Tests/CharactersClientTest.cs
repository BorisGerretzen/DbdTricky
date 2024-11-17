using System.Net;
using DbdTricky.Lib.Characters;
using DbdTricky.Lib.Common;

namespace DbdTricky.Tests;

public class CharactersClientTest
{
    [Test]
    public async Task GetCharacters_ShouldReturnCharacters()
    {
        var client = TestHttpClientFactory.CreateClient("/characters", ResourceReader.Read("characters.json"));
        var charactersClient = new DbdTrickyCharactersClient(client);
        
        var characters = await charactersClient.GetCharacters(DbdTrickyRole.Killer);
        Assert.That(characters, Is.Not.Null);
        
        var character = characters[268435491];
        Assert.That(character, Is.Not.Null);
        
        Assert.Multiple(() =>
        {
            Assert.That(character.Name, Is.EqualTo("The Lich"));
            Assert.That(character.Role, Is.EqualTo(DbdTrickyRole.Killer));
            Assert.That(character.Difficulty, Is.EqualTo("intermediate"));
            Assert.That(character.Gender, Is.EqualTo("male"));
            Assert.That(character.Height, Is.EqualTo("average"));
            Assert.That(character.Bio, Is.Not.Empty);
            Assert.That(character.Story, Is.Not.Empty);
            Assert.That(character.Tunables, Has.Count.EqualTo(13));
            Assert.Multiple(() =>
            {
                Assert.That(character.Tunables["MaxWalkSpeed"], Is.EqualTo(460));
                Assert.That(character.Tunables["CarryingCamperMaxWalkSpeedPercent"], Is.EqualTo(0.800000011920929));
                Assert.That(character.Tunables["TerrorRadius"], Is.EqualTo(3200));
                Assert.That(character.Tunables["Addon_14_CooldownReductionOnBasicAttackSuccess"], Is.EqualTo(5));
                Assert.That(character.Tunables["Addon_15_SurvivorDistanceFromTreasureChest"], Is.EqualTo(600));
                Assert.That(character.Tunables["Addon_15_EffectLifetime"], Is.EqualTo(3));
                Assert.That(character.Tunables["Addon_16_MangledEffectLifetime"], Is.EqualTo(45));
                Assert.That(character.Tunables["Addon_16_HemorrhageEffectLifetime"], Is.EqualTo(45));
                Assert.That(character.Tunables["Addon_17_UndetectableEffectLifetime"], Is.EqualTo(10));
                Assert.That(character.Tunables["Addon_18_ObliviousEffectLifetime"], Is.EqualTo(15));
                Assert.That(character.Tunables["Addon_18_MinimumGuaranteedMimicSpawnAmount"], Is.EqualTo(2));
                Assert.That(character.Tunables["ScoreEvent_TimeToReceiveBloodpointsAfterActivatingSpell"], Is.EqualTo(15));
            });
            Assert.That(character.Item, Is.Not.Null);
            Assert.That(character.Outfit, Has.Count.EqualTo(3));
            Assert.That(character.Dlc, Is.EqualTo("Churros"));
            Assert.That(character.Image, Is.EqualTo("UI/Icons/CharPortraits/Churros/K36_TheLich_Portrait.png"));
            Assert.That(character.Perks, Is.Not.Null);
            Assert.That(character.Perks.Ids, Has.Count.EqualTo(3));
        });
    }
    
    [Test]
    public async Task GetCharacters_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/characters?role=killer", ResourceReader.Read("characters.json"));
        var charactersClient = new DbdTrickyCharactersClient(client);
        
        var characters = await charactersClient.GetCharacters(DbdTrickyRole.Killer);
        Assert.That(characters, Is.Not.Null);
    }

    [Test]
    public async Task GetCharacter_ShouldReturnCharacter()
    {
        var client = TestHttpClientFactory.CreateClient("/characterinfo?character=268435491&includeperks&includeitem", ResourceReader.Read("characterinfo.json"));
        var charactersClient = new DbdTrickyCharactersClient(client);
        
        var character = await charactersClient.GetCharacter("268435491", true, true);
        Assert.That(character, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(character.Name, Is.EqualTo("The Lich"));
            Assert.That(character.Role, Is.EqualTo(DbdTrickyRole.Killer));
            Assert.That(character.Difficulty, Is.EqualTo("intermediate"));
            Assert.That(character.Gender, Is.EqualTo("male"));
            Assert.That(character.Height, Is.EqualTo("average"));
            Assert.That(character.Bio, Is.Not.Empty);
            Assert.That(character.Story, Is.Not.Empty);
            Assert.That(character.Tunables, Has.Count.EqualTo(13));
            Assert.That(character.Item, Is.Not.Null);
            Assert.That(character.Outfit, Has.Count.EqualTo(3));
            Assert.That(character.Dlc, Is.EqualTo("Churros"));
            Assert.That(character.Image, Is.EqualTo("UI/Icons/CharPortraits/Churros/K36_TheLich_Portrait.png"));
            Assert.That(character.Perks, Is.Not.Null);
            Assert.That(character.Perks.Perks, Has.Count.EqualTo(3));

            Assert.Multiple(() =>
            {
                var perk1 = character.Perks.Perks[0];
                Assert.That(perk1.Name, Is.EqualTo("Weave Attunement"));
                Assert.That(perk1.Description, Is.Not.Empty);
                Assert.That(perk1.Role, Is.EqualTo(DbdTrickyRole.Killer));
                Assert.That(perk1.Tunables.TunablesList, Has.Count.EqualTo(2));
                Assert.That(perk1.Teachable, Is.EqualTo(30));
                Assert.That(perk1.Image, Is.EqualTo("UI/Icons/Perks/Churros/iconPerks_WeaveAttunement.png"));

                var perk2 = character.Perks.Perks[1];
                Assert.That(perk2.Name, Is.EqualTo("Languid Touch"));
                Assert.That(perk2.Description, Is.Not.Empty);
                Assert.That(perk2.Role, Is.EqualTo(DbdTrickyRole.Killer));
                Assert.That(perk2.Tunables.TunablesList, Has.Count.EqualTo(3));
                Assert.That(perk2.Teachable, Is.EqualTo(35));
                Assert.That(perk2.Image, Is.EqualTo("UI/Icons/Perks/Churros/iconPerks_LanguidTouch.png"));

                var perk3 = character.Perks.Perks[2];
                Assert.That(perk3.Name, Is.EqualTo("Dark Arrogance"));
                Assert.That(perk3.Description, Is.Not.Empty);
                Assert.That(perk3.Role, Is.EqualTo(DbdTrickyRole.Killer));
                Assert.That(perk3.Tunables.TunablesList, Has.Count.EqualTo(2));
                Assert.That(perk3.Teachable, Is.EqualTo(40));
                Assert.That(perk3.Image, Is.EqualTo("UI/Icons/Perks/Churros/iconPerks_DarkArrogance.png"));
            });
        });
    }
    
    [Test]
    public async Task GetCharacter_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/characterinfo?character=268435491&includeperks&includeitem", statusCode: HttpStatusCode.NotFound);
        var charactersClient = new DbdTrickyCharactersClient(client);
        
        var character = await charactersClient.GetCharacter("268435491", true, true);
        Assert.That(character, Is.Null);
    }

    [Test]
    public async Task GetRandomCharacter_ShouldReturnCharacter()
    {
        var client = TestHttpClientFactory.CreateClient("/randomcharacter", ResourceReader.Read("characterinfo.json"));
        var charactersClient = new DbdTrickyCharactersClient(client);
        
        var character = await charactersClient.GetRandom();
        Assert.That(character, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(character.Name, Is.EqualTo("The Lich"));
            Assert.That(character.Role, Is.EqualTo(DbdTrickyRole.Killer));
            Assert.That(character.Difficulty, Is.EqualTo("intermediate"));
            Assert.That(character.Gender, Is.EqualTo("male"));
            Assert.That(character.Height, Is.EqualTo("average"));
            Assert.That(character.Bio, Is.Not.Empty);
            Assert.That(character.Story, Is.Not.Empty);
            Assert.That(character.Tunables, Has.Count.EqualTo(13));
            Assert.That(character.Item, Is.Not.Null);
            Assert.That(character.Outfit, Has.Count.EqualTo(3));
            Assert.That(character.Dlc, Is.EqualTo("Churros"));
            Assert.That(character.Image, Is.EqualTo("UI/Icons/CharPortraits/Churros/K36_TheLich_Portrait.png"));
            Assert.That(character.Perks, Is.Not.Null);
            Assert.That(character.Perks.Perks, Has.Count.EqualTo(3));

            Assert.Multiple(() =>
            {
                var perk1 = character.Perks.Perks[0];
                Assert.That(perk1.Name, Is.EqualTo("Weave Attunement"));
                Assert.That(perk1.Description, Is.Not.Empty);
                Assert.That(perk1.Role, Is.EqualTo(DbdTrickyRole.Killer));
                Assert.That(perk1.Tunables.TunablesList, Has.Count.EqualTo(2));
                Assert.That(perk1.Teachable, Is.EqualTo(30));
                Assert.That(perk1.Image, Is.EqualTo("UI/Icons/Perks/Churros/iconPerks_WeaveAttunement.png"));

                var perk2 = character.Perks.Perks[1];
                Assert.That(perk2.Name, Is.EqualTo("Languid Touch"));
                Assert.That(perk2.Description, Is.Not.Empty);
                Assert.That(perk2.Role, Is.EqualTo(DbdTrickyRole.Killer));
                Assert.That(perk2.Tunables.TunablesList, Has.Count.EqualTo(3));
                Assert.That(perk2.Teachable, Is.EqualTo(35));
                Assert.That(perk2.Image, Is.EqualTo("UI/Icons/Perks/Churros/iconPerks_LanguidTouch.png"));

                var perk3 = character.Perks.Perks[2];
                Assert.That(perk3.Name, Is.EqualTo("Dark Arrogance"));
                Assert.That(perk3.Description, Is.Not.Empty);
                Assert.That(perk3.Role, Is.EqualTo(DbdTrickyRole.Killer));
                Assert.That(perk3.Tunables.TunablesList, Has.Count.EqualTo(2));
                Assert.That(perk3.Teachable, Is.EqualTo(40));
                Assert.That(perk3.Image, Is.EqualTo("UI/Icons/Perks/Churros/iconPerks_DarkArrogance.png"));
            });
        });
    }
    
    [Test]
    public async Task GetRandomCharacter_ShouldAddQueryParameters()
    {
        var client = TestHttpClientFactory.CreateClient("/randomcharacter?role=killer&includeperks", ResourceReader.Read("characterinfo.json"));
        var charactersClient = new DbdTrickyCharactersClient(client);

        var character = await charactersClient.GetRandom(DbdTrickyRole.Killer, true);
        Assert.That(character, Is.Not.Null);
    }
}