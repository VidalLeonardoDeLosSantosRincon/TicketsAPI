using TicketsAPI.Application.DTOs;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITicketStatusService
{
    Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync();
}
