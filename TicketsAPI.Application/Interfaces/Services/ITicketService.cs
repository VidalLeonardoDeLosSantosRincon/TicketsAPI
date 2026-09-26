using TicketsAPI.Application.DTOs.Tickets;
using TicketsAPI.Domain.Filters;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITicketService
{
    Task<IEnumerable<TicketDto>> GetAll(TicketSearchFilter? filter = null);
    Task<TicketSummaryDto> GetAllSummary();
    Task<TicketDto?> GetByGuid(Guid guid);
}
