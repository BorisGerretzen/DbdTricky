namespace DbdTricky.Lib.Journals;

public class DbdTrickyJournalVignette
{
    public required string Title { get; init; }
    public required string Subtitle { get; init; }
    public required int Cinematics { get; init; }
    public required List<DbdTrickyJournalEntry> Entries { get; init; }
}