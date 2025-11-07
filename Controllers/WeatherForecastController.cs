using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries =
    [
      "Freezing", "Bracing", "Chilly",
      "Cool", "Mild", "Warm", "Balmy",
      "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    public IActionResult Get()
    {
      var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      });
      return Ok(weatherForecasts);
    }

    [HttpGet("{summaryIndex}")]
    public IActionResult GetBySummaryIndex(int summaryIndex)
    {
      if (summaryIndex < 0 || summaryIndex >= Summaries.Length)
      {
        return BadRequest("Invalid summary index.");
      }

      var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[summaryIndex]
      });
      return Ok(weatherForecasts);
    }
  }

  public class WeatherForecast
  {
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
  }
}