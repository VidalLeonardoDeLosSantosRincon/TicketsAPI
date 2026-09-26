using Mapster;
using TicketsAPI.Application.DTOs.Tickets;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Constants;
using TicketsAPI.Domain.Enums;
using TicketsAPI.Domain.Filters;
using TicketsAPI.Domain.Interfaces.Repositories;

namespace TicketsAPI.Application.Services;

public class TicketService: ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<TicketDto>> GetAllAsync(TicketSearchFilter? filter = null)
    {
        var tickets = await _ticketRepository.GetAllAsync(filter);

        return tickets.Adapt<IEnumerable<TicketDto>>();
    }

    public async Task<TicketSummaryDto> GetAllSummaryAsync()
    {
        var tickets = await _ticketRepository.GetAllAsync();
        var ticketsDtos = tickets.Adapt<IEnumerable<TicketDto>>();

        return new TicketSummaryDto()
        {
            OpenTicketsCount = ticketsDtos.Count(x =>
                !string.IsNullOrWhiteSpace(x.Status) 
                && !x.Status.Equals(Tickets.Status.Closed)
                && !x.Status.Equals(Tickets.Status.Resolved)
            ),
            CriticalTicketsCount = ticketsDtos.Count(x =>
                    !string.IsNullOrWhiteSpace(x.Priority)
                    && x.Priority.Equals(nameof(TicketPriorityEnum.P1), StringComparison.OrdinalIgnoreCase)
            ),
            InProgressTicketsCount = ticketsDtos.Count(x =>
                    !string.IsNullOrWhiteSpace(x.Status)
                    && x.Status.Equals(Tickets.Status.InProgress, StringComparison.OrdinalIgnoreCase)
            ),
            ResolvedTicketsCount = ticketsDtos.Count(x =>
                    !string.IsNullOrWhiteSpace(x.Status)
                    && x.Status.Equals(Tickets.Status.Resolved, StringComparison.OrdinalIgnoreCase)
            ),
            Tickets = ticketsDtos
        };
    }

    public async Task<TicketDto?> GetByGuidAsync(Guid guid)
    {
        var ticket = await _ticketRepository.GetByGuidAsync(guid);

        if (ticket is null) return null;

        return ticket.Adapt<TicketDto>();
    }
}
