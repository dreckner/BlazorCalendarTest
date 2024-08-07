using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazorCalendarTest.DalMock.MockDbTypes;

namespace BlazorCalendarTest.DalMock
{
    public static class MockDb
    {
        public static List<CalendarData> Calendars { get; set; } = new List<CalendarData>();
        public static List<EventData> Events { get; set; } = new List<EventData>();
        public static List<EventTypeData> EventTypes { get; set; } = new List<EventTypeData>();
        public static List<EventSpaceData> EventSpaces { get; set; } = new List<EventSpaceData>();
        

        static MockDb()
        {
            Calendars.Add(new CalendarData { Id = 0, Name = "Calendar 0", Active = true });
            Calendars.Add(new CalendarData { Id = 1, Name = "Calendar 1", Active = true });
            Calendars.Add(new CalendarData { Id = 2, Name = "Calendar 2", Active = false });

            var eventId0 = Guid.NewGuid();
            Events.Add(new EventData
            {
                Id = eventId0,
                CalendarId = 0,
                Title = "Event 0",
                Description = "Description of Event 0",
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(5),
                Organizer = "Organizer 0",
                Status = 0,
                EventTypeId = 1,
                EventSpaceId = 1
            });
            var eventId1 = Guid.NewGuid();
            Events.Add(new EventData
            {
                Id = eventId1,
                CalendarId = 0,
                Title = "Event 00",
                Description = "Description of Event 00",
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(4),
                Organizer = "Organizer 00",
                Status = 1,
                EventTypeId = 1,
                EventSpaceId = 1
            });
            var eventId2 = Guid.NewGuid();
            Events.Add(new EventData
            {
                Id = eventId2,
                CalendarId = 0,
                Title = "Event 000",
                Description = "Description of Event 000",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(3),
                Organizer = "Organizer 000",
                Status = 0,
                EventTypeId = 1,
                EventSpaceId = 2
            });
            var eventId3 = Guid.NewGuid();
            Events.Add(new EventData
            {
                Id = eventId3,
                CalendarId = 1,
                Title = "Event 1",
                Description = "Description of Event 1",                
                StartDate = DateTime.Now.AddDays(-5),
                EndDate = DateTime.Now.AddDays(14),
                Organizer = "Organizer 1",   
                Status = 1,
                EventTypeId = 2,
                EventSpaceId = 1             
            });
            var eventId4 = Guid.NewGuid();
            Events.Add(new EventData
            {
                Id = eventId4,
                CalendarId = 1,
                Title = "Event 11",                
                Description = "Description of Event 11",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(2),
                Organizer = "Organizer 2",
                Status = 1,
                EventTypeId = 3,
                EventSpaceId = 2
            });
            var eventId5 = Guid.NewGuid();
            Events.Add(new EventData
            {
                Id = eventId5,
                CalendarId = 2,
                Title = "Event 2",
                Description = "Description of Event 2",
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(7),
                Organizer = "Organizer 3", 
                Status = 0,
                EventTypeId = 1,
                EventSpaceId = 3               
            });

            EventSpaces.Add(new EventSpaceData { Id = 1, CalendarId = 1, Name = "MPR", Description = "Multipurpose Room", Active = true });
            EventSpaces.Add(new EventSpaceData { Id = 2, CalendarId = 1, Name = "FG", Description = "Focus Group Room", Active = false });
            EventSpaces.Add(new EventSpaceData { Id = 3, CalendarId = 1, Name = "KIT", Description = "Kitchen", Active = true });
            EventSpaces.Add(new EventSpaceData { Id = 4, CalendarId = 2, Name = "IDI", Description = "One on One Room", Active = false });
            EventSpaces.Add(new EventSpaceData { Id = 5, CalendarId = 2, Name = "HUT", Description = "Home Use Test Placement & Return", Active = true });
            EventSpaces.Add(new EventSpaceData { Id = 6, CalendarId = 2, Name = "OFF", Description = "Offsite", Active = false });

            EventSpaces.Add(new EventSpaceData { Id = 1, CalendarId = 0, Name = "MPR", Description = "Multipurpose Room", Active = true });
            EventSpaces.Add(new EventSpaceData { Id = 2, CalendarId = 0, Name = "FG", Description = "Focus Group Room", Active = false });
            EventSpaces.Add(new EventSpaceData { Id = 3, CalendarId = 0, Name = "KIT", Description = "Kitchen", Active = true });

            EventTypes.Add(new EventTypeData { Id = 1, Name = "Test", Active = true, BookedStyle = "background-color: steelblue; color: white", HoldStyle = "background-color: powderblue; color: gray" });
            EventTypes.Add(new EventTypeData { Id = 2, Name = "Meeting", BookedStyle = "background-color: silver; color: black", HoldStyle = "background-color: darkgray; color: gainsboro", Active = false });
            EventTypes.Add(new EventTypeData { Id = 3, Name = "PTO", BookedStyle = "background-color: gold; color: black", HoldStyle = "background-color: khaki; color: darkgray", Active = true });
            EventTypes.Add(new EventTypeData { Id = 4, Name = "Offsite", BookedStyle = "background-color: darkorange; color: black", HoldStyle = "background-color: lightsalmon; color: white", Active = false });
            EventTypes.Add(new EventTypeData { Id = 5, Name = "HUT", BookedStyle = "background-color: firebrick; color: black", HoldStyle = "background-color: lightcoral; color: lightgray", Active = true });
            
        }

    }

}