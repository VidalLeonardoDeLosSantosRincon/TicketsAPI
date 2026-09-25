using Microsoft.EntityFrameworkCore;
using TicketsAPI.Domain.Interfaces.Repositories;
using TicketsAPI.Domain.Models.Tickets;
using TicketsAPI.Infrastructure.Persistence.Database;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class TicketRepository: ITicketRepository
{
    public readonly AppDbContext _appDbContext;

    public TicketRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Ticket>> GetAll()
    {
        return await _appDbContext.Tickets
                .Include(x => x.Status)
                .Include(x => x.Priority)
                .Include(x => x.Category)
                .Include(x => x.User)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
    }

    public async Task<Ticket?> GetByGuid(Guid guid)
    {
        return await _appDbContext.Tickets
                .Include(x => x.Status)
                .Include(x => x.Priority)
                .Include(x => x.Category)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Guid == guid);
    }
}
