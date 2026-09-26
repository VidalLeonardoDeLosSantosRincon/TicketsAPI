namespace TicketsAPI.Interfaces.Controllers.V1;

public interface ITicketsCategoriesController
{
    Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken);
}
