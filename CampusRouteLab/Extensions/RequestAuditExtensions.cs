namespace CampusRouteLab.Extensions;

using CampusRouteLab.Middlewares;

public static class RequestAuditExtension {
    public static IApplicationBuilder UseRequestAudit(this IApplicationBuilder app) {
        return app.UseMiddleware<RequestAuditMiddleware>();
    }
}