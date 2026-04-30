namespace HelpDesk.Endpoints;


public static class StatusEndpoint {
    public static void MapStatusEndpoint(this WebApplication app) {
        app.Map("/status/unauthorized", () => Results.Unauthorized());

        app.Map("/status/forbidden", () => Results.StatusCode(403));

        app.Map("/status/custom/418", () => Results.StatusCode(418));
    }
}