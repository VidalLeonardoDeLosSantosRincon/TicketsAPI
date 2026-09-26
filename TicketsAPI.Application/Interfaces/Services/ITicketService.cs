using TicketsAPI.Application.DTOs.Tickets;
using TicketsAPI.Domain.Filters;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITicketService
{
    Task<IEnumerable<TicketDto>> GetAllAsync(TicketSearchFilter? filter = null);
    Task<TicketSummaryDto> GetAllSummaryAsync();
    Task<TicketDto?> GetByGuidAsync(Guid guid);
}
