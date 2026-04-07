using StudentPortal.Extensions;
using StudentPortal.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Console.WriteLine("1. WebApplicationBuilder создан");
Console.WriteLine($"2. Окружение: {builder.Environment.EnvironmentName}");

builder.Services.AddStudentPortalServices();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();


app.Use(async (context, next) => {
    Console.WriteLine($"Start: {context.Request.Path}");
    await next(context);
    Console.WriteLine($"End: {context.Request.Path}");
});


app.UseWhen(context => context.Request.Query.ContainsKey("trace") && context.Request.Query["trace"] == "true", branch => {
    branch.Use(async (ctx, next) => {
        Console.WriteLine("trace = true");
        await next(ctx);
    });
});

app.MapWhen(context => context.Request.Query.ContainsKey("format") && context.Request.Query["format"] == "plain", branch => {
    branch.Run(async ctx => {
        ctx.Response.ContentType = "text/plain; charset=utf-8";
        await ctx.Response.WriteAsync("MapWhen, dumal ya tupoy?");
    });
});

app.MapEndpoints(builder.Services);

app.Run();


