using TicketsAPI.Domain.Filters;

namespace TicketsAPI.Interfaces.Controllers;

public interface ITicketsController
{
    Task<IActionResult> GetAll([FromQuery] TicketSearchFilter? filter);
    Task<IActionResult> GetByGuid(Guid id);
}
