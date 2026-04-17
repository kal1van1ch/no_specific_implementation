namespace CampusRouteLab.Middlewares;

using CampusRouteLab.Services;


public class RequestAuditMiddleware {

    private readonly RequestDelegate _next;
    private readonly IAppInfoService _app;
    private readonly ILogger<RequestAuditMiddleware> _logger;
    public RequestAuditMiddleware(RequestDelegate next, IAppInfoService app, ILogger<RequestAuditMiddleware> logger) {
        _next = next;
        _app = app;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, IRequestContextService request, ITransientMarkerService marker) {
        _logger.LogInformation("Strat");

        context.Response.OnStarting(() => {

            context.Response.Headers["X-App-Instance"] = _app.AppInstanceId.ToString();
            context.Response.Headers["X-Request-Id"] = request.RequestId.ToString();
            context.Response.Headers["X-Transient-Id"] = marker.Id.ToString();

            _logger.LogInformation("Only after _next(context)");

            return Task.CompletedTask;
        });

        _logger.LogInformation("before _next(context)");

        await _next(context);

        _logger.LogInformation("End");
    }
}