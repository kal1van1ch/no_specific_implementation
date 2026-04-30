namespace HelpDesk.Services;

using HelpDesk.Models;


public interface ITicketRepository {
    IEnumerable<Ticket> GetAll();
    Ticket? GetById(int id);
    Ticket Create(string title, int priority);
}