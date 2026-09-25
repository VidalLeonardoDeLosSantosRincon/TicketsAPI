using TicketsAPI.Domain.Models.Tickets;

namespace TicketsAPI.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetByGuid(Guid guid);
    }
}
