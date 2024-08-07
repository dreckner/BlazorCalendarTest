using System;
using System.Collections.Generic;
using System.Linq;
using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.DalMock
{

    public class EventDal : IEventDal
    {
        public EventDto Fetch(Guid id)
        {
            var result = (from e in MockDb.Events
                where(e.Id == id)
                select new EventDto
                {
                    Id = e.Id,
                    CalendarId = e.CalendarId,
                    Title = e.Title,
                    Description = e.Description,
                    Organizer = e.Organizer,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Status = e.Status,
                    EventSpaceId = e.EventSpaceId
                })
                .FirstOrDefault();

            if(result is null)
                throw new DataNotFoundException("Event");
            
            return result;
        }

        public List<EventDto> Fetch(int calendarId)
        {
            var list = (from e in MockDb.Events
                        where e.CalendarId == calendarId
                        select new EventDto
                        {
                            Id = e.Id,
                            CalendarId = e.CalendarId,
                            Title = e.Title,
                            Description = e.Description,
                            Organizer = e.Organizer,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate,
                            Status = e.Status,
                            EventTypeId = e.EventTypeId,
                            EventSpaceId = e.EventSpaceId
                        }).ToList();

            return list;
        }
        public List<EventDto> Fetch(int calendarId, DateTime start, DateTime end)
        {
            var list = (from e in MockDb.Events
                        where e.CalendarId == calendarId
                        where (e.StartDate >= start || e.EndDate >= start)
                        where e.StartDate <= end
                        select new EventDto
                        {
                            Id = e.Id,
                            CalendarId = e.CalendarId,
                            Title = e.Title,
                            Description = e.Description,
                            Organizer = e.Organizer,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate,
                            Status = e.Status,
                            EventTypeId = e.EventTypeId,
                            EventSpaceId = e.EventSpaceId
                        }).ToList();

            return list;
        }
        public List<EventDto> Fetch()
        {
            var list = (from e in MockDb.Events
                        select new EventDto
                        {
                            Id = e.Id,
                            CalendarId = e.CalendarId,
                            Title = e.Title,
                            Description = e.Description,
                            Organizer = e.Organizer,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate,
                            Status = e.Status,
                            EventTypeId = e.EventTypeId,
                            EventSpaceId = e.EventSpaceId
                        }).ToList();

            return list;
        }

        public void Insert(EventDto eventDto)
        {
            
            MockDb.Events.Add(new MockDbTypes.EventData
            {
                Id = eventDto.Id,
                CalendarId = eventDto.CalendarId,
                Title = eventDto.Title,
                Description = eventDto.Description,
                Organizer = eventDto.Organizer,
                StartDate = eventDto.StartDate,
                EndDate = eventDto.EndDate,
                Status = eventDto.Status,
                EventTypeId = eventDto.EventTypeId,
                EventSpaceId = eventDto.EventSpaceId
            });
        }

        public void Update(EventDto eventDto)
        {
            var existingEvent = MockDb.Events
                .Where(e => e.Id == eventDto.Id)
                .FirstOrDefault();

            if (existingEvent != null)
            {
                existingEvent.CalendarId = eventDto.CalendarId;
                existingEvent.Title = eventDto.Title;
                existingEvent.Description = eventDto.Description;
                existingEvent.Organizer = eventDto.Organizer;
                existingEvent.StartDate = eventDto.StartDate;
                existingEvent.EndDate = eventDto.EndDate;
                existingEvent.Status = eventDto.Status;
                existingEvent.EventTypeId = eventDto.EventTypeId;
                existingEvent.EventSpaceId = eventDto.EventSpaceId;
            }
        }

        public void Delete(Guid id)
        {
            var existingEvent = MockDb.Events
                .Where(e => e.Id == id)
                .FirstOrDefault();

            if (existingEvent != null)
            {
                MockDb.Events.Remove(existingEvent);
            }
        }
    }
}