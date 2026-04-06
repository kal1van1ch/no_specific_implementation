namespace StudentPortal.Endpoints;
using System.Text;


public static class DIEndpoint {
    public static void MapDIEndpoint(this WebApplication app) {
        app.MapGet("/di/services", (IServiceCollection service) => {
            var sb = new StringBuilder();
            sb.AppendLine("Info about services from IServiceCollection");

            foreach(var elem in service.Take(10)) {
                sb.AppendLine($"Name: {elem.ServiceType.Name}            LifeTime: {elem.Lifetime}");
            }

            return sb.ToString();
        });
    }
}