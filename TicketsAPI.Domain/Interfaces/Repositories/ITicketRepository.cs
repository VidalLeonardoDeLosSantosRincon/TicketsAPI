using TicketsAPI.Domain.Filters;
using TicketsAPI.Domain.Models.Tickets;

namespace TicketsAPI.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync(TicketSearchFilter? filter = null, CancellationToken cancellationToken = default);
        Task<Ticket?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken);
    }
}
