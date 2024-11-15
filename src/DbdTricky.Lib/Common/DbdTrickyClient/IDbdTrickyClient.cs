using DbdTricky.Lib.Addons;
using DbdTricky.Lib.Archives;
using DbdTricky.Lib.Characters;
using DbdTricky.Lib.Customizations;
using DbdTricky.Lib.Dlc;
using DbdTricky.Lib.Events;
using DbdTricky.Lib.Items;
using DbdTricky.Lib.Journals;
using DbdTricky.Lib.Maps;
using DbdTricky.Lib.Offerings;
using DbdTricky.Lib.PatchNotes;
using DbdTricky.Lib.Perks;
using DbdTricky.Lib.PlayerCount;
using DbdTricky.Lib.RankReset;
using DbdTricky.Lib.Rift;
using DbdTricky.Lib.Shrine;
using DbdTricky.Lib.TopStats;
using DbdTricky.Lib.Versions;

namespace DbdTricky.Lib.Common;

public interface IDbdTrickyClient
{
    IDbdTrickyAddonsClient Addons { get; }
    IDbdTrickyArchivesClient Archives { get; }
    IDbdTrickyCharactersClient Characters { get; }
    IDbdTrickyCustomizationsClient Customizations { get; }
    IDbdTrickyDlcClient Dlc { get; }
    IDbdTrickyEventsClient Events { get; }
    IDbdTrickyItemsClient Items { get; }
    IDbdTrickyJournalsClient Journals { get; }
    IDbdTrickyMapsClient Maps { get; }
    IDbdTrickyOfferingsClient Offerings { get; }
    IDbdTrickyPatchNotesClient PatchNotes { get; }
    IDbdTrickyPerksClient Perks { get; }
    IDbdTrickyPlayerCountClient PlayerCount { get; }
    IDbdTrickyRankResetClient RankReset { get; }
    IDbdTrickyRiftClient Rift { get; }
    IDbdTrickyShrineClient Shrine { get; }
    IDbdTrickyTopStatsClient TopStats { get; }
    IDbdTrickyVersionsClient Versions { get; }
}