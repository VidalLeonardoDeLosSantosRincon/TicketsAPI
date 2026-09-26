using TicketsAPI.Interfaces.Controllers.V1;

namespace TicketsAPI.Controllers.V1;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/teams")]
[ApiController]
public class TeamsController : ControllerBase, ITeamsController
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    // GET: api/v1/teams
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var teams = await _teamService.GetAllAsync(cancellationToken);
        return Ok(teams);
    }

    // GET: api/v1/teams/f47ac10b-58cc-4372-a567-0e02b2c3d479
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByGuid(Guid id, CancellationToken cancellationToken)
    {
        var team = await _teamService.GetByGuidAsync(id, cancellationToken);
        return team is not null ? Ok(team) : NotFound();
    }
}
