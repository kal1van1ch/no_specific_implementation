using HelpDesk.Extensions;
using HelpDesk.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITicketRepository, InMemoryTicketRepository>();

var app = builder.Build();

// app.Environment.EnvironmentName = "Production";

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}
else {
    app.UseExceptionHandler("/error/exception");
}

app.UseStatusCodePagesWithReExecute("/error/status/{0}");

app.MapExtension();
app.Run();
