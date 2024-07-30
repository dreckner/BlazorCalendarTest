using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.DalMock.Tests
{
    [TestFixture]
    public class CalendarTests
    {
        private ICalendarDal dal;
        [SetUp]
        public void Setup()
        {
            dal = Startup.GetRequiredService<ICalendarDal>();
        }

        [Test]
        public void FetchCalendarTest()
        {
            var calendar = dal.Fetch(1);
            Assert.IsNotNull(calendar);
        }
        [Test]
        public void InsertCalendarTest()
        {
            var calendar = new CalendarDto
            {
                Name = "Test Calendar",
                Active = true
            };
            dal.Insert(calendar);
            Assert.That(calendar.Id > 0);
        }
        [Test]
        public void UpdateCalendarTest()
        {
            var calendar = dal.Fetch(1);
            calendar.Name = "Updated Calendar";
            dal.Update(calendar);
            var updatedCalendar = dal.Fetch(1);
            Assert.That("Updated Calendar" == updatedCalendar.Name);
        }
        [Test]
        public void DeleteCalendarTest()
        {
            var newCalendar = new CalendarDto
            {
                Name = "Delete Calendar",
                Active = true
            };
            dal.Insert(newCalendar);

            var existingCal = dal.Fetch(newCalendar.Id);
            Assert.IsNotNull(existingCal);
            dal.Delete(newCalendar.Id);

            try
            {
                var deletedCal = dal.Fetch(newCalendar.Id);
            }
            catch (DataNotFoundException)
            {
                Assert.Pass();
            }
            
        }
    }
}