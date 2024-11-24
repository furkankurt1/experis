using Business.Handlers.Lottery.Commands;
using Business.Handlers.Lottery.Queries;
using Business.Handlers.Ticket.Commands;
using Business.Handlers.Ticket.Queires;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Experis.Controllers;

[ApiController] [Route("[controller]")]
public class LotteriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public LotteriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateLottery", Name = "CreateLottery")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateLottery([FromBody] CreateLotteryCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("GetAllLotteries", Name = "GetAllLotteries")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllLotteries()
    {
        var result = await _mediator.Send(new GetAllLotteriesQuery());
        return result.Success ? Ok(result) : BadRequest(result);
    }
}