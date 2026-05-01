namespace HelpDesk.Endpoints;


public static class StatusEndpoint {
    public static void MapStatusEndpoint(this WebApplication app) {
        app.Map("/status/unauthorized", (ILogger<Program> logger) => {
            logger.LogError("Не авторизован");
            return Results.Unauthorized();
        }).WithName("Возврат кода 401");

        app.Map("/status/forbidden", (ILogger<Program> logger) => {
            logger.LogError("Домтуп запрещён");
            return Results.StatusCode(403);
        }).WithName("Возврат кода 403");

        app.Map("/status/custom/418", (ILogger<Program> logger) => {
            logger.LogError("Статус 418");
            return Results.StatusCode(418);
        }).WithName("Возврат кода 418");
    }
}