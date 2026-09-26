using TicketsAPI.Application.DTOs;
using TicketsAPI.Domain.ValueObjects;

namespace TicketsAPI.Application.Mappings;

public class OptionObjectMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OptionObject, OptionObjectDto>();
    }
}
