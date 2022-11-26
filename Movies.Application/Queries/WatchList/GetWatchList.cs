using FluentValidation;
using MediatR;
using Movies.Application.Contracts.Interfaces.Repositories;
using Movies.Domain.Models;

namespace Movies.Application.Queries.WatchList;

public class GetWatchList : IRequest<List<WatchHistoryItem>>
{
    public int UserId { get; set; }
}
public class GetWatchListValidator : AbstractValidator<GetWatchList>
{
    public GetWatchListValidator()
    {
        RuleFor(x => x.UserId).NotNull();
    }
}
public class GetWatchListHandler : IRequestHandler<GetWatchList, List<WatchHistoryItem>>
{
    private readonly IWatchHistoryItemRepository _repository;
    public GetWatchListHandler(IWatchHistoryItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WatchHistoryItem>> Handle(GetWatchList request, CancellationToken cancellationToken)
    {
        List<WatchHistoryItem>? watchList = await _repository.Get(request.UserId, cancellationToken);
        return watchList ?? throw new InvalidOperationException();
    }
}