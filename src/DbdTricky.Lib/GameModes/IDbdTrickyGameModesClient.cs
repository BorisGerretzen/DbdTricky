namespace DbdTricky.Lib.GameModes;

public interface IDbdTrickyGameModesClient
{
    /// <summary>
    /// Gets all gamemodes.
    /// </summary>
    /// <param name="token"></param>
    /// <returns>GameModes indexed by id.</returns>
    Task<Dictionary<string, DbdTrickyGameMode>> GetGameModes(CancellationToken token = default);
}