namespace DbdTricky.Lib.Dlc;

public class DbdTrickyDlcClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyDlcClient
{
    /// <inheritdoc />
    public Task<Dictionary<string, DbdTrickyDlc>> GetDlcs(CancellationToken cancellationToken = default)
    {
        return Get<Dictionary<string, DbdTrickyDlc>>("dlc", null, cancellationToken);
    }
}