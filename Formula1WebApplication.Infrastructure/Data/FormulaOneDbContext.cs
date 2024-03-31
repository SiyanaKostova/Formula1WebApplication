using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Data.SeedDb.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
