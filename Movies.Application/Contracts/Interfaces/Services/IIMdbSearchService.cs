using Movies.Domain.Models;
namespace Movies.Application.Interfaces

{
    public interface IIMdbSearchService
    {
        Task<SearchMovie> GetMovieAsync(string apikey, string expression, CancellationToken cancellationToken = default);
    }
}
