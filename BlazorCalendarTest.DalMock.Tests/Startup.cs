using Microsoft.Extensions.DependencyInjection;
using BlazorCalendarTest.Configuration;
using Csla.Configuration;

namespace BlazorCalendarTest.DalMock.Tests
{
    public class Startup
    {
        public static IServiceProvider Provider()
        {
            var services = new ServiceCollection();
            services.AddDalMock();
            services.AddCsla();
            return services.BuildServiceProvider();
        }
        public static T GetRequiredService<T>()
        {
            return Provider().GetRequiredService<T>();
        }
    }
}