using TicketsAPI.Domain.ValueObjects;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface ITicketPriorityRepository
{
    Task<IEnumerable<OptionObject>> GetAllForDropdownAsync();
}
