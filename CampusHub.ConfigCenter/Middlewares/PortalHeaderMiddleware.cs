namespace CampusHub.ConfigCenter.Middlewares;

using CampusHub.ConfigCenter.Models;
using Microsoft.Extensions.Options;

public class PortalHeaderMiddleware {
    private readonly RequestDelegate _next;
    public NotificationOptions _notification;
    public PortalOptions _portal;

    public PortalHeaderMiddleware(RequestDelegate next, IOptions<NotificationOptions> notification, IOptions<PortalOptions> portal) {
        _next = next;
        _notification = notification.Value;
        _portal = portal.Value;
    }

    public async Task InvokeAsync(HttpContext context) {
        context.Response.Headers["X-Portal-Title"] = _portal.Title;
        context.Response.Headers["XPortal-Semester"] = _portal.Semester;

        await _next(context);
    }
}