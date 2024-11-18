using DbdTricky.Lib.Addons;
using DbdTricky.Lib.Archives;
using DbdTricky.Lib.Characters;
using DbdTricky.Lib.Customizations;
using DbdTricky.Lib.Dlc;
using DbdTricky.Lib.Events;
using DbdTricky.Lib.GameModes;
using DbdTricky.Lib.Items;
using DbdTricky.Lib.Journals;
using DbdTricky.Lib.KillSwitch;
using DbdTricky.Lib.Maps;
using DbdTricky.Lib.Offerings;
using DbdTricky.Lib.PatchNotes;
using DbdTricky.Lib.Perks;
using DbdTricky.Lib.Player;
using DbdTricky.Lib.PlayerCount;
using DbdTricky.Lib.RankReset;
using DbdTricky.Lib.Rift;
using DbdTricky.Lib.Shrine;
using DbdTricky.Lib.TopStats;
using DbdTricky.Lib.Versions;

namespace DbdTricky.Lib.Common;

public class DbdTrickyClient(
    IDbdTrickyAddonsClient addons,
    IDbdTrickyArchivesClient archives,
    IDbdTrickyCharactersClient characters,
    IDbdTrickyCustomizationsClient customizations,
    IDbdTrickyDlcClient dlc,
    IDbdTrickyEventsClient events,
    IDbdTrickyGameModesClient gameModes,
    IDbdTrickyItemsClient items,
    IDbdTrickyJournalsClient journals,
    IDbdTrickyKillSwitchClient killSwitch,
    IDbdTrickyMapsClient maps,
    IDbdTrickyOfferingsClient offerings,
    IDbdTrickyPatchNotesClient patchNotes,
    IDbdTrickyPerksClient perks,
    IDbdTrickyPlayerClient player,
    IDbdTrickyPlayerCountClient playerCount,
    IDbdTrickyRankResetClient rankReset,
    IDbdTrickyRiftClient rift,
    IDbdTrickyShrineClient shrine,
    IDbdTrickyTopStatsClient topStats,
    IDbdTrickyVersionsClient versions)
    : IDbdTrickyClient
{
    public IDbdTrickyAddonsClient Addons { get; } = addons;
    public IDbdTrickyArchivesClient Archives { get; } = archives;
    public IDbdTrickyCharactersClient Characters { get; } = characters;
    public IDbdTrickyCustomizationsClient Customizations { get; } = customizations;
    public IDbdTrickyDlcClient Dlc { get; } = dlc;
    public IDbdTrickyEventsClient Events { get; } = events;
    public IDbdTrickyGameModesClient GameModes { get; } = gameModes;
    public IDbdTrickyItemsClient Items { get; } = items;
    public IDbdTrickyJournalsClient Journals { get; } = journals;
    public IDbdTrickyKillSwitchClient KillSwitch { get; } = killSwitch;
    public IDbdTrickyMapsClient Maps { get; } = maps;
    public IDbdTrickyOfferingsClient Offerings { get; } = offerings;
    public IDbdTrickyPatchNotesClient PatchNotes { get; } = patchNotes;
    public IDbdTrickyPerksClient Perks { get; } = perks;
    public IDbdTrickyPlayerClient Player { get; } = player;
    public IDbdTrickyPlayerCountClient PlayerCount { get; } = playerCount;
    public IDbdTrickyRankResetClient RankReset { get; } = rankReset;
    public IDbdTrickyRiftClient Rift { get; } = rift;
    public IDbdTrickyShrineClient Shrine { get; } = shrine;
    public IDbdTrickyTopStatsClient TopStats { get; } = topStats;
    public IDbdTrickyVersionsClient Versions { get; } = versions;
}