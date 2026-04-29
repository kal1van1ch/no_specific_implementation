namespace HelpDesk.Extensions;


public static class RootHtmlExtension {
    public static IResult GetListPathHtml(this IResultExtensions extension, string code) {
        return new RootHtml(code);
    }
}