using Csla;
using BlazorCalendarTest.Dal;   

namespace BlazorCalendarTest.BusinessLibrary
{
    [Serializable]
    public class EventSpaceInfoList : ReadOnlyListBase<EventSpaceInfoList, EventSpaceInfo>
    {
        [Fetch]
        private void Fetch(int calendarId, [Inject] IEventSpaceDal dal, [Inject] IChildDataPortal<EventSpaceInfo> childDataPortal)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;
            var list = dal.FetchForCalendar(calendarId);
            foreach(var item in list)
                Add(childDataPortal.FetchChild(item));

            RaiseListChangedEvents = rlce;
        }
    }
}