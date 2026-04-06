namespace StudentPortal.Middleware;


public class ErrorHandlingMiddleware{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        await _next(context);

        if (context.Response.StatusCode == 403) await context.Response.WriteAsync("Token is gaddem bad");

        if (context.Response.StatusCode == 404) await context.Response.WriteAsync("Not Found, nu zaplach");
    }

}