using BlazorCalendarTest.Dal;
using BlazorCalendarTest.DalMock.MockDbTypes;

namespace BlazorCalendarTest.DalMock
{
    public class EventTypeDal : IEventTypeDal
    {
        public List<EventTypeDto> Fetch()
        {
            var list = (from t in MockDb.EventTypes
                        select new EventTypeDto
                        {
                            Id = t.Id,
                            Name = t.Name,
                            HoldStyle = t.HoldStyle,
                            BookedStyle = t.BookedStyle,
                            Active = t.Active
                        }).ToList();
            return list;
        }

        public EventTypeDto Fetch(int id)
        {
            var result = (from t in MockDb.EventTypes
                          where t.Id == id
                          select new EventTypeDto
                          {
                              Id = t.Id,
                              Name = t.Name,
                              HoldStyle = t.HoldStyle,
                              BookedStyle = t.BookedStyle,
                              Active = t.Active
                          }).FirstOrDefault();
            if (result == null)
                throw new DataNotFoundException("EventType");
                
            return result;
        }

        public void Insert(EventTypeDto eventType)
        {
            var nextId = MockDb.EventTypes.Max(t => t.Id) + 1;
            eventType.Id = nextId;
            MockDb.EventTypes.Add(new EventTypeData
            {
                Id = eventType.Id,
                Name = eventType.Name,
                HoldStyle = eventType.HoldStyle,
                BookedStyle = eventType.BookedStyle,
                Active = eventType.Active
            });
        }

        public void Update(EventTypeDto eventType)
        {
            var existing = MockDb.EventTypes.FirstOrDefault(t => t.Id == eventType.Id);
            if (existing != null)
            {
                existing.Name = eventType.Name;
                existing.HoldStyle = eventType.HoldStyle;
                existing.BookedStyle = eventType.BookedStyle;
                existing.Active = eventType.Active;
            }
            else
            {
                throw new DataNotFoundException("EventType");
            }
        }

        public void Delete(int id)
        {
            var existing = MockDb.EventTypes.FirstOrDefault(t => t.Id == id);
            if (existing != null)
            {
                MockDb.EventTypes.Remove(existing);
            }
            else
            {
                throw new DataNotFoundException("EventType");
            }
        }
    }
}