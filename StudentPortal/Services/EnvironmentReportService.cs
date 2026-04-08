namespace StudentPortal.Services;
using System.Text;


public class EnvironmentReportService : IEnvironmentReportService
{
    private readonly IWebHostEnvironment _env;

    public EnvironmentReportService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public string BuildReport()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"EnvironmentName: {_env.EnvironmentName}");
        sb.AppendLine($"ApplicationName: {_env.ApplicationName}");

        switch (_env.EnvironmentName) {
            case "Development":
                sb.AppendLine($"ContentRootPath: {_env.ContentRootPath}");
                sb.AppendLine($"WebRootPath: {_env.WebRootPath ?? "No WebRootPath"}");
                sb.AppendLine($"OS Version: {System.Environment.OSVersion}");
                break;
            default:
                sb.AppendLine("Extra info was hidden");
                break;
        }

        return sb.ToString();
    }
}