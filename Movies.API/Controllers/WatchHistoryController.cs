using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Queries.WatchHistory;

namespace Movies.API.Controllers;

[Route("api/v1/[controller]")]
public class WatchHistoryController : ControllerBase
{

    private readonly ISender _sender;
    public WatchHistoryController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Creates watch history item for user.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// 
    [HttpPost("Add")]
    public async Task<IActionResult> Add(AddWatchHistoryItemRequest command, CancellationToken cancellationToken)
    {
        try
        {
            await _sender.Send(command, cancellationToken);
        }
        catch
        {
            return Conflict("Item already exists");
        }
        return Ok();
    }

    /// <summary>
    /// Gets user watch history
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>


    [HttpGet("Get")]
    public async Task<IActionResult> Get(int userId, CancellationToken cancellationToken)
    {
        GetWatchHistory? query = new GetWatchHistory() { UserId = userId };
        List<Domain.Models.WatchHistoryItem>? response = await _sender.Send(query, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Marks the film as watched in watch history
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>


    [HttpPut("Update")]
    public async Task<IActionResult> Update(int userId, string movieId, CancellationToken cancellationToken)
    {
        UpdateWatchHistoryItem? query = new UpdateWatchHistoryItem() { UserId = userId, MovieId = movieId };
        Unit response = await _sender.Send(query, cancellationToken);
        return Ok(response);
    }


}