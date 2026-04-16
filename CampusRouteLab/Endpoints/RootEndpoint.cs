namespace CampusRouteLab.Endpoints;


public static class RootEndpoint {
    public static void MapRootEndpoint(this WebApplication app) {
        app.Map("/", () => """
        Name: CampusRouteLab
        Target: Learn about routs and make them
        /
        /students/
        /students/{group}
        /students/{group}/{id}
        /reports/{section?}
        /portal/{module=home}/{page=index}/{id?}
        /files/{**path}
        /routes
        /diag/lifetimes
        /diag/lifetimes/check
        /diag/request-services
        /diag/app-services
        """);
    }
}