namespace StudentPortal.Middleware;


public class TokenMiddleware{
    private readonly RequestDelegate _next;
    private readonly string _realToken;

    public TokenMiddleware(RequestDelegate next, string realToken){
        _next = next;
        _realToken = realToken;
    }

    public async Task InvokeAsync(HttpContext context){
        var token = context.Request.Query["token"];

        if (token != _realToken){
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Very bad token ayayayayyyyyyyy");
        }
        else{
            await _next(context);
        }
    }
}