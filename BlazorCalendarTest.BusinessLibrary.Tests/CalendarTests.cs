using BlazorCalendarTest.Dal;
using Csla;
using BlazorCalendarTest.BusinessLibrary;

namespace BlazorCalendarTest.BusinessLibrary.Tests
{
    [TestFixture]
    public class CalendarTests
    {
        [Test]
        public void FetchAll()
        { 
            var dataPortal = Startup.GetRequiredService<Csla.IDataPortal<CalendarInfoList>>();
            
            var list = dataPortal.Fetch();
            Assert.IsNotNull(list);
            Assert.That(list.Count > 0);
        }
        [Test]
        public void FetchCalendar()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<CalendarEdit>>();
            var calendar = dp.Fetch(1);
            Assert.IsNotNull(calendar);
        }
        [Test]
        public void InsertCalendar()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<CalendarEdit>>();
            var c = dp.Create();
            c.Name = "Test Calendar Test";
            c.Active = true;
            var c2 = c.Save();
            Assert.That(c2.Id > 0);
        }
        [Test]
        public void UpdateCalendar()
        {
            
            var dp = Startup.GetRequiredService<Csla.IDataPortal<CalendarEdit>>();
            var calendar = dp.Fetch(1);
            calendar.Name = "Updated Calendar";
            var o = calendar.Save();
            var updatedCalendar = dp.Fetch(1);
            Assert.That("Updated Calendar" == updatedCalendar.Name);
        }
        [Test]
        public void DeleteCalendar()
        {
            
            var dp = Startup.GetRequiredService<Csla.IDataPortal<CalendarEdit>>();
            var cal = dp.Create();
            cal.Name = "Delete Test Calendar";
            cal = cal.Save();

            Assert.That(cal.Id > 0);
            var cal2 = dp.Fetch(cal.Id);
            cal2.Delete();
            var o2 = cal2.Save();

            try
            {
                var calendar = dp.Fetch(cal.Id);
            
            }
            catch
            {
                Assert.Pass();
            }
            
        }
        [Test]
        public void TestEventCount()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<CalendarEdit>>();
            var c = dp.Fetch(1);
            Assert.That(c.Events.Count > 0);
        }
        
    }

}

