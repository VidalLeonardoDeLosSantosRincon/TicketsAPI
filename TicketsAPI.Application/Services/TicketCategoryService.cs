using TicketsAPI.Application.DTOs;

namespace TicketsAPI.Application.Services;

public class TicketCategoryService : ITicketCategoryService
{
    private readonly ITicketCategoryRepository _ticketCategoryRepository;

    public TicketCategoryService(ITicketCategoryRepository ticketCategoryRepository)
    {
        _ticketCategoryRepository = ticketCategoryRepository;
    }

    public async Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync(CancellationToken cancellationToken)
    {
        var options = await _ticketCategoryRepository.GetAllForDropdownAsync(cancellationToken);
        return options.Adapt<IEnumerable<OptionObjectDto>>();
    }
}
