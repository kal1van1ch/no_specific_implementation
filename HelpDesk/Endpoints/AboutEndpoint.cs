namespace HelpDesk.Endpoints;


public static class AboutEndpoint {
    public static void MapAboutEndpoint(this WebApplication app) {
        app.Map("/about/text", () => Results.Text("Интересный факт, если назвать приложение, как в задании, то Results у меня не будет работать"));

        app.Map("/about/content", () => Results.Content("<h1>Results.Content хз что писать лалалалала</h1>", "text/html", System.Text.Encoding.UTF8));
    }
}