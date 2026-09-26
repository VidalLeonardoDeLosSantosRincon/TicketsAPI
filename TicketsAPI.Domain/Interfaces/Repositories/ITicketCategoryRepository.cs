using TicketsAPI.Domain.ValueObjects;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface ITicketCategoryRepository
{
    Task<IEnumerable<OptionObject>> GetAllForDropdownAsync();
}
