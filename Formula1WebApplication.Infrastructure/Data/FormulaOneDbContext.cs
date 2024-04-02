using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Data.SeedDb.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Formula1WebApplication.Infrastructure.Data
{
    public class FormulaOneDbContext : IdentityDbContext
    {
        public FormulaOneDbContext(DbContextOptions<FormulaOneDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventUser>()
                .HasKey(eu => new { eu.EventId, eu.UserId });

            builder.Entity<EventUser>()
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OrganizerConfiguration());
            builder.ApplyConfiguration(new PilotConfiguration());
            builder.ApplyConfiguration(new RaceConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new NewsArticleConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Organizer> Organizers { get; set; } = null!;
        public DbSet<Pilot> Pilots { get; set; } = null!;
        public DbSet<Race> Races { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<NewsArticle> NewsArticles { get; set; } = null!;
        public DbSet<EventUser> EventsUsers { get; set; }
    }
}
