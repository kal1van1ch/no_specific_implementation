namespace CampusRouteLab.Services;


public class DiagnosticsReportService {
    public IAppInfoService app { get; }
    public ITransientMarkerService market { get; }
    public IRequestContextService request { get; }

    public DiagnosticsReportService(
        IAppInfoService app,
        ITransientMarkerService market,
        IRequestContextService request
    ) {
        this.app = app;
        this.market = market;
        this.request = request;
    }
}