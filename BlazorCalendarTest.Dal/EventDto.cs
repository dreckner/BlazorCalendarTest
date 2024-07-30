using System;

namespace BlazorCalendarTest.Dal
{
    public class EventDto 
    {
        public Guid Id { get; set; }
        public int CalendarId { get; set; }
        public string Title {get;set;} = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public string Organizer { get; set; }   = string.Empty;
        public int EventTypeId { get; set; }
        public int EventSpaceId { get; set; }
    }

    
}