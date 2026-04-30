namespace HelpDesk.Endpoints;


public static class ThrowEndpoint {
    public static void MapThrowEndpoint(this WebApplication app) {
        app.Map("/throw", () => {

        });
    }
}