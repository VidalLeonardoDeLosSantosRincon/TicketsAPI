using TicketsAPI.Domain.Filters;

namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/tickets/categories")]
[ApiController]
public class TicketsCategoriesController : ControllerBase, ITicketsCategoriesController
{
    private readonly ITicketCategoryService _ticketCategoryService;

    public TicketsCategoriesController(ITicketCategoryService ticketCategoryService)
    {
        _ticketCategoryService = ticketCategoryService;
    }

    // GET: api/tickets/categories/dropdown
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken)
    {
        var categories = await _ticketCategoryService.GetAllForDropdownAsync(cancellationToken);
        return Ok(categories);
    }
}
