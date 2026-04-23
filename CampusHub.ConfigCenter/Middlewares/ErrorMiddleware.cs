namespace CampusHub.ConfigCenter.Middlewares;


public class ErrorMiddleware {

    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorMiddleware> _logger;

    public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {
        _logger.LogInformation("Начало обработки запроса. Путь: {path}", context.Request.Path);

        await _next(context);

        if (context.Response.StatusCode == 404) {
            _logger.LogInformation("Неизвестный путь. Путь: {path}", context.Request.Path);
            await context.Response.WriteAsync("Page not found");
            return;
        }
        _logger.LogInformation("Конец обработки запроса. Путь: {path}", context.Request.Path);
    }
}