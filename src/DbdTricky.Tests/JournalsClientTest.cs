using System.Net;
using DbdTricky.Lib.Journals;

namespace DbdTricky.Tests;

public class JournalsClientTest
{
    /**
     *     "Anniversary2022": {
        "title": "TWISTED MASQUERADE",
        "vignettes": {
            "Anniversary2022": {
                "title": "Twisted Masquerade",
                "subtitle": "Logs, Stories, and Notes",
                "cinematics": 0,
                "entries": [
                    {
                        "title": "Journal of a Moving Picture. The Sweet Darkness.",
                        "text": "Captain Pierce found an old journal with sketches of people and creatures in elaborate costumes celebrating the \u2018Sweet Darkness.\u2019 It was signed\u2026 the Mad Designer. Another book by what I presume to be the same author showcased sketches of abandoned towers just like this one in the middle of the abyss. Pierce believes we should form parties to search for them. I think they\u2019re just the sketches of a creative artist with lots of time on his hands.",
                        "audio": "anniversary22_observer_01"
                    },
                    {
                        "title": "Journal of a Moving Picture. Jezabel.",
                        "text": "Sam Park writes to his missing son every night without fail. I\u2019d eventually like to read those letters for research. I cannot even begin to imagine what it would be like to lose someone you love and not know where they ended up. On another note, we found several other journals with absurd designs and characters illustrated by an artist who signs off as Jezabel.",
                        "audio": "anniversary22_observer_02"
                    },
                    {
                        "title": "Journal of a Moving Picture. The Mad Designer.",
                        "text": "Alex found a room filled with masks and other objects created it would seem from Jezabel\u2019s designs. It seems to me that Jezabel and the Mad Designer are one and the same. She seems to have multiple personas and her designs seem to be quite bold and unrestricted. They are fun and horrific at the same time especially those that describes battles between towers. If there is any credibility to her sketches and notes, it would seem as though I was wrong and that there are several of these towers scattered throughout the abyss.",
                        "audio": "anniversary22_observer_03"
                    }
                ]
            }
        }
    },

     */
    [Test]
    public async Task GetJournals_ShouldReturnJournals()
    {
        var client = TestHttpClientFactory.CreateClient("/journals", ResourceReader.Read("journals.json"));
        var journalsClient = new DbdTrickyJournalsClient(client);

        var journals = await journalsClient.GetJournals();
        Assert.That(journals, Is.Not.Null);

        var journal = journals["Anniversary2022"];
        Assert.Multiple(() =>
        {
            Assert.That(journal, Is.Not.Null);
            Assert.That(journal.Title, Is.EqualTo("TWISTED MASQUERADE"));
            Assert.That(journal.Vignettes, Is.Not.Null);
            Assert.That(journal.Vignettes["Anniversary2022"], Is.Not.Null);
            Assert.That(journal.Vignettes["Anniversary2022"].Title, Is.EqualTo("Twisted Masquerade"));
            Assert.That(journal.Vignettes["Anniversary2022"].Subtitle, Is.EqualTo("Logs, Stories, and Notes"));
            Assert.That(journal.Vignettes["Anniversary2022"].Cinematics, Is.EqualTo(0));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries, Is.Not.Null);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries, Has.Count.EqualTo(3));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[0].Title, Is.EqualTo("Journal of a Moving Picture. The Sweet Darkness."));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[0].Text, Is.Not.Empty);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[0].Audio, Is.EqualTo("anniversary22_observer_01"));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[1].Title, Is.EqualTo("Journal of a Moving Picture. Jezabel."));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[1].Text, Is.Not.Empty);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[1].Audio, Is.EqualTo("anniversary22_observer_02"));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[2].Title, Is.EqualTo("Journal of a Moving Picture. The Mad Designer."));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[2].Text, Is.Not.Empty);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[2].Audio, Is.EqualTo("anniversary22_observer_03"));
        });
    }

    [Test]
    public async Task GetJournal_ShouldReturnJournal()
    {
        var client = TestHttpClientFactory.CreateClient("/journals?tome=Anniversary2022", ResourceReader.Read("journal.json"));
        var journalsClient = new DbdTrickyJournalsClient(client);

        var journal = await journalsClient.GetJournal("Anniversary2022");
        Assert.That(journal, Is.Not.Null);
        
        Assert.Multiple(() =>
        {
            Assert.That(journal.Title, Is.EqualTo("TWISTED MASQUERADE"));
            Assert.That(journal.Vignettes, Is.Not.Null);
            Assert.That(journal.Vignettes["Anniversary2022"], Is.Not.Null);
            Assert.That(journal.Vignettes["Anniversary2022"].Title, Is.EqualTo("Twisted Masquerade"));
            Assert.That(journal.Vignettes["Anniversary2022"].Subtitle, Is.EqualTo("Logs, Stories, and Notes"));
            Assert.That(journal.Vignettes["Anniversary2022"].Cinematics, Is.EqualTo(0));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries, Is.Not.Null);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries, Has.Count.EqualTo(3));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[0].Title, Is.EqualTo("Journal of a Moving Picture. The Sweet Darkness."));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[0].Text, Is.Not.Empty);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[0].Audio, Is.EqualTo("anniversary22_observer_01"));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[1].Title, Is.EqualTo("Journal of a Moving Picture. Jezabel."));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[1].Text, Is.Not.Empty);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[1].Audio, Is.EqualTo("anniversary22_observer_02"));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[2].Title, Is.EqualTo("Journal of a Moving Picture. The Mad Designer."));
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[2].Text, Is.Not.Empty);
            Assert.That(journal.Vignettes["Anniversary2022"].Entries[2].Audio, Is.EqualTo("anniversary22_observer_03"));
        });
    }
    
    [Test]
    public async Task GetJournal_WhenNotFound_ShouldReturnNull()
    {
        var client = TestHttpClientFactory.CreateClient("/journals?tome=Anniversary2022", statusCode: HttpStatusCode.NotFound);
        var journalsClient = new DbdTrickyJournalsClient(client);

        var journal = await journalsClient.GetJournal("Anniversary2022");
        Assert.That(journal, Is.Null);
    }
}