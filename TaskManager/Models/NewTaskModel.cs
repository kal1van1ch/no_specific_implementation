namespace TaskManager.Models;

public class NewTaskModel{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted{get; set;} = false;
}