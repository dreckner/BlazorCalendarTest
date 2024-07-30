using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.DalMock.Tests
{
    [TestFixture]
    public class EventTypeTests
    {
        private IEventTypeDal dal;
        [SetUp]
        public void Setup()
        {
            dal = Startup.GetRequiredService<IEventTypeDal>();
        }
        [Test]
        public void FetchEventTypeTest()
        {
            var eventType = dal.Fetch(1);
            Assert.IsNotNull(eventType);
        }
        [Test]
        public void InsertEventTypeTest()
        {
            var eventType = new EventTypeDto
            {
                Name = "Test Event Type",
                Active = true
            };
            dal.Insert(eventType);
            Assert.That(eventType.Id > 0);
        }
        [Test]
        public void UpdateEventTypeTest()
        {
            var eventType = dal.Fetch(1);
            eventType.Name = "Updated Event Type";
            dal.Update(eventType);
            var updatedEventType = dal.Fetch(1);
            Assert.That("Updated Event Type" == updatedEventType.Name);
        }
        [Test]
        public void DeleteEventTypeTest()
        {
            var newEventType = new EventTypeDto
            {
                Name = "Delete Event Type",
                Active = true
            };
            dal.Insert(newEventType);
            var existingEventType = dal.Fetch(newEventType.Id);
            Assert.IsNotNull(existingEventType);
            dal.Delete(existingEventType.Id);
            try
            {
                var deletedEventType = dal.Fetch(newEventType.Id);
            }
            catch (DataNotFoundException)
            {
                Assert.Pass();
            }
        }

    }

}