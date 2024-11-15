namespace DbdTricky.Lib.PatchNotes;

public interface IDbdTrickyPatchNotesClient
{
    /// <summary>
    /// Get all patch notes
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of patchnotes.</returns>
    Task<List<DbdTrickyPatchNotes>> GetPatchNotes(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get patch notes by version.
    /// </summary>
    /// <param name="version">Version of the patch.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Null if not found.</returns>
    Task<DbdTrickyPatchNotes?> GetPatchNotesByVersion(string version, CancellationToken cancellationToken = default);
}