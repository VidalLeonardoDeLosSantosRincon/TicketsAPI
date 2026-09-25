using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketsAPI.Domain.Interfaces.Repositories;
using TicketsAPI.Infrastructure.Persistence.Database;
using TicketsAPI.Infrastructure.Persistence.Repositories;

namespace TicketsAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(
        configuration.GetConnectionString("TicketsDB")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        
        return services;
    }
}