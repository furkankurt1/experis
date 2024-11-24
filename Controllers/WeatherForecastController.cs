using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Experis.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Get Weather Forecast.
    /// </summary>
    /// <returns>A list of weather forecasts.</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _mediator.Send(new GetWeatherForecastQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching weather forecasts.");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}