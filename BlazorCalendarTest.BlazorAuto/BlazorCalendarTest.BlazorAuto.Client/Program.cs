using Csla.Configuration;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCalendarTest.BlazorAuto;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddTransient<RenderModeProvider>();
//builder.Services.AddScoped<ActiveCircuitState>();

builder.Services.AddMemoryCache();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddCsla(o => o
    .AddBlazorWebAssembly()
    .DataPortal(o => o.ClientSideDataPortal(o => o
        .UseHttpProxy(o => o.DataPortalUrl = "/api/DataPortal"))));

await builder.Build().RunAsync();
