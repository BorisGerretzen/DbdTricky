namespace DbdTricky.Lib.Player;

public class DbdTrickyPlayerClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyPlayerClient
{
    /// <inheritdoc/>
    public Task<DbdTrickyLeaderboardStat?> GetLeaderBoardStat(long steamId, string stat = DbdTrickyStat.Bloodpoints, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?>
        {
            { "steamid", steamId.ToString() },
            { "stat", stat }
        };

        return GetOrDefault<DbdTrickyLeaderboardStat>("leaderboardposition", parameters, cancellationToken);
    }
    
    /// <inheritdoc/>
    public Task<DbdTrickyPlayerAdepts?> GetAdepts(long steamId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "steamid", steamId.ToString() } };
        return GetOrDefault<DbdTrickyPlayerAdepts>("playeradepts", parameters, cancellationToken);
    }
    
    /// <inheritdoc/>
    public Task<DbdTrickyPlayerStats?> GetStats(long steamId, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "steamid", steamId.ToString() } };
        return GetOrDefault<DbdTrickyPlayerStats>("playerstats", parameters, cancellationToken);
    }
}