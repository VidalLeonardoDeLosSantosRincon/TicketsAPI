using Microsoft.EntityFrameworkCore;
using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Infrastructure.Persistence.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base (options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Entities configuration
            modelBuilder.HasDefaultSchema("helpdesk");
            modelBuilder.Entity<Team>().ToTable("Team");
        }
    }
}
