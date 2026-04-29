namespace HelpDesk.Extensions;


public class RootHtml : IResult {
    private readonly string _code;

    public RootHtml(string code) {
        _code = code;
    }

    public async Task ExecuteAsync(HttpContext context) {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync(_code);
    }
}