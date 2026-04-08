using StudentPortal.Middleware;
namespace StudentPortal.Extensions;


public static class EnvExtension{
    public static IApplicationBuilder CheckEnv(this IApplicationBuilder app) {
        return app.UseMiddleware<EnvMiddleware>();
    }
}    
