using DbdTricky.Lib.Addons;

namespace DbdTricky.Lib.Common;

public interface IDbdTrickyClient
{
    IDbdAddonsClient Addons { get; }
}