using FluentValidation;
using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Models;

namespace Movies.Application.Queries
{
    public class MoviesQuery : IRequest<SearchMovie>
    {
        public string ApiKey { get; set; }
        public string Expression { get; set; }

    }
    public class MoviesQueryValidator : AbstractValidator<MoviesQuery>
    {
        public MoviesQueryValidator()
        {
            RuleFor(x => x.ApiKey).NotNull();
            RuleFor(x => x.Expression).Length(4, 50);
        }
    }
    public class MoviesQueryHandler : IRequestHandler<MoviesQuery, SearchMovie>
    {
        private readonly IIMdbSearchService _movieApiService;
        private readonly IValidator<MoviesQuery> _validator;

        public MoviesQueryHandler(IIMdbSearchService movieApiService, IValidator<MoviesQuery> validator)
        {
            _movieApiService = movieApiService;
            _validator = validator;
        }

        public async Task<SearchMovie> Handle(MoviesQuery request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult? result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                throw new ArgumentException();
            }

            SearchMovie? movies = await _movieApiService.GetMovieAsync(request.ApiKey, request.Expression, cancellationToken);
            return movies ?? throw new InvalidOperationException();
        }
    }
}
