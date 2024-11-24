using Business.Handlers.Lottery.Commands;
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


    [HttpPost(Name = "CreateLottery")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateLottery([FromBody] CreateLotteryCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}