namespace StudentPortal.Endpoints;
using StudentPortal.Extensions;


public static class SecureEndpoint {
    public static void MapSecureEndpoint(this WebApplication app) {
        app.Map("/secure", secure => {

            secure.CheckSudo();

            secure.Map("/admin", admin => {

                admin.UseToken("study2026"); 

                admin.Map("/report", report => report.Run(context => {
                    return context.Response.WriteAsync("Token is gaddem good");
                }));
            });    
        });
    }
}