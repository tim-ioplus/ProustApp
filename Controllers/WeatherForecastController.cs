using Microsoft.AspNetCore.Mvc;

namespace ProustApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Effing Freezy", "Bratzy Bracy", "Chucking Chilly", "Cranky Cool", "Milky Mild", "Wacky Warm", "Ballsy Balmy", "Heavy Hot", "Swaggy Sweltering", "supé Scorching", "Tres Tittsy"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var weathers =  Enumerable.Range(1, 10).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-50, 50),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        return weathers;
    }
}
