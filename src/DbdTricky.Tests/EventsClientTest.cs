using DbdTricky.Lib.Events;

namespace DbdTricky.Tests;

public class EventsClientTest
{
    [Test]
    public async Task GetEvents_ShouldReturnEvents()
    {
        var client = TestHttpClientFactory.CreateClient("/events", ResourceReader.Read("events.json"));
        var eventsClient = new DbdTrickyEventsClient(client);

        var events = await eventsClient.GetEvents();
        Assert.That(events, Is.Not.Null);
        
        var @event = events.First(e => e.Event == "BPEVENT_Bloodfeast_NAME");
        Assert.Multiple(() =>
        {
            Assert.That(@event, Is.Not.Null);
            Assert.That(@event.Type, Is.EqualTo("bloodpoints"));
            Assert.That(@event.Name, Is.EqualTo("BLOODFEAST!"));
            Assert.That(@event.Multiplier, Is.EqualTo(2));
            Assert.That(@event.Start, Is.EqualTo(1441929600));
            Assert.That(@event.End, Is.EqualTo(1442016000));
        });
    }
}