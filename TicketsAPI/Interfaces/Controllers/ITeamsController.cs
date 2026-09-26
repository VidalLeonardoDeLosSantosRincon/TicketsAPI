namespace TicketsAPI.Interfaces.Controllers;

public interface ITeamsController
{
    Task<IActionResult> GetAll(CancellationToken cancellationToken);
    Task<IActionResult> GetByGuid(Guid id, CancellationToken cancellationToken);
}
