namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/tickets/priorities")]
[ApiController]
public class TicketsPrioritiesController : ControllerBase, ITicketsPrioritiesController
{
    private readonly ITicketPriorityService _ticketPriorityService;

    public TicketsPrioritiesController(ITicketPriorityService ticketPriorityService)
    {
        _ticketPriorityService = ticketPriorityService;
    }

    // GET: api/tickets/priorities/dropdown
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken)
    {
        var priority = await _ticketPriorityService.GetAllForDropdownAsync(cancellationToken);
        return Ok(priority);
    }
}
