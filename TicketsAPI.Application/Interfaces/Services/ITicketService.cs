using TicketsAPI.Application.DTOs.Tickets;
using TicketsAPI.Domain.Filters;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITicketService
{
    Task<IEnumerable<TicketDto>> GetAllAsync(TicketSearchFilter? filter = null, CancellationToken cancellationToken = default);
    Task<TicketSummaryDto> GetAllSummaryAsync(CancellationToken cancellationToken);
    Task<TicketDto?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken);
}
