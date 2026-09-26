using Microsoft.EntityFrameworkCore;
using TicketsAPI.Domain.Filters;
using TicketsAPI.Domain.Interfaces.Repositories;
using TicketsAPI.Domain.Models.Tickets;
using TicketsAPI.Infrastructure.Persistence.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class TicketRepository: ITicketRepository
{
    public readonly AppDbContext _appDbContext;

    public TicketRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync(TicketSearchFilter? filter = null)
    {
        var query = _appDbContext.Tickets
                .Include(x => x.Status)
                .Include(x => x.Priority)
                .Include(x => x.Category)
                .Include(x => x.User).AsQueryable();

        if (filter?.Status is not null) query = query.Where(x => x.Status!.Guid == filter.Status);
        if (filter?.Priority is not null) query = query.Where(x => x.Priority!.Guid == filter.Priority);
        if (filter?.Category is not null) query = query.Where(x => x.Category!.Guid == filter.Category);

        return await query
                .OrderByDescending(x => x.Id)
                .ToListAsync();
    }

    public async Task<Ticket?> GetByGuidAsync(Guid guid)
    {
        return await _appDbContext.Tickets
                .Include(x => x.Status)
                .Include(x => x.Priority)
                .Include(x => x.Category)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Guid == guid);
    }
}
