namespace TicketsAPI.Interfaces.Controllers.V1;

public interface ITicketsPrioritiesController
{
    Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken);
}
