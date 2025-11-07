using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers;

[ApiController]
[Route("[controller]s")]
public class UserController : ControllerBase
{
  private static readonly List<User> users =
  [
    new User(1, "Alice", 30),
    new User(2, "Bob", 25),
    new User(3, "Charlie", 35)
  ];

  [HttpGet]
  public IActionResult GetUsers()
  {
    return Ok(users);
  }
}