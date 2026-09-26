namespace TicketsAPI.Interfaces.Controllers;

public interface ITicketsPrioritiesController
{
    Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken);
}
