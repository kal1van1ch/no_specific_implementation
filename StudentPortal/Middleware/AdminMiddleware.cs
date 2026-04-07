namespace StudentPortal.Middleware;


public class AdminMiddleware {
    
    private readonly RequestDelegate _next;

    public AdminMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        var root = bool.TryParse(context.Request.Query["sudo"], out bool isSudo);

        if (!isSudo) {
            context.Items["AccessError"] = "You are not an admin";
            context.Response.StatusCode = 403;
        }
        else {
            await _next(context);
        }
    }
}