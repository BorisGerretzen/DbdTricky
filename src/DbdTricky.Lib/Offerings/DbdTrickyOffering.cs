namespace DbdTricky.Lib.Offerings;

public class DbdTrickyOffering
{
    public required string Type { get; init; }
    public List<string>? Tags { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string Rarity { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter<DbdTrickyRole>))] public DbdTrickyRole? Role { get; init; }
    public required int Retired { get; init; }
    public required string Image { get; init; }
}