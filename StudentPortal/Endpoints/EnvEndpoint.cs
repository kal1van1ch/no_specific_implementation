namespace StudentPortal.Endpoints;
using Microsoft.Extensions.Primitives;
using StudentPortal.Extensions;
using StudentPortal.Services;


public static class EnvEndpoint {
    public static void MapEnvEndpoint(this WebApplication app) {
        app.MapGet("/env", (IEnvironmentReportService env) => {            
            app.CheckEnv();

            
            return env.BuildReport();
        });
    }
}