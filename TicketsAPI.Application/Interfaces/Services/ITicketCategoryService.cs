using TicketsAPI.Application.DTOs;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITicketCategoryService
{
    Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync(CancellationToken cancellationToken);
}
