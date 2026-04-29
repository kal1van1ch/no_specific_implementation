namespace HelpDesk.Endpoints;

using System.Text.Json;
using HelpDesk.Models;


public static class ApiEndpoint {
    public static void MapApiEndpoint(this WebApplication app) {
        app.Map("/api/tickets/{id:int?}", (int? id) => {

            string json = File.ReadAllText("Data/tickets.json");
            var tickets = JsonSerializer.Deserialize<List<Ticket>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            if (id == null) return Results.Json(tickets);

            var ticket = tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null) return Results.NotFound("Нет заявки с таким ID");

            return Results.Ok(ticket);
        });
    }
}