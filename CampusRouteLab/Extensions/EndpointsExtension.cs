namespace CampusRouteLab.Extensions;

using CampusRouteLab.Endpoints;


public static class EndpointsExtension {
    public static WebApplication MapEndpoints(this WebApplication app) {
        app.MapStudentEndpoint();
        app.MapReportEndpoint();
        app.MapPortalEndpoint();
        app.MapFilesEndpoint();

        return app;
    }
}