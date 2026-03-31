using System.Text.Json;     
using TaskManager.Models;  
namespace TaskManager.Endpoints;


public static class PutEndpoint
{
    public static void MapPutEndpoint(this WebApplication app)
    {
        app.MapPut("/api/tasks/{id:int}", (int id, NewTaskModel newTask) => 
        {
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

            var existTask = allTasks.FirstOrDefault(t => t.Id == id);

            if(newTask.Title.Length > 0 && newTask.Title != null)
            {
                existTask.Title = newTask.Title;
            }

            if(newTask.Description.Length != 0 && newTask.Description != null)
            {
                existTask.Description = newTask.Description;
            }
            
            existTask.IsCompleted = newTask.IsCompleted;
            


            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(allTasks, options);
            File.WriteAllText(DB_PATH, updatedJson);

            return Results.Ok(existTask);
            
        }).WithName("Обновление задачи").WithDescription("Обновляет задачу по её id");
    }
}