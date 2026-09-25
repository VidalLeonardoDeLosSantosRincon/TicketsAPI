using Microsoft.EntityFrameworkCore;
using TicketsAPI.Domain.Models.Teams;
using TicketsAPI.Domain.Models.Users;

namespace TicketsAPI.Infrastructure.Persistence.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base (options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<User> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Entities configuration
            modelBuilder.HasDefaultSchema("helpdesk");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<TeamMember>().ToTable("TeamMembers");
        }
    }
}
