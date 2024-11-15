using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.Dlc;

public class DbdTrickyDlcClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyDlcClient
{
    public Task<Dictionary<string, DbdTrickyDlc>> GetDlcs(CancellationToken cancellationToken = default)
    {
        return Get<Dictionary<string, DbdTrickyDlc>>("dlc", null, cancellationToken);
    }
}