namespace StudentPortal.Extensions;
using StudentPortal.Services;


public static class ServiceCollectionExtensions {
    public static IServiceCollection AddStudentPortalServices(this IServiceCollection service) {
        service.AddTransient<IDateTimeService, DateTimeService>();
        service.AddTransient<IEnvironmentReportService, EnvironmentReportService>();

        return service;
    }
}