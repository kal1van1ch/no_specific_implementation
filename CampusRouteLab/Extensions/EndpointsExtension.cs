namespace CampusRouteLab.Extensions;

using CampusRouteLab.Endpoints;


public static class EndpointsExtension {
    public static WebApplication MapEndpoints(this WebApplication app) {
        app.MapRootEndpoint();
        app.MapStudentEndpoint();
        app.MapReportEndpoint();
        app.MapPortalEndpoint();
        app.MapFilesEndpoint();
        app.MapRouteEndpoint();
        app.MapDiagEndpoint();

        return app;
    }
}