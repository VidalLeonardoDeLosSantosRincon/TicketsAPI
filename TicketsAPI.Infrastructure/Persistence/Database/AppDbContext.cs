using Microsoft.EntityFrameworkCore;
using TicketsAPI.Domain.Models.Teams;
using TicketsAPI.Domain.Models.Tickets;
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
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Entities configuration
            modelBuilder.HasDefaultSchema("helpdesk");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<TeamMember>().ToTable("TeamMembers");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketStatus>().ToTable("TicketStatus");
            modelBuilder.Entity<TicketPriority>().ToTable("TicketPriority");
            modelBuilder.Entity<TicketCategory>().ToTable("TicketCategory");
            //modelBuilder.Entity<TicketAssignment>().ToTable("TicketAssignment");
        }
    }
}
