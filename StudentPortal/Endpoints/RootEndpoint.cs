namespace StudentPortal.Endpoints;


public static class RootEndpoint {
    public static void MapRootEndpoint(this WebApplication app) {
        app.MapGet("/", () => {
            return Results.Text($"""
            {"StudentPortal:\n"}
            {"/tools/time\n/tools/date\n/tools/info\n/env\n/secure/report\n/di/services"});
            """);
        });
    }
}