using AirportAPI.HubTower;
using AirportAPI.Logic;
using AirportAPI.Services;
using AirportAPI.Services.ControlTower;
using AirportAPI.Services.Schedualer;
using DatabaseContext;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<DBContext>(options => options.UseSqlite($"Data Source=AirportLogsSimulator.db"), ServiceLifetime.Singleton);
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<FlightRepository, FlightRepository>();
builder.Services.AddSingleton<IAirportService, AirportService>();
builder.Services.AddSingleton<ILegsService, LegsService>();
builder.Services.AddSingleton<ControlTower>();
builder.Services.AddSingleton<SchedualLandingFlights>();
builder.Services.AddSingleton<ControlTowerHub>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<DBContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ControlTowerHub>("/airport");
    endpoints.MapControllers();
});

app.MapGet("/", () => "Hello World!");

app.Run();