# CampusHub.ConfigCenter

## Фото всех обязательных маршрутов

1) `/`

![](assets/image.png)

2) `/config/raw`

![](assets/Снимок%20экрана%202026-04-27%20092444.png)

3) `/config/section/portal`

![](assets/Снимок%20экрана%202026-04-27%20092642.png)

4) `/config/tree`

![](assets/Снимок%20экрана%202026-04-27%20092739.png)

5) `/config/connection`

![](assets/Снимок%20экрана%202026-04-27%20092832.png)

6) `/config/providers`

![](assets/Снимок%20экрана%202026-04-27%20092940.png)

7) `/config/custom`

![](assets/Снимок%20экрана%202026-04-27%20093020.png)

![](assets/Снимок%20экрана%202026-04-27%20093104.png)

8) `/config/bind`

![](assets/Снимок%20экрана%202026-04-27%20093231.png)

9) `/config/options`

![](assets/Снимок%20экрана%202026-04-27%20093316.png)

10) `/config/effective`

![](assets/Снимок%20экрана%202026-04-27%20093414.png)

## Фрагмент Program.cs с порядком подключения источников конфигурации

![](assets/Снимок%20экрана%202026-04-27%20093606.png)

## Фрагмент launchSettings.json с environmentVariables и commandLineArgs

![](assets/Снимок%20экрана%202026-04-27%20093747.png)

## Скриншот ответа /config/effective и пояснение какой источник победил по каждому конфликтующему ключу

Скриншоты выше</br>
ПО ключам:
- Title: Development
- Semester: env
- SupportEmail: Development
- Admin: Name и Email: appsetting
- Sender: ini
- Signature: xml
- Channel: CLI

## Объяснение разницы между `Bind()/Get<T>()` и `IOptions<T>`

`Bind()/Get<T>()` - Чтение из IConfigurations (если нужна вложенность)

`IOptions<T>` - Получение из DI (Endpoint, сервисы или middleware)

## Краткое описание формата customsettings.txt и алгоритма работы собственного провайдера

В `customsettings.txt` файлы строки выглядят так

![](assets/Снимок%20экрана%202026-04-27%20093104.png)

Работает так:

1. `builder.Configuration.AddTextFile("customsettings.txt");`
Подключаем данный метод через `TextConfigurationExtension` (добавляем источник в конфигурацию).
Этот класс определяет для объекта IConfigurationBuilder метод расширения AddTextFile(), в котором создается источник конфигурации TextConfigurationSource, который затем добавляется к строителю конфигурации.

2. `TextConfigurationSource`: возвращает объект `TextConfigurationProvider`, содержащий сам по себе объект, в метод Build() из данного файла в качестве параметра передается строитель конфигурации. В данном случае этот объект нам позволяет получить полный путь к текстовому файлу. Краткое название файла (относительный путь) передается в класс источника через конструктор и хранится в свойстве `_filename`. После создания полного пути к файлу этот путь передается в конструктор TextConfigurationProvider.

3. `TextConfigurationProvider`: получает путь файла и записывает из него пары в виде ключ:значение в свойство Data

## Скриншот или доказательство наличия заголовков X-Portal-Title и X-Portal-Semester в ответе

![](assets/Снимок%20экрана%202026-04-27%20102457.png)
