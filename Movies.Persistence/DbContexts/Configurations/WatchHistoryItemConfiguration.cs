using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Models;

namespace Movies.Persistence.Configurations
{
    public class WatchHistoryItemConfiguration : IEntityTypeConfiguration<WatchHistoryItem>
    {
        public void Configure(EntityTypeBuilder<WatchHistoryItem> modelBuilder)
        {
            modelBuilder.HasKey(t => t.Id);
            modelBuilder.HasIndex(t => new { t.UserId, t.MovieId }).IsUnique();
        }
    }
}
