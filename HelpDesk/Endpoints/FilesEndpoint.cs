namespace HelpDesk.Endpoints;


public static class FilesEndpoint {
    public static void MapFilesEndpoint(this WebApplication app) {
        app.Map("/files/readme", () => {
            string path = "files/readme.txt";
            string contentType = "text/plain";
            string downloadName = "best_readme.txt";

            return Results.File(path, contentType, downloadName);
        });
    }
}