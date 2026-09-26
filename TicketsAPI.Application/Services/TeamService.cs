using Mapster;
using TicketsAPI.Application.DTOs.Teams;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Interfaces.Repositories;

namespace TicketsAPI.Application.Services;

public class TeamService: ITeamService
{
    private readonly ITeamRepository _teamRepostiroy;

    public TeamService(ITeamRepository teamRepostiroy)
    {
        _teamRepostiroy = teamRepostiroy;
    }

    public async Task<IEnumerable<TeamDto>> GetAllAsync()
    {
        var teams = await _teamRepostiroy.GetAllAsync();

        return teams.Adapt<IEnumerable<TeamDto>>();
    }

    public async Task<TeamDto?> GetByGuidAsync(Guid guid)
    {
        var team = await _teamRepostiroy.GetByGuidAsync(guid);
        return team.Adapt<TeamDto>();
    }
}
