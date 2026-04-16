namespace CampusRouteLab.Extensions;

using CampusRouteLab.Services;


public static class ServiceCollectionExtensions {
    public static IServiceCollection AddCampusServices(this IServiceCollection services) {
        services.AddSingleton<IStudentCatalogService, StudentCatalogService>();

        return services;
    }
}