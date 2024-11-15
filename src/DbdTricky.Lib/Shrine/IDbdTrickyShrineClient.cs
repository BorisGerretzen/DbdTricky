namespace DbdTricky.Lib.Shrine;

public interface IDbdTrickyShrineClient
{
    /// <summary>
    /// Gets the current shrine.
    /// </summary>
    /// <param name="includePerkInfo">Whether to include more perk info instead of just names and prices.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Current shrine.</returns>
    Task<DbdTrickyShrine> GetShrine(bool includePerkInfo = false, CancellationToken cancellationToken = default);
}