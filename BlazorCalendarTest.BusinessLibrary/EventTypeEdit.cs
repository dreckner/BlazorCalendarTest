using Csla;
using BlazorCalendarTest.Dal;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCalendarTest.BusinessLibrary
{
    [Serializable]
    public class EventTypeEdit : BusinessBase<EventTypeEdit>
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
        public static readonly PropertyInfo<string> BookedStyleProperty = RegisterProperty<string>(c => c.BookedStyle);
        public string BookedStyle
        {
            get => GetProperty(BookedStyleProperty);
            set => SetProperty(BookedStyleProperty, value);
        }
        public static readonly PropertyInfo<string> HoldStyleProperty = RegisterProperty<string>(c => c.HoldStyle);
        public string HoldStyle
        {
            get => GetProperty(HoldStyleProperty);
            set => SetProperty(HoldStyleProperty, value);
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
        private void Fetch(int id, [Inject] IEventTypeDal dal)
        {
            var data = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id = data.Id;
                Name = data.Name;
                BookedStyle = data.BookedStyle;
                HoldStyle = data.HoldStyle;
                Active = data.Active;
            }
        }
        [Insert]
        private void Insert([Inject] IEventTypeDal dal)
        {
            var data = new EventTypeDto
            {
                Name = Name,
                BookedStyle = BookedStyle,
                HoldStyle = HoldStyle,
                Active = Active
            };
            dal.Insert(data);
            Id = data.Id;
        }
        [Update]
        private void Update([Inject] IEventTypeDal dal)
        {
            var data = new EventTypeDto
            {
                Id = Id,
                Name = Name,
                BookedStyle = BookedStyle,
                HoldStyle = HoldStyle,
                Active = Active
            };
            dal.Update(data);
        }
        [DeleteSelf]
        private void Delete([Inject] IEventTypeDal dal)
        {
            Delete(Id, dal);
        }
        [Delete]
        private void Delete(int id, [Inject] IEventTypeDal dal)
        {
            dal.Delete(id);
        }
    }
}