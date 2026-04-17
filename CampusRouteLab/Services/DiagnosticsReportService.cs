namespace CampusRouteLab.Services;


public class DiagnosticsReportService {
    public IAppInfoService appInfo { get; }
    public ITransientMarkerService market { get; }
    public IRequestContextService request { get; }

    public DiagnosticsReportService(
        IAppInfoService appInfo,
        ITransientMarkerService market,
        IRequestContextService request
    ) {
        this.appInfo = appInfo;
        this.market = market;
        this.request = request;
    }
}