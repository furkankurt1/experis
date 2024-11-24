using Business.Handlers.Lottery.Commands;
using Business.Handlers.Ticket.Commands;
using Business.Handlers.Ticket.Queires;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Experis.Controllers;

[ApiController] [Route("[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("BuyTicket", Name = "BuyTicket")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuyTicket([FromBody] BuyTicketCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("GetAvailableTickets", Name = "GetAvailableTickets")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAvailableTickets([FromQuery] GetAvailableTicketsQuery query)
    {
        var result = await _mediator.Send(query);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}