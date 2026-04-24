namespace CampusHub.ConfigCenter.Endpoints;


public static class ConfigEndpoint {
    public static void MapConfigEndpoint(this WebApplication app) {
        app.Map("/config/raw", (IConfiguration config) => {
            return $"""
            Portal:Title: {config["Portal:Title"]}
            Portal:Semester: {config["Portal:Semester"]}
            Portal:Admin:Name {config["Portal:Admin:Name"]}
            Portal:Admin:Email {config["Portal:Admin:Email"]}
            """;
        });
    }
}
