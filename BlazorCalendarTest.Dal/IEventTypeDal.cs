namespace BlazorCalendarTest.Dal
{
    public interface IEventTypeDal
    {
        List<EventTypeDto> Fetch();
        EventTypeDto Fetch(int id);
        void Insert(EventTypeDto eventType);
        void Update(EventTypeDto eventType);
        void Delete(int id);
    }
    
}