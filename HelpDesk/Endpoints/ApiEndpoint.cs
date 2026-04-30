namespace HelpDesk.Endpoints;

using HelpDesk.Services;
using System.Text.Json;
using HelpDesk.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;


public static class ApiEndpoint {
    public static void MapApiEndpoint(this WebApplication app) {
        app.Map("/api/tickets/{id:int?}", (int? id, ITicketRepository rep) => {
            if (id == null) return Results.Json(rep.GetAll());

            var ticket = rep.GetById(id.Value);

            if (ticket == null) return Results.NotFound(new { message = $"Ticket {id} not found" });

            return Results.Ok(ticket);

        }).WithName("GetAllOrNotTickets");

        app.Map("/api/tickets/create", (string? title, int priority, ITicketRepository rep) => {
            if (title == null) return Results.Json(new { message = "У новой заявки нет имени" }, statusCode: 400);

            var newTicket = rep.Create(title, priority);

            return Results.Ok(newTicket);
        });
    }
}