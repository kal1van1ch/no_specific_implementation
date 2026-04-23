namespace CampusHub.ConfigCenter.Endpoints;


public static class RootEndpoint {
    public static void MapRootEndpoint(this WebApplication app) {
        app.Map("/", (IEnumerable<EndpointDataSource> endpds) => {
            string name = """
            CampusHub.ConfigCenter - приложение, которое играет роль учебного центра 
            диагностики конфигурации внутреннего портала колледжа. Приложение должно показывать итоговые 
            настройки портала, демонстрировать объединение нескольких источников конфигурации, выводить 
            структуру отдельных секций, показывать строки подключения, использовать собственный провайдер 
            конфигурации и передавать настройки в middleware через механизм Options.
            """;
            string paths = string.Join("\n", endpds.SelectMany(source => source.Endpoints));

            return Results.Text($"{name}\n\nПути:\n{paths}");
        });
    }
}
