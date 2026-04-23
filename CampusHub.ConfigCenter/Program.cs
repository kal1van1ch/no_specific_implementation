using CampusHub.ConfigCenter.Extensions;
using CampusHub.ConfigCenter.Middlewares;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();

app.MapEndpoints();

app.Run();
