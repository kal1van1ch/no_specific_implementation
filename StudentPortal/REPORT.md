# Отчёт о работе StudentPortal

## Фото работы

Фотография пути `/`

![Фото пути "/"](assets/1.png)

Фотография пути `/tools/time`

![Фото пути "/tools/time"](assets/2.png)

Фотография пути `/tools/time?trace=true`

![Фото пути "/tools/time?trace=true"](assets/3.png)
![Фото пути "/tools/time?trace=true"](assets/3.1.png)

Фотография пути `/tools/date`

![Фото пути "/tools/date"](assets/4.png)

Фотография пути `/tools/info`

![Фото пути "/tools/info"](assets/5.png)

Фотография пути `/env`

![Фото пути "/env"](assets/6.png)

Фотография пути `/env?envName=Production`

![Фото пути "/env?envName=Production"](assets/7.png)

Фотография пути `/env?envName=Development`

![Фото пути "/env?envName=Development"](assets/8.png)

Фотография пути `/secure/admin/report`

![Фото пути "/secure/admin/report"](assets/9.png)

Фотография пути `/secure/admin/report?sudo=true`

![Фото пути "/secure/admin/report?sudo=true"](assets/10.png)

Фотография пути `/secure/admin/report?sudo=true&token=study2026`

![Фото пути "/secure/admin/report?sudo=true&token=study2026"](assets/11.png)

Фотография пути `/di/services`

![Фото пути "/di/services"](assets/12.png)

Фотография пути `/asdfghjkl`

![Фото пути "/asdfghjkl"](assets/13.png)

Логирование в процессе перехода по данным путям

![Фото пути "/Логирование"](assets/14.png)
![Фото пути "/Логирование"](assets/15.png)





## Пояснения к доп-заданию
1) Таблица как будто и так ясно

2) В качестве защиты ветки /secure/admin был написан отдельный класс
AdminMiddleware.cs, в котором я получал значение ключа sudo доп данных Query.
Перед переходом в /admin проверяется значение ключа sudo аналогично проверке токена
перед переходом в /report. Аналогично для TokenExt... был написан файл AdminExt...

3) Сделал возможность разного вывода информации для Development и Production через обработку Query. 
Механизм схож с проверкой на админа. Для запроса сервиса пришлось изменить подход, запрашивая его через
context.RequestServices.GetRequiredService<IEnvironmentReportService>();.

4) Добавил логирование во все middleware