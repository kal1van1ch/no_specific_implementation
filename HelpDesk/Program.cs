using HelpDesk.Extensions;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapExtension();
app.Run();
