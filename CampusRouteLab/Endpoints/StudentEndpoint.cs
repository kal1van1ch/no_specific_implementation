namespace CampusRouteLab.Endpoints;

using CampusRouteLab.Services;


public static class StudentEndpoint {
    public static void MapStudentEndpoint(this WebApplication app) {
        app.Map("/students", (IStudentCatalogService studentService) => studentService.GetAllGroups());

        app.Map("/students/{group}", (IStudentCatalogService studentService, string group, HttpContext c) => {
            var answer = studentService.GetAllStudents(group);

            if (answer == null) {
                c.Response.StatusCode = 404;
                return Results.Empty;
            }
            return Results.Ok(answer);
        });

        app.Map("/students/{group}/{id}", (IStudentCatalogService studentService, string group, int id, HttpContext c) => {
            var answer = studentService.GetStudent(group, id);

            if (answer == null) {
                c.Response.StatusCode = 404;
                return Results.Empty;
            }

            return Results.Ok(answer);
        });
    }
}
