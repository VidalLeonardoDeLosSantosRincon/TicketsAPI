using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Constants;

namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamController(ITeamService teamService) {
        _teamService = teamService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var teams = await _teamService.GetAll();
        return Ok(teams);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        var team = await _teamService.GetByCode(code);
        return team is not null ? Ok(team) : NotFound();
    }
}
