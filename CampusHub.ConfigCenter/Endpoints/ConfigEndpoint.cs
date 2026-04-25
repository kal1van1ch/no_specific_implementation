namespace CampusHub.ConfigCenter.Endpoints;

using System.Text;


public static class ConfigEndpoint {
    public static void MapConfigEndpoint(this WebApplication app) {
        app.Map("/config/raw", (IConfiguration config) => {
            return $"""
            Portal:Title: {config["Portal:Title"]}
            Portal:Semester: {config["Portal:Semester"]}
            Portal:Admin:Name: {config["Portal:Admin:Name"]}
            Portal:Admin:Email: {config["Portal:Admin:Email"]}
            Notifications:Sender: {config["Notifications:Sender"]}
            Notifications:Channel: {config["Notifications:Channel"]}
            """;
        });

        app.Map("/config/section/portal", (IConfiguration config) => {
            return config.GetSection("Portal");
        });

        app.Map("/config/tree", (IConfiguration config) => RecursiveMethod(config.GetSection("Portal"), 0));

        app.Map("/config/connection", (IConfiguration config) => {
            string val = config.GetSection("ConnectionStrings:DefaultConnection")
            .Value ?? "no value in DefaultConnection";

            return val;
        });

        app.Map("/config/providers", (IConfiguration config) => {
            var root = (IConfigurationRoot)config;
            var sb = new StringBuilder();

            foreach (var r in root.Providers) {
                sb.AppendLine(r.ToString());
            }

            return sb.ToString();
        });
    }

    private static string RecursiveMethod(IConfiguration configSection, int indentationLevel) {

        var sb = new StringBuilder();

        foreach (var sec in configSection.GetChildren()) {

            string indent = new string(' ', indentationLevel * 2);
            sb.Append($"{indent}{sec.Key}: ");

            if (sec.Value == null) {
                var newSb = RecursiveMethod(sec, indentationLevel + 1);
                sb.Append($"{{\n{newSb}{indent}}}\n");
            }
            else {
                sb.Append($"{sec.Value}\n");
            }
        }

        return sb.ToString();
    }
}