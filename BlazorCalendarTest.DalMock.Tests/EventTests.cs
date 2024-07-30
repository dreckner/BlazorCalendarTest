using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.DalMock.Tests
{
    [TestFixture]
    public class EventTests
    {
        private IEventDal dal;
        [SetUp]
        public void Setup()
        {
            dal = Startup.GetRequiredService<IEventDal>();
        }
        [Test]
        public void FetchEventCalendarEvents()
        {
            var calendar = dal.Fetch(1);
            Assert.IsNotNull(calendar);
        }
        [Test]
        public void FetchEvent()
        {
            var calendar = dal.Fetch(1);
            var eventId = calendar[0].Id;
            var evt = dal.Fetch(eventId);
            Assert.That(evt is not null);
        }
        [Test]
        public void InsertEvent()
        {
            var newId = Guid.NewGuid();

            var evt = new EventDto
            {
                CalendarId = 1,
                Id = newId,
                Title = "Delete Event",
                Description = "Delete Event",
                Organizer = "Test Organizer",                
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                EventTypeId = 1,
                EventSpaceId = 1
            };
            dal.Insert(evt);
            Assert.That(evt.Id, Is.EqualTo(newId));
            Assert.That(evt.Organizer, Is.EqualTo("Test Organizer"));
            
        }
        [Test]
        public void UpdateEvent()
        {
            var calendar = dal.Fetch(1);
            var evt = dal.Fetch(calendar[0].Id);
            evt.Organizer = "Updated Organizer";
            dal.Update(evt);
            var updatedEvent = dal.Fetch(calendar[0].Id);
            Assert.That("Updated Organizer" == updatedEvent.Organizer);
        }
        [Test]
        public void DeleteEvent()
        {
            var newEvent = new EventDto
            {
                Id = Guid.NewGuid(),
                CalendarId = 1,
                Title = "Delete Event",
                Description = "Delete Event",
                Organizer = "Delete Event",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1)
            };
            dal.Insert(newEvent);
            var existingEvent = dal.Fetch(newEvent.Id);
            Assert.IsNotNull(existingEvent);
            dal.Delete(newEvent.Id);
            
            try
            {
                var deletedEvent = dal.Fetch(newEvent.Id);
            }
            catch (DataNotFoundException)
            {
                Assert.Pass();
            }
        }

    }

}