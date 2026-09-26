using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllAsync();
    Task<Team?> GetByGuidAsync(Guid guid);
}
