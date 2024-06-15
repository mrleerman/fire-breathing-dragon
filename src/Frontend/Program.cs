using System.Reflection;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Frontend;
using Frontend.Options;
using Frontend.Services.CombatConnection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped<ICombatConnection, CombatConnection>();

builder.Services.Configure<ConnectionOptions>(builder.Configuration.GetSection(ConnectionOptions.Key));

// Add Fluxor
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(Assembly.GetExecutingAssembly());
    options.UseReduxDevTools();
});

await builder.Build().RunAsync();
