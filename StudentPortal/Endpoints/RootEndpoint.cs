namespace StudentPortal.Endpoints;


public static class RootEndpoint {
    public static void MapRootEndpoint(this WebApplication app) {
        app.MapGet("/", () => {
            return Results.Text($"""
            {"StudentPortal:"}
            {"/tools/time\n/tools/date\n/tools/info\n/env\n/secure/admin/report\n/di/services"}
            """);
        });
    }
}
