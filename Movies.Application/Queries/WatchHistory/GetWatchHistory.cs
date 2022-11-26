using FluentValidation;
using MediatR;
using Movies.Application.Contracts.Interfaces.Repositories;
using Movies.Domain.Models;

namespace Movies.Application.Queries.WatchHistory;

public class GetWatchHistory : IRequest<List<WatchHistoryItem>>
{
    public int UserId { get; set; }
}
public class GetWatchHistoryValidator : AbstractValidator<GetWatchHistory>
{
    public GetWatchHistoryValidator()
    {
        RuleFor(x => x.UserId).NotNull();
    }
}
public class GetWatchHistoryHandler : IRequestHandler<GetWatchHistory, List<WatchHistoryItem>>
{
    private readonly IWatchHistoryItemRepository _repository;
    public GetWatchHistoryHandler(IWatchHistoryItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WatchHistoryItem>> Handle(GetWatchHistory request, CancellationToken cancellationToken)
    {
        List<WatchHistoryItem>? watchList = await _repository.Get(request.UserId, cancellationToken);
        return watchList ?? throw new InvalidOperationException();
    }
}