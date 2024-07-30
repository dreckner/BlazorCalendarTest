using Csla;
using BlazorCalendarTest.Dal;

namespace BusinessCalendarTest.BusinessLibrary
{

    [Serializable]
    public class EventTypeInfo : ReadOnlyBase<EventTypeInfo>
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

        public static readonly PropertyInfo<string> BookedStyleProperty = RegisterProperty<string>(c => c.BookedStyle);
        public string BookedStyle
        {
            get => GetProperty(BookedStyleProperty);
            private set => LoadProperty(BookedStyleProperty, value);
        }

        public static readonly PropertyInfo<string> HoldStyleProperty = RegisterProperty<string>(c => c.HoldStyle);
        public string HoldStyle
        {
            get => GetProperty(HoldStyleProperty);
            private set => LoadProperty(HoldStyleProperty, value);
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
        { }

        [FetchChild]
        private void Fetch(EventTypeDto data)
        {
            Id = data.Id;
            Name = data.Name;
            BookedStyle = data.BookedStyle;
            HoldStyle = data.HoldStyle;
            Active = data.Active; 
        }
    }

}