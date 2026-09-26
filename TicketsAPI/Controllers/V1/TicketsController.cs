using TicketsAPI.Domain.Filters;
using TicketsAPI.Interfaces.Controllers.V1;

namespace TicketsAPI.Controllers.V1;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/tickets")]
[ApiController]
public class TicketsController : ControllerBase, ITicketsController
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    // GET: api/v1/tickets
    // GET: api/v1/tickets?summary=true
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TicketSearchFilter? filter, CancellationToken cancellationToken)
    {
        if (filter?.Summary ?? false) return Ok(await _ticketService.GetAllSummaryAsync(cancellationToken));

        return Ok(await _ticketService.GetAllAsync(filter, cancellationToken));
    }

    // GET: api/v1/tickets/f47ac10b-58cc-4372-a567-0e02b2c3d479
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByGuid(Guid id, CancellationToken cancellationToken)
    {
        var ticket = await _ticketService.GetByGuidAsync(id, cancellationToken);

        if (ticket is null)
            return NotFound(new { Message = $"El ticket con Id {id} no existe." });

        return Ok(ticket);
    }
}
