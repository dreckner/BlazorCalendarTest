using Csla;
using BlazorCalendarTest.Dal;
using System.Globalization;

namespace BlazorCalendarTest.BusinessLibrary
{
    [Serializable]
    public class CalendarInfo : ReadOnlyBase<CalendarInfo>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get => GetProperty(IdProperty);
            private set => LoadProperty(IdProperty, value);
        }
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get => GetProperty(NameProperty);
            private set => LoadProperty(NameProperty, value);
        }
        public static readonly PropertyInfo<bool> ActiveProperty = RegisterProperty<bool>(c => c.Active);
        public bool Active
        {
            get => GetProperty(ActiveProperty);
            private set => LoadProperty(ActiveProperty, value);
        }

        [Create]
        [RunLocal]
        private void Create()
        {}

        [FetchChild]
        private void Fetch(CalendarDto data)
        {
            Id = data.Id;
            Name = data.Name;
            Active = data.Active;
        }
        

    }

}