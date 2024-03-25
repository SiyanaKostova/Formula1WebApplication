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

        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
    }
}
