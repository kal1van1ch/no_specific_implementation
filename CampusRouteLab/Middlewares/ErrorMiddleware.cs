namespace CampusRouteLab.Middlewares;


public class ErrorMiddleware {
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorMiddleware> _logger;

    public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {

        await _next(context);

        if (context.Response.StatusCode == 404) {
            _logger.LogInformation("Not Found: Path: {path}", context.Request.Path);
            await context.Response.WriteAsync("Unfortunately page not found");
        }
    }
}