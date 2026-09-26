using TicketsAPI.Application.DTOs;
namespace TicketsAPI.Application.Services;

public class TicketStatusService: ITicketStatusService
{
    private readonly ITicketStatusRepository _ticketStatusRepository;

    public TicketStatusService(ITicketStatusRepository ticketStatusRepository)
    {
        _ticketStatusRepository = ticketStatusRepository;
    }

    public async Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync()
    {
        var options = await _ticketStatusRepository.GetAllForDropdownAsync();
        return options.Adapt<IEnumerable<OptionObjectDto>>();
    }
}
