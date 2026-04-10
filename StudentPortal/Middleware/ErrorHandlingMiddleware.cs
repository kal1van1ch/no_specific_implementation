namespace StudentPortal.Middleware;


public class ErrorHandlingMiddleware{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;  

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger){
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context){
        await _next(context);

        if (context.Response.StatusCode == 403) {
            if (context.Items.TryGetValue("AccessError", out var mess) && mess != null) {
                _logger.LogInformation("Forbidden access: {message}. Path: {path}", mess, context.Request.Path);
                var message = mess.ToString()!;
                await context.Response.WriteAsync(message);
            }
            else {
                _logger.LogInformation("Unknown error occurred. Path: {path}", context.Request.Path);
                await context.Response.WriteAsync("Another one error");
            }
        } 

        if (context.Response.StatusCode == 404) {
            _logger.LogInformation("Not Found: Path: {path}", context.Request.Path);
            await context.Response.WriteAsync("Not Found, nu zaplach");
        }    
    }

}