using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAll();
    Task<Team?> GetByGuid(Guid guid);
}
