using Csla;
using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.BusinessLibrary
{

    [Serializable]
    public class EventEditList : BusinessListBase<EventEditList, EventEdit>
    {
        protected override EventEdit AddNewCore()
        {
            var childDataPortal = ApplicationContext.GetRequiredService<IChildDataPortal<EventEdit>>();
            var item = childDataPortal.CreateChild();
            Add(item);
            return item;
        }
        [FetchChild]
        private void Fetch(int calendarId, [Inject] IEventDal dal, [Inject] IChildDataPortal<EventEdit> childDataPortal)
        {
            var list = dal.Fetch(calendarId);
            foreach (var item in list)
            {
                Add(childDataPortal.FetchChild(item));
            }
        }

        [FetchChild]
        private void Fetch(int calendarId, DateTime startDate, DateTime endDate, [Inject] IEventDal dal, [Inject] IChildDataPortal<EventEdit> childDataPortal)
        {
            var list = dal.Fetch(calendarId, startDate, endDate);
            foreach (var item in list)
            {
                Add(childDataPortal.FetchChild(item));
            }
        }
    }
}