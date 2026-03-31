using TaskManager.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("1. WebApplicationBuilder создан");
Console.WriteLine($"2. Окружение: {builder.Environment.EnvironmentName}");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapApplicationEndpoints();

app.Run();