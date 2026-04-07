using StudentPortal.Middleware;
namespace StudentPortal.Extensions;


public static class Adminxtensions{
    public static IApplicationBuilder CheckSudo(this IApplicationBuilder app){
        return app.UseMiddleware<AdminMiddleware>();
    }
}    
