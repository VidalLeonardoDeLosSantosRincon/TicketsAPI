namespace TicketsAPI.Interfaces.Controllers.V1;

public interface ITicketsStatusesController
{
    Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken);
}
