using System.Net;
using DbdTricky.Lib.PatchNotes;

namespace DbdTricky.Tests;

public class PatchNotesClientTest
{
    [Test]
    public async Task GetPatchNotes_ShouldReturnPatchNotes()
    {
        var client = TestHttpClientFactory.CreateClient("/patchnotes", ResourceReader.Read("patchnotes.json"));
        var patchNotesClient = new DbdTrickyPatchNotesClient(client);

        var patchNotes = await patchNotesClient.GetPatchNotes();
        Assert.That(patchNotes, Is.Not.Null);
        
        var patchNote = patchNotes.First();
        Assert.Multiple(() =>
        {
            Assert.That(patchNote, Is.Not.Null);
            Assert.That(patchNote.Id, Is.EqualTo("8.0.0"));
            Assert.That(patchNote.Type, Is.EqualTo(2));
            Assert.That(patchNote.Notes, Is.Not.Null);
        });
    }
    
    [Test]
    public async Task GetPatchNotesByVersion_ShouldReturnPatchNotes()
    {
        var client = TestHttpClientFactory.CreateClient("/patchnotes?version=8.0.0", ResourceReader.Read("patchnote.json"));
        var patchNotesClient = new DbdTrickyPatchNotesClient(client);

        var patchNote = await patchNotesClient.GetPatchNotesByVersion("8.0.0");
        Assert.Multiple(() =>
        {
            Assert.That(patchNote, Is.Not.Null);
            Assert.That(patchNote.Id, Is.EqualTo("8.0.0"));
            Assert.That(patchNote.Type, Is.EqualTo(2));
            Assert.That(patchNote.Notes, Is.Not.Null);
            Assert.That(patchNote.Kb, Is.EqualTo(452));
            Assert.That(patchNote.Ptb, Is.EqualTo(0));
        });
    }
    
    [Test]
    public async Task GetPatchNotesByVersion_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/patchnotes?version=8.0.1", statusCode: HttpStatusCode.NotFound);
        var patchNotesClient = new DbdTrickyPatchNotesClient(client);

        var patchNote = await patchNotesClient.GetPatchNotesByVersion("8.0.1");
        Assert.That(patchNote, Is.Null);
    }
}