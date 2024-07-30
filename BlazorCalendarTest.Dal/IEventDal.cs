using System;
using System.Collections.Generic;

namespace BlazorCalendarTest.Dal
{
    public interface IEventDal
    {

        EventDto Fetch(Guid id);
        List<EventDto> Fetch(int calendarId);
        List<EventDto> Fetch(int calendarId, DateTime start, DateTime end);
        List<EventDto> Fetch();
        void Insert(EventDto calendar);
        void Update(EventDto calendar);
        void Delete(Guid id);
    }
}