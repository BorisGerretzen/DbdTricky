using System.Net;
using DbdTricky.Lib.Common;
using DbdTricky.Lib.Player;
using DbdTricky.Tests.Infrastructure;

namespace DbdTricky.Tests;

public class PlayerClientTest
{
    private const long SteamId = 99999999999999999;
    
    [Test]
    public async Task GetLeaderBoardStat_ShouldReturn()
    {
        var client = TestHttpClientFactory.CreateClient("/leaderboardposition?steamid=99999999999999999&stat=banstate", ResourceReader.Read("leaderboardposition.json"));
        var playerClient = new DbdTrickyPlayerClient(client);
        
        var stat = await playerClient.GetLeaderBoardStat(SteamId, DbdTrickyStat.Banstate);
        Assert.That(stat, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(stat.Stat, Is.EqualTo("bloodpoints"));
            Assert.That(stat.Value, Is.EqualTo(4569287268));
            Assert.That(stat.Position, Is.EqualTo(1));
            Assert.That(stat.UpdatedAt, Is.EqualTo(1731832503));
        });
    }
    
    [Test]
    public async Task GetLeaderBoardStat_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/leaderboardposition?steamid=99999999999999999", statusCode: HttpStatusCode.NotFound);
        var playerClient = new DbdTrickyPlayerClient(client);
        
        var stat = await playerClient.GetLeaderBoardStat(SteamId);
        Assert.That(stat, Is.Null);
    }

    [Test]
    public async Task GetAdepts_ShouldReturn()
    {
        var client = TestHttpClientFactory.CreateClient("/playeradepts?steamid=99999999999999999", ResourceReader.Read("playeradepts.json"));
        var playerClient = new DbdTrickyPlayerClient(client);
        
        var adepts = await playerClient.GetAdepts(SteamId);
        Assert.That(adepts, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(adepts.DwightCount, Is.EqualTo(1));
            Assert.That(adepts.DwightTime, Is.EqualTo(1501827441));
            Assert.That(adepts.MegCount, Is.EqualTo(1));
            Assert.That(adepts.MegTime, Is.EqualTo(1494608830));
            Assert.That(adepts.ClaudetteCount, Is.EqualTo(1));
            Assert.That(adepts.ClaudetteTime, Is.EqualTo(1499718884));
            Assert.That(adepts.JakeCount, Is.EqualTo(1));
            Assert.That(adepts.JakeTime, Is.EqualTo(1501026816));
            Assert.That(adepts.NeaCount, Is.EqualTo(1));
            Assert.That(adepts.NeaTime, Is.EqualTo(1538561778));
            Assert.That(adepts.LaurieCount, Is.EqualTo(1));
            Assert.That(adepts.LaurieTime, Is.EqualTo(1538565095));
            Assert.That(adepts.AceCount, Is.EqualTo(1));
            Assert.That(adepts.AceTime, Is.EqualTo(1538567234));
            Assert.That(adepts.BillCount, Is.EqualTo(1));
            Assert.That(adepts.BillTime, Is.EqualTo(1538584922));
            Assert.That(adepts.FengCount, Is.EqualTo(1));
            Assert.That(adepts.FengTime, Is.EqualTo(1538562706));
            Assert.That(adepts.DavidCount, Is.EqualTo(1));
            Assert.That(adepts.DavidTime, Is.EqualTo(1538563949));
            Assert.That(adepts.KateCount, Is.EqualTo(1));
            Assert.That(adepts.KateTime, Is.EqualTo(1538583843));
            Assert.That(adepts.QuentinCount, Is.EqualTo(1));
            Assert.That(adepts.QuentinTime, Is.EqualTo(1538568250));
            Assert.That(adepts.TappCount, Is.EqualTo(1));
            Assert.That(adepts.TappTime, Is.EqualTo(1538586594));
            Assert.That(adepts.AdamCount, Is.EqualTo(1));
            Assert.That(adepts.AdamTime, Is.EqualTo(1538570356));
            Assert.That(adepts.JeffCount, Is.EqualTo(1));
            Assert.That(adepts.JeffTime, Is.EqualTo(1547888579));
            Assert.That(adepts.JaneCount, Is.EqualTo(1));
            Assert.That(adepts.JaneTime, Is.EqualTo(1576154564));
            Assert.That(adepts.AshCount, Is.EqualTo(1));
            Assert.That(adepts.AshTime, Is.EqualTo(1576147170));
            Assert.That(adepts.NancyCount, Is.EqualTo(1));
            Assert.That(adepts.NancyTime, Is.EqualTo(1576146227));
            Assert.That(adepts.SteveCount, Is.EqualTo(1));
            Assert.That(adepts.SteveTime, Is.EqualTo(1576145587));
            Assert.That(adepts.YuiCount, Is.EqualTo(1));
            Assert.That(adepts.YuiTime, Is.EqualTo(1576145019));
            Assert.That(adepts.ZarinaCount, Is.EqualTo(1));
            Assert.That(adepts.ZarinaTime, Is.EqualTo(1593880899));
            Assert.That(adepts.CherylCount, Is.EqualTo(1));
            Assert.That(adepts.CherylTime, Is.EqualTo(1593880115));
            Assert.That(adepts.FelixCount, Is.EqualTo(1));
            Assert.That(adepts.FelixTime, Is.EqualTo(1599585528));
            Assert.That(adepts.ElodieCount, Is.EqualTo(1));
            Assert.That(adepts.ElodieTime, Is.EqualTo(1606859792));
            Assert.That(adepts.YunjinCount, Is.EqualTo(1));
            Assert.That(adepts.YunjinTime, Is.EqualTo(1617672794));
            Assert.That(adepts.JillCount, Is.EqualTo(1));
            Assert.That(adepts.JillTime, Is.EqualTo(1624056522));
            Assert.That(adepts.LeonCount, Is.EqualTo(1));
            Assert.That(adepts.LeonTime, Is.EqualTo(1623956151));
            Assert.That(adepts.MikaelaCount, Is.EqualTo(1));
            Assert.That(adepts.MikaelaTime, Is.EqualTo(1635555283));
            Assert.That(adepts.JonahCount, Is.EqualTo(1));
            Assert.That(adepts.JonahTime, Is.EqualTo(1638470153));
            Assert.That(adepts.YoichiCount, Is.EqualTo(1));
            Assert.That(adepts.YoichiTime, Is.EqualTo(1646863758));
            Assert.That(adepts.HaddieCount, Is.EqualTo(1));
            Assert.That(adepts.HaddieTime, Is.EqualTo(1654811004));
            Assert.That(adepts.AdaCount, Is.EqualTo(1));
            Assert.That(adepts.AdaTime, Is.EqualTo(1661925103));
            Assert.That(adepts.RebeccaCount, Is.EqualTo(2));
            Assert.That(adepts.RebeccaTime, Is.EqualTo(1661928581));
            Assert.That(adepts.VittorioCount, Is.EqualTo(1));
            Assert.That(adepts.VittorioTime, Is.EqualTo(1669187944));
            Assert.That(adepts.ThalitaCount, Is.EqualTo(1));
            Assert.That(adepts.ThalitaTime, Is.EqualTo(1678210873));
            Assert.That(adepts.RenatoCount, Is.EqualTo(1));
            Assert.That(adepts.RenatoTime, Is.EqualTo(1678211985));
            Assert.That(adepts.GabrielCount, Is.EqualTo(1));
            Assert.That(adepts.GabrielTime, Is.EqualTo(1686678158));
            Assert.That(adepts.NicCount, Is.EqualTo(1));
            Assert.That(adepts.NicTime, Is.EqualTo(1690306826));
            Assert.That(adepts.EllenCount, Is.EqualTo(1));
            Assert.That(adepts.EllenTime, Is.EqualTo(1693340251));
            Assert.That(adepts.AlanCount, Is.EqualTo(1));
            Assert.That(adepts.AlanTime, Is.EqualTo(1706648819));
            Assert.That(adepts.SableCount, Is.EqualTo(1));
            Assert.That(adepts.SableTime, Is.EqualTo(1710350098));
            Assert.That(adepts.AestriCount, Is.EqualTo(1));
            Assert.That(adepts.AestriTime, Is.EqualTo(1717440401));
            Assert.That(adepts.LaraCount, Is.EqualTo(1));
            Assert.That(adepts.LaraTime, Is.EqualTo(1721151453));
            Assert.That(adepts.TrevorCount, Is.EqualTo(1));
            Assert.That(adepts.TrevorTime, Is.EqualTo(1724785894));
            Assert.That(adepts.TrapperCount, Is.EqualTo(1));
            Assert.That(adepts.TrapperTime, Is.EqualTo(1505031901));
            Assert.That(adepts.WraithCount, Is.EqualTo(1));
            Assert.That(adepts.WraithTime, Is.EqualTo(1494640699));
            Assert.That(adepts.BillyCount, Is.EqualTo(1));
            Assert.That(adepts.BillyTime, Is.EqualTo(1504403922));
            Assert.That(adepts.NurseCount, Is.EqualTo(1));
            Assert.That(adepts.NurseTime, Is.EqualTo(1538601679));
            Assert.That(adepts.HagCount, Is.EqualTo(1));
            Assert.That(adepts.HagTime, Is.EqualTo(1538690782));
            Assert.That(adepts.MyersCount, Is.EqualTo(3));
            Assert.That(adepts.MyersTime, Is.EqualTo(1500404357));
            Assert.That(adepts.DoctorCount, Is.EqualTo(1));
            Assert.That(adepts.DoctorTime, Is.EqualTo(1538651518));
            Assert.That(adepts.HuntressCount, Is.EqualTo(2));
            Assert.That(adepts.HuntressTime, Is.EqualTo(1538571772));
            Assert.That(adepts.TumtumsCount, Is.EqualTo(1));
            Assert.That(adepts.TumtumsTime, Is.EqualTo(1538650283));
            Assert.That(adepts.FreddyCount, Is.EqualTo(1));
            Assert.That(adepts.FreddyTime, Is.EqualTo(1538658432));
            Assert.That(adepts.PigCount, Is.EqualTo(1));
            Assert.That(adepts.PigTime, Is.EqualTo(1538594880));
            Assert.That(adepts.ClownCount, Is.EqualTo(1));
            Assert.That(adepts.ClownTime, Is.EqualTo(1538675165));
            Assert.That(adepts.SpiritCount, Is.EqualTo(1));
            Assert.That(adepts.SpiritTime, Is.EqualTo(1538656169));
            Assert.That(adepts.LegionCount, Is.EqualTo(1));
            Assert.That(adepts.LegionTime, Is.EqualTo(1595293923));
            Assert.That(adepts.PlagueCount, Is.EqualTo(2));
            Assert.That(adepts.PlagueTime, Is.EqualTo(1604212527));
            Assert.That(adepts.GhostfaceCount, Is.EqualTo(1));
            Assert.That(adepts.GhostfaceTime, Is.EqualTo(1595038676));
            Assert.That(adepts.DemogorgonCount, Is.EqualTo(1));
            Assert.That(adepts.DemogorgonTime, Is.EqualTo(1604219639));
            Assert.That(adepts.OniCount, Is.EqualTo(1));
            Assert.That(adepts.OniTime, Is.EqualTo(1604222505));
            Assert.That(adepts.DeathslingerCount, Is.EqualTo(1));
            Assert.That(adepts.DeathslingerTime, Is.EqualTo(1604217745));
            Assert.That(adepts.ExecutionerCount, Is.EqualTo(1));
            Assert.That(adepts.ExecutionerTime, Is.EqualTo(1604208713));
            Assert.That(adepts.BlightCount, Is.EqualTo(1));
            Assert.That(adepts.BlightTime, Is.EqualTo(1604224834));
            Assert.That(adepts.TwinsCount, Is.EqualTo(1));
            Assert.That(adepts.TwinsTime, Is.EqualTo(1608328598));
            Assert.That(adepts.TricksterCount, Is.EqualTo(1));
            Assert.That(adepts.TricksterTime, Is.EqualTo(1618580772));
            Assert.That(adepts.NemesisCount, Is.EqualTo(1));
            Assert.That(adepts.NemesisTime, Is.EqualTo(1628627755));
            Assert.That(adepts.CenobiteCount, Is.EqualTo(1));
            Assert.That(adepts.CenobiteTime, Is.EqualTo(1631040299));
            Assert.That(adepts.ArtistCount, Is.EqualTo(1));
            Assert.That(adepts.ArtistTime, Is.EqualTo(1640910061));
            Assert.That(adepts.OnryoCount, Is.EqualTo(1));
            Assert.That(adepts.OnryoTime, Is.EqualTo(1646879803));
            Assert.That(adepts.DredgeCount, Is.EqualTo(1));
            Assert.That(adepts.DredgeTime, Is.EqualTo(1654652813));
            Assert.That(adepts.MastermindCount, Is.EqualTo(1));
            Assert.That(adepts.MastermindTime, Is.EqualTo(1662037197));
            Assert.That(adepts.KnightCount, Is.EqualTo(1));
            Assert.That(adepts.KnightTime, Is.EqualTo(1669431489));
            Assert.That(adepts.SkullmerchantCount, Is.EqualTo(1));
            Assert.That(adepts.SkullmerchantTime, Is.EqualTo(1678252478));
            Assert.That(adepts.SingularityCount, Is.EqualTo(1));
            Assert.That(adepts.SingularityTime, Is.EqualTo(1686938735));
            Assert.That(adepts.XenomorphCount, Is.EqualTo(1));
            Assert.That(adepts.XenomorphTime, Is.EqualTo(1693355563));
            Assert.That(adepts.GoodguyCount, Is.EqualTo(1));
            Assert.That(adepts.GoodguyTime, Is.EqualTo(1701215889));
            Assert.That(adepts.UnknownCount, Is.EqualTo(1));
            Assert.That(adepts.UnknownTime, Is.EqualTo(1710263412));
            Assert.That(adepts.LichCount, Is.EqualTo(1));
            Assert.That(adepts.LichTime, Is.EqualTo(1717445828));
            Assert.That(adepts.DarklordCount, Is.EqualTo(1));
            Assert.That(adepts.DarklordTime, Is.EqualTo(1724777449));
            Assert.That(adepts.UpdatedAt, Is.EqualTo(1731832503));
            Assert.That(adepts.CreatedAt, Is.EqualTo(0));
        });
    }
    
    [Test]
    public async Task GetAdepts_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/playeradepts?steamid=99999999999999999", statusCode: HttpStatusCode.NotFound);
        var playerClient = new DbdTrickyPlayerClient(client);
        
        var adepts = await playerClient.GetAdepts(SteamId);
        Assert.That(adepts, Is.Null);
    }

    [Test]
    public async Task GetStats_ShouldReturn()
    {
        var client = TestHttpClientFactory.CreateClient("/playerstats?steamid=99999999999999999", ResourceReader.Read("playerstats.json"));
        var playerClient = new DbdTrickyPlayerClient(client);
        
        var stats = await playerClient.GetStats(SteamId);
        Assert.That(stats, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(stats.SteamId, Is.EqualTo(SteamId));
            Assert.That(stats.Bloodpoints, Is.EqualTo(4569287268));
            Assert.That(stats.SurvivorRank, Is.EqualTo(10));
            Assert.That(stats.SurvivorFullLoadout, Is.EqualTo(38491));
            Assert.That(stats.SurvivorPerfectGames, Is.EqualTo(5489));
            Assert.That(stats.SurvivorUltraRare, Is.EqualTo(12532));
            Assert.That(stats.GensRepaired, Is.EqualTo(85556));
            Assert.That(stats.DamagedGensRepaired, Is.EqualTo(38807));
            Assert.That(stats.SurvivorsHealed, Is.EqualTo(50454));
            Assert.That(stats.SurvivorsHealedWhileInjured, Is.EqualTo(12577));
            Assert.That(stats.SkillChecks, Is.EqualTo(656320));
            Assert.That(stats.SkillChecksInjured, Is.EqualTo(6758));
            Assert.That(stats.Saved, Is.EqualTo(72007));
            Assert.That(stats.SavedEndgame, Is.EqualTo(7154));
            Assert.That(stats.Escaped, Is.EqualTo(25948));
            Assert.That(stats.EscapedKo, Is.EqualTo(1678));
            Assert.That(stats.HookedEscape, Is.EqualTo(602));
            Assert.That(stats.EscapedHatch, Is.EqualTo(3078));
            Assert.That(stats.EscapedHatchCrawling, Is.EqualTo(216));
            Assert.That(stats.EscapedAllHatch, Is.EqualTo(173));
            Assert.That(stats.EscapedDownedOnce, Is.EqualTo(11551));
            Assert.That(stats.EscapedInjuredHalfOfTrail, Is.EqualTo(3935));
            Assert.That(stats.EscapedNoBloodLossObsession, Is.EqualTo(69));
            Assert.That(stats.EscapedLastGenLastSurvivor, Is.EqualTo(56));
            Assert.That(stats.EscapedNewItem, Is.EqualTo(4685));
            Assert.That(stats.EscapedWithItemFrom, Is.EqualTo(801));
            Assert.That(stats.EscapedBroken, Is.EqualTo(5));
            Assert.That(stats.ProtectionHitsUnhooked, Is.EqualTo(12271));
            Assert.That(stats.ProtectionHitsWhileCarried, Is.EqualTo(2713));
            Assert.That(stats.HealedDyingToInjured, Is.EqualTo(7778));
            Assert.That(stats.ObsessionsHealed, Is.EqualTo(9010));
            Assert.That(stats.ItemsDepleted, Is.EqualTo(17276));
            Assert.That(stats.SurvivorsHealedThreeNotHealthy, Is.EqualTo(11987));
            Assert.That(stats.SurvivorsHealedFoundYou, Is.EqualTo(2320));
            Assert.That(stats.KillerStunnedPalletCarrying, Is.EqualTo(2066));
            Assert.That(stats.KillerStunnedHoldingItem, Is.EqualTo(1161));
            Assert.That(stats.GensRepairedNoPerks, Is.EqualTo(144));
            Assert.That(stats.EscapedChasePalletStun, Is.EqualTo(14312));
            Assert.That(stats.EscapedChaseHealthyInjured, Is.EqualTo(28709));
            Assert.That(stats.EscapedChaseHidingInLocker, Is.EqualTo(1084));
            Assert.That(stats.DodgedAttack, Is.EqualTo(78410));
            Assert.That(stats.KillersAuraRevealed, Is.EqualTo(11363));
            Assert.That(stats.SurvivorsHealedBasement, Is.EqualTo(117));
            Assert.That(stats.KillerBlindedFlashlight, Is.EqualTo(1745));
            Assert.That(stats.VaultsInChase, Is.EqualTo(102043));
            Assert.That(stats.VaultsInChaseMissed, Is.EqualTo(8509));
            Assert.That(stats.WiggledFromKillersGrasp, Is.EqualTo(895));
            Assert.That(stats.HexTotemsCleansed, Is.EqualTo(5752));
            Assert.That(stats.HexTotemsBlessed, Is.EqualTo(46));
            Assert.That(stats.BlessedTotemBoosts, Is.EqualTo(69457));
            Assert.That(stats.ExitGatesOpened, Is.EqualTo(12316));
            Assert.That(stats.UnhookedSelf, Is.EqualTo(912));
            Assert.That(stats.HooksSabotaged, Is.EqualTo(3713));
            Assert.That(stats.ChestsSearched, Is.EqualTo(13671));
            Assert.That(stats.ChestsSearchedBasement, Is.EqualTo(1642));
            Assert.That(stats.MysteryBoxesOpened, Is.EqualTo(39116));
            Assert.That(stats.Screams, Is.EqualTo(5680));
            Assert.That(stats.UnhookedSafelyWhileBroken, Is.EqualTo(13));
            Assert.That(stats.SecondFloorGenDisturbedWard, Is.EqualTo(184));
            Assert.That(stats.SecondFloorGenFatherCampbellsChapel, Is.EqualTo(122));
            Assert.That(stats.SecondFloorGenMothersDwelling, Is.EqualTo(212));
            Assert.That(stats.SecondFloorGenTempleOfPurgation, Is.EqualTo(74));
            Assert.That(stats.SecondFloorGenGame, Is.EqualTo(323));
            Assert.That(stats.SecondFloorGenFamilyResidence, Is.EqualTo(142));
            Assert.That(stats.SecondFloorGenSanctumOfWrath, Is.EqualTo(107));
            Assert.That(stats.SecondFloorGenMountOrmondResort, Is.EqualTo(284));
            Assert.That(stats.SecondFloorGenLampkinLane, Is.EqualTo(192));
            Assert.That(stats.SecondFloorGenPaleRose, Is.EqualTo(196));
            Assert.That(stats.SecondFloorGenUndergroundComplex, Is.EqualTo(50));
            Assert.That(stats.SecondFloorGenTreatmentTheatre, Is.EqualTo(176));
            Assert.That(stats.SecondFloorGenDeadDawgSaloon, Is.EqualTo(205));
            Assert.That(stats.SecondFloorGenMidwichElementarySchool, Is.EqualTo(196));
            Assert.That(stats.SecondFloorGenRacconCityPoliceStation, Is.EqualTo(224));
            Assert.That(stats.SecondFloorGenEyrieOfCrows, Is.EqualTo(253));
            Assert.That(stats.SecondFloorGenGardenOfJoy, Is.EqualTo(96));
            Assert.That(stats.SecondFloorGenShatteredSquare, Is.EqualTo(52));
            Assert.That(stats.SecondFloorGenShelterWoods, Is.EqualTo(41));
            Assert.That(stats.SecondFloorGenTobaLanding, Is.EqualTo(46));
            Assert.That(stats.SecondFloorGenMessHall, Is.EqualTo(43));
            Assert.That(stats.SecondFloorGenGreenvilleSquare, Is.EqualTo(17));
            Assert.That(stats.SecondFloorGenForgottenRuins, Is.EqualTo(14));
            Assert.That(stats.KillerRank, Is.EqualTo(16));
            Assert.That(stats.KillerFullLoadout, Is.EqualTo(25175));
            Assert.That(stats.KillerPerfectGames, Is.EqualTo(10877));
            Assert.That(stats.KillerUltraRare, Is.EqualTo(2387));
            Assert.That(stats.Killed, Is.EqualTo(4836));
            Assert.That(stats.KilledAllEvilWithin, Is.EqualTo(3));
            Assert.That(stats.Sacrificed, Is.EqualTo(67285));
            Assert.That(stats.SacrificedAllBeforeLastGen, Is.EqualTo(9518));
            Assert.That(stats.SacrificedObsessions, Is.EqualTo(15383));
            Assert.That(stats.KilledSacrificedAfterLastGen, Is.EqualTo(14838));
            Assert.That(stats.BlinkAttacks, Is.EqualTo(87234));
            Assert.That(stats.ChainsawHits, Is.EqualTo(16464));
            Assert.That(stats.EvilWithinTierUp, Is.EqualTo(2176));
            Assert.That(stats.BearTrapCatches, Is.EqualTo(1639));
            Assert.That(stats.UncloakAttacks, Is.EqualTo(18212));
            Assert.That(stats.Shocked, Is.EqualTo(6161));
            Assert.That(stats.HatchetsThrown, Is.EqualTo(78114));
            Assert.That(stats.DreamState, Is.EqualTo(6085));
            Assert.That(stats.RbtsPlaced, Is.EqualTo(3233));
            Assert.That(stats.PhantasmsTriggered, Is.EqualTo(8844));
            Assert.That(stats.CagesOfAtonement, Is.EqualTo(530));
            Assert.That(stats.LethalRushHits, Is.EqualTo(8845));
            Assert.That(stats.Lacerations, Is.EqualTo(2267));
            Assert.That(stats.PossessedChains, Is.EqualTo(4802));
            Assert.That(stats.Condemned, Is.EqualTo(1206));
            Assert.That(stats.SlammedSurvivors, Is.EqualTo(464));
            Assert.That(stats.SurvivorsDamagedPursuedByGuard, Is.EqualTo(149));
            Assert.That(stats.TailAttacks, Is.EqualTo(98));
            Assert.That(stats.HellfireHits, Is.EqualTo(137));
            Assert.That(stats.GensDamagedWhileOneHooked, Is.EqualTo(38082));
            Assert.That(stats.GensDamagedWhileUndetectable, Is.EqualTo(2543));
            Assert.That(stats.SurvivorsGrabbedRepairingGen, Is.EqualTo(1460));
            Assert.That(stats.SurvivorsGrabbedFromInsideALocker, Is.EqualTo(1674));
            Assert.That(stats.SurvivorsAllMaxMadness, Is.EqualTo(775));
            Assert.That(stats.SurvivorsHitAfterTeleporting, Is.EqualTo(153));
            Assert.That(stats.SurvivorsHitDroppingPalletInChase, Is.EqualTo(26517));
            Assert.That(stats.SurvivorsHitWhileCarrying, Is.EqualTo(7791));
            Assert.That(stats.SurvivorsHitBasicAttackUndetectable, Is.EqualTo(694));
            Assert.That(stats.SurvivorsHitScamper, Is.EqualTo(11));
            Assert.That(stats.SurvivorsHitDetainedByDog, Is.EqualTo(74));
            Assert.That(stats.SurvivorsThreeHookedBasementSameTime, Is.EqualTo(1514));
            Assert.That(stats.HatchesClosed, Is.EqualTo(4917));
            Assert.That(stats.HookedWhileThreeInjured, Is.EqualTo(4903));
            Assert.That(stats.SurvivorsInterruptedCleansingTotem, Is.EqualTo(410));
            Assert.That(stats.SurvivorsHookedEndGameCollapse, Is.EqualTo(10436));
            Assert.That(stats.SurvivorsHookedBeforeGenRepaired, Is.EqualTo(16835));
            Assert.That(stats.SurvivorsHookedInBasement, Is.EqualTo(16531));
            Assert.That(stats.VaultsInChaseAsKiller, Is.EqualTo(4571));
            Assert.That(stats.SurvivorsScreams, Is.EqualTo(27787));
            Assert.That(stats.SurvivorsInjuredBasement, Is.EqualTo(628));
            Assert.That(stats.SurvivorsInteruptedVaulting, Is.EqualTo(53));
            Assert.That(stats.SurvivorsDownedHatchets, Is.EqualTo(224));
            Assert.That(stats.SurvivorsDownedChainsaw, Is.EqualTo(3502));
            Assert.That(stats.SurvivorsDownedIntoxicated, Is.EqualTo(1014));
            Assert.That(stats.SurvivorsDownedHaunting, Is.EqualTo(1337));
            Assert.That(stats.SurvivorsDownedDeepWound, Is.EqualTo(839));
            Assert.That(stats.SurvivorsDownedMaxSickness, Is.EqualTo(2319));
            Assert.That(stats.SurvivorsDownedMarked, Is.EqualTo(585));
            Assert.That(stats.SurvivorsDownedShred, Is.EqualTo(128));
            Assert.That(stats.SurvivorsDownedBloodFury, Is.EqualTo(625));
            Assert.That(stats.SurvivorsDownedSpeared, Is.EqualTo(495));
            Assert.That(stats.SurvivorsDownedVictor, Is.EqualTo(615));
            Assert.That(stats.SurvivorsDownedContaminated, Is.EqualTo(489));
            Assert.That(stats.SurvivorsDownedDireCrows, Is.EqualTo(184));
            Assert.That(stats.SurvivorsDownedNightfall, Is.EqualTo(87));
            Assert.That(stats.SurvivorsDownedLockOn, Is.EqualTo(93));
            Assert.That(stats.SurvivorsDownedUvx, Is.EqualTo(124));
            Assert.That(stats.SurvivorsDownedHindered, Is.EqualTo(2198));
            Assert.That(stats.SurvivorsDownedOblivious, Is.EqualTo(10315));
            Assert.That(stats.SurvivorsDownedExposed, Is.EqualTo(7328));
            Assert.That(stats.SurvivorsDownedWhileCarrying, Is.EqualTo(1302));
            Assert.That(stats.SurvivorsDownedNearRaisedPallet, Is.EqualTo(46389));
            Assert.That(stats.Hash, Is.EqualTo("2b15b8bf233042158b0c3651ff390e9fe0753c5a"));
            Assert.That(stats.UpdatedAt, Is.EqualTo(1731832503));
            Assert.That(stats.CreatedAt, Is.EqualTo(0));
            Assert.That(stats.Playtime, Is.EqualTo(1457720));
            Assert.That(stats.BanState, Is.EqualTo(0));
        });
    }
    
    [Test]
    public async Task GetStats_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/playerstats?steamid=99999999999999999", statusCode: HttpStatusCode.NotFound);
        var playerClient = new DbdTrickyPlayerClient(client);
        
        var stats = await playerClient.GetStats(SteamId);
        Assert.That(stats, Is.Null);
    }
}