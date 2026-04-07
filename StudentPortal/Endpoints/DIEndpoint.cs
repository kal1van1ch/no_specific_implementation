namespace StudentPortal.Endpoints;
using System.Text;


public static class DIEndpoint {
    public static void MapDIEndpoint(this WebApplication app, IServiceCollection service) {

        app.MapGet("/di/services", () => {
            var sb = new StringBuilder();
            sb.Append("<h1>Information about services</h1>");
            sb.Append("<table>");

            sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Implementation</th></tr>");

            foreach (var serv in service.Take(10)){
                sb.Append("<tr>");
                sb.Append($"<td>{serv.ServiceType.FullName}</td>");
                sb.Append($"<td>{serv.Lifetime}</td>");
                sb.Append($"<td>{serv.ImplementationType?.FullName}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return Results.Text(sb.ToString(), "text/html; charset=utf-8");
        });
    }
}