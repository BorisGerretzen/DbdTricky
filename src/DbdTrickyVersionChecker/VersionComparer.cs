using DbdTricky.Lib.Versions;

namespace DbdTrickyVersionChecker;

public class VersionComparer : IComparer<DbdTrickyVersion>
{
    public int Compare(DbdTrickyVersion? x, DbdTrickyVersion? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return 1;
        if (y is null) return -1;

        foreach (var pair in x.Version.Split('.').Zip(y.Version.Split('.')))
        {
            var left = int.Parse(pair.First);
            var right = int.Parse(pair.Second);
            var comparison = left.CompareTo(right);
            if (comparison != 0) return comparison;
        }
        
        return x.LastUpdate.CompareTo(y.LastUpdate);
    }
}