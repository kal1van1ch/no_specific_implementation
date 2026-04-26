using CampusHub.ConfigCenter.Extensions;
using CampusHub.ConfigCenter.Middlewares;
using CampusHub.ConfigCenter.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddIniFile("notifications.ini");
builder.Configuration.AddXmlFile("portal.xml");
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile("appsettings.Development.json");
builder.Configuration.AddTextFile("customsettings.txt");
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddCommandLine(args);

builder.Services.Configure<NotificationOptions>(builder.Configuration.GetSection("Notifications"));
builder.Services.Configure<PortalOptions>(builder.Configuration.GetSection("Portal"));

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();
app.UseMiddleware<PortalHeaderMiddleware>();

app.MapEndpoints();

app.Run();
