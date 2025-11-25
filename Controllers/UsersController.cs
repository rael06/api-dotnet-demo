using Microsoft.AspNetCore.Mvc;
using MyWebAPI.DTO;
using MyWebAPI.Services.UserService;

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
  public async Task<IActionResult> GetUsers([FromQuery] GetUsersSearchParamsDto? searchParams)
  {
    var input = new GetUsersInput
    {
      MinAge = searchParams?.MinAge,
      MaxAge = searchParams?.MaxAge
    };

    var models = await _userService.GetUsers(input);

    var dto = models.Select(u => new GetUserResponseDto
    (
      id: u.Id,
      username: u.Username,
      age: u.Age
    ));

    return Ok(dto);
  }

  [HttpGet("age-average")]
  public async Task<IActionResult> GetAgeAverage()
  {
    var averageAge = await _userService.GetAverageAge();

    return Ok(averageAge);
  }

  [HttpGet("{userId}")]
  public async Task<IActionResult> GetUserById(int userId)
  {
    var model = await _userService.GetUserById(userId);

    if (model == null)
    {
      return NotFound();
    }

    var dto = new GetUserResponseDto
    (
      id: model.Id,
      username: model.Username,
      age: model.Age
    );

    return Ok(dto);
  }

  [HttpPost]
  public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto requestDto)
  {
    var input = new CreateUserInput
    (
      username: requestDto.Username,
      age: requestDto.Age,
      password: requestDto.Password
    );

    var model = await _userService.CreateUser(input);

    var responseDto = new GetUserResponseDto
    (
      id: model.Id,
      username: model.Username,
      age: model.Age
    );

    return CreatedAtAction(nameof(GetUserById), new { userId = model.Id }, responseDto);
  }

  [HttpDelete("{userId}")]
  public async Task<IActionResult> DeleteUser(int userId)
  {
    var output = await _userService.DeleteUser(userId);

    return output.Status switch
    {
      DeleteUserStatus.Success => NoContent(),
      DeleteUserStatus.NotFound => NotFound($"User with id {userId} not found"),
    };
  }

  [HttpPut("{userId}")]
  public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserRequestDto requestDto)
  {
    if (requestDto.Id != userId)
    {
      return BadRequest($"Id: {requestDto.Id} in the request body does not match the id: {userId} in the URL");
    }

    var input = new UpdateUserInput(
      id: requestDto.Id,
      username: requestDto.Username,
      age: requestDto.Age
    );

    var model = await _userService.UpdateUser(input);

    if (model == null)
    {
      return NotFound($"User with id {userId} not found");
    }

    var dto = new GetUserResponseDto(
      id: model.Id,
      username: model.Username,
      age: model.Age
    );

    return Ok(dto);
  }
}