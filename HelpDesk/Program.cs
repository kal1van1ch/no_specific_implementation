using HelpDesk.Extensions;
using HelpDesk.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITicketRepository, InMemoryTicketRepository>();

var app = builder.Build();


app.MapExtension();
app.Run();
