using TaskManager.Endpoints; 
namespace TaskManager.Extensions; 


public static class EndpointExtension
{
    public static WebApplication MapApplicationEndpoints(this WebApplication app)
    {
        app.MapGetEndpoint();
        app.MapPostEndpoint();
        app.MapPutEndpoint();
        app.MapDeleteEndpoint();
        return app;
    }
}