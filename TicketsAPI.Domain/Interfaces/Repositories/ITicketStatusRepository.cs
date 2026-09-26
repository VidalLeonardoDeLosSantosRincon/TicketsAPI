using TicketsAPI.Domain.ValueObjects;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface ITicketStatusRepository
{
    Task<IEnumerable<OptionObject>> GetAllForDropdownAsync();
}
