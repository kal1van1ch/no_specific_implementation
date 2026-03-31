using System.Text.Json;     
using TaskManager.Models;  
namespace TaskManager.Endpoints;


public static class GetEndpoint
{
    public static void MapGetEndpoint(this WebApplication app)
    {
        app.MapGet("/api/tasks", () =>
        {
            string DB_PATH = "Data/task.json";
            string jsonText = File.ReadAllText(DB_PATH);
            return Results.Text(jsonText, "application/json");
        }).WithName("Получение списка задач").WithDescription("Получает список задач");

        app.MapGet("/api/tasks/{id:int}", (int id) => {
            string DB_PATH = "Data/task.json";
            string jsonText = File.ReadAllText(DB_PATH);
            var allTasks = JsonSerializer.Deserialize<List<TaskModel>>(jsonText);

            var task = allTasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return Results.NotFound(new { Message = $"Задача с ID {id} не найдена" });
            }

            string jsonAnswer = JsonSerializer.Serialize(task);
            return Results.Text(jsonAnswer, "application/json");
        }).WithName("Получение списка задач по id").WithDescription("Получает список задач по id");

        app.MapGet("/api/tasks/completed", () => {
            
            var completedTasks = new List<TaskModel>();

            string DB_PATH = "Data/task.json";
            string jsonText = File.ReadAllText(DB_PATH);
            var allTasks = JsonSerializer.Deserialize<List<TaskModel>>(jsonText);

            foreach (var comp in allTasks){
                if(comp.IsCompleted) completedTasks.Add(comp);
            }
            
            return Results.Json(completedTasks);
        }).WithName("Получение списка выполненных задач").WithDescription("Получает список выполненных задач");
    }
}