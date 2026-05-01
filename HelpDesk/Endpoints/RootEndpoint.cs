namespace HelpDesk.Endpoints;

using HelpDesk.Extensions;


public static class RootEndpoint {
    public static void MapRootEndpoint(this WebApplication app) {
        app.Map("/", (IEnumerable<EndpointDataSource> endpds, ILogger<Program> logger) => {
            string descr = @"
            Это учебный сервис заявок в службу поддержки.</br>
            Приложение должно показывать список заявок, </br>
            возвращать данные в разных форматах, обрабатывать</br>
            ошибочные запросы, имитировать серверное исключение, </br>
            отдавать файл-инструкцию и демонстрировать</br>
            разные способы формирования HTTP-ответа через Results API.</br>
            ";

            string paths = string.Join("</br>", endpds.SelectMany(s => s.Endpoints));

            string code = $@"
            <!DOCTYPE html>
            <html lang='ru'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Моя страница</title>
            </head>
            <body>

                <h1>HelpDesk</h1>
                <h3>{descr}</h3>
                </br>
                </br>
                <h2>Пути</h2>
                <h3>{paths}</h3>

            </body>
            </html>
            ";

            logger.LogInformation("Выведена информация по проекту и маршрутам");
            return Results.Extensions.GetListPathHtml(code);
        }).WithName("Главная страница");
    }
}
