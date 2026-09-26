using TicketsAPI.Application.DTOs.Teams;

namespace TicketsAPI.Application.Interfaces.Services;

public interface ITeamService
{
    Task<IEnumerable<TeamDto>> GetAllAsync();
    Task<TeamDto?> GetByGuidAsync(Guid guid);
}
