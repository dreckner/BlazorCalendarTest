using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.DalMock
{

    public class CalendarDal : ICalendarDal
    {
        public CalendarDto Fetch(int id)
        {
            var result = (from c in MockDb.Calendars
                         where c.Id == id
                         select new CalendarDto
                         {
                             Id = c.Id,
                             Name = c.Name,
                             Active = c.Active
                         }).FirstOrDefault();

            if (result == null)
                throw new DataNotFoundException("Calendar");
            
            return result;
        }

        public void Insert(CalendarDto calendar)
        {
            calendar.Id = MockDb.Calendars.Max(c => c.Id) + 1;
        
            var data = new MockDbTypes.CalendarData
            {
                Id = calendar.Id,
                Name = calendar.Name,
                Active = calendar.Active
            };
            MockDb.Calendars.Add(data);
        }

        public void Update(CalendarDto calendar)
        {
            var calendarData = MockDb.Calendars.Find(c => c.Id == calendar.Id);

            if(calendarData == null)
                throw new DataNotFoundException("Calendar");
                
            if (calendarData != null)
            {
                calendarData.Name = calendar.Name;
                calendarData.Active = calendar.Active;
            }
        }

        public void Delete(int id)
        {
            var calendarData = MockDb.Calendars.Find(c => c.Id == id);
            if (calendarData != null)
            {
                MockDb.Calendars.Remove(calendarData);
            }
        }

        public List<CalendarDto> Fetch()
        {
            var list = (from c in MockDb.Calendars
                        select new CalendarDto
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Active = c.Active
                        }).ToList();
            return list;
        }
    }
}