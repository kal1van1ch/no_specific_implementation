namespace HelpDesk.Models;


public class Ticket {
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Status { get; set; } = "";
    public int Priority { get; set; } = 5;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}