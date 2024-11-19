namespace DbdTricky.Lib.GameModes;

public class DbdTrickyGameModesClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyGameModesClient
{
    /// <inheritdoc/>
    public Task<Dictionary<string, DbdTrickyGameMode>> GetGameModes(CancellationToken token = default)
    {
        return Get<Dictionary<string, DbdTrickyGameMode>>("gamemodes", null, token);
    }
}