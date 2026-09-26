using TicketsAPI.Application.DTOs;

namespace TicketsAPI.Application.Services;

public class TicketCategoryService : ITicketCategoryService
{
    private readonly ITicketCategoryRepository _ticketCategoryRepository;

    public TicketCategoryService(ITicketCategoryRepository ticketCategoryRepository)
    {
        _ticketCategoryRepository = ticketCategoryRepository;
    }

    public async Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync()
    {
        var options = await _ticketCategoryRepository.GetAllForDropdownAsync();
        return options.Adapt<IEnumerable<OptionObjectDto>>();
    }
}
