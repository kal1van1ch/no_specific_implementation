namespace StudentPortal.Middleware;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;


public class EnvMiddleware {
    
    private readonly RequestDelegate _next;
    private readonly ILogger<EnvMiddleware> _logger;

    public EnvMiddleware(RequestDelegate next, ILogger<EnvMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {
        List<string> lstOfEnvnames = new List<string>() { "Development", "Production" };

        var envName = context.Request.Query["envName"].ToString();

        if(string.IsNullOrEmpty(envName)) {
            _logger.LogInformation("No envName, defaulting to Production");
            envName = "Production";
        }

        if (!lstOfEnvnames.Contains(envName!)) {
            _logger.LogInformation("Access denied, no such environment: {envName}. Path: {path}", envName, context.Request.Path);
            context.Response.StatusCode = 403;
            context.Items["AccessError"] = $"Access denied, no such environment: {envName}";
        }
        else {
            _logger.LogInformation("Access granted, environment: {envName}. Path: {path}", envName, context.Request.Path);
            context.Items["realEnvName"] = envName;
            await _next(context);
            _logger.LogInformation("Finished: {status_code}", context.Response.StatusCode);
        }
    }
}