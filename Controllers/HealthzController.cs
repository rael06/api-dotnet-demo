using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthzController : ControllerBase
{
  [HttpGet]
  public IActionResult Get()
  {
    return Ok("Healthy");
  }
}