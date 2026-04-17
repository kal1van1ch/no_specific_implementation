namespace CampusRouteLab.Endpoints;

using CampusRouteLab.Services;


public static class DiagEndpoint {
    public static void MapDiagEndpoint(this WebApplication app) {
        app.Map("/diag/lifetimes", (
            IAppInfoService appInfo,
            IRequestContextService request,
            ITransientMarkerService market,
            DiagnosticsReportService diagonal
        ) => {
            var result = new {
                notFromDiagonal = new {
                    newApp = appInfo.AppInstanceId,
                    newRequest = request.RequestId,
                    newMarket = market.Id,
                    appStartedAt = appInfo.StartedAt
                },
                fromDiagonal = new {
                    newApp = diagonal.appInfo.AppInstanceId,
                    newREquest = diagonal.request.RequestId,
                    newMarket = diagonal.market.Id,
                    appStartedAt = diagonal.appInfo.StartedAt
                }
            };

            Console.WriteLine("Получаю через параметр обработчика маршрута");
            return result;
        });

        app.Map("/diag/lifetimes/check", (ITransientMarkerService trans1, ITransientMarkerService trans2) => {
            var result = new {
                Trans1 = new {
                    trans1.Id
                },
                Trans2 = new {
                    trans2.Id
                }
            };
            Console.WriteLine("Получаю через параметр обработчика маршрута");
            return result;
        });

        app.Map("/diag/request-services", (HttpContext context) => {
            var serv = context.RequestServices.GetRequiredService<ITransientMarkerService>();
            var result = new {
                res = new {
                    serv.Id
                }
            };

            Console.WriteLine("Получаю через context.RequestServices.GetRequiredService<>()");
            return result;
        });

        app.Map("/diag/app-services", () => {
            var serv = app.Services.GetRequiredService<IAppInfoService>();

            var result = new {
                res = new {
                    serv.AppInstanceId,
                    serv.StartedAt
                }
            };

            Console.WriteLine("Получаю через app.Services.GetRequiredService<>()");
            return result;
        });
    }
}