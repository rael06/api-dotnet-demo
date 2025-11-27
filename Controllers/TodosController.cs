using Microsoft.AspNetCore.Mvc;
using MyWebAPI.DTO;
using MyWebAPI.Models;
using MyWebAPI.Services.TodoService;

namespace MyWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
  private readonly ITodoService _todoService;

  public TodosController(ITodoService todoService)
  {
    _todoService = todoService;
  }

  [HttpPost]
  public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequestDto requestDto)
  {
    var input = new CreateTodoInput(
      title: requestDto.Title,
      description: requestDto.Description,
      dueDate: requestDto.DueDate,
      userId: requestDto.UserId
    );

    var model = await _todoService.CreateTodo(input);

    var responseDto = new GetTodoResponseDto
    {
      Id = model.Id,
      Title = model.Title,
      Description = model.Description,
      CreationDate = model.CreationDate,
      UpdateDate = model.UpdateDate,
      DueDate = model.DueDate,
      IsDone = model.IsDone,
      UserId = model.UserId
    };

    return CreatedAtAction(null, new { id = model.Id }, responseDto);
  }

  [HttpGet]
  public async Task<IActionResult> GetTodos()
  {
    var models = await _todoService.GetTodos();
    var dto = models.Select(t => new GetTodoWithoutDescriptionResponseDto
    {
      Id = t.Id,
      Title = t.Title,
      CreationDate = t.CreationDate,
      UpdateDate = t.UpdateDate,
      DueDate = t.DueDate,
      IsDone = t.IsDone,
      UserId = t.UserId
    });

    return Ok(dto);
  }

  [HttpPut("{todoId}")]
  public async Task<IActionResult> UpdateTodo(int todoId, [FromBody] UpdateTodoRequestDto requestDto)
  {
    if (todoId != requestDto.Id)
    {
      return BadRequest("The todo ID in the URL does not match the ID in the request body.");
    }

    var input = new Todo
    {
      Id = requestDto.Id,
      Title = requestDto.Title,
      Description = requestDto.Description,
      DueDate = requestDto.DueDate,
      CreationDate = requestDto.CreationDate,
      UpdateDate = requestDto.UpdateDate,
      IsDone = requestDto.IsDone,
      UserId = requestDto.UserId
    };

    var model = await _todoService.UpdateTodo(input);
    if (model == null)
    {
      return NotFound();
    }

    var dto = new GetTodoResponseDto
    {
      Id = model.Id,
      Title = model.Title,
      Description = model.Description,
      CreationDate = model.CreationDate,
      UpdateDate = model.UpdateDate,
      DueDate = model.DueDate,
      IsDone = model.IsDone,
      UserId = model.UserId
    };

    return Ok(dto);
  }

  [HttpGet("{todoId}")]
  public async Task<IActionResult> GetTodoById(int todoId)
  {
    var model = await _todoService.GetTodoById(todoId);
    if (model == null)
    {
      return NotFound();
    }

    var dto = new GetTodoResponseDto
    {
      Id = model.Id,
      Title = model.Title,
      Description = model.Description,
      CreationDate = model.CreationDate,
      UpdateDate = model.UpdateDate,
      DueDate = model.DueDate,
      IsDone = model.IsDone,
      UserId = model.UserId
    };

    return Ok(dto);
  }

  [HttpDelete("{todoId}")]
  public async Task<IActionResult> DeleteTodo(int todoId)
  {
    var isSuccess = await _todoService.DeleteTodo(todoId);
    if (!isSuccess)
    {
      return NotFound();
    }

    return NoContent();
  }
}