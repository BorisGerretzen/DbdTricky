using DbdTricky.Lib.GameModes;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class GameModesClientTest
{
    [Test]
    public async Task GetGameModes_ShouldGetGameModes()
    {
        var client = TestHttpClientFactory.CreateClient("/gamemodes", ResourceReader.Read("gamemodes.json"));
        var gameModesClient = new DbdTrickyGameModesClient(client);

        var gameModes = await gameModesClient.GetGameModes();
        Assert.That(gameModes, Is.Not.Null);
        
        var gameMode = gameModes["DreadByDaylight"];
        Assert.Multiple(() =>
        {
            Assert.That(gameMode, Is.Not.Null);
            Assert.That(gameMode.Name, Is.EqualTo("LIGHTS OUT"));
            Assert.That(gameMode.Modifiers, Is.Not.Null);
            Assert.That(gameMode.Modifiers["AllowsItemAddons"], Is.False);
            Assert.That(gameMode.Modifiers["InGameChestCountModifier"], Is.EqualTo(8));
            Assert.That(gameMode.Modifiers["LevelLightingOverride"], Is.EqualTo("DreadMode"));
            Assert.That(gameMode.Modifiers["CanUseActiveSpecialEvent"], Is.True);
            Assert.That(gameMode.Modifiers["AudioGroupState"], Is.EqualTo("DreadByDaylight"));
            Assert.That(gameMode.Modifiers["DisabledInventory"], Is.EquivalentTo(new[] { "Nightmare", "Item_Camper_BrokenKey", "Item_Camper_DullKey", "Item_Camper_Key" }));
            Assert.That(gameMode.Modifiers["IsLimitedTimeExperience"], Is.True);
            Assert.That(gameMode.Modifiers["KeepsItemAfterGame"], Is.False);
            Assert.That(gameMode.Modifiers["DisabledPanelTabs"], Is.EquivalentTo(new[] { "LOADOUT" }));
            Assert.That(gameMode.Modifiers["CanDisableFogOverrides"], Is.True);
            Assert.That(gameMode.Modifiers["AllowsQuestProgression"], Is.True);
            Assert.That(gameMode.Modifiers["DefaultBotSightRange"], Is.EqualTo(1800));
            Assert.That(gameMode.Mutators, Is.Not.Null);
            Assert.That(gameMode.Mutators!["DisableTerrorRadiusAudioGameplayMutator"], Is.EqualTo(0));
            Assert.That(gameMode.Mutators["BP_HideScratchMarksMutator_C"], Is.EqualTo(0));
            Assert.That(gameMode.Mutators["HideHUDGameplayMutator"], Is.EqualTo(0));
            Assert.That(gameMode.Mutators["BP_DarkWorldCosmeticMutator_C"], Is.EqualTo(0));
            Assert.That(gameMode.Mutators["BP_ModifyExitGateIndicatorDurationMutator_C"], Is.EqualTo(4));
            Assert.That(gameMode.Mutators["AddGeneratorProgressionGameplayMutator"], Is.EqualTo(0.05000000074505806));
            Assert.That(gameMode.LimitedTime, Is.EqualTo(1));
        });
    }
}