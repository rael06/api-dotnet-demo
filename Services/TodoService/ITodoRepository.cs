using MyWebAPI.Models;

namespace MyWebAPI.Services.TodoService;

public interface ITodoRepository
{
  Task<Todo> CreateTodo(Todo todo);
  Task<ICollection<Todo>> GetTodos();
}