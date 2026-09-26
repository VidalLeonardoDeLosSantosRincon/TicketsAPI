using TicketsAPI.Domain.ValueObjects;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class TicketPriorityRepository : ITicketPriorityRepository
{
    public readonly AppDbContext _appDbContext;

    public TicketPriorityRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<OptionObject>> GetAllForDropdownAsync(CancellationToken cancellationToken)
    {
        var ticketStatuses = await _appDbContext.TicketPriorities.Select(x => new OptionObject()
        {
            Guid = x.Guid,
            Code = x.Code,
            Name = x.Name
        }).ToListAsync(cancellationToken);

        return ticketStatuses;
    }
}
