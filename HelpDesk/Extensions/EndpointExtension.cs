namespace HelpDesk.Extensions;

using HelpDesk.Endpoints;


public static class EndpointExtension {
    public static WebApplication MapExtension(this WebApplication app) {
        app.MapRootEndpoint();
        app.MapAboutEndpoint();
        app.MapApiEndpoint();

        return app;
    }
}