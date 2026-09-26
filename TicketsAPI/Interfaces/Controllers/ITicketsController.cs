using System.Threading;
using TicketsAPI.Domain.Filters;

namespace TicketsAPI.Interfaces.Controllers;

public interface ITicketsController
{
    Task<IActionResult> GetAll([FromQuery] TicketSearchFilter? filter, CancellationToken cancellationToken);
    Task<IActionResult> GetByGuid(Guid id, CancellationToken cancellationToken);
}
