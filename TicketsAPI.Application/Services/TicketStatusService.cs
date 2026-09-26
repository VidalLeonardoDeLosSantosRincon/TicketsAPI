using TicketsAPI.Application.DTOs;
namespace TicketsAPI.Application.Services;

public class TicketStatusService: ITicketStatusService
{
    private readonly ITicketStatusRepository _ticketStatusRepository;

    public TicketStatusService(ITicketStatusRepository ticketStatusRepository)
    {
        _ticketStatusRepository = ticketStatusRepository;
    }

    public async Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync(CancellationToken cancellationToken)
    {
        var options = await _ticketStatusRepository.GetAllForDropdownAsync(cancellationToken);
        return options.Adapt<IEnumerable<OptionObjectDto>>();
    }
}
