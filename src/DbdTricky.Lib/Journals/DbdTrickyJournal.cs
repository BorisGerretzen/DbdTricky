namespace DbdTricky.Lib.Journals;

public class DbdTrickyJournal
{
    public required string Title { get; init; }
    public Dictionary<string, DbdTrickyJournalVignette> Vignettes { get; init; } = new();
}