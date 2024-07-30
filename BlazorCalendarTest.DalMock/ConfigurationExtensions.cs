using BlazorCalendarTest.DalMock;
using BlazorCalendarTest.Dal;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCalendarTest.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddDalMock(this IServiceCollection services)
        {
            services.AddTransient<IEventDal, EventDal>();
            services.AddTransient<ICalendarDal, CalendarDal>();
            services.AddTransient<IEventSpaceDal, EventSpaceDal>();
            services.AddTransient<IEventTypeDal, EventTypeDal>();
            return services;
        }
    }
}