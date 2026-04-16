namespace CampusRouteLab.Endpoints;


public static class RouteEndpoint {
    public static void MapRouteEndpoint(this WebApplication app) {
        app.Map("/routes", (IEnumerable<EndpointDataSource> endpds) =>
        string.Join("\n", endpds.SelectMany(source => source.Endpoints)));
    }
}