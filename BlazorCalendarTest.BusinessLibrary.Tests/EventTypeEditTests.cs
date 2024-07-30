using Csla;
using BlazorCalendarTest.Dal;
using BlazorCalendarTest.BusinessLibrary;

namespace BlazorCalendarTest.BusinessLibrary.Tests
{
    [TestFixture]
    public class EventTypeEditTests
    {
        [Test]
        public void FetchAll()
        { 
            var dataPortal = Startup.GetRequiredService<Csla.IDataPortal<EventTypeInfoList>>();
            
            var list = dataPortal.Fetch();
            Assert.IsNotNull(list);
            Assert.That(list.Count > 0);
        }
        [Test]
        public void FetchEventType()
        {
            var dpEventTypeInfoList = Startup.GetRequiredService<Csla.IDataPortal<EventTypeInfoList>>();    
            var list = dpEventTypeInfoList.Fetch();
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventTypeEdit>>();
            var eventType = dp.Fetch(list[0].Id);
            Assert.IsNotNull(eventType);
        }
        [Test]
        public void InsertEventType()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventTypeEdit>>();
            var c = dp.Create();
            c.Name = "Test Event Type Test";
            c.Active = true;
            var c2 = c.Save();
            Assert.That(c2.Id > 0);
        }
        [Test]
        public void UpdateEventType()
        {
            var dpEventTypeInfoList = Startup.GetRequiredService<Csla.IDataPortal<EventTypeInfoList>>();    
            var list = dpEventTypeInfoList.Fetch();
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventTypeEdit>>();
            var eventType = dp.Fetch(list[0].Id);
            eventType.Name = "Updated Event Type";
            var o = eventType.Save();
            var updatedEventType = dp.Fetch(list[0].Id);
            Assert.That("Updated Event Type" == updatedEventType.Name);
        }
        [Test]
        public void DeleteEventType()
        {
            
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventTypeEdit>>();
            var cal = dp.Create();
            cal.Name = "Delete Test Event Type";
            cal = cal.Save();

            Assert.That(cal.Id > 0);
            var cal2 = dp.Fetch(cal.Id);
            cal2.Delete();
            var o2 = cal2.Save();
        }
    }
}