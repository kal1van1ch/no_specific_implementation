namespace HelpDesk.Endpoints;


public static class ThrowEndpoint {
    public static void MapThrowEndpoint(this WebApplication app) {
        app.Map("/throw", (ILogger<Program> logger) => {
            logger.LogCritical("Сгенерированное исключение через /throw");
            throw new Exception("Исключение из /throw");
        }).WithName("Исключение throw Development");

        app.Map("/error/exception", (HttpContext con, ILogger<Program> logger) => {
            logger.LogError("Ошибка на сервере");
            return Results.Problem(title: "Ошибка 500", statusCode: 500);
        }).WithName("Исключение throw Production (перенапрака сюда)");

        app.Map("/error/status/{errorCode:int}", (int errorCode, ILogger<Program> logger) => {
            string message = errorCode switch {
                400 => "Неверный запрос",
                401 => "Вы не авторизованы",
                403 => "Доступ запрещён",
                404 => "Извините, но данная страница не найдена",
                _ => "Ошибка другого характера"
            };

            logger.LogWarning($"Ошибка номер {errorCode} - {message}");
            return Results.Text(message);
        }).WithName("Обрабатывает статус-коды");
    }
}