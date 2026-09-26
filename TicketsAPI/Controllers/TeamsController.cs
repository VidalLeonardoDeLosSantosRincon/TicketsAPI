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
    public async Task<IActionResult> GetAll()
    {
        var teams = await _teamService.GetAllAsync();
        return Ok(teams);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByGuid(Guid id)
    {
        var team = await _teamService.GetByGuidAsync(id);
        return team is not null ? Ok(team) : NotFound();
    }
}
