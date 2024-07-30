using Csla;
using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.BusinessLibrary
{

    [Serializable]
    public class CalendarInfoList : ReadOnlyListBase<CalendarInfoList, CalendarInfo>
    {
        [Fetch]
        private void Fetch([Inject] ICalendarDal dal, [Inject] IChildDataPortal<CalendarInfo> childDataPortal)
        {
            IsReadOnly = false;
            var list = dal.Fetch();
            foreach (var item in list)
            {
                Add(childDataPortal.FetchChild(item));
            }
            IsReadOnly = true;
        }
        
    }
}