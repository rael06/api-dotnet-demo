using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Services;

namespace MyWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUserService _userService;

  public UsersController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public IActionResult GetUsers()
  {
    var users = _userService.GetAllUsers();
    return Ok(users);
  }

  [HttpGet("age-average")]
  public IActionResult GetAgeAverage()
  {
    var averageAge = _userService.GetAverageAge();

    return Ok(averageAge);
  }
}