using TicketsAPI.Interfaces.Controllers.V1;

namespace TicketsAPI.Controllers.V1;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/tickets/statuses")]
[ApiController]
public class TicketsStatusesController : ControllerBase, ITicketsStatusesController
{
    private readonly ITicketStatusService _ticketStatusService;

    public TicketsStatusesController(ITicketStatusService ticketStatusService)
    {
        _ticketStatusService = ticketStatusService;
    }

    // GET: api/v1/tickets/statuses/dropdown
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetAllForDropdown(CancellationToken cancellationToken)
    {
        var statuses = await _ticketStatusService.GetAllForDropdownAsync(cancellationToken);
        return Ok(statuses);
    }
}
