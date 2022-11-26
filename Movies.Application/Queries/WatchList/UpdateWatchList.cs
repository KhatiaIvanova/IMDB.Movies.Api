using FluentValidation;
using MediatR;
using Movies.Application.Contracts.Interfaces.Repositories;
using Movies.Domain.Models;

namespace Movies.Application.Queries.WatchList
{
    public class UpdateWatchList : IRequest
    {
        public int UserId { get; set; }
        public string MovieId { get; set; }

    }
    public class UpdateWatchListValidator : AbstractValidator<UpdateWatchList>
    {
        public UpdateWatchListValidator()
        {
            RuleFor(x => x.UserId).NotNull();
        }
    }
    public class UpdateWatchListhandler : IRequestHandler<UpdateWatchList>
    {
        private readonly IWatchHistoryItemRepository _repository;
        public UpdateWatchListhandler(IWatchHistoryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateWatchList request, CancellationToken cancellationToken)
        {
            WatchHistoryItem? entity = new WatchHistoryItem()
            {
                UserId = request.UserId,
                MovieId = request.MovieId
            };

            await _repository.MarkWatched(entity, cancellationToken);
            return Unit.Value;
        }
    }
}
