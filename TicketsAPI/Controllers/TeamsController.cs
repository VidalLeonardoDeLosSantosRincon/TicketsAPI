namespace TicketsAPI.Controllers;

[Authorize(Policy = nameof(Policies.Scopes.GrantTicketAccess))]
[Route("api/teams")]
[ApiController]
public class TeamsController : ControllerBase, ITeamsController
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService) {
        _teamService = teamService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var teams = await _teamService.GetAllAsync(cancellationToken);
        return Ok(teams);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByGuid(Guid id, CancellationToken cancellationToken)
    {
        var team = await _teamService.GetByGuidAsync(id, cancellationToken);
        return team is not null ? Ok(team) : NotFound();
    }
}
