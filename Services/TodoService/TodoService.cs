using MyWebAPI.Infrastructure.Database.Repositories;
using MyWebAPI.Models;

namespace MyWebAPI.Services.TodoService;

public class TodoService : ITodoService
{
  private readonly ITodoRepository _todoRepository;
  public TodoService(ITodoRepository todoRepository)
  {
    _todoRepository = todoRepository;
  }

  public async Task<Todo> CreateTodo(CreateTodoInput input)
  {
    var todo = new Todo
    {
      Title = input.Title,
      Description = input.Description,
      CreationDate = DateTime.UtcNow,
      DueDate = input.DueDate,
      IsDone = false
    };

    var createdTodo = await _todoRepository.CreateTodo(todo);
    return createdTodo;
  }

  public async Task<ICollection<Todo>> GetTodos()
  {
    return await _todoRepository.GetTodos();
  }
}