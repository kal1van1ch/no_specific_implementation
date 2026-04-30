namespace HelpDesk.Services;

using System.Reflection.Metadata.Ecma335;
using HelpDesk.Models;


public class InMemoryTicketRepository : ITicketRepository {

    private List<Ticket> _data = new List<Ticket> {
        new Ticket { Id = 1, Title = "Заявка на участие в клоунаде", Status = "open", Priority = 1},
        new Ticket { Id = 2, Title = "Заявка на участие в поступлении в ВУЦ", Status = "open", Priority = 1},
        new Ticket { Id = 3, Title = "Сдать нормативы на 100 баллов", Status = "open", Priority = 1}
    };

    public IEnumerable<Ticket> GetAll() {
        return _data;
    }

    public Ticket? GetById(int id) {
        return _data.FirstOrDefault(t => t.Id == id);
    }

    public Ticket Create(string title, int priority) {

        var newTicket = new Ticket { Id = _data.Count + 1, Priority = priority, Title = title, Status = "open" };
        _data.Add(newTicket);

        return newTicket;
    }
}
