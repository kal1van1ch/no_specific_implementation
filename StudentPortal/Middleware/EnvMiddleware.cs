namespace StudentPortal.Middleware;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;


public class EnvMiddleware {
    
    private readonly RequestDelegate _next;

    public EnvMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        List<string> lstOfEnvnames = new List<string>() { "Development", "Production" };

        var envName = context.Request.Query["envName"].ToString();

        if(string.IsNullOrEmpty(envName)) {
            envName = "Development";
        }

        if (!lstOfEnvnames.Contains(envName!)) {
            context.Response.StatusCode = 403;
            context.Items["AccessError"] = $"Access denied, no such environment: {envName}";
        }
        else {
            context.Items["realEnvName"] = envName;
            await _next(context);
        }
    }
}