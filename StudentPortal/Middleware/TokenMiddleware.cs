namespace StudentPortal.Middleware;


public class TokenMiddleware{
    private readonly RequestDelegate _next;
    private readonly ILogger<TokenMiddleware> _logger;  
    private readonly string _realToken;

    public TokenMiddleware(RequestDelegate next, ILogger<TokenMiddleware> logger, string realToken){
        _next = next;
        _logger = logger;
        _realToken = realToken;
    }

    public async Task InvokeAsync(HttpContext context){
        var token = context.Request.Query["token"];

        if (token != _realToken){
            _logger.LogInformation("Access denied, invalid token. Token: {token}, Path: {path}", token, context.Request.Path); 
            context.Items["AccessError"] = "Token is gaddem bad";
            context.Response.StatusCode = 403;
        }
        else{
            _logger.LogInformation("Access granted, valid token. Path: {path}", context.Request.Path);  
            await _next(context);
            _logger.LogInformation("Finished: {status_code}", context.Response.StatusCode);
        }
    }
}