using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;
using Movies.Persistence.DbContexts;



namespace Movies.Persistence.Repositories
{
    public class WatchHistoryItemRepository : Application.Contracts.Interfaces.Repositories.IWatchHistoryItemRepository
    {
        public SpaceIMDBDbContext DbContext { get; }

        public WatchHistoryItemRepository(SpaceIMDBDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public async Task Add(WatchHistoryItem entity, CancellationToken cancellationToken = default)
        {
            await DbContext.WatchHistoryItem.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<WatchHistoryItem>> Get(int userId, CancellationToken cancellationToken = default)
        {
            return await DbContext.WatchHistoryItem.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task MarkWatched(WatchHistoryItem entity, CancellationToken cancellationToken = default)
        {
            WatchHistoryItem? watchHistoryItem = await DbContext.WatchHistoryItem.FirstOrDefaultAsync(x => x.UserId == entity.UserId && x.MovieId == entity.MovieId);
            if (watchHistoryItem == null)
            {
                return;
            }

            watchHistoryItem.Watched = true;

            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
