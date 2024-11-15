using DbdTricky.Lib.Common;

namespace DbdTricky.Lib.PatchNotes;

public class DbdTrickyPatchNotesClient(HttpClient http) : DbdTrickyBaseClient(http), IDbdTrickyPatchNotesClient
{
    public Task<List<DbdTrickyPatchNotes>> GetPatchNotes(CancellationToken cancellationToken = default)
    {
        return Get<List<DbdTrickyPatchNotes>>("patchnotes", null, cancellationToken: cancellationToken);
    }

    public Task<DbdTrickyPatchNotes?> GetPatchNotesByVersion(string version, CancellationToken cancellationToken = default)
    {
        var parameters = new Dictionary<string, string?> { { "version", version } };
        return GetOrDefault<DbdTrickyPatchNotes>("patchnotes", parameters, cancellationToken);
    }
}