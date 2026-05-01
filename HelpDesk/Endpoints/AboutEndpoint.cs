namespace HelpDesk.Endpoints;


public static class AboutEndpoint {
    public static void MapAboutEndpoint(this WebApplication app) {
        app.Map("/about/text", (ILogger<Program> logger) => {
            logger.LogInformation("Проверка работы Results API");
            return Results.Text("Интересный факт, если назвать приложение, как в задании, то Results у меня не будет работать");
        }).WithName("Проверка работы Results.Text()");

        app.Map("/about/content", (ILogger<Program> logger) => {
            logger.LogInformation("Проверка работы Results API");
            return Results.Content("<h1>Results.Content хз что писать лалалалала</h1>", "text/html", System.Text.Encoding.UTF8);
        }).WithName("Проверка работы Results.Content()");
    }
}