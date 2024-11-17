namespace DbdTricky.Lib.PatchNotes;

public class DbdTrickyPatchNotes
{
    public required string Id { get; init; } 
    public int? Kb { get; init; }
    public required int Type { get; init; }
    public required string Notes { get; init; }
    public int? Ptb { get; init; }
}