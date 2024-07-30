namespace BlazorCalendarTest.Dal
{
    public interface ICalendarDal
    {
        List<CalendarDto> Fetch();
        CalendarDto Fetch(int id);
        void Insert(CalendarDto calendar);
        void Update(CalendarDto calendar);
        void Delete(int id);
    }
    
}