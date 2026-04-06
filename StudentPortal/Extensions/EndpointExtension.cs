namespace StudentPortal.Extensions;
using StudentPortal.Endpoints;


public static class EndPointExtension {
    public static WebApplication MapEndpoints(this WebApplication app) {
        app.MapRootEndpoint();
        app.MapToolsEndpoint();
        app.MapSecureEndpoint();
        app.MapEnvEndpoint();
        app.MapDIEndpoint();

        return app;
    }
}