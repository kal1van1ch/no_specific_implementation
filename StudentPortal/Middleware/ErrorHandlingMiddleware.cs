namespace StudentPortal.Middleware;


public class ErrorHandlingMiddleware{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        await _next(context);

        if (context.Response.StatusCode == 403) {
            if (context.Items.TryGetValue("AccessError", out var mess) && mess != null) {
                var message = mess.ToString()!;
                await context.Response.WriteAsync(message);
            }
            else {
                await context.Response.WriteAsync("Another one error");
            }
        } 

        if (context.Response.StatusCode == 404) await context.Response.WriteAsync("Not Found, nu zaplach");
    }

}