using System;
using Csla;
using BlazorCalendarTest.Dal;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace BlazorCalendarTest.BusinessLibrary
{
    [Serializable]
    public class CalendarEdit : BusinessBase<CalendarEdit>
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

        public static readonly PropertyInfo<bool> ActiveProperty = RegisterProperty<bool>(c => c.Active);
        public bool Active
        {
            get => GetProperty(ActiveProperty);
            set => SetProperty(ActiveProperty, value);
        }
        public static readonly PropertyInfo<EventEditList> EventsProperty = RegisterProperty<EventEditList>(c => c.Events);
        public EventEditList Events
        {
            get => GetProperty(EventsProperty);
            private set => LoadProperty(EventsProperty, value);
        }

        [Create]
        [RunLocal]
        private void Create([Inject] IChildDataPortal<EventEditList> childDataPortal)
        {
            LoadProperty(EventsProperty, childDataPortal.CreateChild());
        }
        [Fetch]
        private void Fetch(int id, [Inject] ICalendarDal dal, [Inject] IChildDataPortal<EventEditList> childDataPortal)
        {
            var data = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id = data.Id;
                Name = data.Name;   
                Active = data.Active;
            }   
            Events = childDataPortal.FetchChild(id);
        }
        [Fetch]
        private void Fetch(int id, DateTime startDate, DateTime endDate, [Inject] ICalendarDal dal, [Inject] IChildDataPortal<EventEditList> childDataPortal)
        {

            var data = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id = data.Id;
                Name = data.Name;   
                Active = data.Active;
            }   
            Events = childDataPortal.FetchChild(id, startDate, endDate);
        }
        [Insert]
        private void Insert([Inject] ICalendarDal dal)
        {
            var data = new CalendarDto
            {
                Name = Name,
                Active = Active
            };
            dal.Insert(data);
            Id = data.Id;
            FieldManager.UpdateChildren();

        }
        [Update]
        private void Update([Inject] ICalendarDal dal)
        {
            var data = new CalendarDto
            {
                Id = Id,
                Name = Name,
                Active = Active
            };
            dal.Update(data);
            FieldManager.UpdateChildren(this.Id);
        }
        [Delete]
        private void Delete([Inject] ICalendarDal dal)
        {
            dal.Delete(Id);
        }
        [DeleteSelf]
        private void DeleteSelf([Inject] ICalendarDal dal)
        {
            dal.Delete(Id);
        }


    }
}