namespace TicketsAPI.Interfaces.Controllers.V1;

public interface ITeamsController
{
    Task<IActionResult> GetAll(CancellationToken cancellationToken);
    Task<IActionResult> GetByGuid(Guid id, CancellationToken cancellationToken);
}
