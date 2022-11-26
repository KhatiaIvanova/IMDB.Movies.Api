using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;
using System.Reflection;

namespace Movies.Persistence.DbContexts
{
    public class SpaceIMDBDbContext : DbContext
    {
        public SpaceIMDBDbContext(DbContextOptions<SpaceIMDBDbContext> ctx) : base(ctx)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<WatchHistoryItem> WatchHistoryItem { get; set; }
    }
}
