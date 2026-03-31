using System.Text.Json;     
using TaskManager.Models;  
namespace TaskManager.Endpoints;


public static class PostEndpoint
{
    public static void MapPostEndpoint(this WebApplication app)
    {
        app.MapPost("/api/tasks", (NewTaskModel newTask) =>{
            string DB_PATH = "Data/task.json";
            string jsonText = File.ReadAllText(DB_PATH);
            
            var allTasks = JsonSerializer.Deserialize<List<TaskModel>>(jsonText);

            if (allTasks == null)
            {
                allTasks = new List<TaskModel>();
            }

            TaskModel taskToSave = new TaskModel();
            
            taskToSave.Title = newTask.Title;
            taskToSave.Description = newTask.Description;
            taskToSave.IsCompleted = newTask.IsCompleted;

            if (allTasks.Count == 0){
                taskToSave.Id = 1;
            }
            else{
                int maxId = allTasks.Max(t => t.Id);
                taskToSave.Id = maxId + 1;
            }

            allTasks.Add(taskToSave);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(allTasks, options);
            File.WriteAllText(DB_PATH, updatedJson);

            return Results.Ok(taskToSave);
            
        }).WithName("Создание задачи").WithDescription("Добавляет новую задачу в базу данных");
    }
}