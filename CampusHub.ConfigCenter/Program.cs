using CampusHub.ConfigCenter.Extensions;
using CampusHub.ConfigCenter.Middlewares;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json");

app.UseMiddleware<ErrorMiddleware>();

app.MapEndpoints();

app.Run();
