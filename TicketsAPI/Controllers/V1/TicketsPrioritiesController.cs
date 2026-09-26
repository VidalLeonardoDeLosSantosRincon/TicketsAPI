using TicketsAPI.Interfaces.Controllers.V1;

namespace TicketsAPI.Controllers.V1;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/tickets/priorities")]
[ApiController]
public class TicketsPrioritiesController : ControllerBase, ITicketsPrioritiesController
{
    private readonly ITicketPriorityService _ticketPriorityService;

    public TicketsPrioritiesController(ITicketPriorityService ticketPriorityService)
    {
        _ticketPriorityService = ticketPriorityService;
    }

    // GET: api/v1/tickets/priorities/dropdown/
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken)
    {
        var priority = await _ticketPriorityService.GetAllForDropdownAsync(cancellationToken);
        return Ok(priority);
    }
}
