namespace DbdTricky.Lib.KillSwitch;

public interface IDbdTrickyKillSwitchClient
{
    /// <summary>
    /// Gets the current kill switch status.
    /// </summary>
    /// <param name="token"></param>
    /// <returns>Null if not found.</returns>
    Task<List<DbdTrickyKillSwitch>?> GetKillSwitch(CancellationToken token = default);
}