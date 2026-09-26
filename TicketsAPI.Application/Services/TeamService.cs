using TicketsAPI.Application.DTOs.Teams;

namespace TicketsAPI.Application.Services;

public class TeamService: ITeamService
{
    private readonly ITeamRepository _teamRepostiroy;

    public TeamService(ITeamRepository teamRepostiroy)
    {
        _teamRepostiroy = teamRepostiroy;
    }

    public async Task<IEnumerable<TeamDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var teams = await _teamRepostiroy.GetAllAsync(cancellationToken);

        return teams.Adapt<IEnumerable<TeamDto>>();
    }

    public async Task<TeamDto?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        var team = await _teamRepostiroy.GetByGuidAsync(guid, cancellationToken);
        return team.Adapt<TeamDto>();
    }
}
