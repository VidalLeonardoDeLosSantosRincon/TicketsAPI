namespace TicketsAPI.Interfaces.Controllers;

public interface ITicketsCategoriesController
{
    Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken);
}
