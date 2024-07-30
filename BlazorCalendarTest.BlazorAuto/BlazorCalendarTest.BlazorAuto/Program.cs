using Csla.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using BlazorCalendarTest.BlazorAuto;
using BlazorCalendarTest.BlazorAuto.Client;
using BlazorCalendarTest.BlazorAuto.Components;
using BlazorCalendarTest.Configuration;
using Microsoft.AspNetCore.Components.Endpoints.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add servicess to the container
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie();
// builder.Services.AddCascadingAuthenticationState();

// builder.Services.AddTransient<RenderModeProvider>();
// builder.Services.AddTransient<ActiveCircuitHandler>();
// builder.Services.AddScoped(typeof(CircuitHandler), typeof(ActiveCircuitHandler));

builder.Services.AddHttpContextAccessor();

builder.Services.AddCsla(o => o
    .AddAspNetCore()
    .AddServerSideBlazor(ssb => ssb.UseInMemoryApplicationContextManager = false));

builder.Services.AddDalMock();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorCalendarTest.BlazorAuto.Client._Imports).Assembly);

app.Run();
