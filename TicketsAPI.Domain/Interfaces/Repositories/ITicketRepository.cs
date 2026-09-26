using TicketsAPI.Domain.Filters;
using TicketsAPI.Domain.Models.Tickets;

namespace TicketsAPI.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync(TicketSearchFilter? filter = null);
        Task<Ticket?> GetByGuidAsync(Guid guid);
    }
}
