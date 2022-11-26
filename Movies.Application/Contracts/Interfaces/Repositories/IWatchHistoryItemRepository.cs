using Movies.Domain.Models;

namespace Movies.Application.Contracts.Interfaces.Repositories
{
    public interface IWatchHistoryItemRepository
    {
        Task<List<WatchHistoryItem>> Get(int userId, CancellationToken cancellationToken = default);
        Task Add(WatchHistoryItem entity, CancellationToken cancellationToken = default);
        Task MarkWatched(WatchHistoryItem entity, CancellationToken cancellationToken = default);
    }
}
