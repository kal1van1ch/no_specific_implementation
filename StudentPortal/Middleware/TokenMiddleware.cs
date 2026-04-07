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
            context.Items["AccessError"] = "Token is gaddem bad";
            context.Response.StatusCode = 403;
        }
        else{
            await _next(context);
        }
    }
}