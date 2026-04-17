# Отчёт по работе CamousRouteLab

## Фотоотчёт о работе путей
1) `/`

![](assets/img.png)

2) Работа с путями `/students...`
Вот так выглядит сама по себе база студентов

```
private Dictionary<string, List<Student>> _listOfGrouos = new Dictionary<string, List<Student>> {
        ["Group_1"] = new List<Student> {
            new Student(1, "Mikhail"),
            new Student(2, "Valya"),
            new Student(3, "Nastya")
        },
        ["Group_2"] = new List<Student> {
            new Student(1, "Denis"),
            new Student(2, "Yulya"),
            new Student(3, "Max")
        }
    };
```

2.1. `/students`

![](assets/img_1.png)

2.2. `/students/Group_1`

![](assets/img_2.png)

2.3. `/students/Group_1/1`

![](assets/img_3.png)

2.4. Обработка несуществующих путей

![](assets/img_4.png)

![](assets/img_5.png)

3) `/reports/{section?}`

![](assets/image.png)

![](assets/Снимок%20экрана%202026-04-17%20120736.png)

4) `/portal/{module=home}/{page=index}/{id?}`

![](assets/Снимок%20экрана%202026-04-17%20130255.png)

![](assets/Снимок%20экрана%202026-04-17%20130429.png)

![](assets/Снимок%20экрана%202026-04-17%20130533.png)

![](assets/Снимок%20экрана%202026-04-17%20130601.png)

5) `/files/{**path}`

![](assets/Снимок%20экрана%202026-04-17%20130838.png)

![](assets/Снимок%20экрана%202026-04-17%20130916.png)

![](assets/Снимок%20экрана%202026-04-17%20130951.png)

6) `/routes`

![](assets/Снимок%20экрана%202026-04-17%20131254.png)

7) Работа с путями `/diag...`

7.1. `/diag/lifetimes`

![](assets/Снимок%20экрана%202026-04-17%20132003.png)

![](assets/Снимок%20экрана%202026-04-17%20132957.png)

![](assets/Снимок%20экрана%202026-04-17%20135655.png)

![](assets/Снимок%20экрана%202026-04-17%20135740.png)

![](assets/Снимок%20экрана%202026-04-17%20204613.png)

7.2. `/diag/lifetimes/check`

![](assets/Снимок%20экрана%202026-04-17%20140103.png)

![](assets/Снимок%20экрана%202026-04-17%20140148.png)

![](assets/Снимок%20экрана%202026-04-17%20140337.png)

![](assets/Снимок%20экрана%202026-04-17%20140425.png)

![](assets/Снимок%20экрана%202026-04-17%20204709.png)

7.3. `/diag/request-services`

![](assets/Снимок%20экрана%202026-04-17%20140557.png)

![](assets/Снимок%20экрана%202026-04-17%20140630.png)

![](assets/Снимок%20экрана%202026-04-17%20140706.png)

![](assets/Снимок%20экрана%202026-04-17%20140731.png)

![](assets/Снимок%20экрана%202026-04-17%20204801.png)

7.4. `/diag/app-services`

![](assets/Снимок%20экрана%202026-04-17%20204116.png)

![](assets/Снимок%20экрана%202026-04-17%20204146.png)

![](assets/Снимок%20экрана%202026-04-17%20204211.png)

![](assets/Снимок%20экрана%202026-04-17%20204237.png)

![](assets/Снимок%20экрана%202026-04-17%20204855.png)

8) Неизвестные маршруты

![](assets/Снимок%20экрана%202026-04-17%20205115.png)





## Middleware

### RequestAuditMiddleware

Насчёт данной конструкции
```
context.Response.OnStarting(() => {
    context.Response.Headers["X-App-Instance"] = _app.AppInstanceId.ToString();
    context.Response.Headers["X-Request-Id"] = request.RequestId.ToString();
    context.Response.Headers["X-Transient-Id"] = marker.Id.ToString();

    _logger.LogInformation("Only after _next(context)");

    return Task.CompletedTask;
});
```

Она регестрирует отложенное действие. После _next(context) заголовки уже заблокированы и их не установить, а по заданию требуется писать заголовки после _next(context)

![](assets/Снимок%20экрана%202026-04-17%20204855.png)

## Разница между Transient, Scoped и Singelton

- Singelton - создаётся один раз при старте приложения и живёт, пока сервер не рванёт

- Scoped - создаётся 1 раз на 1 http запрос 

- Transient - создаётся новый при каждом запросе

## Почему scoped-сервис нельзя внедрять в конструктор middleware?

Потому что конструктор middleware создаётся и заполняется один раз при старте приложения.

## Таблица и жизненные циклы сервисов

| Сервис | Жизненный цикл |
|-|-|
| IStudentCatalogService / StudentCatalogService | Singelton |
| IAppInfoService / AppInfoService | Singelton |
| IRequestContextService / RequestContextService | Scoped |
| ITransientMarkerService / TransientMarkerService | Transient |
| DiagnosticsReportService | Transient |























