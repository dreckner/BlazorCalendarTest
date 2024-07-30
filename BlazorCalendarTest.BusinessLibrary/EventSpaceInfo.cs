using Csla;
using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.BusinessLibrary
{
    [Serializable]
    public class EventSpaceInfo : ReadOnlyBase<EventSpaceInfo>
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

        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get => GetProperty(DescriptionProperty);
            private set => LoadProperty(DescriptionProperty, value);
        }

        public static readonly PropertyInfo<int> CapacityProperty = RegisterProperty<int>(c => c.Capacity);
        public int Capacity
        {
            get => GetProperty(CapacityProperty);
            private set => LoadProperty(CapacityProperty, value);
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
        private void Fetch(EventSpaceDto data)
        {
            Id = data.Id;
            Name = data.Name;
            Description = data.Description;            
            Active = data.Active; 
        }
    }
}