using TicketsAPI.Application.DTOs;

namespace TicketsAPI.Application.Services;

public class TicketPriorityService : ITicketPriorityService
{
    private readonly ITicketPriorityRepository _ticketPriorityRepository;

    public TicketPriorityService(ITicketPriorityRepository ticketPriorityRepository)
    {
        _ticketPriorityRepository = ticketPriorityRepository;
    }

    public async Task<IEnumerable<OptionObjectDto>> GetAllForDropdownAsync(CancellationToken cancellationToken)
    {
        var options = await _ticketPriorityRepository.GetAllForDropdownAsync(cancellationToken);
        return options.Adapt<IEnumerable<OptionObjectDto>>();
    }
}
