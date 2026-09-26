using System.Threading;
using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllAsync(CancellationToken cancellationToken);
    Task<Team?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken);
}
