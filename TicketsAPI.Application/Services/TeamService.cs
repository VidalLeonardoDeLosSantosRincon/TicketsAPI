using Mapster;
using TicketsAPI.Application.DTOs.Teams;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Interfaces.Repositories;
using TicketsAPI.Domain.Models.Tickets;

namespace TicketsAPI.Application.Services;

public class TeamService: ITeamService
{
    private readonly ITeamRepository _teamRepostiroy;

    public TeamService(ITeamRepository teamRepostiroy)
    {
        _teamRepostiroy = teamRepostiroy;
    }

    public async Task<IEnumerable<TeamDto>> GetAll()
    {
        var teams = await _teamRepostiroy.GetAll();

        return teams.Adapt<IEnumerable<TeamDto>>();
    }

    public async Task<TeamDto?> GetByCode(string code)
    {
        var team = await _teamRepostiroy.GetByCode(code);
        return team.Adapt<TeamDto>();
    }
}
