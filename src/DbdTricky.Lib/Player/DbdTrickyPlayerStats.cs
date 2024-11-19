namespace DbdTricky.Lib.Player;

public class DbdTrickyPlayerStats
{
    public required long SteamId { get; init; }
    public required long Bloodpoints { get; init; }
    [JsonPropertyName("survivor_rank")] public required int SurvivorRank { get; init; }
    [JsonPropertyName("survivor_fullloadout")] public required int SurvivorFullLoadout { get; init; }
    [JsonPropertyName("survivor_perfectgames")] public required int SurvivorPerfectGames { get; init; }
    [JsonPropertyName("survivor_ultrarare")] public required int SurvivorUltraRare { get; init; }
    public required int GensRepaired { get; init; }
    public required int DamagedGensRepaired { get; init; }
    public required int SurvivorsHealed { get; init; }
    [JsonPropertyName("survivorshealed_whileinjured")] public required int SurvivorsHealedWhileInjured { get; init; }
    public required int SkillChecks { get; init; }
    [JsonPropertyName("skillchecks_injured")] public required int SkillChecksInjured { get; init; }
    public required int Saved { get; init; }
    [JsonPropertyName("saved_endgame")] public required int SavedEndgame { get; init; }
    public required int Escaped { get; init; }
    [JsonPropertyName("escaped_ko")] public required int EscapedKo { get; init; }
    [JsonPropertyName("hooked_escape")] public required int HookedEscape { get; init; }
    [JsonPropertyName("escaped_hatch")] public required int EscapedHatch { get; init; }
    [JsonPropertyName("escaped_hatchcrawling")] public required int EscapedHatchCrawling { get; init; }
    [JsonPropertyName("escaped_allhatch")] public required int EscapedAllHatch { get; init; }
    [JsonPropertyName("escaped_downedonce")] public required int EscapedDownedOnce { get; init; }
    [JsonPropertyName("escaped_injuredhalfoftrail")] public required int EscapedInjuredHalfOfTrail { get; init; }
    [JsonPropertyName("escaped_nobloodlossobsession")] public required int EscapedNoBloodLossObsession { get; init; }
    [JsonPropertyName("escaped_lastgenlastsurvivor")] public required int EscapedLastGenLastSurvivor { get; init; }
    [JsonPropertyName("escaped_newitem")] public required int EscapedNewItem { get; init; }
    [JsonPropertyName("escaped_withitemfrom")] public required int EscapedWithItemFrom { get; init; }
    [JsonPropertyName("protectionhits_unhooked")] public required int ProtectionHitsUnhooked { get; init; }
    [JsonPropertyName("protectionhits_whilecarried")] public required int ProtectionHitsWhileCarried { get; init; }
    [JsonPropertyName("healeddyingtoinjured")] public required int HealedDyingToInjured { get; init; }
    public required int ObsessionsHealed { get; init; }
    public required int ItemsDepleted { get; init; }
    [JsonPropertyName("survivorshealed_threenothealthy")] public required int SurvivorsHealedThreeNotHealthy { get; init; }
    [JsonPropertyName("survivorshealed_foundyou")] public required int SurvivorsHealedFoundYou { get; init; }
    [JsonPropertyName("killerstunned_palletcarrying")] public required int KillerStunnedPalletCarrying { get; init; }
    [JsonPropertyName("killerstunned_holdingitem")] public required int KillerStunnedHoldingItem { get; init; }
    [JsonPropertyName("gensrepaired_noperks")] public required int GensRepairedNoPerks { get; init; }
    [JsonPropertyName("escapedchase_palletstun")] public required int EscapedChasePalletStun { get; init; }
    [JsonPropertyName("escapedchase_healthyinjured")] public required int EscapedChaseHealthyInjured { get; init; }
    [JsonPropertyName("escapedchase_hidinginlocker")] public required int EscapedChaseHidingInLocker { get; init; }
    public required int DodgedAttack { get; init; }
    [JsonPropertyName("killersaurarevealed")] public required int KillersAuraRevealed { get; init; }
    [JsonPropertyName("survivorshealed_basement")] public required int SurvivorsHealedBasement { get; init; }
    [JsonPropertyName("killerblinded_flashlight")] public required int KillerBlindedFlashlight { get; init; }
    public required int VaultsInChase { get; init; }
    [JsonPropertyName("vaultsinchase_missed")] public required int VaultsInChaseMissed { get; init; }
    public required int WiggledFromKillersGrasp { get; init; }
    public required int HexTotemsCleansed { get; init; }
    public required int HexTotemsBlessed { get; init; }
    [JsonPropertyName("blessedtotemboosts")] public required int BlessedTotemBoosts { get; init; }
    public required int ExitGatesOpened { get; init; }
    [JsonPropertyName("unhookedself")] public required int UnhookedSelf { get; init; }
    public required int HooksSabotaged { get; init; }
    public required int ChestsSearched { get; init; }
    [JsonPropertyName("chestssearched_basement")] public required int ChestsSearchedBasement { get; init; }
    public required int MysteryBoxesOpened { get; init; }
    public required int Screams { get; init; }
    [JsonPropertyName("secondfloorgen_disturbedward")] public required int SecondFloorGenDisturbedWard { get; init; }
    [JsonPropertyName("secondfloorgen_fathercampbellschapel")] public required int SecondFloorGenFatherCampbellsChapel { get; init; }
    [JsonPropertyName("secondfloorgen_mothersdwelling")] public required int SecondFloorGenMothersDwelling { get; init; }
    [JsonPropertyName("secondfloorgen_templeofpurgation")] public required int SecondFloorGenTempleOfPurgation { get; init; }
    [JsonPropertyName("secondfloorgen_game")] public required int SecondFloorGenGame { get; init; }
    [JsonPropertyName("secondfloorgen_familyresidence")] public required int SecondFloorGenFamilyResidence { get; init; }
    [JsonPropertyName("secondfloorgen_sanctumofwrath")] public required int SecondFloorGenSanctumOfWrath { get; init; }
    [JsonPropertyName("secondfloorgen_mountormondresort")] public required int SecondFloorGenMountOrmondResort { get; init; }
    [JsonPropertyName("secondfloorgen_lampkinlane")] public required int SecondFloorGenLampkinLane { get; init; }
    [JsonPropertyName("secondfloorgen_palerose")] public required int SecondFloorGenPaleRose { get; init; }
    [JsonPropertyName("secondfloorgen_undergroundcomplex")] public required int SecondFloorGenUndergroundComplex { get; init; }
    [JsonPropertyName("secondfloorgen_treatmenttheatre")] public required int SecondFloorGenTreatmentTheatre { get; init; }
    [JsonPropertyName("secondfloorgen_deaddawgsaloon")] public required int SecondFloorGenDeadDawgSaloon { get; init; }
    [JsonPropertyName("secondfloorgen_midwichelementaryschool")] public required int SecondFloorGenMidwichElementarySchool { get; init; }
    [JsonPropertyName("secondfloorgen_racconcitypolicestation")] public required int SecondFloorGenRacconCityPoliceStation { get; init; }
    [JsonPropertyName("secondfloorgen_eyrieofcrows")] public required int SecondFloorGenEyrieOfCrows { get; init; }
    [JsonPropertyName("secondfloorgen_gardenofjoy")] public required int SecondFloorGenGardenOfJoy { get; init; }
    [JsonPropertyName("secondfloorgen_shatteredsquare")] public required int SecondFloorGenShatteredSquare { get; init; }
    [JsonPropertyName("secondfloorgen_shelterwoods")] public required int SecondFloorGenShelterWoods { get; init; }
    [JsonPropertyName("secondfloorgen_tobalanding")] public required int SecondFloorGenTobaLanding { get; init; }
    [JsonPropertyName("secondfloorgen_messhall")] public required int SecondFloorGenMessHall { get; init; }
    [JsonPropertyName("secondfloorgen_greenvillesquare")] public required int SecondFloorGenGreenvilleSquare { get; init; }
    [JsonPropertyName("secondfloorgen_forgottenruins")] public required int SecondFloorGenForgottenRuins { get; init; }
    [JsonPropertyName("killer_rank")] public required int KillerRank { get; init; }
    [JsonPropertyName("killer_fullloadout")] public required int KillerFullLoadout { get; init; }
    [JsonPropertyName("killer_perfectgames")] public required int KillerPerfectGames { get; init; }
    [JsonPropertyName("killer_ultrarare")] public required int KillerUltraRare { get; init; }
    public required int Killed { get; init; }
    [JsonPropertyName("killed_allevilwithin")] public required int KilledAllEvilWithin { get; init; }
    public required int Sacrificed { get; init; }
    [JsonPropertyName("sacrificed_allbeforelastgen")] public required int SacrificedAllBeforeLastGen { get; init; }
    [JsonPropertyName("sacrificed_obsessions")] public required int SacrificedObsessions { get; init; }
    [JsonPropertyName("killed_sacrificed_afterlastgen")] public required int KilledSacrificedAfterLastGen { get; init; }
    public required int BlinkAttacks { get; init; }
    public required int ChainsawHits { get; init; }
    public required int EvilWithinTierUp { get; init; }
    public required int BearTrapCatches { get; init; }
    public required int UncloakAttacks { get; init; }
    public required int Shocked { get; init; }
    public required int HatchetsThrown { get; init; }
    public required int DreamState { get; init; }
    public required int RbtsPlaced { get; init; }
    public required int PhantasmsTriggered { get; init; }
    public required int CagesOfAtonement { get; init; }
    public required int LethalRushHits { get; init; }
    public required int Lacerations { get; init; }
    public required int PossessedChains { get; init; }
    public required int Condemned { get; init; }
    public required int SlammedSurvivors { get; init; }
    public required int SurvivorsDamagedPursuedByGuard { get; init; }
    public required int TailAttacks { get; init; }
    public required int HellfireHits { get; init; }
    public required int GensDamagedWhileOneHooked { get; init; }
    public required int GensDamagedWhileUndetectable { get; init; }
    public required int SurvivorsGrabbedRepairingGen { get; init; }
    public required int SurvivorsGrabbedFromInsideALocker { get; init; }
    public required int SurvivorsAllMaxMadness { get; init; }
    [JsonPropertyName("survivorshit_afterteleporting")] public required int SurvivorsHitAfterTeleporting { get; init; }
    [JsonPropertyName("survivorshit_droppingpalletinchase")] public required int SurvivorsHitDroppingPalletInChase { get; init; }
    [JsonPropertyName("survivorshit_whilecarrying")] public required int SurvivorsHitWhileCarrying { get; init; }
    [JsonPropertyName("survivorshit_basicattackundetectable")] public required int SurvivorsHitBasicAttackUndetectable { get; init; }
    [JsonPropertyName("survivorshit_scamper")] public required int SurvivorsHitScamper { get; init; } 
    public required int SurvivorsThreeHookedBasementSameTime { get; init; }
    public required int HatchesClosed { get; init; }
    public required int HookedWhileThreeInjured { get; init; }
    public required int SurvivorsInterruptedCleansingTotem { get; init; }
    public required int SurvivorsHookedEndGameCollapse { get; init; }
    public required int SurvivorsHookedBeforeGenRepaired { get; init; }
    public required int SurvivorsHookedInBasement { get; init; }
    [JsonPropertyName("vaultsinchase_askiller")] public required int VaultsInChaseAsKiller { get; init; }
    [JsonPropertyName("survivorscreams")] public required int SurvivorsScreams { get; init; }
    [JsonPropertyName("survivorsinjured_basement")] public required int SurvivorsInjuredBasement { get; init; }
    [JsonPropertyName("survivorsinterupted_vaulting")] public required int SurvivorsInteruptedVaulting { get; init; }
    [JsonPropertyName("survivorsdowned_hatchets")] public required int SurvivorsDownedHatchets { get; init; }
    [JsonPropertyName("survivorsdowned_chainsaw")] public required int SurvivorsDownedChainsaw { get; init; }
    [JsonPropertyName("survivorsdowned_intoxicated")] public required int SurvivorsDownedIntoxicated { get; init; }
    [JsonPropertyName("survivorsdowned_haunting")] public required int SurvivorsDownedHaunting { get; init; }
    [JsonPropertyName("survivorsdowned_deepwound")] public required int SurvivorsDownedDeepWound { get; init; }
    [JsonPropertyName("survivorsdowned_maxsickness")] public required int SurvivorsDownedMaxSickness { get; init; }
    [JsonPropertyName("survivorsdowned_marked")] public required int SurvivorsDownedMarked { get; init; }
    [JsonPropertyName("survivorsdowned_shred")] public required int SurvivorsDownedShred { get; init; }
    [JsonPropertyName("survivorsdowned_bloodfury")] public required int SurvivorsDownedBloodFury { get; init; }
    [JsonPropertyName("survivorsdowned_speared")] public required int SurvivorsDownedSpeared { get; init; }
    [JsonPropertyName("survivorsdowned_victor")] public required int SurvivorsDownedVictor { get; init; }
    [JsonPropertyName("survivorsdowned_contaminated")] public required int SurvivorsDownedContaminated { get; init; }
    [JsonPropertyName("survivorsdowned_direcrows")] public required int SurvivorsDownedDireCrows { get; init; }
    [JsonPropertyName("survivorsdowned_nightfall")] public required int SurvivorsDownedNightfall { get; init; }
    [JsonPropertyName("survivorsdowned_lockon")] public required int SurvivorsDownedLockOn { get; init; }
    [JsonPropertyName("survivorsdowned_uvx")] public required int SurvivorsDownedUvx { get; init; }
    [JsonPropertyName("survivorsdowned_hindered")] public required int SurvivorsDownedHindered { get; init; }
    [JsonPropertyName("survivorsdowned_oblivious")] public required int SurvivorsDownedOblivious { get; init; }
    [JsonPropertyName("survivorsdowned_exposed")] public required int SurvivorsDownedExposed { get; init; }
    [JsonPropertyName("survivorsdowned_whilecarrying")] public required int SurvivorsDownedWhileCarrying { get; init; }
    [JsonPropertyName("survivorsdowned_nearraisedpallet")] public required int SurvivorsDownedNearRaisedPallet { get; init; }
    public required string Hash { get; init; }
    [JsonPropertyName("updated_at")] public required long UpdatedAt { get; init; }
    [JsonPropertyName("created_at")] public required long CreatedAt { get; init; }
    public required long Playtime { get; init; }
    public required int BanState { get; init; }
}