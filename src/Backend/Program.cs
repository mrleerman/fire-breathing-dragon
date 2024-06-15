using System.Reflection;
using Backend.Hubs;
using Fluxor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddSignalR();

builder.Services.AddFluxor(x => x
    .ScanAssemblies(Assembly.GetExecutingAssembly())
    .WithLifetime(StoreLifetime.Singleton));

var app = builder.Build();

app.UseCors();

var hubBuilder = app.MapHub<CombatHub>("/hubs/combat");
var clientCorsUrl = app.Configuration.GetValue<string>("ClientAppUrl");
if (!string.IsNullOrEmpty(clientCorsUrl))
{ 
    hubBuilder
        .RequireCors(policyBuilder => policyBuilder
            .WithOrigins(clientCorsUrl)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
}

var fluxorStore = app.Services.GetService<IStore>() ?? throw new Exception("Required Fluxor Store not found.");
await fluxorStore.InitializeAsync();

app.Run();
