using System;
using Csla;
using BlazorCalendarTest.Dal;
using System.Reflection;

namespace BlazorCalendarTest.BusinessLibrary
{
    public enum EventStatus
    {
        OnHold = 0,
        Booked = 1
    }
    [Serializable]
    public class EventEdit : BusinessBase<EventEdit>
    {
        public static readonly PropertyInfo<Guid> IdProperty = RegisterProperty<Guid>(c => c.Id);
        public Guid Id
        {
            get => GetProperty(IdProperty);
            set => SetProperty(IdProperty, value);
        }

        public static readonly PropertyInfo<int> CalendarIdProperty = RegisterProperty<int>(c => c.CalendarId);
        public int CalendarId
        {
            get => GetProperty(CalendarIdProperty);
            set => SetProperty(CalendarIdProperty, value);
        }

        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title);
        public string Title
        {
            get => GetProperty(TitleProperty);
            set => SetProperty(TitleProperty, value);
        }
        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get => GetProperty(DescriptionProperty);
            set => SetProperty(DescriptionProperty, value);
        }
        public static readonly PropertyInfo<string> OrganizerProperty = RegisterProperty<string>(c => c.Organizer);
        public string Organizer
        {
            get => GetProperty(OrganizerProperty);
            set => SetProperty(OrganizerProperty, value);
        }

        public static readonly PropertyInfo<DateTime> StartDateProperty = RegisterProperty<DateTime>(c => c.StartDate);
        public DateTime StartDate
        {
            get => GetProperty(StartDateProperty);
            set => SetProperty(StartDateProperty, value);
        }

        public static readonly PropertyInfo<DateTime> EndDateProperty = RegisterProperty<DateTime>(c => c.EndDate);
        public DateTime EndDate
        {
            get => GetProperty(EndDateProperty);
            set => SetProperty(EndDateProperty, value);
        }
        public static readonly PropertyInfo<EventStatus> StatusProperty = RegisterProperty<EventStatus>(c => c.Status);
        public EventStatus Status
        {
            get => GetProperty(StatusProperty);
            set => SetProperty(StatusProperty, value);
        }
        public static readonly PropertyInfo<int> EventTypeIdProperty = RegisterProperty<int>(c => c.EventTypeId);
        public int EventTypeId
        {
            get => GetProperty(EventTypeIdProperty);
            set => SetProperty(EventTypeIdProperty, value);
        }
        public static readonly PropertyInfo<int> EventSpaceIdProperty = RegisterProperty<int>(c => c.EventSpaceId);
        public int EventSpaceId
        {
            get => GetProperty(EventSpaceIdProperty);
            set => SetProperty(EventSpaceIdProperty, value);
        }

        [Create]
        [RunLocal]
        private void Create()
        {
            LoadProperty(IdProperty, Guid.NewGuid());            
        }
        [CreateChild]
        private void CreateChild()
        {
            LoadProperty(IdProperty, Guid.NewGuid());
        }
        [Fetch]
        private void Fetch(Guid id, [Inject] IEventDal dal)
        {
            var data = dal.Fetch(id);
            LoadData(data);
        }
        private void LoadData(EventDto data)
        {
            using(BypassPropertyChecks)
            {
                Id = data.Id;
                CalendarId = data.CalendarId;
                Title = data.Title;
                Description = data.Description;                
                Organizer = data.Organizer;
                StartDate = data.StartDate;
                EndDate = data.EndDate;
                Status = data.Status == 0 ? EventStatus.OnHold : EventStatus.Booked;
                EventTypeId = data.EventTypeId;
                EventSpaceId = data.EventSpaceId;
            }
        }
        [FetchChild]
        private void FetchChild(EventDto data)
        {
            LoadData(data);
        }

        [Insert]
        private void Insert([Inject] IEventDal dal)
        {
            var data = new EventDto
            {
                Id = Id,
                CalendarId = CalendarId,
                Title = Title,
                Description = Description,
                Organizer = Organizer,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = (int)Status,
                EventTypeId = EventTypeId,
                EventSpaceId = EventSpaceId
            };
            dal.Insert(data);
        }
        [InsertChild]
        private void InsertChild(int calendarId, [Inject] IEventDal dal)
        {
            var data = new EventDto
            {
                Id = Id,
                CalendarId = calendarId,
                Title = Title,
                Description = Description,
                Organizer = Organizer,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = (int)Status,
                EventTypeId = EventTypeId,
                EventSpaceId = EventSpaceId
            };
            dal.Insert(data);
        }
        [Update]
        [UpdateChild]
        private void Update([Inject] IEventDal dal)
        {
            var data = new EventDto
            {
                Id = Id,
                CalendarId = CalendarId,
                Title = Title,
                Description = Description,
                Organizer = Organizer,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = (int)Status,
                EventTypeId = EventTypeId,
                EventSpaceId = EventSpaceId

            };
            dal.Update(data);
        }
        [Delete]
        private void Delete(Guid id, [Inject] IEventDal dal)
        {
            dal.Delete(id);
        }
        [DeleteSelf]
        private void DeleteSelf([Inject] IEventDal dal)
        {
            dal.Delete(Id);
        }
    }
}