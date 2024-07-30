using Microsoft.Extensions.DependencyInjection;
using BlazorCalendarTest.Configuration;
using Csla.Configuration;
using BlazorCalendarTest.DalMock;

namespace BlazorCalendarTest.BusinessLibrary.Tests
{
    public static class Startup
    {
        private static IServiceProvider Provider(){
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