namespace BlazorCalendarTest.Dal
{
    public class EventSpaceDto
    {
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
    }
}