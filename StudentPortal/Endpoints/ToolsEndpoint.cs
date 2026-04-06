namespace StudentPortal.Endpoints;
using StudentPortal.Services;


public static class ToolsEndpoint {
    public static void MapToolsEndpoint(this WebApplication app) {
        app.Map("/tools", tools => {
            tools.Map("/time", timeApp => timeApp.Run(context => {
                var dtService = context.RequestServices.GetRequiredService<IDateTimeService>();
                return context.Response.WriteAsync($"Time: {dtService.GetTime()}");
            }));

            tools.Map("/date", dateApp => dateApp.Run(context => {
                var dtService = context.RequestServices.GetRequiredService<IDateTimeService>();
                return context.Response.WriteAsync($"Date: {dtService.GetDate()}");
            }));

            tools.Map("/info", infoApp => infoApp.Run(context => {
                return context.Response.WriteAsync("tree-path tools");
            }));
        });
    }
}