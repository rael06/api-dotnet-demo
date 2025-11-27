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
      requestDto.Title,
      requestDto.Description,
      requestDto.DueDate
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
      IsDone = model.IsDone
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
      IsDone = t.IsDone
    });

    return Ok(dto);
  }
}