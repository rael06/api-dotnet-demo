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
      IsDone = false,
      UserId = input.UserId
    };

    var createdTodo = await _todoRepository.CreateTodo(todo);
    return createdTodo;
  }

  public async Task<ICollection<Todo>> GetTodos()
  {
    return await _todoRepository.GetTodos();
  }

  public async Task<Todo?> UpdateTodo(Todo input)
  {
    var todoToUpdate = await _todoRepository.GetTodoById(input.Id);
    if (todoToUpdate == null)
    {
      return null;
    }
    todoToUpdate.Title = input.Title;
    todoToUpdate.Description = input.Description;
    todoToUpdate.DueDate = input.DueDate;
    todoToUpdate.IsDone = input.IsDone;
    todoToUpdate.UpdateDate = DateTime.UtcNow;
    var updatedTodo = await _todoRepository.UpdateTodo(todoToUpdate);

    return updatedTodo;
  }

  public async Task<Todo?> GetTodoById(int id)
  {
    return await _todoRepository.GetTodoById(id);
  }

  public async Task<bool> DeleteTodo(int id)
  {
    var isSuccess = await _todoRepository.DeleteTodo(id);
    return isSuccess;
  }
}
