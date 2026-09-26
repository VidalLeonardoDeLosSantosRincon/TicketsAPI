using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketsAPI.Application.Interfaces.Services.Auth;
using TicketsAPI.Application.Services;
using TicketsAPI.Application.Services.Auth;

namespace TicketsAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
    this IServiceCollection services)
    {
        // Mapster
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        services.AddMapster();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<ITicketStatusService, TicketStatusService>();
        services.AddScoped<ITicketPriorityService, TicketPriorityService>();
        services.AddScoped<ITicketCategoryService, TicketCategoryService>();

        return services;
    }
}
