using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Constants;

namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _ticketService.GetAll();
        return Ok(tickets);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetByGuid(Guid guid)
    {
        var ticket = await _ticketService.GetByGuid(guid);
        return ticket is not null ? Ok(ticket) : NotFound();
    }

}
