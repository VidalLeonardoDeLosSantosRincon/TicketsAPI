using TicketsAPI.Application.DTOs;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITicketPriorityService
{
    Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync();
}
