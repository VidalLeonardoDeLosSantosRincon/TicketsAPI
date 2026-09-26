using TicketsAPI.Domain.Filters;
using TicketsAPI.Interfaces.Controllers.V1;

namespace TicketsAPI.Controllers.V1;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/tickets/categories")]
[ApiController]
public class TicketsCategoriesController : ControllerBase, ITicketsCategoriesController
{
    private readonly ITicketCategoryService _ticketCategoryService;

    public TicketsCategoriesController(ITicketCategoryService ticketCategoryService)
    {
        _ticketCategoryService = ticketCategoryService;
    }

    // GET: api/v1/tickets/categories/dropdown
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken)
    {
        var categories = await _ticketCategoryService.GetAllForDropdownAsync(cancellationToken);
        return Ok(categories);
    }
}
