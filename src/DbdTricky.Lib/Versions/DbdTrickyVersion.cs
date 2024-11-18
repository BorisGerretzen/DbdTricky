using System.Text.Json.Serialization;

namespace DbdTricky.Lib.Versions;

public class DbdTrickyVersion: IComparable<DbdTrickyVersion>
{
    public required string Version { get; init; }
    public required long LastUpdate { get; init; }
    
    [JsonIgnore] public DateTime LastUpdateDateTime => DateTime.UnixEpoch.AddSeconds(LastUpdate);

    public int CompareTo(DbdTrickyVersion? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;

        foreach (var pair in Version.Split('.').Zip(other.Version.Split('.')))
        {
            var left = int.Parse(pair.First);
            var right = int.Parse(pair.Second);
            var comparison = left.CompareTo(right);
            if (comparison != 0) return comparison;
        }
        
        return LastUpdate.CompareTo(other.LastUpdate);
    }
    
    public static bool operator >(DbdTrickyVersion left, DbdTrickyVersion right) => left.CompareTo(right) > 0;
    public static bool operator <(DbdTrickyVersion left, DbdTrickyVersion right) => left.CompareTo(right) < 0;
    public static bool operator >=(DbdTrickyVersion left, DbdTrickyVersion right) => left.CompareTo(right) >= 0;
    public static bool operator <=(DbdTrickyVersion left, DbdTrickyVersion right) => left.CompareTo(right) <= 0;
    public static bool operator ==(DbdTrickyVersion left, DbdTrickyVersion right) => left.CompareTo(right) == 0;
    public static bool operator !=(DbdTrickyVersion left, DbdTrickyVersion right) => left.CompareTo(right) != 0;
    
    protected bool Equals(DbdTrickyVersion other)
    {
        return Version == other.Version && LastUpdate == other.LastUpdate;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((DbdTrickyVersion)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Version, LastUpdate);
    }
}