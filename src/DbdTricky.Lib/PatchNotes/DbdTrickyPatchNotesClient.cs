namespace DbdTricky.Lib.PatchNotes;

public class DbdTrickyPatchNotesClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyPatchNotesClient
{
    /// <inheritdoc />
    public Task<List<DbdTrickyPatchNotes>> GetPatchNotes(CancellationToken cancellationToken = default)
    {
        return Get<List<DbdTrickyPatchNotes>>("patchnotes", null, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<DbdTrickyPatchNotes?> GetPatchNotesByVersion(string version, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "version", version } };
        return GetOrDefault<DbdTrickyPatchNotes>("patchnotes", parameters, cancellationToken);
    }
}