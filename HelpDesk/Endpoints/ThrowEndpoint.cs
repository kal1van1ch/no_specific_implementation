namespace HelpDesk.Endpoints;


public static class ThrowEndpoint {
    public static void MapThrowEndpoint(this WebApplication app) {
        app.Map("/throw", () => {
            throw new Exception("Исключение из /throw");
        });

        app.Map("/error/exception", (HttpContext con) => {
            return Results.Problem(title: "Ошибка 500", statusCode: 500);
        });

        app.Map("/error/status/{errorCode:int}", (int errorCode) => {
            string message = errorCode switch {
                400 => "Неверный запрос",
                401 => "Вы не авторизованы",
                403 => "Доступ запрещён",
                404 => "Извините, но данная страница не найдена",
                _ => "Ошибка на сервере"
            };

            return Results.Text(message);
        });
    }
}