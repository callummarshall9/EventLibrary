using EventLibrary.Services;
using Moq;

namespace EventLibrary.Tests
{
    public partial class EventServiceTests
    {
        readonly Mock<IEventBroker<FakeObject>> brokerMock;
        readonly IEventService<FakeObject> eventService;

        public EventServiceTests()
        {
            brokerMock = new Mock<IEventBroker<FakeObject>>();
            eventService = new EventService<FakeObject>(brokerMock.Object);
        }
    }

    public class FakeObject { }
}