namespace HelpDesk.Endpoints;


public static class RedirectEndpoint {
    public static void MapRedirectEndpoint(this WebApplication app) {
        app.Map("/redirect/old-tickets", () => Results.LocalRedirect("/api/tickets"));

        app.Map("/redirect/ticket/{id:int}", (int id) => Results.RedirectToRoute("GetAllOrNotTickets", new { id }));
    }
}