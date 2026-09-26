using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class TeamRepository: ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context) {
      _context= context;
    }

    public async Task<IEnumerable<Team>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Teams
            .Include(x => x.Members)
            .ToListAsync(cancellationToken);
    }

    public async  Task<Team?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        return await _context.Teams
            .Include(x => x.Members)
            .FirstOrDefaultAsync(x =>  x.Guid == guid, cancellationToken);
    }
}
