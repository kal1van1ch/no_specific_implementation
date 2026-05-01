namespace HelpDesk.Endpoints;


public static class FilesEndpoint {
    public static void MapFilesEndpoint(this WebApplication app) {
        app.Map("/files/readme", (ILogger<Program> logger) => {
            string path = "files/readme.txt";
            string contentType = "text/plain";
            string downloadName = "best_readme.txt";

            logger.LogInformation("Отправлен на скачивание файл с path: {Path}, contentType: {ContentType}, downloadName: {DownloadName}", path, contentType, downloadName);
            return Results.File(path, contentType, downloadName);
        }).WithName("Отпарвка файла");
    }
}