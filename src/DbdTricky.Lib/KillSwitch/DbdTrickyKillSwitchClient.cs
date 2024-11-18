using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.KillSwitch;

public class DbdTrickyKillSwitchClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyKillSwitchClient
{
    /// <inheritdoc />
    public Task<List<DbdTrickyKillSwitch>?> GetKillSwitch(CancellationToken token = default)
    {
        return GetOrDefault<List<DbdTrickyKillSwitch>>("killswitch", null, cancellationToken: token);
    }
}