namespace BlazorCalendarTest.Dal
{
    public interface IEventSpaceDal
    {
        EventSpaceDto Fetch(int id);
        List<EventSpaceDto> FetchForCalendar(int calendarId);
        void Insert(EventSpaceDto eventSpace);
        void Update(EventSpaceDto eventSpace);
        void Delete(int id);
    }
}