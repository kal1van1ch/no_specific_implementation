namespace CampusRouteLab.Endpoints;


public static class FilesEndpoint {
    public static void MapFilesEndpoint(this WebApplication app) {
        app.Map("/files/{**path}", (string? path) => {
            return Results.Text($"Path: {path ?? "no path"}");
        });
    }
}