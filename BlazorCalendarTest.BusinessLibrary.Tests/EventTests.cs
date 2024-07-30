using BlazorCalendarTest.Dal;
using Csla;
using BlazorCalendarTest.BusinessLibrary;

namespace BlazorCalendarTest.BusinessLibrary.Tests
{
    [TestFixture]
    public class EventTests()
    { 
   
        [Test]
        public void FetchAll()
        {
            var dataPortal = Startup.GetRequiredService<Csla.IDataPortal<EventEditList>>(); 
            var list = dataPortal.Fetch();
            Assert.IsNotNull(list);
            Assert.That(list.Count > 0);
        }
        [Test]
        public void FetchEvent()
        {
            var dpEvent = Startup.GetRequiredService<Csla.IDataPortal<EventEdit>>();
            var dbEventList = Startup.GetRequiredService<Csla.IDataPortal<EventEditList>>();
            var list = dbEventList.Fetch();
            var evt = dpEvent.Fetch(list[0].Id);
            Assert.IsNotNull(evt);
        }
        [Test]
        public void InsertEvent()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventEdit>>();
            var c = dp.Create();
            var cId = c.Id;

            c.Title = "Test Event Test";
            c.Description = "Test Description";
            c.Organizer = "Test Organizer";
            c.StartDate = DateTime.Now;
            c.EndDate = DateTime.Now.AddHours(1);
            c.EventTypeId = 1;
            c = c.Save();
            var c2 = dp.Fetch(c.Id);

            Assert.That(c2 is not null);
        }
        [Test]
        public void UpdateEvent()
        {
            var dpEvtList = Startup.GetRequiredService<Csla.IDataPortal<EventEditList>>();
            var list = dpEvtList.Fetch();
            var evt = list[0];
            var dpEvent = Startup.GetRequiredService<Csla.IDataPortal<EventEdit>>();
            var evt2 = dpEvent.Fetch(evt.Id);
            evt2.Title = "Updated Event";
            var o = evt2.Save();
            var updatedEvt = dpEvent.Fetch(evt.Id);
            Assert.That("Updated Event" == updatedEvt.Title);
        }
        [Test]
        public void DeleteEvent()
        {
            var dp = Startup.GetRequiredService<Csla.IDataPortal<EventEdit>>();
            var evt = dp.Create();
            evt.Title = "Delete Test Event";
            evt = evt.Save();
            var evt2 = dp.Fetch(evt.Id);
            Assert.That(evt2 is not null);
            if(evt2 is not null)
            {
                evt2.Delete();
                var o2 = evt2.Save();
            }

            try
            {
                var evt3 = dp.Fetch(evt.Id);
            }
            catch
            {
                Assert.Pass();
            }
        }
     
    }
}