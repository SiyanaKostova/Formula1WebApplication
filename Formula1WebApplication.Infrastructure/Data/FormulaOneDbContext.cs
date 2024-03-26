using Formula1WebApplication.Infrastructure.Data.Models;
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
            builder.Entity<Race>()
            .HasOne(r => r.Organizer)
            .WithMany(o => o.Races)
            .HasForeignKey(r => r.OrganizerId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
            .HasOne(e => e.Organizer) 
            .WithMany(o => o.Events) 
            .HasForeignKey(e => e.OrganizerId) 
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<NewsArticle>()
            .HasOne(n => n.Organizer) 
            .WithMany(o => o.NewsArticles) 
            .HasForeignKey(n => n.OrganizerId) 
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
    }
}
