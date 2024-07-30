using Csla;
using BlazorCalendarTest.Dal;

namespace BlazorCalendarTest.BusinessLibrary
{
    [Serializable]
    public class EventSpaceEdit : BusinessBase<EventSpaceEdit>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get => GetProperty(IdProperty);
            set => SetProperty(IdProperty, value);
        }
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get => GetProperty(NameProperty);
            set => SetProperty(NameProperty, value);
        }
        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get => GetProperty(DescriptionProperty);
            set => SetProperty(DescriptionProperty, value);
        }
        public static readonly PropertyInfo<int> CapacityProperty = RegisterProperty<int>(c => c.Capacity);
        public int Capacity
        {
            get => GetProperty(CapacityProperty);
            set => SetProperty(CapacityProperty, value);
        }
        public static readonly PropertyInfo<bool> ActiveProperty = RegisterProperty<bool>(c => c.Active);
        public bool Active
        {
            get => GetProperty(ActiveProperty);
            set => SetProperty(ActiveProperty, value);
        }

        [Create]
        [RunLocal]
        private void Create()
        {}
        [Fetch]
        private void Fetch(int id, [Inject] IEventSpaceDal dal)
        {
            var data = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id = data.Id;
                Name = data.Name;
                Description = data.Description;
                Active = data.Active;
            }
        }
        [Insert]
        private void Insert([Inject] IEventSpaceDal dal)
        {
            var data = new EventSpaceDto
            {
                Name = Name,
                Description = Description,                
                Active = Active
            };
            dal.Insert(data);
            Id = data.Id;
        }
        [Update]
        private void Update([Inject] IEventSpaceDal dal)
        {
            var data = new EventSpaceDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Active = Active
            };
            dal.Update(data);
        }
        [DeleteSelf]
        private void Delete([Inject] IEventSpaceDal dal)
        {
            Delete(Id, dal);
        }
        [Delete]
        private void Delete(int id, [Inject] IEventSpaceDal dal)
        {
            dal.Delete(id);
        }
    }
}