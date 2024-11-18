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
using Microsoft.Extensions.DependencyInjection;

namespace DbdTricky.Lib.Common;

public static class DbdTrickyExtensions
{
    public static string AsString(this DbdTrickyRole role)
    {
        return role switch
        {
            DbdTrickyRole.Survivor => "survivor",
            DbdTrickyRole.Killer => "killer",
            DbdTrickyRole.Shared => "shared",
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }

    /// <summary>
    /// Adds the DbdTricky services to the service collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Override default configuration.</param>
    public static IServiceCollection AddDbdTricky(this IServiceCollection services, DbdTrickyConfiguration? configuration = null)
    {
        var configureClient = (HttpClient client) =>
        {
            client.BaseAddress = new Uri(configuration?.BaseUrl ?? "https://dbd.tricky.lol/api/");
            client.DefaultRequestHeaders.Add("User-Agent", configuration?.UserAgent ?? "DbdTricky.Lib");
        };

        return services.AddDbdTricky(configureClient);
    }

    /// <summary>
    /// Adds the DbdTricky services to the service collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configureClient">Configurator for the HttpClient.</param>
    /// <returns></returns>
    public static IServiceCollection AddDbdTricky(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddHttpClient<IDbdTrickyAddonsClient, DbdTrickyAddonsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyArchivesClient, DbdTrickyArchivesClient>(configureClient);
        services.AddHttpClient<IDbdTrickyCharactersClient, DbdTrickyCharactersClient>(configureClient);
        services.AddHttpClient<IDbdTrickyOfferingsClient, DbdTrickyOfferingsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyPerksClient, DbdTrickyPerksClient>(configureClient);
        services.AddHttpClient<IDbdTrickyCustomizationsClient, DbdTrickyCustomizationsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyDlcClient, DbdTrickyDlcClient>(configureClient);
        services.AddHttpClient<IDbdTrickyEventsClient, DbdTrickyEventsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyGameModesClient, DbdTrickyGameModesClient>(configureClient);
        services.AddHttpClient<IDbdTrickyItemsClient, DbdTrickyItemsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyJournalsClient, DbdTrickyJournalsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyKillSwitchClient, DbdTrickyKillSwitchClient>(configureClient);
        services.AddHttpClient<IDbdTrickyMapsClient, DbdTrickyMapsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyPerksClient, DbdTrickyPerksClient>(configureClient);
        services.AddHttpClient<IDbdTrickyPatchNotesClient, DbdTrickyPatchNotesClient>();
        services.AddHttpClient<IDbdTrickyPerksClient, DbdTrickyPerksClient>(configureClient);
        services.AddHttpClient<IDbdTrickyPlayerClient, DbdTrickyPlayerClient>();
        services.AddHttpClient<IDbdTrickyPlayerCountClient, DbdTrickyPlayerCountClient>(configureClient);
        services.AddHttpClient<IDbdTrickyRankResetClient, DbdTrickyRankResetClient>(configureClient);
        services.AddHttpClient<IDbdTrickyRiftClient, DbdTrickyRiftsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyShrineClient, DbdTrickyShrineClient>(configureClient);
        services.AddHttpClient<IDbdTrickyTopStatsClient, DbdTrickyTopStatsClient>(configureClient);
        services.AddHttpClient<IDbdTrickyVersionsClient, DbdTrickyVersionsClient>(configureClient);

        services.AddTransient<IDbdTrickyClient, DbdTrickyClient>();

        return services;
    }
}