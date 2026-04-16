namespace CampusRouteLab.Endpoints;


public static class PortalEndpoint {
    public static void MapPortalEndpoint(this WebApplication app) {
        app.Map("/portal/{module=home}/{page=index}/{id?}", (string module, string page, int? id) => {
            return Results.Text($"""
            Module: {module}
            Pge: {page}
            Id: {id ?? -1}
            """);
        });
    }
}