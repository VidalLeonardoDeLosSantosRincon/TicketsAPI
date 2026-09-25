using TicketsAPI.Application.DTOs.Tickets;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITicketService
{
    Task<IEnumerable<TicketDto>> GetAll();
    Task<TicketDto?> GetByGuid(Guid guid);
}
