using Mapster;
using TicketsAPI.Application.DTOs.Tickets;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Interfaces.Repositories;

namespace TicketsAPI.Application.Services;

public class TicketService: ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<TicketDto>> GetAll()
    {
        var tickets = await _ticketRepository.GetAll();

        return tickets.Adapt<IEnumerable<TicketDto>>();
    }

    public async Task<TicketDto?> GetByGuid(Guid guid)
    {
        var ticket = await _ticketRepository.GetByGuid(guid);

        if (ticket is null) return null;

        return ticket.Adapt<TicketDto>();
    }
}
