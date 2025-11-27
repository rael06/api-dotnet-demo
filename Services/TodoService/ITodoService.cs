using MyWebAPI.Models;

namespace MyWebAPI.Services.TodoService;

public interface ITodoService
{
  Task<Todo> CreateTodo(CreateTodoInput input);
  Task<ICollection<Todo>> GetTodos();
}