namespace HelpDesk.Endpoints;


public static class RedirectEndpoint {
    public static void MapRedirectEndpoint(this WebApplication app) {
        app.Map("/redirect/old-tickets", (ILogger<Program> logger) => {
            logger.LogWarning("Перенаправлен на маршрут /api/tickets");
            return Results.LocalRedirect("/api/tickets");
        }).WithName("Локальная переадресация");

        app.Map("/redirect/ticket/{id:int}", (int id, ILogger<Program> logger) => {
            logger.LogWarning("Перенаправлен на маршрут с имененм GetAllOrNotTickets");
            return Results.RedirectToRoute("GetAllOrNotTickets", new { id });
        }).WithName("Переадресация через RedirectToRoutr()");
    }
}