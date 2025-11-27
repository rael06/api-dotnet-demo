using MyWebAPI.Models;

namespace MyWebAPI.Services.TodoService;

public interface ITodoService
{
  Task<Todo> CreateTodo(CreateTodoInput input);
  Task<ICollection<Todo>> GetTodos();
  Task<Todo?> UpdateTodo(Todo input);
  Task<Todo?> GetTodoById(int id);
  Task<bool> DeleteTodo(int id);
}