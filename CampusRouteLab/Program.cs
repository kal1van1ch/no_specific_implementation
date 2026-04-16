using CampusRouteLab.Extensions;
using CampusRouteLab.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.WriteIndented = true;
});
builder.Services.AddCampusServices();

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();

app.MapEndpoints();

app.Run();