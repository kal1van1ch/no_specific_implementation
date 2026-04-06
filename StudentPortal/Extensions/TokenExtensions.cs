using StudentPortal.Middleware;
namespace StudentPortal.Extensions;


public static class TokenExtensions{
    public static IApplicationBuilder UseToken(this IApplicationBuilder app, string pattern){
        return app.UseMiddleware<TokenMiddleware>(pattern);
    }
}    
