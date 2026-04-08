namespace StudentPortal.Endpoints;
using StudentPortal.Extensions;
using StudentPortal.Services;


public static class EnvEndpoint {
    public static void MapEnvEndpoint(this WebApplication app) {
        app.Map("/env", envMap => {            
            envMap.CheckEnv();


            envMap.Run(async context => {

                var env = context.RequestServices.GetRequiredService<IEnvironmentReportService>();
                
                var envName = context.Items["realEnvName"]!.ToString();
                app.Environment.EnvironmentName = envName!;

                await context.Response.WriteAsync(env.BuildReport());
            });
        });
    }
}