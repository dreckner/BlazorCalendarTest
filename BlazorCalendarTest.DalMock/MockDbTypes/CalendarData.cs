using System;

namespace BlazorCalendarTest.DalMock.MockDbTypes
{
    public class CalendarData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}