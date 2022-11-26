using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Queries;
using Movies.Domain.Models;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ISender _sender;

        public MoviesController(ISender sender)
        {
            _sender = sender;
        }
        /// <summary>
        /// Gets Movie list using API key and movie name.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(SearchMovie), 200)]
        public async Task<IActionResult> GetMovieList(string apiKey, string expression, CancellationToken cancellationToken)
        {

            var query = new MoviesQuery() { ApiKey = apiKey, Expression = expression };

            var response = await _sender.Send(query, cancellationToken);
            return Ok(response);
        }
    }
}
