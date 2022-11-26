using FluentValidation;
using MediatR;
using Movies.Application.Contracts.Interfaces.Repositories;
using Movies.Domain.Models;
namespace Movies.Application.Queries.WatchList;

public class AddWatchHistoryItemRequest : IRequest
{
    public int UserId { get; set; }
    public string MovieId { get; set; }
    public string MovieName { get; set; }
    public string StoppedTime { get; set; }
    public bool Seen { get; set; } = false;
}
public class AddWatchHistoryItemValidator : AbstractValidator<AddWatchHistoryItemRequest>
{
    public AddWatchHistoryItemValidator()
    {
        RuleFor(x => x.UserId).NotNull();
        RuleFor(x => x.MovieId).NotNull();
    }
}
public class AddWatchHistoryItemRequestHandler : IRequestHandler<AddWatchHistoryItemRequest>
{
    private readonly IWatchHistoryItemRepository _repository;

    public AddWatchHistoryItemRequestHandler(IWatchHistoryItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddWatchHistoryItemRequest request, CancellationToken cancellationToken)
    {
        WatchHistoryItem? entity = new WatchHistoryItem()
        {
            UserId = request.UserId,
            MovieId = request.MovieId,
            MovieName = request.MovieName,
            StoppedTime = request.StoppedTime,
            Watched = request.Seen,

        };

        await _repository.Add(entity, cancellationToken);
        return Unit.Value;
    }
}