using FluentValidation;
using MediatR;
using Movies.Application.Contracts.Interfaces.Repositories;
using Movies.Domain.Models;

namespace Movies.Application.Queries.WatchHistory
{
    public class UpdateWatchHistoryItem : IRequest
    {
        public int UserId { get; set; }
        public string MovieId { get; set; }

    }
    public class UpdateWatchHistoryItemValidator : AbstractValidator<UpdateWatchHistoryItem>
    {
        public UpdateWatchHistoryItemValidator()
        {
            RuleFor(x => x.UserId).NotNull();
        }
    }
    public class UpdateWatchHistoryItemHandler : IRequestHandler<UpdateWatchHistoryItem>
    {
        private readonly IWatchHistoryItemRepository _repository;
        public UpdateWatchHistoryItemHandler(IWatchHistoryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateWatchHistoryItem request, CancellationToken cancellationToken)
        {
            var entity = new WatchHistoryItem()
            {
                UserId = request.UserId,
                MovieId = request.MovieId
            };

            await _repository.MarkWatched(entity, cancellationToken);
            return Unit.Value;
        }
    }
}
