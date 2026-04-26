namespace CampusHub.ConfigCenter.Endpoints;

using System.Text;
using CampusHub.ConfigCenter.Models;
using Microsoft.Extensions.Options;

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

        app.Map("/config/custom", (IConfiguration config) => {
            return $"""
            property1: {config["property1"]}
            property2: {config["property2"]}
            property3: {config["property3"]}
            """;
        });

        app.Map("/config/bind", (IConfiguration config) => {
            var obj = config.GetSection("Portal").Get<PortalOptions>()!;

            return $"""
            Title: {obj.Title}
            Seemster: {obj.Semester}
            SupportEmail: {obj.SupportEmail}
            Admin:
                {obj.Admin.Name}
                {obj.Admin.Email}
            Modules: {string.Join(", ", obj.Modules)}
            """;
        });

        app.Map("/config/options", (IOptions<NotificationOptions> notif, IOptions<PortalOptions> portal) => {
            return $"""
            Sender: {notif.Value.Sender}
            Channel: {notif.Value.Channel}
            Signature: {notif.Value.Signature}
            Title: {portal.Value.Title}
            Admin: 
                {portal.Value.Admin.Name}
                {portal.Value.Admin.Email}
            """;
        });

        app.Map("/config/effective", (IConfiguration config) => {
            return $"""
            Show key conflict
            Title: {config["Portal:Title"]}
            Semester: {config["Portal:Semester"]}
            SupportEmail: {config["Portal:SupportEmail"]}
            Admin:Name: {config["Portal:Admin:Name"]}
            Admin:Email: {config["Portal:Admin:Email"]}
            Sender: {config["Notifications:Sender"]}
            Signature: {config["Notifications:Signature"]}
            CLI: {config["Notifications:Channel"]}
            """;
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