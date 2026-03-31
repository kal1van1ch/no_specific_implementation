using System.Text.Json;     
using TaskManager.Models;  
namespace TaskManager.Endpoints;


public static class DeleteEndpoint{
    public static void MapDeleteEndpoint(this WebApplication app){
        app.MapDelete("/api/tasks/{id:int}", (int id) => {
            string DB_PATH = "Data/task.json";
            string jsonText = File.ReadAllText(DB_PATH);

            var allTasks = JsonSerializer.Deserialize<List<TaskModel>>(jsonText);

            if(allTasks == null || allTasks.FirstOrDefault(t => t.Id == id) == null)
            {
                return Results.NotFound(new
                {
                    Message = "Такой задачи нет"
                });
            }

            var taskToRemove = allTasks.FirstOrDefault(t => t.Id == id);
            allTasks.Remove(taskToRemove);

            if(id <= allTasks.Count){
                int indToStart = id - 1;
                for(int i = indToStart; i < allTasks.Count; i++){
                    allTasks[i].Id = id;
                    id++;
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(allTasks, options);
            File.WriteAllText(DB_PATH, updatedJson);

            return Results.Ok(new{
                Message = "Задача удалена"
            });
        }).WithName("Удаление задачи").WithDescription("Удаляет задачу по её id");
    }
}