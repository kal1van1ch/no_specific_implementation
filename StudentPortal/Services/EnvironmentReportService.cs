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
        sb.AppendLine($"ContentRootPath: {_env.ContentRootPath}");
        sb.AppendLine($"WebRootPath: {_env.WebRootPath}");
        return sb.ToString();
    }
}