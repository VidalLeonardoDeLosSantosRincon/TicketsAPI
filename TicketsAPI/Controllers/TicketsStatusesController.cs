namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/tickets/statuses")]
[ApiController]
public class TicketsStatusesController : ControllerBase, ITicketsStatusesController
{
    private readonly ITicketStatusService _ticketStatusService;

    public TicketsStatusesController(ITicketStatusService ticketStatusService)
    {
        _ticketStatusService = ticketStatusService;
    }

    // GET: api/tickets/statuses/dropdown
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken)
    {
        var statuses = await _ticketStatusService.GetAllForDropdownAsync(cancellationToken);
        return Ok(statuses);
    }
}
