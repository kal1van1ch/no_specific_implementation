# HelpDesk

## Скриншот или список успешных запросов ко всем обязательным маршрутам

1) `/`

![](assets/image.png)

2) `/about/text`

![](assets/2026-05-01_20-26-28.png)

3) `/about/content`

![](assets/2026-05-01_20-28-20.png)

4) `/api/tickets`, `/api/tickets/1`, `/api/tickets/999`, `/api/tickets/create?title=Printer&priority=2`, `/api/tickets/create?priority=2`

![](assets/2026-05-01_20-29-46.png)

![](assets/2026-05-01_20-30-39.png)

![](assets/2026-05-01_20-31-26.png)

![](assets/2026-05-01_20-32-29.png)

![](assets/2026-05-01_20-33-55.png)

![](assets/2026-05-01_20-34-48.png)

![](assets/2026-05-01_20-35-22.png)

5) `/status/unauthorized`

![](assets/2026-05-01_20-36-17.png)

6) `/status/forbidden`

![](assets/2026-05-01_20-38-30.png)

7) `/status/custom/418`

![](assets/2026-05-01_20-41-32.png)

```
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
});
```

8) `/redirect/old-tickets`

![](assets/2026-05-01_20-53-10.png)

9) `/redirect/ticket/1`

![](assets/2026-05-01_20-55-21.png)

10) `/files/readme`

![](assets/2026-05-01_20-58-42.png)

11) `/throw`

- Development

![](assets/2026-05-01_21-03-10.png)

- Production

![](assets/2026-05-01_21-04-43.png)

12) `/unknown`

![](assets/2026-05-01_21-06-16.png)

## Фрагмент Program.cs с порядком middleware и маршрутов

```
using HelpDesk.Extensions;
using HelpDesk.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITicketRepository, InMemoryTicketRepository>();

var app = builder.Build();

// app.Environment.EnvironmentName = "Production";

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}
else {
    app.UseExceptionHandler("/error/exception");
}

app.UseStatusCodePagesWithReExecute("/error/status/{0}");

app.MapExtension();
app.Run();
```


## Объяснение, почему UseExceptionHandler и UseStatusCodePages должны находиться до конечных точек

Их ставят до конечных точек, тк конечные точки разворачивают конвейер обратно. Если поставить после них, то исключения просто не перехватятся.



## Краткое объяснение разницы между Results.Text, Results.Content, Results.Json и Results.File

- Results.Text - отправляет в ответ некоторое текстовое содержимое. Аналогичен методу Content(String, String, Encoding)
- Results.Content - отправляет в ответе некоторую строку. Позволяет вручную указать формат данных и кодировку
- Results.Json - отправляет ответ в формате JSON
- Results.File - отправляет в ответ файл




## Фрагмент собственного HtmlResult (у меня он называется RootHtml) и extension method

- RootHtml

```
namespace HelpDesk.Extensions;


public class RootHtml : IResult {
    private readonly string _code;

    public RootHtml(string code) {
        _code = code;
    }

    public async Task ExecuteAsync(HttpContext context) {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync(_code);
    }
}
```

- Extension метод

```
namespace HelpDesk.Extensions;


public static class RootHtmlExtension {
    public static IResult GetListPathHtml(this IResultExtensions extension, string code) {
        return new RootHtml(code);
    }
}
```



## Вывод по работе: что было самым важным в понимании статуса ответа, тела ответа и Content-Type

Сымым важным было понять, что три этих компонента неразрывно связаны и работают вместе для правильной обработки браузером запроса



## Дополнительно

- Добавил логирование
- Добавил Results.Problem(). В отличие от Json() возвращает отчёт об ошибке в стандартной форме (нельзя задать свою)
- Добавил WithName()