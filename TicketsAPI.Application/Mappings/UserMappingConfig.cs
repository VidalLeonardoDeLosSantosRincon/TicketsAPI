using Mapster;
using TicketsAPI.Application.DTOs.Users;
using TicketsAPI.Domain.Models.Users;

namespace TicketsAPI.Application.Mappings;

public class UserMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Map(dest => dest.Role, src => src.Role);
    }
}
