namespace DbdTricky.Lib.Journals;

public class DbdTrickyJournalEntry
{
    public required string Title { get; init; }
    public string? Text { get; init; }
    public required string Audio { get; init; }
}