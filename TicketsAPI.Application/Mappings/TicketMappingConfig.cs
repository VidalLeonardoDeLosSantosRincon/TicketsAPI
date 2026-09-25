using Mapster;
using TicketsAPI.Application.DTOs.Tickets;
using TicketsAPI.Domain.Models.Tickets;

namespace TicketsAPI.Application.Mappings;

public class TicketMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Ticket, TicketDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Code, src => $"tkt-{src.Id}")
            .Map(dest => dest.Status, src => src!.Status!.Code)
            .Map(dest => dest.Priority, src => src!.Priority!.Code)
            .Map(dest => dest.Category, src => src!.Category!.Code)
            //.Map(dest => dest.TeamCode, src => src!.TeamMember!.TeamId!.ToString())
            //.Map(dest => dest.Assignee, src => src!.TeamMember!.Name)
            .Map(dest => dest.Requester, src => src!.User!.Name);
    }
}
