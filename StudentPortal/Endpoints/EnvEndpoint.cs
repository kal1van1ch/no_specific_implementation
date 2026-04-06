namespace StudentPortal.Endpoints;
using StudentPortal.Services;


public static class EnvEndpoint {
    public static void MapEnvEndpoint(this WebApplication app) {
        app.MapGet("/env", (IEnvironmentReportService env) => {
            return env.BuildReport();
        });
    }
}