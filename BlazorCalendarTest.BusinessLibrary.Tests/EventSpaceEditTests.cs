using BlazorCalendarTest.Dal;
using BlazorCalendarTest.BusinessLibrary;
using Csla;

namespace BlazorCalendarTest.BusinessLibrary.Tests
{
    [TestFixture]
    public class EventSpaceEditTests
    {
        [Test]
        public void FetchAll()
        {
            var dataPortal = Startup.GetRequiredService<Csla.IDataPortal<EventSpaceInfoList>>();
            var dpCalendarInfoList = Startup.GetRequiredService<Csla.IDataPortal<CalendarInfoList>>();
            var calList = dpCalendarInfoList.Fetch();
            var list = dataPortal.Fetch(calList[0].Id);
            Assert.IsNotNull(list);
            Assert.That(list.Count > 0);
        }
        [Test]
        public void FetchEventSpace()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventSpaceEdit>>();
            var eventSpace = dp.Fetch(1);
            Assert.IsNotNull(eventSpace);
        }
        [Test]
        public void InsertEventSpace()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventSpaceEdit>>();
            var c = dp.Create();
            c.Name = "Test Event Space Test";
            c.Active = true;
            var c2 = c.Save();
            Assert.That(c2.Id > 0);
        }
        [Test]
        public void UpdateEventSpace()
        {
            var dpCalendarInfoList = Startup.GetRequiredService<Csla.IDataPortal<CalendarInfoList>>();
            var dpEventInfoList = Startup.GetRequiredService<Csla.IDataPortal<EventSpaceInfoList>>();
            var dpEventSpaceEdit = Startup.GetRequiredService<Csla.IDataPortal<EventSpaceEdit>>();
            var calList = dpCalendarInfoList.Fetch();
            var list = dpEventInfoList.Fetch(calList[0].Id);
            var eventSpace = list[0];
            var eventSpaceEdit = dpEventSpaceEdit.Fetch(eventSpace.Id);
            eventSpaceEdit.Name = "Updated Event Space";
            var o = eventSpaceEdit.Save();
            var updatedEventSpace = dpEventSpaceEdit.Fetch(eventSpace.Id);
            Assert.That("Updated Event Space" == updatedEventSpace.Name);
        }
        [Test]
        public void DeleteEventSpace()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventSpaceEdit>>();
            var eventSpace = dp.Create();
            eventSpace.Name = "Delete Test Event Space";
            eventSpace = eventSpace.Save();

            Assert.That(eventSpace.Id > 0);
            var eventSpace2 = dp.Fetch(eventSpace.Id);
            eventSpace2.Delete();
            var o2 = eventSpace2.Save();
            try
            {
                var eventSpace3 = dp.Fetch(eventSpace.Id);
            }
            catch
            {
                Assert.Pass();
            }
        }
    }
}