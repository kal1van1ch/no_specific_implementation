namespace CampusHub.ConfigCenter.Extensions;

using CampusHub.ConfigCenter.Endpoints;


public static class EndpointExtension {
    public static WebApplication MapEndpoints(this WebApplication app) {
        app.MapRootEndpoint();
        app.MapConfigEndpoint();

        return app;
    }
}