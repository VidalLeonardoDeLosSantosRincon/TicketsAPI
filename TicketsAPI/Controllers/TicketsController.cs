using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Constants;

namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/tickets")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    // GET: api/tickets
    // GET: api/tickets?summary=true
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool summary = false)
    {
        if (summary) return Ok(await _ticketService.GetAllSummary());

        return Ok(await _ticketService.GetAll());
    }

    // GET: api/tickets/f47ac10b-58cc-4372-a567-0e02b2c3d479
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByGuid(Guid id)
    {
        var ticket = await _ticketService.GetByGuid(id);

        if (ticket is null)
            return NotFound(new { Message = $"El ticket con Id {id} no existe." });

        return Ok(ticket);
    }
}
