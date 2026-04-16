using Microsoft.AspNetCore.DataProtection;

namespace CampusRouteLab.Endpoints;


public static class ReportEndpoint {
    public static void MapReportEndpoint(this WebApplication app) {
        app.Map("/reports/{section?}", (string? section) => {
            return Results.Text($"Section: {section ?? "overview"}");
        });
    }
}