namespace BlazorCalendarTest.DalMock.MockDbTypes
{
    public class EventTypeData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HoldStyle { get; set; } = string.Empty;
        public string BookedStyle { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}