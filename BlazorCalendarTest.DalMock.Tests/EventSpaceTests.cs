using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.DalMock.Tests
{
    [TestFixture]
    public class EventSpaceTests
    {
        private IEventSpaceDal dal;
        [SetUp]
        public void Setup()
        {
            dal = Startup.GetRequiredService<IEventSpaceDal>();
        }
        [Test]
        public void FetchEventSpaceTest()
        {
            var eventSpace = dal.Fetch(1);
            Assert.IsNotNull(eventSpace);
        }
        [Test]
        public void InsertEventSpaceTest()
        {
            var eventSpace = new EventSpaceDto
            {
                CalendarId = 1,
                Name = "Test Event Space",
                Description = "Test Event Space Description",
                Active = true
            };
            dal.Insert(eventSpace);
            Assert.That(eventSpace.Id > 0);
        }
        [Test]
        public void UpdateEventSpaceTest()
        {
            var eventSpace = dal.Fetch(1);
            eventSpace.Name = "Updated Event Space";
            dal.Update(eventSpace);
            var updatedEventSpace = dal.Fetch(1);
            Assert.That("Updated Event Space" == updatedEventSpace.Name);
        }
        [Test]
        public void DeleteEventSpaceTest()
        {
            var newEventSpace = new EventSpaceDto
            {
                
                CalendarId = 1,
                Name = "Test Event Space",
                Description = "Test Event Space Description",
                Active = true
            };
            dal.Insert(newEventSpace);

            var existingEventSpace = dal.Fetch(newEventSpace.Id);
            Assert.IsNotNull(existingEventSpace);
            
            dal.Delete(existingEventSpace.Id);

            try
            {
                var deletedEventSpace = dal.Fetch(existingEventSpace.Id);
            }
            catch (DataNotFoundException)
            {
                Assert.Pass();
            }
            
        }

    }

}