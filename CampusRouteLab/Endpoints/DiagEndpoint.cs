namespace CampusRouteLab.Endpoints;

using CampusRouteLab.Services;


public static class DiagEndpoint {
    public static void MapDiagEndpoint(this WebApplication app) {
        app.Map("/diag/lifetimes", (
            IAppInfoService app,
            IRequestContextService request,
            ITransientMarkerService market,
            DiagnosticsReportService diagonal
        ) => {
            var result = new {
                notFromDiagonal = new {
                    newApp = app.AppInstanceId,
                    newRequest = request.RequestId,
                    newMarket = market.Id,
                    appStartedAt = app.StartedAt
                },
                fromDiagonal = new {
                    newApp = diagonal.app.AppInstanceId,
                    newREquest = diagonal.request.RequestId,
                    newMarket = diagonal.market.Id,
                    appStartedAt = diagonal.app.StartedAt
                }
            };

            return result;
        });
    }
}