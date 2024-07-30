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
            Calendars.Add(new CalendarData { Id = 0, Name = "Default Calendar", Active = true });
            Calendars.Add(new CalendarData { Id = 1, Name = "Calendar 1", Active = true });
            Calendars.Add(new CalendarData { Id = 2, Name = "Calendar 2", Active = false });

            Events.Add(new EventData
            {
                Id = Guid.NewGuid(),
                CalendarId = 0,
                Title = "Event 0",
                Description = "Description of Event 0",
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(5),
                Organizer = "Organizer 0",
                Status = 0,
                EventTypeId = 1,
                EventSpaceId = 0
            });

            Events.Add(new EventData
            {
                Id = Guid.NewGuid(),
                CalendarId = 0,
                Title = "Event 00",
                Description = "Description of Event 00",
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now.AddDays(4),
                Organizer = "Organizer 00",
                Status = 1,
                EventTypeId = 2,
                EventSpaceId = 1
            });

            Events.Add(new EventData
            {
                Id = Guid.NewGuid(),
                CalendarId = 0,
                Title = "Event 000",
                Description = "Description of Event 000",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(3),
                Organizer = "Organizer 000",
                Status = 0,
                EventTypeId = 3,
                EventSpaceId = 2
            });

            Events.Add(new EventData
            {
                Id = Guid.NewGuid(),
                CalendarId = 1,
                Title = "Event 1",
                Description = "Description of Event 1",                
                StartDate = DateTime.Now.AddDays(-5),
                EndDate = DateTime.Now.AddDays(14),
                Organizer = "Organizer 1",   
                Status = 1,
                EventTypeId = 1,
                EventSpaceId = 1             
            });

            Events.Add(new EventData
            {
                Id = Guid.NewGuid(),
                CalendarId = 1,
                Title = "Event 2",                
                Description = "Description of Event 2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Organizer = "Organizer 2",
                Status = 1,
                EventTypeId = 2,
                EventSpaceId = 2
            });

            Events.Add(new EventData
            {
                Id = Guid.NewGuid(),
                CalendarId = 2,
                Title = "Event 3",
                Description = "Description of Event 3",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Organizer = "Organizer 3", 
                Status = 0,
                EventTypeId = 3,
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