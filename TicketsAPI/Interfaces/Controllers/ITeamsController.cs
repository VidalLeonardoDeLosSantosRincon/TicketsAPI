using Microsoft.AspNetCore.Mvc;

namespace TicketsAPI.Interfaces.Controllers;

public interface ITeamsController
{
    Task<IActionResult> GetAll();
    Task<IActionResult> GetByGuid(Guid id);
}
