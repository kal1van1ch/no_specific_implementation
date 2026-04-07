namespace StudentPortal.Extensions;
using StudentPortal.Endpoints;


public static class EndPointExtension {
    public static WebApplication MapEndpoints(this WebApplication app, IServiceCollection serv) {
        app.MapRootEndpoint();
        app.MapToolsEndpoint();
        app.MapSecureEndpoint();
        app.MapEnvEndpoint();
        app.MapDIEndpoint(serv);

        return app;
    }
}