namespace StudentPortal.Middleware;


public class AdminMiddleware {
    
    private readonly RequestDelegate _next;
    private readonly ILogger<AdminMiddleware> _logger;

    public AdminMiddleware(RequestDelegate next, ILogger<AdminMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {
        var root = bool.TryParse(context.Request.Query["sudo"], out bool isSudo);

        if (!isSudo) {
            _logger.LogInformation("Access denied, you are not an admin. Path: {path}", context);
            context.Items["AccessError"] = "You are not an admin";
            context.Response.StatusCode = 403;
        }
        else {
            _logger.LogInformation("Access granted, you are an admin. Path: {path}", context.Request.Path);
            await _next(context);
            _logger.LogInformation("Finished: {status_code}", context.Response.StatusCode); 
        }
    }
}