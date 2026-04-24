namespace CampusHub.ConfigCenter.Endpoints;

using System.Text;


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

        app.Map("/config/section/portal", (IConfiguration config) => {
            return config.GetSection("Portal");
        });

        app.Map("/config/tree", (IConfiguration config) => RecursiveMethod(config.GetSection("Portal")));
    }

    private static string RecursiveMethod(IConfiguration configSection) {

        var sb = new StringBuilder();

        foreach (var sec in configSection.GetChildren()) {
            sb.Append(sec.Key);

            if (sec.Value == null) {
                sb.Append("\n");
                var newSb = RecursiveMethod(sec);
                sb.AppendLine(newSb);
            }
            else {
                sb.Append($": {sec.Value}\n");
            }
        }

        return sb.ToString();
    }
}