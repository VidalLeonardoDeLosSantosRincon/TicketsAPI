using TicketsAPI.Domain.ValueObjects;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class TicketStatusRepository: ITicketStatusRepository
{
    public readonly AppDbContext _appDbContext;

    public TicketStatusRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<OptionObject>> GetAllForDropdownAsync()
    {
        var ticketStatuses = await _appDbContext.TicketStatuses.Select(x => new OptionObject()
        {
            Guid = x.Guid,
            Code = x.Code,
            Name = x.Name
        }).ToListAsync();

        return ticketStatuses;
    }
}
