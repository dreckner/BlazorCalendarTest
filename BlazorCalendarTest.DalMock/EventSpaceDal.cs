using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.DalMock
{
    public class EventSpaceDal : IEventSpaceDal
    {
        public EventSpaceDto Fetch(int id)
        {
            var result = (from e in MockDb.EventSpaces
                          where e.Id == id
                          select new EventSpaceDto
                          {
                              Id = e.Id,
                              CalendarId = e.CalendarId,
                              Name = e.Name,
                              Description = e.Description,
                              Active = e.Active
                          }).FirstOrDefault();
            if(result is null)
                throw new DataNotFoundException("EventSpace");
                
            return result;
        }
        public List<EventSpaceDto> FetchForCalendar(int calendarId)
        {
            var result = (from e in MockDb.EventSpaces
                          where e.CalendarId == calendarId
                          select new EventSpaceDto
                          {
                              Id = e.Id,
                              CalendarId = e.CalendarId,
                              Name = e.Name,
                              Description = e.Description,
                              Active = e.Active
                          }).ToList();
            return result;
        }
        public void Insert(EventSpaceDto eventSpace)
        {
            int newId = MockDb.EventSpaces.Max(e => e.Id) + 1;  
            eventSpace.Id = newId;

            MockDb.EventSpaces.Add(new MockDbTypes.EventSpaceData
            {
                Id = eventSpace.Id,
                CalendarId = eventSpace.CalendarId,
                Name = eventSpace.Name,
                Description = eventSpace.Description,
                Active = eventSpace.Active
            });
        }
        public void Update(EventSpaceDto eventSpace)
        {
            var existing = MockDb.EventSpaces.FirstOrDefault(e => e.Id == eventSpace.Id);
            if (existing != null)
            {
                existing.CalendarId = eventSpace.CalendarId;
                existing.Name = eventSpace.Name;
                existing.Description = eventSpace.Description;
                existing.Active = eventSpace.Active;
            }
        }
        public void Delete(int id)
        {
            var existing = MockDb.EventSpaces.FirstOrDefault(e => e.Id == id);
            if (existing != null)
            {
                MockDb.EventSpaces.Remove(existing);
            }
        }   
    }

}