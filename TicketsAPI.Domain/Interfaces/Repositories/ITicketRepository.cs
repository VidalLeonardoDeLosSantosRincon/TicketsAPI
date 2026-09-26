using TicketsAPI.Domain.Filters;
using TicketsAPI.Domain.Models.Tickets;

namespace TicketsAPI.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll(TicketSearchFilter? filter = null);
        Task<Ticket?> GetByGuid(Guid guid);
    }
}
