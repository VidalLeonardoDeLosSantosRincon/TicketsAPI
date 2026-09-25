using TicketsAPI.Application.DTOs.Teams;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITeamService
{
    Task<IEnumerable<TeamDto>> GetAll();
    Task<TeamDto?> GetByGuid(Guid guid);
}
