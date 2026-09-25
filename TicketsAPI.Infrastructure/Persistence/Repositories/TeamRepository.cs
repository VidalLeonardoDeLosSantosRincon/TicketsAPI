using Microsoft.EntityFrameworkCore;
using TicketsAPI.Domain.Interfaces.Repositories;
using TicketsAPI.Domain.Models.Teams;
using TicketsAPI.Infrastructure.Persistence.Database;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class TeamRepository: ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context) {
      _context= context;
    }

    public async Task<IEnumerable<Team>> GetAll()
    {
        return await _context.Teams
            .Include(x => x.Members)
            .ToListAsync();
    }

    public async  Task<Team?> GetByGuid(Guid guid)
    {
        return await _context.Teams
            .Include(x => x.Members)
            .FirstOrDefaultAsync(x =>  x.Guid == guid);
    }
}
