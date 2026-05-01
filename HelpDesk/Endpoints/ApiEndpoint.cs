namespace HelpDesk.Endpoints;

using HelpDesk.Services;
using System.Text.Json;
using HelpDesk.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;


public static class ApiEndpoint {
    public static void MapApiEndpoint(this WebApplication app) {
        app.Map("/api/tickets/{id:int?}", (int? id, ITicketRepository rep, ILogger<Program> logger) => {
            if (id == null) {
                logger.LogInformation("id не передан, возврат полного списка");
                return Results.Json(rep.GetAll());
            }

            var ticket = rep.GetById(id.Value);

            if (ticket == null) {
                logger.LogError($"Нет такой заявки с id {id}");
                return Results.NotFound(new { message = $"Ticket {id} not found" });
            }

            logger.LogInformation($"Возврат заявки с id {id}");
            return Results.Ok(ticket);

        }).WithName("GetAllOrNotTickets");

        app.Map("/api/tickets/create", (string? title, int priority, ITicketRepository rep, ILogger<Program> logger) => {
            if (title == null) {
                logger.LogError("У новой заявки нет title");
                return Results.Json(new { message = "У новой заявки нет имени" }, statusCode: 400);
            }

            var newTicket = rep.Create(title, priority);

            logger.LogInformation("Возврат новой заявки");
            return Results.Ok(newTicket);
        }).WithName("Создание заявки");
    }
}