using Csla;
using BlazorCalendarTest.Dal;
using BusinessCalendarTest.BusinessLibrary;

namespace BlazorCalendarTest.BusinessLibrary
{
    [Serializable]
    public class EventTypeInfoList : ReadOnlyListBase<EventTypeInfoList, EventTypeInfo>
    {
        [Fetch]
        private void Fetch([Inject] IEventTypeDal dal, [Inject] IChildDataPortal<EventTypeInfo> childDataPortal)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            IsReadOnly = false;
            var list = dal.Fetch();
            foreach(var item in list)
                Add(childDataPortal.FetchChild(item));

            RaiseListChangedEvents = rlce;
        }
    }
}