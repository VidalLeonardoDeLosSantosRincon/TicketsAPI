using Mapster;
using TicketsAPI.Application.DTOs.Teams;
using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Application.Mappings;

public class TeamMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Team, TeamDto>()
            .Map(dest => dest.MemberCount, src => src.Members.Count);
    }
}
