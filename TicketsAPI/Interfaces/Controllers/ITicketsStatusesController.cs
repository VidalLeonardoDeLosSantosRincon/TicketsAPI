namespace TicketsAPI.Interfaces.Controllers;

public interface ITicketsStatusesController
{
    Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken);
}
